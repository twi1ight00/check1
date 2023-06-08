using Aspose.Slides.Theme;
using ns56;

namespace ns18;

internal class Class948
{
	internal delegate Class1818 Delegate15();

	internal static void smethod_0(IExtraColorScheme extraColorScheme, Class1818 extraColorSchemeElementData)
	{
		if (extraColorSchemeElementData != null)
		{
			Class932.smethod_0(extraColorScheme.ColorScheme, extraColorSchemeElementData.ClrScheme);
			Class931.smethod_4(((ExtraColorScheme)extraColorScheme).ColorMapping, extraColorSchemeElementData.ClrMap);
		}
	}

	internal static void smethod_1(IExtraColorScheme extraColorScheme, Class1818.Delegate1333 addExtraClrScheme)
	{
		if (extraColorScheme != null)
		{
			Class1818 @class = addExtraClrScheme();
			Class932.smethod_1(extraColorScheme.ColorScheme, @class.ClrScheme);
			Class931.smethod_9(((ExtraColorScheme)extraColorScheme).ColorMapping, @class.delegate1324_0);
		}
	}
}
