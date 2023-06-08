using System;
using System.Text;
using ns181;
using ns183;

namespace ns195;

internal class Class5710
{
	public const char char_0 = '\0';

	public const int int_0 = 0;

	public const int int_1 = 1;

	public const int int_2 = 2;

	public const int int_3 = 3;

	public const int int_4 = 4;

	public const char char_1 = '\0';

	public const char char_2 = '\n';

	public const char char_3 = '\r';

	public const char char_4 = '\t';

	public const char char_5 = ' ';

	public const char char_6 = '\u00a0';

	public const char char_7 = '\u0085';

	public const char char_8 = '\u200b';

	public const char char_9 = '\u2060';

	public const char char_10 = '\u200d';

	public const char char_11 = '\u200e';

	public const char char_12 = '\u202f';

	public const char char_13 = '\u202a';

	public const char char_14 = '\u202b';

	public const char char_15 = '\u202c';

	public const char char_16 = '\u202d';

	public const char char_17 = '\u202e';

	public const char char_18 = '\ufeff';

	public const char char_19 = '\u00ad';

	public const char char_20 = '\u2028';

	public const char char_21 = '\u2029';

	public const char char_22 = '□';

	public const char char_23 = '\u3000';

	public const char char_24 = '￼';

	public const char char_25 = '\uffff';

	protected Class5710()
	{
		throw new NotSupportedException();
	}

	public static int smethod_0(int c)
	{
		switch (c)
		{
		case 10:
			return 1;
		default:
			if (!smethod_6(c))
			{
				return 3;
			}
			return 0;
		case 9:
		case 13:
		case 32:
			return 4;
		case 0:
			return 2;
		}
	}

	public static bool smethod_1(int c)
	{
		if (c != 32)
		{
			return smethod_3(c);
		}
		return true;
	}

	public static bool smethod_2(int c)
	{
		if (c != 8203 && c != 8288)
		{
			return c == 65279;
		}
		return true;
	}

	public static bool smethod_3(int c)
	{
		if (c >= 8192 && c <= 8203)
		{
			return true;
		}
		return c == 12288;
	}

	public static bool smethod_4(int c)
	{
		if (c != 160 && c != 8239 && c != 12288 && c != 8288)
		{
			return c == 65279;
		}
		return true;
	}

	public static bool smethod_5(int c)
	{
		if (c != 32)
		{
			return c == 160;
		}
		return true;
	}

	public static bool smethod_6(int c)
	{
		if (!smethod_1(c))
		{
			return smethod_4(c);
		}
		return true;
	}

	public static bool smethod_7(int c)
	{
		if (c != 10 && c != 13 && c != 133 && c != 8232)
		{
			return c == 8233;
		}
		return true;
	}

	public static string smethod_8(int c)
	{
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		int num2 = ((c > 65535) ? 6 : 4);
		while (num < num2)
		{
			int num3 = c & 0xF;
			char value = ((num3 >= 10) ? ((char)(65 + (num3 - 10))) : ((char)(48 + num3)));
			stringBuilder.Append(value);
			num++;
			c >>= 4;
		}
		return "&#x" + Class4956.Class5762.smethod_0(stringBuilder.ToString()) + ";";
	}

	public static string smethod_9(string s)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (s != null)
		{
			foreach (char c in s)
			{
				if (c >= ' ' && c < '\u007f')
				{
					switch (c)
					{
					case '<':
						stringBuilder.Append("&lt;");
						break;
					case '>':
						stringBuilder.Append("&gt;");
						break;
					case '&':
						stringBuilder.Append("&amp;");
						break;
					default:
						stringBuilder.Append(c);
						break;
					}
				}
				else
				{
					stringBuilder.Append(smethod_8(c));
				}
			}
		}
		return stringBuilder.ToString();
	}

	public static string smethod_10(string s, int width, char pad)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = s.Length; i < width; i++)
		{
			stringBuilder.Append(pad);
		}
		stringBuilder.Append(s);
		return stringBuilder.ToString();
	}

	public static string smethod_11(int c)
	{
		if (c < 1114112)
		{
			return "0x" + smethod_10(c.ToString("X"), (c < 65536) ? 4 : 6, '0');
		}
		return "!NOT A CHARACTER!";
	}

	public static bool smethod_12(Interface238 cs1, Interface238 cs2)
	{
		if (cs1.imethod_0() != cs2.imethod_0())
		{
			return false;
		}
		int num = 0;
		int num2 = cs1.imethod_0();
		while (true)
		{
			if (num < num2)
			{
				if (cs1.imethod_1(num) != cs2.imethod_1(num))
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}
}
