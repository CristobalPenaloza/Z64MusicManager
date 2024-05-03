namespace Z64MusicManager {
	partial class AboutForm {
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(240, 29);
			this.label1.TabIndex = 0;
			this.label1.Text = "Z64 Music Manager";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(349, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "A small tool for managing Zelda 64 custom music files.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(248, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Created by Tolin (Cristóbal Peñaloza).\r\n";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(65, 183);
			this.label4.MaximumSize = new System.Drawing.Size(300, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(269, 34);
			this.label4.TabIndex = 3;
			this.label4.Text = "Made with ❤️ for the Ocarina of Time and Majora\'s Mask Randomizer community.";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 116);
			this.label5.MaximumSize = new System.Drawing.Size(365, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(357, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "Thanks to Revven, Isghj and Joshua8600 for their help!";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 133);
			this.label6.MaximumSize = new System.Drawing.Size(365, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(339, 17);
			this.label6.TabIndex = 5;
			this.label6.Text = "Also, shoutouts to Matty07 for the amazing file icons!";
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 235);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.Text = "About";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
	}
}