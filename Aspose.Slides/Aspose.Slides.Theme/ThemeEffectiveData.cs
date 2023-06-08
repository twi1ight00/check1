using System.Drawing;
using ns4;

namespace Aspose.Slides.Theme;

public class ThemeEffectiveData : IThemeEffectiveData
{
	private IColorScheme icolorScheme_0;

	private IFontScheme ifontScheme_0;

	private IFormatScheme iformatScheme_0;

	private IBaseSlide ibaseSlide_0;

	public IFontSchemeEffectiveData FontScheme => new FontSchemeEffectiveData(ifontScheme_0);

	public IFormatSchemeEffectiveData FormatScheme => new FormatSchemeEffectiveData(iformatScheme_0, ibaseSlide_0);

	internal IColorScheme ColorSchemeInternal => icolorScheme_0;

	internal IFontScheme FontSchemeInternal => ifontScheme_0;

	internal IFormatScheme FormatSchemeInternal => iformatScheme_0;

	internal ThemeEffectiveData(IThemeEffectiveData theme, IBaseSlide slide)
	{
		ibaseSlide_0 = slide;
		method_0((ThemeEffectiveData)theme);
	}

	internal ThemeEffectiveData(ITheme theme, IBaseSlide slide)
	{
		ibaseSlide_0 = slide;
		method_1(theme);
	}

	private void method_0(ThemeEffectiveData theme)
	{
		icolorScheme_0 = theme.ColorSchemeInternal;
		ifontScheme_0 = theme.FontSchemeInternal;
		iformatScheme_0 = theme.FormatSchemeInternal;
	}

	private void method_1(ITheme theme)
	{
		icolorScheme_0 = theme.ColorScheme;
		ifontScheme_0 = theme.FontScheme;
		iformatScheme_0 = theme.FormatScheme;
	}

	internal void method_2(ITheme theme)
	{
		if (theme != null)
		{
			if (theme.ColorScheme != null)
			{
				icolorScheme_0 = theme.ColorScheme;
			}
			if (theme.FontScheme != null)
			{
				ifontScheme_0 = theme.FontScheme;
			}
			if (theme.FormatScheme != null)
			{
				iformatScheme_0 = theme.FormatScheme;
			}
		}
	}

	public IColorSchemeEffectiveData GetColorScheme(Color styleColor)
	{
		return new ColorSchemeEffectiveData(icolorScheme_0, ibaseSlide_0, styleColor);
	}

	internal Class493 method_3(IBaseSlide colorMappingSlide, int index, ColorFormat colorFormat)
	{
		if (index == 0)
		{
			return null;
		}
		if (index > 0)
		{
			if (index <= iformatScheme_0.FillStyles.Count)
			{
				return new Class493(iformatScheme_0.FillStyles[index - 1], colorFormat.method_4(colorMappingSlide, null));
			}
			return null;
		}
		index = -index;
		if (index <= iformatScheme_0.BackgroundFillStyles.Count)
		{
			return new Class493(iformatScheme_0.BackgroundFillStyles[index - 1], colorFormat.method_4(colorMappingSlide, null));
		}
		return null;
	}

	internal FillFormat method_4(int index)
	{
		if (index == 0)
		{
			return null;
		}
		if (index > 0)
		{
			if (index <= iformatScheme_0.FillStyles.Count)
			{
				return (FillFormat)iformatScheme_0.FillStyles[index - 1];
			}
			return null;
		}
		index = -index;
		if (index <= iformatScheme_0.BackgroundFillStyles.Count)
		{
			return (FillFormat)iformatScheme_0.BackgroundFillStyles[index - 1];
		}
		return null;
	}

	internal Class512 method_5(IBaseSlide colorMappingSlide, int index, ColorFormat styleColor)
	{
		if (index == 0)
		{
			return null;
		}
		return new Class512(iformatScheme_0.LineStyles[index - 1], styleColor.method_4(colorMappingSlide, null));
	}

	internal Class492 method_6(IBaseSlide colorMappingSlide, uint index, ColorFormat styleColor)
	{
		if (index == 0)
		{
			return null;
		}
		return new Class492(iformatScheme_0.EffectStyles[(int)(index - 1)].EffectFormat, styleColor.method_4(colorMappingSlide, null));
	}

	internal Class539 method_7(IBaseSlide colorMappingSlide, uint index, ColorFormat styleColor)
	{
		if (index == 0)
		{
			return null;
		}
		return new Class539(iformatScheme_0.EffectStyles[(int)(index - 1)].ThreeDFormat, styleColor.method_4(colorMappingSlide, null));
	}
}
