/*
 * Copyright (C) 2000-2009 - Xeno Innovations, Inc.
 * User: DSuess
 * Date: 8/8/2009
 * Time: 8:11 PM
 * 
 */
namespace testApp
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Etalon_close = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ZoomLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.NumLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.autocompleteMenu1 = new AutocompleteMenuNS.AutocompleteMenu();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new testApp.ExtendedToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new testApp.ExtendedToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new testApp.ExtendedToolStripSeparator();
            this.searchWithGoogleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new testApp.ExtendedToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDefaultZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new testApp.ExtendedToolStripSeparator();
            this.numbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordWrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autocompleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.readTheTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFromFotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puntoSwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.translatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.lineNumbers_For_RichTextBox1 = new LineNumbers.LineNumbers_For_RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Etalon_close});
            this.menuStrip1.Location = new System.Drawing.Point(0, 31);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(739, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Etalon_close
            // 
            this.Etalon_close.AutoSize = false;
            this.Etalon_close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Etalon_close.Image = ((System.Drawing.Image)(resources.GetObject("Etalon_close.Image")));
            this.Etalon_close.Name = "Etalon_close";
            this.Etalon_close.Padding = new System.Windows.Forms.Padding(0);
            this.Etalon_close.Size = new System.Drawing.Size(20, 20);
            this.Etalon_close.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autocompleteMenu1.SetAutocompleteMenu(this.richTextBox1, this.autocompleteMenu1);
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.richTextBox1.Location = new System.Drawing.Point(22, 61);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(717, 367);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.richTextBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseClick);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZoomLabel,
            this.toolStripStatusLabel2,
            this.NumLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 432);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(739, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ZoomLabel
            // 
            this.ZoomLabel.Margin = new System.Windows.Forms.Padding(50, 4, 0, 2);
            this.ZoomLabel.Name = "ZoomLabel";
            this.ZoomLabel.Size = new System.Drawing.Size(45, 20);
            this.ZoomLabel.Text = "100%";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Window;
            this.toolStripStatusLabel2.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(4, 20);
            // 
            // NumLabel
            // 
            this.NumLabel.Margin = new System.Windows.Forms.Padding(20, 4, 0, 2);
            this.NumLabel.Name = "NumLabel";
            this.NumLabel.Size = new System.Drawing.Size(77, 20);
            this.NumLabel.Text = "Ln 1, Col 1";
            // 
            // autocompleteMenu1
            // 
            this.autocompleteMenu1.AllowsTabKey = true;
            this.autocompleteMenu1.AppearInterval = 400;
            this.autocompleteMenu1.Colors = ((AutocompleteMenuNS.Colors)(resources.GetObject("autocompleteMenu1.Colors")));
            this.autocompleteMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.autocompleteMenu1.ImageList = null;
            this.autocompleteMenu1.Items = new string[] {
        "apple",
        "nice",
        "i",
        "am"};
            this.autocompleteMenu1.TargetControlWrapper = null;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(49, 27);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.toolStripSeparator2,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator3,
            this.searchWithGoogleToolStripMenuItem,
            this.findToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem,
            this.timeToolStripMenuItem});
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(53, 27);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(243, 6);
            // 
            // searchWithGoogleToolStripMenuItem
            // 
            this.searchWithGoogleToolStripMenuItem.Name = "searchWithGoogleToolStripMenuItem";
            this.searchWithGoogleToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.searchWithGoogleToolStripMenuItem.Text = "Search With Google";
            this.searchWithGoogleToolStripMenuItem.Click += new System.EventHandler(this.searchWithGoogleToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.findToolStripMenuItem.Text = "Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.replaceToolStripMenuItem.Text = "Replace";
            this.replaceToolStripMenuItem.Click += new System.EventHandler(this.replaceToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(243, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // timeToolStripMenuItem
            // 
            this.timeToolStripMenuItem.Name = "timeToolStripMenuItem";
            this.timeToolStripMenuItem.Size = new System.Drawing.Size(246, 28);
            this.timeToolStripMenuItem.Text = "Time/Date";
            this.timeToolStripMenuItem.Click += new System.EventHandler(this.timeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.fontToolStripMenuItem,
            this.toolStripSeparator5,
            this.numbarToolStripMenuItem,
            this.statusStripToolStripMenuItem,
            this.wordWrapToolStripMenuItem});
            this.viewToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(60, 27);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // themeToolStripMenuItem
            // 
            this.themeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackToolStripMenuItem,
            this.whiteToolStripMenuItem});
            this.themeToolStripMenuItem.Name = "themeToolStripMenuItem";
            this.themeToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.themeToolStripMenuItem.Text = "Theme";
            // 
            // blackToolStripMenuItem
            // 
            this.blackToolStripMenuItem.Name = "blackToolStripMenuItem";
            this.blackToolStripMenuItem.Size = new System.Drawing.Size(139, 28);
            this.blackToolStripMenuItem.Text = "Black";
            this.blackToolStripMenuItem.Click += new System.EventHandler(this.blackToolStripMenuItem_Click);
            // 
            // whiteToolStripMenuItem
            // 
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Size = new System.Drawing.Size(139, 28);
            this.whiteToolStripMenuItem.Text = "White";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.restoreDefaultZoomToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(176, 28);
            this.toolStripMenuItem2.Text = "Zoom";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // restoreDefaultZoomToolStripMenuItem
            // 
            this.restoreDefaultZoomToolStripMenuItem.Name = "restoreDefaultZoomToolStripMenuItem";
            this.restoreDefaultZoomToolStripMenuItem.Size = new System.Drawing.Size(261, 28);
            this.restoreDefaultZoomToolStripMenuItem.Text = "Restore Default Zoom";
            this.restoreDefaultZoomToolStripMenuItem.Click += new System.EventHandler(this.restoreDefaultZoomToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(173, 6);
            // 
            // numbarToolStripMenuItem
            // 
            this.numbarToolStripMenuItem.Checked = true;
            this.numbarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.numbarToolStripMenuItem.Name = "numbarToolStripMenuItem";
            this.numbarToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.numbarToolStripMenuItem.Text = "Numbar";
            this.numbarToolStripMenuItem.Click += new System.EventHandler(this.numbarToolStripMenuItem_Click);
            // 
            // statusStripToolStripMenuItem
            // 
            this.statusStripToolStripMenuItem.Checked = true;
            this.statusStripToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusStripToolStripMenuItem.Name = "statusStripToolStripMenuItem";
            this.statusStripToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.statusStripToolStripMenuItem.Text = "StatusStrip";
            this.statusStripToolStripMenuItem.Click += new System.EventHandler(this.toolStripToolStripMenuItem_Click);
            // 
            // wordWrapToolStripMenuItem
            // 
            this.wordWrapToolStripMenuItem.Checked = true;
            this.wordWrapToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wordWrapToolStripMenuItem.Name = "wordWrapToolStripMenuItem";
            this.wordWrapToolStripMenuItem.Size = new System.Drawing.Size(176, 28);
            this.wordWrapToolStripMenuItem.Text = "WordWrap";
            this.wordWrapToolStripMenuItem.Click += new System.EventHandler(this.wordWrapToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autocompleteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.readTheTextToolStripMenuItem,
            this.textFromFotoToolStripMenuItem,
            this.puntoSwitchToolStripMenuItem,
            this.translatorToolStripMenuItem});
            this.optionsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(84, 27);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // autocompleteToolStripMenuItem
            // 
            this.autocompleteToolStripMenuItem.Name = "autocompleteToolStripMenuItem";
            this.autocompleteToolStripMenuItem.Size = new System.Drawing.Size(265, 28);
            this.autocompleteToolStripMenuItem.Text = "Autocomplete";
            this.autocompleteToolStripMenuItem.Click += new System.EventHandler(this.autocompleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(265, 28);
            this.toolStripMenuItem1.Text = "Recognize The Speech";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // readTheTextToolStripMenuItem
            // 
            this.readTheTextToolStripMenuItem.Name = "readTheTextToolStripMenuItem";
            this.readTheTextToolStripMenuItem.Size = new System.Drawing.Size(265, 28);
            this.readTheTextToolStripMenuItem.Text = "Read The Text";
            this.readTheTextToolStripMenuItem.Click += new System.EventHandler(this.readTheTextToolStripMenuItem_Click);
            // 
            // textFromFotoToolStripMenuItem
            // 
            this.textFromFotoToolStripMenuItem.Name = "textFromFotoToolStripMenuItem";
            this.textFromFotoToolStripMenuItem.Size = new System.Drawing.Size(265, 28);
            this.textFromFotoToolStripMenuItem.Text = "Text From Photo";
            this.textFromFotoToolStripMenuItem.Click += new System.EventHandler(this.textFromFotoToolStripMenuItem_Click);
            // 
            // puntoSwitchToolStripMenuItem
            // 
            this.puntoSwitchToolStripMenuItem.Name = "puntoSwitchToolStripMenuItem";
            this.puntoSwitchToolStripMenuItem.Size = new System.Drawing.Size(265, 28);
            this.puntoSwitchToolStripMenuItem.Text = "Punto Switch";
            this.puntoSwitchToolStripMenuItem.Click += new System.EventHandler(this.puntoSwitchToolStripMenuItem_Click);
            // 
            // translatorToolStripMenuItem
            // 
            this.translatorToolStripMenuItem.Name = "translatorToolStripMenuItem";
            this.translatorToolStripMenuItem.Size = new System.Drawing.Size(265, 28);
            this.translatorToolStripMenuItem.Text = "Translator";
            this.translatorToolStripMenuItem.Click += new System.EventHandler(this.translatorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(59, 27);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(739, 31);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // lineNumbers_For_RichTextBox1
            // 
            this.lineNumbers_For_RichTextBox1._SeeThroughMode_ = false;
            this.lineNumbers_For_RichTextBox1.AutoSizing = true;
            this.lineNumbers_For_RichTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_BetaColor = System.Drawing.Color.LightSteelBlue;
            this.lineNumbers_For_RichTextBox1.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.lineNumbers_For_RichTextBox1.BorderLines_Color = System.Drawing.Color.SlateGray;
            this.lineNumbers_For_RichTextBox1.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineNumbers_For_RichTextBox1.BorderLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lineNumbers_For_RichTextBox1.DockSide = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Left;
            this.lineNumbers_For_RichTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lineNumbers_For_RichTextBox1.GridLines_Color = System.Drawing.Color.White;
            this.lineNumbers_For_RichTextBox1.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineNumbers_For_RichTextBox1.GridLines_Thickness = 10F;
            this.lineNumbers_For_RichTextBox1.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight;
            this.lineNumbers_For_RichTextBox1.LineNrs_AntiAlias = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_AsHexadecimal = false;
            this.lineNumbers_For_RichTextBox1.LineNrs_ClippedByItemRectangle = true;
            this.lineNumbers_For_RichTextBox1.LineNrs_LeadingZeroes = false;
            this.lineNumbers_For_RichTextBox1.LineNrs_Offset = new System.Drawing.Size(0, 0);
            this.lineNumbers_For_RichTextBox1.Location = new System.Drawing.Point(0, 61);
            this.lineNumbers_For_RichTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.lineNumbers_For_RichTextBox1.MarginLines_Color = System.Drawing.Color.GhostWhite;
            this.lineNumbers_For_RichTextBox1.MarginLines_Side = LineNumbers.LineNumbers_For_RichTextBox.LineNumberDockSide.Right;
            this.lineNumbers_For_RichTextBox1.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Dash;
            this.lineNumbers_For_RichTextBox1.MarginLines_Thickness = 1F;
            this.lineNumbers_For_RichTextBox1.Name = "lineNumbers_For_RichTextBox1";
            this.lineNumbers_For_RichTextBox1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.lineNumbers_For_RichTextBox1.ParentRichTextBox = this.richTextBox1;
            this.lineNumbers_For_RichTextBox1.Show_BackgroundGradient = false;
            this.lineNumbers_For_RichTextBox1.Show_BorderLines = false;
            this.lineNumbers_For_RichTextBox1.Show_GridLines = false;
            this.lineNumbers_For_RichTextBox1.Show_LineNrs = true;
            this.lineNumbers_For_RichTextBox1.Show_MarginLines = false;
            this.lineNumbers_For_RichTextBox1.Size = new System.Drawing.Size(22, 371);
            this.lineNumbers_For_RichTextBox1.TabIndex = 0;
            this.lineNumbers_For_RichTextBox1.Resize += new System.EventHandler(this.lineNumbers_For_RichTextBox1_Resize);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(739, 458);
            this.Controls.Add(this.lineNumbers_For_RichTextBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip2;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(739, 458);
            this.Name = "MainForm";
            this.Text = "Notebook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private LineNumbers.LineNumbers_For_RichTextBox lineNumbers_For_RichTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem Etalon_close;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ZoomLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel NumLabel;
        private AutocompleteMenuNS.AutocompleteMenu autocompleteMenu1;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private ExtendedToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private ExtendedToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private ExtendedToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem searchWithGoogleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private ExtendedToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreDefaultZoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private ExtendedToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem numbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusStripToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordWrapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autocompleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem readTheTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFromFotoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puntoSwitchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem translatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
    }
}
