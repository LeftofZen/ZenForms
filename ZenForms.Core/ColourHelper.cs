using System;
using System.Drawing;

namespace ZenForms.Core
{
	public static class ColourHelper
	{
		public static Color ShiftBrightness(Color colour, float percent)
		{
			return HSLtoRGB(colour.GetHue(), colour.GetSaturation(), colour.GetBrightness() + percent);
		}

		public static Color MakeGrayscale(Color colour)
		{
			return HSLtoRGB(colour.GetHue(), 0, colour.GetBrightness());
		}

		// C# Color really uses HSL, not HSB, and is misnamed.
		// https://www.codeproject.com/Articles/19045/Manipulating-colors-in-NET-Part-1
		/// <param name="h">Hue, must be in [0, 360].</param>
		/// <param name="s">Saturation, must be in [0, 1].</param>
		/// <param name="l">Luminance, must be in [0, 1].</param>
		//[SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider")]
		static Color HSLtoRGB(double h, double s, double l)
		{
			h = MathHelper.Clamp(h, 0, 360);
			s = MathHelper.Clamp(s, 0, 1);
			l = MathHelper.Clamp(l, 0, 1);

			if (s == 0)
			{
				// grayscale
				return Color.FromArgb(
					Convert.ToInt32(double.Parse(string.Format("{0:0.00}", l * 255.0))),
					Convert.ToInt32(double.Parse(string.Format("{0:0.00}", l * 255.0))),
					Convert.ToInt32(double.Parse(string.Format("{0:0.00}", l * 255.0))));
			}
			else
			{
				double q = (l < 0.5) ? (l * (1.0 + s)) : (l + s - (l * s));
				double p = (2.0 * l) - q;

				double hk = h / 360.0;
				double[] t = new double[3];
				t[0] = hk + (1.0 / 3.0);    // Tr
				t[1] = hk;                  // Tb
				t[2] = hk - (1.0 / 3.0);    // Tg

				for (int i = 0; i < 3; i++)
				{
					if (t[i] < 0)
					{
						t[i] += 1.0;
					}
					if (t[i] > 1)
					{
						t[i] -= 1.0;
					}

					if ((t[i] * 6) < 1)
					{
						t[i] = p + ((q - p) * 6.0 * t[i]);
					}
					else if ((t[i] * 2.0) < 1) //(1.0/6.0)<=T[i] && T[i]<0.5
					{
						t[i] = q;
					}
					else if ((t[i] * 3.0) < 2) // 0.5<=T[i] && T[i]<(2.0/3.0)
					{
						t[i] = p + (q - p) * ((2.0 / 3.0) - t[i]) * 6.0;
					}
					else
					{
						t[i] = p;
					}
				}

				return Color.FromArgb(
					Convert.ToInt32(double.Parse(string.Format("{0:0.00}", t[0] * 255.0))),
					Convert.ToInt32(double.Parse(string.Format("{0:0.00}", t[1] * 255.0))),
					Convert.ToInt32(double.Parse(string.Format("{0:0.00}", t[2] * 255.0)))
					);
			}
		}
	}
}
