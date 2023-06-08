using System;
using System.Runtime.CompilerServices;

namespace ns16;

internal sealed class Class752
{
	internal delegate Enum36 Delegate4(Enum41 flush);

	internal class Class753
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		internal Enum37 enum37_0;

		private static readonly Class753[] class753_0;

		private Class753(int int_4, int int_5, int int_6, int int_7, Enum37 enum37_1)
		{
			int_0 = int_4;
			int_1 = int_5;
			int_2 = int_6;
			int_3 = int_7;
			enum37_0 = enum37_1;
		}

		public static Class753 smethod_0(Enum42 enum42_0)
		{
			return class753_0[(int)enum42_0];
		}

		static Class753()
		{
			class753_0 = new Class753[10]
			{
				new Class753(0, 0, 0, 0, Enum37.const_0),
				new Class753(4, 4, 8, 4, Enum37.const_1),
				new Class753(4, 5, 16, 8, Enum37.const_1),
				new Class753(4, 6, 32, 32, Enum37.const_1),
				new Class753(4, 4, 16, 16, Enum37.const_2),
				new Class753(8, 16, 32, 32, Enum37.const_2),
				new Class753(8, 16, 128, 128, Enum37.const_2),
				new Class753(8, 32, 128, 256, Enum37.const_2),
				new Class753(32, 128, 258, 1024, Enum37.const_2),
				new Class753(32, 258, 258, 4096, Enum37.const_2)
			};
		}
	}

	private static readonly int int_0 = 9;

	private static readonly int int_1 = 8;

	private Delegate4 delegate4_0;

	private static readonly string[] string_0 = new string[10] { "need dictionary", "stream end", "", "file error", "stream error", "data error", "insufficient memory", "buffer error", "incompatible version", "" };

	private static readonly int int_2 = 32;

	private static readonly int int_3 = 42;

	private static readonly int int_4 = 113;

	private static readonly int int_5 = 666;

	private static readonly int int_6 = 8;

	private static readonly int int_7 = 0;

	private static readonly int int_8 = 1;

	private static readonly int int_9 = 2;

	private static readonly int int_10 = 0;

	private static readonly int int_11 = 1;

	private static readonly int int_12 = 2;

	private static readonly int int_13 = 16;

	private static readonly int int_14 = 3;

	private static readonly int int_15 = 258;

	private static readonly int int_16 = int_15 + int_14 + 1;

	private static readonly int int_17 = 2 * Class762.int_5 + 1;

	private static readonly int int_18 = 256;

	internal Class765 class765_0;

	internal int int_19;

	internal byte[] byte_0;

	internal int int_20;

	internal int int_21;

	internal sbyte sbyte_0;

	internal int int_22;

	internal int int_23;

	internal int int_24;

	internal int int_25;

	internal byte[] byte_1;

	internal int int_26;

	internal short[] short_0;

	internal short[] short_1;

	internal int int_27;

	internal int int_28;

	internal int int_29;

	internal int int_30;

	internal int int_31;

	internal int int_32;

	private Class753 class753_0;

	internal int int_33;

	internal int int_34;

	internal int int_35;

	internal int int_36;

	internal int int_37;

	internal int int_38;

	internal int int_39;

	internal Enum42 enum42_0;

	internal Enum43 enum43_0;

	internal short[] short_2;

	internal short[] short_3;

	internal short[] short_4;

	internal Class760 class760_0 = new Class760();

	internal Class760 class760_1 = new Class760();

	internal Class760 class760_2 = new Class760();

	internal short[] short_5 = new short[Class762.int_0 + 1];

	internal int[] int_40 = new int[2 * Class762.int_5 + 1];

	internal int int_41;

	internal int int_42;

	internal sbyte[] sbyte_1 = new sbyte[2 * Class762.int_5 + 1];

	internal int int_43;

	internal int int_44;

	internal int int_45;

	internal int int_46;

	internal int int_47;

	internal int int_48;

	internal int int_49;

	internal int int_50;

	internal short short_6;

	internal int int_51;

	private bool bool_0;

	private bool bool_1 = true;

	internal Class752()
	{
		short_2 = new short[int_17 * 2];
		short_3 = new short[(2 * Class762.int_2 + 1) * 2];
		short_4 = new short[(2 * Class762.int_1 + 1) * 2];
	}

	private void method_0()
	{
		int_26 = 2 * int_23;
		Array.Clear(short_1, 0, int_28);
		class753_0 = Class753.smethod_0(enum42_0);
		method_28();
		int_36 = 0;
		int_32 = 0;
		int_38 = 0;
		int_33 = (int_39 = int_14 - 1);
		int_35 = 0;
		int_27 = 0;
	}

	private void method_1()
	{
		class760_0.short_0 = short_2;
		class760_0.class763_0 = Class763.class763_0;
		class760_1.short_0 = short_3;
		class760_1.class763_0 = Class763.class763_1;
		class760_2.short_0 = short_4;
		class760_2.class763_0 = Class763.class763_2;
		short_6 = 0;
		int_51 = 0;
		int_50 = 8;
		method_2();
	}

	internal void method_2()
	{
		for (int i = 0; i < Class762.int_5; i++)
		{
			short_2[i * 2] = 0;
		}
		for (int j = 0; j < Class762.int_2; j++)
		{
			short_3[j * 2] = 0;
		}
		for (int k = 0; k < Class762.int_1; k++)
		{
			short_4[k * 2] = 0;
		}
		short_2[int_18 * 2] = 1;
		int_48 = 0;
		int_47 = 0;
		int_49 = 0;
		int_45 = 0;
	}

	internal void method_3(short[] short_7, int int_52)
	{
		int num = int_40[int_52];
		for (int num2 = int_52 << 1; num2 <= int_41; num2 <<= 1)
		{
			if (num2 < int_41 && smethod_0(short_7, int_40[num2 + 1], int_40[num2], sbyte_1))
			{
				num2++;
			}
			if (smethod_0(short_7, num, int_40[num2], sbyte_1))
			{
				break;
			}
			int_40[int_52] = int_40[num2];
			int_52 = num2;
		}
		int_40[int_52] = num;
	}

	internal static bool smethod_0(short[] short_7, int int_52, int int_53, sbyte[] sbyte_2)
	{
		short num = short_7[int_52 * 2];
		short num2 = short_7[int_53 * 2];
		if (num >= num2)
		{
			if (num == num2)
			{
				return sbyte_2[int_52] <= sbyte_2[int_53];
			}
			return false;
		}
		return true;
	}

	internal void method_4(short[] short_7, int int_52)
	{
		int num = -1;
		int num2 = short_7[1];
		int num3 = 0;
		int num4 = 7;
		int num5 = 4;
		if (num2 == 0)
		{
			num4 = 138;
			num5 = 3;
		}
		short_7[(int_52 + 1) * 2 + 1] = short.MaxValue;
		for (int i = 0; i <= int_52; i++)
		{
			int num6 = num2;
			num2 = short_7[(i + 1) * 2 + 1];
			if (++num3 < num4 && num6 == num2)
			{
				continue;
			}
			if (num3 < num5)
			{
				short_4[num6 * 2] = (short)(short_4[num6 * 2] + num3);
			}
			else if (num6 != 0)
			{
				if (num6 != num)
				{
					short_4[num6 * 2]++;
				}
				short_4[Class762.int_7 * 2]++;
			}
			else if (num3 <= 10)
			{
				short_4[Class762.int_8 * 2]++;
			}
			else
			{
				short_4[Class762.int_9 * 2]++;
			}
			num3 = 0;
			num = num6;
			if (num2 == 0)
			{
				num4 = 138;
				num5 = 3;
			}
			else if (num6 == num2)
			{
				num4 = 6;
				num5 = 3;
			}
			else
			{
				num4 = 7;
				num5 = 4;
			}
		}
	}

	internal int method_5()
	{
		method_4(short_2, class760_0.int_6);
		method_4(short_3, class760_1.int_6);
		class760_2.method_1(this);
		int num = Class762.int_1 - 1;
		while (num >= 3 && short_4[Class760.sbyte_0[num] * 2 + 1] == 0)
		{
			num--;
		}
		int_47 += 3 * (num + 1) + 5 + 5 + 4;
		return num;
	}

	internal void method_6(int int_52, int int_53, int int_54)
	{
		method_10(int_52 - 257, 5);
		method_10(int_53 - 1, 5);
		method_10(int_54 - 4, 4);
		for (int i = 0; i < int_54; i++)
		{
			method_10(short_4[Class760.sbyte_0[i] * 2 + 1], 3);
		}
		method_7(short_2, int_52 - 1);
		method_7(short_3, int_53 - 1);
	}

	internal void method_7(short[] short_7, int int_52)
	{
		int num = -1;
		int num2 = short_7[1];
		int num3 = 0;
		int num4 = 7;
		int num5 = 4;
		if (num2 == 0)
		{
			num4 = 138;
			num5 = 3;
		}
		for (int i = 0; i <= int_52; i++)
		{
			int num6 = num2;
			num2 = short_7[(i + 1) * 2 + 1];
			if (++num3 < num4 && num6 == num2)
			{
				continue;
			}
			if (num3 < num5)
			{
				do
				{
					method_9(num6, short_4);
				}
				while (--num3 != 0);
			}
			else if (num6 != 0)
			{
				if (num6 != num)
				{
					method_9(num6, short_4);
					num3--;
				}
				method_9(Class762.int_7, short_4);
				method_10(num3 - 3, 2);
			}
			else if (num3 <= 10)
			{
				method_9(Class762.int_8, short_4);
				method_10(num3 - 3, 3);
			}
			else
			{
				method_9(Class762.int_9, short_4);
				method_10(num3 - 11, 7);
			}
			num3 = 0;
			num = num6;
			if (num2 == 0)
			{
				num4 = 138;
				num5 = 3;
			}
			else if (num6 == num2)
			{
				num4 = 6;
				num5 = 3;
			}
			else
			{
				num4 = 7;
				num5 = 4;
			}
		}
	}

	private void method_8(byte[] byte_2, int int_52, int int_53)
	{
		Array.Copy(byte_2, int_52, byte_0, int_21, int_53);
		int_21 += int_53;
	}

	internal void method_9(int int_52, short[] short_7)
	{
		int num = int_52 * 2;
		method_10(short_7[num] & 0xFFFF, short_7[num + 1] & 0xFFFF);
	}

	internal void method_10(int int_52, int int_53)
	{
		if (int_51 > int_13 - int_53)
		{
			short_6 |= (short)((int_52 << int_51) & 0xFFFF);
			byte_0[int_21++] = (byte)short_6;
			byte_0[int_21++] = (byte)(short_6 >> 8);
			short_6 = (short)((uint)int_52 >> int_13 - int_51);
			int_51 += int_53 - int_13;
		}
		else
		{
			short_6 |= (short)((int_52 << int_51) & 0xFFFF);
			int_51 += int_53;
		}
	}

	internal void method_11()
	{
		method_10(int_8 << 1, 3);
		method_9(int_18, Class763.short_0);
		method_15();
		if (1 + int_50 + 10 - int_51 < 9)
		{
			method_10(int_8 << 1, 3);
			method_9(int_18, Class763.short_0);
			method_15();
		}
		int_50 = 7;
	}

	internal bool method_12(int int_52, int int_53)
	{
		byte_0[int_46 + int_45 * 2] = (byte)((uint)int_52 >> 8);
		byte_0[int_46 + int_45 * 2 + 1] = (byte)int_52;
		byte_0[int_43 + int_45] = (byte)int_53;
		int_45++;
		if (int_52 == 0)
		{
			short_2[int_53 * 2]++;
		}
		else
		{
			int_49++;
			int_52--;
			short_2[(Class760.sbyte_2[int_53] + Class762.int_3 + 1) * 2]++;
			short_3[Class760.smethod_0(int_52) * 2]++;
		}
		if ((int_45 & 0x1FFF) == 0 && enum42_0 > Enum42.const_4)
		{
			int num = int_45 << 3;
			int num2 = int_36 - int_32;
			for (int i = 0; i < Class762.int_2; i++)
			{
				num = (int)(num + short_3[i * 2] * (5L + (long)Class760.int_2[i]));
			}
			num >>= 3;
			if (int_49 < int_45 / 2 && num < num2 / 2)
			{
				return true;
			}
		}
		if (int_45 != int_44 - 1)
		{
			return int_45 == int_44;
		}
		return true;
	}

	internal void method_13(short[] short_7, short[] short_8)
	{
		int num = 0;
		if (int_45 != 0)
		{
			do
			{
				int num2 = int_46 + num * 2;
				int num3 = ((byte_0[num2] << 8) & 0xFF00) | (byte_0[num2 + 1] & 0xFF);
				int num4 = byte_0[int_43 + num] & 0xFF;
				num++;
				if (num3 != 0)
				{
					int num5 = Class760.sbyte_2[num4];
					method_9(num5 + Class762.int_3 + 1, short_7);
					int num6 = Class760.int_1[num5];
					if (num6 != 0)
					{
						num4 -= Class760.int_4[num5];
						method_10(num4, num6);
					}
					num3--;
					num5 = Class760.smethod_0(num3);
					method_9(num5, short_8);
					num6 = Class760.int_2[num5];
					if (num6 != 0)
					{
						num3 -= Class760.int_5[num5];
						method_10(num3, num6);
					}
				}
				else
				{
					method_9(num4, short_7);
				}
			}
			while (num < int_45);
		}
		method_9(int_18, short_7);
		int_50 = short_7[int_18 * 2 + 1];
	}

	internal void method_14()
	{
		int i = 0;
		int num = 0;
		int num2 = 0;
		for (; i < 7; i++)
		{
			num2 += short_2[i * 2];
		}
		for (; i < 128; i++)
		{
			num += short_2[i * 2];
		}
		for (; i < Class762.int_3; i++)
		{
			num2 += short_2[i * 2];
		}
		sbyte_0 = (sbyte)((num2 > num >> 2) ? int_10 : int_11);
	}

	internal void method_15()
	{
		if (int_51 == 16)
		{
			byte_0[int_21++] = (byte)short_6;
			byte_0[int_21++] = (byte)(short_6 >> 8);
			short_6 = 0;
			int_51 = 0;
		}
		else if (int_51 >= 8)
		{
			byte_0[int_21++] = (byte)short_6;
			short_6 >>= 8;
			int_51 -= 8;
		}
	}

	internal void method_16()
	{
		if (int_51 > 8)
		{
			byte_0[int_21++] = (byte)short_6;
			byte_0[int_21++] = (byte)(short_6 >> 8);
		}
		else if (int_51 > 0)
		{
			byte_0[int_21++] = (byte)short_6;
		}
		short_6 = 0;
		int_51 = 0;
	}

	internal void method_17(int int_52, int int_53, bool bool_2)
	{
		method_16();
		int_50 = 8;
		if (bool_2)
		{
			byte_0[int_21++] = (byte)int_53;
			byte_0[int_21++] = (byte)(int_53 >> 8);
			byte_0[int_21++] = (byte)(~int_53);
			byte_0[int_21++] = (byte)(~int_53 >> 8);
		}
		method_8(byte_1, int_52, int_53);
	}

	internal void method_18(bool bool_2)
	{
		method_21((int_32 >= 0) ? int_32 : (-1), int_36 - int_32, bool_2);
		int_32 = int_36;
		class765_0.method_9();
	}

	internal Enum36 method_19(Enum41 enum41_0)
	{
		int num = 65535;
		if (65535 > byte_0.Length - 5)
		{
			num = byte_0.Length - 5;
		}
		while (true)
		{
			if (int_38 <= 1)
			{
				method_22();
				if (int_38 == 0 && enum41_0 == Enum41.const_0)
				{
					return Enum36.const_0;
				}
				if (int_38 == 0)
				{
					method_18(enum41_0 == Enum41.const_4);
					if (class765_0.int_3 == 0)
					{
						if (enum41_0 != Enum41.const_4)
						{
							return Enum36.const_0;
						}
						return Enum36.const_2;
					}
					if (enum41_0 != Enum41.const_4)
					{
						return Enum36.const_1;
					}
					return Enum36.const_3;
				}
			}
			int_36 += int_38;
			int_38 = 0;
			int num2 = int_32 + num;
			if (int_36 == 0 || int_36 >= num2)
			{
				int_38 = int_36 - num2;
				int_36 = num2;
				method_18(bool_2: false);
				if (class765_0.int_3 == 0)
				{
					return Enum36.const_0;
				}
			}
			if (int_36 - int_32 >= int_23 - int_16)
			{
				method_18(bool_2: false);
				if (class765_0.int_3 == 0)
				{
					break;
				}
			}
		}
		return Enum36.const_0;
	}

	internal void method_20(int int_52, int int_53, bool bool_2)
	{
		method_10((int_7 << 1) + (bool_2 ? 1 : 0), 3);
		method_17(int_52, int_53, bool_2: true);
	}

	internal void method_21(int int_52, int int_53, bool bool_2)
	{
		int num = 0;
		int num2;
		int num3;
		if (enum42_0 > Enum42.const_0)
		{
			if (sbyte_0 == int_12)
			{
				method_14();
			}
			class760_0.method_1(this);
			class760_1.method_1(this);
			num = method_5();
			num2 = int_47 + 3 + 7 >> 3;
			num3 = int_48 + 3 + 7 >> 3;
			if (num3 <= num2)
			{
				num2 = num3;
			}
		}
		else
		{
			num2 = (num3 = int_53 + 5);
		}
		if (int_53 + 4 <= num2 && int_52 != -1)
		{
			method_20(int_52, int_53, bool_2);
		}
		else if (num3 == num2)
		{
			method_10((int_8 << 1) + (bool_2 ? 1 : 0), 3);
			method_13(Class763.short_0, Class763.short_1);
		}
		else
		{
			method_10((int_9 << 1) + (bool_2 ? 1 : 0), 3);
			method_6(class760_0.int_6 + 1, class760_1.int_6 + 1, num + 1);
			method_13(short_2, short_3);
		}
		method_2();
		if (bool_2)
		{
			method_16();
		}
	}

	private void method_22()
	{
		do
		{
			int num = int_26 - int_38 - int_36;
			if (num != 0 || int_36 != 0 || int_38 != 0)
			{
				if (num == -1)
				{
					num--;
				}
				else if (int_36 >= int_23 + int_23 - int_16)
				{
					Array.Copy(byte_1, int_23, byte_1, 0, int_23);
					int_37 -= int_23;
					int_36 -= int_23;
					int_32 -= int_23;
					int num2 = int_28;
					int num3 = num2;
					do
					{
						int num4 = short_1[--num3] & 0xFFFF;
						short_1[num3] = (short)((num4 >= int_23) ? (num4 - int_23) : 0);
					}
					while (--num2 != 0);
					num2 = int_23;
					num3 = num2;
					do
					{
						int num4 = short_0[--num3] & 0xFFFF;
						short_0[num3] = (short)((num4 >= int_23) ? (num4 - int_23) : 0);
					}
					while (--num2 != 0);
					num += int_23;
				}
			}
			else
			{
				num = int_23;
			}
			if (class765_0.int_1 != 0)
			{
				int num2 = class765_0.method_10(byte_1, int_36 + int_38, num);
				int_38 += num2;
				if (int_38 >= int_14)
				{
					int_27 = byte_1[int_36] & 0xFF;
					int_27 = ((int_27 << int_31) ^ (byte_1[int_36 + 1] & 0xFF)) & int_30;
				}
				continue;
			}
			break;
		}
		while (int_38 < int_16 && class765_0.int_1 != 0);
	}

	internal Enum36 method_23(Enum41 enum41_0)
	{
		int num = 0;
		while (true)
		{
			if (int_38 < int_16)
			{
				method_22();
				if (int_38 < int_16 && enum41_0 == Enum41.const_0)
				{
					return Enum36.const_0;
				}
				if (int_38 == 0)
				{
					method_18(enum41_0 == Enum41.const_4);
					if (class765_0.int_3 == 0)
					{
						if (enum41_0 == Enum41.const_4)
						{
							return Enum36.const_2;
						}
						return Enum36.const_0;
					}
					if (enum41_0 != Enum41.const_4)
					{
						return Enum36.const_1;
					}
					return Enum36.const_3;
				}
			}
			if (int_38 >= int_14)
			{
				int_27 = ((int_27 << int_31) ^ (byte_1[int_36 + (int_14 - 1)] & 0xFF)) & int_30;
				num = short_1[int_27] & 0xFFFF;
				short_0[int_36 & int_25] = short_1[int_27];
				short_1[int_27] = (short)int_36;
			}
			if ((long)num != 0 && ((int_36 - num) & 0xFFFF) <= int_23 - int_16 && enum43_0 != Enum43.const_2)
			{
				int_33 = method_25(num);
			}
			bool flag;
			if (int_33 >= int_14)
			{
				flag = method_12(int_36 - int_37, int_33 - int_14);
				int_38 -= int_33;
				if (int_33 <= class753_0.int_1 && int_38 >= int_14)
				{
					int_33--;
					do
					{
						int_36++;
						int_27 = ((int_27 << int_31) ^ (byte_1[int_36 + (int_14 - 1)] & 0xFF)) & int_30;
						num = short_1[int_27] & 0xFFFF;
						short_0[int_36 & int_25] = short_1[int_27];
						short_1[int_27] = (short)int_36;
					}
					while (--int_33 != 0);
					int_36++;
				}
				else
				{
					int_36 += int_33;
					int_33 = 0;
					int_27 = byte_1[int_36] & 0xFF;
					int_27 = ((int_27 << int_31) ^ (byte_1[int_36 + 1] & 0xFF)) & int_30;
				}
			}
			else
			{
				flag = method_12(0, byte_1[int_36] & 0xFF);
				int_38--;
				int_36++;
			}
			if (flag)
			{
				method_18(bool_2: false);
				if (class765_0.int_3 == 0)
				{
					break;
				}
			}
		}
		return Enum36.const_0;
	}

	internal Enum36 method_24(Enum41 enum41_0)
	{
		int num = 0;
		while (true)
		{
			if (int_38 < int_16)
			{
				method_22();
				if (int_38 < int_16 && enum41_0 == Enum41.const_0)
				{
					return Enum36.const_0;
				}
				if (int_38 == 0)
				{
					if (int_35 != 0)
					{
						bool flag = method_12(0, byte_1[int_36 - 1] & 0xFF);
						int_35 = 0;
					}
					method_18(enum41_0 == Enum41.const_4);
					if (class765_0.int_3 == 0)
					{
						if (enum41_0 == Enum41.const_4)
						{
							return Enum36.const_2;
						}
						return Enum36.const_0;
					}
					if (enum41_0 != Enum41.const_4)
					{
						return Enum36.const_1;
					}
					return Enum36.const_3;
				}
			}
			if (int_38 >= int_14)
			{
				int_27 = ((int_27 << int_31) ^ (byte_1[int_36 + (int_14 - 1)] & 0xFF)) & int_30;
				num = short_1[int_27] & 0xFFFF;
				short_0[int_36 & int_25] = short_1[int_27];
				short_1[int_27] = (short)int_36;
			}
			int_39 = int_33;
			int_34 = int_37;
			int_33 = int_14 - 1;
			if (num != 0 && int_39 < class753_0.int_1 && ((int_36 - num) & 0xFFFF) <= int_23 - int_16)
			{
				if (enum43_0 != Enum43.const_2)
				{
					int_33 = method_25(num);
				}
				if (int_33 <= 5 && (enum43_0 == Enum43.const_1 || (int_33 == int_14 && int_36 - int_37 > 4096)))
				{
					int_33 = int_14 - 1;
				}
			}
			if (int_39 >= int_14 && int_33 <= int_39)
			{
				int num2 = int_36 + int_38 - int_14;
				bool flag = method_12(int_36 - 1 - int_34, int_39 - int_14);
				int_38 -= int_39 - 1;
				int_39 -= 2;
				do
				{
					if (++int_36 <= num2)
					{
						int_27 = ((int_27 << int_31) ^ (byte_1[int_36 + (int_14 - 1)] & 0xFF)) & int_30;
						num = short_1[int_27] & 0xFFFF;
						short_0[int_36 & int_25] = short_1[int_27];
						short_1[int_27] = (short)int_36;
					}
				}
				while (--int_39 != 0);
				int_35 = 0;
				int_33 = int_14 - 1;
				int_36++;
				if (flag)
				{
					method_18(bool_2: false);
					if (class765_0.int_3 == 0)
					{
						return Enum36.const_0;
					}
				}
			}
			else if (int_35 != 0)
			{
				bool flag;
				if (flag = method_12(0, byte_1[int_36 - 1] & 0xFF))
				{
					method_18(bool_2: false);
				}
				int_36++;
				int_38--;
				if (class765_0.int_3 == 0)
				{
					break;
				}
			}
			else
			{
				int_35 = 1;
				int_36++;
				int_38--;
			}
		}
		return Enum36.const_0;
	}

	internal int method_25(int int_52)
	{
		int num = class753_0.int_3;
		int num2 = int_36;
		int num3 = int_39;
		int num4 = ((int_36 > int_23 - int_16) ? (int_36 - (int_23 - int_16)) : 0);
		int num5 = class753_0.int_2;
		int num6 = int_25;
		int num7 = int_36 + int_15;
		byte b = byte_1[num2 + num3 - 1];
		byte b2 = byte_1[num2 + num3];
		if (int_39 >= class753_0.int_0)
		{
			num >>= 2;
		}
		if (num5 > int_38)
		{
			num5 = int_38;
		}
		do
		{
			int num8 = int_52;
			if (byte_1[num8 + num3] != b2 || byte_1[num8 + num3 - 1] != b || byte_1[num8] != byte_1[num2] || byte_1[++num8] != byte_1[num2 + 1])
			{
				continue;
			}
			num2 += 2;
			num8++;
			while (byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && num2 < num7)
			{
			}
			int num9 = int_15 - (num7 - num2);
			num2 = num7 - int_15;
			if (num9 > num3)
			{
				int_37 = int_52;
				num3 = num9;
				if (num9 >= num5)
				{
					break;
				}
				b = byte_1[num2 + num3 - 1];
				b2 = byte_1[num2 + num3];
			}
		}
		while ((int_52 = short_0[int_52 & num6] & 0xFFFF) > num4 && --num != 0);
		if (num3 <= int_38)
		{
			return num3;
		}
		return int_38;
	}

	[SpecialName]
	internal bool method_26()
	{
		return bool_1;
	}

	[SpecialName]
	internal void method_27(bool bool_2)
	{
		bool_1 = bool_2;
	}

	internal int Initialize(Class765 class765_1, Enum42 enum42_1, int int_52, Enum43 enum43_1)
	{
		return Initialize(class765_1, enum42_1, int_52, int_1, enum43_1);
	}

	internal int Initialize(Class765 class765_1, Enum42 enum42_1, int int_52, int int_53, Enum43 enum43_1)
	{
		class765_0 = class765_1;
		class765_0.string_0 = null;
		if (int_52 >= 9 && int_52 <= 15)
		{
			if (int_53 < 1 || int_53 > int_0)
			{
				throw new Exception5($"memLevel must be in the range 1.. {int_0}");
			}
			class765_0.class752_0 = this;
			int_24 = int_52;
			int_23 = 1 << int_24;
			int_25 = int_23 - 1;
			int_29 = int_53 + 7;
			int_28 = 1 << int_29;
			int_30 = int_28 - 1;
			int_31 = (int_29 + int_14 - 1) / int_14;
			byte_1 = new byte[int_23 * 2];
			short_0 = new short[int_23];
			short_1 = new short[int_28];
			int_44 = 1 << int_53 + 6;
			byte_0 = new byte[int_44 * 4];
			int_46 = int_44;
			int_43 = 3 * int_44;
			enum42_0 = enum42_1;
			enum43_0 = enum43_1;
			Reset();
			return 0;
		}
		throw new Exception5("windowBits must be in the range 9..15.");
	}

	internal void Reset()
	{
		Class765 @class = class765_0;
		class765_0.long_1 = 0L;
		@class.long_0 = 0L;
		class765_0.string_0 = null;
		int_21 = 0;
		int_20 = 0;
		bool_0 = false;
		int_19 = (method_26() ? int_3 : int_4);
		class765_0.uint_0 = Class764.smethod_0(0u, null, 0, 0);
		int_22 = 0;
		method_1();
		method_0();
	}

	private void method_28()
	{
		switch (class753_0.enum37_0)
		{
		case Enum37.const_0:
			delegate4_0 = method_19;
			break;
		case Enum37.const_1:
			delegate4_0 = method_23;
			break;
		case Enum37.const_2:
			delegate4_0 = method_24;
			break;
		}
	}

	internal int method_29(Enum41 enum41_0)
	{
		if (class765_0.byte_1 != null && (class765_0.byte_0 != null || class765_0.int_1 == 0) && (int_19 != int_5 || enum41_0 == Enum41.const_4))
		{
			if (class765_0.int_3 == 0)
			{
				class765_0.string_0 = string_0[7];
				throw new Exception5("OutputBuffer is full (AvailableBytesOut == 0)");
			}
			int num = int_22;
			int_22 = (int)enum41_0;
			if (int_19 == int_3)
			{
				int num2 = int_6 + (int_24 - 8 << 4) << 8;
				int num3 = (int)((enum42_0 - 1) & (Enum42)255) >> 1;
				if (num3 > 3)
				{
					num3 = 3;
				}
				num2 |= num3 << 6;
				if (int_36 != 0)
				{
					num2 |= int_2;
				}
				num2 += 31 - num2 % 31;
				int_19 = int_4;
				byte_0[int_21++] = (byte)(num2 >> 8);
				byte_0[int_21++] = (byte)num2;
				if (int_36 != 0)
				{
					byte_0[int_21++] = (byte)((class765_0.uint_0 & 0xFF000000u) >> 24);
					byte_0[int_21++] = (byte)((class765_0.uint_0 & 0xFF0000) >> 16);
					byte_0[int_21++] = (byte)((class765_0.uint_0 & 0xFF00) >> 8);
					byte_0[int_21++] = (byte)(class765_0.uint_0 & 0xFFu);
				}
				class765_0.uint_0 = Class764.smethod_0(0u, null, 0, 0);
			}
			if (int_21 != 0)
			{
				class765_0.method_9();
				if (class765_0.int_3 == 0)
				{
					int_22 = -1;
					return 0;
				}
			}
			else if (class765_0.int_1 == 0 && (int)enum41_0 <= num && enum41_0 != Enum41.const_4)
			{
				return 0;
			}
			if (int_19 == int_5 && class765_0.int_1 != 0)
			{
				class765_0.string_0 = string_0[7];
				throw new Exception5("status == FINISH_STATE && _codec.AvailableBytesIn != 0");
			}
			if (class765_0.int_1 != 0 || int_38 != 0 || (enum41_0 != 0 && int_19 != int_5))
			{
				Enum36 @enum = delegate4_0(enum41_0);
				if (@enum == Enum36.const_2 || @enum == Enum36.const_3)
				{
					int_19 = int_5;
				}
				if (@enum == Enum36.const_0 || @enum == Enum36.const_2)
				{
					if (class765_0.int_3 == 0)
					{
						int_22 = -1;
					}
					return 0;
				}
				if (@enum == Enum36.const_1)
				{
					if (enum41_0 == Enum41.const_1)
					{
						method_11();
					}
					else
					{
						method_20(0, 0, bool_2: false);
						if (enum41_0 == Enum41.const_3)
						{
							for (int i = 0; i < int_28; i++)
							{
								short_1[i] = 0;
							}
						}
					}
					class765_0.method_9();
					if (class765_0.int_3 == 0)
					{
						int_22 = -1;
						return 0;
					}
				}
			}
			if (enum41_0 != Enum41.const_4)
			{
				return 0;
			}
			if (method_26() && !bool_0)
			{
				byte_0[int_21++] = (byte)((class765_0.uint_0 & 0xFF000000u) >> 24);
				byte_0[int_21++] = (byte)((class765_0.uint_0 & 0xFF0000) >> 16);
				byte_0[int_21++] = (byte)((class765_0.uint_0 & 0xFF00) >> 8);
				byte_0[int_21++] = (byte)(class765_0.uint_0 & 0xFFu);
				class765_0.method_9();
				bool_0 = true;
				if (int_21 == 0)
				{
					return 1;
				}
				return 0;
			}
			return 1;
		}
		class765_0.string_0 = string_0[4];
		throw new Exception5($"Something is fishy. [{class765_0.string_0}]");
	}
}
