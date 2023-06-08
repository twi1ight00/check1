using ns24;
using ns4;

namespace Aspose.Slides.Theme;

public class FontScheme : IFontScheme
{
	private Fonts fonts_0;

	private Fonts fonts_1;

	private string string_0;

	private Class339 class339_0 = new Class339();

	private uint uint_0;

	private static readonly FontData fontData_0 = new FontData("Arial");

	internal Class339 PPTXUnsupportedProps => class339_0;

	public IFonts Minor => fonts_1;

	public IFonts Major => fonts_0;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			method_2();
		}
	}

	internal uint Version => uint_0 + fonts_1.Version + fonts_0.Version;

	internal FontScheme(Class48 fontsList)
	{
		fonts_0 = new Fonts(fontsList);
		fonts_1 = new Fonts(fontsList);
	}

	internal void method_0()
	{
		fonts_0.LatinFont = fontData_0;
		fonts_0.EastAsianFont = fontData_0;
		fonts_0.ComplexScriptFont = fontData_0;
		fonts_1.LatinFont = fontData_0;
		fonts_1.EastAsianFont = fontData_0;
		fonts_1.ComplexScriptFont = fontData_0;
		string_0 = "Arial";
		method_2();
	}

	internal void method_1(FontScheme fontScheme)
	{
		fonts_0.method_1(fontScheme.fonts_0);
		fonts_1.method_1(fontScheme.fonts_1);
		string_0 = fontScheme.string_0;
		if (fontScheme.class339_0.ExtensionList != null)
		{
			class339_0.ExtensionList = fontScheme.class339_0.ExtensionList.Clone();
		}
		method_2();
	}

	private void method_2()
	{
		uint_0++;
	}
}
