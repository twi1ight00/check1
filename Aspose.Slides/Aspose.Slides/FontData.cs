using Aspose.Slides.Theme;
using ns24;
using ns4;
using ns63;

namespace Aspose.Slides;

public sealed class FontData : IFontData
{
	private Class338 class338_0 = new Class338();

	private string string_0;

	internal static readonly FontData fontData_0 = (FontData)Class53.DefaultFontsList.method_5(65535).FontData;

	internal Class338 PPTXUnsupportedProps => class338_0;

	public string FontName
	{
		get
		{
			return string_0;
		}
		internal set
		{
			string_0 = value;
		}
	}

	internal byte CharSet
	{
		get
		{
			return PPTXUnsupportedProps.Charset;
		}
		set
		{
			PPTXUnsupportedProps.Charset = value;
		}
	}

	internal byte PitchFamily
	{
		get
		{
			return PPTXUnsupportedProps.PitchFamily;
		}
		set
		{
			PPTXUnsupportedProps.PitchFamily = value;
		}
	}

	internal byte PitchAndFamily => PPTXUnsupportedProps.PitchFamily;

	internal byte[] Panose => PPTXUnsupportedProps.Panose;

	internal FontData()
	{
	}

	public FontData(string fontName)
	{
		string_0 = fontName;
	}

	internal FontData(Class2879 fatom)
	{
		string_0 = fatom.LfFaceName;
		PitchFamily = (byte)(fatom.Pitch | fatom.Family);
		CharSet = fatom.LfCharSet;
	}

	internal FontData(IFontData fontData)
	{
		FontData fontData2 = (FontData)fontData;
		string_0 = fontData2.string_0;
		class338_0 = new Class338(fontData2.PPTXUnsupportedProps);
	}

	public string GetFontName(IThemeEffectiveData theme)
	{
		if (string_0 != null && string_0.Length == 6 && string_0[0] == '+' && theme != null)
		{
			IFontsEffectiveData fontsEffectiveData = null;
			if (string.Compare(string_0, 1, "mn-", 0, 3) == 0)
			{
				fontsEffectiveData = theme.FontScheme.Minor;
			}
			else
			{
				if (string.Compare(string_0, 1, "mj-", 0, 3) != 0)
				{
					return string_0;
				}
				fontsEffectiveData = theme.FontScheme.Major;
			}
			if (smethod_0(string_0))
			{
				return fontsEffectiveData.LatinFont.FontName;
			}
			if (smethod_1(string_0))
			{
				return fontsEffectiveData.EastAsianFont.FontName;
			}
			if (smethod_2(string_0))
			{
				return fontsEffectiveData.ComplexScriptFont.FontName;
			}
			return string_0;
		}
		return string_0;
	}

	internal FontData method_1(IThemeEffectiveData theme)
	{
		if (string_0 != null && string_0.Length == 6 && string_0[0] == '+' && theme != null)
		{
			IFontsEffectiveData fontsEffectiveData = null;
			if (string.Compare(string_0, 1, "mn-", 0, 3) == 0)
			{
				fontsEffectiveData = theme.FontScheme.Minor;
			}
			else
			{
				if (string.Compare(string_0, 1, "mj-", 0, 3) != 0)
				{
					return this;
				}
				fontsEffectiveData = theme.FontScheme.Major;
			}
			if (smethod_0(string_0))
			{
				return (FontData)fontsEffectiveData.LatinFont;
			}
			if (smethod_1(string_0))
			{
				return (FontData)fontsEffectiveData.EastAsianFont;
			}
			if (smethod_2(string_0))
			{
				return (FontData)fontsEffectiveData.ComplexScriptFont;
			}
			return this;
		}
		return this;
	}

	internal static bool smethod_0(string typeface)
	{
		if (typeface != null && typeface.Length > 5)
		{
			return string.Compare(typeface, 4, "lt", 0, 2) == 0;
		}
		return false;
	}

	internal static bool smethod_1(string typeface)
	{
		if (typeface != null && typeface.Length > 5)
		{
			return string.Compare(typeface, 4, "ea", 0, 2) == 0;
		}
		return false;
	}

	internal static bool smethod_2(string typeface)
	{
		if (typeface != null && typeface.Length > 5)
		{
			return string.Compare(typeface, 4, "cs", 0, 2) == 0;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is FontData fontData))
		{
			return base.Equals(obj);
		}
		if (string_0 == null && fontData.string_0 == null)
		{
			if (PitchFamily == fontData.PitchFamily)
			{
				return CharSet == fontData.CharSet;
			}
			return false;
		}
		return string_0 == fontData.string_0;
	}

	public override int GetHashCode()
	{
		return string_0.GetHashCode();
	}
}
