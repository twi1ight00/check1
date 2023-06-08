using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns11;
using ns33;
using ns6;

namespace ns4;

internal sealed class Class151 : ICloneable
{
	private bool bool_0;

	private bool bool_1;

	private bool bool_2;

	private bool bool_3;

	private bool bool_4;

	private TextCapType textCapType_0;

	private float float_0;

	private float float_1;

	private float float_2 = float.NaN;

	private float float_3;

	private readonly float float_4 = 576f;

	private Color color_0;

	private Color color_1 = Color.Black;

	private readonly double double_0;

	private readonly double double_1;

	private readonly float float_5;

	private Class66 class66_0;

	private Class63 class63_0;

	private TextStrikethroughType textStrikethroughType_0;

	private string string_0;

	private string string_1;

	private Enum1 enum1_0;

	private sbyte sbyte_0 = -1;

	private int int_0;

	private byte[] byte_0;

	private readonly Class54 class54_0;

	public short Escapement
	{
		get
		{
			return (short)float_0;
		}
		set
		{
			float_0 = value;
		}
	}

	public Class63 FontFill
	{
		get
		{
			return class63_0;
		}
		set
		{
			class63_0 = value;
		}
	}

	public Class66 FontOutline
	{
		get
		{
			return class66_0;
		}
		set
		{
			class66_0 = value;
		}
	}

	public Color FontColor
	{
		get
		{
			return class63_0.ForeColor;
		}
		set
		{
			class63_0 = new Class63(value);
		}
	}

	public Color ShadowColor
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
		}
	}

	public Color BackColor
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
		}
	}

	public Color FaceColor
	{
		get
		{
			if (!FontEmbossed)
			{
				return FontColor;
			}
			return BackColor;
		}
	}

	public bool FontBold
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	public bool FontItalic
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public bool FontShadow
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public bool FontEmbossed
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool FontUnderline
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public TextCapType TextCapType
	{
		get
		{
			return textCapType_0;
		}
		set
		{
			textCapType_0 = value;
		}
	}

	public TextStrikethroughType TextStrikethrough
	{
		get
		{
			return textStrikethroughType_0;
		}
		set
		{
			textStrikethroughType_0 = value;
		}
	}

	public short FontHeight
	{
		get
		{
			return (short)float_1;
		}
		set
		{
			float_1 = value;
		}
	}

	public float FFontHeight
	{
		get
		{
			return float_1;
		}
		set
		{
			float_1 = value;
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
			float_3 = value;
		}
	}

	public string FontName
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
			sbyte_0 = -1;
		}
	}

	public Enum1 FontCharset
	{
		get
		{
			return enum1_0;
		}
		set
		{
			enum1_0 = value;
		}
	}

	public int FontPitchAndFamily
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

	public byte[] FontPanose
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	internal bool FontExists
	{
		get
		{
			if (sbyte_0 < 0)
			{
				sbyte_0 = ((class54_0.method_1(FontName, FontStyle.Regular) != null) ? ((sbyte)1) : ((sbyte)0));
			}
			return sbyte_0 > 0;
		}
	}

	internal string DefaultFontName => string_1;

	internal float ForcedWidth
	{
		get
		{
			return float_2;
		}
		set
		{
			float_2 = value;
		}
	}

	internal double ShadowBlurRadius => double_0;

	internal double ShadowDistance => double_1;

	internal float ShadowDirection => float_5;

	internal Class54 FontsManager => class54_0;

	public Class151(Presentation presentation, float dpi)
	{
		class54_0 = presentation.FontsManagerInternal;
		string_0 = "Arial";
		string_1 = presentation.LoadOptions.DefaultRegularFont;
		float_1 = 18f;
		bool_0 = false;
		bool_1 = false;
		bool_2 = false;
		bool_3 = false;
		bool_4 = false;
		float_0 = 0f;
		class63_0 = new Class63(Color.Black);
		color_0 = Color.White;
		if (string_0.ToLower() == "arial black")
		{
			bool_0 = false;
		}
		float_4 = dpi;
	}

	public Class151(IPortionFormat props, string fontname, Enum1 charset, byte pitchFamily, byte[] panose, string defaultFontName, FloatColor styleColor, float fontHeightOverride, ShapeFrame frame, BaseSlide slide, Class169 rc)
	{
		class54_0 = ((Presentation)slide.Presentation).FontsManagerInternal;
		float_4 = 72f;
		string_0 = fontname;
		string_1 = defaultFontName;
		enum1_0 = charset;
		int_0 = pitchFamily;
		if (props != null)
		{
			if (float.IsNaN(fontHeightOverride))
			{
				float_1 = props.FontHeight;
			}
			else
			{
				float_1 = fontHeightOverride;
			}
			float_3 = props.Spacing;
			bool_0 = props.FontBold == NullableBool.True;
			bool_1 = props.FontItalic == NullableBool.True;
			textCapType_0 = props.TextCapType;
			float_0 = props.Escapement;
			class63_0 = new Class63(new Class67(frame, null, null, slide, rc), new Class493(props.FillFormat, styleColor));
			class66_0 = new Class66(new Class67(frame, null, null, slide, rc), new Class512(props.LineFormat, styleColor));
			if (props.StrikethroughType > TextStrikethroughType.None)
			{
				textStrikethroughType_0 = props.StrikethroughType;
			}
			IOuterShadow outerShadowEffect = props.EffectFormat.OuterShadowEffect;
			if (outerShadowEffect != null)
			{
				bool_3 = true;
				color_1 = outerShadowEffect.ShadowColor.Color;
				double_0 = outerShadowEffect.BlurRadius;
				double_1 = outerShadowEffect.Distance;
				float_5 = outerShadowEffect.Direction;
			}
		}
		else
		{
			float_1 = fontHeightOverride;
			bool_0 = false;
			bool_1 = false;
			bool_2 = false;
			bool_3 = false;
			bool_4 = false;
			float_0 = 0f;
			class63_0 = new Class63(Color.Black);
		}
	}

	internal FontFamily method_0()
	{
		try
		{
			FontFamily fontFamily = new FontFamily(FontName);
			fontFamily.GetLineSpacing(FontStyle.Regular);
			return fontFamily;
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			return new FontFamily("Arial");
		}
	}

	internal Class733 method_1()
	{
		return method_2(float_4);
	}

	internal Class733 method_2(float dpi)
	{
		try
		{
			return Class733.smethod_0(class54_0, FontName, enum1_0, int_0, method_6(dpi), Class732.smethod_0(FontName, method_8()));
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			return Class733.smethod_0(class54_0, "Arial", enum1_0, int_0, method_6(dpi), method_8());
		}
	}

	internal float method_3()
	{
		return method_4(float_4);
	}

	internal float method_4(float dpi)
	{
		return (float)FontHeight * 1.2f * dpi / 72f;
	}

	internal float method_5()
	{
		return method_6(float_4);
	}

	internal float method_6(float dpi)
	{
		return ((Escapement == 0) ? 1f : 0.66f) * (float)FontHeight * dpi / 96f;
	}

	internal float method_7()
	{
		FontFamily fontFamily;
		try
		{
			fontFamily = new FontFamily(FontName);
		}
		catch (Exception ex)
		{
			Class1165.smethod_28(ex);
			fontFamily = new FontFamily("Arial");
		}
		FontStyle style = method_8();
		float num = method_3() * (float)fontFamily.GetCellDescent(style) / (float)fontFamily.GetEmHeight(style);
		fontFamily.Dispose();
		return num / 2f;
	}

	internal FontStyle method_8()
	{
		FontStyle fontStyle = FontStyle.Regular;
		if (FontBold)
		{
			fontStyle |= FontStyle.Bold;
		}
		if (FontItalic)
		{
			fontStyle |= FontStyle.Italic;
		}
		if (FontUnderline)
		{
			fontStyle |= FontStyle.Underline;
		}
		return fontStyle;
	}

	internal Class66 method_9(Class66 lineParam)
	{
		return new Class66(lineParam);
	}

	internal Class63 method_10(Color color)
	{
		return new Class63(color);
	}

	public object Clone()
	{
		return MemberwiseClone();
	}
}
