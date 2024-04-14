namespace Z64MusicManager {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.msMainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnNew = new System.Windows.Forms.ToolStripMenuItem();
			this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
			this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnConvert = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSetupOoTCustomMusicStarter = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSetupMMCustomMusicStarter = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.msMainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// msMainMenu
			// 
			this.msMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.convertToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.msMainMenu.Location = new System.Drawing.Point(0, 0);
			this.msMainMenu.Name = "msMainMenu";
			this.msMainMenu.Size = new System.Drawing.Size(401, 28);
			this.msMainMenu.TabIndex = 1;
			this.msMainMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.toolStripMenuItem4,
            this.btnSave,
            this.btnSaveAs,
            this.toolStripMenuItem3,
            this.btnExit});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// btnNew
			// 
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(144, 26);
			this.btnNew.Text = "New";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(144, 26);
			this.btnOpen.Text = "Open...";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(141, 6);
			// 
			// btnSave
			// 
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(144, 26);
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.Size = new System.Drawing.Size(144, 26);
			this.btnSaveAs.Text = "Save As...";
			this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(141, 6);
			// 
			// btnExit
			// 
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(144, 26);
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// convertToolStripMenuItem
			// 
			this.convertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConvert});
			this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
			this.convertToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
			this.convertToolStripMenuItem.Text = "Tools";
			// 
			// btnConvert
			// 
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(216, 26);
			this.btnConvert.Text = "Convert to ...";
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetupOoTCustomMusicStarter,
            this.btnSetupMMCustomMusicStarter});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
			this.toolsToolStripMenuItem.Text = "Setup";
			// 
			// btnSetupOoTCustomMusicStarter
			// 
			this.btnSetupOoTCustomMusicStarter.Name = "btnSetupOoTCustomMusicStarter";
			this.btnSetupOoTCustomMusicStarter.Size = new System.Drawing.Size(294, 26);
			this.btnSetupOoTCustomMusicStarter.Text = "Setup OoT custom music starter";
			this.btnSetupOoTCustomMusicStarter.Click += new System.EventHandler(this.btnSetupOoTCustomMusicStarter_Click);
			// 
			// btnSetupMMCustomMusicStarter
			// 
			this.btnSetupMMCustomMusicStarter.Name = "btnSetupMMCustomMusicStarter";
			this.btnSetupMMCustomMusicStarter.Size = new System.Drawing.Size(294, 26);
			this.btnSetupMMCustomMusicStarter.Text = "Setup MM custom music starter";
			this.btnSetupMMCustomMusicStarter.Click += new System.EventHandler(this.btnSetupMMCustomMusicStarter_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbout});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// btnAbout
			// 
			this.btnAbout.Enabled = false;
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(398, 26);
			this.btnAbout.Text = "About ZMusic Manager";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 339);
			this.Controls.Add(this.msMainMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "ZMusic Manager";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.msMainMenu.ResumeLayout(false);
			this.msMainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip msMainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem btnNew;
		private System.Windows.Forms.ToolStripMenuItem btnOpen;
		private System.Windows.Forms.ToolStripMenuItem btnSave;
		private System.Windows.Forms.ToolStripMenuItem btnSaveAs;
		private System.Windows.Forms.ToolStripMenuItem btnExit;
		private System.Windows.Forms.ToolStripMenuItem convertToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem btnConvert;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem btnAbout;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem btnSetupOoTCustomMusicStarter;
		private System.Windows.Forms.ToolStripMenuItem btnSetupMMCustomMusicStarter;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
	}
}