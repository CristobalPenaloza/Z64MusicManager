namespace ZMusicManager
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
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
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnNew = new System.Windows.Forms.ToolStripMenuItem();
			this.btnOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSave = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutZMusicManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.cbxBank = new System.Windows.Forms.ComboBox();
			this.txtMusicGroups = new System.Windows.Forms.TextBox();
			this.cbxSequenceType = new System.Windows.Forms.ComboBox();
			this.tbMainVolume = new System.Windows.Forms.TrackBar();
			this.txtMainVolume = new System.Windows.Forms.TextBox();
			this.btnOpenMusicGroupSelector = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbMainVolume)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(444, 28);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
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
			this.btnNew.Size = new System.Drawing.Size(216, 26);
			this.btnNew.Text = "New";
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(216, 26);
			this.btnOpen.Text = "Open...";
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnSave
			// 
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(216, 26);
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.Size = new System.Drawing.Size(216, 26);
			this.btnSaveAs.Text = "Save As...";
			this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
			// 
			// btnExit
			// 
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(216, 26);
			this.btnExit.Text = "Exit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutZMusicManagerToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutZMusicManagerToolStripMenuItem
			// 
			this.aboutZMusicManagerToolStripMenuItem.Name = "aboutZMusicManagerToolStripMenuItem";
			this.aboutZMusicManagerToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
			this.aboutZMusicManagerToolStripMenuItem.Text = "About ZMusic Manager";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Bank:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 149);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "Music groups:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 187);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 17);
			this.label4.TabIndex = 4;
			this.label4.Text = "Main volume:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(99, 17);
			this.label5.TabIndex = 5;
			this.label5.Text = "Sequece type:";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(133, 37);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(293, 22);
			this.txtName.TabIndex = 6;
			// 
			// cbxBank
			// 
			this.cbxBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxBank.FormattingEnabled = true;
			this.cbxBank.Items.AddRange(new object[] {
            "0x03 Hyrule Field"});
			this.cbxBank.Location = new System.Drawing.Point(133, 72);
			this.cbxBank.Name = "cbxBank";
			this.cbxBank.Size = new System.Drawing.Size(293, 24);
			this.cbxBank.TabIndex = 7;
			// 
			// txtMusicGroups
			// 
			this.txtMusicGroups.Location = new System.Drawing.Point(133, 146);
			this.txtMusicGroups.Name = "txtMusicGroups";
			this.txtMusicGroups.Size = new System.Drawing.Size(253, 22);
			this.txtMusicGroups.TabIndex = 8;
			// 
			// cbxSequenceType
			// 
			this.cbxSequenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxSequenceType.ForeColor = System.Drawing.SystemColors.WindowText;
			this.cbxSequenceType.FormattingEnabled = true;
			this.cbxSequenceType.Items.AddRange(new object[] {
            "Bgm",
            "Fanfare"});
			this.cbxSequenceType.Location = new System.Drawing.Point(133, 109);
			this.cbxSequenceType.Name = "cbxSequenceType";
			this.cbxSequenceType.Size = new System.Drawing.Size(293, 24);
			this.cbxSequenceType.TabIndex = 9;
			// 
			// tbMainVolume
			// 
			this.tbMainVolume.Location = new System.Drawing.Point(133, 183);
			this.tbMainVolume.Maximum = 127;
			this.tbMainVolume.Name = "tbMainVolume";
			this.tbMainVolume.Size = new System.Drawing.Size(253, 56);
			this.tbMainVolume.TabIndex = 11;
			this.tbMainVolume.Value = 88;
			this.tbMainVolume.ValueChanged += new System.EventHandler(this.tbMainVolume_ValueChanged);
			// 
			// txtMainVolume
			// 
			this.txtMainVolume.Location = new System.Drawing.Point(392, 183);
			this.txtMainVolume.Name = "txtMainVolume";
			this.txtMainVolume.ReadOnly = true;
			this.txtMainVolume.Size = new System.Drawing.Size(34, 22);
			this.txtMainVolume.TabIndex = 12;
			this.txtMainVolume.Text = "58";
			// 
			// btnOpenMusicGroupSelector
			// 
			this.btnOpenMusicGroupSelector.Location = new System.Drawing.Point(392, 145);
			this.btnOpenMusicGroupSelector.Name = "btnOpenMusicGroupSelector";
			this.btnOpenMusicGroupSelector.Size = new System.Drawing.Size(34, 27);
			this.btnOpenMusicGroupSelector.TabIndex = 13;
			this.btnOpenMusicGroupSelector.Text = "...";
			this.btnOpenMusicGroupSelector.UseVisualStyleBackColor = true;
			this.btnOpenMusicGroupSelector.Click += new System.EventHandler(this.btnOpenMusicGroupSelector_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 491);
			this.Controls.Add(this.btnOpenMusicGroupSelector);
			this.Controls.Add(this.txtMainVolume);
			this.Controls.Add(this.tbMainVolume);
			this.Controls.Add(this.cbxSequenceType);
			this.Controls.Add(this.txtMusicGroups);
			this.Controls.Add(this.cbxBank);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "ZMusic Manager";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbMainVolume)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem btnNew;
		private System.Windows.Forms.ToolStripMenuItem btnOpen;
		private System.Windows.Forms.ToolStripMenuItem btnExit;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutZMusicManagerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem btnSave;
		private System.Windows.Forms.ToolStripMenuItem btnSaveAs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.ComboBox cbxBank;
		private System.Windows.Forms.TextBox txtMusicGroups;
		private System.Windows.Forms.ComboBox cbxSequenceType;
		private System.Windows.Forms.TrackBar tbMainVolume;
		private System.Windows.Forms.TextBox txtMainVolume;
		private System.Windows.Forms.Button btnOpenMusicGroupSelector;
	}
}

