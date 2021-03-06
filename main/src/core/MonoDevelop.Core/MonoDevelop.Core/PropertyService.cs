//
// PropertyService.cs
//
// Author:
//   Mike Krüger <mkrueger@novell.com>
//
// Copyright (C) 2007 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace MonoDevelop.Core
{
	public static class PropertyService
	{
		const string CURRENT_PROFILE_VERSION = "2.6";
		
		readonly static string FileName = "MonoDevelopProperties.xml";
		static Properties properties;

		public readonly static bool IsWindows;
		public readonly static bool IsMac;

		public static Properties GlobalInstance {
			get { return properties; }
		}
		
		public static FilePath EntryAssemblyPath {
			get {
				if (Assembly.GetEntryAssembly () != null)
					return Path.GetDirectoryName (Assembly.GetEntryAssembly ().Location);
				return AppDomain.CurrentDomain.BaseDirectory;
			}
		}
		
		public static UserDataLocations Locations {
			get; private set;
		}
		
		/// <summary>
		/// Location of data files that are bundled with MonoDevelop itself.
		/// </summary>
		public static FilePath DataPath {
			get {
				string result = System.Configuration.ConfigurationManager.AppSettings ["DataDirectory"];
				if (String.IsNullOrEmpty (result)) 
					result = Path.Combine (EntryAssemblyPath, Path.Combine ("..", "data"));
				return result;
			}
		}
		
		//From Managed.Windows.Forms/XplatUI
		static bool IsRunningOnMac ()
		{
			IntPtr buf = IntPtr.Zero;
			try {
				buf = System.Runtime.InteropServices.Marshal.AllocHGlobal (8192);
				// This is a hacktastic way of getting sysname from uname ()
				if (uname (buf) == 0) {
					string os = System.Runtime.InteropServices.Marshal.PtrToStringAnsi (buf);
					if (os == "Darwin")
						return true;
				}
			} catch {
			} finally {
				if (buf != IntPtr.Zero)
					System.Runtime.InteropServices.Marshal.FreeHGlobal (buf);
			}
			return false;
		}
		
		[System.Runtime.InteropServices.DllImport ("libc")]
		static extern int uname (IntPtr buf);
		
		static PropertyService ()
		{
			Counters.PropertyServiceInitialization.BeginTiming ();
			
			IsWindows = Path.DirectorySeparatorChar == '\\';
			IsMac = !IsWindows && IsRunningOnMac ();
			
			FilePath testProfileRoot = Environment.GetEnvironmentVariable ("MONODEVELOP_PROFILE");
			if (!testProfileRoot.IsNullOrEmpty) {
				Locations = UserDataLocations.ForTest (CURRENT_PROFILE_VERSION, testProfileRoot);
			} else {
				Locations = GetLocations (CURRENT_PROFILE_VERSION);
			}
			
			string migrateVersion = null;
			UserDataLocations migratableProfile = null;
			
			var prefsPath = Locations.Config.Combine (FileName);
			if (!File.Exists (prefsPath)) {
				if (GetMigratableProfile (testProfileRoot, out migratableProfile, out migrateVersion)) {
					FilePath migratePrefsPath = migratableProfile.Config.Combine (FileName);
					try {
						var parentDir = prefsPath.ParentDirectory;
						//can't use file service until property sevice in initialized
						if (!Directory.Exists (parentDir))
							Directory.CreateDirectory (parentDir);
						File.Copy (migratePrefsPath, prefsPath);
						LoggingService.LogInfo ("Migrated core properties from {0}", migratePrefsPath);
					} catch (IOException ex) {
						string message = string.Format ("Failed to migrate core properties from {0}", migratePrefsPath);
						LoggingService.LogError (message, ex);
					}
				} else {
					LoggingService.LogInfo ("Did not find previous version from which to migrate data");	
				}
			}
			
			if (!LoadProperties (prefsPath)) {
				properties = new Properties ();
				properties.Set ("MonoDevelop.Core.FirstRun", true);
			}
			
			if (migratableProfile != null)
				UserDataMigrationService.SetMigrationSource (migratableProfile, migrateVersion);
			
			properties.PropertyChanged += delegate(object sender, PropertyChangedEventArgs args) {
				if (PropertyChanged != null)
					PropertyChanged (sender, args);
			};
			
			Counters.PropertyServiceInitialization.EndTiming ();
		}
		
		static UserDataLocations GetLocations (string profileVersion)
		{
			if (IsWindows)
				return UserDataLocations.ForWindows (profileVersion);
			else if (IsWindows)
				return UserDataLocations.ForMac (profileVersion);
			else
				return UserDataLocations.ForUnix (profileVersion);
		}
		
		static bool GetMigratableProfile (FilePath testProfileRoot, out UserDataLocations profile, out string version)
		{
			profile = null;
			version = null;
			
			//TODO: check 2.6 when 2.8 is released, etc
			string[] migratableVersions = { };
			
			//test profiles only migrate from test profiles
			if (!testProfileRoot.IsNullOrEmpty) {
				for (int i = migratableVersions.Length -1; i >= 0; i--) {
					var p = UserDataLocations.ForTest (migratableVersions[i], testProfileRoot);
					if (File.Exists (p.Config.Combine (FileName))) {
						profile = p;
						version = migratableVersions[i];
						return true;
					}
				}
				return false;
			}
			
			//try versioned profiles
			for (int i = migratableVersions.Length -1; i >= 0; i--) {
				var p = UserDataLocations.ForTest (migratableVersions[i], testProfileRoot);
				if (File.Exists (p.Config.Combine (FileName))) {
					profile = p;
					version = migratableVersions[i];
					return true;
				}
			}
			
			//try the old unversioned MD <= 2.4 profile
			var md24 = UserDataLocations.ForMD24 ();
			if (File.Exists (md24.Config.Combine (FileName))) {
				profile = md24;
				version = "2.4";
				return true;
			}
			return false;
		}
		
		static bool LoadProperties (string fileName)
		{
			properties = null;
			if (File.Exists (fileName)) {
				try {
					properties = Properties.Load (fileName);
				} catch (Exception ex) {
					LoggingService.LogError ("Error loading properties from file '{0}':\n{1}", fileName, ex);
				}
			}
			
			//if it failed and a backup file exists, try that instead
			string backupFile = fileName + ".previous";
			if (properties == null && File.Exists (backupFile)) {
				try {
					properties = Properties.Load (backupFile);
				} catch (Exception ex) {
					LoggingService.LogError ("Error loading properties from backup file '{0}':\n{1}", backupFile, ex);
				}
			}
			return properties != null;
		}
		
		public static void SaveProperties ()
		{
			Debug.Assert (properties != null);
			var prefsPath = Locations.Config.Combine (FileName);
			FileService.EnsureDirectoryExists (prefsPath.ParentDirectory);
			properties.Save (prefsPath);
		}
		
		public static T Get<T> (string property, T defaultValue)
		{
			return properties.Get (property, defaultValue);
		}
		
		public static T Get<T> (string property)
		{
			return properties.Get<T> (property);
		}
		
		public static void Set (string key, object val)
		{
			properties.Set (key, val);
		}
		
		public static void AddPropertyHandler (string propertyName, EventHandler<PropertyChangedEventArgs> handler)
		{
			properties.AddPropertyHandler (propertyName, handler);
		}
		
		public static void RemovePropertyHandler (string propertyName, EventHandler<PropertyChangedEventArgs> handler)
		{
			properties.RemovePropertyHandler (propertyName, handler);
		}
		
		public static event EventHandler<PropertyChangedEventArgs> PropertyChanged;
	}
}
