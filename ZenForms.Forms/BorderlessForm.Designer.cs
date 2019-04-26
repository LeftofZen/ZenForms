using System.Drawing;
using System.Windows.Forms;

namespace ZenForms.Forms
{
	partial class BorderlessForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System.ComponentModel.IContainer components = null;

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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent()
		{
			this.TopLeftCornerPanel = new Panel();
			this.TopRightCornerPanel = new Panel();
			this.BottomLeftCornerPanel = new Panel();
			this.BottomRightCornerPanel = new Panel();
			this.TopBorderPanel = new Panel();
			this.BottomBorderPanel = new Panel();
			this.LeftBorderPanel = new Panel();
			this.RightBorderPanel = new Panel();
			this.SuspendLayout();
			//
			// TopLeftCornerPanel
			//
			this.TopLeftCornerPanel.BackColor = Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
			this.TopLeftCornerPanel.Cursor = Cursors.SizeNWSE;
			this.TopLeftCornerPanel.Location = new Point(0, 0);
			this.TopLeftCornerPanel.Name = "TopLeftCornerPanel";
			this.TopLeftCornerPanel.Size = new Size(1, 1);
			this.TopLeftCornerPanel.TabIndex = 0;
			//
			// TopRightCornerPanel
			//
			this.TopRightCornerPanel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.TopRightCornerPanel.BackColor = Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
			this.TopRightCornerPanel.Cursor = Cursors.SizeNESW;
			this.TopRightCornerPanel.Location = new Point(783, 0);
			this.TopRightCornerPanel.Name = "TopRightCornerPanel";
			this.TopRightCornerPanel.Size = new Size(1, 1);
			this.TopRightCornerPanel.TabIndex = 1;
			//
			// BottomLeftCornerPanel
			//
			this.BottomLeftCornerPanel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Left)));
			this.BottomLeftCornerPanel.BackColor = Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
			this.BottomLeftCornerPanel.Cursor = Cursors.SizeNESW;
			this.BottomLeftCornerPanel.Location = new Point(0, 440);
			this.BottomLeftCornerPanel.Name = "BottomLeftCornerPanel";
			this.BottomLeftCornerPanel.Size = new Size(1, 1);
			this.BottomLeftCornerPanel.TabIndex = 1;
			//
			// BottomRightCornerPanel
			//
			this.BottomRightCornerPanel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.BottomRightCornerPanel.BackColor = Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
			this.BottomRightCornerPanel.Cursor = Cursors.SizeNWSE;
			this.BottomRightCornerPanel.Location = new Point(783, 440);
			this.BottomRightCornerPanel.Name = "BottomRightCornerPanel";
			this.BottomRightCornerPanel.Size = new Size(1, 1);
			this.BottomRightCornerPanel.TabIndex = 1;
			//
			// TopBorderPanel
			//
			this.TopBorderPanel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
		| AnchorStyles.Right)));
			this.TopBorderPanel.BackColor = Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
			this.TopBorderPanel.Cursor = Cursors.SizeNS;
			this.TopBorderPanel.Location = new Point(1, 0);
			this.TopBorderPanel.Name = "TopBorderPanel";
			this.TopBorderPanel.Size = new Size(782, 1);
			this.TopBorderPanel.TabIndex = 2;
			//
			// BottomBorderPanel
			//
			this.BottomBorderPanel.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left)
		| AnchorStyles.Right)));
			this.BottomBorderPanel.BackColor = Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
			this.BottomBorderPanel.Cursor = Cursors.SizeNS;
			this.BottomBorderPanel.Location = new Point(1, 440);
			this.BottomBorderPanel.Name = "BottomBorderPanel";
			this.BottomBorderPanel.Size = new Size(782, 1);
			this.BottomBorderPanel.TabIndex = 3;
			//
			// LeftBorderPanel
			//
			this.LeftBorderPanel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
		| AnchorStyles.Left)));
			this.LeftBorderPanel.BackColor = Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
			this.LeftBorderPanel.Cursor = Cursors.SizeWE;
			this.LeftBorderPanel.Location = new Point(0, 1);
			this.LeftBorderPanel.Name = "LeftBorderPanel";
			this.LeftBorderPanel.Size = new Size(1, 439);
			this.LeftBorderPanel.TabIndex = 4;
			//
			// RightBorderPanel
			//
			this.RightBorderPanel.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Bottom)
		| AnchorStyles.Right)));
			this.RightBorderPanel.BackColor = Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
			this.RightBorderPanel.Cursor = Cursors.SizeWE;
			this.RightBorderPanel.Location = new Point(783, 1);
			this.RightBorderPanel.Name = "RightBorderPanel";
			this.RightBorderPanel.Size = new Size(1, 439);
			this.RightBorderPanel.TabIndex = 5;
			//
			// ZBorderlessForm
			//
			this.AutoScaleDimensions = new SizeF(6F, 13F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.White;
			this.ClientSize = new Size(784, 441);
			this.Controls.Add(this.RightBorderPanel);
			this.Controls.Add(this.LeftBorderPanel);
			this.Controls.Add(this.BottomBorderPanel);
			this.Controls.Add(this.TopBorderPanel);
			this.Controls.Add(this.TopRightCornerPanel);
			this.Controls.Add(this.BottomLeftCornerPanel);
			this.Controls.Add(this.BottomRightCornerPanel);
			this.Controls.Add(this.TopLeftCornerPanel);
			this.DoubleBuffered = true;
			this.MinimumSize = new Size(800, 480);
			this.Name = "ZBorderlessForm";
			this.Text = "Title";
			this.SizeChanged += new System.EventHandler(this.ZBorderlessForm_SizeChanged);
			this.ResumeLayout(false);

		}

		#endregion

		protected internal Panel TopLeftCornerPanel;
		protected internal Panel TopRightCornerPanel;
		protected internal Panel BottomLeftCornerPanel;
		protected internal Panel BottomRightCornerPanel;
		protected internal Panel TopBorderPanel;
		protected internal Panel BottomBorderPanel;
		protected internal Panel LeftBorderPanel;
		protected internal Panel RightBorderPanel;
	}
}

