using System;
using System.Text;

namespace ns4;

internal class Class68 : Interface1
{
	public static readonly Class68 class68_0 = new Class68();

	private static readonly char[] char_0 = new char[10] { '○', '一', '二', '三', '四', '五', '六', '七', '八', '九' };

	private static char[] char_1 = new char[3] { '十', '百', '千' };

	public string imethod_0(string format, int value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (format != null && format.IndexOf('e') >= 0)
		{
			while (value > 0)
			{
				stringBuilder.Append(char_0[value % 10]);
				value /= 10;
			}
			if (stringBuilder.Length > 0)
			{
				int num = stringBuilder.Length / 2;
				for (int i = 0; i < num; i++)
				{
					char value2 = stringBuilder[i];
					stringBuilder[i] = stringBuilder[stringBuilder.Length - 1 - i];
					stringBuilder[stringBuilder.Length - 1 - i] = value2;
				}
			}
			else
			{
				stringBuilder.Append(char_0[0]);
			}
			return stringBuilder.ToString();
		}
		if (value >= 100)
		{
			throw new FormatException("");
		}
		if (value >= 20)
		{
			stringBuilder.Append(char_0[value / 10]);
		}
		if (value >= 10)
		{
			stringBuilder.Append(char_1[0]);
		}
		value %= 10;
		if (value > 0)
		{
			stringBuilder.Append(char_0[value]);
		}
		return stringBuilder.ToString();
	}
}
