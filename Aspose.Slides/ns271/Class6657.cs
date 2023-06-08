using System;
using System.Collections;
using System.Drawing;
using ns218;
using ns221;
using ns234;

namespace ns271;

internal class Class6657
{
	private const string string_0 = "Times New Roman";

	private readonly object object_0 = new object();

	private readonly Class5968 class5968_0;

	private readonly IDictionary idictionary_0 = Class6152.smethod_0();

	internal Class6657(Class6654[] availableFontsData)
	{
		class5968_0 = smethod_0(availableFontsData);
	}

	[Attribute7(false)]
	private static Class5968 smethod_0(Class6654[] availableFontsData)
	{
		Class5968 @class = new Class5968(isCaseSensitive: false);
		Class6732 class2 = new Class6732();
		foreach (Class6654 fontData in availableFontsData)
		{
			try
			{
				Class6723[] array = class2.method_1(fontData);
				if (array == null)
				{
					continue;
				}
				Class6723[] array2 = array;
				foreach (Class6723 class3 in array2)
				{
					Class6723 class4 = (Class6723)@class[class3.FullName];
					if (class4 == null || class3.IsTtc)
					{
						@class[class3.FullName] = class3;
					}
				}
			}
			catch (Exception)
			{
			}
		}
		return @class;
	}

	public Class6730 method_0(string familyName, FontStyle style)
	{
		Class6730 @class = method_3(familyName, style);
		string alterFontName = null;
		if (@class == null)
		{
			switch (familyName)
			{
			case "Segoe":
				alterFontName = "Segoe UI";
				break;
			case "Meiryo":
				alterFontName = "Meiryo UI";
				break;
			case "Lao":
				alterFontName = "Lao UI";
				break;
			case "Khmer":
				alterFontName = "Khmer UI";
				break;
			case "Helvetica":
				alterFontName = "Arial";
				break;
			default:
				smethod_1(familyName, out alterFontName);
				break;
			}
			if (Class5964.smethod_20(alterFontName))
			{
				@class = method_3(alterFontName, style);
			}
		}
		return @class;
	}

	private static bool smethod_1(string fontName, out string alterFontName)
	{
		try
		{
			FontFamily fontFamily = new FontFamily(fontName);
			alterFontName = fontFamily.Name;
			return true;
		}
		catch (Exception)
		{
			alterFontName = null;
			return false;
		}
	}

	public Class6730 method_1(FontStyle style)
	{
		return method_3("Times New Roman", style);
	}

	public Class6730 method_2()
	{
		foreach (Class6723 value in class5968_0.GetValueList())
		{
			Class6730 class2 = method_3(value.FamilyName, FontStyle.Regular);
			if (class2 != null)
			{
				return class2;
			}
		}
		return null;
	}

	[Attribute7(false)]
	private Class6730 method_3(string familyName, FontStyle style)
	{
		Class6731 @class = (Class6731)idictionary_0[familyName];
		if (@class == null)
		{
			lock (object_0)
			{
				@class = (Class6731)idictionary_0[familyName];
				if (@class == null)
				{
					try
					{
						@class = method_4(familyName);
						idictionary_0[familyName] = @class;
					}
					catch (Exception)
					{
						return null;
					}
				}
			}
		}
		return @class.method_0(style, isExactStyle: false);
	}

	private Class6731 method_4(string familyName)
	{
		Class6731 @class = new Class6731(familyName);
		foreach (Class6723 value in class5968_0.GetValueList())
		{
			if (Class6165.smethod_0(familyName, value.FamilyName))
			{
				Class6732 class3 = new Class6732();
				Class6730 class4 = class3.Read(value.Data, value.FullName);
				if (class4.method_6(familyName))
				{
					@class.Add(class4);
				}
			}
		}
		return @class;
	}
}
