using System;

namespace ns16;

internal sealed class Class754
{
	private enum Enum38
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9
	}

	internal static readonly int[] int_0 = new int[19]
	{
		16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
		11, 4, 12, 3, 13, 2, 14, 1, 15
	};

	private Enum38 enum38_0;

	internal int int_1;

	internal int int_2;

	internal int int_3;

	internal int[] int_4;

	internal int[] int_5 = new int[1];

	internal int[] int_6 = new int[1];

	internal Class756 class756_0 = new Class756();

	internal int int_7;

	internal Class765 class765_0;

	internal int int_8;

	internal int int_9;

	internal int[] int_10;

	internal byte[] byte_0;

	internal int int_11;

	internal int int_12;

	internal int int_13;

	internal object object_0;

	internal uint uint_0;

	internal Class758 class758_0 = new Class758();

	internal Class754(Class765 class765_1, object object_1, int int_14)
	{
		class765_0 = class765_1;
		int_10 = new int[4320];
		byte_0 = new byte[int_14];
		int_11 = int_14;
		object_0 = object_1;
		enum38_0 = Enum38.const_0;
		Reset();
	}

	internal uint Reset()
	{
		uint result = uint_0;
		enum38_0 = Enum38.const_0;
		int_8 = 0;
		int_9 = 0;
		int_13 = 0;
		int_12 = 0;
		if (object_0 != null)
		{
			class765_0.uint_0 = (uint_0 = Class764.smethod_0(0u, null, 0, 0));
		}
		return result;
	}

	internal int Process(int int_14)
	{
		int num = class765_0.int_0;
		int num2 = class765_0.int_1;
		int num3 = int_9;
		int i = int_8;
		int num4 = int_13;
		int num5 = ((num4 < int_12) ? (int_12 - num4 - 1) : (int_11 - num4));
		while (true)
		{
			switch (enum38_0)
			{
			case Enum38.const_6:
				int_9 = num3;
				int_8 = i;
				class765_0.int_1 = num2;
				class765_0.long_0 += num - class765_0.int_0;
				class765_0.int_0 = num;
				int_13 = num4;
				int_14 = class756_0.Process(this, int_14);
				if (int_14 == 1)
				{
					int_14 = 0;
					num = class765_0.int_0;
					num2 = class765_0.int_1;
					num3 = int_9;
					i = int_8;
					num4 = int_13;
					num5 = ((num4 < int_12) ? (int_12 - num4 - 1) : (int_11 - num4));
					if (int_7 == 0)
					{
						enum38_0 = Enum38.const_0;
						break;
					}
					enum38_0 = Enum38.const_7;
					goto case Enum38.const_7;
				}
				return Flush(int_14);
			case Enum38.const_5:
			{
				int num6;
				while (true)
				{
					num6 = int_2;
					if (int_3 >= 258 + (num6 & 0x1F) + ((num6 >> 5) & 0x1F))
					{
						break;
					}
					for (num6 = int_5[0]; i < num6; i += 8)
					{
						if (num2 != 0)
						{
							int_14 = 0;
							num2--;
							num3 |= (class765_0.byte_0[num++] & 0xFF) << i;
							continue;
						}
						int_9 = num3;
						int_8 = i;
						class765_0.int_1 = num2;
						class765_0.long_0 += num - class765_0.int_0;
						class765_0.int_0 = num;
						int_13 = num4;
						return Flush(int_14);
					}
					num6 = int_10[(int_6[0] + (num3 & Class755.int_0[num6])) * 3 + 1];
					int num7 = int_10[(int_6[0] + (num3 & Class755.int_0[num6])) * 3 + 2];
					if (num7 < 16)
					{
						num3 >>= num6;
						i -= num6;
						int_4[int_3++] = num7;
						continue;
					}
					int num8 = ((num7 == 18) ? 7 : (num7 - 14));
					int num9 = ((num7 == 18) ? 11 : 3);
					for (; i < num6 + num8; i += 8)
					{
						if (num2 != 0)
						{
							int_14 = 0;
							num2--;
							num3 |= (class765_0.byte_0[num++] & 0xFF) << i;
							continue;
						}
						int_9 = num3;
						int_8 = i;
						class765_0.int_1 = num2;
						class765_0.long_0 += num - class765_0.int_0;
						class765_0.int_0 = num;
						int_13 = num4;
						return Flush(int_14);
					}
					num3 >>= num6;
					i -= num6;
					num9 += num3 & Class755.int_0[num8];
					num3 >>= num8;
					i -= num8;
					num8 = int_3;
					num6 = int_2;
					if (num8 + num9 <= 258 + (num6 & 0x1F) + ((num6 >> 5) & 0x1F) && (num7 != 16 || num8 >= 1))
					{
						num7 = ((num7 == 16) ? int_4[num8 - 1] : 0);
						do
						{
							int_4[num8++] = num7;
						}
						while (--num9 != 0);
						int_3 = num8;
						continue;
					}
					int_4 = null;
					enum38_0 = Enum38.const_9;
					class765_0.string_0 = "invalid bit length repeat";
					int_14 = -3;
					int_9 = num3;
					int_8 = i;
					class765_0.int_1 = num2;
					class765_0.long_0 += num - class765_0.int_0;
					class765_0.int_0 = num;
					int_13 = num4;
					return Flush(-3);
				}
				int_6[0] = -1;
				int[] array5 = new int[1] { 9 };
				int[] array6 = new int[1] { 6 };
				int[] array7 = new int[1];
				int[] array8 = new int[1];
				num6 = int_2;
				num6 = class758_0.method_2(257 + (num6 & 0x1F), 1 + ((num6 >> 5) & 0x1F), int_4, array5, array6, array7, array8, int_10, class765_0);
				if (num6 == 0)
				{
					class756_0.method_0(array5[0], array6[0], int_10, array7[0], int_10, array8[0]);
					enum38_0 = Enum38.const_6;
					goto case Enum38.const_6;
				}
				if (num6 == -3)
				{
					int_4 = null;
					enum38_0 = Enum38.const_9;
				}
				int_14 = num6;
				int_9 = num3;
				int_8 = i;
				class765_0.int_1 = num2;
				class765_0.long_0 += num - class765_0.int_0;
				class765_0.int_0 = num;
				int_13 = num4;
				return Flush(int_14);
			}
			case Enum38.const_4:
			{
				while (int_3 < 4 + (int_2 >> 10))
				{
					for (; i < 3; i += 8)
					{
						if (num2 != 0)
						{
							int_14 = 0;
							num2--;
							num3 |= (class765_0.byte_0[num++] & 0xFF) << i;
							continue;
						}
						int_9 = num3;
						int_8 = i;
						class765_0.int_1 = num2;
						class765_0.long_0 += num - class765_0.int_0;
						class765_0.int_0 = num;
						int_13 = num4;
						return Flush(int_14);
					}
					int_4[int_0[int_3++]] = num3 & 7;
					num3 >>= 3;
					i -= 3;
				}
				while (int_3 < 19)
				{
					int_4[int_0[int_3++]] = 0;
				}
				int_5[0] = 7;
				int num6 = class758_0.method_1(int_4, int_5, int_6, int_10, class765_0);
				if (num6 == 0)
				{
					int_3 = 0;
					enum38_0 = Enum38.const_5;
					goto case Enum38.const_5;
				}
				int_14 = num6;
				if (int_14 == -3)
				{
					int_4 = null;
					enum38_0 = Enum38.const_9;
				}
				int_9 = num3;
				int_8 = i;
				class765_0.int_1 = num2;
				class765_0.long_0 += num - class765_0.int_0;
				class765_0.int_0 = num;
				int_13 = num4;
				return Flush(int_14);
			}
			case Enum38.const_3:
			{
				for (; i < 14; i += 8)
				{
					if (num2 != 0)
					{
						int_14 = 0;
						num2--;
						num3 |= (class765_0.byte_0[num++] & 0xFF) << i;
						continue;
					}
					int_9 = num3;
					int_8 = i;
					class765_0.int_1 = num2;
					class765_0.long_0 += num - class765_0.int_0;
					class765_0.int_0 = num;
					int_13 = num4;
					return Flush(int_14);
				}
				int num6 = (int_2 = num3 & 0x3FFF);
				if ((num6 & 0x1F) <= 29 && ((num6 >> 5) & 0x1F) <= 29)
				{
					num6 = 258 + (num6 & 0x1F) + ((num6 >> 5) & 0x1F);
					if (int_4 != null && int_4.Length >= num6)
					{
						Array.Clear(int_4, 0, num6);
					}
					else
					{
						int_4 = new int[num6];
					}
					num3 >>= 14;
					i -= 14;
					int_3 = 0;
					enum38_0 = Enum38.const_4;
					goto case Enum38.const_4;
				}
				enum38_0 = Enum38.const_9;
				class765_0.string_0 = "too many length or distance symbols";
				int_14 = -3;
				int_9 = num3;
				int_8 = i;
				class765_0.int_1 = num2;
				class765_0.long_0 += num - class765_0.int_0;
				class765_0.int_0 = num;
				int_13 = num4;
				return Flush(-3);
			}
			case Enum38.const_2:
				if (num2 != 0)
				{
					if (num5 == 0)
					{
						if (num4 == int_11 && int_12 != 0)
						{
							num4 = 0;
							num5 = ((0 < int_12) ? (int_12 - num4 - 1) : (int_11 - num4));
						}
						if (num5 == 0)
						{
							int_13 = num4;
							int_14 = Flush(int_14);
							num4 = int_13;
							num5 = ((num4 < int_12) ? (int_12 - num4 - 1) : (int_11 - num4));
							if (num4 == int_11 && int_12 != 0)
							{
								num4 = 0;
								num5 = ((0 < int_12) ? (int_12 - num4 - 1) : (int_11 - num4));
							}
							if (num5 == 0)
							{
								int_9 = num3;
								int_8 = i;
								class765_0.int_1 = num2;
								class765_0.long_0 += num - class765_0.int_0;
								class765_0.int_0 = num;
								int_13 = num4;
								return Flush(int_14);
							}
						}
					}
					int_14 = 0;
					int num6 = int_1;
					if (num6 > num2)
					{
						num6 = num2;
					}
					if (num6 > num5)
					{
						num6 = num5;
					}
					Array.Copy(class765_0.byte_0, num, byte_0, num4, num6);
					num += num6;
					num2 -= num6;
					num4 += num6;
					num5 -= num6;
					if ((int_1 -= num6) == 0)
					{
						enum38_0 = ((int_7 != 0) ? Enum38.const_7 : Enum38.const_0);
					}
					break;
				}
				int_9 = num3;
				int_8 = i;
				class765_0.int_1 = num2;
				class765_0.long_0 += num - class765_0.int_0;
				class765_0.int_0 = num;
				int_13 = num4;
				return Flush(int_14);
			case Enum38.const_1:
				for (; i < 32; i += 8)
				{
					if (num2 != 0)
					{
						int_14 = 0;
						num2--;
						num3 |= (class765_0.byte_0[num++] & 0xFF) << i;
						continue;
					}
					int_9 = num3;
					int_8 = i;
					class765_0.int_1 = num2;
					class765_0.long_0 += num - class765_0.int_0;
					class765_0.int_0 = num;
					int_13 = num4;
					return Flush(int_14);
				}
				if (((~num3 >> 16) & 0xFFFF) == (num3 & 0xFFFF))
				{
					int_1 = num3 & 0xFFFF;
					num3 = (i = 0);
					enum38_0 = ((int_1 != 0) ? Enum38.const_2 : ((int_7 != 0) ? Enum38.const_7 : Enum38.const_0));
					break;
				}
				enum38_0 = Enum38.const_9;
				class765_0.string_0 = "invalid stored block lengths";
				int_14 = -3;
				int_9 = num3;
				int_8 = i;
				class765_0.int_1 = num2;
				class765_0.long_0 += num - class765_0.int_0;
				class765_0.int_0 = num;
				int_13 = num4;
				return Flush(-3);
			case Enum38.const_0:
			{
				for (; i < 3; i += 8)
				{
					if (num2 != 0)
					{
						int_14 = 0;
						num2--;
						num3 |= (class765_0.byte_0[num++] & 0xFF) << i;
						continue;
					}
					int_9 = num3;
					int_8 = i;
					class765_0.int_1 = num2;
					class765_0.long_0 += num - class765_0.int_0;
					class765_0.int_0 = num;
					int_13 = num4;
					return Flush(int_14);
				}
				int num6 = num3 & 7;
				int_7 = num6 & 1;
				switch ((uint)num6 >> 1)
				{
				case 0u:
					num3 >>= 3;
					i -= 3;
					num6 = i & 7;
					num3 >>= num6;
					i -= num6;
					enum38_0 = Enum38.const_1;
					break;
				case 1u:
				{
					int[] array = new int[1];
					int[] array2 = new int[1];
					int[][] array3 = new int[1][];
					int[][] array4 = new int[1][];
					Class758.smethod_0(array, array2, array3, array4, class765_0);
					class756_0.method_0(array[0], array2[0], array3[0], 0, array4[0], 0);
					num3 >>= 3;
					i -= 3;
					enum38_0 = Enum38.const_6;
					break;
				}
				case 2u:
					num3 >>= 3;
					i -= 3;
					enum38_0 = Enum38.const_3;
					break;
				case 3u:
					num3 >>= 3;
					i -= 3;
					enum38_0 = Enum38.const_9;
					class765_0.string_0 = "invalid block type";
					int_14 = -3;
					int_9 = num3;
					int_8 = i;
					class765_0.int_1 = num2;
					class765_0.long_0 += num - class765_0.int_0;
					class765_0.int_0 = num;
					int_13 = num4;
					return Flush(-3);
				}
				break;
			}
			default:
				int_14 = -2;
				int_9 = num3;
				int_8 = i;
				class765_0.int_1 = num2;
				class765_0.long_0 += num - class765_0.int_0;
				class765_0.int_0 = num;
				int_13 = num4;
				return Flush(-2);
			case Enum38.const_7:
				int_13 = num4;
				int_14 = Flush(int_14);
				num4 = int_13;
				num5 = ((num4 < int_12) ? (int_12 - num4 - 1) : (int_11 - num4));
				if (int_12 != int_13)
				{
					int_9 = num3;
					int_8 = i;
					class765_0.int_1 = num2;
					class765_0.long_0 += num - class765_0.int_0;
					class765_0.int_0 = num;
					int_13 = num4;
					return Flush(int_14);
				}
				enum38_0 = Enum38.const_8;
				goto case Enum38.const_8;
			case Enum38.const_8:
				int_14 = 1;
				int_9 = num3;
				int_8 = i;
				class765_0.int_1 = num2;
				class765_0.long_0 += num - class765_0.int_0;
				class765_0.int_0 = num;
				int_13 = num4;
				return Flush(1);
			case Enum38.const_9:
				int_14 = -3;
				int_9 = num3;
				int_8 = i;
				class765_0.int_1 = num2;
				class765_0.long_0 += num - class765_0.int_0;
				class765_0.int_0 = num;
				int_13 = num4;
				return Flush(-3);
			}
		}
	}

	internal void method_0()
	{
		Reset();
		byte_0 = null;
		int_10 = null;
	}

	internal int Flush(int int_14)
	{
		int num = 0;
		while (true)
		{
			if (num >= 2)
			{
				return int_14;
			}
			int num2 = ((num != 0) ? (int_13 - int_12) : (((int_12 <= int_13) ? int_13 : int_11) - int_12));
			if (num2 == 0)
			{
				break;
			}
			if (num2 > class765_0.int_3)
			{
				num2 = class765_0.int_3;
			}
			if (num2 != 0 && int_14 == -5)
			{
				int_14 = 0;
			}
			class765_0.int_3 -= num2;
			class765_0.long_1 += num2;
			if (object_0 != null)
			{
				class765_0.uint_0 = (uint_0 = Class764.smethod_0(uint_0, byte_0, int_12, num2));
			}
			Array.Copy(byte_0, int_12, class765_0.byte_1, class765_0.int_2, num2);
			class765_0.int_2 += num2;
			int_12 += num2;
			if (int_12 == int_11 && num == 0)
			{
				int_12 = 0;
				if (int_13 == int_11)
				{
					int_13 = 0;
				}
			}
			else
			{
				num++;
			}
			num++;
		}
		if (int_14 == -5)
		{
			int_14 = 0;
		}
		return int_14;
	}
}
