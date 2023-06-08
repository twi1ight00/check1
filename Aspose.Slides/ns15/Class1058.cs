using Aspose.Slides.Theme;
using ns63;
using ns9;

namespace ns15;

internal class Class1058
{
	internal static void smethod_0(IMasterTheme targetTheme, Class2718 master, Class153 colorMapping)
	{
		if (master.SlideSchemeColorSchemeAtom != null)
		{
			Class1050.smethod_0((ColorScheme)targetTheme.ColorScheme, master.SlideSchemeColorSchemeAtom, colorMapping);
		}
		Class2840[] rgSchemeListElementColorScheme = master.RgSchemeListElementColorScheme;
		foreach (Class2840 csa in rgSchemeListElementColorScheme)
		{
			ExtraColorScheme extraColorScheme = new ExtraColorScheme(targetTheme);
			Class1051.smethod_0(extraColorScheme, csa);
			((ExtraColorSchemeCollection)targetTheme.ExtraColorSchemes).Add(extraColorScheme);
		}
		((FormatScheme)targetTheme.FormatScheme).method_2();
		((FontScheme)targetTheme.FontScheme).method_0();
	}
}
