using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns8;

internal class Class728 : Class725
{
	private string string_2;

	private int int_0;

	public static bool smethod_0(char char_0)
	{
		return "\t\n\r".IndexOf(char_0) != -1;
	}

	private void method_1()
	{
		while (!method_2() && smethod_0(method_7()))
		{
			int_0++;
		}
	}

	private bool method_2()
	{
		return int_0 >= string_2.Length;
	}

	public ArrayList method_3()
	{
		string_2 = string_2.Replace("&quot;", "");
		while (!method_2())
		{
			string text = method_4();
			string text2 = method_5();
			while (!text.Equals("") && !text2.Equals(""))
			{
				method_6(text, text2);
				text = method_4();
				text2 = method_5();
			}
		}
		return method_0();
	}

	public string method_4()
	{
		StringBuilder stringBuilder = new StringBuilder();
		method_1();
		while (true)
		{
			if (!method_2())
			{
				if (method_7() != ':')
				{
					if (method_7() == ';')
					{
						break;
					}
					stringBuilder.Append(method_7());
					int_0++;
					continue;
				}
				int_0++;
			}
			method_1();
			return stringBuilder.ToString().Trim();
		}
		int_0 -= stringBuilder.ToString().Trim().Length;
		return "";
	}

	public string method_5()
	{
		StringBuilder stringBuilder = new StringBuilder();
		method_1();
		while (!method_2())
		{
			if (method_7() != ';')
			{
				stringBuilder.Append(method_7());
				int_0++;
				continue;
			}
			int_0++;
			break;
		}
		return stringBuilder.ToString().Trim();
	}

	public void method_6(string string_3, string string_4)
	{
		Class724 class724_ = new Class724(string_3, string_4);
		Add(class724_);
	}

	private char method_7()
	{
		return method_8(0);
	}

	private char method_8(int int_1)
	{
		if (int_0 + int_1 < string_2.Length)
		{
			return string_2[int_0 + int_1];
		}
		return '\0';
	}

	[SpecialName]
	public void method_9(string string_3)
	{
		if (string_3.StartsWith("'") && string_3.EndsWith("'"))
		{
			string_2 = string_3.Substring(1, string_3.Length - 2);
		}
		else
		{
			string_2 = string_3;
		}
	}
}
