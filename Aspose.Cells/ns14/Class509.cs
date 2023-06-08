using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using ns22;

namespace ns14;

internal class Class509
{
	private string string_0;

	private Class516 class516_0;

	private Color color_0 = Color.Empty;

	private short short_0;

	internal string Pattern
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal Color Color => color_0;

	[SpecialName]
	internal Class516 method_0()
	{
		return class516_0;
	}

	[SpecialName]
	internal void method_1(Class516 class516_1)
	{
		class516_0 = class516_1;
	}

	[SpecialName]
	internal short method_2()
	{
		return short_0;
	}

	internal int method_3(char[] char_0, int int_0, int int_1, StringBuilder stringBuilder_0, bool bool_0)
	{
		switch (char_0[int_0])
		{
		case 'G':
			if (int_0 + 5 < int_1 && char_0[int_0 + 5] == ']' && (char_0[int_0 + 1] == 'r' || char_0[int_0 + 1] == 'R') && (char_0[int_0 + 2] == 'e' || char_0[int_0 + 2] == 'E') && (char_0[int_0 + 3] == 'e' || char_0[int_0 + 3] == 'E') && (char_0[int_0 + 4] == 'n' || char_0[int_0 + 4] == 'N'))
			{
				color_0 = Color.Green;
				return int_0 + 6;
			}
			break;
		case '$':
		{
			int_0++;
			bool flag = true;
			int num2 = int_0;
			while (int_0 < int_1)
			{
				switch (char_0[int_0])
				{
				default:
					int_0++;
					break;
				case '-':
					method_4(stringBuilder_0, char_0, num2, int_0, bool_0);
					int_0++;
					num2 = int_0;
					flag = false;
					break;
				case ']':
					if (flag)
					{
						method_4(stringBuilder_0, char_0, num2, int_0, bool_0);
					}
					else if (num2 < int_0)
					{
						try
						{
							int num3 = int.Parse(new string(char_0, num2, int_0 - num2), NumberStyles.HexNumber);
							short_0 = (short)(num3 & 0xFFFF);
						}
						catch
						{
						}
					}
					return int_0 + 1;
				}
			}
			break;
		}
		case 'R':
			if (int_0 + 3 < int_1 && char_0[int_0 + 3] == ']' && (char_0[int_0 + 1] == 'e' || char_0[int_0 + 1] == 'E') && (char_0[int_0 + 2] == 'd' || char_0[int_0 + 2] == 'D'))
			{
				color_0 = Color.Red;
				return int_0 + 4;
			}
			break;
		case 'M':
			if (int_0 + 7 < int_1 && char_0[int_0 + 7] == ']' && (char_0[int_0 + 1] == 'a' || char_0[int_0 + 1] == 'A') && (char_0[int_0 + 2] == 'g' || char_0[int_0 + 2] == 'G') && (char_0[int_0 + 3] == 'e' || char_0[int_0 + 3] == 'E') && (char_0[int_0 + 4] == 'n' || char_0[int_0 + 4] == 'N') && (char_0[int_0 + 5] == 't' || char_0[int_0 + 5] == 'T') && (char_0[int_0 + 6] == 'a' || char_0[int_0 + 6] == 'A'))
			{
				color_0 = Color.Magenta;
				return int_0 + 8;
			}
			break;
		case 'B':
		case 'b':
			if (int_0 + 4 >= int_1)
			{
				break;
			}
			int_0++;
			if (char_0[int_0] != 'l' && char_0[int_0] != 'L')
			{
				break;
			}
			int_0++;
			switch (char_0[int_0])
			{
			case 'U':
			case 'u':
				if (char_0[int_0 + 2] == ']' && (char_0[int_0 + 1] == 'e' || char_0[int_0 + 1] == 'E'))
				{
					color_0 = Color.Blue;
					return int_0 + 3;
				}
				break;
			case 'A':
			case 'a':
				if (int_0 + 3 < int_1 && char_0[int_0 + 3] == ']' && (char_0[int_0 + 1] == 'c' || char_0[int_0 + 1] == 'C') && (char_0[int_0 + 2] == 'k' || char_0[int_0 + 2] == 'K'))
				{
					color_0 = Color.Black;
					return int_0 + 4;
				}
				break;
			}
			break;
		case 'C':
		case 'c':
			if (int_0 + 4 >= int_1)
			{
				break;
			}
			switch (char_0[int_0 + 1])
			{
			case 'Y':
			case 'y':
				if (char_0[int_0 + 4] == ']' && (char_0[int_0 + 2] == 'a' || char_0[int_0 + 2] == 'A') && (char_0[int_0 + 3] == 'n' || char_0[int_0 + 3] == 'N'))
				{
					color_0 = Color.Cyan;
					return int_0 + 5;
				}
				break;
			case 'O':
			case 'o':
			{
				if (int_0 + 6 >= int_1 || (char_0[int_0 + 2] != 'l' && char_0[int_0 + 2] != 'L') || (char_0[int_0 + 3] != 'o' && char_0[int_0 + 3] != 'O') || (char_0[int_0 + 4] != 'r' && char_0[int_0 + 4] != 'R'))
				{
					break;
				}
				int_0 += 5;
				if (char_0[int_0] < '0' || char_0[int_0] > '9')
				{
					break;
				}
				int num = char_0[int_0] - 48;
				int_0++;
				if (char_0[int_0] >= '0' && char_0[int_0] <= '9')
				{
					num = num * 10 + (char_0[int_0] - 48);
					int_0++;
				}
				if (char_0[int_0] == ']' && num > 0 && num < 57)
				{
					if (class516_0.method_1() != null)
					{
						color_0 = class516_0.method_1().GetColor(num);
					}
					else
					{
						color_0 = Class485.smethod_0(num);
					}
					return int_0 + 1;
				}
				break;
			}
			}
			break;
		case 'W':
			if (int_0 + 5 < int_1 && char_0[int_0 + 5] == ']' && (char_0[int_0 + 1] == 'h' || char_0[int_0 + 1] == 'H') && (char_0[int_0 + 2] == 'i' || char_0[int_0 + 2] == 'I') && (char_0[int_0 + 3] == 't' || char_0[int_0 + 3] == 'T') && (char_0[int_0 + 4] == 'e' || char_0[int_0 + 4] == 'E'))
			{
				color_0 = Color.White;
				return int_0 + 6;
			}
			break;
		default:
			if (int_0 + 2 >= int_1)
			{
				break;
			}
			if (char_0[int_0 + 2] == ']')
			{
				if (char_0[int_0 + 1] == '色')
				{
					switch (char_0[int_0])
					{
					case '绿':
						color_0 = Color.Green;
						return int_0 + 3;
					case '红':
						color_0 = Color.Red;
						return int_0 + 3;
					case '白':
						color_0 = Color.White;
						return int_0 + 3;
					case '黑':
						color_0 = Color.Black;
						return int_0 + 3;
					case '黄':
						color_0 = Color.Yellow;
						return int_0 + 3;
					case '蓝':
						color_0 = Color.Blue;
						return int_0 + 3;
					}
				}
				else if (char_0[int_0] == '洋' && char_0[int_0 + 1] == '红')
				{
					color_0 = Color.Magenta;
					return int_0 + 3;
				}
			}
			else if (int_0 + 3 < int_1 && char_0[int_0 + 3] == ']' && char_0[int_0 + 2] == '色' && char_0[int_0] == '蓝' && char_0[int_0 + 1] == '绿')
			{
				return int_0 + 4;
			}
			break;
		case 'Y':
			if (int_0 + 6 < int_1 && char_0[int_0 + 6] == ']' && (char_0[int_0 + 1] == 'e' || char_0[int_0 + 1] == 'R') && (char_0[int_0 + 2] == 'l' || char_0[int_0 + 2] == 'E') && (char_0[int_0 + 3] == 'l' || char_0[int_0 + 3] == 'E') && (char_0[int_0 + 4] == 'o' || char_0[int_0 + 4] == 'O') && (char_0[int_0 + 5] == 'w' || char_0[int_0 + 5] == 'W'))
			{
				color_0 = Color.Yellow;
				return int_0 + 7;
			}
			break;
		}
		while (true)
		{
			if (int_0 < int_1)
			{
				if (char_0[int_0] == ']')
				{
					break;
				}
				int_0++;
				continue;
			}
			return int_0;
		}
		return int_0 + 1;
	}

	private void method_4(StringBuilder stringBuilder_0, char[] char_0, int int_0, int int_1, bool bool_0)
	{
		if (int_0 < int_1 && stringBuilder_0 != null)
		{
			if (bool_0)
			{
				Class1180.smethod_6(stringBuilder_0, char_0, int_0, int_1);
				return;
			}
			stringBuilder_0.Append('"');
			stringBuilder_0.Append(char_0, int_0, int_1 - int_0);
			stringBuilder_0.Append('"');
		}
	}
}
