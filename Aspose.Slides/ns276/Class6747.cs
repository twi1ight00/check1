using System;

namespace ns276;

internal sealed class Class6747
{
	private const int int_0 = 1440;

	private const int int_1 = 0;

	private const int int_2 = 1;

	private const int int_3 = 2;

	private const int int_4 = -1;

	private const int int_5 = -2;

	private const int int_6 = -3;

	private const int int_7 = -4;

	private const int int_8 = -5;

	private const int int_9 = -6;

	internal const int int_10 = 9;

	internal const int int_11 = 5;

	internal const int int_12 = 15;

	internal static readonly int[] int_13 = new int[1536]
	{
		96, 7, 256, 0, 8, 80, 0, 8, 16, 84,
		8, 115, 82, 7, 31, 0, 8, 112, 0, 8,
		48, 0, 9, 192, 80, 7, 10, 0, 8, 96,
		0, 8, 32, 0, 9, 160, 0, 8, 0, 0,
		8, 128, 0, 8, 64, 0, 9, 224, 80, 7,
		6, 0, 8, 88, 0, 8, 24, 0, 9, 144,
		83, 7, 59, 0, 8, 120, 0, 8, 56, 0,
		9, 208, 81, 7, 17, 0, 8, 104, 0, 8,
		40, 0, 9, 176, 0, 8, 8, 0, 8, 136,
		0, 8, 72, 0, 9, 240, 80, 7, 4, 0,
		8, 84, 0, 8, 20, 85, 8, 227, 83, 7,
		43, 0, 8, 116, 0, 8, 52, 0, 9, 200,
		81, 7, 13, 0, 8, 100, 0, 8, 36, 0,
		9, 168, 0, 8, 4, 0, 8, 132, 0, 8,
		68, 0, 9, 232, 80, 7, 8, 0, 8, 92,
		0, 8, 28, 0, 9, 152, 84, 7, 83, 0,
		8, 124, 0, 8, 60, 0, 9, 216, 82, 7,
		23, 0, 8, 108, 0, 8, 44, 0, 9, 184,
		0, 8, 12, 0, 8, 140, 0, 8, 76, 0,
		9, 248, 80, 7, 3, 0, 8, 82, 0, 8,
		18, 85, 8, 163, 83, 7, 35, 0, 8, 114,
		0, 8, 50, 0, 9, 196, 81, 7, 11, 0,
		8, 98, 0, 8, 34, 0, 9, 164, 0, 8,
		2, 0, 8, 130, 0, 8, 66, 0, 9, 228,
		80, 7, 7, 0, 8, 90, 0, 8, 26, 0,
		9, 148, 84, 7, 67, 0, 8, 122, 0, 8,
		58, 0, 9, 212, 82, 7, 19, 0, 8, 106,
		0, 8, 42, 0, 9, 180, 0, 8, 10, 0,
		8, 138, 0, 8, 74, 0, 9, 244, 80, 7,
		5, 0, 8, 86, 0, 8, 22, 192, 8, 0,
		83, 7, 51, 0, 8, 118, 0, 8, 54, 0,
		9, 204, 81, 7, 15, 0, 8, 102, 0, 8,
		38, 0, 9, 172, 0, 8, 6, 0, 8, 134,
		0, 8, 70, 0, 9, 236, 80, 7, 9, 0,
		8, 94, 0, 8, 30, 0, 9, 156, 84, 7,
		99, 0, 8, 126, 0, 8, 62, 0, 9, 220,
		82, 7, 27, 0, 8, 110, 0, 8, 46, 0,
		9, 188, 0, 8, 14, 0, 8, 142, 0, 8,
		78, 0, 9, 252, 96, 7, 256, 0, 8, 81,
		0, 8, 17, 85, 8, 131, 82, 7, 31, 0,
		8, 113, 0, 8, 49, 0, 9, 194, 80, 7,
		10, 0, 8, 97, 0, 8, 33, 0, 9, 162,
		0, 8, 1, 0, 8, 129, 0, 8, 65, 0,
		9, 226, 80, 7, 6, 0, 8, 89, 0, 8,
		25, 0, 9, 146, 83, 7, 59, 0, 8, 121,
		0, 8, 57, 0, 9, 210, 81, 7, 17, 0,
		8, 105, 0, 8, 41, 0, 9, 178, 0, 8,
		9, 0, 8, 137, 0, 8, 73, 0, 9, 242,
		80, 7, 4, 0, 8, 85, 0, 8, 21, 80,
		8, 258, 83, 7, 43, 0, 8, 117, 0, 8,
		53, 0, 9, 202, 81, 7, 13, 0, 8, 101,
		0, 8, 37, 0, 9, 170, 0, 8, 5, 0,
		8, 133, 0, 8, 69, 0, 9, 234, 80, 7,
		8, 0, 8, 93, 0, 8, 29, 0, 9, 154,
		84, 7, 83, 0, 8, 125, 0, 8, 61, 0,
		9, 218, 82, 7, 23, 0, 8, 109, 0, 8,
		45, 0, 9, 186, 0, 8, 13, 0, 8, 141,
		0, 8, 77, 0, 9, 250, 80, 7, 3, 0,
		8, 83, 0, 8, 19, 85, 8, 195, 83, 7,
		35, 0, 8, 115, 0, 8, 51, 0, 9, 198,
		81, 7, 11, 0, 8, 99, 0, 8, 35, 0,
		9, 166, 0, 8, 3, 0, 8, 131, 0, 8,
		67, 0, 9, 230, 80, 7, 7, 0, 8, 91,
		0, 8, 27, 0, 9, 150, 84, 7, 67, 0,
		8, 123, 0, 8, 59, 0, 9, 214, 82, 7,
		19, 0, 8, 107, 0, 8, 43, 0, 9, 182,
		0, 8, 11, 0, 8, 139, 0, 8, 75, 0,
		9, 246, 80, 7, 5, 0, 8, 87, 0, 8,
		23, 192, 8, 0, 83, 7, 51, 0, 8, 119,
		0, 8, 55, 0, 9, 206, 81, 7, 15, 0,
		8, 103, 0, 8, 39, 0, 9, 174, 0, 8,
		7, 0, 8, 135, 0, 8, 71, 0, 9, 238,
		80, 7, 9, 0, 8, 95, 0, 8, 31, 0,
		9, 158, 84, 7, 99, 0, 8, 127, 0, 8,
		63, 0, 9, 222, 82, 7, 27, 0, 8, 111,
		0, 8, 47, 0, 9, 190, 0, 8, 15, 0,
		8, 143, 0, 8, 79, 0, 9, 254, 96, 7,
		256, 0, 8, 80, 0, 8, 16, 84, 8, 115,
		82, 7, 31, 0, 8, 112, 0, 8, 48, 0,
		9, 193, 80, 7, 10, 0, 8, 96, 0, 8,
		32, 0, 9, 161, 0, 8, 0, 0, 8, 128,
		0, 8, 64, 0, 9, 225, 80, 7, 6, 0,
		8, 88, 0, 8, 24, 0, 9, 145, 83, 7,
		59, 0, 8, 120, 0, 8, 56, 0, 9, 209,
		81, 7, 17, 0, 8, 104, 0, 8, 40, 0,
		9, 177, 0, 8, 8, 0, 8, 136, 0, 8,
		72, 0, 9, 241, 80, 7, 4, 0, 8, 84,
		0, 8, 20, 85, 8, 227, 83, 7, 43, 0,
		8, 116, 0, 8, 52, 0, 9, 201, 81, 7,
		13, 0, 8, 100, 0, 8, 36, 0, 9, 169,
		0, 8, 4, 0, 8, 132, 0, 8, 68, 0,
		9, 233, 80, 7, 8, 0, 8, 92, 0, 8,
		28, 0, 9, 153, 84, 7, 83, 0, 8, 124,
		0, 8, 60, 0, 9, 217, 82, 7, 23, 0,
		8, 108, 0, 8, 44, 0, 9, 185, 0, 8,
		12, 0, 8, 140, 0, 8, 76, 0, 9, 249,
		80, 7, 3, 0, 8, 82, 0, 8, 18, 85,
		8, 163, 83, 7, 35, 0, 8, 114, 0, 8,
		50, 0, 9, 197, 81, 7, 11, 0, 8, 98,
		0, 8, 34, 0, 9, 165, 0, 8, 2, 0,
		8, 130, 0, 8, 66, 0, 9, 229, 80, 7,
		7, 0, 8, 90, 0, 8, 26, 0, 9, 149,
		84, 7, 67, 0, 8, 122, 0, 8, 58, 0,
		9, 213, 82, 7, 19, 0, 8, 106, 0, 8,
		42, 0, 9, 181, 0, 8, 10, 0, 8, 138,
		0, 8, 74, 0, 9, 245, 80, 7, 5, 0,
		8, 86, 0, 8, 22, 192, 8, 0, 83, 7,
		51, 0, 8, 118, 0, 8, 54, 0, 9, 205,
		81, 7, 15, 0, 8, 102, 0, 8, 38, 0,
		9, 173, 0, 8, 6, 0, 8, 134, 0, 8,
		70, 0, 9, 237, 80, 7, 9, 0, 8, 94,
		0, 8, 30, 0, 9, 157, 84, 7, 99, 0,
		8, 126, 0, 8, 62, 0, 9, 221, 82, 7,
		27, 0, 8, 110, 0, 8, 46, 0, 9, 189,
		0, 8, 14, 0, 8, 142, 0, 8, 78, 0,
		9, 253, 96, 7, 256, 0, 8, 81, 0, 8,
		17, 85, 8, 131, 82, 7, 31, 0, 8, 113,
		0, 8, 49, 0, 9, 195, 80, 7, 10, 0,
		8, 97, 0, 8, 33, 0, 9, 163, 0, 8,
		1, 0, 8, 129, 0, 8, 65, 0, 9, 227,
		80, 7, 6, 0, 8, 89, 0, 8, 25, 0,
		9, 147, 83, 7, 59, 0, 8, 121, 0, 8,
		57, 0, 9, 211, 81, 7, 17, 0, 8, 105,
		0, 8, 41, 0, 9, 179, 0, 8, 9, 0,
		8, 137, 0, 8, 73, 0, 9, 243, 80, 7,
		4, 0, 8, 85, 0, 8, 21, 80, 8, 258,
		83, 7, 43, 0, 8, 117, 0, 8, 53, 0,
		9, 203, 81, 7, 13, 0, 8, 101, 0, 8,
		37, 0, 9, 171, 0, 8, 5, 0, 8, 133,
		0, 8, 69, 0, 9, 235, 80, 7, 8, 0,
		8, 93, 0, 8, 29, 0, 9, 155, 84, 7,
		83, 0, 8, 125, 0, 8, 61, 0, 9, 219,
		82, 7, 23, 0, 8, 109, 0, 8, 45, 0,
		9, 187, 0, 8, 13, 0, 8, 141, 0, 8,
		77, 0, 9, 251, 80, 7, 3, 0, 8, 83,
		0, 8, 19, 85, 8, 195, 83, 7, 35, 0,
		8, 115, 0, 8, 51, 0, 9, 199, 81, 7,
		11, 0, 8, 99, 0, 8, 35, 0, 9, 167,
		0, 8, 3, 0, 8, 131, 0, 8, 67, 0,
		9, 231, 80, 7, 7, 0, 8, 91, 0, 8,
		27, 0, 9, 151, 84, 7, 67, 0, 8, 123,
		0, 8, 59, 0, 9, 215, 82, 7, 19, 0,
		8, 107, 0, 8, 43, 0, 9, 183, 0, 8,
		11, 0, 8, 139, 0, 8, 75, 0, 9, 247,
		80, 7, 5, 0, 8, 87, 0, 8, 23, 192,
		8, 0, 83, 7, 51, 0, 8, 119, 0, 8,
		55, 0, 9, 207, 81, 7, 15, 0, 8, 103,
		0, 8, 39, 0, 9, 175, 0, 8, 7, 0,
		8, 135, 0, 8, 71, 0, 9, 239, 80, 7,
		9, 0, 8, 95, 0, 8, 31, 0, 9, 159,
		84, 7, 99, 0, 8, 127, 0, 8, 63, 0,
		9, 223, 82, 7, 27, 0, 8, 111, 0, 8,
		47, 0, 9, 191, 0, 8, 15, 0, 8, 143,
		0, 8, 79, 0, 9, 255
	};

	internal static readonly int[] int_14 = new int[96]
	{
		80, 5, 1, 87, 5, 257, 83, 5, 17, 91,
		5, 4097, 81, 5, 5, 89, 5, 1025, 85, 5,
		65, 93, 5, 16385, 80, 5, 3, 88, 5, 513,
		84, 5, 33, 92, 5, 8193, 82, 5, 9, 90,
		5, 2049, 86, 5, 129, 192, 5, 24577, 80, 5,
		2, 87, 5, 385, 83, 5, 25, 91, 5, 6145,
		81, 5, 7, 89, 5, 1537, 85, 5, 97, 93,
		5, 24577, 80, 5, 4, 88, 5, 769, 84, 5,
		49, 92, 5, 12289, 82, 5, 13, 90, 5, 3073,
		86, 5, 193, 192, 5, 24577
	};

	internal static readonly int[] int_15 = new int[31]
	{
		3, 4, 5, 6, 7, 8, 9, 10, 11, 13,
		15, 17, 19, 23, 27, 31, 35, 43, 51, 59,
		67, 83, 99, 115, 131, 163, 195, 227, 258, 0,
		0
	};

	internal static readonly int[] int_16 = new int[31]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
		1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
		4, 4, 4, 4, 5, 5, 5, 5, 0, 112,
		112
	};

	internal static readonly int[] int_17 = new int[30]
	{
		1, 2, 3, 4, 5, 7, 9, 13, 17, 25,
		33, 49, 65, 97, 129, 193, 257, 385, 513, 769,
		1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577
	};

	internal static readonly int[] int_18 = new int[30]
	{
		0, 0, 0, 0, 1, 1, 2, 2, 3, 3,
		4, 4, 5, 5, 6, 6, 7, 7, 8, 8,
		9, 9, 10, 10, 11, 11, 12, 12, 13, 13
	};

	internal int[] int_19;

	internal int[] int_20;

	internal int[] int_21;

	internal int[] int_22;

	internal int[] int_23;

	internal int[] int_24;

	private int method_0(int[] b, int bindex, int n, int s, int[] d, int[] e, int[] t, int[] m, int[] hp, int[] hn, int[] v)
	{
		int num = 0;
		int num2 = n;
		do
		{
			int_21[b[bindex + num]]++;
			num++;
			num2--;
		}
		while (num2 != 0);
		if (int_21[0] == n)
		{
			t[0] = -1;
			m[0] = 0;
			return 0;
		}
		int num3 = m[0];
		int i;
		for (i = 1; i <= 15 && int_21[i] == 0; i++)
		{
		}
		int j = i;
		if (num3 < i)
		{
			num3 = i;
		}
		num2 = 15;
		while (num2 != 0 && int_21[num2] == 0)
		{
			num2--;
		}
		int num4 = num2;
		if (num3 > num2)
		{
			num3 = num2;
		}
		m[0] = num3;
		int num5 = 1 << i;
		while (true)
		{
			if (i < num2)
			{
				if ((num5 -= int_21[i]) < 0)
				{
					break;
				}
				i++;
				num5 <<= 1;
				continue;
			}
			if ((num5 -= int_21[num2]) < 0)
			{
				return -3;
			}
			int_21[num2] += num5;
			int[] array = int_24;
			i = 0;
			array[1] = 0;
			num = 1;
			int num6 = 2;
			while (--num2 != 0)
			{
				i = (int_24[num6] = i + int_21[num]);
				num6++;
				num++;
			}
			num2 = 0;
			num = 0;
			do
			{
				if ((i = b[bindex + num]) != 0)
				{
					v[int_24[i]++] = num2;
				}
				num++;
			}
			while (++num2 < n);
			n = int_24[num4];
			int[] array2 = int_24;
			num2 = 0;
			array2[0] = 0;
			num = 0;
			int num7 = -1;
			int num8 = -num3;
			int_23[0] = 0;
			int num9 = 0;
			int num10 = 0;
			for (; j <= num4; j++)
			{
				int num11 = int_21[j];
				while (num11-- != 0)
				{
					int num12;
					while (j > num8 + num3)
					{
						num7++;
						num8 += num3;
						num10 = num4 - num8;
						num10 = ((num10 > num3) ? num3 : num10);
						if ((num12 = 1 << (i = j - num8)) > num11 + 1)
						{
							num12 -= num11 + 1;
							num6 = j;
							if (i < num10)
							{
								while (++i < num10 && (num12 <<= 1) > int_21[++num6])
								{
									num12 -= int_21[num6];
								}
							}
						}
						num10 = 1 << i;
						if (hn[0] + num10 > 1440)
						{
							return -3;
						}
						num9 = (int_23[num7] = hn[0]);
						hn[0] += num10;
						if (num7 != 0)
						{
							int_24[num7] = num2;
							int_22[0] = (sbyte)i;
							int_22[1] = (sbyte)num3;
							i = Class6753.smethod_0(num2, num8 - num3);
							int_22[2] = num9 - int_23[num7 - 1] - i;
							Array.Copy(int_22, 0, hp, (int_23[num7 - 1] + i) * 3, 3);
						}
						else
						{
							t[0] = num9;
						}
					}
					int_22[1] = (sbyte)(j - num8);
					if (num >= n)
					{
						int_22[0] = 192;
					}
					else if (v[num] < s)
					{
						int_22[0] = (sbyte)((v[num] >= 256) ? 96 : 0);
						int_22[2] = v[num++];
					}
					else
					{
						int_22[0] = (sbyte)(e[v[num] - s] + 16 + 64);
						int_22[2] = d[v[num++] - s];
					}
					num12 = 1 << j - num8;
					for (i = Class6753.smethod_0(num2, num8); i < num10; i += num12)
					{
						Array.Copy(int_22, 0, hp, (num9 + i) * 3, 3);
					}
					i = 1 << j - 1;
					while ((num2 & i) != 0)
					{
						num2 ^= i;
						i = Class6753.smethod_0(i, 1);
					}
					num2 ^= i;
					int num13 = (1 << num8) - 1;
					while ((num2 & num13) != int_24[num7])
					{
						num7--;
						num8 -= num3;
						num13 = (1 << num8) - 1;
					}
				}
			}
			if (num5 != 0 && num4 != 1)
			{
				return -5;
			}
			return 0;
		}
		return -3;
	}

	internal int method_1(int[] c, int[] bb, int[] tb, int[] hp, Class6756 z)
	{
		method_3(19);
		int_19[0] = 0;
		int num = method_0(c, 0, 19, 19, null, null, tb, bb, hp, int_19, int_20);
		if (num == -3)
		{
			z.string_0 = "oversubscribed dynamic bit lengths tree";
		}
		else if (num == -5 || bb[0] == 0)
		{
			z.string_0 = "incomplete dynamic bit lengths tree";
			num = -3;
		}
		return num;
	}

	internal int method_2(int nl, int nd, int[] c, int[] bl, int[] bd, int[] tl, int[] td, int[] hp, Class6756 z)
	{
		method_3(288);
		int_19[0] = 0;
		int num = method_0(c, 0, nl, 257, int_15, int_16, tl, bl, hp, int_19, int_20);
		if (num == 0 && bl[0] != 0)
		{
			method_3(288);
			num = method_0(c, nl, nd, 0, int_17, int_18, td, bd, hp, int_19, int_20);
			if (num == 0 && (bd[0] != 0 || nl <= 257))
			{
				return 0;
			}
			switch (num)
			{
			case -3:
				z.string_0 = "oversubscribed distance tree";
				break;
			case -5:
				z.string_0 = "incomplete distance tree";
				num = -3;
				break;
			default:
				z.string_0 = "empty distance tree with lengths";
				num = -3;
				break;
			case -4:
				break;
			}
			return num;
		}
		switch (num)
		{
		case -3:
			z.string_0 = "oversubscribed literal/length tree";
			break;
		default:
			z.string_0 = "incomplete literal/length tree";
			num = -3;
			break;
		case -4:
			break;
		}
		return num;
	}

	internal static int smethod_0(int[] bl, int[] bd, int[][] tl, int[][] td, Class6756 z)
	{
		bl[0] = 9;
		bd[0] = 5;
		tl[0] = int_13;
		td[0] = int_14;
		return 0;
	}

	private void method_3(int vsize)
	{
		if (int_19 == null)
		{
			int_19 = new int[1];
			int_20 = new int[vsize];
			int_21 = new int[16];
			int_22 = new int[3];
			int_23 = new int[15];
			int_24 = new int[16];
		}
		if (int_20.Length < vsize)
		{
			int_20 = new int[vsize];
		}
		for (int i = 0; i < vsize; i++)
		{
			int_20[i] = 0;
		}
		for (int j = 0; j < 16; j++)
		{
			int_21[j] = 0;
		}
		for (int k = 0; k < 3; k++)
		{
			int_22[k] = 0;
		}
		Array.Copy(int_21, 0, int_23, 0, 15);
		Array.Copy(int_21, 0, int_24, 0, 16);
	}
}
