using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns8;

internal class Class729 : Class725
{
	private StreamReader streamReader_0;

	private char char_0;

	private StringBuilder stringBuilder_0 = new StringBuilder();

	public static bool smethod_0(char char_1)
	{
		return "\t\n\r ".IndexOf(char_1) != -1;
	}

	public char method_1()
	{
		char c = ' ';
		while (!method_2())
		{
			c = method_3();
			if (!smethod_0(c))
			{
				break;
			}
		}
		return c;
	}

	public bool method_2()
	{
		return streamReader_0.Peek() == -1;
	}

	public char method_3()
	{
		return (char)streamReader_0.Read();
	}

	public string method_4()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(char_0);
		while (!method_2())
		{
			char c = method_3();
			if (!smethod_0(c) && c != '=' && c != '>')
			{
				stringBuilder.Append(c);
				continue;
			}
			char_0 = c;
			break;
		}
		return stringBuilder.ToString().Trim();
	}

	public string method_5()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (char_0 == '=')
		{
			char c = method_3();
			if (c != '\'' && c != '"')
			{
				stringBuilder.Append(c);
				while (!method_2())
				{
					c = method_3();
					if (smethod_0(c))
					{
						break;
					}
					switch (c)
					{
					case '"':
						stringBuilder.Append('\'');
						break;
					default:
						stringBuilder.Append(c);
						break;
					case '>':
						char_0 = c;
						return stringBuilder.ToString().Trim();
					}
				}
			}
			else
			{
				char c2 = c;
				while (!method_2())
				{
					c = method_3();
					if (c == c2)
					{
						break;
					}
					stringBuilder.Append(c);
				}
			}
			char_0 = method_1();
		}
		return stringBuilder.ToString().Trim();
	}

	public void method_6(string string_2, string string_3)
	{
		Class724 class724_ = new Class724(string_2, string_3);
		Add(class724_);
	}

	[SpecialName]
	public StringBuilder method_7()
	{
		return stringBuilder_0;
	}

	[SpecialName]
	public StreamReader method_8()
	{
		return streamReader_0;
	}

	[SpecialName]
	public void method_9(StreamReader streamReader_1)
	{
		streamReader_0 = streamReader_1;
	}

	[SpecialName]
	public char method_10()
	{
		return char_0;
	}

	[SpecialName]
	public void method_11(char char_1)
	{
		char_0 = char_1;
	}
}
