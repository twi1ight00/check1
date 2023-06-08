using System;
using System.Drawing;
using System.Globalization;

namespace ns316;

internal class Class7177
{
	internal static Color smethod_0(Bitmap src, long stride)
	{
		int num = src.Width - Convert.ToInt32(Math.Round((decimal)stride / (decimal)src.Width, 0));
		int num2 = Convert.ToInt32(Math.Round((decimal)stride / (decimal)src.Width, 0));
		if (num2 < src.Width && num < src.Height)
		{
			return src.GetPixel(num, num2);
		}
		return Color.Gray;
	}

	internal static void smethod_1(ref Bitmap src, long stride, Color color)
	{
		int num = src.Width - Convert.ToInt32(Math.Round((decimal)stride / (decimal)src.Width, 0));
		int num2 = Convert.ToInt32(Math.Round((decimal)stride / (decimal)src.Width, 0));
		if (num < src.Width && num2 < src.Height)
		{
			src.SetPixel(num, num2, color);
		}
	}

	internal static int smethod_2(Color color)
	{
		string s = $"{color.R:x}" + $"{color.G:x}" + $"{color.B:x}";
		return int.Parse(s, NumberStyles.HexNumber);
	}

	internal static int[] smethod_3(Bitmap image)
	{
		int[] array = new int[image.Width * image.Height];
		for (int i = 0; i < image.Width; i++)
		{
			for (int j = 0; j < image.Width; j++)
			{
				long num = i * image.Width + j;
				array[num] = smethod_2(smethod_0(image, num));
			}
		}
		return array;
	}
}
