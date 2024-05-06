namespace Z64MusicManager {
	partial class MMRForm {
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
			this.cbxBank = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMainVolume = new System.Windows.Forms.TextBox();
			this.tbMainVolume = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.clbCategories = new System.Windows.Forms.CheckedListBox();
			this.btnPreview = new System.Windows.Forms.Button();
			this.lbFormat = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.tbMainVolume)).BeginInit();
			this.SuspendLayout();
			// 
			// cbxBank
			// 
			this.cbxBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxBank.FormattingEnabled = true;
			this.cbxBank.Items.AddRange(new object[] {
            "0x03 Hyrule Field"});
			this.cbxBank.Location = new System.Drawing.Point(134, 41);
			this.cbxBank.Name = "cbxBank";
			this.cbxBank.Size = new System.Drawing.Size(293, 24);
			this.cbxBank.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 8;
			this.label2.Text = "Bank:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 78);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 17);
			this.label1.TabIndex = 10;
			this.label1.Text = "Categories:";
			// 
			// txtMainVolume
			// 
			this.txtMainVolume.Location = new System.Drawing.Point(393, 314);
			this.txtMainVolume.Name = "txtMainVolume";
			this.txtMainVolume.ReadOnly = true;
			this.txtMainVolume.Size = new System.Drawing.Size(34, 22);
			this.txtMainVolume.TabIndex = 15;
			this.txtMainVolume.Text = "58";
			// 
			// tbMainVolume
			// 
			this.tbMainVolume.Location = new System.Drawing.Point(134, 314);
			this.tbMainVolume.Maximum = 255;
			this.tbMainVolume.Name = "tbMainVolume";
			this.tbMainVolume.Size = new System.Drawing.Size(253, 56);
			this.tbMainVolume.TabIndex = 14;
			this.tbMainVolume.Value = 88;
			this.tbMainVolume.ValueChanged += new System.EventHandler(this.tbMainVolume_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 318);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(91, 17);
			this.label4.TabIndex = 13;
			this.label4.Text = "Main volume:";
			// 
			// clbCategories
			// 
			this.clbCategories.FormattingEnabled = true;
			this.clbCategories.Items.AddRange(new object[] {
            "[0] Field",
            "[1] Towns",
            "[2] Dungeon",
            "[3] Indoors",
            "[4] Minigame",
            "[5] Action cutscenes/events",
            "[6] Calm cutscenes/events",
            "[7] Boss fight",
            "[8] Item get, Minigame win, Soaring CS",
            "[9] Game over",
            "[10] Area clear",
            "[16] Ending and Title screen"});
			this.clbCategories.Location = new System.Drawing.Point(134, 78);
			this.clbCategories.Name = "clbCategories";
			this.clbCategories.Size = new System.Drawing.Size(293, 225);
			this.clbCategories.TabIndex = 17;
			// 
			// btnPreview
			// 
			this.btnPreview.Location = new System.Drawing.Point(324, 361);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(103, 31);
			this.btnPreview.TabIndex = 18;
			this.btnPreview.Text = "Preview";
			this.btnPreview.UseVisualStyleBackColor = true;
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// lbFormat
			// 
			this.lbFormat.AutoSize = true;
			this.lbFormat.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lbFormat.Location = new System.Drawing.Point(14, 367);
			this.lbFormat.Name = "lbFormat";
			this.lbFormat.Size = new System.Drawing.Size(302, 17);
			this.lbFormat.TabIndex = 19;
			this.lbFormat.Text = "MMRS | Custom bank and samples | FormMask";
			// 
			// MMRForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(441, 410);
			this.Controls.Add(this.lbFormat);
			this.Controls.Add(this.btnPreview);
			this.Controls.Add(this.clbCategories);
			this.Controls.Add(this.txtMainVolume);
			this.Controls.Add(this.tbMainVolume);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbxBank);
			this.Controls.Add(this.label2);
			this.Name = "MMRForm";
			this.Text = "MMRForm";
			this.Load += new System.EventHandler(this.MMRForm_Load);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.cbxBank, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.tbMainVolume, 0);
			this.Controls.SetChildIndex(this.txtMainVolume, 0);
			this.Controls.SetChildIndex(this.clbCategories, 0);
			this.Controls.SetChildIndex(this.btnPreview, 0);
			this.Controls.SetChildIndex(this.lbFormat, 0);
			((System.ComponentModel.ISupportInitialize)(this.tbMainVolume)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbxBank;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMainVolume;
		private System.Windows.Forms.TrackBar tbMainVolume;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckedListBox clbCategories;
		private System.Windows.Forms.Button btnPreview;
		private System.Windows.Forms.Label lbFormat;
	}
}