using System.IO;
using System.Text;
using xf9a9481c3f63a419;

namespace x6c95d9cf46ff5f25;

internal class x09d499c483428bd1
{
	private static readonly string[] xcb93edca77239570 = new string[3] { "/usr/share/fonts", "/usr/local/share/fonts", "/usr/X11R6/lib/X11/fonts" };

	public static bool xadc83cc585a89881(string x9e9070c6c983bbc0)
	{
		if (0 > x9e9070c6c983bbc0.IndexOf("Symbol") && 0 > x9e9070c6c983bbc0.IndexOf("Webdings") && 0 > x9e9070c6c983bbc0.IndexOf("Wingdings"))
		{
			return 0 <= x9e9070c6c983bbc0.IndexOf("Dingbats");
		}
		return true;
	}

	public static string x728c19b085a53832(string x9e9070c6c983bbc0)
	{
		return x9e9070c6c983bbc0 switch
		{
			"Helv" => "Arial", 
			"Tms Rmn" => "Times New Roman", 
			"MS Serif" => "Times New Roman", 
			"MS Sans Serif" => "Microsoft Sans Serif", 
			"Courier" => "Courier New", 
			_ => x9e9070c6c983bbc0, 
		};
	}

	public static char xa8b9c2cfa706a303(char x3c4da2980d043c95)
	{
		if (!x0a2abff5995103da(x3c4da2980d043c95))
		{
			return x3c4da2980d043c95;
		}
		return (char)(x3c4da2980d043c95 - 61440);
	}

	public static string xa8b9c2cfa706a303(string xf6987a1745781d6f)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (char x3c4da2980d043c in xf6987a1745781d6f)
		{
			stringBuilder.Append(xa8b9c2cfa706a303(x3c4da2980d043c));
		}
		return stringBuilder.ToString();
	}

	public static bool x0a2abff5995103da(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 >= '\uf020')
		{
			return x3c4da2980d043c95 <= '\uf0ff';
		}
		return false;
	}

	public static bool x09468e7ac5460b6d(char x3c4da2980d043c95)
	{
		if (x3c4da2980d043c95 >= ' ')
		{
			return x3c4da2980d043c95 <= 'ÿ';
		}
		return false;
	}

	public static char x1ea7c95c824f6882(char x3c4da2980d043c95)
	{
		if (!x09468e7ac5460b6d(x3c4da2980d043c95))
		{
			return x3c4da2980d043c95;
		}
		return (char)(x3c4da2980d043c95 + 61440);
	}

	internal static string x7e3d53d5e4ddb3fd()
	{
		switch (xed747ca236d86aa0.xf40b599afa14f524())
		{
		case x3bb20242a64c30a9.x8a2adacc78a4bcc9:
			return xed747ca236d86aa0.x0f5d18019ab06bc5();
		case x3bb20242a64c30a9.x720fa05edddb7fd4:
			return "/Library/Fonts";
		case x3bb20242a64c30a9.x40a5752567c3c6a6:
		{
			string[] array = xcb93edca77239570;
			foreach (string text in array)
			{
				if (Directory.Exists(text))
				{
					return text;
				}
			}
			return string.Empty;
		}
		default:
			return string.Empty;
		}
	}
}
