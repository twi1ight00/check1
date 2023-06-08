using Aspose.Slides.Theme;
using ns56;

namespace ns18;

internal class Class932
{
	public static void smethod_0(IColorScheme colorScheme, Class1819 colorSchemeElementData)
	{
		if (colorSchemeElementData != null)
		{
			Class930.smethod_0(colorScheme.Accent1, colorSchemeElementData.Accent1);
			Class930.smethod_0(colorScheme.Accent2, colorSchemeElementData.Accent2);
			Class930.smethod_0(colorScheme.Accent3, colorSchemeElementData.Accent3);
			Class930.smethod_0(colorScheme.Accent4, colorSchemeElementData.Accent4);
			Class930.smethod_0(colorScheme.Accent5, colorSchemeElementData.Accent5);
			Class930.smethod_0(colorScheme.Accent6, colorSchemeElementData.Accent6);
			Class930.smethod_0(colorScheme.Dark1, colorSchemeElementData.Dk1);
			Class930.smethod_0(colorScheme.Dark2, colorSchemeElementData.Dk2);
			Class930.smethod_0(colorScheme.FollowedHyperlink, colorSchemeElementData.FolHlink);
			Class930.smethod_0(colorScheme.Hyperlink, colorSchemeElementData.Hlink);
			Class930.smethod_0(colorScheme.Light1, colorSchemeElementData.Lt1);
			Class930.smethod_0(colorScheme.Light2, colorSchemeElementData.Lt2);
			((ColorScheme)colorScheme).Name = colorSchemeElementData.Name;
			((ColorScheme)colorScheme).PPTXUnsupportedProps.ExtensionList = colorSchemeElementData.ExtLst;
		}
	}

	public static void smethod_1(IColorScheme colorScheme, Class1819 colorSchemeElementData)
	{
		Class930.smethod_3(colorScheme.Accent1, colorSchemeElementData.Accent1);
		Class930.smethod_3(colorScheme.Accent2, colorSchemeElementData.Accent2);
		Class930.smethod_3(colorScheme.Accent3, colorSchemeElementData.Accent3);
		Class930.smethod_3(colorScheme.Accent4, colorSchemeElementData.Accent4);
		Class930.smethod_3(colorScheme.Accent5, colorSchemeElementData.Accent5);
		Class930.smethod_3(colorScheme.Accent6, colorSchemeElementData.Accent6);
		Class930.smethod_3(colorScheme.Dark1, colorSchemeElementData.Dk1);
		Class930.smethod_3(colorScheme.Dark2, colorSchemeElementData.Dk2);
		Class930.smethod_3(colorScheme.FollowedHyperlink, colorSchemeElementData.FolHlink);
		Class930.smethod_3(colorScheme.Hyperlink, colorSchemeElementData.Hlink);
		Class930.smethod_3(colorScheme.Light1, colorSchemeElementData.Lt1);
		Class930.smethod_3(colorScheme.Light2, colorSchemeElementData.Lt2);
		colorSchemeElementData.Name = ((ColorScheme)colorScheme).Name;
		colorSchemeElementData.delegate1535_0(((ColorScheme)colorScheme).PPTXUnsupportedProps.ExtensionList);
	}

	public static void smethod_2(IColorScheme colorScheme, Class1819.Delegate1336 addClrScheme)
	{
		if (colorScheme != null)
		{
			Class1819 colorSchemeElementData = addClrScheme();
			smethod_1(colorScheme, colorSchemeElementData);
		}
	}
}
