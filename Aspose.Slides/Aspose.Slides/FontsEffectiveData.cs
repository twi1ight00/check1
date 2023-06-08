using ns24;
using ns4;

namespace Aspose.Slides;

public class FontsEffectiveData : IFontsEffectiveData, IEffectiveData
{
	private IFontData ifontData_0;

	private IFontData ifontData_1;

	private IFontData ifontData_2;

	private Class340 class340_0 = new Class340();

	public IFontData LatinFont => ifontData_0;

	public IFontData EastAsianFont => ifontData_1;

	public IFontData ComplexScriptFont => ifontData_2;

	internal FontsEffectiveData()
	{
	}

	internal void method_0(IFonts source)
	{
		ifontData_0 = source.LatinFont;
		ifontData_1 = source.EastAsianFont;
		ifontData_2 = source.ComplexScriptFont;
		class340_0 = ((Fonts)source).PPTXUnsupportedProps;
	}

	internal string method_1(string lang)
	{
		if (lang != null && lang.Length != 0)
		{
			Fonts.Class47 @class = (Fonts.Class47)Fonts.idictionary_0[lang];
			if (@class == null)
			{
				return ifontData_0.FontName;
			}
			if (class340_0.Fonts.ContainsKey(@class.string_1))
			{
				return class340_0.Fonts[@class.string_1];
			}
			return @class.enum2_0 switch
			{
				Enum2.const_1 => ifontData_1.FontName, 
				Enum2.const_2 => ifontData_2.FontName, 
				_ => ifontData_0.FontName, 
			};
		}
		return ifontData_0.FontName;
	}

	internal string method_2(string lang)
	{
		if (lang != null && lang.Length != 0)
		{
			Fonts.Class47 @class = (Fonts.Class47)Fonts.idictionary_0[lang];
			if (@class == null)
			{
				return null;
			}
			if (class340_0.Fonts.ContainsKey(@class.string_1))
			{
				return class340_0.Fonts[@class.string_1];
			}
			return null;
		}
		return null;
	}
}
