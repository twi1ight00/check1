namespace ns262;

internal class Class6470 : Interface314
{
	private int int_0;

	private string string_0;

	private string string_1;

	private int int_1;

	private Enum836 enum836_0;

	public string Token => string_1;

	public Enum836 TokenType => enum836_0;

	public void method_0(string text)
	{
		if (text == null)
		{
			text = string.Empty;
		}
		string_0 = text;
		int_0 = 0;
		int_1 = 0;
	}

	public bool MoveNext()
	{
		if (int_0 >= string_0.Length)
		{
			return false;
		}
		method_3();
		method_1();
		return true;
	}

	public override string ToString()
	{
		return Token;
	}

	private static bool smethod_0(char c)
	{
		if (c != '\n')
		{
			return c == '\r';
		}
		return true;
	}

	private static bool smethod_1(char c)
	{
		if (c != ' ')
		{
			return c == '\t';
		}
		return true;
	}

	private static Enum836 smethod_2(char firstChar)
	{
		if (smethod_1(firstChar))
		{
			return Enum836.const_1;
		}
		if (smethod_0(firstChar))
		{
			return Enum836.const_2;
		}
		return Enum836.const_0;
	}

	private void method_1()
	{
		while (true)
		{
			if (int_0 < string_0.Length)
			{
				Enum836 @enum = smethod_2(string_0[int_0]);
				if (@enum != TokenType)
				{
					break;
				}
				int_0++;
				continue;
			}
			method_2();
			return;
		}
		method_2();
	}

	private void method_2()
	{
		string_1 = string_0.Substring(int_1, int_0 - int_1);
	}

	private void method_3()
	{
		int_1 = int_0;
		enum836_0 = smethod_2(string_0[int_0]);
	}
}
