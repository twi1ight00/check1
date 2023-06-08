using System.Drawing;
using Aspose.Slides.Theme;
using ns33;

namespace Aspose.Slides;

public class PortionFormatEffectiveData : IPortionFormatEffectiveData, IEffectiveData
{
	internal int int_0 = 524288;

	internal FontData fontData_0;

	internal FontData fontData_1;

	internal FontData fontData_2;

	internal FontData fontData_3;

	internal LineFormatEffectiveData lineFormatEffectiveData_0;

	internal LineFormatEffectiveData lineFormatEffectiveData_1;

	internal FillFormatEffectiveData fillFormatEffectiveData_0;

	internal FillFormatEffectiveData fillFormatEffectiveData_1;

	internal EffectFormatEffectiveData effectFormatEffectiveData_0;

	internal Color color_0;

	internal IHyperlink ihyperlink_0;

	internal IHyperlink ihyperlink_1;

	internal float float_0 = float.NaN;

	internal float float_1 = float.NaN;

	internal float float_2 = float.NaN;

	internal float float_3 = float.NaN;

	internal uint uint_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	public ILineFormatEffectiveData LineFormat => lineFormatEffectiveData_0;

	public IFillFormatEffectiveData FillFormat => fillFormatEffectiveData_0;

	public IEffectFormatEffectiveData EffectFormat => effectFormatEffectiveData_0;

	public Color HighlightColor => color_0;

	public ILineFormatEffectiveData UnderlineLineFormat => lineFormatEffectiveData_0;

	public IFillFormatEffectiveData UnderlineFillFormat => fillFormatEffectiveData_0;

	internal uint SmartTagId => uint_0;

	public string BookmarkId => string_2;

	public IHyperlink HyperlinkClick => ihyperlink_0;

	public IHyperlink HyperlinkMouseOver => ihyperlink_1;

	public bool FontBold => method_5(0) == NullableBool.True;

	public bool FontItalic => method_5(2) == NullableBool.True;

	public bool Kumimoji => method_5(4) == NullableBool.True;

	public bool NormaliseHeight => method_5(6) == NullableBool.True;

	public bool ProofDisabled => method_5(8) == NullableBool.True;

	public TextUnderlineType FontUnderline => (TextUnderlineType)(((int_0 & 0x7C00L) >> 10) - 1L);

	public TextCapType TextCapType => (TextCapType)(((int_0 & 0x18000L) >> 15) - 1L);

	public TextStrikethroughType StrikethroughType => (TextStrikethroughType)(((int_0 & 0x60000L) >> 17) - 1L);

	public bool SmartTagClean => (int_0 & 0x80000) != 0;

	public bool IsHardUnderlineLine => method_5(20) == NullableBool.True;

	public bool IsHardUnderlineFill => method_5(22) == NullableBool.True;

	internal bool ElementPresent => (int_0 & 0x1000000) != 0;

	public float FontHeight => float_0;

	public IFontData LatinFont => fontData_0;

	public IFontData EastAsianFont => fontData_1;

	public IFontData ComplexScriptFont => fontData_2;

	public IFontData SymbolFont => fontData_3;

	public float Escapement => float_2;

	public float KerningMinimalSize => float_1;

	public string LanguageId => string_0;

	public string AlternativeLanguageId => string_1;

	public float Spacing => float_3;

	internal void method_0(NullableBool value)
	{
		method_6(0, value);
	}

	internal void method_1(NullableBool value)
	{
		method_6(2, value);
	}

	internal bool method_2(PortionFormatEffectiveData portion)
	{
		if (int_0 == portion.int_0 && fontData_0 == portion.fontData_0 && fontData_1 == portion.fontData_1 && fontData_2 == portion.fontData_2 && fontData_3 == portion.fontData_3 && lineFormatEffectiveData_0.Equals(portion.lineFormatEffectiveData_0) && fillFormatEffectiveData_0.Equals(portion.fillFormatEffectiveData_0) && lineFormatEffectiveData_1.Equals(portion.lineFormatEffectiveData_1) && fillFormatEffectiveData_1.Equals(portion.fillFormatEffectiveData_1) && color_0.Equals(portion.color_0) && Class1165.smethod_0(float_0, portion.float_0) && Class1165.smethod_0(float_1, portion.float_1) && Class1165.smethod_0(float_2, portion.float_2) && Class1165.smethod_0(float_3, portion.float_3) && uint_0 == portion.uint_0 && !(string_0 != portion.string_0) && !(string_1 != portion.string_1) && !(string_2 != portion.string_2) && ihyperlink_0 == portion.ihyperlink_0 && ihyperlink_1 == portion.ihyperlink_1)
		{
			return true;
		}
		return false;
	}

	internal PortionFormatEffectiveData()
	{
		lineFormatEffectiveData_0 = new LineFormatEffectiveData();
		lineFormatEffectiveData_1 = new LineFormatEffectiveData();
		fillFormatEffectiveData_0 = new FillFormatEffectiveData();
		fillFormatEffectiveData_1 = new FillFormatEffectiveData();
		effectFormatEffectiveData_0 = new EffectFormatEffectiveData();
	}

	internal PortionFormatEffectiveData(PortionFormat props, BaseSlide slide, FloatColor styleColor)
	{
		lineFormatEffectiveData_0 = new LineFormatEffectiveData(props.LineFormat, slide, styleColor);
		lineFormatEffectiveData_1 = new LineFormatEffectiveData(props.UnderlineLineFormat, slide, styleColor);
		fillFormatEffectiveData_0 = new FillFormatEffectiveData(props.FillFormat, slide, styleColor);
		fillFormatEffectiveData_1 = new FillFormatEffectiveData(props.UnderlineFillFormat, slide, styleColor);
		effectFormatEffectiveData_0 = new EffectFormatEffectiveData(props.EffectFormat, slide, styleColor);
		method_3(props, slide, styleColor);
	}

	internal void method_3(PortionFormat props, BaseSlide slide, FloatColor styleColor)
	{
		if (props != null)
		{
			int_0 = props.Attributes;
			if (slide != null)
			{
				IThemeEffectiveData theme = slide.CreateThemeEffective();
				fontData_0 = ((props.LatinFont != null) ? ((FontData)props.LatinFont).method_1(theme) : null);
				fontData_1 = ((props.EastAsianFont != null) ? ((FontData)props.EastAsianFont).method_1(theme) : null);
				fontData_2 = ((props.ComplexScriptFont != null) ? ((FontData)props.ComplexScriptFont).method_1(theme) : null);
				fontData_3 = ((props.SymbolFont != null) ? ((FontData)props.SymbolFont).method_1(theme) : null);
			}
			lineFormatEffectiveData_0.method_0(props.LineFormat, slide, styleColor);
			lineFormatEffectiveData_1.method_0(props.UnderlineLineFormat, slide, styleColor);
			fillFormatEffectiveData_0.method_0(props.FillFormat, slide, styleColor);
			effectFormatEffectiveData_0.method_0(props.EffectFormat, slide, styleColor);
			fillFormatEffectiveData_1.method_1(props.UnderlineFillFormat, slide, styleColor);
			color_0 = ((ColorFormat)props.HighlightColor).method_5(slide, styleColor);
			ihyperlink_0 = props.HyperlinkClick;
			ihyperlink_1 = props.HyperlinkMouseOver;
			float_0 = props.FontHeight;
			float_1 = props.KerningMinimalSize;
			float_2 = props.Escapement;
			float_3 = props.Spacing;
			uint_0 = props.PPTXUnsupportedProps.SmartTagId;
			string_0 = props.LanguageId;
			string_1 = props.AlternativeLanguageId;
			string_2 = props.BookmarkId;
		}
	}

	internal void method_4(PortionFormat props, BaseSlide slide, FloatColor styleColor)
	{
		NullableBool fontBold = props.FontBold;
		if (fontBold != NullableBool.NotDefined)
		{
			method_6(0, fontBold);
		}
		fontBold = props.FontItalic;
		if (fontBold != NullableBool.NotDefined)
		{
			method_6(2, fontBold);
		}
		fontBold = props.Kumimoji;
		if (fontBold != NullableBool.NotDefined)
		{
			method_6(4, fontBold);
		}
		fontBold = props.NormaliseHeight;
		if (fontBold != NullableBool.NotDefined)
		{
			method_6(6, fontBold);
		}
		fontBold = props.ProofDisabled;
		if (fontBold != NullableBool.NotDefined)
		{
			method_6(8, fontBold);
		}
		TextUnderlineType fontUnderline = props.FontUnderline;
		if (fontUnderline != TextUnderlineType.NotDefined)
		{
			int_0 &= -31745;
			int_0 |= (int)(fontUnderline + 1) << 10;
		}
		TextCapType textCapType = props.TextCapType;
		if (textCapType != TextCapType.NotDefined)
		{
			int_0 &= -2064385;
			int_0 |= (int)(textCapType + 1) << 15;
		}
		TextStrikethroughType strikethroughType = props.StrikethroughType;
		if (strikethroughType != TextStrikethroughType.NotDefined)
		{
			int_0 &= -8257537;
			int_0 |= (int)(strikethroughType + 1) << 17;
		}
		if (((IPortionFormat)props).SmartTagClean)
		{
			int_0 |= 524288;
		}
		else
		{
			int_0 &= -524289;
		}
		fontBold = props.IsHardUnderlineLine;
		if (fontBold != NullableBool.NotDefined)
		{
			method_6(20, fontBold);
		}
		fontBold = props.IsHardUnderlineFill;
		if (fontBold != NullableBool.NotDefined)
		{
			method_6(22, fontBold);
		}
		IThemeEffectiveData theme = slide.CreateThemeEffective();
		if (props.LatinFont != null)
		{
			fontData_0 = ((FontData)props.LatinFont).method_1(theme);
		}
		if (props.EastAsianFont != null)
		{
			fontData_1 = ((FontData)props.EastAsianFont).method_1(theme);
		}
		if (props.ComplexScriptFont != null)
		{
			fontData_2 = ((FontData)props.ComplexScriptFont).method_1(theme);
		}
		if (props.SymbolFont != null)
		{
			fontData_3 = ((FontData)props.SymbolFont).method_1(theme);
		}
		lineFormatEffectiveData_0.method_1(props.LineFormat, slide, styleColor);
		lineFormatEffectiveData_1.method_1(props.UnderlineLineFormat, slide, styleColor);
		fillFormatEffectiveData_0.method_1(props.FillFormat, slide, styleColor);
		effectFormatEffectiveData_0.method_1(props.EffectFormat, slide, styleColor);
		fillFormatEffectiveData_1.method_1(props.UnderlineFillFormat, slide, styleColor);
		if (props.HighlightColor.ColorType != ColorType.NotDefined)
		{
			color_0 = ((ColorFormat)props.HighlightColor).method_5(slide, styleColor);
		}
		if (props.HyperlinkClick != null)
		{
			ihyperlink_0 = props.HyperlinkClick;
		}
		if (props.HyperlinkMouseOver != null)
		{
			ihyperlink_1 = props.HyperlinkMouseOver;
		}
		if (!float.IsNaN(props.FontHeight))
		{
			float_0 = props.FontHeight;
		}
		if (!float.IsNaN(props.KerningMinimalSize))
		{
			float_1 = props.KerningMinimalSize;
		}
		if (!float.IsNaN(props.Escapement))
		{
			float_2 = props.Escapement;
		}
		if (!float.IsNaN(props.Spacing))
		{
			float_3 = props.Spacing;
		}
		if (props.LanguageId != null)
		{
			string_0 = props.LanguageId;
		}
		if (props.AlternativeLanguageId != null)
		{
			string_1 = props.AlternativeLanguageId;
		}
		if (props.BookmarkId != null)
		{
			string_2 = props.BookmarkId;
		}
	}

	private NullableBool method_5(int bitShift)
	{
		uint num = (uint)(3 << bitShift);
		return (NullableBool)(((int_0 & num) >> bitShift) - 1L);
	}

	private void method_6(int bitShift, NullableBool value)
	{
		int num = ~(3 << bitShift);
		int_0 &= num;
		int_0 |= (int)(value + 1) << bitShift;
	}
}
