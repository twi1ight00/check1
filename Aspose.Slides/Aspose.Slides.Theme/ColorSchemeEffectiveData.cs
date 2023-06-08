using System.Drawing;

namespace Aspose.Slides.Theme;

public class ColorSchemeEffectiveData : IColorSchemeEffectiveData, IEffectiveData
{
	internal Color[] color_0 = new Color[12];

	public Color this[ColorSchemeIndex index]
	{
		get
		{
			int num = (int)index;
			if (num >= 0 && num < color_0.Length)
			{
				return color_0[num];
			}
			return Color.Black;
		}
	}

	public Color Dark1 => this[ColorSchemeIndex.Dark1];

	public Color Light1 => this[ColorSchemeIndex.Light1];

	public Color Dark2 => this[ColorSchemeIndex.Dark2];

	public Color Light2 => this[ColorSchemeIndex.Light2];

	public Color Accent1 => this[ColorSchemeIndex.Accent1];

	public Color Accent2 => this[ColorSchemeIndex.Accent2];

	public Color Accent3 => this[ColorSchemeIndex.Accent3];

	public Color Accent4 => this[ColorSchemeIndex.Accent4];

	public Color Accent5 => this[ColorSchemeIndex.Accent5];

	public Color Accent6 => this[ColorSchemeIndex.Accent6];

	public Color Hyperlink => this[ColorSchemeIndex.Hyperlink];

	public Color FollowedHyperlink => this[ColorSchemeIndex.FollowedHyperlink];

	internal ColorSchemeEffectiveData(IColorScheme source, IBaseSlide slide, Color styleColor)
	{
		method_0(source, slide, styleColor);
	}

	internal void method_0(IColorScheme source, IBaseSlide slide, Color styleColor)
	{
		ColorScheme colorScheme = (ColorScheme)source;
		for (int i = 0; i < colorScheme.colorFormat_0.Length; i++)
		{
			ref Color reference = ref color_0[i];
			reference = colorScheme.colorFormat_0[i].method_5(slide, new FloatColor(styleColor));
		}
	}

	internal void method_1(IColorScheme source, IBaseSlide slide, Color styleColor)
	{
		ColorScheme colorScheme = (ColorScheme)source;
		for (int i = 0; i < colorScheme.colorFormat_0.Length; i++)
		{
			if (colorScheme.colorFormat_0[i].ColorType != ColorType.NotDefined)
			{
				ref Color reference = ref color_0[i];
				reference = colorScheme.colorFormat_0[i].method_5(slide, new FloatColor(styleColor));
			}
		}
	}
}
