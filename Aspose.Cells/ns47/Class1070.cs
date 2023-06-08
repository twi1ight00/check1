using System;
using ns18;

namespace ns47;

internal class Class1070 : Class1067
{
	internal int int_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal int int_4;

	internal int int_5;

	internal int int_6;

	internal int[] int_7;

	internal int[] int_8;

	internal int[] int_9;

	internal int[] int_10;

	internal int[] int_11;

	internal Class1070(Class1393 class1393_0)
	{
		int num = (int)class1393_0.method_0().Position;
		if (class1393_0.method_4() != 0)
		{
			throw new InvalidOperationException("Unexpected cmap table version.");
		}
		int num2 = class1393_0.method_4();
		int num3 = 0;
		int num6;
		while (true)
		{
			if (num3 < num2)
			{
				int_0 = class1393_0.method_4();
				int_1 = class1393_0.method_4();
				int num4 = class1393_0.method_1();
				if (int_0 == 3 && (int_1 == 1 || int_1 == 0))
				{
					int num5 = (int)class1393_0.method_0().Position;
					num6 = num + num4;
					class1393_0.method_0().Position = num6;
					int num7 = class1393_0.method_4();
					if (num7 == 4)
					{
						break;
					}
					class1393_0.method_0().Position = num5;
				}
				num3++;
				continue;
			}
			throw new InvalidOperationException("Cannot find a required cmap table.");
		}
		class1393_0.method_0().Position = num6;
		method_1(class1393_0);
	}

	private void method_1(Class1393 class1393_0)
	{
		int num = (int)class1393_0.method_0().Position;
		int num2 = class1393_0.method_4();
		if (num2 != 4)
		{
			throw new InvalidOperationException("Unexpected cmap subtable format.");
		}
		int num3 = class1393_0.method_4();
		int_2 = class1393_0.method_4();
		int_3 = class1393_0.method_4();
		int_4 = class1393_0.method_4();
		int_5 = class1393_0.method_4();
		int_6 = class1393_0.method_4();
		int int_ = int_3 / 2;
		int_7 = smethod_0(class1393_0, int_);
		class1393_0.method_4();
		int_8 = smethod_0(class1393_0, int_);
		int_9 = smethod_1(class1393_0, int_);
		int_10 = smethod_0(class1393_0, int_);
		int num4 = num + num3;
		int num5 = num4 - (int)class1393_0.method_0().Position;
		int num6 = num5 / 2;
		if (num4 + 4 <= class1393_0.method_0().Length)
		{
			num6 += 2;
		}
		int_11 = smethod_0(class1393_0, num6);
	}

	internal Class1464 method_2(Class1457 class1457_0, string string_0)
	{
		Class1464 @class = new Class1464();
		int num = int_7.Length;
		if (!string_0.ToLower().StartsWith("wingdings"))
		{
			string_0.ToLower().StartsWith("marlett");
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = int_8[i]; j <= int_7[i]; j++)
			{
				int num2;
				if (j == 65535)
				{
					num2 = 0;
				}
				else
				{
					switch (int_10[i])
					{
					default:
					{
						int num3 = j - int_8[i];
						int num4 = int_10[i] / 2 + num3 - num + i;
						num2 = int_11[num4];
						if (num2 != 0)
						{
							num2 = (num2 + int_9[i]) & 0xFFFF;
						}
						break;
					}
					case 65535:
						num2 = 0;
						break;
					case 0:
						num2 = (j + int_9[i]) & 0xFFFF;
						if (num2 == 65535)
						{
							num2 = 0;
						}
						break;
					}
				}
				Struct91 @struct = class1457_0.method_0(num2);
				long num5 = j;
				if (class1457_0.struct91_0.Length < 255 && j > 61440 && j != 65535)
				{
					num5 &= 0xFFF;
				}
				Class1463 class2 = new Class1463((char)num5, num2, @struct.ushort_0, @struct.short_0);
				@class.Add(class2);
				if (class2.method_1() == 0)
				{
					@class.method_0(class2);
				}
			}
		}
		return @class;
	}

	internal void method_3(Class1398 class1398_0)
	{
		int num = class1398_0.Count - 1;
		if (class1398_0.method_3(num) != 65535)
		{
			throw new InvalidOperationException("Last character is supposed to be the 0xffff (the missing character).");
		}
		if ((int)class1398_0.GetByIndex(num) != 0)
		{
			throw new InvalidOperationException("Glyph index for the missing character is expected to be zero.");
		}
		int count = class1398_0.Count;
		int_3 = count * 2;
		int_4 = 2 << (int)Math.Floor(Math.Log(count) / Math.Log(2.0));
		int_5 = (int)(Math.Log((double)int_4 / 2.0) / Math.Log(2.0));
		int_6 = 2 * count - int_4;
		int_7 = new int[count];
		int_8 = new int[count];
		int_9 = new int[count];
		int_10 = new int[count];
		int_11 = new int[0];
		for (int i = 0; i < class1398_0.Count; i++)
		{
			int num2 = class1398_0.method_3(i);
			int num3 = (int)class1398_0.GetByIndex(i);
			int_7[i] = num2;
			int_8[i] = num2;
			int_9[i] = num3 - num2;
		}
	}

	internal override void Write(Class1394 class1394_0)
	{
		class1394_0.method_3(0);
		class1394_0.method_3(1);
		class1394_0.method_3(int_0);
		class1394_0.method_3(int_1);
		class1394_0.method_2(12u);
		method_4(class1394_0);
	}

	private void method_4(Class1394 class1394_0)
	{
		_ = class1394_0.method_0().Position;
		class1394_0.method_3(4);
		int num = 16 + int_3 * 4 + int_11.Length * 2;
		class1394_0.method_3(num);
		class1394_0.method_3(int_2);
		class1394_0.method_3(int_3);
		class1394_0.method_3(int_4);
		class1394_0.method_3(int_5);
		class1394_0.method_3(int_6);
		smethod_2(int_7, class1394_0);
		class1394_0.method_3(0);
		smethod_2(int_8, class1394_0);
		smethod_2(int_9, class1394_0);
		smethod_2(int_10, class1394_0);
		smethod_2(int_11, class1394_0);
	}

	private static int[] smethod_0(Class1393 class1393_0, int int_12)
	{
		int[] array = new int[int_12];
		for (int i = 0; i < int_12; i++)
		{
			array[i] = class1393_0.method_4();
		}
		return array;
	}

	private static int[] smethod_1(Class1393 class1393_0, int int_12)
	{
		int[] array = new int[int_12];
		for (int i = 0; i < int_12; i++)
		{
			array[i] = class1393_0.method_3();
		}
		return array;
	}

	private static void smethod_2(int[] int_12, Class1394 class1394_0)
	{
		foreach (int num in int_12)
		{
			class1394_0.method_3(num);
		}
	}
}
