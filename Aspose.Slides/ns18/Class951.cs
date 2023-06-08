using Aspose.Slides.Theme;
using ns56;

namespace ns18;

internal class Class951
{
	public static void smethod_0(IFontScheme fontScheme, Class1847 fontSchemeElementData)
	{
		if (fontSchemeElementData != null)
		{
			Class952.smethod_0(fontScheme.Major, fontSchemeElementData.MajorFont);
			Class952.smethod_0(fontScheme.Minor, fontSchemeElementData.MinorFont);
			((FontScheme)fontScheme).PPTXUnsupportedProps.ExtensionList = fontSchemeElementData.ExtLst;
			fontScheme.Name = fontSchemeElementData.Name;
		}
	}

	public static void smethod_1(IFontScheme fontScheme, Class1847 fontSchemeElementData)
	{
		Class952.smethod_2(fontScheme.Major, fontSchemeElementData.MajorFont);
		Class952.smethod_2(fontScheme.Minor, fontSchemeElementData.MinorFont);
		fontSchemeElementData.delegate1535_0(((FontScheme)fontScheme).PPTXUnsupportedProps.ExtensionList);
		fontSchemeElementData.Name = fontScheme.Name;
	}

	public static void smethod_2(IFontScheme fontScheme, Class1847.Delegate1420 addFontScheme)
	{
		if (fontScheme != null)
		{
			Class1847 fontSchemeElementData = addFontScheme();
			smethod_1(fontScheme, fontSchemeElementData);
		}
	}
}
