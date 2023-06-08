using System;
using System.Drawing;

namespace ns44;

internal class Class1336
{
	internal static Color smethod_0(Color color_0, double double_0)
	{
		int[] array = new int[3] { color_0.R, color_0.G, color_0.B };
		for (int i = 0; i < 3; i++)
		{
			double num = smethod_17(array[i]);
			double double_ = num * (1.0 + (1.0 - double_0));
			if (double_0 > 0.0)
			{
				double_ = num * (1.0 - (1.0 - double_0)) + (1.0 - double_0);
			}
			array[i] = smethod_18(double_);
		}
		return Color.FromArgb(array[0], array[1], array[2]);
	}

	internal static Color smethod_1(Color color_0, double double_0)
	{
		int[] array = new int[3] { color_0.R, color_0.G, color_0.B };
		for (int i = 0; i < 3; i++)
		{
			double num = smethod_17(array[i]);
			double num2 = num * double_0;
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
			else if (num2 > 1.0)
			{
				num2 = 1.0;
			}
			array[i] = smethod_18(num2);
		}
		return Color.FromArgb(array[0], array[1], array[2]);
	}

	internal static Color smethod_2(Color color_0, double double_0)
	{
		if (double_0 == 0.0)
		{
			return color_0;
		}
		Class1681 @class = smethod_31(color_0);
		if (double_0 < 0.0)
		{
			@class.method_5(@class.method_4() * (1.0 + double_0));
		}
		else if (double_0 > 0.0)
		{
			@class.method_5(@class.method_4() * (1.0 - double_0) + double_0);
		}
		return smethod_32(@class);
	}

	internal static Color smethod_3(Color color_0, double double_0)
	{
		int alpha = (int)Math.Round(255.0 * (1.0 - double_0), 0, MidpointRounding.AwayFromZero);
		return Color.FromArgb(alpha, color_0);
	}

	internal static Color smethod_4(Color color_0, double double_0)
	{
		int alpha = (int)Math.Round(255.0 * (1.0 - (1.0 - (double)(int)color_0.A / 255.0) * double_0), 0, MidpointRounding.AwayFromZero);
		return Color.FromArgb(alpha, color_0);
	}

	internal static Color smethod_5(Color color_0, double double_0)
	{
		int alpha = (int)Math.Round(255.0 * (1.0 - (1.0 - (double)(int)color_0.A / 255.0) - double_0), 0, MidpointRounding.AwayFromZero);
		return Color.FromArgb(alpha, color_0);
	}

	internal static Color smethod_6(Color color_0, double double_0)
	{
		double num = smethod_17(255);
		num *= double_0;
		int red = smethod_18(num);
		return Color.FromArgb(red, color_0.G, color_0.B);
	}

	internal static Color smethod_7(Color color_0, double double_0)
	{
		double num = smethod_17(color_0.R);
		num *= double_0;
		int red = smethod_18(num);
		return Color.FromArgb(red, color_0.G, color_0.B);
	}

	internal static Color smethod_8(Color color_0, double double_0)
	{
		double num = smethod_17(color_0.R);
		num += double_0;
		int red = smethod_18(num);
		return Color.FromArgb(red, color_0.G, color_0.B);
	}

	internal static Color smethod_9(Color color_0, double double_0)
	{
		double num = smethod_17(255);
		num *= double_0;
		int green = smethod_18(num);
		return Color.FromArgb(color_0.R, green, color_0.B);
	}

	internal static Color smethod_10(Color color_0, double double_0)
	{
		double num = smethod_17(color_0.G);
		num *= double_0;
		int green = smethod_18(num);
		return Color.FromArgb(color_0.R, green, color_0.B);
	}

	internal static Color smethod_11(Color color_0, double double_0)
	{
		double num = smethod_17(color_0.G);
		num += double_0;
		int green = smethod_18(num);
		return Color.FromArgb(color_0.R, green, color_0.B);
	}

	internal static Color smethod_12(Color color_0, double double_0)
	{
		double num = smethod_17(255);
		num *= double_0;
		int blue = smethod_18(num);
		return Color.FromArgb(color_0.R, color_0.G, blue);
	}

	internal static Color smethod_13(Color color_0, double double_0)
	{
		double num = smethod_17(color_0.B);
		num *= double_0;
		int blue = smethod_18(num);
		return Color.FromArgb(color_0.R, color_0.G, blue);
	}

	internal static Color smethod_14(Color color_0, double double_0)
	{
		double num = smethod_17(color_0.B);
		num += double_0;
		int blue = smethod_18(num);
		return Color.FromArgb(color_0.R, color_0.G, blue);
	}

	internal static Color smethod_15(Color color_0)
	{
		Class1681 @class = smethod_31(color_0);
		if (@class.method_0() < 180.0)
		{
			@class.method_1(@class.method_0() + 180.0);
		}
		else
		{
			@class.method_1(@class.method_0() - 180.0);
		}
		return smethod_32(@class);
	}

	internal static Color smethod_16(Color color_0)
	{
		int[] array = new int[3] { color_0.R, color_0.G, color_0.B };
		for (int i = 0; i < 3; i++)
		{
			double double_ = 1.0 - smethod_17(array[i]);
			array[i] = smethod_18(double_);
		}
		return Color.FromArgb(array[0], array[1], array[2]);
	}

	internal static double smethod_17(int int_0)
	{
		double num = (double)int_0 / 255.0;
		double num2 = 0.0;
		if (num < 0.0)
		{
			return 0.0;
		}
		if (num <= 0.04045)
		{
			return num / 12.92;
		}
		if (num <= 1.0)
		{
			return Math.Pow((num + 0.055) / 1.055, 2.4);
		}
		return 1.0;
	}

	internal static int smethod_18(double double_0)
	{
		double num = 0.0;
		num = ((double_0 < 0.0) ? 0.0 : ((double_0 <= 0.0031308) ? (double_0 * 12.92) : ((!(double_0 < 1.0)) ? 1.0 : (1.055 * Math.Pow(double_0, 5.0 / 12.0) - 0.055))));
		return (int)Math.Round(num * 255.0, 0, MidpointRounding.AwayFromZero);
	}

	internal static Color smethod_19(Color color_0, double double_0)
	{
		Class1681 @class = smethod_31(color_0);
		@class.method_1(double_0);
		return smethod_32(@class);
	}

	internal static Color smethod_20(Color color_0, double double_0)
	{
		Class1681 @class = smethod_31(color_0);
		@class.method_1(@class.method_0() * double_0);
		return smethod_32(@class);
	}

	internal static Color smethod_21(Color color_0, double double_0)
	{
		Class1681 @class = smethod_31(color_0);
		@class.method_1(@class.method_0() + double_0);
		return smethod_32(@class);
	}

	internal static Color smethod_22(Color color_0, double double_0)
	{
		Class1681 @class = smethod_31(color_0);
		@class.method_3(double_0);
		return smethod_32(@class);
	}

	internal static Color smethod_23(Color color_0, double double_0)
	{
		Class1681 @class = smethod_31(color_0);
		@class.method_3(@class.method_2() * double_0);
		return smethod_32(@class);
	}

	internal static Color smethod_24(Color color_0, double double_0)
	{
		Class1681 @class = smethod_31(color_0);
		@class.method_3(@class.method_2() + double_0);
		return smethod_32(@class);
	}

	internal static Color smethod_25(Color color_0, double double_0)
	{
		Class1681 @class = smethod_31(color_0);
		@class.method_5(double_0);
		return smethod_32(@class);
	}

	internal static Color smethod_26(Color color_0, double double_0)
	{
		Class1681 @class = smethod_31(color_0);
		@class.method_5(@class.method_4() * double_0);
		return smethod_32(@class);
	}

	internal static Color smethod_27(Color color_0, double double_0)
	{
		Class1681 @class = smethod_31(color_0);
		@class.method_5(@class.method_4() + double_0);
		return smethod_32(@class);
	}

	internal static Color smethod_28(Color color_0)
	{
		int[] array = new int[3] { color_0.R, color_0.G, color_0.B };
		for (int i = 0; i < 3; i++)
		{
			array[i] = (int)Math.Round(Math.Min(255.0, 255.0 * Math.Pow((double)array[i] / 255.0, 0.45454545454545453) + 0.5), 0, MidpointRounding.AwayFromZero);
		}
		return Color.FromArgb(array[0], array[1], array[2]);
	}

	internal static Color smethod_29(Color color_0)
	{
		int[] array = new int[3] { color_0.R, color_0.G, color_0.B };
		for (int i = 0; i < 3; i++)
		{
			array[i] = (int)Math.Round(255.0 * Math.Pow((double)array[i] / 255.0, 2.2), 0, MidpointRounding.AwayFromZero);
		}
		return Color.FromArgb(array[0], array[1], array[2]);
	}

	internal static Color smethod_30(Color color_0)
	{
		int num = (int)Math.Round((double)(int)color_0.R * 0.2126 + (double)(int)color_0.G * 0.7152 + (double)(int)color_0.B * 0.0722, 0, MidpointRounding.AwayFromZero);
		return Color.FromArgb(num, num, num);
	}

	internal static Class1681 smethod_31(Color color_0)
	{
		double double_ = 0.0;
		double double_2 = 0.0;
		double num = 0.0;
		double num2 = (double)(int)color_0.R / 255.0;
		double num3 = (double)(int)color_0.G / 255.0;
		double num4 = (double)(int)color_0.B / 255.0;
		double num5 = Math.Max(num2, Math.Max(num3, num4));
		double num6 = Math.Min(num2, Math.Min(num3, num4));
		if (num5 == num6)
		{
			double_ = 0.0;
		}
		else if (num5 == num2 && num3 >= num4)
		{
			double_ = 60.0 * (num3 - num4) / (num5 - num6);
		}
		else if (num5 == num2 && num3 < num4)
		{
			double_ = 60.0 * (num3 - num4) / (num5 - num6) + 360.0;
		}
		else if (num5 == num3)
		{
			double_ = 60.0 * (num4 - num2) / (num5 - num6) + 120.0;
		}
		else if (num5 == num4)
		{
			double_ = 60.0 * (num2 - num3) / (num5 - num6) + 240.0;
		}
		num = (num5 + num6) / 2.0;
		if (num != 0.0 && num5 != num6)
		{
			if (0.0 < num && num <= 0.5)
			{
				double_2 = (num5 - num6) / (num5 + num6);
			}
			else if (num > 0.5)
			{
				double_2 = (num5 - num6) / (2.0 - (num5 + num6));
			}
		}
		else
		{
			double_2 = 0.0;
		}
		return new Class1681(double_, double_2, num);
	}

	internal static Color smethod_32(Class1681 class1681_0)
	{
		if (class1681_0.method_2() == 0.0)
		{
			int num = (int)Math.Round(class1681_0.method_4() * 255.0, 0, MidpointRounding.AwayFromZero);
			return Color.FromArgb(num, num, num);
		}
		double num2 = ((class1681_0.method_4() < 0.5) ? (class1681_0.method_4() * (1.0 + class1681_0.method_2())) : (class1681_0.method_4() + class1681_0.method_2() - class1681_0.method_4() * class1681_0.method_2()));
		double num3 = 2.0 * class1681_0.method_4() - num2;
		double num4 = class1681_0.method_0() / 360.0;
		double[] array = new double[3]
		{
			num4 + 1.0 / 3.0,
			num4,
			num4 - 1.0 / 3.0
		};
		for (int i = 0; i < 3; i++)
		{
			if (array[i] < 0.0)
			{
				array[i] += 1.0;
			}
			if (array[i] > 1.0)
			{
				array[i] -= 1.0;
			}
			if (array[i] * 6.0 < 1.0)
			{
				array[i] = num3 + (num2 - num3) * 6.0 * array[i];
			}
			else if (array[i] * 2.0 < 1.0)
			{
				array[i] = num2;
			}
			else if (array[i] * 3.0 < 2.0)
			{
				array[i] = num3 + (num2 - num3) * (2.0 / 3.0 - array[i]) * 6.0;
			}
			else
			{
				array[i] = num3;
			}
		}
		return Color.FromArgb((int)Math.Round(array[0] * 255.0, 0, MidpointRounding.AwayFromZero), (int)Math.Round(array[1] * 255.0, 0, MidpointRounding.AwayFromZero), (int)Math.Round(array[2] * 255.0, 0, MidpointRounding.AwayFromZero));
	}
}
