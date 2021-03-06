
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.Ide.Gui.Dialogs
{
	internal partial class GtkErrorDialog
	{
		private global::Gtk.HBox hbox1;
		private global::Gtk.Image image884;
		private global::Gtk.VBox vbox3;
		private global::Gtk.Label descriptionLabel;
		private global::Gtk.Expander expander;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView detailsTextView;
		private global::Gtk.Label expanderLabel;
		private global::Gtk.Button okButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.Ide.Gui.Dialogs.GtkErrorDialog
			this.Name = "MonoDevelop.Ide.Gui.Dialogs.GtkErrorDialog";
			this.Title = global::MonoDevelop.Core.GettextCatalog.GetString ("MonoDevelop");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child MonoDevelop.Ide.Gui.Dialogs.GtkErrorDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			this.hbox1.BorderWidth = ((uint)(12));
			// Container child hbox1.Gtk.Box+BoxChild
			this.image884 = new global::Gtk.Image ();
			this.image884.Name = "image884";
			this.image884.Yalign = 0F;
			this.image884.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-dialog-error", global::Gtk.IconSize.Dialog);
			this.hbox1.Add (this.image884);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.image884]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.descriptionLabel = new global::Gtk.Label ();
			this.descriptionLabel.Name = "descriptionLabel";
			this.descriptionLabel.Xalign = 0F;
			this.descriptionLabel.LabelProp = "An exception has been thrown 1 2 3 4 5 6 7 8 9 10 11 12 13 14";
			this.descriptionLabel.Wrap = true;
			this.descriptionLabel.Selectable = true;
			this.vbox3.Add (this.descriptionLabel);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.descriptionLabel]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.expander = new global::Gtk.Expander (null);
			this.expander.CanFocus = true;
			this.expander.Name = "expander";
			// Container child expander.Gtk.Container+ContainerChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.HeightRequest = 250;
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.detailsTextView = new global::Gtk.TextView ();
			this.detailsTextView.CanFocus = true;
			this.detailsTextView.Name = "detailsTextView";
			this.GtkScrolledWindow.Add (this.detailsTextView);
			this.expander.Add (this.GtkScrolledWindow);
			this.expanderLabel = new global::Gtk.Label ();
			this.expanderLabel.Name = "expanderLabel";
			this.expanderLabel.LabelProp = global::MonoDevelop.Core.GettextCatalog.GetString ("Details");
			this.expanderLabel.UseUnderline = true;
			this.expander.LabelWidget = this.expanderLabel;
			this.vbox3.Add (this.expander);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.expander]));
			w6.Position = 1;
			this.hbox1.Add (this.vbox3);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox3]));
			w7.Position = 1;
			w1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(w1 [this.hbox1]));
			w8.Position = 0;
			// Internal child MonoDevelop.Ide.Gui.Dialogs.GtkErrorDialog.ActionArea
			global::Gtk.HButtonBox w9 = this.ActionArea;
			w9.Name = "dialog1_ActionArea";
			w9.Spacing = 10;
			w9.BorderWidth = ((uint)(5));
			w9.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.okButton = new global::Gtk.Button ();
			this.okButton.CanDefault = true;
			this.okButton.CanFocus = true;
			this.okButton.Name = "okButton";
			this.okButton.UseStock = true;
			this.okButton.UseUnderline = true;
			this.okButton.Label = "gtk-ok";
			this.AddActionWidget (this.okButton, -5);
			global::Gtk.ButtonBox.ButtonBoxChild w10 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w9 [this.okButton]));
			w10.Expand = false;
			w10.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 624;
			this.DefaultHeight = 142;
			this.Hide ();
			this.expander.Activated += new global::System.EventHandler (this.OnExpander1Activated);
			this.okButton.Clicked += new global::System.EventHandler (this.OnOkButtonClicked);
		}
	}
}
