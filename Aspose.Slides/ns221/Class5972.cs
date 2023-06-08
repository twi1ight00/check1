using System.Text;

namespace ns221;

internal static class Class5972
{
	private const int int_0 = 65;

	private const int int_1 = 26;

	public static int smethod_0(string text)
	{
		int num = 1;
		int num2 = 0;
		for (int i = 0; i < text.Length; i++)
		{
			int num3 = text.Length - i - 1;
			char c = text[num3];
			int num4 = char.ToUpper(c) - 65;
			int num5 = ((text.Length != 1 && num3 <= 0) ? 1 : 0);
			num2 += (num4 + num5) * num;
			num *= 26;
		}
		return num2;
	}

	public static string smethod_1(int value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (value < 26)
		{
			stringBuilder.Append((char)(value + 65));
		}
		else
		{
			do
			{
				int num = ((value < 26) ? 1 : 0);
				int num2 = value % 26 + 65 - num;
				stringBuilder.Append((char)num2);
				value /= 26;
			}
			while (value > 0);
		}
		return smethod_2(stringBuilder.ToString());
	}

	private static string smethod_2(string s)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int num = s.Length - 1; num >= 0; num--)
		{
			stringBuilder.Append(s[num]);
		}
		return stringBuilder.ToString();
	}
}
