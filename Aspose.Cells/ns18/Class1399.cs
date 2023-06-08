using System.Text;

namespace ns18;

internal class Class1399
{
	private static readonly char[] char_0 = new char[16]
	{
		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
		'A', 'B', 'C', 'D', 'E', 'F'
	};

	private Class1399()
	{
	}

	public static bool smethod_0(string string_0)
	{
		return string_0.IndexOf(":/") > 0;
	}

	public static bool smethod_1(string string_0)
	{
		if (!smethod_2(string_0))
		{
			return smethod_3(string_0);
		}
		return true;
	}

	public static bool smethod_2(string string_0)
	{
		if (string_0.Length > 2 && smethod_4(string_0[0]) && string_0[1] == ':')
		{
			return string_0[2] == '\\';
		}
		return false;
	}

	public static bool smethod_3(string string_0)
	{
		return string_0.StartsWith("\\\\");
	}

	private static bool smethod_4(char char_1)
	{
		if (char_1 >= 'a' && char_1 <= 'z')
		{
			return true;
		}
		if (char_1 >= 'A')
		{
			return char_1 <= 'Z';
		}
		return false;
	}

	public static string smethod_5(string string_0, string string_1)
	{
		if (!Class1015.smethod_11(string_0))
		{
			return string_1;
		}
		string text = ((string_0.IndexOf("/") == -1) ? "\\" : "/");
		if (string_0.EndsWith(text))
		{
			return string_0 + string_1;
		}
		return string_0 + text + string_1;
	}

	public static bool smethod_6(string string_0)
	{
		return string_0.StartsWith("#");
	}

	public static string smethod_7(string string_0)
	{
		if (!smethod_10(string_0))
		{
			return string_0;
		}
		return smethod_8(string_0);
	}

	public static string smethod_8(string string_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char c in string_0)
		{
			if (smethod_9(c))
			{
				stringBuilder.Append(smethod_13(c));
			}
			else
			{
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	private static bool smethod_9(char char_1)
	{
		return " <>{}|^[]`\"%".IndexOf(char_1) >= 0;
	}

	private static bool smethod_10(string string_0)
	{
		if (!Class1015.smethod_11(string_0))
		{
			return false;
		}
		if (!smethod_2(string_0) && !smethod_3(string_0))
		{
			if (string_0.IndexOfAny(" <>{}|^[]`\"".ToCharArray()) >= 0)
			{
				return true;
			}
			int num = 0;
			while (true)
			{
				if (num < string_0.Length)
				{
					if (string_0[num] == '%' && num + 2 < string_0.Length && !smethod_11(string_0.Substring(num, 3)))
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
		return false;
	}

	private static bool smethod_11(string string_0)
	{
		if (string_0.Length == 3 && string_0[0] == '%' && Class1015.smethod_15(string_0[1]) && Class1015.smethod_15(string_0[2]))
		{
			if (" <>{}|^[]`\"%".IndexOf(smethod_12(string_0)) < 0)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	private static char smethod_12(string string_0)
	{
		return (char)(Class1015.smethod_14(string_0[1]) * 16 + Class1015.smethod_14(string_0[2]));
	}

	private static string smethod_13(char char_1)
	{
		StringBuilder stringBuilder = new StringBuilder(3);
		stringBuilder.Length = 3;
		stringBuilder[0] = '%';
		stringBuilder[1] = char_0[(char_1 & 0xF0) >> 4];
		stringBuilder[2] = char_0[char_1 & 0xF];
		return stringBuilder.ToString();
	}
}
