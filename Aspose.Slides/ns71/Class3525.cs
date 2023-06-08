using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ns71;

internal static class Class3525
{
	public const char char_0 = '=';

	public const char char_1 = '\n';

	public const char char_2 = '\r';

	public const char char_3 = ' ';

	public static KeyValuePair<string, string> smethod_0(StringReader reader)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		string text = reader.ReadLine().Trim('\n', '\r', ' ');
		string[] array = text.Split('=');
		if (array.Length != 2)
		{
			throw new InvalidOperationException();
		}
		return new KeyValuePair<string, string>(array[0], array[1]);
	}

	public static string smethod_1(StringReader reader, int length)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		char[] array = new char[length];
		reader.Read(array, 0, length);
		return new string(array);
	}

	public static int smethod_2(StringReader reader, string value, out string result)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		result = null;
		StringBuilder stringBuilder = new StringBuilder();
		string text;
		int num;
		do
		{
			if (reader.Peek() != -1)
			{
				stringBuilder.Append((char)reader.Read());
				text = stringBuilder.ToString();
				num = text.IndexOf(value);
				continue;
			}
			return -1;
		}
		while (num == -1);
		result = text.Substring(0, num);
		return num;
	}

	public static int smethod_3(StringReader reader, out string result)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		result = null;
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		result = null;
		StringBuilder stringBuilder = new StringBuilder();
		string text;
		int num2;
		do
		{
			if (reader.Peek() != -1)
			{
				stringBuilder.Append((char)reader.Read());
				text = stringBuilder.ToString();
				int num = text.IndexOf("\r\n");
				if (num == -1)
				{
					num2 = text.IndexOf("\n\r");
					continue;
				}
				result = text.Substring(0, num);
				return num;
			}
			return -1;
		}
		while (num2 == -1);
		result = text.Substring(0, num2);
		return num2;
	}

	public static int smethod_4(StringReader reader, string value)
	{
		StringReader reader2 = new StringReader(reader.ToString());
		string result;
		return smethod_2(reader2, value, out result);
	}

	public static void smethod_5(StringReader reader)
	{
		while (true)
		{
			char c = (char)reader.Peek();
			if (c == '\r' || c == '\n')
			{
				reader.Read();
				continue;
			}
			break;
		}
	}
}
