using System.Text;

namespace ns4;

internal class Class69 : Interface1
{
	public static readonly Class69 class69_0 = new Class69();

	private static char[] char_0 = new char[4] { 'ק', 'ר', 'ש', 'ת' };

	private static char[] char_1 = new char[9] { 'י', 'כ', 'ל', 'מ', 'נ', 'ס', 'ע', 'פ', 'צ' };

	private static char[] char_2 = new char[9] { 'א', 'ב', 'ג', 'ד', 'ה', 'ו', 'ז', 'ח', 'ט' };

	private void method_0(StringBuilder sb, int value)
	{
		int num;
		for (num = value / 100; num > 4; num -= 4)
		{
			sb.Append(char_0[3]);
		}
		if (num > 0)
		{
			sb.Append(char_0[num - 1]);
		}
		value %= 100;
		if (value != 15 && value != 16)
		{
			num = value / 10;
			if (num > 0)
			{
				sb.Append(char_1[num - 1]);
			}
			num = value % 10;
			if (num > 0)
			{
				sb.Append(char_2[num - 1]);
			}
		}
		else
		{
			sb.Append((value == 15) ? "טו" : "טז");
		}
	}

	public string imethod_0(string format, int value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (value > 1000000000)
		{
			method_0(stringBuilder, value / 1000000000);
			stringBuilder.Append('׳');
		}
		value %= 1000000000;
		if (value > 1000000)
		{
			method_0(stringBuilder, value / 1000000);
			stringBuilder.Append('׳');
		}
		value %= 1000000;
		if (value > 1000)
		{
			method_0(stringBuilder, value / 1000);
			stringBuilder.Append('׳');
		}
		value %= 1000;
		if (value > 0)
		{
			method_0(stringBuilder, value);
		}
		if (stringBuilder.Length < 2)
		{
			stringBuilder.Append('\'');
		}
		else
		{
			stringBuilder.Insert(stringBuilder.Length - 1, '"');
		}
		return stringBuilder.ToString();
	}
}
