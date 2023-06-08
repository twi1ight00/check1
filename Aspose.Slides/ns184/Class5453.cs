using System;
using System.Text;

namespace ns184;

internal class Class5453
{
	private static string[] string_0 = new string[3]
	{
		Class5729.string_1,
		Class5729.string_2,
		Class5729.string_3
	};

	private static string[] string_1 = new string[1] { "light" };

	private static string[] string_2 = new string[1] { "medium" };

	private static string[] string_3 = new string[2] { "demi", "semi" };

	private static string[] string_4 = new string[1] { "bold" };

	private static string[] string_5 = new string[6] { "extrabold", "extra bold", "black", "heavy", "ultra", "super" };

	private Class5453()
	{
	}

	public static int smethod_0(string text)
	{
		int num = 400;
		try
		{
			num = int.Parse(text);
			num = num / 100 * 100;
			num = Math.Max(num, 100);
			return Math.Min(num, 900);
		}
		catch (Exception ex)
		{
			if (ex is FormatException)
			{
				if (text.Equals("normal"))
				{
					return 400;
				}
				if (text.Equals("bold"))
				{
					return 700;
				}
				throw new ArgumentException("Illegal value for font weight: '" + text + "'. Use one of: 100, 200, 300, 400, 500, 600, 700, 800, 900, normal (=400), bold (=700)");
			}
			throw;
		}
	}

	public static string smethod_1(string str)
	{
		if (str != null)
		{
			StringBuilder stringBuilder = new StringBuilder(str.Length);
			int i = 0;
			for (int length = str.Length; i < length; i++)
			{
				char c = str[i];
				if (c != ' ' && c != '\r' && c != '\n' && c != '\t')
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}
		return str;
	}

	public static string smethod_2(string fontName)
	{
		if (fontName != null)
		{
			for (int i = 0; i < string_0.Length; i++)
			{
				if (fontName.IndexOf(string_0[i]) != -1)
				{
					return Class5729.string_1;
				}
			}
		}
		return Class5729.string_0;
	}

	public static int smethod_3(string fontName)
	{
		int result = Class5729.int_2;
		for (int i = 0; i < string_4.Length; i++)
		{
			if (fontName.IndexOf(string_4[i]) != -1)
			{
				result = Class5729.int_1;
				break;
			}
		}
		for (int j = 0; j < string_2.Length; j++)
		{
			if (fontName.IndexOf(string_2[j]) != -1)
			{
				result = Class5729.int_2 + 100;
				break;
			}
		}
		for (int k = 0; k < string_3.Length; k++)
		{
			if (fontName.IndexOf(string_3[k]) != -1)
			{
				result = Class5729.int_1 - 100;
				break;
			}
		}
		for (int l = 0; l < string_5.Length; l++)
		{
			if (fontName.IndexOf(string_5[l]) != -1)
			{
				result = Class5729.int_0;
				break;
			}
		}
		for (int m = 0; m < string_1.Length; m++)
		{
			if (fontName.IndexOf(string_1[m]) != -1)
			{
				result = Class5729.int_3;
				break;
			}
		}
		return result;
	}
}
