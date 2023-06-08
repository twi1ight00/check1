using ns195;

namespace ns186;

internal class Class5387
{
	public const int int_0 = 0;

	public const int int_1 = 1;

	public const int int_2 = 2;

	public const int int_3 = 3;

	public const int int_4 = 4;

	public const int int_5 = 5;

	public const int int_6 = 6;

	public const int int_7 = 7;

	public const int int_8 = 8;

	public const int int_9 = 9;

	public const int int_10 = 10;

	public const int int_11 = 11;

	public const int int_12 = 12;

	public const int int_13 = 13;

	public const int int_14 = 14;

	public const int int_15 = 15;

	public const int int_16 = 16;

	public const int int_17 = 17;

	private const string string_0 = "_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

	private const string string_1 = ".-0123456789";

	private const string string_2 = "0123456789";

	private const string string_3 = "0123456789abcdefABCDEF";

	protected int int_18;

	protected string string_4;

	protected int int_19;

	private int int_20;

	private string string_5;

	private int int_21;

	private int int_22;

	internal Class5387(string s)
	{
		string_5 = s;
		int_22 = s.Length;
	}

	internal void method_0()
	{
		string_4 = null;
		int_20 = int_21;
		while (int_21 < int_22)
		{
			char c = string_5[int_21++];
			switch (c)
			{
			case '\t':
			case '\n':
			case '\r':
			case ' ':
				break;
			case '#':
				method_2();
				return;
			case '"':
			case '\'':
				int_21 = string_5.IndexOf(c, int_21);
				if (int_21 < 0)
				{
					int_21 = int_20 + 1;
					throw new Exception55("missing quote");
				}
				string_4 = Class5479.smethod_0(string_5, int_20 + 1, int_21++);
				int_18 = 5;
				return;
			case '(':
				int_18 = 3;
				return;
			case ')':
				int_18 = 4;
				return;
			case '*':
				int_18 = 2;
				return;
			case '+':
				int_18 = 8;
				return;
			case ',':
				int_18 = 13;
				return;
			case '-':
				int_18 = 9;
				return;
			case '.':
				method_1();
				return;
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
			{
				method_5();
				bool flag;
				if (int_21 < int_22 && string_5[int_21] == '.')
				{
					int_21++;
					flag = true;
					if (int_21 < int_22 && smethod_0(string_5[int_21]))
					{
						int_21++;
						method_5();
					}
				}
				else
				{
					flag = false;
				}
				if (int_21 < int_22 && string_5[int_21] == '%')
				{
					int_21++;
					int_18 = 14;
				}
				else
				{
					int_19 = int_21;
					method_3();
					int_19 = int_21 - int_19;
					int_18 = ((int_19 > 0) ? 12 : (flag ? 16 : 17));
				}
				string_4 = Class5479.smethod_0(string_5, int_20, int_21);
				return;
			}
			default:
				int_21--;
				method_3();
				if (int_21 == int_20)
				{
					throw new Exception55("illegal character");
				}
				string_4 = Class5479.smethod_0(string_5, int_20, int_21);
				if (string_4.Equals("mod"))
				{
					int_18 = 10;
				}
				else if (string_4.Equals("div"))
				{
					int_18 = 11;
				}
				else if (method_7())
				{
					int_18 = 7;
				}
				else
				{
					int_18 = 1;
				}
				return;
			}
			int_20 = int_21;
		}
		int_18 = 0;
	}

	private void method_1()
	{
		if (int_21 < int_22 && smethod_0(string_5[int_21]))
		{
			int_21++;
			method_5();
			if (int_21 < int_22 && string_5[int_21] == '%')
			{
				int_21++;
				int_18 = 14;
			}
			else
			{
				int_19 = int_21;
				method_3();
				int_19 = int_21 - int_19;
				int_18 = ((int_19 > 0) ? 12 : 16);
			}
			string_4 = Class5479.smethod_0(string_5, int_20, int_21);
			return;
		}
		throw new Exception55("illegal character '.'");
	}

	private void method_2()
	{
		if (int_21 < int_22)
		{
			int_21++;
			method_6();
			int num = int_21 - int_20 - 1;
			if (num % 3 == 0)
			{
				int_18 = 15;
			}
			else
			{
				method_4();
				int_18 = 1;
			}
			string_4 = Class5479.smethod_0(string_5, int_20, int_21);
			return;
		}
		throw new Exception55("illegal character '#'");
	}

	private void method_3()
	{
		if (int_21 < int_22 && smethod_3(string_5[int_21]))
		{
			method_4();
		}
	}

	private void method_4()
	{
		while (++int_21 < int_22 && smethod_4(string_5[int_21]))
		{
		}
	}

	private void method_5()
	{
		while (int_21 < int_22 && smethod_0(string_5[int_21]))
		{
			int_21++;
		}
	}

	private void method_6()
	{
		while (int_21 < int_22 && smethod_1(string_5[int_21]))
		{
			int_21++;
		}
	}

	private bool method_7()
	{
		for (int i = int_21; i < int_22; i++)
		{
			switch (string_5[i])
			{
			case '\t':
			case '\n':
			case '\r':
			case ' ':
				break;
			case '(':
				int_21 = i + 1;
				return true;
			default:
				return false;
			}
		}
		return false;
	}

	private static bool smethod_0(char c)
	{
		return "0123456789".IndexOf(c) >= 0;
	}

	private static bool smethod_1(char c)
	{
		return "0123456789abcdefABCDEF".IndexOf(c) >= 0;
	}

	private static bool smethod_2(char c)
	{
		switch (c)
		{
		default:
			return false;
		case '\t':
		case '\n':
		case '\r':
		case ' ':
			return true;
		}
	}

	private static bool smethod_3(char c)
	{
		if ("_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(c) < 0)
		{
			return c >= '\u0080';
		}
		return true;
	}

	private static bool smethod_4(char c)
	{
		if ("_abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(c) < 0 && ".-0123456789".IndexOf(c) < 0)
		{
			return c >= '\u0080';
		}
		return true;
	}
}
