using System;
using Aspose.Slides.Charts;
using ns24;
using ns33;
using ns4;

namespace Aspose.Slides;

public abstract class BasePortionFormat : IBasePortionFormat
{
	internal delegate void Delegate0(Portion whichPortion);

	private int int_0 = 524288;

	private ushort? nullable_0;

	private ushort? nullable_1;

	private ushort? nullable_2;

	private FontData fontData_0;

	private readonly LineFormat lineFormat_0;

	private readonly FillFormat fillFormat_0;

	private readonly EffectFormat effectFormat_0;

	private readonly ColorFormat colorFormat_0;

	private readonly LineFormat lineFormat_1;

	private readonly FillFormat fillFormat_1;

	private float float_0 = float.NaN;

	private float float_1 = float.NaN;

	private float float_2 = float.NaN;

	private float float_3 = float.NaN;

	private string string_0;

	private string string_1;

	private readonly Class349 class349_0;

	private readonly IPresentationComponent ipresentationComponent_0;

	private uint uint_0;

	private Class48 class48_0;

	private ParagraphFormat paragraphFormat_0;

	public ILineFormat LineFormat => lineFormat_0;

	public IFillFormat FillFormat => fillFormat_0;

	public IEffectFormat EffectFormat => effectFormat_0;

	public IColorFormat HighlightColor => colorFormat_0;

	public ILineFormat UnderlineLineFormat => lineFormat_1;

	public IFillFormat UnderlineFillFormat => fillFormat_1;

	public NullableBool FontBold
	{
		get
		{
			return method_2(0);
		}
		set
		{
			if (method_2(0) != value)
			{
				method_3(0, value);
				method_4();
				method_5();
			}
		}
	}

	public NullableBool FontItalic
	{
		get
		{
			return method_2(2);
		}
		set
		{
			if (method_2(2) != value)
			{
				method_3(2, value);
				method_4();
				method_5();
			}
		}
	}

	public NullableBool Kumimoji
	{
		get
		{
			return method_2(4);
		}
		set
		{
			if (method_2(4) != value)
			{
				method_3(4, value);
				method_4();
				method_5();
			}
		}
	}

	public NullableBool NormaliseHeight
	{
		get
		{
			return method_2(6);
		}
		set
		{
			if (method_2(6) != value)
			{
				method_3(6, value);
				method_4();
				method_5();
			}
		}
	}

	public NullableBool ProofDisabled
	{
		get
		{
			return method_2(8);
		}
		set
		{
			if (method_2(8) != value)
			{
				method_3(8, value);
				method_4();
				method_5();
			}
		}
	}

	public TextUnderlineType FontUnderline
	{
		get
		{
			return (TextUnderlineType)(((Attributes & 0x7C00L) >> 10) - 1L);
		}
		set
		{
			Attributes &= -31745;
			Attributes |= (int)(value + 1) << 10;
			method_5();
		}
	}

	public TextCapType TextCapType
	{
		get
		{
			return (TextCapType)(((Attributes & 0x18000L) >> 15) - 1L);
		}
		set
		{
			Attributes &= -98305;
			Attributes |= (int)(value + 1) << 15;
			method_4();
			method_5();
		}
	}

	public TextStrikethroughType StrikethroughType
	{
		get
		{
			return (TextStrikethroughType)(((Attributes & 0x60000L) >> 17) - 1L);
		}
		set
		{
			Attributes &= -393217;
			Attributes |= (int)(value + 1) << 17;
			method_5();
		}
	}

	public NullableBool IsHardUnderlineLine
	{
		get
		{
			return method_2(20);
		}
		set
		{
			if (method_2(20) != value)
			{
				method_3(20, value);
				method_4();
				method_5();
			}
		}
	}

	public NullableBool IsHardUnderlineFill
	{
		get
		{
			return method_2(22);
		}
		set
		{
			if (method_2(22) != value)
			{
				method_3(22, value);
				method_4();
				method_5();
			}
		}
	}

	public float FontHeight
	{
		get
		{
			return float_0;
		}
		set
		{
			float num = float_0;
			float_0 = Class1165.smethod_5(value, 1f, 4000f);
			if (float_0 != num)
			{
				method_4();
				method_5();
			}
		}
	}

	public IFontData LatinFont
	{
		get
		{
			if (!nullable_0.HasValue)
			{
				return null;
			}
			return FontsList.method_5(nullable_0.Value).FontData;
		}
		set
		{
			if (value != null)
			{
				nullable_0 = FontsList.Add(Enum2.const_0, value);
			}
			method_4();
			method_5();
		}
	}

	public IFontData EastAsianFont
	{
		get
		{
			if (!nullable_1.HasValue)
			{
				return null;
			}
			return FontsList.method_5(nullable_1.Value).FontData;
		}
		set
		{
			if (value != null)
			{
				nullable_1 = FontsList.Add(Enum2.const_1, value);
			}
			method_4();
			method_5();
		}
	}

	public IFontData ComplexScriptFont
	{
		get
		{
			if (!nullable_2.HasValue)
			{
				return null;
			}
			return FontsList.method_5(nullable_2.Value).FontData;
		}
		set
		{
			if (value != null)
			{
				nullable_2 = FontsList.Add(Enum2.const_2, value);
			}
			method_4();
			method_5();
		}
	}

	public IFontData SymbolFont
	{
		get
		{
			return fontData_0;
		}
		set
		{
			fontData_0 = (FontData)value;
			method_4();
			method_5();
		}
	}

	public float Escapement
	{
		get
		{
			return float_2;
		}
		set
		{
			if (float_2 != value)
			{
				float_2 = value;
				method_4();
				method_5();
			}
		}
	}

	public float KerningMinimalSize
	{
		get
		{
			return float_1;
		}
		set
		{
			if (float_1 != value)
			{
				float_1 = Class1165.smethod_5(value, 0f, 4000f);
				method_4();
				method_5();
			}
		}
	}

	public string LanguageId
	{
		get
		{
			return string_0;
		}
		set
		{
			if (value != null && value.Length == 0)
			{
				value = null;
			}
			if (string_0 != value)
			{
				string_0 = value;
				method_5();
			}
		}
	}

	public string AlternativeLanguageId
	{
		get
		{
			return string_1;
		}
		set
		{
			if (value != null && value.Length == 0)
			{
				value = null;
			}
			if (string_1 != value)
			{
				string_1 = value;
				method_5();
			}
		}
	}

	public float Spacing
	{
		get
		{
			return float_3;
		}
		set
		{
			if (float_3 != value)
			{
				float_3 = Class1165.smethod_5(value, -1000f, 1000f);
				method_4();
				method_5();
			}
		}
	}

	internal int Attributes
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal Class349 PPTXUnsupportedProps => class349_0;

	internal IPresentationComponent Parent => ipresentationComponent_0;

	internal ParagraphFormat ParentParagraphFormat
	{
		get
		{
			return paragraphFormat_0;
		}
		set
		{
			paragraphFormat_0 = value;
		}
	}

	internal Class48 FontsList => class48_0;

	internal uint Version => uint_0 + lineFormat_0.Version + fillFormat_0.Version + effectFormat_0.Version + colorFormat_0.Version + lineFormat_1.Version + fillFormat_1.Version;

	public override bool Equals(object obj)
	{
		if (!(obj is BasePortionFormat basePortionFormat))
		{
			return false;
		}
		if (Attributes == basePortionFormat.Attributes && Class1165.smethod_2(LineFormat, basePortionFormat.LineFormat) && Class1165.smethod_2(FillFormat, basePortionFormat.FillFormat) && Class1165.smethod_2(EffectFormat, basePortionFormat.EffectFormat) && Class1165.smethod_2(HighlightColor, basePortionFormat.HighlightColor) && Class1165.smethod_2(UnderlineLineFormat, basePortionFormat.UnderlineLineFormat) && Class1165.smethod_2(UnderlineFillFormat, UnderlineFillFormat) && Class1165.smethod_0(FontHeight, basePortionFormat.FontHeight) && Class1165.smethod_2(LatinFont, basePortionFormat.LatinFont) && Class1165.smethod_2(EastAsianFont, basePortionFormat.EastAsianFont) && Class1165.smethod_2(ComplexScriptFont, basePortionFormat.ComplexScriptFont) && Class1165.smethod_2(SymbolFont, basePortionFormat.SymbolFont) && Class1165.smethod_0(Escapement, basePortionFormat.Escapement) && Class1165.smethod_0(KerningMinimalSize, basePortionFormat.KerningMinimalSize) && !(LanguageId != basePortionFormat.LanguageId) && !(AlternativeLanguageId != basePortionFormat.AlternativeLanguageId) && Class1165.smethod_0(Spacing, basePortionFormat.Spacing) && PPTXUnsupportedProps.SmartTagId == basePortionFormat.PPTXUnsupportedProps.SmartTagId)
		{
			return true;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	internal BasePortionFormat(IPresentationComponent parent)
	{
		if (parent != null && !(parent is IFormattedTextContainer) && !(parent is Portion) && !(parent is Field) && !(parent is Paragraph) && !(parent is MasterSlide) && !(parent is Presentation) && !(parent is TextFrame))
		{
			throw new ArgumentException();
		}
		ipresentationComponent_0 = parent;
		class349_0 = new Class349();
		class48_0 = Class53.smethod_7(parent);
		lineFormat_0 = new LineFormat(ipresentationComponent_0);
		fillFormat_0 = new FillFormat(ipresentationComponent_0);
		lineFormat_1 = new LineFormat(ipresentationComponent_0);
		fillFormat_1 = new FillFormat(ipresentationComponent_0);
		colorFormat_0 = new ColorFormat(ipresentationComponent_0 as ISlideComponent);
		effectFormat_0 = new EffectFormat(ipresentationComponent_0);
	}

	internal virtual void vmethod_0(PortionFormatEffectiveData props)
	{
		Attributes = props.int_0;
		LatinFont = props.fontData_0;
		EastAsianFont = props.fontData_1;
		ComplexScriptFont = props.fontData_2;
		fontData_0 = props.fontData_3;
		lineFormat_0.method_1(props.lineFormatEffectiveData_0);
		lineFormat_1.method_1(props.lineFormatEffectiveData_1);
		fillFormat_0.method_1(props.fillFormatEffectiveData_0);
		effectFormat_0.method_1(props.effectFormatEffectiveData_0);
		fillFormat_1.method_1(props.fillFormatEffectiveData_1);
		colorFormat_0.method_1(props.color_0);
		float_0 = props.float_0;
		float_1 = props.float_1;
		float_2 = props.float_2;
		float_3 = props.float_3;
		PPTXUnsupportedProps.SmartTagId = props.SmartTagId;
		string_0 = props.string_0;
		string_1 = props.string_1;
		if (this is PortionFormat portionFormat)
		{
			portionFormat.HyperlinkClick = props.HyperlinkClick;
			portionFormat.HyperlinkMouseOver = props.HyperlinkMouseOver;
			portionFormat.BookmarkId = props.BookmarkId;
		}
		method_5();
	}

	internal virtual void vmethod_1(BasePortionFormat props)
	{
		Attributes = props.Attributes;
		LatinFont = props.LatinFont;
		EastAsianFont = props.EastAsianFont;
		ComplexScriptFont = props.ComplexScriptFont;
		fontData_0 = props.fontData_0;
		lineFormat_0.method_0(props.lineFormat_0);
		lineFormat_1.method_0(props.lineFormat_1);
		fillFormat_0.method_0(props.fillFormat_0);
		effectFormat_0.method_0(props.effectFormat_0);
		fillFormat_1.method_0(props.fillFormat_1);
		colorFormat_0.method_0(props.colorFormat_0);
		float_0 = props.float_0;
		float_1 = props.float_1;
		float_2 = props.float_2;
		float_3 = props.float_3;
		string_0 = props.string_0;
		string_1 = props.string_1;
		PPTXUnsupportedProps.SmartTagId = props.PPTXUnsupportedProps.SmartTagId;
		PortionFormat portionFormat = this as PortionFormat;
		PortionFormat portionFormat2 = props as PortionFormat;
		if (portionFormat != null && portionFormat2 != null)
		{
			portionFormat.HyperlinkClick = portionFormat2.HyperlinkClick;
			portionFormat.HyperlinkMouseOver = portionFormat2.HyperlinkMouseOver;
			portionFormat.BookmarkId = portionFormat2.BookmarkId;
		}
		method_5();
	}

	internal virtual void vmethod_2(BasePortionFormat props)
	{
		if (LatinFont != null)
		{
			props.LatinFont = LatinFont;
		}
		if (EastAsianFont != null)
		{
			props.EastAsianFont = EastAsianFont;
		}
		if (ComplexScriptFont != null)
		{
			props.ComplexScriptFont = ComplexScriptFont;
		}
		if (fontData_0 != null)
		{
			props.fontData_0 = fontData_0;
		}
		if (!lineFormat_0.IsFormatNotDefined)
		{
			props.lineFormat_0.method_0(lineFormat_0);
		}
		if (!lineFormat_1.IsFormatNotDefined)
		{
			props.lineFormat_1.method_0(lineFormat_1);
		}
		if (fillFormat_0.FillType != FillType.NotDefined)
		{
			props.fillFormat_0.method_0(fillFormat_0);
		}
		if (fillFormat_1.FillType != FillType.NotDefined)
		{
			props.fillFormat_1.method_0(fillFormat_1);
		}
		if (effectFormat_0 != null)
		{
			props.effectFormat_0.method_0(effectFormat_0);
		}
		if (colorFormat_0.ColorType != ColorType.NotDefined)
		{
			props.colorFormat_0.method_0(colorFormat_0);
		}
		if (!float.IsNaN(float_0))
		{
			props.float_0 = float_0;
		}
		if (!float.IsNaN(float_1))
		{
			props.float_1 = float_1;
		}
		if (!float.IsNaN(float_2))
		{
			props.float_2 = float_2;
		}
		if (!float.IsNaN(float_3))
		{
			props.float_3 = float_3;
		}
		if (string_0 != null)
		{
			props.string_0 = string_0;
		}
		if (string_1 != null)
		{
			props.string_1 = string_1;
		}
		if (FontBold != NullableBool.NotDefined)
		{
			props.FontBold = FontBold;
		}
		if (FontItalic != NullableBool.NotDefined)
		{
			props.FontItalic = FontItalic;
		}
		if (Kumimoji != NullableBool.NotDefined)
		{
			props.Kumimoji = Kumimoji;
		}
		if (NormaliseHeight != NullableBool.NotDefined)
		{
			props.NormaliseHeight = NormaliseHeight;
		}
		if (ProofDisabled != NullableBool.NotDefined)
		{
			props.ProofDisabled = ProofDisabled;
		}
		if (FontUnderline != TextUnderlineType.NotDefined)
		{
			props.FontUnderline = FontUnderline;
		}
		if (TextCapType != TextCapType.NotDefined)
		{
			props.TextCapType = TextCapType;
		}
		if (StrikethroughType != TextStrikethroughType.NotDefined)
		{
			props.StrikethroughType = StrikethroughType;
		}
		if (IsHardUnderlineLine != NullableBool.NotDefined)
		{
			props.IsHardUnderlineLine = IsHardUnderlineLine;
		}
		if (IsHardUnderlineFill != NullableBool.NotDefined)
		{
			props.IsHardUnderlineFill = IsHardUnderlineFill;
		}
		PortionFormat portionFormat = this as PortionFormat;
		PortionFormat portionFormat2 = props as PortionFormat;
		if (portionFormat != null && portionFormat2 != null)
		{
			if (portionFormat.HyperlinkClick != null)
			{
				portionFormat2.HyperlinkClick = portionFormat.HyperlinkClick;
			}
			if (portionFormat.HyperlinkMouseOver != null)
			{
				portionFormat2.HyperlinkMouseOver = portionFormat.HyperlinkMouseOver;
			}
			if (portionFormat.BookmarkId != null)
			{
				portionFormat2.BookmarkId = portionFormat.BookmarkId;
			}
			portionFormat2.SmartTagClean = portionFormat.SmartTagClean;
		}
	}

	internal virtual void vmethod_3(BasePortionFormat props)
	{
		if (LatinFont == null && EastAsianFont == null && ComplexScriptFont == null && fontData_0 == null)
		{
			LatinFont = props.LatinFont;
			EastAsianFont = props.EastAsianFont;
			ComplexScriptFont = props.ComplexScriptFont;
			fontData_0 = props.fontData_0;
		}
		if (lineFormat_0.IsFormatNotDefined)
		{
			lineFormat_0.method_0(props.lineFormat_0);
		}
		if (lineFormat_1.IsFormatNotDefined)
		{
			lineFormat_1.method_0(props.lineFormat_1);
		}
		if (fillFormat_0.FillType == FillType.NotDefined)
		{
			fillFormat_0.method_0(props.fillFormat_0);
		}
		if (fillFormat_1.FillType == FillType.NotDefined)
		{
			fillFormat_1.method_0(props.fillFormat_1);
		}
		if (colorFormat_0.ColorType == ColorType.NotDefined)
		{
			colorFormat_0.method_0(props.colorFormat_0);
		}
		if (float.IsNaN(float_0))
		{
			float_0 = props.float_0;
		}
		if (float.IsNaN(float_1))
		{
			float_1 = props.float_1;
		}
		if (float.IsNaN(float_2))
		{
			float_2 = props.float_2;
		}
		if (float.IsNaN(float_3))
		{
			float_3 = props.float_3;
		}
		if (string_0 == null)
		{
			string_0 = props.string_0;
		}
		if (string_1 == null)
		{
			string_1 = props.string_1;
		}
		if (FontBold == NullableBool.NotDefined)
		{
			FontBold = props.FontBold;
		}
		if (FontItalic == NullableBool.NotDefined)
		{
			FontItalic = props.FontItalic;
		}
		if (Kumimoji == NullableBool.NotDefined)
		{
			Kumimoji = props.Kumimoji;
		}
		if (NormaliseHeight == NullableBool.NotDefined)
		{
			NormaliseHeight = props.NormaliseHeight;
		}
		if (ProofDisabled == NullableBool.NotDefined)
		{
			ProofDisabled = props.ProofDisabled;
		}
		if (FontUnderline == TextUnderlineType.NotDefined)
		{
			FontUnderline = props.FontUnderline;
		}
		if (TextCapType == TextCapType.NotDefined)
		{
			TextCapType = props.TextCapType;
		}
		if (StrikethroughType == TextStrikethroughType.NotDefined)
		{
			StrikethroughType = props.StrikethroughType;
		}
		if (IsHardUnderlineLine == NullableBool.NotDefined)
		{
			IsHardUnderlineLine = props.IsHardUnderlineLine;
		}
		if (IsHardUnderlineFill == NullableBool.NotDefined)
		{
			IsHardUnderlineFill = props.IsHardUnderlineFill;
		}
		PortionFormat portionFormat = this as PortionFormat;
		PortionFormat portionFormat2 = props as PortionFormat;
		if (portionFormat != null && portionFormat2 != null)
		{
			portionFormat.SmartTagClean = portionFormat2.SmartTagClean;
			if (portionFormat.HyperlinkClick == null)
			{
				portionFormat.HyperlinkClick = portionFormat2.HyperlinkClick;
			}
			if (portionFormat.HyperlinkMouseOver == null)
			{
				portionFormat.HyperlinkMouseOver = portionFormat2.HyperlinkMouseOver;
			}
			if (portionFormat.BookmarkId == null)
			{
				portionFormat.BookmarkId = portionFormat2.BookmarkId;
			}
		}
	}

	internal void method_0(BasePortionFormat oldDefault, BasePortionFormat newDefault)
	{
		if (LatinFont == null)
		{
			if (oldDefault.LatinFont != null)
			{
				LatinFont = oldDefault.LatinFont;
			}
			else if (newDefault.LatinFont != null)
			{
				LatinFont = FontData.fontData_0;
			}
		}
		if (EastAsianFont == null)
		{
			if (oldDefault.EastAsianFont != null)
			{
				EastAsianFont = oldDefault.EastAsianFont;
			}
			else if (newDefault.EastAsianFont != null)
			{
				EastAsianFont = FontData.fontData_0;
			}
		}
		if (ComplexScriptFont == null)
		{
			if (oldDefault.ComplexScriptFont != null)
			{
				ComplexScriptFont = oldDefault.ComplexScriptFont;
			}
			else if (newDefault.ComplexScriptFont != null)
			{
				ComplexScriptFont = FontData.fontData_0;
			}
		}
		if (fontData_0 == null)
		{
			if (oldDefault.fontData_0 != null)
			{
				fontData_0 = oldDefault.fontData_0;
			}
			else if (newDefault.fontData_0 != null)
			{
				fontData_0 = FontData.fontData_0;
			}
		}
		if (lineFormat_0.IsFormatNotDefined)
		{
			if (!oldDefault.lineFormat_0.IsFormatNotDefined)
			{
				lineFormat_0.method_0(oldDefault.lineFormat_0);
			}
			else if (!newDefault.lineFormat_0.IsFormatNotDefined)
			{
				lineFormat_0.FillFormat.FillType = FillType.NoFill;
			}
		}
		if (lineFormat_1.IsFormatNotDefined)
		{
			if (!oldDefault.lineFormat_1.IsFormatNotDefined)
			{
				lineFormat_1.method_0(oldDefault.lineFormat_1);
			}
			else if (!newDefault.lineFormat_1.IsFormatNotDefined)
			{
				lineFormat_1.FillFormat.FillType = FillType.NoFill;
			}
		}
		if (fillFormat_0.FillType == FillType.NotDefined)
		{
			if (oldDefault.fillFormat_0.FillType != FillType.NotDefined)
			{
				fillFormat_0.method_0(oldDefault.fillFormat_0);
			}
			else if (newDefault.fillFormat_0.FillType != FillType.NotDefined)
			{
				fillFormat_0.FillType = FillType.Solid;
				fillFormat_0.SolidFillColor.SchemeColor = SchemeColor.StyleColor;
			}
		}
		if (fillFormat_1.FillType == FillType.NotDefined)
		{
			if (oldDefault.fillFormat_1.FillType != FillType.NotDefined)
			{
				fillFormat_1.method_0(oldDefault.fillFormat_1);
			}
			else if (newDefault.fillFormat_1.FillType != FillType.NotDefined)
			{
				fillFormat_0.FillType = FillType.Solid;
				fillFormat_0.SolidFillColor.SchemeColor = SchemeColor.StyleColor;
			}
		}
		if (colorFormat_0.ColorType == ColorType.NotDefined)
		{
			if (oldDefault.colorFormat_0.ColorType != ColorType.NotDefined)
			{
				colorFormat_0.method_0(oldDefault.colorFormat_0);
			}
			else if (newDefault.colorFormat_0.ColorType != ColorType.NotDefined)
			{
				colorFormat_0.PresetColor = PresetColor.White;
			}
		}
		if (float.IsNaN(float_0))
		{
			if (!float.IsNaN(oldDefault.float_0))
			{
				float_0 = oldDefault.float_0;
			}
			else if (!float.IsNaN(newDefault.float_0))
			{
				float_0 = 18f;
			}
		}
		if (float.IsNaN(float_1))
		{
			if (!float.IsNaN(oldDefault.float_1))
			{
				float_1 = oldDefault.float_1;
			}
			else if (!float.IsNaN(newDefault.float_1))
			{
				float_1 = 12f;
			}
		}
		if (float.IsNaN(float_2))
		{
			if (!float.IsNaN(oldDefault.float_2))
			{
				float_2 = oldDefault.float_2;
			}
			else if (!float.IsNaN(newDefault.float_2))
			{
				float_2 = 0f;
			}
		}
		if (float.IsNaN(float_3))
		{
			if (!float.IsNaN(oldDefault.float_3))
			{
				float_3 = oldDefault.float_3;
			}
			else if (!float.IsNaN(newDefault.float_3))
			{
				float_3 = 0f;
			}
		}
		if (string_0 == null && oldDefault.string_0 != null)
		{
			string_0 = oldDefault.string_0;
		}
		if (string_1 == null && oldDefault.string_1 != null)
		{
			string_1 = oldDefault.string_1;
		}
		if (FontBold == NullableBool.NotDefined)
		{
			if (oldDefault.FontBold != NullableBool.NotDefined)
			{
				FontBold = oldDefault.FontBold;
			}
			else if (newDefault.FontBold != NullableBool.NotDefined)
			{
				FontBold = NullableBool.False;
			}
		}
		if (FontItalic == NullableBool.NotDefined)
		{
			if (oldDefault.FontItalic != NullableBool.NotDefined)
			{
				FontItalic = oldDefault.FontItalic;
			}
			else if (newDefault.FontItalic != NullableBool.NotDefined)
			{
				FontItalic = NullableBool.False;
			}
		}
		if (Kumimoji == NullableBool.NotDefined)
		{
			if (oldDefault.Kumimoji != NullableBool.NotDefined)
			{
				Kumimoji = oldDefault.Kumimoji;
			}
			else if (newDefault.Kumimoji != NullableBool.NotDefined)
			{
				Kumimoji = NullableBool.False;
			}
		}
		if (NormaliseHeight == NullableBool.NotDefined)
		{
			if (oldDefault.NormaliseHeight != NullableBool.NotDefined)
			{
				NormaliseHeight = oldDefault.NormaliseHeight;
			}
			else if (newDefault.NormaliseHeight != NullableBool.NotDefined)
			{
				NormaliseHeight = NullableBool.False;
			}
		}
		if (ProofDisabled == NullableBool.NotDefined)
		{
			if (oldDefault.NormaliseHeight != NullableBool.NotDefined)
			{
				NormaliseHeight = oldDefault.NormaliseHeight;
			}
			else if (newDefault.NormaliseHeight != NullableBool.NotDefined)
			{
				NormaliseHeight = NullableBool.False;
			}
		}
		if (FontUnderline == TextUnderlineType.NotDefined)
		{
			if (oldDefault.FontUnderline != TextUnderlineType.NotDefined)
			{
				FontUnderline = oldDefault.FontUnderline;
			}
			else if (newDefault.FontUnderline != TextUnderlineType.NotDefined)
			{
				FontUnderline = TextUnderlineType.None;
			}
		}
		if (TextCapType == TextCapType.NotDefined)
		{
			if (oldDefault.TextCapType != TextCapType.NotDefined)
			{
				TextCapType = oldDefault.TextCapType;
			}
			else if (newDefault.TextCapType != TextCapType.NotDefined)
			{
				TextCapType = TextCapType.None;
			}
		}
		if (StrikethroughType == TextStrikethroughType.NotDefined)
		{
			if (oldDefault.StrikethroughType != TextStrikethroughType.NotDefined)
			{
				StrikethroughType = oldDefault.StrikethroughType;
			}
			else if (newDefault.StrikethroughType != TextStrikethroughType.NotDefined)
			{
				StrikethroughType = TextStrikethroughType.None;
			}
		}
		((IPortionFormat)this).SmartTagClean |= ((IPortionFormat)oldDefault).SmartTagClean;
		if (IsHardUnderlineLine == NullableBool.NotDefined)
		{
			if (oldDefault.IsHardUnderlineLine != NullableBool.NotDefined)
			{
				IsHardUnderlineLine = oldDefault.IsHardUnderlineLine;
			}
			else if (newDefault.IsHardUnderlineLine != NullableBool.NotDefined)
			{
				IsHardUnderlineLine = NullableBool.False;
			}
		}
		if (IsHardUnderlineFill == NullableBool.NotDefined)
		{
			if (oldDefault.IsHardUnderlineFill != NullableBool.NotDefined)
			{
				IsHardUnderlineFill = oldDefault.IsHardUnderlineFill;
			}
			else if (newDefault.IsHardUnderlineFill != NullableBool.NotDefined)
			{
				IsHardUnderlineFill = NullableBool.False;
			}
		}
		PortionFormat portionFormat = this as PortionFormat;
		PortionFormat portionFormat2 = oldDefault as PortionFormat;
		if (portionFormat != null && portionFormat2 != null)
		{
			if (portionFormat.HyperlinkClick == null && portionFormat2.HyperlinkClick != null)
			{
				portionFormat.HyperlinkClick = portionFormat2.HyperlinkClick;
			}
			if (portionFormat.HyperlinkMouseOver == null && portionFormat2.HyperlinkMouseOver != null)
			{
				portionFormat.HyperlinkMouseOver = portionFormat2.HyperlinkMouseOver;
			}
			if (portionFormat.BookmarkId == null && portionFormat2.BookmarkId != null)
			{
				portionFormat.BookmarkId = portionFormat2.BookmarkId;
			}
		}
	}

	internal IFontData method_1()
	{
		if (SymbolFont == null)
		{
			SymbolFont = new FontData();
		}
		return SymbolFont;
	}

	private NullableBool method_2(int bitShift)
	{
		uint num = (uint)(3 << bitShift);
		return (NullableBool)(((Attributes & num) >> bitShift) - 1L);
	}

	private void method_3(int bitShift, NullableBool value)
	{
		int num = ~(3 << bitShift);
		Attributes &= num;
		Attributes |= (int)(value + 1) << bitShift;
	}

	internal void method_4()
	{
		if (Class21.bool_0)
		{
			if (ParentParagraphFormat != null)
			{
				ParentParagraphFormat.vmethod_0(this);
			}
			if (ipresentationComponent_0 is Portion portion && portion.paragraph_0 != null)
			{
				portion.paragraph_0.method_3();
			}
		}
	}

	internal void method_5()
	{
		uint_0++;
	}

	internal void method_6(Class48 fontsList)
	{
		class48_0 = fontsList;
	}
}
