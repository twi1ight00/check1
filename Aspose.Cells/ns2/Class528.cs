using System.Globalization;
using System.Text;
using ns14;

namespace ns2;

internal class Class528 : Interface4
{
	private readonly Class529 class529_0;

	private readonly char[] char_0;

	private readonly char[] char_1;

	internal Class528(CultureInfo cultureInfo_0, Class529 class529_1)
	{
		class529_0 = class529_1;
		char_0 = cultureInfo_0.NumberFormat.CurrencySymbol.ToCharArray();
		char_1 = cultureInfo_0.NumberFormat.PercentSymbol.ToCharArray();
	}

	public virtual int imethod_0(char[] char_2, int int_0)
	{
		if (char_2[int_0] != class529_0.method_2())
		{
			return 0;
		}
		return 1;
	}

	public virtual int imethod_1(char[] char_2, int int_0)
	{
		if (char_2[int_0] != class529_0.method_3())
		{
			return 0;
		}
		return 1;
	}

	public virtual int imethod_2(char[] char_2, int int_0, bool bool_0)
	{
		if (bool_0)
		{
			int_0 -= char_1.Length - 1;
			if (int_0 < 0)
			{
				return 0;
			}
		}
		else if (int_0 + char_1.Length > char_2.Length)
		{
			return 0;
		}
		int num = 0;
		while (true)
		{
			if (num < char_1.Length)
			{
				if (char_2[num + int_0] != char_1[num])
				{
					break;
				}
				num++;
				continue;
			}
			return char_1.Length;
		}
		return 0;
	}

	public virtual int imethod_3(char[] char_2, int int_0, bool bool_0)
	{
		if (bool_0)
		{
			char c = char_2[int_0];
			if (c == '€')
			{
				return 1;
			}
			return 0;
		}
		switch (char_2[int_0])
		{
		default:
		{
			if (int_0 + char_0.Length > char_2.Length)
			{
				return 0;
			}
			int num = 0;
			while (true)
			{
				if (num < char_0.Length)
				{
					if (char_2[num + int_0] != char_0[num])
					{
						break;
					}
					num++;
					continue;
				}
				return char_0.Length;
			}
			return 0;
		}
		case '$':
		case '€':
		case '￡':
		case '￥':
			return 1;
		}
	}

	public virtual int imethod_4(char[] char_2, int int_0)
	{
		int num = int_0;
		do
		{
			if (char_2[num] == ' ')
			{
				num++;
				continue;
			}
			switch (char_2[num])
			{
			default:
				if (char_2[num] != class529_0.method_5())
				{
					return 0;
				}
				break;
			case '-':
			case '/':
				break;
			}
			for (num++; num < char_2.Length && char_2[num] == ' '; num++)
			{
			}
			return num - int_0;
		}
		while (num < char_2.Length);
		return 0;
	}

	public virtual int imethod_5(char[] char_2, int int_0)
	{
		int num = int_0;
		do
		{
			if (char_2[num] == ' ')
			{
				num++;
				continue;
			}
			if (char_2[num] != class529_0.method_6())
			{
				return 0;
			}
			for (num++; num < char_2.Length && char_2[num] == ' '; num++)
			{
			}
			return num - int_0;
		}
		while (num < char_2.Length);
		return 0;
	}

	public virtual int imethod_6(char[] char_2, int int_0)
	{
		return 0;
	}

	public virtual int imethod_7(char[] char_2, int int_0)
	{
		char c = char_2[int_0];
		if (c == '年')
		{
			return 1;
		}
		return 0;
	}

	public virtual int imethod_8(char[] char_2, int int_0)
	{
		return 0;
	}

	public virtual int imethod_9(char[] char_2, int int_0)
	{
		char c = char_2[int_0];
		if (c == '月')
		{
			return 1;
		}
		return 0;
	}

	public virtual int imethod_10(char[] char_2, int int_0)
	{
		return 0;
	}

	public virtual int imethod_11(char[] char_2, int int_0)
	{
		char c = char_2[int_0];
		if (c == '日')
		{
			return 1;
		}
		return 0;
	}

	public virtual int imethod_12(char[] char_2, int int_0)
	{
		return 0;
	}

	public virtual int imethod_13(char[] char_2, int int_0)
	{
		char c = char_2[int_0];
		if (c == '时')
		{
			return 1;
		}
		return 0;
	}

	public virtual int imethod_14(char[] char_2, int int_0)
	{
		return 0;
	}

	public virtual int imethod_15(char[] char_2, int int_0)
	{
		char c = char_2[int_0];
		if (c == '分')
		{
			return 1;
		}
		return 0;
	}

	public virtual int imethod_16(char[] char_2, int int_0)
	{
		return 0;
	}

	public virtual int imethod_17(char[] char_2, int int_0)
	{
		char c = char_2[int_0];
		if (c == '秒')
		{
			return 1;
		}
		return 0;
	}

	public virtual int imethod_18(char[] char_2, int int_0, StringBuilder stringBuilder_0)
	{
		if (method_0(char_2, int_0, Class1391.char_0))
		{
			stringBuilder_0.Append(Class1391.char_0);
			stringBuilder_0.Append('/');
			stringBuilder_0.Append(Class1391.char_1);
			return Class1391.char_0.Length;
		}
		char c = char_2[int_0];
		if (c == 'A' || c == 'a')
		{
			int_0++;
			if (int_0 == char_2.Length)
			{
				stringBuilder_0.Append(char_2[int_0 - 1]);
				stringBuilder_0.Append('/');
				stringBuilder_0.Append((char_2[int_0 - 1] == 'A') ? 'P' : 'p');
				return 1;
			}
			switch (char_2[int_0])
			{
			case 'M':
			case 'm':
				int_0++;
				if (int_0 != char_2.Length && char_2[int_0] != ' ')
				{
					return 0;
				}
				stringBuilder_0.Append(char_2, int_0 - 2, 2);
				stringBuilder_0.Append('/');
				stringBuilder_0.Append((char_2[int_0 - 2] == 'A') ? 'P' : 'p');
				stringBuilder_0.Append(char_2[int_0 - 1]);
				return 2;
			case ' ':
				stringBuilder_0.Append(char_2[int_0 - 1]);
				stringBuilder_0.Append('/');
				stringBuilder_0.Append((char_2[int_0 - 1] == 'A') ? 'P' : 'p');
				return 1;
			}
		}
		return 0;
	}

	public virtual int imethod_19(char[] char_2, int int_0, StringBuilder stringBuilder_0)
	{
		if (method_0(char_2, int_0, Class1391.char_1))
		{
			stringBuilder_0.Append(Class1391.char_0);
			stringBuilder_0.Append('/');
			stringBuilder_0.Append(Class1391.char_1);
			return Class1391.char_1.Length;
		}
		char c = char_2[int_0];
		if (c == 'P' || c == 'p')
		{
			int_0++;
			if (int_0 == char_2.Length)
			{
				stringBuilder_0.Append((char_2[int_0 - 1] == 'P') ? 'A' : 'a');
				stringBuilder_0.Append('/');
				stringBuilder_0.Append(char_2[int_0 - 1]);
				return 1;
			}
			switch (char_2[int_0])
			{
			case 'M':
			case 'm':
				int_0++;
				if (int_0 != char_2.Length && char_2[int_0] != ' ')
				{
					return 0;
				}
				stringBuilder_0.Append((char_2[int_0 - 2] == 'P') ? 'A' : 'a');
				stringBuilder_0.Append(char_2[int_0 - 1]);
				stringBuilder_0.Append('/');
				stringBuilder_0.Append(char_2, int_0 - 2, 2);
				return 2;
			case ' ':
				stringBuilder_0.Append((char_2[int_0 - 1] == 'P') ? 'A' : 'a');
				stringBuilder_0.Append('/');
				stringBuilder_0.Append(char_2[int_0 - 1]);
				return 1;
			}
		}
		return 0;
	}

	private bool method_0(char[] char_2, int int_0, char[] char_3)
	{
		if (char_3 == null)
		{
			return false;
		}
		if (int_0 + char_3.Length > char_2.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < char_3.Length)
			{
				if (char_2[int_0 + num] != char_3[num])
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

	public virtual int imethod_20(char[] char_2, int int_0)
	{
		if (int_0 + 3 >= char_2.Length)
		{
			return 0;
		}
		switch (char_2[int_0])
		{
		case 'D':
		case 'd':
			if ((char_2[int_0 + 1] == 'e' || char_2[int_0 + 1] == 'E') && (char_2[int_0 + 2] == 'c' || char_2[int_0 + 2] == 'C'))
			{
				int num = -1073741824;
				if (int_0 + 7 < char_2.Length && (char_2[int_0 + 3] == 'e' || char_2[int_0 + 3] == 'E') && (char_2[int_0 + 4] == 'm' || char_2[int_0 + 4] == 'M') && (char_2[int_0 + 5] == 'b' || char_2[int_0 + 5] == 'B') && (char_2[int_0 + 6] == 'e' || char_2[int_0 + 6] == 'E') && (char_2[int_0 + 7] == 'r' || char_2[int_0 + 7] == 'R'))
				{
					return num | 8;
				}
				return num | 3;
			}
			goto default;
		case 'F':
		case 'f':
			if ((char_2[int_0 + 1] == 'e' || char_2[int_0 + 1] == 'E') && (char_2[int_0 + 2] == 'b' || char_2[int_0 + 2] == 'B'))
			{
				int num10 = 536870912;
				if (int_0 + 7 < char_2.Length && (char_2[int_0 + 3] == 'r' || char_2[int_0 + 3] == 'R') && (char_2[int_0 + 4] == 'u' || char_2[int_0 + 4] == 'U') && (char_2[int_0 + 5] == 'a' || char_2[int_0 + 5] == 'A') && (char_2[int_0 + 6] == 'r' || char_2[int_0 + 6] == 'R') && (char_2[int_0 + 7] == 'y' || char_2[int_0 + 7] == 'Y'))
				{
					return num10 | 8;
				}
				return num10 | 3;
			}
			goto default;
		case 'A':
		case 'a':
			switch (char_2[int_0 + 1])
			{
			case 'U':
			case 'u':
				if (char_2[int_0 + 2] == 'g' || char_2[int_0 + 2] == 'G')
				{
					int num9 = int.MinValue;
					if (int_0 + 5 < char_2.Length && (char_2[int_0 + 3] == 'u' || char_2[int_0 + 3] == 'U') && (char_2[int_0 + 4] == 's' || char_2[int_0 + 4] == 'S') && (char_2[int_0 + 5] == 't' || char_2[int_0 + 5] == 'T'))
					{
						return num9 | 6;
					}
					return num9 | 3;
				}
				break;
			case 'P':
			case 'p':
				if (char_2[int_0 + 2] == 'r' || char_2[int_0 + 2] == 'R')
				{
					int num8 = 1073741824;
					if (int_0 + 4 < char_2.Length && (char_2[int_0 + 3] == 'i' || char_2[int_0 + 3] == 'I') && (char_2[int_0 + 4] == 'l' || char_2[int_0 + 4] == 'L'))
					{
						return num8 | 5;
					}
					return num8 | 3;
				}
				break;
			}
			goto default;
		case 'S':
		case 's':
			if ((char_2[int_0 + 1] == 'e' || char_2[int_0 + 1] == 'E') && (char_2[int_0 + 2] == 'p' || char_2[int_0 + 2] == 'P'))
			{
				int num6 = -1879048192;
				if (int_0 + 8 < char_2.Length && (char_2[int_0 + 3] == 't' || char_2[int_0 + 3] == 'T') && (char_2[int_0 + 4] == 'e' || char_2[int_0 + 4] == 'E') && (char_2[int_0 + 5] == 'm' || char_2[int_0 + 5] == 'M') && (char_2[int_0 + 6] == 'b' || char_2[int_0 + 6] == 'B') && (char_2[int_0 + 7] == 'e' || char_2[int_0 + 7] == 'E') && (char_2[int_0 + 8] == 'r' || char_2[int_0 + 8] == 'R'))
				{
					return num6 | 9;
				}
				return num6 | 3;
			}
			goto default;
		case 'J':
		case 'j':
			switch (char_2[int_0 + 1])
			{
			case 'U':
			case 'u':
				switch (char_2[int_0 + 2])
				{
				case 'L':
				case 'l':
				{
					int num4 = 1879048192;
					if (int_0 + 3 < char_2.Length && (char_2[int_0 + 3] == 'y' || char_2[int_0 + 3] == 'y'))
					{
						return num4 | 4;
					}
					return num4 | 3;
				}
				case 'N':
				case 'n':
				{
					int num3 = 1610612736;
					if (int_0 + 3 < char_2.Length && (char_2[int_0 + 3] == 'e' || char_2[int_0 + 3] == 'e'))
					{
						return num3 | 4;
					}
					return num3 | 3;
				}
				}
				break;
			case 'A':
			case 'a':
			{
				int num2 = 268435456;
				if (char_2[int_0 + 2] == 'n' || char_2[int_0 + 2] == 'N')
				{
					if (int_0 + 6 < char_2.Length && (char_2[int_0 + 3] == 'u' || char_2[int_0 + 3] == 'U') && (char_2[int_0 + 4] == 'a' || char_2[int_0 + 4] == 'A') && (char_2[int_0 + 5] == 'r' || char_2[int_0 + 5] == 'R') && (char_2[int_0 + 6] == 'y' || char_2[int_0 + 6] == 'Y'))
					{
						return num2 | 7;
					}
					return num2 | 3;
				}
				break;
			}
			}
			goto default;
		case 'M':
		case 'm':
			if (char_2[int_0 + 1] == 'a' || char_2[int_0 + 1] == 'A')
			{
				switch (char_2[int_0 + 2])
				{
				case 'Y':
				case 'y':
					return 0x50000000 | 3;
				case 'R':
				case 'r':
				{
					int num7 = 805306368;
					if (int_0 + 4 < char_2.Length && (char_2[int_0 + 3] == 'c' || char_2[int_0 + 3] == 'C') && (char_2[int_0 + 4] == 'h' || char_2[int_0 + 4] == 'H'))
					{
						return num7 | 5;
					}
					return num7 | 3;
				}
				}
			}
			goto default;
		case 'N':
		case 'n':
			if ((char_2[int_0 + 1] == 'o' || char_2[int_0 + 1] == 'O') && (char_2[int_0 + 2] == 'v' || char_2[int_0 + 2] == 'V'))
			{
				int num5 = -1342177280;
				if (int_0 + 7 < char_2.Length && (char_2[int_0 + 3] == 'e' || char_2[int_0 + 3] == 'E') && (char_2[int_0 + 4] == 'm' || char_2[int_0 + 4] == 'M') && (char_2[int_0 + 5] == 'b' || char_2[int_0 + 5] == 'B') && (char_2[int_0 + 6] == 'e' || char_2[int_0 + 6] == 'E') && (char_2[int_0 + 7] == 'r' || char_2[int_0 + 7] == 'R'))
				{
					return num5 | 8;
				}
				return num5 | 3;
			}
			goto default;
		case 'O':
		case 'o':
			if ((char_2[int_0 + 1] == 'c' || char_2[int_0 + 1] == 'C') && (char_2[int_0 + 2] == 't' || char_2[int_0 + 2] == 'T'))
			{
				break;
			}
			goto default;
		default:
			return 0;
		}
		int num11 = -1610612736;
		if (int_0 + 6 < char_2.Length && (char_2[int_0 + 3] == 'o' || char_2[int_0 + 3] == 'O') && (char_2[int_0 + 4] == 'b' || char_2[int_0 + 4] == 'B') && (char_2[int_0 + 5] == 'e' || char_2[int_0 + 5] == 'E') && (char_2[int_0 + 6] == 'r' || char_2[int_0 + 6] == 'R'))
		{
			return num11 | 7;
		}
		return num11 | 3;
	}
}
