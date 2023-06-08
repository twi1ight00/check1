using System.Collections.Generic;
using Aspose.Slides;
using ns24;
using ns56;

namespace ns18;

internal class Class952
{
	public static void smethod_0(IFonts fonts, Class1845 fontCollectionElementData)
	{
		if (fontCollectionElementData != null)
		{
			IFontData fontData = new FontData();
			Class950.smethod_0(fontData, fontCollectionElementData.Latin);
			fonts.LatinFont = fontData;
			IFontData fontData2 = new FontData();
			Class950.smethod_0(fontData2, fontCollectionElementData.Ea);
			fonts.EastAsianFont = fontData2;
			IFontData fontData3 = new FontData();
			Class950.smethod_0(fontData3, fontCollectionElementData.Cs);
			fonts.ComplexScriptFont = fontData3;
			smethod_1(fonts, fontCollectionElementData);
		}
	}

	private static void smethod_1(IFonts fonts, Class1845 fontCollectionElementData)
	{
		Class340 pPTXUnsupportedProps = ((Fonts)fonts).PPTXUnsupportedProps;
		Class1930[] fontList = fontCollectionElementData.FontList;
		foreach (Class1930 @class in fontList)
		{
			pPTXUnsupportedProps.method_0(@class.Script, @class.Typeface);
		}
		pPTXUnsupportedProps.ExtensionList = fontCollectionElementData.ExtLst;
	}

	public static void smethod_2(IFonts fonts, Class1845 fontCollectionElementData)
	{
		Class950.smethod_4(fonts.LatinFont, fontCollectionElementData.Latin);
		Class950.smethod_4(fonts.EastAsianFont, fontCollectionElementData.Ea);
		Class950.smethod_4(fonts.ComplexScriptFont, fontCollectionElementData.Cs);
		smethod_3(fonts, fontCollectionElementData);
	}

	private static void smethod_3(IFonts fonts, Class1845 fontCollectionElementData)
	{
		Class340 pPTXUnsupportedProps = ((Fonts)fonts).PPTXUnsupportedProps;
		foreach (KeyValuePair<string, string> font in pPTXUnsupportedProps.Fonts)
		{
			Class1930 @class = fontCollectionElementData.delegate1657_0();
			@class.Script = font.Key;
			@class.Typeface = font.Value;
		}
		fontCollectionElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}
}
