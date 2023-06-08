using System;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace ns19;

internal class Class878
{
	private Enum93 enum93_0 = Enum93.const_0;

	private Class878 class878_0;

	internal Class875[] class875_0;

	private Class876[] class876_0;

	internal Class873[] class873_0;

	private Class879[] class879_0;

	private Class881[] class881_0;

	internal Class874[] class874_0;

	internal Class874[] class874_1;

	internal static readonly Class873[] class873_1 = new Class873[0];

	internal static readonly string[] string_0 = new string[11]
	{
		"c", "w", "h", "ss", "ls", "hc", "vc", "l", "t", "r",
		"b"
	};

	[SpecialName]
	internal void method_0(Enum93 enum93_1)
	{
		if (enum93_0 != enum93_1 && enum93_1 != 0)
		{
			if (enum93_0 == Enum93.const_1)
			{
				class875_0 = null;
				class876_0 = null;
				class873_0 = class873_1;
				class879_0 = null;
				class881_0 = null;
				class874_0 = null;
				class874_1 = null;
			}
			enum93_0 = enum93_1;
			class878_0 = Class880.smethod_1(enum93_0);
			if (class878_0 != null)
			{
				class875_0 = smethod_0(class878_0.class875_0);
			}
		}
	}

	internal GraphicsPath[] method_1(float float_0, float float_1, float float_2, float float_3)
	{
		Class878 @class = this;
		if (enum93_0 != 0)
		{
			@class = class878_0;
		}
		Class881[] array = @class.class881_0;
		if (array.Length == 0)
		{
			return null;
		}
		GraphicsPath[] array2 = new GraphicsPath[array.Length];
		method_4(float_2, float_3, out var guideValueFlags, out var guideValues);
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = array[i].method_0(this, guideValues, guideValueFlags, float_0, float_1, float_2, float_3, out var _);
		}
		return array2;
	}

	internal float method_2(double[] double_0, Enum90[] enum90_0, long long_0)
	{
		Enum90 geomRef = Enum90.flag_0;
		return method_3(double_0, enum90_0, long_0, out geomRef);
	}

	internal float method_3(double[] guideValues, Enum90[] guideValueFlags, long value, out Enum90 geomRef)
	{
		geomRef = Enum90.flag_0;
		if (value < -27273042329600L)
		{
			geomRef = guideValueFlags[(int)(-27273042329600L - value - 1)];
			return (float)guideValues[(int)(-27273042329600L - value - 1)];
		}
		if (value <= 27273042316900L)
		{
			return value;
		}
		return class875_0[(int)(value - 27273042316900L - 1)].method_0();
	}

	internal void method_4(float width, float height, out Enum90[] guideValueFlags, out double[] guideValues)
	{
		Class878 @class = this;
		if (enum93_0 != 0)
		{
			@class = class878_0;
		}
		Class879[] array = @class.class879_0;
		guideValues = new double[array.Length + 11];
		guideValueFlags = new Enum90[array.Length + 11];
		guideValueFlags[7] = Enum90.flag_1;
		guideValueFlags[8] = Enum90.flag_3;
		guideValueFlags[9] = Enum90.flag_2;
		guideValueFlags[10] = Enum90.flag_4;
		int num = 0;
		int num2 = -1;
		for (int i = 0; i < 11; i++)
		{
			guideValueFlags[i] |= Enum90.flag_5;
		}
		guideValues[0] = 21600000.0;
		guideValues[1] = width;
		guideValues[2] = height;
		guideValues[3] = ((width > height) ? height : width);
		guideValues[4] = ((width > height) ? width : height);
		guideValues[5] = width / 2f;
		guideValues[6] = height / 2f;
		guideValues[7] = 0.0;
		guideValues[8] = 0.0;
		guideValues[9] = width;
		guideValues[10] = height;
		int num3 = 10;
		while (num3 > 0 && num < guideValues.Length)
		{
			num2 = num;
			num = guideValues.Length;
			num3 = 0;
			for (int j = Math.Max(num2, 11); j < guideValues.Length; j++)
			{
				if ((guideValueFlags[j] & Enum90.flag_5) == Enum90.flag_5)
				{
					continue;
				}
				Class879 class2 = array[j - 11];
				Enum90 geomRef;
				double num4 = method_6(guideValues, guideValueFlags, class2.long_0, out geomRef);
				Enum90 geomRef2;
				double num5 = method_6(guideValues, guideValueFlags, class2.long_1, out geomRef2);
				Enum90 geomRef3;
				double num6 = method_6(guideValues, guideValueFlags, class2.long_2, out geomRef3);
				if (!double.IsNaN(num4) && !double.IsNaN(num5) && !double.IsNaN(num6))
				{
					switch (class2.enum89_0)
					{
					case Enum89.const_0:
						guideValues[j] = num4 * num5 / num6;
						break;
					case Enum89.const_1:
						guideValues[j] = num4 + num5 - num6;
						break;
					case Enum89.const_2:
						guideValues[j] = (num4 + num5) / num6;
						break;
					case Enum89.const_3:
						guideValues[j] = ((num4 > 0.0) ? num5 : num6);
						break;
					case Enum89.const_4:
						guideValues[j] = Math.Abs(num4);
						break;
					case Enum89.const_5:
						guideValues[j] = Math.Atan2(num5, num4) / 2.9088820866572157E-07;
						break;
					case Enum89.const_6:
						guideValues[j] = num4 * Math.Cos(Math.Atan2(num6, num5));
						break;
					case Enum89.const_7:
						guideValues[j] = num4 * Math.Cos(num5 * 2.9088820866572157E-07);
						break;
					case Enum89.const_8:
						guideValues[j] = Math.Max(num4, num5);
						break;
					case Enum89.const_9:
						guideValues[j] = Math.Min(num4, num5);
						break;
					case Enum89.const_10:
						guideValues[j] = Math.Sqrt(num4 * num4 + num5 * num5 + num6 * num6);
						break;
					case Enum89.const_11:
						guideValues[j] = ((num4 > num5) ? num4 : ((num5 > num6) ? num6 : num5));
						break;
					case Enum89.const_12:
						guideValues[j] = num4 * Math.Sin(Math.Atan2(num6, num5));
						break;
					case Enum89.const_13:
						guideValues[j] = num4 * Math.Sin(num5 * 2.9088820866572157E-07);
						break;
					case Enum89.const_14:
						guideValues[j] = Math.Sqrt(num4);
						break;
					case Enum89.const_15:
						guideValues[j] = num4 * Math.Tan(num5 * 2.9088820866572157E-07);
						break;
					case Enum89.const_16:
						guideValues[j] = num4;
						break;
					}
					guideValueFlags[j] = geomRef | geomRef2 | geomRef3 | Enum90.flag_5;
					num3++;
				}
				else if (j < num)
				{
					num = j;
				}
			}
		}
	}

	public Class878()
	{
	}

	public Class878(Class875[] class875_1, Class879[] class879_1, Class876[] class876_1, Class873[] class873_2, Class881[] class881_1, Class874 class874_2, Class874 class874_3)
	{
		class875_0 = class875_1;
		class876_0 = class876_1;
		class873_0 = class873_2;
		class879_0 = class879_1;
		class881_0 = class881_1;
		enum93_0 = Enum93.const_1;
		if (class874_2 != null)
		{
			class874_0 = new Class874[1];
			class874_0[0] = class874_2;
			class874_1 = new Class874[1];
			class874_1[0] = class874_3;
		}
	}

	internal static Class875[] smethod_0(Class875[] class875_1)
	{
		Class875[] array = new Class875[class875_1.Length];
		for (int i = 0; i < class875_1.Length; i++)
		{
			array[i] = new Class875(class875_1[i]);
		}
		return array;
	}

	internal float method_5(double[] double_0, Enum90[] enum90_0, long long_0)
	{
		Enum90 geomRef;
		return method_3(double_0, enum90_0, long_0, out geomRef) / 60000f;
	}

	private double method_6(double[] guideValues, Enum90[] guideFlags, long coordinate, out Enum90 geomRef)
	{
		geomRef = Enum90.flag_0;
		if (coordinate > 27273042316900L)
		{
			return class875_0[(int)(coordinate - 27273042316900L - 1)].method_0();
		}
		if (coordinate < -27273042329600L)
		{
			int num = (int)(-27273042329600L - coordinate - 1);
			if ((guideFlags[num] & Enum90.flag_5) == Enum90.flag_5)
			{
				geomRef = guideFlags[num];
				return guideValues[num];
			}
			return double.NaN;
		}
		return coordinate;
	}
}
