using System;

namespace ns276;

internal sealed class Class6741
{
	internal delegate Enum899 Delegate2781(Enum898 flush);

	internal class Class6742
	{
		internal int int_0;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		internal Enum900 enum900_0;

		private static Class6742[] class6742_0;

		private Class6742(int goodLength, int maxLazy, int niceLength, int maxChainLength, Enum900 flavor)
		{
			int_0 = goodLength;
			int_1 = maxLazy;
			int_2 = niceLength;
			int_3 = maxChainLength;
			enum900_0 = flavor;
		}

		public static Class6742 smethod_0(Enum914 level)
		{
			return class6742_0[(int)level];
		}

		static Class6742()
		{
			class6742_0 = new Class6742[10]
			{
				new Class6742(0, 0, 0, 0, Enum900.const_0),
				new Class6742(4, 4, 8, 4, Enum900.const_1),
				new Class6742(4, 5, 16, 8, Enum900.const_1),
				new Class6742(4, 6, 32, 32, Enum900.const_1),
				new Class6742(4, 4, 16, 16, Enum900.const_2),
				new Class6742(8, 16, 32, 32, Enum900.const_2),
				new Class6742(8, 16, 128, 128, Enum900.const_2),
				new Class6742(8, 32, 128, 256, Enum900.const_2),
				new Class6742(32, 128, 258, 1024, Enum900.const_2),
				new Class6742(32, 258, 258, 4096, Enum900.const_2)
			};
		}
	}

	private const int int_0 = 9;

	private const int int_1 = 8;

	private const int int_2 = 32;

	private const int int_3 = 42;

	private const int int_4 = 113;

	private const int int_5 = 666;

	private const int int_6 = 8;

	private const int int_7 = 0;

	private const int int_8 = 1;

	private const int int_9 = 2;

	private const int int_10 = 0;

	private const int int_11 = 1;

	private const int int_12 = 2;

	private const int int_13 = 16;

	private const int int_14 = 16;

	private const int int_15 = 17;

	private const int int_16 = 18;

	private const int int_17 = 3;

	private const int int_18 = 258;

	private const int int_19 = 262;

	private const int int_20 = 15;

	private const int int_21 = 30;

	private const int int_22 = 19;

	private const int int_23 = 29;

	private const int int_24 = 256;

	private const int int_25 = 286;

	private const int int_26 = 573;

	private const int int_27 = 256;

	private Enum900 enum900_0;

	private static readonly string[] string_0 = new string[10]
	{
		"need dictionary",
		"stream end",
		string.Empty,
		"file error",
		"stream error",
		"data error",
		"insufficient memory",
		"buffer error",
		"incompatible version",
		string.Empty
	};

	internal Class6756 class6756_0;

	internal int int_28;

	internal byte[] byte_0;

	internal int int_29;

	internal int int_30;

	internal sbyte sbyte_0;

	internal int int_31;

	internal int int_32;

	internal int int_33;

	internal int int_34;

	internal byte[] byte_1;

	internal int int_35;

	internal short[] short_0;

	internal short[] short_1;

	internal int int_36;

	internal int int_37;

	internal int int_38;

	internal int int_39;

	internal int int_40;

	internal int int_41;

	private Class6742 class6742_0;

	internal int int_42;

	internal int int_43;

	internal int int_44;

	internal int int_45;

	internal int int_46;

	internal int int_47;

	internal int int_48;

	internal Enum914 enum914_0;

	internal Enum915 enum915_0;

	internal short[] short_2;

	internal short[] short_3;

	internal short[] short_4;

	internal Class6749 class6749_0 = new Class6749();

	internal Class6749 class6749_1 = new Class6749();

	internal Class6749 class6749_2 = new Class6749();

	internal short[] short_5 = new short[16];

	internal int[] int_49 = new int[573];

	internal int int_50;

	internal int int_51;

	internal sbyte[] sbyte_1 = new sbyte[573];

	internal int int_52;

	internal int int_53;

	internal int int_54;

	internal int int_55;

	internal int int_56;

	internal int int_57;

	internal int int_58;

	internal int int_59;

	internal short short_6;

	internal int int_60;

	private bool bool_0;

	private bool bool_1 = true;

	internal bool WantRfc1950HeaderBytes
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	internal Class6741()
	{
		short_2 = new short[1146];
		short_3 = new short[122];
		short_4 = new short[78];
	}

	private void method_0()
	{
		int_35 = 2 * int_32;
		for (int i = 0; i < int_37; i++)
		{
			short_1[i] = 0;
		}
		class6742_0 = Class6742.smethod_0(enum914_0);
		enum900_0 = class6742_0.enum900_0;
		int_45 = 0;
		int_41 = 0;
		int_47 = 0;
		int_48 = 2;
		int_42 = 2;
		int_44 = 0;
		int_36 = 0;
	}

	private void method_1()
	{
		class6749_0.short_0 = short_2;
		class6749_0.class6754_0 = Class6754.class6754_0;
		class6749_1.short_0 = short_3;
		class6749_1.class6754_0 = Class6754.class6754_1;
		class6749_2.short_0 = short_4;
		class6749_2.class6754_0 = Class6754.class6754_2;
		short_6 = 0;
		int_60 = 0;
		int_59 = 8;
		method_2();
	}

	internal void method_2()
	{
		for (int i = 0; i < 286; i++)
		{
			short_2[i * 2] = 0;
		}
		for (int j = 0; j < 30; j++)
		{
			short_3[j * 2] = 0;
		}
		for (int k = 0; k < 19; k++)
		{
			short_4[k * 2] = 0;
		}
		short_2[512] = 1;
		int_57 = 0;
		int_56 = 0;
		int_58 = 0;
		int_54 = 0;
	}

	internal void method_3(short[] tree, int k)
	{
		int num = int_49[k];
		for (int num2 = k << 1; num2 <= int_50; num2 <<= 1)
		{
			if (num2 < int_50 && smethod_0(tree, int_49[num2 + 1], int_49[num2], sbyte_1))
			{
				num2++;
			}
			if (smethod_0(tree, num, int_49[num2], sbyte_1))
			{
				break;
			}
			int_49[k] = int_49[num2];
			k = num2;
		}
		int_49[k] = num;
	}

	internal static bool smethod_0(short[] tree, int n, int m, sbyte[] depth)
	{
		short num = tree[n * 2];
		short num2 = tree[m * 2];
		if (num >= num2)
		{
			if (num == num2)
			{
				return depth[n] <= depth[m];
			}
			return false;
		}
		return true;
	}

	internal void method_4(short[] tree, int max_code)
	{
		int num = -1;
		int num2 = tree[1];
		int num3 = 0;
		int num4 = 7;
		int num5 = 4;
		if (num2 == 0)
		{
			num4 = 138;
			num5 = 3;
		}
		tree[(max_code + 1) * 2 + 1] = short.MaxValue;
		for (int i = 0; i <= max_code; i++)
		{
			int num6 = num2;
			num2 = tree[(i + 1) * 2 + 1];
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
				short_4[32]++;
			}
			else if (num3 <= 10)
			{
				short_4[34]++;
			}
			else
			{
				short_4[36]++;
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
		method_4(short_2, class6749_0.int_18);
		method_4(short_3, class6749_1.int_18);
		class6749_2.method_1(this);
		int num = 18;
		while (num >= 3 && short_4[Class6749.sbyte_0[num] * 2 + 1] == 0)
		{
			num--;
		}
		int_56 += 3 * (num + 1) + 5 + 5 + 4;
		return num;
	}

	internal void method_6(int lcodes, int dcodes, int blcodes)
	{
		method_13(lcodes - 257, 5);
		method_13(dcodes - 1, 5);
		method_13(blcodes - 4, 4);
		for (int i = 0; i < blcodes; i++)
		{
			method_13(short_4[Class6749.sbyte_0[i] * 2 + 1], 3);
		}
		method_7(short_2, lcodes - 1);
		method_7(short_3, dcodes - 1);
	}

	internal void method_7(short[] tree, int max_code)
	{
		int num = -1;
		int num2 = tree[1];
		int num3 = 0;
		int num4 = 7;
		int num5 = 4;
		if (num2 == 0)
		{
			num4 = 138;
			num5 = 3;
		}
		for (int i = 0; i <= max_code; i++)
		{
			int num6 = num2;
			num2 = tree[(i + 1) * 2 + 1];
			if (++num3 < num4 && num6 == num2)
			{
				continue;
			}
			if (num3 < num5)
			{
				do
				{
					method_12(num6, short_4);
				}
				while (--num3 != 0);
			}
			else if (num6 != 0)
			{
				if (num6 != num)
				{
					method_12(num6, short_4);
					num3--;
				}
				method_12(16, short_4);
				method_13(num3 - 3, 2);
			}
			else if (num3 <= 10)
			{
				method_12(17, short_4);
				method_13(num3 - 3, 3);
			}
			else
			{
				method_12(18, short_4);
				method_13(num3 - 11, 7);
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

	private void method_8(byte[] p, int start, int len)
	{
		Array.Copy(p, start, byte_0, int_30, len);
		int_30 += len;
	}

	private void method_9(byte c)
	{
		byte_0[int_30++] = c;
	}

	internal void method_10(int w)
	{
		method_9((byte)w);
		method_9((byte)Class6753.smethod_0(w, 8));
	}

	internal void method_11(int b)
	{
		method_9((byte)(b >> 8));
		method_9((byte)b);
	}

	internal void method_12(int c, short[] tree)
	{
		int num = c * 2;
		method_13(tree[num] & 0xFFFF, tree[num + 1] & 0xFFFF);
	}

	internal void method_13(int value, int length)
	{
		if (int_60 > 16 - length)
		{
			short_6 = (short)((short_6 & 0xFFFF) | ((value << int_60) & 0xFFFF));
			method_10(short_6);
			short_6 = (short)Class6753.smethod_0(value, 16 - int_60);
			int_60 += length - 16;
		}
		else
		{
			short_6 = (short)((short_6 & 0xFFFF) | ((value << int_60) & 0xFFFF));
			int_60 += length;
		}
	}

	internal void method_14()
	{
		method_13(2, 3);
		method_12(256, Class6754.short_0);
		method_18();
		if (1 + int_59 + 10 - int_60 < 9)
		{
			method_13(2, 3);
			method_12(256, Class6754.short_0);
			method_18();
		}
		int_59 = 7;
	}

	internal bool method_15(int dist, int lc)
	{
		byte_0[int_55 + int_54 * 2] = (byte)Class6753.smethod_0(dist, 8);
		byte_0[int_55 + int_54 * 2 + 1] = (byte)dist;
		byte_0[int_52 + int_54] = (byte)lc;
		int_54++;
		if (dist == 0)
		{
			short_2[lc * 2]++;
		}
		else
		{
			int_58++;
			dist--;
			short_2[(Class6749.sbyte_2[lc] + 256 + 1) * 2]++;
			short_3[Class6749.smethod_0(dist) * 2]++;
		}
		if ((int_54 & 0x1FFF) == 0 && enum914_0 > Enum914.const_4)
		{
			int num = int_54 * 8;
			int num2 = int_45 - int_41;
			for (int i = 0; i < 30; i++)
			{
				num = (int)(num + short_3[i * 2] * (5L + Class6749.int_14[i]));
			}
			num = Class6753.smethod_0(num, 3);
			if (int_58 < int_54 / 2 && num < num2 / 2)
			{
				return true;
			}
		}
		if (int_54 != int_53 - 1)
		{
			return int_54 == int_53;
		}
		return true;
	}

	internal void method_16(short[] ltree, short[] dtree)
	{
		int num = 0;
		if (int_54 != 0)
		{
			do
			{
				int num2 = int_55 + num * 2;
				int num3 = ((byte_0[num2] << 8) & 0xFF00) | (byte_0[num2 + 1] & 0xFF);
				int num4 = byte_0[int_52 + num] & 0xFF;
				num++;
				if (num3 != 0)
				{
					int num5 = Class6749.sbyte_2[num4];
					method_12(num5 + 256 + 1, ltree);
					int num6 = Class6749.int_13[num5];
					if (num6 != 0)
					{
						num4 -= Class6749.int_16[num5];
						method_13(num4, num6);
					}
					num3--;
					num5 = Class6749.smethod_0(num3);
					method_12(num5, dtree);
					num6 = Class6749.int_14[num5];
					if (num6 != 0)
					{
						num3 -= Class6749.int_17[num5];
						method_13(num3, num6);
					}
				}
				else
				{
					method_12(num4, ltree);
				}
			}
			while (num < int_54);
		}
		method_12(256, ltree);
		int_59 = ltree[513];
	}

	internal void method_17()
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
		for (; i < 256; i++)
		{
			num2 += short_2[i * 2];
		}
		sbyte_0 = (sbyte)((num2 <= Class6753.smethod_0(num, 2)) ? 1 : 0);
	}

	internal void method_18()
	{
		if (int_60 == 16)
		{
			method_10(short_6);
			short_6 = 0;
			int_60 = 0;
		}
		else if (int_60 >= 8)
		{
			method_9((byte)short_6);
			short_6 = (short)Class6753.smethod_0(short_6, 8);
			int_60 -= 8;
		}
	}

	internal void method_19()
	{
		if (int_60 > 8)
		{
			method_10(short_6);
		}
		else if (int_60 > 0)
		{
			method_9((byte)short_6);
		}
		short_6 = 0;
		int_60 = 0;
	}

	internal void method_20(int buf, int len, bool header)
	{
		method_19();
		int_59 = 8;
		if (header)
		{
			method_10((short)len);
			method_10((short)(~len));
		}
		method_8(byte_1, buf, len);
	}

	internal void method_21(bool eof)
	{
		method_24((int_41 >= 0) ? int_41 : (-1), int_45 - int_41, eof);
		int_41 = int_45;
		class6756_0.method_18();
	}

	internal Enum899 method_22(Enum898 flush)
	{
		int num = 65535;
		if (65535 > byte_0.Length - 5)
		{
			num = byte_0.Length - 5;
		}
		while (true)
		{
			if (int_47 <= 1)
			{
				method_25();
				if (int_47 == 0 && flush == Enum898.const_0)
				{
					return Enum899.const_0;
				}
				if (int_47 == 0)
				{
					method_21(flush == Enum898.const_4);
					if (class6756_0.int_3 == 0)
					{
						if (flush != Enum898.const_4)
						{
							return Enum899.const_0;
						}
						return Enum899.const_2;
					}
					if (flush != Enum898.const_4)
					{
						return Enum899.const_1;
					}
					return Enum899.const_3;
				}
			}
			int_45 += int_47;
			int_47 = 0;
			int num2 = int_41 + num;
			if (int_45 == 0 || int_45 >= num2)
			{
				int_47 = int_45 - num2;
				int_45 = num2;
				method_21(eof: false);
				if (class6756_0.int_3 == 0)
				{
					return Enum899.const_0;
				}
			}
			if (int_45 - int_41 >= int_32 - 262)
			{
				method_21(eof: false);
				if (class6756_0.int_3 == 0)
				{
					break;
				}
			}
		}
		return Enum899.const_0;
	}

	internal void method_23(int buf, int stored_len, bool eof)
	{
		method_13(eof ? 1 : 0, 3);
		method_20(buf, stored_len, header: true);
	}

	internal void method_24(int buf, int stored_len, bool eof)
	{
		int num = 0;
		int num2;
		int num3;
		if (enum914_0 > Enum914.const_0)
		{
			if (sbyte_0 == 2)
			{
				method_17();
			}
			class6749_0.method_1(this);
			class6749_1.method_1(this);
			num = method_5();
			num2 = Class6753.smethod_0(int_56 + 3 + 7, 3);
			num3 = Class6753.smethod_0(int_57 + 3 + 7, 3);
			if (num3 <= num2)
			{
				num2 = num3;
			}
		}
		else
		{
			num2 = (num3 = stored_len + 5);
		}
		if (stored_len + 4 <= num2 && buf != -1)
		{
			method_23(buf, stored_len, eof);
		}
		else if (num3 == num2)
		{
			method_13(2 + (eof ? 1 : 0), 3);
			method_16(Class6754.short_0, Class6754.short_1);
		}
		else
		{
			method_13(4 + (eof ? 1 : 0), 3);
			method_6(class6749_0.int_18 + 1, class6749_1.int_18 + 1, num + 1);
			method_16(short_2, short_3);
		}
		method_2();
		if (eof)
		{
			method_19();
		}
	}

	private void method_25()
	{
		do
		{
			int num = int_35 - int_47 - int_45;
			if (num != 0 || int_45 != 0 || int_47 != 0)
			{
				if (num == -1)
				{
					num--;
				}
				else if (int_45 >= int_32 + int_32 - 262)
				{
					Array.Copy(byte_1, int_32, byte_1, 0, int_32);
					int_46 -= int_32;
					int_45 -= int_32;
					int_41 -= int_32;
					int num2 = int_37;
					int num3 = num2;
					do
					{
						int num4 = short_1[--num3] & 0xFFFF;
						short_1[num3] = (short)((num4 >= int_32) ? (num4 - int_32) : 0);
					}
					while (--num2 != 0);
					num2 = int_32;
					num3 = num2;
					do
					{
						int num4 = short_0[--num3] & 0xFFFF;
						short_0[num3] = (short)((num4 >= int_32) ? (num4 - int_32) : 0);
					}
					while (--num2 != 0);
					num += int_32;
				}
			}
			else
			{
				num = int_32;
			}
			if (class6756_0.int_1 != 0)
			{
				int num2 = class6756_0.method_19(byte_1, int_45 + int_47, num);
				int_47 += num2;
				if (int_47 >= 3)
				{
					int_36 = byte_1[int_45] & 0xFF;
					int_36 = ((int_36 << int_40) ^ (byte_1[int_45 + 1] & 0xFF)) & int_39;
				}
				continue;
			}
			break;
		}
		while (int_47 < 262 && class6756_0.int_1 != 0);
	}

	internal Enum899 method_26(Enum898 flush)
	{
		int num = 0;
		while (true)
		{
			if (int_47 < 262)
			{
				method_25();
				if (int_47 < 262 && flush == Enum898.const_0)
				{
					return Enum899.const_0;
				}
				if (int_47 == 0)
				{
					method_21(flush == Enum898.const_4);
					if (class6756_0.int_3 == 0)
					{
						if (flush == Enum898.const_4)
						{
							return Enum899.const_2;
						}
						return Enum899.const_0;
					}
					if (flush != Enum898.const_4)
					{
						return Enum899.const_1;
					}
					return Enum899.const_3;
				}
			}
			if (int_47 >= 3)
			{
				int_36 = ((int_36 << int_40) ^ (byte_1[int_45 + 2] & 0xFF)) & int_39;
				num = short_1[int_36] & 0xFFFF;
				short_0[int_45 & int_34] = short_1[int_36];
				short_1[int_36] = (short)int_45;
			}
			if (num != 0L && ((int_45 - num) & 0xFFFF) <= int_32 - 262 && enum915_0 != Enum915.const_2)
			{
				int_42 = method_28(num);
			}
			bool flag;
			if (int_42 >= 3)
			{
				flag = method_15(int_45 - int_46, int_42 - 3);
				int_47 -= int_42;
				if (int_42 <= class6742_0.int_1 && int_47 >= 3)
				{
					int_42--;
					do
					{
						int_45++;
						int_36 = ((int_36 << int_40) ^ (byte_1[int_45 + 2] & 0xFF)) & int_39;
						num = short_1[int_36] & 0xFFFF;
						short_0[int_45 & int_34] = short_1[int_36];
						short_1[int_36] = (short)int_45;
					}
					while (--int_42 != 0);
					int_45++;
				}
				else
				{
					int_45 += int_42;
					int_42 = 0;
					int_36 = byte_1[int_45] & 0xFF;
					int_36 = ((int_36 << int_40) ^ (byte_1[int_45 + 1] & 0xFF)) & int_39;
				}
			}
			else
			{
				flag = method_15(0, byte_1[int_45] & 0xFF);
				int_47--;
				int_45++;
			}
			if (flag)
			{
				method_21(eof: false);
				if (class6756_0.int_3 == 0)
				{
					break;
				}
			}
		}
		return Enum899.const_0;
	}

	internal Enum899 method_27(Enum898 flush)
	{
		int num = 0;
		while (true)
		{
			if (int_47 < 262)
			{
				method_25();
				if (int_47 < 262 && flush == Enum898.const_0)
				{
					return Enum899.const_0;
				}
				if (int_47 == 0)
				{
					if (int_44 != 0)
					{
						bool flag = method_15(0, byte_1[int_45 - 1] & 0xFF);
						int_44 = 0;
					}
					method_21(flush == Enum898.const_4);
					if (class6756_0.int_3 == 0)
					{
						if (flush == Enum898.const_4)
						{
							return Enum899.const_2;
						}
						return Enum899.const_0;
					}
					if (flush != Enum898.const_4)
					{
						return Enum899.const_1;
					}
					return Enum899.const_3;
				}
			}
			if (int_47 >= 3)
			{
				int_36 = ((int_36 << int_40) ^ (byte_1[int_45 + 2] & 0xFF)) & int_39;
				num = short_1[int_36] & 0xFFFF;
				short_0[int_45 & int_34] = short_1[int_36];
				short_1[int_36] = (short)int_45;
			}
			int_48 = int_42;
			int_43 = int_46;
			int_42 = 2;
			if (num != 0 && int_48 < class6742_0.int_1 && ((int_45 - num) & 0xFFFF) <= int_32 - 262)
			{
				if (enum915_0 != Enum915.const_2)
				{
					int_42 = method_28(num);
				}
				if (int_42 <= 5 && (enum915_0 == Enum915.const_1 || (int_42 == 3 && int_45 - int_46 > 4096)))
				{
					int_42 = 2;
				}
			}
			if (int_48 >= 3 && int_42 <= int_48)
			{
				int num2 = int_45 + int_47 - 3;
				bool flag = method_15(int_45 - 1 - int_43, int_48 - 3);
				int_47 -= int_48 - 1;
				int_48 -= 2;
				do
				{
					if (++int_45 <= num2)
					{
						int_36 = ((int_36 << int_40) ^ (byte_1[int_45 + 2] & 0xFF)) & int_39;
						num = short_1[int_36] & 0xFFFF;
						short_0[int_45 & int_34] = short_1[int_36];
						short_1[int_36] = (short)int_45;
					}
				}
				while (--int_48 != 0);
				int_44 = 0;
				int_42 = 2;
				int_45++;
				if (flag)
				{
					method_21(eof: false);
					if (class6756_0.int_3 == 0)
					{
						return Enum899.const_0;
					}
				}
			}
			else if (int_44 != 0)
			{
				bool flag;
				if (flag = method_15(0, byte_1[int_45 - 1] & 0xFF))
				{
					method_21(eof: false);
				}
				int_45++;
				int_47--;
				if (class6756_0.int_3 == 0)
				{
					break;
				}
			}
			else
			{
				int_44 = 1;
				int_45++;
				int_47--;
			}
		}
		return Enum899.const_0;
	}

	internal int method_28(int cur_match)
	{
		int num = class6742_0.int_3;
		int num2 = int_45;
		int num3 = int_48;
		int num4 = ((int_45 > int_32 - 262) ? (int_45 - (int_32 - 262)) : 0);
		int num5 = class6742_0.int_2;
		int num6 = int_34;
		int num7 = int_45 + 258;
		byte b = byte_1[num2 + num3 - 1];
		byte b2 = byte_1[num2 + num3];
		if (int_48 >= class6742_0.int_0)
		{
			num >>= 2;
		}
		if (num5 > int_47)
		{
			num5 = int_47;
		}
		do
		{
			int num8 = cur_match;
			if (byte_1[num8 + num3] != b2 || byte_1[num8 + num3 - 1] != b || byte_1[num8] != byte_1[num2] || byte_1[++num8] != byte_1[num2 + 1])
			{
				continue;
			}
			num2 += 2;
			num8++;
			while (byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && byte_1[++num2] == byte_1[++num8] && num2 < num7)
			{
			}
			int num9 = 258 - (num7 - num2);
			num2 = num7 - 258;
			if (num9 > num3)
			{
				int_46 = cur_match;
				num3 = num9;
				if (num9 >= num5)
				{
					break;
				}
				b = byte_1[num2 + num3 - 1];
				b2 = byte_1[num2 + num3];
			}
		}
		while ((cur_match = short_0[cur_match & num6] & 0xFFFF) > num4 && --num != 0);
		if (num3 <= int_47)
		{
			return num3;
		}
		return int_47;
	}

	internal int Initialize(Class6756 codec, Enum914 level)
	{
		return Initialize(codec, level, 15);
	}

	internal int Initialize(Class6756 codec, Enum914 level, int bits)
	{
		return Initialize(codec, level, bits, 8, Enum915.const_0);
	}

	internal int Initialize(Class6756 codec, Enum914 level, int bits, Enum915 compressionStrategy)
	{
		return Initialize(codec, level, bits, 8, compressionStrategy);
	}

	internal int Initialize(Class6756 codec, Enum914 level, int windowBits, int memLevel, Enum915 strategy)
	{
		class6756_0 = codec;
		class6756_0.string_0 = null;
		if (windowBits >= 9 && windowBits <= 15)
		{
			if (memLevel < 1 || memLevel > 9)
			{
				throw new Exception67($"memLevel must be in the range 1.. {9}");
			}
			class6756_0.class6741_0 = this;
			int_33 = windowBits;
			int_32 = 1 << int_33;
			int_34 = int_32 - 1;
			int_38 = memLevel + 7;
			int_37 = 1 << int_38;
			int_39 = int_37 - 1;
			int_40 = (int_38 + 3 - 1) / 3;
			byte_1 = new byte[int_32 * 2];
			short_0 = new short[int_32];
			short_1 = new short[int_37];
			int_53 = 1 << memLevel + 6;
			byte_0 = new byte[int_53 * 4];
			int_55 = int_53;
			int_52 = 3 * int_53;
			enum914_0 = level;
			enum915_0 = strategy;
			Reset();
			return 0;
		}
		throw new Exception67("windowBits must be in the range 9..15.");
	}

	internal void Reset()
	{
		Class6756 @class = class6756_0;
		class6756_0.long_1 = 0L;
		@class.long_0 = 0L;
		class6756_0.string_0 = null;
		int_30 = 0;
		int_29 = 0;
		bool_0 = false;
		int_28 = (WantRfc1950HeaderBytes ? 42 : 113);
		class6756_0.long_2 = Class6755.smethod_0(0L, null, 0, 0);
		int_31 = 0;
		method_1();
		method_0();
	}

	internal int method_29()
	{
		if (int_28 != 42 && int_28 != 113 && int_28 != 666)
		{
			return -2;
		}
		byte_0 = null;
		short_1 = null;
		short_0 = null;
		byte_1 = null;
		if (int_28 != 113)
		{
			return 0;
		}
		return -3;
	}

	internal int method_30(Enum914 level, Enum915 strategy)
	{
		int result = 0;
		if (enum914_0 != level)
		{
			Class6742 @class = Class6742.smethod_0(level);
			if (@class.enum900_0 != class6742_0.enum900_0 && class6756_0.long_0 != 0L)
			{
				result = class6756_0.method_13(Enum898.const_1);
			}
			enum914_0 = level;
			class6742_0 = @class;
			enum900_0 = class6742_0.enum900_0;
		}
		enum915_0 = strategy;
		return result;
	}

	internal int method_31(byte[] dictionary)
	{
		int num = dictionary.Length;
		int sourceIndex = 0;
		if (dictionary != null && int_28 == 42)
		{
			class6756_0.long_2 = Class6755.smethod_0(class6756_0.long_2, dictionary, 0, dictionary.Length);
			if (num < 3)
			{
				return 0;
			}
			if (num > int_32 - 262)
			{
				num = int_32 - 262;
				sourceIndex = dictionary.Length - num;
			}
			Array.Copy(dictionary, sourceIndex, byte_1, 0, num);
			int_45 = num;
			int_41 = num;
			int_36 = byte_1[0] & 0xFF;
			int_36 = ((int_36 << int_40) ^ (byte_1[1] & 0xFF)) & int_39;
			for (int i = 0; i <= num - 3; i++)
			{
				int_36 = ((int_36 << int_40) ^ (byte_1[i + 2] & 0xFF)) & int_39;
				short_0[i & int_34] = short_1[int_36];
				short_1[int_36] = (short)i;
			}
			return 0;
		}
		throw new Exception67("Stream error.");
	}

	internal int method_32(Enum898 flush)
	{
		if (class6756_0.byte_1 != null && (class6756_0.byte_0 != null || class6756_0.int_1 == 0) && (int_28 != 666 || flush == Enum898.const_4))
		{
			if (class6756_0.int_3 == 0)
			{
				class6756_0.string_0 = string_0[7];
				throw new Exception67("OutputBuffer is full (AvailableBytesOut == 0)");
			}
			int num = int_31;
			int_31 = (int)flush;
			if (int_28 == 42)
			{
				int num2 = 8 + (int_33 - 8 << 4) << 8;
				int num3 = (int)((enum914_0 - 1) & (Enum914)255) >> 1;
				if (num3 > 3)
				{
					num3 = 3;
				}
				num2 |= num3 << 6;
				if (int_45 != 0)
				{
					num2 |= 0x20;
				}
				num2 += 31 - num2 % 31;
				int_28 = 113;
				method_11(num2);
				if (int_45 != 0)
				{
					method_11((int)Class6753.smethod_1(class6756_0.long_2, 16));
					method_11((int)(class6756_0.long_2 & 0xFFFFL));
				}
				class6756_0.long_2 = Class6755.smethod_0(0L, null, 0, 0);
			}
			if (int_30 != 0)
			{
				class6756_0.method_18();
				if (class6756_0.int_3 == 0)
				{
					int_31 = -1;
					return 0;
				}
			}
			else if (class6756_0.int_1 == 0 && (int)flush <= num && flush != Enum898.const_4)
			{
				return 0;
			}
			if (int_28 == 666 && class6756_0.int_1 != 0)
			{
				class6756_0.string_0 = string_0[7];
				throw new Exception67("status == FINISH_STATE && _codec.AvailableBytesIn != 0");
			}
			if (class6756_0.int_1 != 0 || int_47 != 0 || (flush != 0 && int_28 != 666))
			{
				Enum899 @enum = enum900_0 switch
				{
					Enum900.const_0 => method_22(flush), 
					Enum900.const_1 => method_26(flush), 
					_ => method_27(flush), 
				};
				if (@enum == Enum899.const_2 || @enum == Enum899.const_3)
				{
					int_28 = 666;
				}
				if (@enum == Enum899.const_0 || @enum == Enum899.const_2)
				{
					if (class6756_0.int_3 == 0)
					{
						int_31 = -1;
					}
					return 0;
				}
				if (@enum == Enum899.const_1)
				{
					if (flush == Enum898.const_1)
					{
						method_14();
					}
					else
					{
						method_23(0, 0, eof: false);
						if (flush == Enum898.const_3)
						{
							for (int i = 0; i < int_37; i++)
							{
								short_1[i] = 0;
							}
						}
					}
					class6756_0.method_18();
					if (class6756_0.int_3 == 0)
					{
						int_31 = -1;
						return 0;
					}
				}
			}
			if (flush != Enum898.const_4)
			{
				return 0;
			}
			if (WantRfc1950HeaderBytes && !bool_0)
			{
				method_11((int)Class6753.smethod_1(class6756_0.long_2, 16));
				method_11((int)(class6756_0.long_2 & 0xFFFFL));
				class6756_0.method_18();
				bool_0 = true;
				if (int_30 == 0)
				{
					return 1;
				}
				return 0;
			}
			return 1;
		}
		class6756_0.string_0 = string_0[4];
		throw new Exception67($"Something is fishy. [{class6756_0.string_0}]");
	}
}
