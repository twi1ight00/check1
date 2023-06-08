using System;
using System.Text;

namespace ns33;

internal class Class1153
{
	public enum Enum175 : byte
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
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14,
		const_15,
		const_16,
		const_17,
		const_18
	}

	public enum Enum177 : byte
	{
		const_0,
		const_1,
		const_2,
		const_3
	}

	public enum Enum176
	{
		const_0,
		const_1,
		const_2
	}

	private const byte byte_0 = 31;

	private const byte byte_1 = 32;

	private const byte byte_2 = 64;

	private const byte byte_3 = 128;

	private const int int_0 = 8;

	private const ushort ushort_0 = 1024;

	private const ushort ushort_1 = 2048;

	public const char char_0 = '\u202d';

	public const char char_1 = '\u202e';

	public const char char_2 = '\u202c';

	public const char char_3 = '\u200d';

	public const char char_4 = '\u00a0';

	private static Class1152[] class1152_0;

	private static ushort[] ushort_2;

	private static char[] char_5;

	private static readonly Enum176[] enum176_0;

	private static readonly short[] short_0;

	private static readonly short[] short_1;

	private static readonly char[] char_6;

	private static readonly char[] char_7;

	private static readonly char[] char_8;

	private static readonly ushort[] ushort_3;

	private static readonly ushort[] ushort_4;

	private static readonly char[] char_9;

	private static readonly char[] char_10;

	private static readonly char[] char_11;

	private static readonly char[] char_12;

	internal static void smethod_0()
	{
		int num = char_8.Length / 5;
		for (int i = 0; i < 256; i++)
		{
			class1152_0[i] = null;
		}
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < 5; j++)
			{
				char c = char_8[i * 5 + j];
				if (c != 0)
				{
					byte b = (byte)((uint)((int)c >> 8) & 0xFFu);
					if (class1152_0[b] == null)
					{
						class1152_0[b] = new Class1152();
					}
					class1152_0[b].int_0[c & 0xFF] = i;
				}
			}
		}
		num = char_6.Length;
		for (int i = 0; i < num; i++)
		{
			char c = char_6[i];
			byte b = (byte)((uint)((int)c >> 8) & 0xFFu);
			if (class1152_0[b] == null)
			{
				class1152_0[b] = new Class1152();
			}
			class1152_0[b].bool_0[c & 0xFF] = true;
		}
		num = char_7.Length;
		for (int i = 0; i < num; i++)
		{
			char c = char_7[i];
			byte b = (byte)((uint)((int)c >> 8) & 0xFFu);
			if (class1152_0[b] == null)
			{
				class1152_0[b] = new Class1152();
			}
			class1152_0[b].bool_1[c & 0xFF] = true;
		}
	}

	internal static bool smethod_1(char valchar)
	{
		int num = ((int)valchar >> 8) & 0xFF;
		if (class1152_0[num] == null)
		{
			return false;
		}
		return class1152_0[num].bool_0[valchar & 0xFF];
	}

	internal static bool smethod_2(char valchar)
	{
		int num = ((int)valchar >> 8) & 0xFF;
		if (class1152_0[num] == null)
		{
			return false;
		}
		return class1152_0[num].bool_1[valchar & 0xFF];
	}

	public static bool smethod_3(char c)
	{
		return (ushort_2[(uint)c] & 0x40) == 64;
	}

	public static bool smethod_4(char c)
	{
		return smethod_5(c) == Enum177.const_1;
	}

	public static Enum177 smethod_5(char c)
	{
		return (Enum177)((uint)(ushort_2[(uint)c] >> 8) & 3u);
	}

	internal static void smethod_6(ref char valchar, byte postype)
	{
		if (smethod_13(valchar) == Enum176.const_0)
		{
			return;
		}
		int num = ((int)valchar >> 8) & 0xFF;
		if (class1152_0[num] == null)
		{
			return;
		}
		int num2 = class1152_0[num].int_0[valchar & 0xFF];
		if (num2 >= 0)
		{
			char c = char_8[num2 * 5 + 4 - postype];
			if (c > '\0')
			{
				valchar = c;
			}
		}
	}

	public static string smethod_7(char[] chars, int commonlength, byte[] levels, int charoffset)
	{
		bool flag = (levels[charoffset] & 1) != 0;
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2 = 0;
		while (num < commonlength)
		{
			byte b = levels[charoffset + num];
			if ((b & 0x30u) != 0)
			{
				if (num - num2 > 0)
				{
					if (flag)
					{
						Array.Reverse(chars, num2, num - num2);
						stringBuilder.Insert(0, chars, num2, num - num2);
					}
					else
					{
						stringBuilder.Append(chars, num2, num - num2);
					}
				}
				if ((b & 0x30) == 16)
				{
					num2 = num;
					bool flag2 = (b & 4) == 0;
					do
					{
						num++;
						b = levels[charoffset + num];
					}
					while ((b & 0x10u) != 0);
					num++;
					string text = "";
					int num3 = 1;
					if (chars[num2] == 'ل')
					{
						int num4 = (flag2 ? 1 : 0);
						if (chars[num2 + 1] == 'آ')
						{
							text = string.Concat((char)(65269 + num4));
						}
						if (chars[num2 + 1] == 'أ')
						{
							text = string.Concat((char)(65271 + num4));
						}
						if (chars[num2 + 1] == 'إ')
						{
							text = string.Concat((char)(65273 + num4));
						}
						if (chars[num2 + 1] == 'ا')
						{
							text = string.Concat((char)(65275 + num4));
						}
						num3 = 2;
					}
					if (num - num2 - num3 > 1)
					{
						text = new string(' ', num - num2 - num3 - 1) + text;
					}
					text = ((!flag2) ? ("\u202e" + text + "\u202c") : ("\u202e\u200d" + text + "\u202c"));
					if (text.Length > 0)
					{
						if (flag)
						{
							stringBuilder.Insert(0, text);
						}
						else
						{
							stringBuilder.Append(text);
						}
					}
				}
				else
				{
					num++;
				}
				num2 = num;
			}
			else
			{
				smethod_6(ref chars[num], (byte)((uint)(b >> 2) & 3u));
				if (flag)
				{
					chars[num] = smethod_18(chars[num]);
				}
				num++;
			}
		}
		if (num - num2 > 0)
		{
			if (flag)
			{
				Array.Reverse(chars, num2, num - num2);
				stringBuilder.Insert(0, chars, num2, num - num2);
			}
			else
			{
				stringBuilder.Append(chars, num2, num - num2);
			}
		}
		if (flag && stringBuilder.Length > 1)
		{
			for (int i = 0; i < stringBuilder.Length; i++)
			{
				if (smethod_13(stringBuilder[i]) == Enum176.const_2)
				{
					stringBuilder.Insert(0, string.Concat('\u202d'));
					stringBuilder.Append(string.Concat('\u202c'));
					break;
				}
			}
		}
		return stringBuilder.ToString();
	}

	public static void smethod_8(ref string text)
	{
		int length = text.Length;
		if (length < 2)
		{
			return;
		}
		byte[] levels = new byte[length];
		Enum175[] array = new Enum175[length];
		for (int i = 0; i < length; i++)
		{
			array[i] = smethod_11(text[i]);
			levels[i] = 3;
		}
		smethod_9(array, ref levels);
		int num = 0;
		StringBuilder stringBuilder = new StringBuilder();
		char[] sourceArray = text.ToCharArray();
		bool flag = (levels[0] & 1) != 0;
		for (int j = 0; j < length; j++)
		{
			bool flag2 = (levels[j] & 1) != 0;
			if (flag != flag2)
			{
				if (j - num > 0)
				{
					char[] array2 = new char[j - num];
					Array.Copy(sourceArray, num, array2, 0, j - num);
					stringBuilder.Insert(0, smethod_7(array2, j - num, levels, num));
				}
				num = j;
				flag = flag2;
			}
		}
		if (length - num > 0)
		{
			char[] array3 = new char[length - num];
			Array.Copy(sourceArray, num, array3, 0, length - num);
			stringBuilder.Insert(0, smethod_7(array3, length - num, levels, num));
		}
	}

	public static void smethod_9(Enum175[] bidiTypes, ref byte[] levels)
	{
		int num = bidiTypes.Length;
		int num2 = 0;
		Enum175 @enum = ((((uint)levels[0] & (true ? 1u : 0u)) != 0) ? Enum175.const_3 : Enum175.const_0);
		while (num2 < num)
		{
			int i = num2;
			bool flag;
			for (flag = (levels[num2] & 1) != 0; i < num && (levels[i] & 1) != 0 == flag; i++)
			{
			}
			bool flag2 = flag ^ (i < num);
			Enum175 enum2 = (flag ? Enum175.const_3 : Enum175.const_0);
			Enum175 enum3 = @enum;
			int j;
			for (j = num2; j < i; j++)
			{
				if (bidiTypes[j] == Enum175.const_13)
				{
					bidiTypes[j] = @enum;
				}
				else if (bidiTypes[j] == Enum175.const_8 && enum3 == Enum175.const_4)
				{
					bidiTypes[j] = Enum175.const_11;
				}
				@enum = bidiTypes[j];
				if (bidiTypes[j] == Enum175.const_4)
				{
					bidiTypes[j] = Enum175.const_3;
				}
				if (smethod_16(@enum))
				{
					enum3 = @enum;
				}
			}
			for (j = num2 + 1; j < i - 1; j++)
			{
				if (bidiTypes[j] == Enum175.const_9)
				{
					if (bidiTypes[j - 1] == Enum175.const_8 && bidiTypes[j + 1] == Enum175.const_8)
					{
						bidiTypes[j] = Enum175.const_8;
					}
				}
				else if (bidiTypes[j] == Enum175.const_12 && bidiTypes[j - 1] == bidiTypes[j + 1] && (bidiTypes[j - 1] == Enum175.const_11 || bidiTypes[j - 1] == Enum175.const_8))
				{
					bidiTypes[j] = bidiTypes[j - 1];
				}
			}
			if (bidiTypes[num2] == Enum175.const_9 || bidiTypes[num2] == Enum175.const_12)
			{
				bidiTypes[num2] = Enum175.const_18;
			}
			if (bidiTypes[i - 1] == Enum175.const_9 || bidiTypes[i - 1] == Enum175.const_12)
			{
				bidiTypes[i - 1] = Enum175.const_18;
			}
			@enum = enum2;
			for (j = num2 + 1; j < i; j++)
			{
				if (bidiTypes[j] == Enum175.const_10 && @enum == Enum175.const_8)
				{
					bidiTypes[j] = Enum175.const_8;
				}
				@enum = bidiTypes[j];
			}
			@enum = (flag2 ? Enum175.const_3 : Enum175.const_0);
			for (j = i - 1; j >= num2; j--)
			{
				if (bidiTypes[j] == Enum175.const_10 && @enum == Enum175.const_8)
				{
					bidiTypes[j] = Enum175.const_8;
				}
				@enum = bidiTypes[j];
			}
			enum3 = enum2;
			for (j = num2; j < i; j++)
			{
				if (bidiTypes[j] == Enum175.const_8)
				{
					if (enum3 == Enum175.const_0)
					{
						bidiTypes[j] = Enum175.const_0;
					}
				}
				else if (smethod_16(bidiTypes[j]))
				{
					enum3 = bidiTypes[j];
				}
			}
			@enum = enum2;
			j = num2;
			while (j < i)
			{
				if (!smethod_16(bidiTypes[j]) && @enum == Enum175.const_0)
				{
					int k;
					for (k = j + 1; k < i && !smethod_16(bidiTypes[k]); k++)
					{
					}
					if (((k >= i) ? ((flag2 && true) ? 1 : 0) : ((int)bidiTypes[k])) == 0)
					{
						while (j < k)
						{
							bidiTypes[j++] = Enum175.const_0;
						}
					}
					else
					{
						j = k;
					}
				}
				else
				{
					@enum = bidiTypes[j++];
				}
			}
			@enum = enum2;
			j = num2;
			while (j < i)
			{
				if (smethod_17(bidiTypes[j]))
				{
					if (!smethod_16(@enum) && @enum != Enum175.const_8 && @enum != Enum175.const_11)
					{
						bidiTypes[j++] = enum2;
					}
					else
					{
						int l;
						for (l = j + 1; l < i && smethod_17(bidiTypes[l]); l++)
						{
						}
						Enum175 enum4 = ((l >= i) ? (flag2 ? Enum175.const_3 : Enum175.const_0) : bidiTypes[l]);
						Enum175 enum5 = (((@enum == Enum175.const_3 || @enum == Enum175.const_8 || @enum == Enum175.const_11) && (enum4 == Enum175.const_3 || enum4 == Enum175.const_8 || enum4 == Enum175.const_11)) ? Enum175.const_3 : ((@enum != 0 || enum4 != 0) ? enum2 : Enum175.const_0));
						while (j < l)
						{
							bidiTypes[j++] = enum5;
						}
					}
				}
				else
				{
					j++;
				}
				@enum = bidiTypes[j - 1];
			}
			num2 = i;
		}
		for (int m = 0; m < num; m++)
		{
			Enum175 enum6 = bidiTypes[m];
			Enum176 enum7 = smethod_14(enum6);
			if (smethod_16(enum6))
			{
				switch (enum7)
				{
				case Enum176.const_1:
					levels[m] = 0;
					break;
				case Enum176.const_2:
					levels[m] = 3;
					break;
				}
			}
			else
			{
				switch (enum7)
				{
				case Enum176.const_1:
					levels[m] &= 254;
					break;
				case Enum176.const_2:
					levels[m] |= 1;
					break;
				}
			}
		}
	}

	public static void smethod_10(string text, ref byte[] levels)
	{
		if (text.Length < 1)
		{
			return;
		}
		int length = text.Length;
		if (levels == null)
		{
			levels = new byte[length];
			Array.Clear(levels, 0, length);
		}
		Enum176 @enum = Enum176.const_0;
		char c = '\0';
		int i;
		for (i = 0; i < length; i++)
		{
			char c2 = text[i];
			int num = c2;
			Enum176 enum2 = smethod_13(c2);
			bool flag = @enum != enum2 && enum2 != Enum176.const_0;
			bool flag2 = @enum != enum2 && @enum != Enum176.const_0;
			if (enum2 != 0)
			{
				if (!flag)
				{
					flag = smethod_1(c);
					if (c == 'ل')
					{
						bool flag3 = num == 1570;
						if (num == 1571)
						{
							flag3 = true;
						}
						if (num == 1573)
						{
							flag3 = true;
						}
						if (num == 1575)
						{
							flag3 = true;
						}
						if (flag3)
						{
							levels[i - 1] = (byte)(levels[i - 1] | 0x10u);
							levels[i] = (byte)(levels[i] | 0x20u);
						}
					}
				}
				if (!flag2 && smethod_2(c2))
				{
					flag2 = true;
					flag = false;
					enum2 = Enum176.const_0;
				}
			}
			if (num >= 1611 && num <= 1630)
			{
				int num2 = i;
				do
				{
					levels[num2] = (byte)(levels[num2] | 0x20u);
					num2--;
					levels[num2] = (byte)(levels[num2] | 0x10u);
				}
				while (num2 > 0 && smethod_13(text[num2]) == Enum176.const_0);
			}
			if (flag2)
			{
				levels[i - 1] = (byte)(levels[i - 1] | 8u);
			}
			if (flag)
			{
				levels[i] = (byte)(levels[i] | 4u);
			}
			c = text[i];
			@enum = enum2;
		}
		if (i > 0 && @enum != 0)
		{
			levels[i - 1] = (byte)(levels[i - 1] | 8u);
		}
	}

	public static Enum175 smethod_11(char c)
	{
		return (Enum175)(ushort_2[(uint)c] & 0x1Fu);
	}

	public static bool smethod_12(char c)
	{
		return (ushort_2[(uint)c] & 0x20) != 0;
	}

	public static Enum176 smethod_13(char c)
	{
		return enum176_0[(uint)smethod_11(c)];
	}

	public static Enum176 smethod_14(Enum175 bt)
	{
		return enum176_0[(uint)bt];
	}

	public static bool smethod_15(char c)
	{
		if (c <= '\u200f')
		{
			return c >= '\u200e';
		}
		if (c <= '\u202f')
		{
			return c >= '\u202a';
		}
		return false;
	}

	public static bool smethod_16(Enum175 type)
	{
		return (int)type <= 6;
	}

	public static bool smethod_17(Enum175 type)
	{
		return (int)type >= 15;
	}

	public static char smethod_18(char c)
	{
		return char_5[(uint)c];
	}

	public static bool smethod_19(short langid)
	{
		int num = 0;
		while (true)
		{
			if (num < short_0.Length)
			{
				if (langid == short_0[num])
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool smethod_20(short langid)
	{
		int num = 0;
		while (true)
		{
			if (num < short_1.Length)
			{
				if (langid == short_1[num])
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool smethod_21(char c)
	{
		return (ushort_2[(uint)c] & 0x400) != 0;
	}

	internal static bool smethod_22(char c)
	{
		return (ushort_2[(uint)c] & 0x800) != 0;
	}

	static Class1153()
	{
		class1152_0 = new Class1152[256];
		ushort_2 = new ushort[65536];
		char_5 = new char[65536];
		enum176_0 = new Enum176[19]
		{
			Enum176.const_1,
			Enum176.const_1,
			Enum176.const_1,
			Enum176.const_2,
			Enum176.const_2,
			Enum176.const_2,
			Enum176.const_2,
			Enum176.const_0,
			Enum176.const_1,
			Enum176.const_0,
			Enum176.const_0,
			Enum176.const_1,
			Enum176.const_0,
			Enum176.const_0,
			Enum176.const_0,
			Enum176.const_0,
			Enum176.const_0,
			Enum176.const_0,
			Enum176.const_0
		};
		short_0 = new short[17]
		{
			1037, 5121, 15361, 3073, 9217, 11265, 2049, 16385, 13313, 12289,
			4097, 6145, 14337, 8193, 1025, 10241, 7169
		};
		short_1 = new short[7] { 2052, 4100, 1028, 3076, 5124, 1041, 1042 };
		char_6 = new char[8] { 'ء', 'إ', 'ا', 'د', 'ذ', 'ر', 'ز', 'و' };
		char_7 = new char[3] { '،', '؛', '؟' };
		char_8 = new char[175]
		{
			'ء', 'ﺀ', 'ﺀ', 'ﺀ', 'ﺀ', 'أ', 'ﺃ', 'ﺄ', 'ﺃ', 'ﺄ',
			'ؤ', 'ﺅ', 'ﺆ', 'ﺅ', 'ﺆ', 'إ', 'ﺇ', 'ﺈ', 'ﺇ', 'ﺈ',
			'ئ', 'ﺉ', 'ﺊ', 'ﺋ', 'ﺌ', 'ا', 'ﺍ', 'ﺎ', 'ﺍ', 'ﺎ',
			'ب', 'ﺏ', 'ﺐ', 'ﺑ', 'ﺒ', 'ة', 'ﺓ', 'ﺔ', '\0', '\0',
			'ت', 'ﺕ', 'ﺖ', 'ﺗ', 'ﺘ', 'ث', 'ﺙ', 'ﺚ', 'ﺛ', 'ﺜ',
			'ج', 'ﺝ', 'ﺞ', 'ﺟ', 'ﺠ', 'ح', 'ﺡ', 'ﺢ', 'ﺣ', 'ﺤ',
			'خ', 'ﺥ', 'ﺦ', 'ﺧ', 'ﺨ', 'د', 'ﺩ', 'ﺪ', 'ﺩ', 'ﺪ',
			'ذ', 'ﺫ', 'ﺬ', 'ﺫ', 'ﺬ', 'ر', 'ﺭ', 'ﺮ', 'ﺭ', 'ﺮ',
			'ز', 'ﺯ', 'ﺰ', 'ﺯ', 'ﺰ', 'س', 'ﺱ', 'ﺲ', 'ﺳ', 'ﺴ',
			'ش', 'ﺵ', 'ﺶ', 'ﺷ', 'ﺸ', 'ص', 'ﺹ', 'ﺺ', 'ﺻ', 'ﺼ',
			'ض', 'ﺽ', 'ﺾ', 'ﺿ', 'ﻀ', 'ط', 'ﻁ', 'ﻂ', 'ﻃ', 'ﻄ',
			'ظ', 'ﻅ', 'ﻆ', 'ﻇ', 'ﻈ', 'ع', 'ﻉ', 'ﻊ', 'ﻋ', 'ﻌ',
			'غ', 'ﻍ', 'ﻎ', 'ﻏ', 'ﻐ', 'ف', 'ﻑ', 'ﻒ', 'ﻓ', 'ﻔ',
			'ق', 'ﻕ', 'ﻖ', 'ﻗ', 'ﻘ', 'ك', 'ﻙ', 'ﻚ', 'ﻛ', 'ﻜ',
			'ل', 'ﻝ', 'ﻞ', 'ﻟ', 'ﻠ', 'م', 'ﻡ', 'ﻢ', 'ﻣ', 'ﻤ',
			'ن', 'ﻥ', 'ﻦ', 'ﻧ', 'ﻨ', 'ه', 'ﻩ', 'ﻪ', 'ﻫ', 'ﻬ',
			'و', 'ﻭ', 'ﻮ', 'ﻭ', 'ﻮ', 'ى', 'ﻯ', 'ﻰ', '\0', '\0',
			'ي', 'ﻱ', 'ﻲ', 'ﻳ', 'ﻴ'
		};
		ushort_3 = new ushort[1725]
		{
			0, 8, 14, 9, 9, 16, 10, 10, 15, 11,
			11, 16, 12, 12, 17, 13, 13, 15, 14, 27,
			14, 28, 30, 15, 31, 31, 16, 32, 32, 17,
			33, 34, 18, 35, 37, 10, 38, 42, 18, 43,
			43, 10, 44, 44, 12, 45, 45, 10, 46, 46,
			12, 47, 47, 9, 48, 57, 8, 58, 58, 12,
			59, 64, 18, 65, 90, 0, 91, 96, 18, 97,
			122, 0, 123, 126, 18, 127, 132, 14, 133, 133,
			15, 134, 159, 14, 160, 160, 12, 161, 161, 18,
			162, 165, 10, 166, 169, 18, 170, 170, 0, 171,
			175, 18, 176, 177, 10, 178, 179, 8, 180, 180,
			18, 181, 181, 0, 182, 184, 18, 185, 185, 8,
			186, 186, 0, 187, 191, 18, 192, 214, 0, 215,
			215, 18, 216, 246, 0, 247, 247, 18, 248, 696,
			0, 697, 698, 18, 699, 705, 0, 706, 719, 18,
			720, 721, 0, 722, 735, 18, 736, 740, 0, 741,
			749, 18, 750, 750, 0, 751, 767, 18, 768, 855,
			45, 856, 860, 32, 861, 879, 45, 880, 883, 0,
			884, 885, 18, 886, 893, 0, 894, 894, 18, 895,
			899, 0, 900, 901, 18, 902, 902, 0, 903, 903,
			18, 904, 1013, 0, 1014, 1014, 18, 1015, 1154, 0,
			1155, 1158, 45, 1159, 1159, 0, 1160, 1161, 45, 1162,
			1417, 0, 1418, 1418, 18, 1419, 1424, 0, 1425, 1441,
			45, 1442, 1442, 0, 1443, 1465, 45, 1466, 1466, 0,
			1467, 1469, 45, 1470, 1470, 3, 1471, 1471, 45, 1472,
			1472, 3, 1473, 1474, 45, 1475, 1475, 3, 1476, 1476,
			45, 1477, 1487, 0, 1488, 1514, 3, 1515, 1519, 0,
			1520, 1524, 3, 1525, 1535, 0, 1536, 1539, 4, 1540,
			1547, 0, 1548, 1548, 4, 1549, 1549, 4, 1550, 1551,
			18, 1552, 1557, 45, 1558, 1562, 0, 1563, 1563, 4,
			1564, 1566, 0, 1567, 1567, 4, 1568, 1568, 0, 1569,
			1594, 4, 1595, 1599, 0, 1600, 1610, 4, 1611, 1624,
			45, 1625, 1631, 0, 1632, 1641, 11, 1642, 1642, 10,
			1643, 1644, 11, 1645, 1647, 4, 1648, 1648, 45, 1649,
			1749, 4, 1750, 1756, 45, 1757, 1757, 4, 1758, 1764,
			45, 1765, 1766, 4, 1767, 1768, 45, 1769, 1769, 18,
			1770, 1773, 45, 1774, 1775, 4, 1776, 1785, 8, 1786,
			1805, 4, 1806, 1806, 0, 1807, 1807, 14, 1808, 1808,
			4, 1809, 1809, 45, 1810, 1839, 4, 1840, 1866, 45,
			1867, 1868, 0, 1869, 1871, 4, 1872, 1919, 0, 1920,
			1957, 4, 1958, 1968, 45, 1969, 1969, 4, 1970, 2304,
			0, 2305, 2306, 45, 2307, 2363, 0, 2364, 2364, 45,
			2365, 2368, 0, 2369, 2376, 45, 2377, 2380, 0, 2381,
			2381, 45, 2382, 2384, 0, 2385, 2388, 45, 2389, 2401,
			0, 2402, 2403, 45, 2404, 2432, 0, 2433, 2433, 45,
			2434, 2491, 0, 2492, 2492, 45, 2493, 2496, 0, 2497,
			2500, 45, 2501, 2508, 0, 2509, 2509, 45, 2510, 2529,
			0, 2530, 2531, 45, 2532, 2545, 0, 2546, 2547, 10,
			2548, 2560, 0, 2561, 2562, 45, 2563, 2619, 0, 2620,
			2620, 45, 2621, 2624, 0, 2625, 2626, 45, 2627, 2630,
			0, 2631, 2632, 45, 2633, 2634, 0, 2635, 2637, 45,
			2638, 2671, 0, 2672, 2673, 45, 2674, 2688, 0, 2689,
			2690, 45, 2691, 2747, 0, 2748, 2748, 45, 2749, 2752,
			0, 2753, 2757, 45, 2758, 2758, 0, 2759, 2760, 45,
			2761, 2764, 0, 2765, 2765, 45, 2766, 2785, 0, 2786,
			2787, 45, 2788, 2800, 0, 2801, 2801, 10, 2802, 2816,
			0, 2817, 2817, 45, 2818, 2875, 0, 2876, 2876, 45,
			2877, 2878, 0, 2879, 2879, 45, 2880, 2880, 0, 2881,
			2883, 45, 2884, 2892, 0, 2893, 2893, 45, 2894, 2901,
			0, 2902, 2902, 45, 2903, 2945, 0, 2946, 2946, 45,
			2947, 3007, 0, 3008, 3008, 45, 3009, 3020, 0, 3021,
			3021, 45, 3022, 3058, 0, 3059, 3064, 18, 3065, 3065,
			10, 3066, 3066, 18, 3067, 3133, 0, 3134, 3136, 45,
			3137, 3141, 0, 3142, 3144, 45, 3145, 3145, 0, 3146,
			3149, 45, 3150, 3156, 0, 3157, 3158, 45, 3159, 3259,
			0, 3260, 3260, 45, 3261, 3275, 0, 3276, 3277, 45,
			3278, 3392, 0, 3393, 3395, 45, 3396, 3404, 0, 3405,
			3405, 45, 3406, 3529, 0, 3530, 3530, 45, 3531, 3537,
			0, 3538, 3540, 45, 3541, 3541, 0, 3542, 3542, 45,
			3543, 3632, 0, 3633, 3633, 45, 3634, 3635, 0, 3636,
			3642, 45, 3643, 3646, 0, 3647, 3647, 10, 3648, 3654,
			0, 3655, 3662, 45, 3663, 3760, 0, 3761, 3761, 45,
			3762, 3763, 0, 3764, 3769, 45, 3770, 3770, 0, 3771,
			3772, 45, 3773, 3783, 0, 3784, 3789, 45, 3790, 3863,
			0, 3864, 3865, 45, 3866, 3892, 0, 3893, 3893, 45,
			3894, 3894, 0, 3895, 3895, 45, 3896, 3896, 0, 3897,
			3897, 45, 3898, 3901, 18, 3902, 3952, 0, 3953, 3966,
			45, 3967, 3967, 0, 3968, 3972, 45, 3973, 3973, 0,
			3974, 3975, 45, 3976, 3983, 0, 3984, 3991, 45, 3992,
			3992, 0, 3993, 4028, 45, 4029, 4037, 0, 4038, 4038,
			45, 4039, 4140, 0, 4141, 4144, 45, 4145, 4145, 0,
			4146, 4146, 45, 4147, 4149, 0, 4150, 4151, 45, 4152,
			4152, 0, 4153, 4153, 45, 4154, 4183, 0, 4184, 4185,
			45, 4186, 5759, 0, 5760, 5760, 17, 5761, 5786, 0,
			5787, 5788, 18, 5789, 5905, 0, 5906, 5908, 45, 5909,
			5937, 0, 5938, 5940, 45, 5941, 5969, 0, 5970, 5971,
			45, 5972, 6001, 0, 6002, 6003, 45, 6004, 6070, 0,
			6071, 6077, 45, 6078, 6085, 0, 6086, 6086, 45, 6087,
			6088, 0, 6089, 6099, 45, 6100, 6106, 0, 6107, 6107,
			10, 6108, 6108, 0, 6109, 6109, 45, 6110, 6127, 0,
			6128, 6137, 18, 6138, 6143, 0, 6144, 6154, 18, 6155,
			6157, 45, 6158, 6158, 17, 6159, 6312, 0, 6313, 6313,
			45, 6314, 6431, 0, 6432, 6434, 45, 6435, 6438, 0,
			6439, 6443, 45, 6444, 6449, 0, 6450, 6450, 45, 6451,
			6456, 0, 6457, 6459, 45, 6460, 6463, 0, 6464, 6464,
			18, 6465, 6467, 0, 6468, 6469, 18, 6470, 6623, 0,
			6624, 6655, 18, 6656, 8124, 0, 8125, 8125, 18, 8126,
			8126, 0, 8127, 8129, 18, 8130, 8140, 0, 8141, 8143,
			18, 8144, 8156, 0, 8157, 8159, 18, 8160, 8172, 0,
			8173, 8175, 18, 8176, 8188, 0, 8189, 8190, 18, 8191,
			8191, 0, 8192, 8202, 17, 8203, 8205, 46, 8206, 8206,
			0, 8207, 8207, 3, 8208, 8231, 18, 8232, 8232, 17,
			8233, 8233, 15, 8234, 8234, 1, 8235, 8235, 5, 8236,
			8236, 7, 8237, 8237, 2, 8238, 8238, 6, 8239, 8239,
			17, 8240, 8244, 10, 8245, 8276, 18, 8277, 8278, 0,
			8279, 8279, 18, 8280, 8286, 0, 8287, 8287, 17, 8288,
			8291, 14, 8292, 8297, 0, 8298, 8303, 14, 8304, 8304,
			8, 8305, 8307, 0, 8308, 8313, 8, 8314, 8315, 10,
			8316, 8318, 18, 8319, 8319, 0, 8320, 8329, 8, 8330,
			8331, 10, 8332, 8334, 18, 8335, 8351, 0, 8352, 8369,
			10, 8370, 8399, 0, 8400, 8426, 45, 8427, 8447, 0,
			8448, 8449, 18, 8450, 8450, 0, 8451, 8454, 18, 8455,
			8455, 0, 8456, 8457, 18, 8458, 8467, 0, 8468, 8468,
			18, 8469, 8469, 0, 8470, 8472, 18, 8473, 8477, 0,
			8478, 8483, 18, 8484, 8484, 0, 8485, 8485, 18, 8486,
			8486, 0, 8487, 8487, 18, 8488, 8488, 0, 8489, 8489,
			18, 8490, 8493, 0, 8494, 8494, 10, 8495, 8497, 0,
			8498, 8498, 18, 8499, 8505, 0, 8506, 8507, 18, 8508,
			8511, 0, 8512, 8516, 18, 8517, 8521, 0, 8522, 8523,
			18, 8524, 8530, 0, 8531, 8543, 18, 8544, 8591, 0,
			8592, 8721, 18, 8722, 8723, 10, 8724, 9013, 18, 9014,
			9082, 0, 9083, 9108, 18, 9109, 9109, 0, 9110, 9168,
			18, 9169, 9215, 0, 9216, 9254, 18, 9255, 9279, 0,
			9280, 9290, 18, 9291, 9311, 0, 9312, 9371, 8, 9372,
			9449, 0, 9450, 9450, 8, 9451, 9751, 18, 9752, 9752,
			0, 9753, 9853, 18, 9854, 9855, 0, 9856, 9873, 18,
			9874, 9887, 0, 9888, 9889, 18, 9890, 9984, 0, 9985,
			9988, 18, 9989, 9989, 0, 9990, 9993, 18, 9994, 9995,
			0, 9996, 10023, 18, 10024, 10024, 0, 10025, 10059, 18,
			10060, 10060, 0, 10061, 10061, 18, 10062, 10062, 0, 10063,
			10066, 18, 10067, 10069, 0, 10070, 10070, 18, 10071, 10071,
			0, 10072, 10078, 18, 10079, 10080, 0, 10081, 10132, 18,
			10133, 10135, 0, 10136, 10159, 18, 10160, 10160, 0, 10161,
			10174, 18, 10175, 10191, 0, 10192, 10219, 18, 10220, 10223,
			0, 10224, 11021, 18, 11022, 11903, 0, 11904, 11929, 18,
			11930, 11930, 0, 11931, 12019, 18, 12020, 12031, 0, 12032,
			12245, 18, 12246, 12271, 0, 12272, 12283, 18, 12284, 12287,
			0, 12288, 12288, 17, 12289, 12292, 18, 12293, 12295, 0,
			12296, 12320, 18, 12321, 12329, 0, 12330, 12335, 45, 12336,
			12336, 18, 12337, 12341, 0, 12342, 12343, 18, 12344, 12348,
			0, 12349, 12351, 18, 12352, 12440, 0, 12441, 12442, 45,
			12443, 12444, 18, 12445, 12447, 0, 12448, 12448, 18, 12449,
			12538, 0, 12539, 12539, 18, 12540, 12828, 0, 12829, 12830,
			18, 12831, 12879, 0, 12880, 12895, 18, 12896, 12923, 0,
			12924, 12925, 18, 12926, 12976, 0, 12977, 12991, 18, 12992,
			13003, 0, 13004, 13007, 18, 13008, 13174, 0, 13175, 13178,
			18, 13179, 13277, 0, 13278, 13279, 18, 13280, 13310, 0,
			13311, 13311, 18, 13312, 19903, 0, 19904, 19967, 18, 19968,
			42127, 0, 42128, 42182, 18, 42183, 64284, 0, 64285, 64285,
			3, 64286, 64286, 45, 64287, 64296, 3, 64297, 64297, 10,
			64298, 64310, 3, 64311, 64311, 0, 64312, 64316, 3, 64317,
			64317, 0, 64318, 64318, 3, 64319, 64319, 0, 64320, 64321,
			3, 64322, 64322, 0, 64323, 64324, 3, 64325, 64325, 0,
			64326, 64335, 3, 64336, 64433, 4, 64434, 64466, 0, 64467,
			64829, 4, 64830, 64831, 18, 64832, 64847, 0, 64848, 64911,
			4, 64912, 64913, 0, 64914, 64967, 4, 64968, 65007, 0,
			65008, 65020, 4, 65021, 65021, 18, 65022, 65023, 0, 65024,
			65039, 45, 65040, 65055, 0, 65056, 65059, 45, 65060, 65071,
			0, 65072, 65103, 18, 65104, 65104, 12, 65105, 65105, 18,
			65106, 65106, 12, 65107, 65107, 0, 65108, 65108, 18, 65109,
			65109, 12, 65110, 65118, 18, 65119, 65119, 10, 65120, 65121,
			18, 65122, 65123, 10, 65124, 65126, 18, 65127, 65127, 0,
			65128, 65128, 18, 65129, 65130, 10, 65131, 65131, 18, 65132,
			65135, 0, 65136, 65140, 4, 65141, 65141, 0, 65142, 65276,
			4, 65277, 65278, 0, 65279, 65279, 14, 65280, 65280, 0,
			65281, 65282, 18, 65283, 65285, 10, 65286, 65290, 18, 65291,
			65291, 10, 65292, 65292, 12, 65293, 65293, 10, 65294, 65294,
			12, 65295, 65295, 9, 65296, 65305, 8, 65306, 65306, 12,
			65307, 65312, 18, 65313, 65338, 0, 65339, 65344, 18, 65345,
			65370, 0, 65371, 65381, 18, 65382, 65503, 0, 65504, 65505,
			10, 65506, 65508, 18, 65509, 65510, 10, 65511, 65511, 0,
			65512, 65518, 18, 65519, 65528, 0, 65529, 65531, 14, 65532,
			65533, 18, 65534, 65535, 0
		};
		ushort_4 = new ushort[93]
		{
			61440, 61695, 3, 11904, 12031, 1, 12288, 12351, 1, 12352,
			12447, 1, 12448, 12543, 1, 12544, 12591, 1, 12592, 12687,
			1, 12736, 12783, 1, 12784, 12799, 1, 12800, 13055, 1,
			13056, 13311, 1, 13312, 19903, 1, 19968, 40959, 1, 44032,
			55215, 1, 63744, 64255, 1, 65072, 65103, 1, 65281, 65535,
			1, 1424, 1535, 2, 1536, 1791, 2, 1872, 1919, 2,
			2304, 2431, 2, 2432, 2559, 2, 2560, 2687, 2, 2688,
			2815, 2, 2816, 2943, 2, 2944, 3071, 2, 3072, 3199,
			2, 3200, 3327, 2, 3328, 3455, 2, 3456, 3583, 2,
			3584, 3711, 2
		};
		char_9 = new char[4] { ',', '.', '、', '。' };
		char_10 = new char[636]
		{
			'(', ')', ')', '(', '<', '>', '>', '<', '[', ']',
			']', '[', '{', '}', '}', '{', '«', '»', '»', '«',
			'‹', '›', '›', '‹', '⁅', '⁆', '⁆', '⁅', '⁽', '⁾',
			'⁾', '⁽', '₍', '₎', '₎', '₍', '∈', '∋', '∉', '∌',
			'∊', '∍', '∋', '∈', '∌', '∉', '∍', '∊', '∕', '⧵',
			'∼', '∽', '∽', '∼', '≃', '⋍', '≒', '≓', '≓', '≒',
			'≔', '≕', '≕', '≔', '≤', '≥', '≥', '≤', '≦', '≧',
			'≧', '≦', '≨', '≩', '≩', '≨', '≪', '≫', '≫', '≪',
			'≮', '≯', '≯', '≮', '≰', '≱', '≱', '≰', '≲', '≳',
			'≳', '≲', '≴', '≵', '≵', '≴', '≶', '≷', '≷', '≶',
			'≸', '≹', '≹', '≸', '≺', '≻', '≻', '≺', '≼', '≽',
			'≽', '≼', '≾', '≿', '≿', '≾', '⊀', '⊁', '⊁', '⊀',
			'⊂', '⊃', '⊃', '⊂', '⊄', '⊅', '⊅', '⊄', '⊆', '⊇',
			'⊇', '⊆', '⊈', '⊉', '⊉', '⊈', '⊊', '⊋', '⊋', '⊊',
			'⊏', '⊐', '⊐', '⊏', '⊑', '⊒', '⊒', '⊑', '⊘', '⦸',
			'⊢', '⊣', '⊣', '⊢', '⊦', '⫞', '⊨', '⫤', '⊩', '⫣',
			'⊫', '⫥', '⊰', '⊱', '⊱', '⊰', '⊲', '⊳', '⊳', '⊲',
			'⊴', '⊵', '⊵', '⊴', '⊶', '⊷', '⊷', '⊶', '⋉', '⋊',
			'⋊', '⋉', '⋋', '⋌', '⋌', '⋋', '⋍', '≃', '⋐', '⋑',
			'⋑', '⋐', '⋖', '⋗', '⋗', '⋖', '⋘', '⋙', '⋙', '⋘',
			'⋚', '⋛', '⋛', '⋚', '⋜', '⋝', '⋝', '⋜', '⋞', '⋟',
			'⋟', '⋞', '⋠', '⋡', '⋡', '⋠', '⋢', '⋣', '⋣', '⋢',
			'⋤', '⋥', '⋥', '⋤', '⋦', '⋧', '⋧', '⋦', '⋨', '⋩',
			'⋩', '⋨', '⋪', '⋫', '⋫', '⋪', '⋬', '⋭', '⋭', '⋬',
			'⋰', '⋱', '⋱', '⋰', '⋲', '⋺', '⋳', '⋻', '⋴', '⋼',
			'⋶', '⋽', '⋷', '⋾', '⋺', '⋲', '⋻', '⋳', '⋼', '⋴',
			'⋽', '⋶', '⋾', '⋷', '⌈', '⌉', '⌉', '⌈', '⌊', '⌋',
			'⌋', '⌊', '〈', '〉', '〉', '〈', '❨', '❩', '❩', '❨',
			'❪', '❫', '❫', '❪', '❬', '❭', '❭', '❬', '❮', '❯',
			'❯', '❮', '❰', '❱', '❱', '❰', '❲', '❳', '❳', '❲',
			'❴', '❵', '❵', '❴', '⟕', '⟖', '⟖', '⟕', '⟝', '⟞',
			'⟞', '⟝', '⟢', '⟣', '⟣', '⟢', '⟤', '⟥', '⟥', '⟤',
			'⟦', '⟧', '⟧', '⟦', '⟨', '⟩', '⟩', '⟨', '⟪', '⟫',
			'⟫', '⟪', '⦃', '⦄', '⦄', '⦃', '⦅', '⦆', '⦆', '⦅',
			'⦇', '⦈', '⦈', '⦇', '⦉', '⦊', '⦊', '⦉', '⦋', '⦌',
			'⦌', '⦋', '⦍', '⦐', '⦎', '⦏', '⦏', '⦎', '⦐', '⦍',
			'⦑', '⦒', '⦒', '⦑', '⦓', '⦔', '⦔', '⦓', '⦕', '⦖',
			'⦖', '⦕', '⦗', '⦘', '⦘', '⦗', '⦸', '⊘', '⧀', '⧁',
			'⧁', '⧀', '⧄', '⧅', '⧅', '⧄', '⧏', '⧐', '⧐', '⧏',
			'⧑', '⧒', '⧒', '⧑', '⧔', '⧕', '⧕', '⧔', '⧘', '⧙',
			'⧙', '⧘', '⧚', '⧛', '⧛', '⧚', '⧵', '∕', '⧸', '⧹',
			'⧹', '⧸', '⧼', '⧽', '⧽', '⧼', '⨫', '⨬', '⨬', '⨫',
			'⨭', '⨬', '⨮', '⨭', '⨴', '⨵', '⨵', '⨴', '⨼', '⨽',
			'⨽', '⨼', '⩤', '⩥', '⩥', '⩤', '⩹', '⩺', '⩺', '⩹',
			'⩽', '⩾', '⩾', '⩽', '⩿', '⪀', '⪀', '⩿', '⪁', '⪂',
			'⪂', '⪁', '⪃', '⪄', '⪄', '⪃', '⪋', '⪌', '⪌', '⪋',
			'⪑', '⪒', '⪒', '⪑', '⪓', '⪔', '⪔', '⪓', '⪕', '⪖',
			'⪖', '⪕', '⪗', '⪘', '⪘', '⪗', '⪙', '⪚', '⪚', '⪙',
			'⪛', '⪜', '⪜', '⪛', '⪡', '⪢', '⪢', '⪡', '⪦', '⪧',
			'⪧', '⪦', '⪨', '⪩', '⪩', '⪨', '⪪', '⪫', '⪫', '⪪',
			'⪬', '⪭', '⪭', '⪬', '⪯', '⪰', '⪰', '⪯', '⪳', '⪴',
			'⪴', '⪳', '⪻', '⪼', '⪼', '⪻', '⪽', '⪾', '⪾', '⪽',
			'⪿', '⫀', '⫀', '⪿', '⫁', '⫂', '⫂', '⫁', '⫃', '⫄',
			'⫄', '⫃', '⫅', '⫆', '⫆', '⫅', '⫍', '⫎', '⫎', '⫍',
			'⫏', '⫐', '⫐', '⫏', '⫑', '⫒', '⫒', '⫑', '⫓', '⫔',
			'⫔', '⫓', '⫕', '⫖', '⫖', '⫕', '⫞', '⊦', '⫣', '⊩',
			'⫤', '⊨', '⫥', '⊫', '⫬', '⫭', '⫭', '⫬', '⫷', '⫸',
			'⫸', '⫷', '⫹', '⫺', '⫺', '⫹', '〈', '〉', '〉', '〈',
			'《', '》', '》', '《', '「', '」', '」', '「', '『', '』',
			'』', '『', '【', '】', '】', '【', '〔', '〕', '〕', '〔',
			'〖', '〗', '〗', '〖', '〘', '〙', '〙', '〘', '〚', '〛',
			'〛', '〚', '（', '）', '）', '（', '＜', '＞', '＞', '＜',
			'［', '］', '］', '［', '｛', '｝', '｝', '｛', '｟', '｠',
			'｠', '｟', '｢', '｣', '｣', '｢'
		};
		char_11 = new char[4] { ' ', '\u2002', '\u2003', '\u3000' };
		char_12 = new char[15]
		{
			'\u00a0', '\u180e', '\u2000', '\u2001', '\u2004', '\u2005', '\u2006', '\u2007', '\u2008', '\u2009',
			'\u200a', '\u200b', '\u205f', '\u202f', '\ufeff'
		};
		for (int i = 0; i < ushort_3.Length; i += 3)
		{
			int num = ushort_3[i];
			int num2 = ushort_3[i + 1];
			byte b = (byte)ushort_3[i + 2];
			while (num <= num2)
			{
				ushort_2[num++] = b;
			}
		}
		for (int j = 0; j < char_9.Length; j++)
		{
			ushort_2[(uint)char_9[j]] |= 64;
		}
		for (int k = 19968; k <= 40959; k++)
		{
			ushort_2[k] |= 128;
		}
		for (int l = 13312; l <= 19903; l++)
		{
			ushort_2[l] |= 128;
		}
		for (int m = 63744; m <= 64255; m++)
		{
			ushort_2[m] |= 128;
		}
		for (int n = 0; n < ushort_4.Length; n += 3)
		{
			int num3 = ushort_4[n + 1];
			int num4 = ushort_4[n + 2] << 8;
			for (int num5 = ushort_4[n]; num5 <= num3; num5++)
			{
				ushort_2[num5] |= (ushort)num4;
			}
		}
		for (int num6 = 0; num6 < char_11.Length; num6++)
		{
			ushort_2[(uint)char_11[num6]] |= 1024;
		}
		for (int num7 = 0; num7 < char_12.Length; num7++)
		{
			ushort_2[(uint)char_12[num7]] |= 2048;
		}
		for (int num8 = 0; num8 < char_5.Length; num8++)
		{
			char_5[num8] = (char)num8;
		}
		for (int num9 = 0; num9 < char_10.Length; num9 += 2)
		{
			char_5[(uint)char_10[num9]] = char_10[num9 + 1];
		}
		smethod_0();
	}
}
