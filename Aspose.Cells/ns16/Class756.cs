using System;

namespace ns16;

internal sealed class Class756
{
	internal int int_0;

	internal int int_1;

	internal int[] int_2;

	internal int int_3;

	internal int int_4;

	internal int int_5;

	internal int int_6;

	internal int int_7;

	internal byte byte_0;

	internal byte byte_1;

	internal int[] int_8;

	internal int int_9;

	internal int[] int_10;

	internal int int_11;

	internal Class756()
	{
	}

	internal void method_0(int int_12, int int_13, int[] int_14, int int_15, int[] int_16, int int_17)
	{
		int_0 = 0;
		byte_0 = (byte)int_12;
		byte_1 = (byte)int_13;
		int_8 = int_14;
		int_9 = int_15;
		int_10 = int_16;
		int_11 = int_17;
		int_2 = null;
	}

	internal int Process(Class754 class754_0, int int_12)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		Class765 class765_ = class754_0.class765_0;
		num3 = class765_.int_0;
		int num4 = class765_.int_1;
		num = class754_0.int_9;
		num2 = class754_0.int_8;
		int num5 = class754_0.int_13;
		int num6 = ((num5 < class754_0.int_12) ? (class754_0.int_12 - num5 - 1) : (class754_0.int_11 - num5));
		while (true)
		{
			switch (int_0)
			{
			case 6:
				if (num6 == 0)
				{
					if (num5 == class754_0.int_11 && class754_0.int_12 != 0)
					{
						num5 = 0;
						num6 = ((0 < class754_0.int_12) ? (class754_0.int_12 - num5 - 1) : (class754_0.int_11 - num5));
					}
					if (num6 == 0)
					{
						class754_0.int_13 = num5;
						int_12 = class754_0.Flush(int_12);
						num5 = class754_0.int_13;
						num6 = ((num5 < class754_0.int_12) ? (class754_0.int_12 - num5 - 1) : (class754_0.int_11 - num5));
						if (num5 == class754_0.int_11 && class754_0.int_12 != 0)
						{
							num5 = 0;
							num6 = ((0 < class754_0.int_12) ? (class754_0.int_12 - num5 - 1) : (class754_0.int_11 - num5));
						}
						if (num6 == 0)
						{
							class754_0.int_9 = num;
							class754_0.int_8 = num2;
							class765_.int_1 = num4;
							class765_.long_0 += num3 - class765_.int_0;
							class765_.int_0 = num3;
							class754_0.int_13 = num5;
							return class754_0.Flush(int_12);
						}
					}
				}
				int_12 = 0;
				class754_0.byte_0[num5++] = (byte)int_5;
				num6--;
				int_0 = 0;
				break;
			case 5:
			{
				int i;
				for (i = num5 - int_7; i < 0; i += class754_0.int_11)
				{
				}
				while (int_1 != 0)
				{
					if (num6 == 0)
					{
						if (num5 == class754_0.int_11 && class754_0.int_12 != 0)
						{
							num5 = 0;
							num6 = ((0 < class754_0.int_12) ? (class754_0.int_12 - num5 - 1) : (class754_0.int_11 - num5));
						}
						if (num6 == 0)
						{
							class754_0.int_13 = num5;
							int_12 = class754_0.Flush(int_12);
							num5 = class754_0.int_13;
							num6 = ((num5 < class754_0.int_12) ? (class754_0.int_12 - num5 - 1) : (class754_0.int_11 - num5));
							if (num5 == class754_0.int_11 && class754_0.int_12 != 0)
							{
								num5 = 0;
								num6 = ((0 < class754_0.int_12) ? (class754_0.int_12 - num5 - 1) : (class754_0.int_11 - num5));
							}
							if (num6 == 0)
							{
								class754_0.int_9 = num;
								class754_0.int_8 = num2;
								class765_.int_1 = num4;
								class765_.long_0 += num3 - class765_.int_0;
								class765_.int_0 = num3;
								class754_0.int_13 = num5;
								return class754_0.Flush(int_12);
							}
						}
					}
					class754_0.byte_0[num5++] = class754_0.byte_0[i++];
					num6--;
					if (i == class754_0.int_11)
					{
						i = 0;
					}
					int_1--;
				}
				int_0 = 0;
				break;
			}
			case 4:
			{
				int num7;
				for (num7 = int_6; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						int_12 = 0;
						num4--;
						num |= (class765_.byte_0[num3++] & 0xFF) << num2;
						continue;
					}
					class754_0.int_9 = num;
					class754_0.int_8 = num2;
					class765_.int_1 = num4;
					class765_.long_0 += num3 - class765_.int_0;
					class765_.int_0 = num3;
					class754_0.int_13 = num5;
					return class754_0.Flush(int_12);
				}
				int_7 += num & Class755.int_0[num7];
				num >>= num7;
				num2 -= num7;
				int_0 = 5;
				goto case 5;
			}
			case 3:
			{
				int num7;
				for (num7 = int_4; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						int_12 = 0;
						num4--;
						num |= (class765_.byte_0[num3++] & 0xFF) << num2;
						continue;
					}
					class754_0.int_9 = num;
					class754_0.int_8 = num2;
					class765_.int_1 = num4;
					class765_.long_0 += num3 - class765_.int_0;
					class765_.int_0 = num3;
					class754_0.int_13 = num5;
					return class754_0.Flush(int_12);
				}
				int num8 = (int_3 + (num & Class755.int_0[num7])) * 3;
				num >>= int_2[num8 + 1];
				num2 -= int_2[num8 + 1];
				int num9 = int_2[num8];
				if (((uint)num9 & 0x10u) != 0)
				{
					int_6 = num9 & 0xF;
					int_7 = int_2[num8 + 2];
					int_0 = 4;
					break;
				}
				if ((num9 & 0x40) == 0)
				{
					int_4 = num9;
					int_3 = num8 / 3 + int_2[num8 + 2];
					break;
				}
				int_0 = 9;
				class765_.string_0 = "invalid distance code";
				int_12 = -3;
				class754_0.int_9 = num;
				class754_0.int_8 = num2;
				class765_.int_1 = num4;
				class765_.long_0 += num3 - class765_.int_0;
				class765_.int_0 = num3;
				class754_0.int_13 = num5;
				return class754_0.Flush(-3);
			}
			case 2:
			{
				int num7;
				for (num7 = int_6; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						int_12 = 0;
						num4--;
						num |= (class765_.byte_0[num3++] & 0xFF) << num2;
						continue;
					}
					class754_0.int_9 = num;
					class754_0.int_8 = num2;
					class765_.int_1 = num4;
					class765_.long_0 += num3 - class765_.int_0;
					class765_.int_0 = num3;
					class754_0.int_13 = num5;
					return class754_0.Flush(int_12);
				}
				int_1 += num & Class755.int_0[num7];
				num >>= num7;
				num2 -= num7;
				int_4 = byte_1;
				int_2 = int_10;
				int_3 = int_11;
				int_0 = 3;
				goto case 3;
			}
			case 1:
			{
				int num7;
				for (num7 = int_4; num2 < num7; num2 += 8)
				{
					if (num4 != 0)
					{
						int_12 = 0;
						num4--;
						num |= (class765_.byte_0[num3++] & 0xFF) << num2;
						continue;
					}
					class754_0.int_9 = num;
					class754_0.int_8 = num2;
					class765_.int_1 = num4;
					class765_.long_0 += num3 - class765_.int_0;
					class765_.int_0 = num3;
					class754_0.int_13 = num5;
					return class754_0.Flush(int_12);
				}
				int num8 = (int_3 + (num & Class755.int_0[num7])) * 3;
				num >>= int_2[num8 + 1];
				num2 -= int_2[num8 + 1];
				int num9 = int_2[num8];
				if (num9 == 0)
				{
					int_5 = int_2[num8 + 2];
					int_0 = 6;
					break;
				}
				if (((uint)num9 & 0x10u) != 0)
				{
					int_6 = num9 & 0xF;
					int_1 = int_2[num8 + 2];
					int_0 = 2;
					break;
				}
				if ((num9 & 0x40) == 0)
				{
					int_4 = num9;
					int_3 = num8 / 3 + int_2[num8 + 2];
					break;
				}
				if (((uint)num9 & 0x20u) != 0)
				{
					int_0 = 7;
					break;
				}
				int_0 = 9;
				class765_.string_0 = "invalid literal/length code";
				int_12 = -3;
				class754_0.int_9 = num;
				class754_0.int_8 = num2;
				class765_.int_1 = num4;
				class765_.long_0 += num3 - class765_.int_0;
				class765_.int_0 = num3;
				class754_0.int_13 = num5;
				return class754_0.Flush(-3);
			}
			case 0:
				if (num6 >= 258 && num4 >= 10)
				{
					class754_0.int_9 = num;
					class754_0.int_8 = num2;
					class765_.int_1 = num4;
					class765_.long_0 += num3 - class765_.int_0;
					class765_.int_0 = num3;
					class754_0.int_13 = num5;
					int_12 = method_1(byte_0, byte_1, int_8, int_9, int_10, int_11, class754_0, class765_);
					num3 = class765_.int_0;
					num4 = class765_.int_1;
					num = class754_0.int_9;
					num2 = class754_0.int_8;
					num5 = class754_0.int_13;
					num6 = ((num5 < class754_0.int_12) ? (class754_0.int_12 - num5 - 1) : (class754_0.int_11 - num5));
					if (int_12 != 0)
					{
						int_0 = ((int_12 == 1) ? 7 : 9);
						break;
					}
				}
				int_4 = byte_0;
				int_2 = int_8;
				int_3 = int_9;
				int_0 = 1;
				goto case 1;
			default:
				int_12 = -2;
				class754_0.int_9 = num;
				class754_0.int_8 = num2;
				class765_.int_1 = num4;
				class765_.long_0 += num3 - class765_.int_0;
				class765_.int_0 = num3;
				class754_0.int_13 = num5;
				return class754_0.Flush(-2);
			case 7:
				if (num2 > 7)
				{
					num2 -= 8;
					num4++;
					num3--;
				}
				class754_0.int_13 = num5;
				int_12 = class754_0.Flush(int_12);
				num5 = class754_0.int_13;
				num6 = ((num5 < class754_0.int_12) ? (class754_0.int_12 - num5 - 1) : (class754_0.int_11 - num5));
				if (class754_0.int_12 != class754_0.int_13)
				{
					class754_0.int_9 = num;
					class754_0.int_8 = num2;
					class765_.int_1 = num4;
					class765_.long_0 += num3 - class765_.int_0;
					class765_.int_0 = num3;
					class754_0.int_13 = num5;
					return class754_0.Flush(int_12);
				}
				int_0 = 8;
				goto case 8;
			case 8:
				int_12 = 1;
				class754_0.int_9 = num;
				class754_0.int_8 = num2;
				class765_.int_1 = num4;
				class765_.long_0 += num3 - class765_.int_0;
				class765_.int_0 = num3;
				class754_0.int_13 = num5;
				return class754_0.Flush(1);
			case 9:
				int_12 = -3;
				class754_0.int_9 = num;
				class754_0.int_8 = num2;
				class765_.int_1 = num4;
				class765_.long_0 += num3 - class765_.int_0;
				class765_.int_0 = num3;
				class754_0.int_13 = num5;
				return class754_0.Flush(-3);
			}
		}
	}

	internal int method_1(int int_12, int int_13, int[] int_14, int int_15, int[] int_16, int int_17, Class754 class754_0, Class765 class765_0)
	{
		int num = class765_0.int_0;
		int num2 = class765_0.int_1;
		int num3 = class754_0.int_9;
		int num4 = class754_0.int_8;
		int num5 = class754_0.int_13;
		int num6 = ((num5 < class754_0.int_12) ? (class754_0.int_12 - num5 - 1) : (class754_0.int_11 - num5));
		int num7 = Class755.int_0[int_12];
		int num8 = Class755.int_0[int_13];
		int num13;
		while (true)
		{
			if (num4 < 20)
			{
				num2--;
				num3 |= (class765_0.byte_0[num++] & 0xFF) << num4;
				num4 += 8;
				continue;
			}
			int num9 = num3 & num7;
			int[] array = int_14;
			int num10 = int_15;
			int num11 = (num10 + num9) * 3;
			int num12;
			if ((num12 = array[num11]) == 0)
			{
				num3 >>= array[num11 + 1];
				num4 -= array[num11 + 1];
				class754_0.byte_0[num5++] = (byte)array[num11 + 2];
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
							num9 += num3 & Class755.int_0[num12];
							num11 = (num10 + num9) * 3;
							if ((num12 = array[num11]) == 0)
							{
								num3 >>= array[num11 + 1];
								num4 -= array[num11 + 1];
								class754_0.byte_0[num5++] = (byte)array[num11 + 2];
								num6--;
								break;
							}
							continue;
						}
						if (((uint)num12 & 0x20u) != 0)
						{
							num13 = class765_0.int_1 - num2;
							num13 = ((num4 >> 3 < num13) ? (num4 >> 3) : num13);
							num2 += num13;
							num -= num13;
							num4 -= num13 << 3;
							class754_0.int_9 = num3;
							class754_0.int_8 = num4;
							class765_0.int_1 = num2;
							class765_0.long_0 += num - class765_0.int_0;
							class765_0.int_0 = num;
							class754_0.int_13 = num5;
							return 1;
						}
						class765_0.string_0 = "invalid literal/length code";
						num13 = class765_0.int_1 - num2;
						num13 = ((num4 >> 3 < num13) ? (num4 >> 3) : num13);
						num2 += num13;
						num -= num13;
						num4 -= num13 << 3;
						class754_0.int_9 = num3;
						class754_0.int_8 = num4;
						class765_0.int_1 = num2;
						class765_0.long_0 += num - class765_0.int_0;
						class765_0.int_0 = num;
						class754_0.int_13 = num5;
						return -3;
					}
					num12 &= 0xF;
					num13 = array[num11 + 2] + (num3 & Class755.int_0[num12]);
					num3 >>= num12;
					for (num4 -= num12; num4 < 15; num4 += 8)
					{
						num2--;
						num3 |= (class765_0.byte_0[num++] & 0xFF) << num4;
					}
					num9 = num3 & num8;
					array = int_16;
					num10 = int_17;
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
							num9 += num3 & Class755.int_0[num12];
							num11 = (num10 + num9) * 3;
							num12 = array[num11];
							continue;
						}
						class765_0.string_0 = "invalid distance code";
						num13 = class765_0.int_1 - num2;
						num13 = ((num4 >> 3 < num13) ? (num4 >> 3) : num13);
						num2 += num13;
						num -= num13;
						num4 -= num13 << 3;
						class754_0.int_9 = num3;
						class754_0.int_8 = num4;
						class765_0.int_1 = num2;
						class765_0.long_0 += num - class765_0.int_0;
						class765_0.int_0 = num;
						class754_0.int_13 = num5;
						return -3;
					}
					for (num12 &= 0xF; num4 < num12; num4 += 8)
					{
						num2--;
						num3 |= (class765_0.byte_0[num++] & 0xFF) << num4;
					}
					int num14 = array[num11 + 2] + (num3 & Class755.int_0[num12]);
					num3 >>= num12;
					num4 -= num12;
					num6 -= num13;
					int num15;
					if (num5 >= num14)
					{
						num15 = num5 - num14;
						if (num5 - num15 > 0 && 2 > num5 - num15)
						{
							class754_0.byte_0[num5++] = class754_0.byte_0[num15++];
							class754_0.byte_0[num5++] = class754_0.byte_0[num15++];
							num13 -= 2;
						}
						else
						{
							Array.Copy(class754_0.byte_0, num15, class754_0.byte_0, num5, 2);
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
							num15 += class754_0.int_11;
						}
						while (num15 < 0);
						num12 = class754_0.int_11 - num15;
						if (num13 > num12)
						{
							num13 -= num12;
							if (num5 - num15 > 0 && num12 > num5 - num15)
							{
								do
								{
									class754_0.byte_0[num5++] = class754_0.byte_0[num15++];
								}
								while (--num12 != 0);
							}
							else
							{
								Array.Copy(class754_0.byte_0, num15, class754_0.byte_0, num5, num12);
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
							class754_0.byte_0[num5++] = class754_0.byte_0[num15++];
						}
						while (--num13 != 0);
						break;
					}
					Array.Copy(class754_0.byte_0, num15, class754_0.byte_0, num5, num13);
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
		num13 = class765_0.int_1 - num2;
		num13 = ((num4 >> 3 < num13) ? (num4 >> 3) : num13);
		num2 += num13;
		num -= num13;
		num4 -= num13 << 3;
		class754_0.int_9 = num3;
		class754_0.int_8 = num4;
		class765_0.int_1 = num2;
		class765_0.long_0 += num - class765_0.int_0;
		class765_0.int_0 = num;
		class754_0.int_13 = num5;
		return 0;
	}
}
