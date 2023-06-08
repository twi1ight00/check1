using System;

namespace ns276;

internal sealed class Class6744
{
	private const int int_0 = 1440;

	private const int int_1 = 0;

	private const int int_2 = 1;

	private const int int_3 = 2;

	private const int int_4 = 3;

	private const int int_5 = 4;

	private const int int_6 = 5;

	private const int int_7 = 6;

	private const int int_8 = 7;

	private const int int_9 = 8;

	private const int int_10 = 9;

	private static readonly int[] int_11 = new int[17]
	{
		0, 1, 3, 7, 15, 31, 63, 127, 255, 511,
		1023, 2047, 4095, 8191, 16383, 32767, 65535
	};

	internal static readonly int[] int_12 = new int[19]
	{
		16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
		11, 4, 12, 3, 13, 2, 14, 1, 15
	};

	internal int int_13;

	internal int int_14;

	internal int int_15;

	internal int int_16;

	internal int[] int_17;

	internal int[] int_18 = new int[1];

	internal int[] int_19 = new int[1];

	internal Class6745 class6745_0 = new Class6745();

	internal int int_20;

	internal Class6756 class6756_0;

	internal int int_21;

	internal int int_22;

	internal int[] int_23;

	internal byte[] byte_0;

	internal int int_24;

	internal int int_25;

	internal int int_26;

	internal object object_0;

	internal long long_0;

	internal Class6747 class6747_0 = new Class6747();

	internal Class6744(Class6756 codec, object checkfn, int w)
	{
		class6756_0 = codec;
		int_23 = new int[4320];
		byte_0 = new byte[w];
		int_24 = w;
		object_0 = checkfn;
		int_13 = 0;
		Reset(null);
	}

	internal void Reset(long[] c)
	{
		if (c != null)
		{
			c[0] = long_0;
		}
		if (int_13 != 4)
		{
		}
		int_13 = 0;
		int_21 = 0;
		int_22 = 0;
		int_26 = 0;
		int_25 = 0;
		if (object_0 != null)
		{
			class6756_0.long_2 = (long_0 = Class6755.smethod_0(0L, null, 0, 0));
		}
	}

	internal int method_0(int r)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		num4 = class6756_0.int_0;
		num5 = class6756_0.int_1;
		num2 = int_22;
		num3 = int_21;
		num6 = int_26;
		num7 = ((num6 < int_25) ? (int_25 - num6 - 1) : (int_24 - num6));
		while (true)
		{
			switch (int_13)
			{
			case 6:
				int_22 = num2;
				int_21 = num3;
				class6756_0.int_1 = num5;
				class6756_0.long_0 += num4 - class6756_0.int_0;
				class6756_0.int_0 = num4;
				int_26 = num6;
				if ((r = class6745_0.method_1(this, r)) == 1)
				{
					r = 0;
					num4 = class6756_0.int_0;
					num5 = class6756_0.int_1;
					num2 = int_22;
					num3 = int_21;
					num6 = int_26;
					num7 = ((num6 < int_25) ? (int_25 - num6 - 1) : (int_24 - num6));
					if (int_20 == 0)
					{
						int_13 = 0;
						break;
					}
					int_13 = 7;
					goto case 7;
				}
				return Flush(r);
			case 5:
			{
				while (true)
				{
					num = int_15;
					if (int_16 >= 258 + (num & 0x1F) + ((num >> 5) & 0x1F))
					{
						break;
					}
					for (num = int_18[0]; num3 < num; num3 += 8)
					{
						if (num5 != 0)
						{
							r = 0;
							num5--;
							num2 |= (class6756_0.byte_0[num4++] & 0xFF) << num3;
							continue;
						}
						int_22 = num2;
						int_21 = num3;
						class6756_0.int_1 = num5;
						class6756_0.long_0 += num4 - class6756_0.int_0;
						class6756_0.int_0 = num4;
						int_26 = num6;
						return Flush(r);
					}
					num = int_23[(int_19[0] + (num2 & int_11[num])) * 3 + 1];
					int num8 = int_23[(int_19[0] + (num2 & int_11[num])) * 3 + 2];
					if (num8 < 16)
					{
						num2 = Class6753.smethod_0(num2, num);
						num3 -= num;
						int_17[int_16++] = num8;
						continue;
					}
					int num9 = ((num8 == 18) ? 7 : (num8 - 14));
					int num10 = ((num8 == 18) ? 11 : 3);
					for (; num3 < num + num9; num3 += 8)
					{
						if (num5 != 0)
						{
							r = 0;
							num5--;
							num2 |= (class6756_0.byte_0[num4++] & 0xFF) << num3;
							continue;
						}
						int_22 = num2;
						int_21 = num3;
						class6756_0.int_1 = num5;
						class6756_0.long_0 += num4 - class6756_0.int_0;
						class6756_0.int_0 = num4;
						int_26 = num6;
						return Flush(r);
					}
					num2 = Class6753.smethod_0(num2, num);
					num3 -= num;
					num10 += num2 & int_11[num9];
					num2 = Class6753.smethod_0(num2, num9);
					num3 -= num9;
					num9 = int_16;
					num = int_15;
					if (num9 + num10 <= 258 + (num & 0x1F) + ((num >> 5) & 0x1F) && (num8 != 16 || num9 >= 1))
					{
						num8 = ((num8 == 16) ? int_17[num9 - 1] : 0);
						do
						{
							int_17[num9++] = num8;
						}
						while (--num10 != 0);
						int_16 = num9;
						continue;
					}
					int_17 = null;
					int_13 = 9;
					class6756_0.string_0 = "invalid bit length repeat";
					r = -3;
					int_22 = num2;
					int_21 = num3;
					class6756_0.int_1 = num5;
					class6756_0.long_0 += num4 - class6756_0.int_0;
					class6756_0.int_0 = num4;
					int_26 = num6;
					return Flush(-3);
				}
				int_19[0] = -1;
				int[] array5 = new int[1] { 9 };
				int[] array6 = new int[1] { 6 };
				int[] array7 = new int[1];
				int[] array8 = new int[1];
				num = int_15;
				num = class6747_0.method_2(257 + (num & 0x1F), 1 + ((num >> 5) & 0x1F), int_17, array5, array6, array7, array8, int_23, class6756_0);
				if (num == 0)
				{
					class6745_0.method_0(array5[0], array6[0], int_23, array7[0], int_23, array8[0]);
					int_13 = 6;
					goto case 6;
				}
				if (num == -3)
				{
					int_17 = null;
					int_13 = 9;
				}
				r = num;
				int_22 = num2;
				int_21 = num3;
				class6756_0.int_1 = num5;
				class6756_0.long_0 += num4 - class6756_0.int_0;
				class6756_0.int_0 = num4;
				int_26 = num6;
				return Flush(r);
			}
			case 4:
				while (int_16 < 4 + Class6753.smethod_0(int_15, 10))
				{
					for (; num3 < 3; num3 += 8)
					{
						if (num5 != 0)
						{
							r = 0;
							num5--;
							num2 |= (class6756_0.byte_0[num4++] & 0xFF) << num3;
							continue;
						}
						int_22 = num2;
						int_21 = num3;
						class6756_0.int_1 = num5;
						class6756_0.long_0 += num4 - class6756_0.int_0;
						class6756_0.int_0 = num4;
						int_26 = num6;
						return Flush(r);
					}
					int_17[int_12[int_16++]] = num2 & 7;
					num2 = Class6753.smethod_0(num2, 3);
					num3 -= 3;
				}
				while (int_16 < 19)
				{
					int_17[int_12[int_16++]] = 0;
				}
				int_18[0] = 7;
				num = class6747_0.method_1(int_17, int_18, int_19, int_23, class6756_0);
				if (num == 0)
				{
					int_16 = 0;
					int_13 = 5;
					goto case 5;
				}
				r = num;
				if (r == -3)
				{
					int_17 = null;
					int_13 = 9;
				}
				int_22 = num2;
				int_21 = num3;
				class6756_0.int_1 = num5;
				class6756_0.long_0 += num4 - class6756_0.int_0;
				class6756_0.int_0 = num4;
				int_26 = num6;
				return Flush(r);
			case 3:
				for (; num3 < 14; num3 += 8)
				{
					if (num5 != 0)
					{
						r = 0;
						num5--;
						num2 |= (class6756_0.byte_0[num4++] & 0xFF) << num3;
						continue;
					}
					int_22 = num2;
					int_21 = num3;
					class6756_0.int_1 = num5;
					class6756_0.long_0 += num4 - class6756_0.int_0;
					class6756_0.int_0 = num4;
					int_26 = num6;
					return Flush(r);
				}
				num = (int_15 = num2 & 0x3FFF);
				if ((num & 0x1F) <= 29 && ((num >> 5) & 0x1F) <= 29)
				{
					num = 258 + (num & 0x1F) + ((num >> 5) & 0x1F);
					if (int_17 != null && int_17.Length >= num)
					{
						for (int i = 0; i < num; i++)
						{
							int_17[i] = 0;
						}
					}
					else
					{
						int_17 = new int[num];
					}
					num2 = Class6753.smethod_0(num2, 14);
					num3 -= 14;
					int_16 = 0;
					int_13 = 4;
					goto case 4;
				}
				int_13 = 9;
				class6756_0.string_0 = "too many length or distance symbols";
				r = -3;
				int_22 = num2;
				int_21 = num3;
				class6756_0.int_1 = num5;
				class6756_0.long_0 += num4 - class6756_0.int_0;
				class6756_0.int_0 = num4;
				int_26 = num6;
				return Flush(-3);
			case 2:
				if (num5 != 0)
				{
					if (num7 == 0)
					{
						if (num6 == int_24 && int_25 != 0)
						{
							num6 = 0;
							num7 = ((0 < int_25) ? (int_25 - num6 - 1) : (int_24 - num6));
						}
						if (num7 == 0)
						{
							int_26 = num6;
							r = Flush(r);
							num6 = int_26;
							num7 = ((num6 < int_25) ? (int_25 - num6 - 1) : (int_24 - num6));
							if (num6 == int_24 && int_25 != 0)
							{
								num6 = 0;
								num7 = ((0 < int_25) ? (int_25 - num6 - 1) : (int_24 - num6));
							}
							if (num7 == 0)
							{
								int_22 = num2;
								int_21 = num3;
								class6756_0.int_1 = num5;
								class6756_0.long_0 += num4 - class6756_0.int_0;
								class6756_0.int_0 = num4;
								int_26 = num6;
								return Flush(r);
							}
						}
					}
					r = 0;
					num = int_14;
					if (num > num5)
					{
						num = num5;
					}
					if (num > num7)
					{
						num = num7;
					}
					Array.Copy(class6756_0.byte_0, num4, byte_0, num6, num);
					num4 += num;
					num5 -= num;
					num6 += num;
					num7 -= num;
					if ((int_14 -= num) == 0)
					{
						int_13 = ((int_20 != 0) ? 7 : 0);
					}
					break;
				}
				int_22 = num2;
				int_21 = num3;
				class6756_0.int_1 = num5;
				class6756_0.long_0 += num4 - class6756_0.int_0;
				class6756_0.int_0 = num4;
				int_26 = num6;
				return Flush(r);
			case 1:
				for (; num3 < 32; num3 += 8)
				{
					if (num5 != 0)
					{
						r = 0;
						num5--;
						num2 |= (class6756_0.byte_0[num4++] & 0xFF) << num3;
						continue;
					}
					int_22 = num2;
					int_21 = num3;
					class6756_0.int_1 = num5;
					class6756_0.long_0 += num4 - class6756_0.int_0;
					class6756_0.int_0 = num4;
					int_26 = num6;
					return Flush(r);
				}
				if ((Class6753.smethod_0(~num2, 16) & 0xFFFF) == (num2 & 0xFFFF))
				{
					int_14 = num2 & 0xFFFF;
					num3 = 0;
					num2 = 0;
					int_13 = ((int_14 != 0) ? 2 : ((int_20 != 0) ? 7 : 0));
					break;
				}
				int_13 = 9;
				class6756_0.string_0 = "invalid stored block lengths";
				r = -3;
				int_22 = num2;
				int_21 = num3;
				class6756_0.int_1 = num5;
				class6756_0.long_0 += num4 - class6756_0.int_0;
				class6756_0.int_0 = num4;
				int_26 = num6;
				return Flush(-3);
			case 0:
				for (; num3 < 3; num3 += 8)
				{
					if (num5 != 0)
					{
						r = 0;
						num5--;
						num2 |= (class6756_0.byte_0[num4++] & 0xFF) << num3;
						continue;
					}
					int_22 = num2;
					int_21 = num3;
					class6756_0.int_1 = num5;
					class6756_0.long_0 += num4 - class6756_0.int_0;
					class6756_0.int_0 = num4;
					int_26 = num6;
					return Flush(r);
				}
				num = num2 & 7;
				int_20 = num & 1;
				switch (Class6753.smethod_0(num, 1))
				{
				case 0:
					num2 = Class6753.smethod_0(num2, 3);
					num3 -= 3;
					num = num3 & 7;
					num2 = Class6753.smethod_0(num2, num);
					num3 -= num;
					int_13 = 1;
					break;
				case 1:
				{
					int[] array = new int[1];
					int[] array2 = new int[1];
					int[][] array3 = new int[1][];
					int[][] array4 = new int[1][];
					Class6747.smethod_0(array, array2, array3, array4, class6756_0);
					class6745_0.method_0(array[0], array2[0], array3[0], 0, array4[0], 0);
					num2 = Class6753.smethod_0(num2, 3);
					num3 -= 3;
					int_13 = 6;
					break;
				}
				case 2:
					num2 = Class6753.smethod_0(num2, 3);
					num3 -= 3;
					int_13 = 3;
					break;
				case 3:
					num2 = Class6753.smethod_0(num2, 3);
					num3 -= 3;
					int_13 = 9;
					class6756_0.string_0 = "invalid block type";
					r = -3;
					int_22 = num2;
					int_21 = num3;
					class6756_0.int_1 = num5;
					class6756_0.long_0 += num4 - class6756_0.int_0;
					class6756_0.int_0 = num4;
					int_26 = num6;
					return Flush(-3);
				}
				break;
			default:
				r = -2;
				int_22 = num2;
				int_21 = num3;
				class6756_0.int_1 = num5;
				class6756_0.long_0 += num4 - class6756_0.int_0;
				class6756_0.int_0 = num4;
				int_26 = num6;
				return Flush(-2);
			case 7:
				int_26 = num6;
				r = Flush(r);
				num6 = int_26;
				num7 = ((num6 < int_25) ? (int_25 - num6 - 1) : (int_24 - num6));
				if (int_25 != int_26)
				{
					int_22 = num2;
					int_21 = num3;
					class6756_0.int_1 = num5;
					class6756_0.long_0 += num4 - class6756_0.int_0;
					class6756_0.int_0 = num4;
					int_26 = num6;
					return Flush(r);
				}
				int_13 = 8;
				goto case 8;
			case 8:
				r = 1;
				int_22 = num2;
				int_21 = num3;
				class6756_0.int_1 = num5;
				class6756_0.long_0 += num4 - class6756_0.int_0;
				class6756_0.int_0 = num4;
				int_26 = num6;
				return Flush(1);
			case 9:
				r = -3;
				int_22 = num2;
				int_21 = num3;
				class6756_0.int_1 = num5;
				class6756_0.long_0 += num4 - class6756_0.int_0;
				class6756_0.int_0 = num4;
				int_26 = num6;
				return Flush(-3);
			}
		}
	}

	internal void method_1()
	{
		Reset(null);
		byte_0 = null;
		int_23 = null;
	}

	internal void method_2(byte[] d, int start, int n)
	{
		Array.Copy(d, start, byte_0, 0, n);
		int_25 = (int_26 = n);
	}

	internal int method_3()
	{
		if (int_13 != 1)
		{
			return 0;
		}
		return 1;
	}

	internal int Flush(int r)
	{
		int num = class6756_0.int_2;
		int num2 = int_25;
		int num3 = ((num2 <= int_26) ? int_26 : int_24) - num2;
		if (num3 > class6756_0.int_3)
		{
			num3 = class6756_0.int_3;
		}
		if (r == -5)
		{
			r = 0;
		}
		class6756_0.int_3 -= num3;
		class6756_0.long_1 += num3;
		if (object_0 != null)
		{
			class6756_0.long_2 = (long_0 = Class6755.smethod_0(long_0, byte_0, num2, num3));
		}
		Array.Copy(byte_0, num2, class6756_0.byte_1, num, num3);
		num += num3;
		num2 += num3;
		if (num2 == int_24)
		{
			num2 = 0;
			if (int_26 == int_24)
			{
				int_26 = 0;
			}
			num3 = int_26 - num2;
			if (num3 > class6756_0.int_3)
			{
				num3 = class6756_0.int_3;
			}
			if (num3 != 0 && r == -5)
			{
				r = 0;
			}
			class6756_0.int_3 -= num3;
			class6756_0.long_1 += num3;
			if (object_0 != null)
			{
				class6756_0.long_2 = (long_0 = Class6755.smethod_0(long_0, byte_0, num2, num3));
			}
			Array.Copy(byte_0, num2, class6756_0.byte_1, num, num3);
			num += num3;
			num2 += num3;
		}
		class6756_0.int_2 = num;
		int_25 = num2;
		return r;
	}
}
