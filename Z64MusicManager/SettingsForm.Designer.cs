namespace Z64MusicManager
{
	partial class SettingsForm
	{
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtBizhawkPath = new System.Windows.Forms.TextBox();
			this.btnBizhawkPath = new System.Windows.Forms.Button();
			this.btnOOTRCLIPath = new System.Windows.Forms.Button();
			this.txtOOTRCLIPath = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnMMRCLIPath = new System.Windows.Forms.Button();
			this.txtMMRCLIPath = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Bizhawk path:";
			// 
			// txtBizhawkPath
			// 
			this.txtBizhawkPath.Location = new System.Drawing.Point(15, 29);
			this.txtBizhawkPath.Name = "txtBizhawkPath";
			this.txtBizhawkPath.Size = new System.Drawing.Size(286, 22);
			this.txtBizhawkPath.TabIndex = 1;
			// 
			// btnBizhawkPath
			// 
			this.btnBizhawkPath.Location = new System.Drawing.Point(308, 29);
			this.btnBizhawkPath.Name = "btnBizhawkPath";
			this.btnBizhawkPath.Size = new System.Drawing.Size(33, 23);
			this.btnBizhawkPath.TabIndex = 2;
			this.btnBizhawkPath.Text = "...";
			this.btnBizhawkPath.UseVisualStyleBackColor = true;
			this.btnBizhawkPath.Click += new System.EventHandler(this.btnBizhawkPath_Click);
			// 
			// btnOOTRCLIPath
			// 
			this.btnOOTRCLIPath.Location = new System.Drawing.Point(308, 134);
			this.btnOOTRCLIPath.Name = "btnOOTRCLIPath";
			this.btnOOTRCLIPath.Size = new System.Drawing.Size(33, 23);
			this.btnOOTRCLIPath.TabIndex = 5;
			this.btnOOTRCLIPath.Text = "...";
			this.btnOOTRCLIPath.UseVisualStyleBackColor = true;
			this.btnOOTRCLIPath.Click += new System.EventHandler(this.btnOOTRCLIPath_Click);
			// 
			// txtOOTRCLIPath
			// 
			this.txtOOTRCLIPath.Location = new System.Drawing.Point(15, 134);
			this.txtOOTRCLIPath.Name = "txtOOTRCLIPath";
			this.txtOOTRCLIPath.Size = new System.Drawing.Size(286, 22);
			this.txtOOTRCLIPath.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 114);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "OOTR CLI path:";
			// 
			// btnMMRCLIPath
			// 
			this.btnMMRCLIPath.Location = new System.Drawing.Point(308, 80);
			this.btnMMRCLIPath.Name = "btnMMRCLIPath";
			this.btnMMRCLIPath.Size = new System.Drawing.Size(33, 23);
			this.btnMMRCLIPath.TabIndex = 8;
			this.btnMMRCLIPath.Text = "...";
			this.btnMMRCLIPath.UseVisualStyleBackColor = true;
			this.btnMMRCLIPath.Click += new System.EventHandler(this.btnMMRCLIPath_Click);
			// 
			// txtMMRCLIPath
			// 
			this.txtMMRCLIPath.Location = new System.Drawing.Point(15, 80);
			this.txtMMRCLIPath.Name = "txtMMRCLIPath";
			this.txtMMRCLIPath.Size = new System.Drawing.Size(286, 22);
			this.txtMMRCLIPath.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 16);
			this.label3.TabIndex = 6;
			this.label3.Text = "MMR CLI path:";
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(353, 179);
			this.Controls.Add(this.btnMMRCLIPath);
			this.Controls.Add(this.txtMMRCLIPath);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnOOTRCLIPath);
			this.Controls.Add(this.txtOOTRCLIPath);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnBizhawkPath);
			this.Controls.Add(this.txtBizhawkPath);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.Text = "Settings";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBizhawkPath;
		private System.Windows.Forms.Button btnBizhawkPath;
		private System.Windows.Forms.Button btnOOTRCLIPath;
		private System.Windows.Forms.TextBox txtOOTRCLIPath;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnMMRCLIPath;
		private System.Windows.Forms.TextBox txtMMRCLIPath;
		private System.Windows.Forms.Label label3;
	}
}