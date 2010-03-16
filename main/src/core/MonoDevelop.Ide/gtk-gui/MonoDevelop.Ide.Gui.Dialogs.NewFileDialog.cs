
// This file has been generated by the GUI designer. Do not modify.
namespace MonoDevelop.Ide.Gui.Dialogs
{
	internal partial class NewFileDialog
	{
		private global::Gtk.VBox vbox2;

		private global::Gtk.HBox hbox1;

		private global::Gtk.ScrolledWindow scrolledwindow1;

		private global::Gtk.TreeView catView;

		private global::MonoDevelop.Components.IconView iconView;

		private global::Gtk.Frame frame1;

		private global::Gtk.Alignment GtkAlignment2;

		private global::Gtk.Label infoLabel;

		private global::Gtk.Label label1;

		private global::Gtk.HBox hbox2;

		private global::Gtk.Label label2;

		private global::Gtk.Entry nameEntry;

		private global::Gtk.VBox boxProject;

		private global::Gtk.HBox hbox3;

		private global::Gtk.CheckButton projectAddCheckbox;

		private global::Gtk.ComboBox projectAddCombo;

		private global::Gtk.HBox hbox4;

		private global::Gtk.Label projectPathLabel;

		private global::MonoDevelop.Components.FolderEntry projectFolderEntry;

		private global::Gtk.Button cancelButton;

		private global::Gtk.Button okButton;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget MonoDevelop.Ide.Gui.Dialogs.NewFileDialog
			this.Name = "MonoDevelop.Ide.Gui.Dialogs.NewFileDialog";
			this.Title = global::Mono.Unix.Catalog.GetString ("New File");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.BorderWidth = ((uint)(6));
			// Internal child MonoDevelop.Ide.Gui.Dialogs.NewFileDialog.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.Spacing = 6;
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			this.vbox2.BorderWidth = ((uint)(6));
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.scrolledwindow1 = new global::Gtk.ScrolledWindow ();
			this.scrolledwindow1.CanFocus = true;
			this.scrolledwindow1.Name = "scrolledwindow1";
			this.scrolledwindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child scrolledwindow1.Gtk.Container+ContainerChild
			this.catView = new global::Gtk.TreeView ();
			this.catView.WidthRequest = 160;
			this.catView.CanFocus = true;
			this.catView.Name = "catView";
			this.catView.HeadersVisible = false;
			this.scrolledwindow1.Add (this.catView);
			this.hbox1.Add (this.scrolledwindow1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.scrolledwindow1]));
			w3.Position = 0;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.iconView = new global::MonoDevelop.Components.IconView ();
			this.iconView.CanFocus = true;
			this.iconView.Name = "iconView";
			this.iconView.ShadowType = ((global::Gtk.ShadowType)(1));
			this.hbox1.Add (this.iconView);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.iconView]));
			w4.Position = 1;
			this.vbox2.Add (this.hbox1);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox1]));
			w5.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment2 = new global::Gtk.Alignment (0f, 0f, 1f, 1f);
			this.GtkAlignment2.Name = "GtkAlignment2";
			// Container child GtkAlignment2.Gtk.Container+ContainerChild
			this.infoLabel = new global::Gtk.Label ();
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Xalign = 0f;
			this.infoLabel.Ellipsize = ((global::Pango.EllipsizeMode)(3));
			this.GtkAlignment2.Add (this.infoLabel);
			this.frame1.Add (this.GtkAlignment2);
			this.vbox2.Add (this.frame1);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.frame1]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.label1 = new global::Gtk.Label ();
			this.label1.WidthRequest = 1;
			this.label1.HeightRequest = 1;
			this.label1.Name = "label1";
			this.vbox2.Add (this.label1);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.label1]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hbox2 = new global::Gtk.HBox ();
			this.hbox2.Name = "hbox2";
			this.hbox2.Spacing = 6;
			// Container child hbox2.Gtk.Box+BoxChild
			this.label2 = new global::Gtk.Label ();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString ("Name:");
			this.hbox2.Add (this.label2);
			global::Gtk.Box.BoxChild w10 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.label2]));
			w10.Position = 0;
			w10.Expand = false;
			w10.Fill = false;
			// Container child hbox2.Gtk.Box+BoxChild
			this.nameEntry = new global::Gtk.Entry ();
			this.nameEntry.CanFocus = true;
			this.nameEntry.Name = "nameEntry";
			this.nameEntry.IsEditable = true;
			this.nameEntry.InvisibleChar = '●';
			this.hbox2.Add (this.nameEntry);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.hbox2[this.nameEntry]));
			w11.Position = 1;
			this.vbox2.Add (this.hbox2);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hbox2]));
			w12.Position = 3;
			w12.Expand = false;
			w12.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.boxProject = new global::Gtk.VBox ();
			this.boxProject.Name = "boxProject";
			this.boxProject.Spacing = 6;
			// Container child boxProject.Gtk.Box+BoxChild
			this.hbox3 = new global::Gtk.HBox ();
			this.hbox3.Name = "hbox3";
			this.hbox3.Spacing = 6;
			// Container child hbox3.Gtk.Box+BoxChild
			this.projectAddCheckbox = new global::Gtk.CheckButton ();
			this.projectAddCheckbox.CanFocus = true;
			this.projectAddCheckbox.Name = "projectAddCheckbox";
			this.projectAddCheckbox.Label = global::Mono.Unix.Catalog.GetString ("_Add to project:");
			this.projectAddCheckbox.DrawIndicator = true;
			this.projectAddCheckbox.UseUnderline = true;
			this.hbox3.Add (this.projectAddCheckbox);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.projectAddCheckbox]));
			w13.Position = 0;
			w13.Expand = false;
			w13.Fill = false;
			// Container child hbox3.Gtk.Box+BoxChild
			this.projectAddCombo = global::Gtk.ComboBox.NewText ();
			this.projectAddCombo.Name = "projectAddCombo";
			this.hbox3.Add (this.projectAddCombo);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.hbox3[this.projectAddCombo]));
			w14.Position = 1;
			this.boxProject.Add (this.hbox3);
			global::Gtk.Box.BoxChild w15 = ((global::Gtk.Box.BoxChild)(this.boxProject[this.hbox3]));
			w15.Position = 0;
			w15.Expand = false;
			w15.Fill = false;
			// Container child boxProject.Gtk.Box+BoxChild
			this.hbox4 = new global::Gtk.HBox ();
			this.hbox4.Name = "hbox4";
			this.hbox4.Spacing = 6;
			// Container child hbox4.Gtk.Box+BoxChild
			this.projectPathLabel = new global::Gtk.Label ();
			this.projectPathLabel.Name = "projectPathLabel";
			this.projectPathLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("Path:");
			this.hbox4.Add (this.projectPathLabel);
			global::Gtk.Box.BoxChild w16 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.projectPathLabel]));
			w16.Position = 0;
			w16.Expand = false;
			w16.Fill = false;
			// Container child hbox4.Gtk.Box+BoxChild
			this.projectFolderEntry = new global::MonoDevelop.Components.FolderEntry ();
			this.projectFolderEntry.Name = "projectFolderEntry";
			this.hbox4.Add (this.projectFolderEntry);
			global::Gtk.Box.BoxChild w17 = ((global::Gtk.Box.BoxChild)(this.hbox4[this.projectFolderEntry]));
			w17.Position = 1;
			this.boxProject.Add (this.hbox4);
			global::Gtk.Box.BoxChild w18 = ((global::Gtk.Box.BoxChild)(this.boxProject[this.hbox4]));
			w18.Position = 1;
			w18.Expand = false;
			w18.Fill = false;
			this.vbox2.Add (this.boxProject);
			global::Gtk.Box.BoxChild w19 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.boxProject]));
			w19.Position = 4;
			w19.Expand = false;
			w19.Fill = false;
			w1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(w1[this.vbox2]));
			w20.Position = 0;
			// Internal child MonoDevelop.Ide.Gui.Dialogs.NewFileDialog.ActionArea
			global::Gtk.HButtonBox w21 = this.ActionArea;
			w21.Name = "dialog1_ActionArea";
			w21.Spacing = 6;
			w21.BorderWidth = ((uint)(5));
			w21.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.cancelButton = new global::Gtk.Button ();
			this.cancelButton.CanDefault = true;
			this.cancelButton.CanFocus = true;
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.UseStock = true;
			this.cancelButton.UseUnderline = true;
			this.cancelButton.Label = "gtk-cancel";
			this.AddActionWidget (this.cancelButton, -6);
			global::Gtk.ButtonBox.ButtonBoxChild w22 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w21[this.cancelButton]));
			w22.Expand = false;
			w22.Fill = false;
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.okButton = new global::Gtk.Button ();
			this.okButton.CanDefault = true;
			this.okButton.CanFocus = true;
			this.okButton.Name = "okButton";
			this.okButton.UseStock = true;
			this.okButton.UseUnderline = true;
			this.okButton.Label = "gtk-new";
			w21.Add (this.okButton);
			global::Gtk.ButtonBox.ButtonBoxChild w23 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w21[this.okButton]));
			w23.Position = 1;
			w23.Expand = false;
			w23.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 597;
			this.DefaultHeight = 370;
			this.boxProject.Hide ();
			this.Show ();
		}
	}
}