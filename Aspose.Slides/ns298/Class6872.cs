using System.Drawing;
using System.Globalization;
using System.IO;

namespace ns298;

internal class Class6872
{
	private static CultureInfo cultureInfo_0;

	public static CultureInfo HtmlCulture
	{
		get
		{
			if (cultureInfo_0 == null)
			{
				cultureInfo_0 = new CultureInfo("en-US");
			}
			return cultureInfo_0;
		}
	}

	private Class6872()
	{
	}

	public static string smethod_0(Color color)
	{
		return ColorTranslator.ToHtml(color);
	}

	public static string smethod_1(float value)
	{
		return value.ToString(HtmlCulture) + "pt";
	}

	public static string smethod_2(float value)
	{
		return ((int)value).ToString();
	}

	internal static string smethod_3(string filepath)
	{
		string directoryName = Path.GetDirectoryName(filepath);
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filepath);
		return Path.Combine(directoryName, fileNameWithoutExtension + "_files");
	}

	internal static string smethod_4(string path)
	{
		string directoryName = Path.GetDirectoryName(path);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		return path;
	}
}
