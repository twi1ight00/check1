using System.Collections;
using System.Collections.Generic;
using ns301;

namespace ns303;

internal class Class6965 : Interface360
{
	private string string_0;

	private string string_1;

	private bool bool_0;

	private List<string> list_0;

	public IList imethod_0(string text)
	{
		Class6892.smethod_1(text, "text");
		list_0 = new List<string>();
		string_0 = string.Empty;
		string_1 = string.Empty;
		bool_0 = false;
		char[] array = text.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			char c = array[i];
			switch (c)
			{
			case '\t':
			case '\n':
			case ' ':
				if (bool_0)
				{
					method_5(string_1);
					method_4();
				}
				method_3();
				method_5(c.ToString());
				method_3();
				break;
			default:
				if (bool_0)
				{
					method_1(c.ToString());
				}
				else
				{
					method_5(c.ToString());
				}
				break;
			case ';':
				if (bool_0)
				{
					method_1(c.ToString());
					method_3();
					method_0();
				}
				else
				{
					method_5(c.ToString());
				}
				break;
			case '&':
				method_5(string_1);
				method_2(c);
				break;
			}
		}
		string text2 = string_0 + string_1;
		if (!Class6973.smethod_0(text2))
		{
			list_0.Add(text2);
		}
		return list_0;
	}

	private void method_0()
	{
		list_0.Add(string_1);
		method_4();
	}

	private void method_1(string c)
	{
		string_1 += c;
	}

	private void method_2(char c)
	{
		bool_0 = true;
		string_1 = c.ToString();
	}

	private void method_3()
	{
		if (!Class6973.smethod_0(string_0))
		{
			list_0.Add(string_0);
			string_0 = string.Empty;
		}
	}

	private void method_4()
	{
		bool_0 = false;
		string_1 = string.Empty;
	}

	private void method_5(string s)
	{
		string_0 += s;
	}
}
