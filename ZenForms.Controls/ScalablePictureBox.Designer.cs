using System.Drawing;
using System.Windows.Forms;

namespace ZenForms.Controls
{
	partial class ScalablePictureBox
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
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(24, 24);
			this.pictureBox.TabIndex = 13;
			this.pictureBox.TabStop = false;
			// 
			// ScalablePictureBox
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Controls.Add(this.pictureBox);
			this.DoubleBuffered = true;
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "ScalablePictureBox";
			this.Size = new System.Drawing.Size(32, 32);
			this.PaddingChanged += new System.EventHandler(this.ScaleablePictureBox_PaddingChanged);
			this.Resize += new System.EventHandler(this.ScaleablePictureBox_Resize);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.PictureBox pictureBox;
	}
}
