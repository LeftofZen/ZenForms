using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ZenForms.Controls
{
	public partial class ScalablePictureBox : UserControl // SuppressCodeSmell Reason = not used for data binding
	{
		public ScalablePictureBox()
		{
			InitializeComponent();
		}

		#region Events

		void pictureBox_MouseDown(object sender, MouseEventArgs e)
		{
			OnMouseDown(e);
		}

		void pictureBox_MouseUp(object sender, MouseEventArgs e)
		{
			OnMouseUp(e);
		}
		void ScaleablePictureBox_Resize(object sender, System.EventArgs e)
		{
			UpdateImage();
		}

		void ScaleablePictureBox_PaddingChanged(object sender, EventArgs e)
		{
			UpdateImage();
		}

		#endregion

		[Category("Custom Properties")]
		[Description("The scale factor to apply to the image.")]
		public float PictureScale
		{
			get => scale;
			set
			{
				scale = value;
				UpdateImage();
			}
		}
		float scale = 1f;

		public void UpdateImage()
		{
			pictureBox.Height = Math.Min(Width - Padding.Horizontal, Height - Padding.Vertical);
			pictureBox.Width = pictureBox.Height;
			pictureBox.Scale(new SizeF(PictureScale, PictureScale));
			pictureBox.Location = new Point(
				(Width - pictureBox.Width + Padding.Left - Padding.Right) / 2,
				(Height - pictureBox.Height + Padding.Top - Padding.Bottom) / 2);
		}

		public Image DisplayedImage
		{
			get => pictureBox.BackgroundImage;
			set => pictureBox.BackgroundImage = value;
		}
	}
}
