using System;

namespace ns276;

internal sealed class Class6749
{
	private const int int_0 = 15;

	private const int int_1 = 19;

	private const int int_2 = 30;

	private const int int_3 = 256;

	private const int int_4 = 29;

	private const int int_5 = 286;

	private const int int_6 = 573;

	internal const int int_7 = 7;

	internal const int int_8 = 256;

	internal const int int_9 = 16;

	internal const int int_10 = 17;

	internal const int int_11 = 18;

	internal const int int_12 = 16;

	internal static readonly int[] int_13 = new int[29]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
		1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
		4, 4, 4, 4, 5, 5, 5, 5, 0
	};

	internal static readonly int[] int_14 = new int[30]
	{
		0, 0, 0, 0, 1, 1, 2, 2, 3, 3,
		4, 4, 5, 5, 6, 6, 7, 7, 8, 8,
		9, 9, 10, 10, 11, 11, 12, 12, 13, 13
	};

	internal static readonly int[] int_15 = new int[19]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
		0, 0, 0, 0, 0, 0, 2, 3, 7
	};

	internal static readonly sbyte[] sbyte_0 = new sbyte[19]
	{
		16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
		11, 4, 12, 3, 13, 2, 14, 1, 15
	};

	private static readonly sbyte[] sbyte_1 = new sbyte[512]
	{
		0, 1, 2, 3, 4, 4, 5, 5, 6, 6,
		6, 6, 7, 7, 7, 7, 8, 8, 8, 8,
		8, 8, 8, 8, 9, 9, 9, 9, 9, 9,
		9, 9, 10, 10, 10, 10, 10, 10, 10, 10,
		10, 10, 10, 10, 10, 10, 10, 10, 11, 11,
		11, 11, 11, 11, 11, 11, 11, 11, 11, 11,
		11, 11, 11, 11, 12, 12, 12, 12, 12, 12,
		12, 12, 12, 12, 12, 12, 12, 12, 12, 12,
		12, 12, 12, 12, 12, 12, 12, 12, 12, 12,
		12, 12, 12, 12, 12, 12, 13, 13, 13, 13,
		13, 13, 13, 13, 13, 13, 13, 13, 13, 13,
		13, 13, 13, 13, 13, 13, 13, 13, 13, 13,
		13, 13, 13, 13, 13, 13, 13, 13, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 14, 14, 14, 14, 14, 14, 14, 14,
		14, 14, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 15, 15, 15, 15,
		15, 15, 15, 15, 15, 15, 0, 0, 16, 17,
		18, 18, 19, 19, 20, 20, 20, 20, 21, 21,
		21, 21, 22, 22, 22, 22, 22, 22, 22, 22,
		23, 23, 23, 23, 23, 23, 23, 23, 24, 24,
		24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
		24, 24, 24, 24, 25, 25, 25, 25, 25, 25,
		25, 25, 25, 25, 25, 25, 25, 25, 25, 25,
		26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 27, 27, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 28, 28,
		28, 28, 28, 28, 28, 28, 28, 28, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29, 29, 29, 29, 29, 29, 29, 29, 29,
		29, 29
	};

	internal static readonly sbyte[] sbyte_2 = new sbyte[256]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 8,
		9, 9, 10, 10, 11, 11, 12, 12, 12, 12,
		13, 13, 13, 13, 14, 14, 14, 14, 15, 15,
		15, 15, 16, 16, 16, 16, 16, 16, 16, 16,
		17, 17, 17, 17, 17, 17, 17, 17, 18, 18,
		18, 18, 18, 18, 18, 18, 19, 19, 19, 19,
		19, 19, 19, 19, 20, 20, 20, 20, 20, 20,
		20, 20, 20, 20, 20, 20, 20, 20, 20, 20,
		21, 21, 21, 21, 21, 21, 21, 21, 21, 21,
		21, 21, 21, 21, 21, 21, 22, 22, 22, 22,
		22, 22, 22, 22, 22, 22, 22, 22, 22, 22,
		22, 22, 23, 23, 23, 23, 23, 23, 23, 23,
		23, 23, 23, 23, 23, 23, 23, 23, 24, 24,
		24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
		24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
		24, 24, 24, 24, 24, 24, 24, 24, 24, 24,
		25, 25, 25, 25, 25, 25, 25, 25, 25, 25,
		25, 25, 25, 25, 25, 25, 25, 25, 25, 25,
		25, 25, 25, 25, 25, 25, 25, 25, 25, 25,
		25, 25, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 26, 26, 26, 26, 26, 26, 26, 26,
		26, 26, 26, 26, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 27, 27, 27, 27, 27, 27,
		27, 27, 27, 27, 27, 28
	};

	internal static readonly int[] int_16 = new int[29]
	{
		0, 1, 2, 3, 4, 5, 6, 7, 8, 10,
		12, 14, 16, 20, 24, 28, 32, 40, 48, 56,
		64, 80, 96, 112, 128, 160, 192, 224, 0
	};

	internal static readonly int[] int_17 = new int[30]
	{
		0, 1, 2, 3, 4, 6, 8, 12, 16, 24,
		32, 48, 64, 96, 128, 192, 256, 384, 512, 768,
		1024, 1536, 2048, 3072, 4096, 6144, 8192, 12288, 16384, 24576
	};

	internal short[] short_0;

	internal int int_18;

	internal Class6754 class6754_0;

	internal static int smethod_0(int dist)
	{
		if (dist >= 256)
		{
			return sbyte_1[256 + Class6753.smethod_0(dist, 7)];
		}
		return sbyte_1[dist];
	}

	internal void method_0(Class6741 s)
	{
		short[] array = short_0;
		short[] short_ = class6754_0.short_2;
		int[] array2 = class6754_0.int_7;
		int num = class6754_0.int_8;
		int num2 = class6754_0.int_10;
		int num3 = 0;
		for (int i = 0; i <= 15; i++)
		{
			s.short_5[i] = 0;
		}
		array[s.int_49[s.int_51] * 2 + 1] = 0;
		int j;
		for (j = s.int_51 + 1; j < 573; j++)
		{
			int num4 = s.int_49[j];
			int i = array[array[num4 * 2 + 1] * 2 + 1] + 1;
			if (i > num2)
			{
				i = num2;
				num3++;
			}
			array[num4 * 2 + 1] = (short)i;
			if (num4 <= int_18)
			{
				s.short_5[i]++;
				int num5 = 0;
				if (num4 >= num)
				{
					num5 = array2[num4 - num];
				}
				short num6 = array[num4 * 2];
				s.int_56 += num6 * (i + num5);
				if (short_ != null)
				{
					s.int_57 += num6 * (short_[num4 * 2 + 1] + num5);
				}
			}
		}
		if (num3 == 0)
		{
			return;
		}
		do
		{
			int i = num2 - 1;
			while (s.short_5[i] == 0)
			{
				i--;
			}
			s.short_5[i]--;
			s.short_5[i + 1] = (short)(s.short_5[i + 1] + 2);
			s.short_5[num2]--;
			num3 -= 2;
		}
		while (num3 > 0);
		for (int i = num2; i != 0; i--)
		{
			int num4 = s.short_5[i];
			while (num4 != 0)
			{
				int num7 = s.int_49[--j];
				if (num7 <= int_18)
				{
					if (array[num7 * 2 + 1] != i)
					{
						s.int_56 = (int)(s.int_56 + ((long)i - (long)array[num7 * 2 + 1]) * array[num7 * 2]);
						array[num7 * 2 + 1] = (short)i;
					}
					num4--;
				}
			}
		}
	}

	internal void method_1(Class6741 s)
	{
		short[] array = short_0;
		short[] short_ = class6754_0.short_2;
		int num = class6754_0.int_9;
		int num2 = -1;
		s.int_50 = 0;
		s.int_51 = 573;
		for (int i = 0; i < num; i++)
		{
			if (array[i * 2] != 0)
			{
				num2 = (s.int_49[++s.int_50] = i);
				s.sbyte_1[i] = 0;
			}
			else
			{
				array[i * 2 + 1] = 0;
			}
		}
		int num3;
		while (s.int_50 < 2)
		{
			num3 = (s.int_49[++s.int_50] = ((num2 < 2) ? (++num2) : 0));
			array[num3 * 2] = 1;
			s.sbyte_1[num3] = 0;
			s.int_56--;
			if (short_ != null)
			{
				s.int_57 -= short_[num3 * 2 + 1];
			}
		}
		int_18 = num2;
		for (int i = s.int_50 / 2; i >= 1; i--)
		{
			s.method_3(array, i);
		}
		num3 = num;
		do
		{
			int i = s.int_49[1];
			s.int_49[1] = s.int_49[s.int_50--];
			s.method_3(array, 1);
			int num4 = s.int_49[1];
			s.int_49[--s.int_51] = i;
			s.int_49[--s.int_51] = num4;
			array[num3 * 2] = (short)(array[i * 2] + array[num4 * 2]);
			s.sbyte_1[num3] = (sbyte)(Math.Max((byte)s.sbyte_1[i], (byte)s.sbyte_1[num4]) + 1);
			array[i * 2 + 1] = (array[num4 * 2 + 1] = (short)num3);
			s.int_49[1] = num3++;
			s.method_3(array, 1);
		}
		while (s.int_50 >= 2);
		s.int_49[--s.int_51] = s.int_49[1];
		method_0(s);
		smethod_1(array, num2, s.short_5);
	}

	internal static void smethod_1(short[] tree, int max_code, short[] bl_count)
	{
		short[] array = new short[16];
		short num = 0;
		for (int i = 1; i <= 15; i++)
		{
			num = (array[i] = (short)(num + bl_count[i - 1] << 1));
		}
		for (int j = 0; j <= max_code; j++)
		{
			int num2 = tree[j * 2 + 1];
			if (num2 != 0)
			{
				tree[j * 2] = (short)smethod_2(array[num2]++, num2);
			}
		}
	}

	internal static int smethod_2(int code, int len)
	{
		int num = 0;
		do
		{
			num |= code & 1;
			code = Class6753.smethod_0(code, 1);
			num <<= 1;
		}
		while (--len > 0);
		return Class6753.smethod_0(num, 1);
	}
}
