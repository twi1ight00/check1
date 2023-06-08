using System;

namespace ns276;

internal sealed class Class6745
{
	private const int int_0 = 0;

	private const int int_1 = 1;

	private const int int_2 = 2;

	private const int int_3 = 3;

	private const int int_4 = 4;

	private const int int_5 = 5;

	private const int int_6 = 6;

	private const int int_7 = 7;

	private const int int_8 = 8;

	private const int int_9 = 9;

	private static readonly int[] int_10 = new int[17]
	{
		0, 1, 3, 7, 15, 31, 63, 127, 255, 511,
		1023, 2047, 4095, 8191, 16383, 32767, 65535
	};

	internal int int_11;

	internal int int_12;

	internal int[] int_13;

	internal int int_14;

	internal int int_15;

	internal int int_16;

	internal int int_17;

	internal int int_18;

	internal byte byte_0;

	internal byte byte_1;

	internal int[] int_19;

	internal int int_20;

	internal int[] int_21;

	internal int int_22;

	internal Class6745()
	{
	}

	internal void method_0(int bl, int bd, int[] tl, int tl_index, int[] td, int td_index)
	{
		int_11 = 0;
		byte_0 = (byte)bl;
		byte_1 = (byte)bd;
		int_19 = tl;
		int_20 = tl_index;
		int_21 = td;
		int_22 = td_index;
		int_13 = null;
	}

	internal int method_1(Class6744 blocks, int r)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		int num9 = 0;
		int num10 = 0;
		Class6756 class6756_ = blocks.class6756_0;
		num6 = class6756_.int_0;
		num7 = class6756_.int_1;
		num4 = blocks.int_22;
		num5 = blocks.int_21;
		num8 = blocks.int_26;
		num9 = ((num8 < blocks.int_25) ? (blocks.int_25 - num8 - 1) : (blocks.int_24 - num8));
		while (true)
		{
			switch (int_11)
			{
			case 6:
				if (num9 == 0)
				{
					if (num8 == blocks.int_24 && blocks.int_25 != 0)
					{
						num8 = 0;
						num9 = ((0 < blocks.int_25) ? (blocks.int_25 - num8 - 1) : (blocks.int_24 - num8));
					}
					if (num9 == 0)
					{
						blocks.int_26 = num8;
						r = blocks.Flush(r);
						num8 = blocks.int_26;
						num9 = ((num8 < blocks.int_25) ? (blocks.int_25 - num8 - 1) : (blocks.int_24 - num8));
						if (num8 == blocks.int_24 && blocks.int_25 != 0)
						{
							num8 = 0;
							num9 = ((0 < blocks.int_25) ? (blocks.int_25 - num8 - 1) : (blocks.int_24 - num8));
						}
						if (num9 == 0)
						{
							blocks.int_22 = num4;
							blocks.int_21 = num5;
							class6756_.int_1 = num7;
							class6756_.long_0 += num6 - class6756_.int_0;
							class6756_.int_0 = num6;
							blocks.int_26 = num8;
							return blocks.Flush(r);
						}
					}
				}
				r = 0;
				blocks.byte_0[num8++] = (byte)int_16;
				num9--;
				int_11 = 0;
				break;
			case 5:
				for (num10 = num8 - int_18; num10 < 0; num10 += blocks.int_24)
				{
				}
				while (int_12 != 0)
				{
					if (num9 == 0)
					{
						if (num8 == blocks.int_24 && blocks.int_25 != 0)
						{
							num8 = 0;
							num9 = ((0 < blocks.int_25) ? (blocks.int_25 - num8 - 1) : (blocks.int_24 - num8));
						}
						if (num9 == 0)
						{
							blocks.int_26 = num8;
							r = blocks.Flush(r);
							num8 = blocks.int_26;
							num9 = ((num8 < blocks.int_25) ? (blocks.int_25 - num8 - 1) : (blocks.int_24 - num8));
							if (num8 == blocks.int_24 && blocks.int_25 != 0)
							{
								num8 = 0;
								num9 = ((0 < blocks.int_25) ? (blocks.int_25 - num8 - 1) : (blocks.int_24 - num8));
							}
							if (num9 == 0)
							{
								blocks.int_22 = num4;
								blocks.int_21 = num5;
								class6756_.int_1 = num7;
								class6756_.long_0 += num6 - class6756_.int_0;
								class6756_.int_0 = num6;
								blocks.int_26 = num8;
								return blocks.Flush(r);
							}
						}
					}
					blocks.byte_0[num8++] = blocks.byte_0[num10++];
					num9--;
					if (num10 == blocks.int_24)
					{
						num10 = 0;
					}
					int_12--;
				}
				int_11 = 0;
				break;
			case 4:
				for (num = int_17; num5 < num; num5 += 8)
				{
					if (num7 != 0)
					{
						r = 0;
						num7--;
						num4 |= (class6756_.byte_0[num6++] & 0xFF) << num5;
						continue;
					}
					blocks.int_22 = num4;
					blocks.int_21 = num5;
					class6756_.int_1 = num7;
					class6756_.long_0 += num6 - class6756_.int_0;
					class6756_.int_0 = num6;
					blocks.int_26 = num8;
					return blocks.Flush(r);
				}
				int_18 += num4 & int_10[num];
				num4 >>= num;
				num5 -= num;
				int_11 = 5;
				goto case 5;
			case 3:
				for (num = int_15; num5 < num; num5 += 8)
				{
					if (num7 != 0)
					{
						r = 0;
						num7--;
						num4 |= (class6756_.byte_0[num6++] & 0xFF) << num5;
						continue;
					}
					blocks.int_22 = num4;
					blocks.int_21 = num5;
					class6756_.int_1 = num7;
					class6756_.long_0 += num6 - class6756_.int_0;
					class6756_.int_0 = num6;
					blocks.int_26 = num8;
					return blocks.Flush(r);
				}
				num2 = (int_14 + (num4 & int_10[num])) * 3;
				num4 >>= int_13[num2 + 1];
				num5 -= int_13[num2 + 1];
				num3 = int_13[num2];
				if (((uint)num3 & 0x10u) != 0)
				{
					int_17 = num3 & 0xF;
					int_18 = int_13[num2 + 2];
					int_11 = 4;
					break;
				}
				if ((num3 & 0x40) == 0)
				{
					int_15 = num3;
					int_14 = num2 / 3 + int_13[num2 + 2];
					break;
				}
				int_11 = 9;
				class6756_.string_0 = "invalid distance code";
				r = -3;
				blocks.int_22 = num4;
				blocks.int_21 = num5;
				class6756_.int_1 = num7;
				class6756_.long_0 += num6 - class6756_.int_0;
				class6756_.int_0 = num6;
				blocks.int_26 = num8;
				return blocks.Flush(-3);
			case 2:
				for (num = int_17; num5 < num; num5 += 8)
				{
					if (num7 != 0)
					{
						r = 0;
						num7--;
						num4 |= (class6756_.byte_0[num6++] & 0xFF) << num5;
						continue;
					}
					blocks.int_22 = num4;
					blocks.int_21 = num5;
					class6756_.int_1 = num7;
					class6756_.long_0 += num6 - class6756_.int_0;
					class6756_.int_0 = num6;
					blocks.int_26 = num8;
					return blocks.Flush(r);
				}
				int_12 += num4 & int_10[num];
				num4 >>= num;
				num5 -= num;
				int_15 = byte_1;
				int_13 = int_21;
				int_14 = int_22;
				int_11 = 3;
				goto case 3;
			case 1:
				for (num = int_15; num5 < num; num5 += 8)
				{
					if (num7 != 0)
					{
						r = 0;
						num7--;
						num4 |= (class6756_.byte_0[num6++] & 0xFF) << num5;
						continue;
					}
					blocks.int_22 = num4;
					blocks.int_21 = num5;
					class6756_.int_1 = num7;
					class6756_.long_0 += num6 - class6756_.int_0;
					class6756_.int_0 = num6;
					blocks.int_26 = num8;
					return blocks.Flush(r);
				}
				num2 = (int_14 + (num4 & int_10[num])) * 3;
				num4 = Class6753.smethod_0(num4, int_13[num2 + 1]);
				num5 -= int_13[num2 + 1];
				num3 = int_13[num2];
				if (num3 == 0)
				{
					int_16 = int_13[num2 + 2];
					int_11 = 6;
					break;
				}
				if (((uint)num3 & 0x10u) != 0)
				{
					int_17 = num3 & 0xF;
					int_12 = int_13[num2 + 2];
					int_11 = 2;
					break;
				}
				if ((num3 & 0x40) == 0)
				{
					int_15 = num3;
					int_14 = num2 / 3 + int_13[num2 + 2];
					break;
				}
				if (((uint)num3 & 0x20u) != 0)
				{
					int_11 = 7;
					break;
				}
				int_11 = 9;
				class6756_.string_0 = "invalid literal/length code";
				r = -3;
				blocks.int_22 = num4;
				blocks.int_21 = num5;
				class6756_.int_1 = num7;
				class6756_.long_0 += num6 - class6756_.int_0;
				class6756_.int_0 = num6;
				blocks.int_26 = num8;
				return blocks.Flush(-3);
			case 0:
				if (num9 >= 258 && num7 >= 10)
				{
					blocks.int_22 = num4;
					blocks.int_21 = num5;
					class6756_.int_1 = num7;
					class6756_.long_0 += num6 - class6756_.int_0;
					class6756_.int_0 = num6;
					blocks.int_26 = num8;
					r = smethod_0(byte_0, byte_1, int_19, int_20, int_21, int_22, blocks, class6756_);
					num6 = class6756_.int_0;
					num7 = class6756_.int_1;
					num4 = blocks.int_22;
					num5 = blocks.int_21;
					num8 = blocks.int_26;
					num9 = ((num8 < blocks.int_25) ? (blocks.int_25 - num8 - 1) : (blocks.int_24 - num8));
					if (r != 0)
					{
						int_11 = ((r == 1) ? 7 : 9);
						break;
					}
				}
				int_15 = byte_0;
				int_13 = int_19;
				int_14 = int_20;
				int_11 = 1;
				goto case 1;
			default:
				r = -2;
				blocks.int_22 = num4;
				blocks.int_21 = num5;
				class6756_.int_1 = num7;
				class6756_.long_0 += num6 - class6756_.int_0;
				class6756_.int_0 = num6;
				blocks.int_26 = num8;
				return blocks.Flush(-2);
			case 7:
				if (num5 > 7)
				{
					num5 -= 8;
					num7++;
					num6--;
				}
				blocks.int_26 = num8;
				r = blocks.Flush(r);
				num8 = blocks.int_26;
				num9 = ((num8 < blocks.int_25) ? (blocks.int_25 - num8 - 1) : (blocks.int_24 - num8));
				if (blocks.int_25 != blocks.int_26)
				{
					blocks.int_22 = num4;
					blocks.int_21 = num5;
					class6756_.int_1 = num7;
					class6756_.long_0 += num6 - class6756_.int_0;
					class6756_.int_0 = num6;
					blocks.int_26 = num8;
					return blocks.Flush(r);
				}
				int_11 = 8;
				goto case 8;
			case 8:
				r = 1;
				blocks.int_22 = num4;
				blocks.int_21 = num5;
				class6756_.int_1 = num7;
				class6756_.long_0 += num6 - class6756_.int_0;
				class6756_.int_0 = num6;
				blocks.int_26 = num8;
				return blocks.Flush(1);
			case 9:
				r = -3;
				blocks.int_22 = num4;
				blocks.int_21 = num5;
				class6756_.int_1 = num7;
				class6756_.long_0 += num6 - class6756_.int_0;
				class6756_.int_0 = num6;
				blocks.int_26 = num8;
				return blocks.Flush(-3);
			}
		}
	}

	internal static int smethod_0(int bl, int bd, int[] tl, int tl_index, int[] td, int td_index, Class6744 s, Class6756 z)
	{
		int num = z.int_0;
		int num2 = z.int_1;
		int num3 = s.int_22;
		int num4 = s.int_21;
		int num5 = s.int_26;
		int num6 = ((num5 < s.int_25) ? (s.int_25 - num5 - 1) : (s.int_24 - num5));
		int num7 = int_10[bl];
		int num8 = int_10[bd];
		int num13;
		while (true)
		{
			if (num4 < 20)
			{
				num2--;
				num3 |= (z.byte_0[num++] & 0xFF) << num4;
				num4 += 8;
				continue;
			}
			int num9 = num3 & num7;
			int[] array = tl;
			int num10 = tl_index;
			int num11 = (num10 + num9) * 3;
			int num12;
			if ((num12 = array[num11]) == 0)
			{
				num3 >>= array[num11 + 1];
				num4 -= array[num11 + 1];
				s.byte_0[num5++] = (byte)array[num11 + 2];
				num6--;
			}
			else
			{
				while (true)
				{
					num3 >>= array[num11 + 1];
					num4 -= array[num11 + 1];
					if ((num12 & 0x10) == 0)
					{
						if ((num12 & 0x40) == 0)
						{
							num9 += array[num11 + 2];
							num9 += num3 & int_10[num12];
							num11 = (num10 + num9) * 3;
							if ((num12 = array[num11]) == 0)
							{
								num3 >>= array[num11 + 1];
								num4 -= array[num11 + 1];
								s.byte_0[num5++] = (byte)array[num11 + 2];
								num6--;
								break;
							}
							continue;
						}
						if (((uint)num12 & 0x20u) != 0)
						{
							num13 = z.int_1 - num2;
							num13 = ((num4 >> 3 < num13) ? (num4 >> 3) : num13);
							num2 += num13;
							num -= num13;
							num4 -= num13 << 3;
							s.int_22 = num3;
							s.int_21 = num4;
							z.int_1 = num2;
							z.long_0 += num - z.int_0;
							z.int_0 = num;
							s.int_26 = num5;
							return 1;
						}
						z.string_0 = "invalid literal/length code";
						num13 = z.int_1 - num2;
						num13 = ((num4 >> 3 < num13) ? (num4 >> 3) : num13);
						num2 += num13;
						num -= num13;
						num4 -= num13 << 3;
						s.int_22 = num3;
						s.int_21 = num4;
						z.int_1 = num2;
						z.long_0 += num - z.int_0;
						z.int_0 = num;
						s.int_26 = num5;
						return -3;
					}
					num12 &= 0xF;
					num13 = array[num11 + 2] + (num3 & int_10[num12]);
					num3 >>= num12;
					for (num4 -= num12; num4 < 15; num4 += 8)
					{
						num2--;
						num3 |= (z.byte_0[num++] & 0xFF) << num4;
					}
					num9 = num3 & num8;
					array = td;
					num10 = td_index;
					num11 = (num10 + num9) * 3;
					num12 = array[num11];
					while (true)
					{
						num3 >>= array[num11 + 1];
						num4 -= array[num11 + 1];
						if (((uint)num12 & 0x10u) != 0)
						{
							break;
						}
						if ((num12 & 0x40) == 0)
						{
							num9 += array[num11 + 2];
							num9 += num3 & int_10[num12];
							num11 = (num10 + num9) * 3;
							num12 = array[num11];
							continue;
						}
						z.string_0 = "invalid distance code";
						num13 = z.int_1 - num2;
						num13 = ((num4 >> 3 < num13) ? (num4 >> 3) : num13);
						num2 += num13;
						num -= num13;
						num4 -= num13 << 3;
						s.int_22 = num3;
						s.int_21 = num4;
						z.int_1 = num2;
						z.long_0 += num - z.int_0;
						z.int_0 = num;
						s.int_26 = num5;
						return -3;
					}
					for (num12 &= 0xF; num4 < num12; num4 += 8)
					{
						num2--;
						num3 |= (z.byte_0[num++] & 0xFF) << num4;
					}
					int num14 = array[num11 + 2] + (num3 & int_10[num12]);
					num3 >>= num12;
					num4 -= num12;
					num6 -= num13;
					int num15;
					if (num5 >= num14)
					{
						num15 = num5 - num14;
						if (num5 - num15 > 0 && 2 > num5 - num15)
						{
							s.byte_0[num5++] = s.byte_0[num15++];
							s.byte_0[num5++] = s.byte_0[num15++];
							num13 -= 2;
						}
						else
						{
							Array.Copy(s.byte_0, num15, s.byte_0, num5, 2);
							num5 += 2;
							num15 += 2;
							num13 -= 2;
						}
					}
					else
					{
						num15 = num5 - num14;
						do
						{
							num15 += s.int_24;
						}
						while (num15 < 0);
						num12 = s.int_24 - num15;
						if (num13 > num12)
						{
							num13 -= num12;
							if (num5 - num15 > 0 && num12 > num5 - num15)
							{
								do
								{
									s.byte_0[num5++] = s.byte_0[num15++];
								}
								while (--num12 != 0);
							}
							else
							{
								Array.Copy(s.byte_0, num15, s.byte_0, num5, num12);
								num5 += num12;
								num15 += num12;
								num12 = 0;
							}
							num15 = 0;
						}
					}
					if (num5 - num15 > 0 && num13 > num5 - num15)
					{
						do
						{
							s.byte_0[num5++] = s.byte_0[num15++];
						}
						while (--num13 != 0);
						break;
					}
					Array.Copy(s.byte_0, num15, s.byte_0, num5, num13);
					num5 += num13;
					num15 += num13;
					num13 = 0;
					break;
				}
			}
			if (num6 < 258 || num2 < 10)
			{
				break;
			}
		}
		num13 = z.int_1 - num2;
		num13 = ((num4 >> 3 < num13) ? (num4 >> 3) : num13);
		num2 += num13;
		num -= num13;
		num4 -= num13 << 3;
		s.int_22 = num3;
		s.int_21 = num4;
		z.int_1 = num2;
		z.long_0 += num - z.int_0;
		z.int_0 = num;
		s.int_26 = num5;
		return 0;
	}
}
