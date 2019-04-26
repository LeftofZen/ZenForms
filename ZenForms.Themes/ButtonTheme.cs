using System.Drawing;
using System.Windows.Forms;
using ZenForms.Core;

namespace ZenForms.Themes
{
	public class ButtonTheme
	{
		public ButtonTheme(
			Color foreColour, Color backColour,
			Color mouseOverForeColour, Color mouseOverBackColour,
			Color mouseDownForeColour, Color mouseDownBackColour,
			int borderSize)
		{
			ForeColour = foreColour;
			BackColour = backColour;
			MouseOverForeColour = mouseOverForeColour;
			MouseOverBackColour = mouseOverBackColour;
			MouseDownForeColour = mouseDownForeColour;
			MouseDownBackColour = mouseDownBackColour;

			BorderSize = borderSize;
		}

		public ButtonTheme(Color foreColor, Color backColor, int borderSize = 0)
			: this(foreColor, backColor,
				  foreColor, ColourHelper.ShiftBrightness(backColor, 0.15f),
				  foreColor, ColourHelper.ShiftBrightness(backColor, -0.15f),
				  borderSize)
		{ }

		public Color ForeColour { get; }
		public Color BackColour { get; }
		public Color MouseOverForeColour { get; }
		public Color MouseOverBackColour { get; }
		public Color MouseDownForeColour { get; }
		public Color MouseDownBackColour { get; }
		public int BorderSize { get; }

		public ButtonTheme AsInactive()
		{
			return new ButtonTheme
			(
				ColourHelper.MakeGrayscale(ForeColour),
				ColourHelper.MakeGrayscale(BackColour),
				ColourHelper.MakeGrayscale(MouseOverForeColour),
				ColourHelper.MakeGrayscale(MouseOverBackColour),
				ColourHelper.MakeGrayscale(MouseDownForeColour),
				ColourHelper.MakeGrayscale(MouseDownBackColour),
				BorderSize
			);
		}

		public override string ToString()
		{
			return $"ForeColour={ForeColour} BackColour={BackColour} MouseOverForeColour={MouseOverForeColour} MouseOverBackColour={MouseOverBackColour} MouseDownForeColour={MouseDownForeColour} MouseDownBackColour={MouseDownBackColour} BorderSize={BorderSize}"; // SuppressCodeSmell Reason = not shown to users
		}
	}

	public static class ButtonThemeExtensions
	{
		public static void ApplyTheme(this Button button, ButtonTheme theme)
		{
			button.FlatAppearance.MouseOverBackColor = theme.MouseOverBackColour;
			button.FlatAppearance.MouseDownBackColor = theme.MouseDownBackColour;
			button.ForeColor = theme.ForeColour;
			button.BackColor = theme.BackColour;
			button.FlatAppearance.BorderSize = theme.BorderSize;
			button.FlatAppearance.BorderColor = theme.BackColour;

			// not available in FlatButtonAppearance and we can't subclass it so we have to do it manually
			button.MouseDown += (s, e) => { button.ForeColor = theme.MouseDownForeColour; };
			button.MouseUp += (s, e) => { button.ForeColor = theme.MouseOverForeColour; };
			button.MouseEnter += (s, e) => { button.ForeColor = theme.MouseOverForeColour; };
			button.MouseLeave += (s, e) => { button.ForeColor = theme.ForeColour; };
		}
	}
}
