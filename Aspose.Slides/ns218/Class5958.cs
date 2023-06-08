using System.Text;

namespace ns218;

internal static class Class5958
{
	public static bool smethod_0(string fontName)
	{
		if (0 > fontName.IndexOf("Symbol") && 0 > fontName.IndexOf("Webdings") && 0 > fontName.IndexOf("Wingdings"))
		{
			return 0 <= fontName.IndexOf("Dingbats");
		}
		return true;
	}

	public static string smethod_1(string fontName)
	{
		return fontName switch
		{
			"Helv" => "Arial", 
			"Tms Rmn" => "Times New Roman", 
			"MS Serif" => "Times New Roman", 
			"MS Sans Serif" => "Microsoft Sans Serif", 
			"Courier" => "Courier New", 
			_ => fontName, 
		};
	}

	public static char smethod_2(char c)
	{
		if (!smethod_4(c))
		{
			return c;
		}
		return (char)(c - 61440);
	}

	public static string smethod_3(string str)
	{
		StringBuilder stringBuilder = new StringBuilder(str.Length);
		for (int i = 0; i < str.Length; i++)
		{
			stringBuilder.Append(smethod_2(str[i]));
		}
		return stringBuilder.ToString();
	}

	public static bool smethod_4(char c)
	{
		if (c >= '\uf020')
		{
			return c <= '\uf0ff';
		}
		return false;
	}

	public static char smethod_5(char c)
	{
		return (char)(c + 61440);
	}
}
