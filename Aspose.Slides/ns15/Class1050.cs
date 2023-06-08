using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Theme;
using ns33;
using ns63;
using ns9;

namespace ns15;

internal class Class1050
{
	internal static void smethod_0(ColorScheme targetScheme, Class2840 atom, Class153 colorMap)
	{
		Color[] array = new Color[8];
		for (int i = 0; i < 8; i++)
		{
			ref Color reference = ref array[i];
			reference = Class1165.smethod_8(255, (uint)atom.method_2(i));
		}
		colorMap.method_0();
		targetScheme[ColorSchemeIndex.Light1].Color = array[0];
		targetScheme[ColorSchemeIndex.Dark1].Color = array[1];
		targetScheme[ColorSchemeIndex.Light2].Color = array[2];
		targetScheme[ColorSchemeIndex.Dark2].Color = array[3];
		targetScheme[ColorSchemeIndex.Accent1].Color = array[4];
		targetScheme[ColorSchemeIndex.Accent2].Color = array[5];
		targetScheme[ColorSchemeIndex.Hyperlink].Color = array[6];
		targetScheme[ColorSchemeIndex.FollowedHyperlink].Color = array[7];
		targetScheme[ColorSchemeIndex.Accent3].Color = Color.FromArgb(155, 187, 89);
		targetScheme[ColorSchemeIndex.Accent4].Color = Color.FromArgb(128, 100, 162);
		targetScheme[ColorSchemeIndex.Accent5].Color = Color.FromArgb(75, 172, 198);
		targetScheme[ColorSchemeIndex.Accent6].Color = Color.FromArgb(247, 150, 70);
	}

	internal static void smethod_1(IColorScheme domColorScheme, Class2639 pptContainer, bool list)
	{
		Class2840 @class = new Class2840();
		pptContainer.Records.Add(@class);
		if (domColorScheme != null)
		{
			@class.Header.Instance = (short)((!list) ? 1 : 6);
			if (domColorScheme.Light1 != null && domColorScheme.Light1.ColorType != ColorType.NotDefined && domColorScheme.Dark1 != null && domColorScheme.Dark1.ColorType != ColorType.NotDefined)
			{
				@class.method_3(0, domColorScheme.Light1.Color.ToArgb());
				@class.method_3(1, domColorScheme.Dark1.Color.ToArgb());
			}
			if (domColorScheme.Light2 != null && domColorScheme.Light2.ColorType != ColorType.NotDefined && domColorScheme.Dark2 != null && domColorScheme.Dark2.ColorType != ColorType.NotDefined)
			{
				@class.method_3(2, domColorScheme.Light2.Color.ToArgb());
				@class.method_3(3, domColorScheme.Dark2.Color.ToArgb());
			}
			if (domColorScheme.Accent1 != null && domColorScheme.Accent1.ColorType != ColorType.NotDefined)
			{
				@class.method_3(4, domColorScheme.Accent1.Color.ToArgb());
			}
			if (domColorScheme.Accent2 != null && domColorScheme.Accent2.ColorType != ColorType.NotDefined)
			{
				@class.method_3(5, domColorScheme.Accent2.Color.ToArgb());
			}
			if (domColorScheme.Hyperlink != null && domColorScheme.Hyperlink.ColorType != ColorType.NotDefined)
			{
				@class.method_3(6, domColorScheme.Hyperlink.Color.ToArgb());
			}
			if (domColorScheme.FollowedHyperlink != null && domColorScheme.FollowedHyperlink.ColorType != ColorType.NotDefined)
			{
				@class.method_3(7, domColorScheme.FollowedHyperlink.Color.ToArgb());
			}
		}
	}

	private static bool smethod_2(Color color1, Color color2)
	{
		return smethod_3(color1) > smethod_3(color2);
	}

	private static float smethod_3(Color color)
	{
		return 0.2126f * (float)(int)color.R + 0.7152f * (float)(int)color.G + 0.0722f * (float)(int)color.B;
	}
}
