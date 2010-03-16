// 
// CSharpFormattingPolicyPanel.cs
//  
// Author:
//       Mike Krüger <mkrueger@novell.com>
// 
// Copyright (c) 2009 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using MonoDevelop.Projects.Gui.Dialogs;
using Gtk;
using MonoDevelop.Ide.CodeFormatting;
using MonoDevelop.Core;
using MonoDevelop.Projects.Text;
using System.Xml;

namespace MonoDevelop.CSharp.Formatting
{
	class CSharpFormattingPolicyPanel : MimeTypePolicyOptionsPanel<CSharpFormattingPolicy>
	{
		TypedCodeFormattingPolicyPanelWidget<CSharpFormattingPolicy> panel;
		
		public static CodeFormatDescription CodeFormatDescription {
			get {
				XmlReaderSettings settings = new XmlReaderSettings ();
				settings.CloseInput = true;
				using (XmlReader reader = XmlTextReader.Create (typeof (CSharpFormattingPolicy).Assembly.GetManifestResourceStream ("CSharpFormattingPolicy.xml"), settings)) {
					return CodeFormatDescription.Read (reader);
				}
			}
		}
		
		public override Widget CreatePanelWidget ()
		{
			panel = new TypedCodeFormattingPolicyPanelWidget<CSharpFormattingPolicy> ();
			return panel;
		}
		
		CSharpFormattingPolicy policy;
		protected override void LoadFrom (CSharpFormattingPolicy policy)
		{
			this.policy = policy.Clone ();
			panel.SetFormat (CodeFormatDescription, this.policy);
		}
		
		protected override CSharpFormattingPolicy GetPolicy ()
		{
			return policy;
		}
	}
}