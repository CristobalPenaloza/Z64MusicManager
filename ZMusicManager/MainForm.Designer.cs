namespace ZMusicManager {
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
			this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
			this.convertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.convertToMMRSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bulkConvertToMMRSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.btnDJGithub = new System.Windows.Forms.ToolStripMenuItem();
			this.btnDJDiscord = new System.Windows.Forms.ToolStripMenuItem();
			this.btnGuideCreatingMusicFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.msMainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// msMainMenu
			// 
			this.msMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.convertToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.msMainMenu.Location = new System.Drawing.Point(0, 0);
			this.msMainMenu.Name = "msMainMenu";
			this.msMainMenu.Size = new System.Drawing.Size(295, 28);
			this.msMainMenu.TabIndex = 1;
			this.msMainMenu.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
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
            this.convertToMMRSToolStripMenuItem,
            this.bulkConvertToMMRSToolStripMenuItem});
			this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
			this.convertToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
			this.convertToolStripMenuItem.Text = "Convert";
			// 
			// convertToMMRSToolStripMenuItem
			// 
			this.convertToMMRSToolStripMenuItem.Enabled = false;
			this.convertToMMRSToolStripMenuItem.Name = "convertToMMRSToolStripMenuItem";
			this.convertToMMRSToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
			this.convertToMMRSToolStripMenuItem.Text = "Convert to MMRS";
			// 
			// bulkConvertToMMRSToolStripMenuItem
			// 
			this.bulkConvertToMMRSToolStripMenuItem.Enabled = false;
			this.bulkConvertToMMRSToolStripMenuItem.Name = "bulkConvertToMMRSToolStripMenuItem";
			this.bulkConvertToMMRSToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
			this.bulkConvertToMMRSToolStripMenuItem.Text = "Bulk convert to MMRS";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbout,
            this.btnDJGithub,
            this.btnDJDiscord,
            this.btnGuideCreatingMusicFiles});
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
			// btnDJGithub
			// 
			this.btnDJGithub.Name = "btnDJGithub";
			this.btnDJGithub.Size = new System.Drawing.Size(398, 26);
			this.btnDJGithub.Text = "Darunia\'s Joy GitHub repository";
			// 
			// btnDJDiscord
			// 
			this.btnDJDiscord.Name = "btnDJDiscord";
			this.btnDJDiscord.Size = new System.Drawing.Size(398, 26);
			this.btnDJDiscord.Text = "Darunia\'s Joy Discord";
			// 
			// btnGuideCreatingMusicFiles
			// 
			this.btnGuideCreatingMusicFiles.Name = "btnGuideCreatingMusicFiles";
			this.btnGuideCreatingMusicFiles.Size = new System.Drawing.Size(398, 26);
			this.btnGuideCreatingMusicFiles.Text = "Guide: Creating music files for OoT Randomizer";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(295, 254);
			this.Controls.Add(this.msMainMenu);
			this.Name = "MainForm";
			this.Text = "ZMusic Manager";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
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
		private System.Windows.Forms.ToolStripMenuItem convertToMMRSToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem bulkConvertToMMRSToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem btnAbout;
		private System.Windows.Forms.ToolStripMenuItem btnDJGithub;
		private System.Windows.Forms.ToolStripMenuItem btnDJDiscord;
		private System.Windows.Forms.ToolStripMenuItem btnGuideCreatingMusicFiles;
	}
}