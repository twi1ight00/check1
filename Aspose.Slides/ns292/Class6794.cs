using System;
using System.IO;

namespace ns292;

internal class Class6794 : ICloneable
{
	public const string string_0 = "_files";

	public const string string_1 = "style.css";

	public const string string_2 = "style{0}p{1}.css";

	private const string string_3 = "a6622bbc-6ab7-4eeb-9fd5-09795537c25b";

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	public string BundleRoot => string_4;

	public string ImageFolder
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public string StylesheetFolder
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string CommonFolder
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	private Class6794()
	{
	}

	public Class6794(string fullHtmlFilePath)
	{
		if (string.IsNullOrEmpty(fullHtmlFilePath) || fullHtmlFilePath.Trim().Length == 0)
		{
			throw new ArgumentException("Path is null, empty or contains whitespace only.", "fullHtmlFilePath");
		}
		string_4 = Path.GetDirectoryName(fullHtmlFilePath);
		string_7 = Path.GetFileNameWithoutExtension(fullHtmlFilePath) + "_files";
	}

	public string method_0(string imageFileName)
	{
		return method_6(ImageFolder, imageFileName);
	}

	public string method_1(string cssFileName)
	{
		return method_6((StylesheetFolder == "a6622bbc-6ab7-4eeb-9fd5-09795537c25b") ? null : StylesheetFolder, cssFileName);
	}

	public string method_2(string fileName)
	{
		return Path.Combine(Path.Combine(BundleRoot, method_8()), fileName);
	}

	public string method_3(string imageFileName)
	{
		return smethod_0(Path.Combine(method_7(ImageFolder), imageFileName));
	}

	public string method_4(string cssFileName)
	{
		if (StylesheetFolder == "a6622bbc-6ab7-4eeb-9fd5-09795537c25b")
		{
			return cssFileName;
		}
		return smethod_0(Path.Combine(method_7(StylesheetFolder), cssFileName));
	}

	public string method_5(string fileName)
	{
		return smethod_0(Path.Combine(method_8(), fileName));
	}

	private static string smethod_0(string reference)
	{
		return reference.Replace('\\', '/');
	}

	private string method_6(string resourcePath, string fileName)
	{
		string path = method_7(resourcePath);
		return Path.Combine(Path.Combine(BundleRoot, path), fileName);
	}

	private string method_7(string resourcePath)
	{
		return resourcePath ?? method_8();
	}

	private string method_8()
	{
		return CommonFolder ?? string.Empty;
	}

	public object Clone()
	{
		Class6794 @class = new Class6794();
		@class.string_4 = string_4;
		@class.string_5 = string_5;
		@class.string_6 = string_6;
		@class.string_7 = string_7;
		return @class;
	}
}
