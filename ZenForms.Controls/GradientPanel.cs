using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ZenForms.Controls
{
	public partial class GradientPanel : Panel
	{
		[Category("Gradient")]
		[Description("Gradient start colour")]
		public Color GradientStartColour
		{
			get => gradientStartColour;
			set { gradientStartColour = value; PaintGradient(); }
		}
		Color gradientStartColour = Color.White;

		[Category("Gradient")]
		[Description("Gradient end colour")]
		public Color GradientEndColour
		{
			get => gradientEndColour;
			set { gradientEndColour = value; PaintGradient(); }
		}
		Color gradientEndColour = Color.Black;

		[Category("Gradient")]
		[Description("Gradient direction")]
		public LinearGradientMode Direction
		{
			get => direction;
			set { direction = value; PaintGradient(); }
		}
		LinearGradientMode direction = LinearGradientMode.Horizontal;

		public GradientPanel()
		{
			InitializeComponent();
			PaintGradient();
		}

		void PaintGradient()
		{
			var drawRect = new Rectangle(0, 0, Width, Height);
			var gradBrush = new LinearGradientBrush(
				drawRect,
				GradientStartColour,
				GradientEndColour,
				Direction);

			Bitmap bmp = new Bitmap(Width, Height);
			Graphics g = Graphics.FromImage(bmp);

			g.FillRectangle(gradBrush, drawRect);

			BackgroundImage = bmp;
		}
	}
}
