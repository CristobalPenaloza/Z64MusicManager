namespace ZMusicManager
{
	partial class OoTRForm
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
			this.btnPreview = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.tbMainVolume)).BeginInit();
			this.SuspendLayout();
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
			// btnPreview
			// 
			this.btnPreview.Location = new System.Drawing.Point(305, 235);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(124, 31);
			this.btnPreview.TabIndex = 14;
			this.btnPreview.Text = "Preview";
			this.btnPreview.UseVisualStyleBackColor = true;
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// OoTRForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(441, 286);
			this.Controls.Add(this.btnPreview);
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
			this.Name = "OoTRForm";
			this.Text = "ZMusic Manager - [Untitled - ZMusic Manager]";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.txtName, 0);
			this.Controls.SetChildIndex(this.cbxBank, 0);
			this.Controls.SetChildIndex(this.txtMusicGroups, 0);
			this.Controls.SetChildIndex(this.cbxSequenceType, 0);
			this.Controls.SetChildIndex(this.tbMainVolume, 0);
			this.Controls.SetChildIndex(this.txtMainVolume, 0);
			this.Controls.SetChildIndex(this.btnOpenMusicGroupSelector, 0);
			this.Controls.SetChildIndex(this.btnPreview, 0);
			((System.ComponentModel.ISupportInitialize)(this.tbMainVolume)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
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
		private System.Windows.Forms.Button btnPreview;
	}
}

