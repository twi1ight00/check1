using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns8;

internal class Class726 : Class725
{
	private Stream stream_0;

	private StreamReader streamReader_0;

	private char char_0;

	private string string_2;

	public Stream Source => stream_0;

	public Class726()
	{
	}

	public Class726(string string_3)
	{
		string_2 = string_3;
	}

	public static bool smethod_0(char char_1)
	{
		return "\t\n\r ".IndexOf(char_1) != -1;
	}

	public void method_1()
	{
		while (!method_2() && smethod_0(method_10()))
		{
			method_7();
		}
	}

	public bool method_2()
	{
		return streamReader_0.Peek() == -1;
	}

	public string method_3()
	{
		StringBuilder stringBuilder = new StringBuilder();
		method_1();
		while (!method_2())
		{
			if (method_10() != ':')
			{
				if (method_10() != 0 && method_10() != '\r' && method_10() != '\n' && method_10() != '\t')
				{
					stringBuilder.Append(method_10());
					method_7();
				}
				else
				{
					method_7();
				}
				continue;
			}
			method_7();
			break;
		}
		method_1();
		if (stringBuilder.Length == 0)
		{
			return null;
		}
		return stringBuilder.ToString().Trim();
	}

	public string method_4()
	{
		StringBuilder stringBuilder = new StringBuilder();
		method_1();
		while (!method_2() && method_10() != '\n' && method_10() != '\r' && method_10() != '\t' && method_10() != '}')
		{
			if (method_10() != ';')
			{
				stringBuilder.Append(method_10());
				method_7();
				continue;
			}
			method_7();
			if (method_10() == '\n' || method_10() == '\r' || method_10() == '\t' || method_10() == '}' || method_10() == ' ')
			{
				break;
			}
			stringBuilder.Append(';');
			return stringBuilder.ToString().Trim();
		}
		method_1();
		if (stringBuilder.Length == 0)
		{
			return null;
		}
		return stringBuilder.ToString().Trim();
	}

	public void method_5(string string_3, string string_4)
	{
		Class724 class724_ = new Class724(string_3, string_4);
		Add(class724_);
	}

	public void method_6()
	{
		char_0 = (char)streamReader_0.Read();
	}

	public void method_7()
	{
		method_6();
	}

	[SpecialName]
	public void method_8(Stream stream_1)
	{
		stream_0 = stream_1;
		streamReader_0 = new StreamReader(stream_0);
	}

	[SpecialName]
	public string method_9()
	{
		return string_2;
	}

	[SpecialName]
	public char method_10()
	{
		return char_0;
	}
}
