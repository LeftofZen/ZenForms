using System;

namespace ZenForms.Core
{
	public static class MathHelper
	{
		#region Clamp

		// C# has no support for proper generics unfortunately
		//public static T Clamp<T>(T value, T min, T max) where T : ArithmeticType
		//{
		//	return Math.Max(Math.Min(value, max), min);
		//}

		public static int Clamp(int value, int min, int max)
		{
			return Math.Max(Math.Min(value, max), min);
		}

		public static double Clamp(double value, double min, double max)
		{
			return Math.Max(Math.Min(value, max), min);
		}

		public static float Clamp(float value, float min, float max)
		{
			return Math.Max(Math.Min(value, max), min);
		}

		#endregion
	}
}
