using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;
using Aspose.Slides;
using ns33;

namespace ns30;

internal class Class511
{
	private static readonly char[] char_0 = new char[3] { '\'', '\\', '\n' };

	private static readonly Class1151 class1151_0 = new Class1151(-1, true, "inherit", "ltr", "rtl");

	private static readonly Class1151 class1151_1 = new Class1151(-1, true, "inherit", "left", "center", "right", "justify");

	private static readonly Class1151 class1151_2 = new Class1151(0, true, "simple", "hanging");

	private static readonly Class1151 class1151_3 = new Class1151(1, true, "solid", "gradient");

	private static readonly Class1151 class1151_4 = new Class1151(0, true, "background1", "text1", "background2", "text2", "accent1", "accent2", "accent3", "accent4", "accent5", "accent6", "hyperlink", "followedhyperlink", "stylecolor", "dark1", "light1", "dark2", "light2");

	private static readonly Class1151 class1151_5 = new Class1151(0, true, "linear", "path-rect", "path-circle", "path-shape");

	private static readonly Class1151 class1151_6 = new Class1151(0, true, "no", "yes");

	private static readonly Class1151 class1151_7 = new Class1151(0, true, "solid", "dotgel", "dashgel", "longdashgel", "dashdotgel", "longdashdotgel", "longdashdotdotgel", "dashsys", "dotsys", "dashdotsys", "dashdotdotsys");

	private static readonly Class1151 class1151_8 = new Class1151(0, true, "round", "bevel", "miter");

	private static readonly Class1151 class1151_9 = new Class1151(0, true, "round", "square", "flat");

	private static readonly Class1151 class1151_10 = new Class1151(0, true, "simple", "double", "thinthick", "thickthin", "triple");

	private static readonly Class1151 class1151_11 = new Class1151(0, true, "center", "inset");

	private static readonly Class1151 class1151_12 = new Class1151(0, true, "inherit", "baseline", "bottom", "middle", "sub", "super", "text-bottom", "text-top", "top");

	private static readonly Class1151 class1151_13 = new Class1151(0, true, "left", "center", "right", "decimal");

	public static void smethod_0(Class495.Class497 style, IParagraphFormat paraFormat, float textRectWidth)
	{
		paraFormat.SpaceBefore = smethod_19(style, "margin-top", float.NaN);
		paraFormat.SpaceWithin = smethod_25(style, "line-height", float.NaN);
		paraFormat.SpaceAfter = smethod_19(style, "margin-bottom", float.NaN);
		paraFormat.Indent = smethod_19(style, "text-indent", float.NaN);
		paraFormat.MarginLeft = smethod_19(style, "margin-left", float.NaN);
		paraFormat.MarginRight = smethod_19(style, "margin-right", float.NaN);
		paraFormat.Alignment = (TextAlignment)smethod_26(style, "text-align", class1151_1, -1);
		paraFormat.RightToLeft = (NullableBool)smethod_26(style, "direction", class1151_0, -1);
		paraFormat.HangingPunctuation = (NullableBool)smethod_26(style, "punctuation-wrap", class1151_2, -1);
		string text = style["tab-stops"];
		if (text == null)
		{
			return;
		}
		TabAlignment align = TabAlignment.Left;
		Class1149 @class = new Class1149(text);
		CaseInsensitiveComparer defaultInvariant = CaseInsensitiveComparer.DefaultInvariant;
		while (true)
		{
			int position = @class.Position;
			float num = @class.method_14(float.NaN);
			if (float.IsNaN(num))
			{
				@class.Position = position;
				float num2 = @class.method_12(float.NaN);
				if (!float.IsNaN(num2))
				{
					paraFormat.Tabs.Add(new Tab(num2, align));
					continue;
				}
				@class.Position = position;
				string text2 = @class.method_2();
				if (text2 == null || !(text2 != ""))
				{
					break;
				}
				if (defaultInvariant.Compare(text2, "left") == 0)
				{
					align = TabAlignment.Left;
				}
				else if (defaultInvariant.Compare(text2, "center") == 0)
				{
					align = TabAlignment.Center;
				}
				else if (defaultInvariant.Compare(text2, "right") == 0)
				{
					align = TabAlignment.Right;
				}
				else if (defaultInvariant.Compare(text2, "decimal") == 0)
				{
					align = TabAlignment.Decimal;
				}
			}
			else
			{
				paraFormat.Tabs.Add(new Tab((double)textRectWidth / 100.0 * (double)num, align));
			}
		}
	}

	public static void smethod_1(Class495.Class497 style, PortionFormat portFormat)
	{
		CaseInsensitiveComparer defaultInvariant = CaseInsensitiveComparer.DefaultInvariant;
		string[] array = smethod_16(style, "mso-ascii-font-family");
		string[] array2 = smethod_16(style, "mso-fareast-font-family");
		string[] array3 = smethod_16(style, "mso-bidi-font-family");
		string[] array4 = smethod_16(style, "font-family");
		if (array != null && array.Length > 0)
		{
			portFormat.LatinFont = new FontData(array[0]);
		}
		else if (array4 != null && array4.Length > 0)
		{
			portFormat.LatinFont = new FontData(array4[0]);
		}
		if (array2 != null && array2.Length > 0)
		{
			portFormat.EastAsianFont = new FontData(array2[0]);
		}
		if (array3 != null && array3.Length > 0)
		{
			portFormat.ComplexScriptFont = new FontData(array3[0]);
		}
		portFormat.FontHeight = smethod_19(style, "font-size", float.NaN);
		string text = style["font-style"];
		if (text != null)
		{
			if (defaultInvariant.Compare(text, "normal") == 0)
			{
				portFormat.FontItalic = NullableBool.False;
			}
			else if (defaultInvariant.Compare(text, "italic") == 0)
			{
				portFormat.FontItalic = NullableBool.True;
			}
			else if (defaultInvariant.Compare(text, "oblique") == 0)
			{
				portFormat.FontItalic = NullableBool.True;
			}
			else
			{
				portFormat.FontItalic = NullableBool.NotDefined;
			}
		}
		else
		{
			portFormat.FontItalic = NullableBool.NotDefined;
		}
		text = style["font-weight"];
		if (text != null)
		{
			Class1149 @class = new Class1149(text);
			@class.method_8();
			if (@class.method_9() >= '0' && @class.method_9() <= '9')
			{
				int num = @class.method_15(int.MinValue);
				if (num != int.MinValue)
				{
					if (num >= 700)
					{
						portFormat.FontBold = NullableBool.True;
					}
					else
					{
						portFormat.FontBold = NullableBool.False;
					}
				}
				else
				{
					portFormat.FontBold = NullableBool.NotDefined;
				}
			}
			else
			{
				string a = @class.method_2();
				if (defaultInvariant.Compare(a, "bold") != 0 && defaultInvariant.Compare(a, "bolder") != 0)
				{
					if (defaultInvariant.Compare(a, "normal") != 0 && defaultInvariant.Compare(a, "lighter") != 0)
					{
						portFormat.FontBold = NullableBool.NotDefined;
					}
					else
					{
						portFormat.FontBold = NullableBool.False;
					}
				}
				else
				{
					portFormat.FontBold = NullableBool.True;
				}
			}
		}
		else
		{
			portFormat.FontBold = NullableBool.NotDefined;
		}
		text = style["text-decoration"];
		if (text != null)
		{
			string a2 = new Class1149(text).method_2();
			if (defaultInvariant.Compare(a2, "line-through") == 0)
			{
				portFormat.StrikethroughType = TextStrikethroughType.Single;
			}
			else if (defaultInvariant.Compare(a2, "underline") == 0)
			{
				portFormat.FontUnderline = TextUnderlineType.Single;
			}
		}
		text = style["mso-font-kerning"];
		if (text != null)
		{
			portFormat.KerningMinimalSize = new Class1149(text).method_12(float.NaN);
		}
		text = style["language"];
		if (text != null)
		{
			portFormat.LanguageId = text;
		}
		smethod_6(style, "mso-style-textoutline", portFormat.LineFormat);
		smethod_8(style, "mso-style-textfill", portFormat.FillFormat);
		if (portFormat.FillFormat.FillType == FillType.NotDefined && style.Contains("color"))
		{
			portFormat.FillFormat.FillType = FillType.Solid;
			new Class1149(style["color"]).method_0(portFormat.FillFormat.SolidFillColor);
		}
		float num2 = smethod_23(style, "mso-text-raise", float.NaN);
		if (!float.IsNaN(num2))
		{
			portFormat.Escapement = num2;
			return;
		}
		num2 = smethod_23(style, "vertical-align", float.NaN);
		if (!float.IsNaN(num2))
		{
			portFormat.Escapement = 0f - num2;
			return;
		}
		switch (smethod_26(style, "vertical-align", class1151_12, -1))
		{
		case -1:
		case 0:
			portFormat.Escapement = float.NaN;
			break;
		case 1:
			portFormat.Escapement = 0f;
			break;
		case 3:
			portFormat.Escapement = 20f;
			break;
		case 4:
			portFormat.Escapement = -25f;
			break;
		case 5:
			portFormat.Escapement = 30f;
			break;
		case 2:
		case 6:
			portFormat.Escapement = 40f;
			break;
		case 7:
		case 8:
			portFormat.Escapement = 40f;
			break;
		}
	}

	public static string smethod_2(IParagraphFormat paraFormat)
	{
		IDictionary dictionary = new SortedList(CaseInsensitiveComparer.DefaultInvariant);
		smethod_20(dictionary, "margin-top", paraFormat.SpaceBefore, float.NaN);
		if (paraFormat.SpaceWithin > 0f)
		{
			smethod_24(dictionary, "line-height", paraFormat.SpaceWithin, float.NaN);
		}
		else
		{
			smethod_20(dictionary, "line-height", 0f - paraFormat.SpaceWithin, float.NaN);
		}
		smethod_20(dictionary, "margin-bottom", paraFormat.SpaceAfter, float.NaN);
		smethod_20(dictionary, "text-indent", paraFormat.Indent, float.NaN);
		smethod_20(dictionary, "margin-left", paraFormat.MarginLeft, float.NaN);
		smethod_20(dictionary, "margin-right", paraFormat.MarginRight, float.NaN);
		smethod_27(dictionary, "text-align", class1151_1, (int)paraFormat.Alignment, -1);
		smethod_27(dictionary, "direction", class1151_0, (int)paraFormat.RightToLeft, -1);
		smethod_27(dictionary, "punctuation-wrap", class1151_2, (int)paraFormat.HangingPunctuation, -1);
		if (paraFormat.Tabs.Count > 0)
		{
			TabAlignment alignment = paraFormat.Tabs[0].Alignment;
			StringBuilder stringBuilder = new StringBuilder(class1151_13[(int)paraFormat.Tabs[0].Alignment]);
			for (int i = 0; i < paraFormat.Tabs.Count; i++)
			{
				if (alignment != paraFormat.Tabs[i].Alignment)
				{
					alignment = paraFormat.Tabs[i].Alignment;
					stringBuilder.Append(' ');
					stringBuilder.Append(class1151_13[(int)paraFormat.Tabs[i].Alignment]);
				}
				stringBuilder.Append(' ');
				stringBuilder.Append(XmlConvert.ToString(paraFormat.Tabs[i].Position));
				stringBuilder.Append("pt");
			}
			dictionary["tab-stops"] = stringBuilder.ToString();
		}
		return smethod_5(dictionary);
	}

	public static string smethod_3(IPortionFormat portFormat, bool useMicrosoftSpecific, BaseSlide slide, FloatColor styleColor)
	{
		IDictionary dictionary = new SortedList(CaseInsensitiveComparer.DefaultInvariant);
		if (useMicrosoftSpecific)
		{
			if (portFormat.LatinFont != null)
			{
				smethod_17(dictionary, "mso-ascii-font-family", portFormat.LatinFont.FontName);
			}
			if (portFormat.EastAsianFont != null)
			{
				smethod_17(dictionary, "mso-fareast-font-family", portFormat.EastAsianFont.FontName);
			}
			if (portFormat.ComplexScriptFont != null)
			{
				smethod_17(dictionary, "mso-bidi-font-family", portFormat.ComplexScriptFont.FontName);
			}
			smethod_20(dictionary, "mso-font-kerning", portFormat.KerningMinimalSize, float.NaN);
			smethod_7(dictionary, "mso-style-textoutline", portFormat.LineFormat, slide, styleColor);
			smethod_9(dictionary, "mso-style-textfill", portFormat.FillFormat, slide, styleColor);
			if (!float.IsNaN(portFormat.Escapement))
			{
				smethod_24(dictionary, "mso-text-raise", portFormat.Escapement, 0f);
			}
		}
		if (portFormat.LatinFont != null)
		{
			smethod_17(dictionary, "font-family", portFormat.LatinFont.GetFontName(slide.CreateThemeEffective()));
		}
		smethod_20(dictionary, "font-size", portFormat.FontHeight, float.NaN);
		if (portFormat.FontItalic == NullableBool.True)
		{
			dictionary["font-style"] = "italic";
		}
		if (portFormat.FontBold == NullableBool.True)
		{
			dictionary["font-weight"] = "bold";
		}
		dictionary["language"] = portFormat.LanguageId;
		if (!float.IsNaN(portFormat.Escapement) && portFormat.Escapement != 0f)
		{
			dictionary["vertical-align"] = ((portFormat.Escapement > 0f) ? "super" : "sub");
		}
		return smethod_5(dictionary);
	}

	public static string smethod_4(Paragraph para, bool useMicrosoftSpecific, BaseSlide slide, FloatColor styleColor)
	{
		IDictionary dictionary = new SortedList();
		if (para.ParagraphFormat.Bullet.IsBulletHardFont == NullableBool.True && para.ParagraphFormat.Bullet.Font != null)
		{
			smethod_17(dictionary, "font-family", para.ParagraphFormat.Bullet.Font.GetFontName(slide.CreateThemeEffective()));
		}
		else if (para.Portions.Count > 0 && para.Portions[0].PortionFormat.LatinFont != null)
		{
			smethod_17(dictionary, "font-family", para.Portions[0].PortionFormat.LatinFont.GetFontName(slide.CreateThemeEffective()));
		}
		if (para.Portions.Count > 0)
		{
			smethod_20(dictionary, "font-size", para.ParagraphFormat.Bullet.Height / 100f * para.Portions[0].PortionFormat.FontHeight, float.NaN);
		}
		if (para.ParagraphFormat.Bullet.IsBulletHardColor == NullableBool.True)
		{
			Color color = ((ColorFormat)para.ParagraphFormat.Bullet.Color).method_5(slide, styleColor);
			dictionary["color"] = $"#{color.R:x2}{color.G:x2}{color.B:x2}";
		}
		if (useMicrosoftSpecific)
		{
			if (para.ParagraphFormat.Bullet.Type == BulletType.Numbered)
			{
				dictionary["mso-special-format"] = $"'numbullet{(int)para.ParagraphFormat.Bullet.NumberedBulletStyle}\\,{para.ParagraphFormat.Bullet.NumberedBulletStartWith}'";
			}
			else
			{
				dictionary["mso-special-format"] = "bullet";
			}
		}
		return smethod_5(dictionary);
	}

	private static string smethod_5(IDictionary style)
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (DictionaryEntry item in style)
		{
			stringBuilder.AppendFormat(";{0}:{1}", item.Key, item.Value);
		}
		if (stringBuilder.Length == 0)
		{
			return null;
		}
		return stringBuilder.ToString(1, stringBuilder.Length - 1);
	}

	private static void smethod_6(Class495.Class497 style, string prefix, ILineFormat format)
	{
		format.FillFormat.FillType = (FillType)smethod_26(style, prefix + "-type", class1151_3, -1);
		switch (format.FillFormat.FillType)
		{
		case FillType.Solid:
			smethod_10(style, prefix + "-fill", format.FillFormat.SolidFillColor);
			break;
		case FillType.Gradient:
			smethod_14(style, prefix + "-fill-gradientfill", format.FillFormat.GradientFormat);
			break;
		}
		format.DashStyle = (LineDashStyle)smethod_26(style, prefix + "-outlinestyle-dash", class1151_7, -1);
		format.JoinStyle = (LineJoinStyle)smethod_26(style, prefix + "-outlinestyle-join", class1151_8, -1);
		format.CapStyle = (LineCapStyle)smethod_26(style, prefix + "-outlinestyle-linecap", class1151_9, -1);
		format.Style = (LineStyle)smethod_26(style, prefix + "-outlinestyle-compound", class1151_10, -1);
		format.Alignment = (LineAlignment)smethod_26(style, prefix + "-outlinestyle-align", class1151_11, -1);
	}

	private static void smethod_7(IDictionary style, string prefix, ILineFormat format, BaseSlide slide, FloatColor styleColor)
	{
		switch (format.FillFormat.FillType)
		{
		case FillType.Solid:
			smethod_27(style, prefix + "-type", class1151_3, (int)format.FillFormat.FillType, -1);
			smethod_11(style, prefix + "-fill", (ColorFormat)format.FillFormat.SolidFillColor, slide, styleColor);
			break;
		case FillType.Gradient:
			smethod_27(style, prefix + "-type", class1151_3, (int)format.FillFormat.FillType, -1);
			smethod_15(style, prefix + "-fill-gradientfill", (GradientFormat)format.FillFormat.GradientFormat, slide, styleColor);
			break;
		}
		smethod_27(style, prefix + "-outlinestyle-dash", class1151_7, (int)format.DashStyle, -1);
		smethod_27(style, prefix + "-outlinestyle-join", class1151_8, (int)format.JoinStyle, -1);
		smethod_27(style, prefix + "-outlinestyle-linecap", class1151_9, (int)format.CapStyle, -1);
		smethod_27(style, prefix + "-outlinestyle-compound", class1151_10, (int)format.Style, -1);
		smethod_27(style, prefix + "-outlinestyle-align", class1151_11, (int)format.Alignment, -1);
	}

	private static void smethod_8(Class495.Class497 style, string prefix, IFillFormat format)
	{
		format.FillType = (FillType)smethod_26(style, prefix + "-type", class1151_3, -1);
		switch (format.FillType)
		{
		case FillType.Solid:
			smethod_10(style, prefix + "-fill", format.SolidFillColor);
			break;
		case FillType.Gradient:
			smethod_14(style, prefix + "-fill-gradientfill", format.GradientFormat);
			break;
		}
	}

	private static void smethod_9(IDictionary style, string prefix, IFillFormat format, BaseSlide slide, FloatColor styleColor)
	{
		switch (format.FillType)
		{
		case FillType.Solid:
		{
			smethod_27(style, prefix + "-type", class1151_3, (int)format.FillType, -1);
			smethod_11(style, prefix + "-fill", (ColorFormat)format.SolidFillColor, slide, styleColor);
			Color color = ((ColorFormat)format.SolidFillColor).method_5(slide, styleColor);
			style["color"] = $"#{color.R:x2}{color.G:x2}{color.B:x2}";
			break;
		}
		case FillType.Gradient:
			smethod_27(style, prefix + "-type", class1151_3, (int)format.FillType, -1);
			smethod_15(style, prefix + "-fill-gradientfill", (GradientFormat)format.GradientFormat, slide, styleColor);
			break;
		}
	}

	private static void smethod_10(Class495.Class497 style, string prefix, IColorFormat colorFormat)
	{
		string text = style[prefix + "-color"];
		if (text != null)
		{
			new Class1149(text).method_0(colorFormat);
		}
		SchemeColor schemeColor = (SchemeColor)smethod_26(style, prefix + "-themecolor", class1151_4, -1);
		if (schemeColor != SchemeColor.NotDefined)
		{
			colorFormat.SchemeColor = schemeColor;
		}
		float num = smethod_23(style, prefix + "-alpha", float.NaN);
		if (!float.IsNaN(num))
		{
			colorFormat.ColorTransform.Add(ColorTransformOperation.SetAlpha, num / 100f);
		}
		text = style[prefix + "-colortransforms"];
		if (text != null)
		{
			Class1149 parser = new Class1149(text);
			smethod_12(parser, colorFormat);
		}
	}

	private static void smethod_11(IDictionary style, string prefix, ColorFormat colorFormat, BaseSlide slide, FloatColor styleColor)
	{
		Color color = colorFormat.method_2(slide, styleColor).Color;
		style[prefix + "-color"] = $"#{color.R:x2}{color.G:x2}{color.B:x2}";
		if (colorFormat.ColorType == ColorType.Scheme)
		{
			smethod_27(style, prefix + "-themecolor", class1151_4, (int)colorFormat.SchemeColor, -1);
		}
		float float_ = colorFormat.method_4(slide, styleColor).float_0;
		smethod_24(style, prefix + "-alpha", float_ * 100f, 100f);
		string text = smethod_13(colorFormat);
		if (text != null && text != "")
		{
			style[prefix + "-colortransforms"] = text;
		}
	}

	private static void smethod_12(Class1149 parser, IColorFormat colorFormat)
	{
		CaseInsensitiveComparer defaultInvariant = CaseInsensitiveComparer.DefaultInvariant;
		while (parser.CharsLeftCount > 0)
		{
			parser.method_8();
			char c = parser.method_9();
			if ((c < 'A' || c > 'Z') && (c < 'a' || c > 'z'))
			{
				break;
			}
			string text = parser.method_2();
			if (!(text != ""))
			{
				continue;
			}
			parser.method_8();
			if (parser.method_7() != '=')
			{
				continue;
			}
			int num = parser.method_15(int.MinValue);
			if (num != int.MinValue)
			{
				if (defaultInvariant.Compare(text, "tint") == 0)
				{
					colorFormat.ColorTransform.Add(ColorTransformOperation.Tint, (float)num / 100000f);
				}
				else if (defaultInvariant.Compare(text, "shade") == 0)
				{
					colorFormat.ColorTransform.Add(ColorTransformOperation.Shade, (float)num / 100000f);
				}
				else if (defaultInvariant.Compare(text, "huem") == 0)
				{
					colorFormat.ColorTransform.Add(ColorTransformOperation.MultiplyHue, (float)num / 100000f);
				}
				else if (defaultInvariant.Compare(text, "sat") == 0)
				{
					colorFormat.ColorTransform.Add(ColorTransformOperation.SetSaturation, (float)num / 100000f);
				}
				else if (defaultInvariant.Compare(text, "sato") == 0)
				{
					colorFormat.ColorTransform.Add(ColorTransformOperation.AddSaturation, (float)num / 100000f);
				}
				else if (defaultInvariant.Compare(text, "satm") == 0)
				{
					colorFormat.ColorTransform.Add(ColorTransformOperation.MultiplySaturation, (float)num / 100000f);
				}
				else if (defaultInvariant.Compare(text, "lum") == 0)
				{
					colorFormat.ColorTransform.Add(ColorTransformOperation.SetLuminance, (float)num / 100000f);
				}
				else if (defaultInvariant.Compare(text, "lumo") == 0)
				{
					colorFormat.ColorTransform.Add(ColorTransformOperation.AddLuminance, (float)num / 100000f);
				}
				else if (defaultInvariant.Compare(text, "lumm") == 0)
				{
					colorFormat.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, (float)num / 100000f);
				}
			}
		}
	}

	private static string smethod_13(ColorFormat colorFormat)
	{
		StringBuilder stringBuilder = new StringBuilder();
		_ = CaseInsensitiveComparer.DefaultInvariant;
		for (int i = 0; i < colorFormat.ColorTransform.Count; i++)
		{
			switch (colorFormat.ColorTransform[i].OperationType)
			{
			case ColorTransformOperation.Tint:
				stringBuilder.AppendFormat(" tint={0}", (int)((double)colorFormat.ColorTransform[i].Parameter * 100000.0));
				break;
			case ColorTransformOperation.Shade:
				stringBuilder.AppendFormat(" shade={0}", (int)(colorFormat.ColorTransform[i].Parameter * 100000f + 0.5f));
				break;
			case ColorTransformOperation.MultiplyHue:
				stringBuilder.AppendFormat(" huem={0}", (int)(colorFormat.ColorTransform[i].Parameter * 100000f + 0.5f));
				break;
			case ColorTransformOperation.SetSaturation:
				stringBuilder.AppendFormat(" sat={0}", (int)(colorFormat.ColorTransform[i].Parameter * 100000f + 0.5f));
				break;
			case ColorTransformOperation.AddSaturation:
				stringBuilder.AppendFormat(" sato={0}", (int)(colorFormat.ColorTransform[i].Parameter * 100000f + 0.5f));
				break;
			case ColorTransformOperation.MultiplySaturation:
				stringBuilder.AppendFormat(" satm={0}", (int)(colorFormat.ColorTransform[i].Parameter * 100000f + 0.5f));
				break;
			case ColorTransformOperation.SetLuminance:
				stringBuilder.AppendFormat(" lum={0}", (int)(colorFormat.ColorTransform[i].Parameter * 100000f + 0.5f));
				break;
			case ColorTransformOperation.AddLuminance:
				stringBuilder.AppendFormat(" lumo={0}", (int)(colorFormat.ColorTransform[i].Parameter * 100000f + 0.5f));
				break;
			case ColorTransformOperation.MultiplyLuminance:
				stringBuilder.AppendFormat(" lumm={0}", (int)(colorFormat.ColorTransform[i].Parameter * 100000f + 0.5f));
				break;
			}
		}
		if (stringBuilder.Length > 0)
		{
			return stringBuilder.ToString(1, stringBuilder.Length - 1);
		}
		return null;
	}

	private static void smethod_14(Class495.Class497 style, string prefix, IGradientFormat gradientFormat)
	{
		gradientFormat.GradientShape = (GradientShape)smethod_26(style, prefix + "-shadetype", class1151_5, -1);
		switch (gradientFormat.GradientShape)
		{
		case GradientShape.Linear:
			gradientFormat.LinearGradientAngle = smethod_21(style, prefix + "-shade-linearshade-angle", float.NaN) / 60000f;
			gradientFormat.LinearGradientScaled = (NullableBool)smethod_26(style, prefix + "-shade-linearshade-fscaled", class1151_6, -1);
			break;
		case GradientShape.Rectangle:
		case GradientShape.Radial:
		case GradientShape.Path:
		{
			float num = smethod_23(style, prefix + "-shade-rectfill-pctleft", float.NaN);
			float num2 = smethod_23(style, prefix + "-shade-rectfill-pctright", float.NaN);
			float num3 = smethod_23(style, prefix + "-shade-rectfill-pcttop", float.NaN);
			float num4 = smethod_23(style, prefix + "-shade-rectfill-pctbottom", float.NaN);
			((GradientFormat)gradientFormat).method_6(num, num3, num2 - num, num4 - num3);
			break;
		}
		}
		string str = style[prefix + "-stoplist"];
		Class1149 @class = new Class1149(str);
		if (@class.method_9() == '\'' || @class.method_9() == '"')
		{
			@class.method_7();
		}
		while (@class.CharsLeftCount > 0)
		{
			float num5 = @class.method_11(float.NaN);
			if (!float.IsNaN(num5))
			{
				gradientFormat.GradientStops.Add(num5 / 100000f, Color.Black);
				IGradientStop gradientStop = gradientFormat.GradientStops[gradientFormat.GradientStops.Count - 1];
				@class.method_8();
				@class.method_7();
				@class.method_0(gradientStop.Color);
				int num6 = @class.method_15(-1);
				if (num6 >= 0)
				{
					gradientStop.Color.SchemeColor = (SchemeColor)num6;
				}
				@class.method_8();
				float num7 = @class.method_11(float.NaN) / 100000f;
				if (!float.IsNaN(num7))
				{
					gradientStop.Color.ColorTransform.Insert(0, ColorTransformOperation.SetAlpha, num7);
				}
				smethod_12(@class, (ColorFormat)gradientStop.Color);
				@class.method_8();
				if (@class.method_9() == '\\')
				{
					@class.method_7();
				}
				if (@class.method_9() == ',')
				{
					@class.method_7();
				}
				continue;
			}
			break;
		}
	}

	private static void smethod_15(IDictionary style, string prefix, GradientFormat gradientFormat, BaseSlide slide, FloatColor styleColor)
	{
		smethod_27(style, prefix + "-shadetype", class1151_5, (int)gradientFormat.GradientShape, -1);
		switch (gradientFormat.GradientShape)
		{
		case GradientShape.Linear:
			smethod_22(style, prefix + "-shade-linearshade-angle", gradientFormat.LinearGradientAngle * 60000f, float.NaN);
			smethod_27(style, prefix + "-shade-linearshade-fscaled", class1151_6, (int)gradientFormat.LinearGradientScaled, -1);
			break;
		case GradientShape.Rectangle:
		case GradientShape.Radial:
		case GradientShape.Path:
			smethod_24(style, prefix + "-shade-rectfill-pctleft", gradientFormat.FillToRectangleX, float.NaN);
			smethod_24(style, prefix + "-shade-rectfill-pctright", gradientFormat.FillToRectangleX + gradientFormat.FillToRectangleWidth, float.NaN);
			smethod_24(style, prefix + "-shade-rectfill-pcttop", gradientFormat.FillToRectangleY, float.NaN);
			smethod_24(style, prefix + "-shade-rectfill-pctbottom", gradientFormat.FillToRectangleY + gradientFormat.FillToRectangleHeight, float.NaN);
			break;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < gradientFormat.GradientStops.Count; i++)
		{
			IGradientStop gradientStop = gradientFormat.GradientStops[i];
			Color color = ((ColorFormat)gradientFormat.GradientStops[i].Color).method_5(slide, styleColor);
			stringBuilder.AppendFormat("\\,{0} \\#{1:x2}{2:x2}{3:x2} {4}", (int)(gradientStop.Position * 100000f + 0.5f), color.R, color.G, color.B, (int)gradientStop.Color.SchemeColor);
			stringBuilder.AppendFormat(" {0}", (int)((float)(int)color.A * 100000f / 255f));
			string text = smethod_13((ColorFormat)gradientStop.Color);
			if (text != null)
			{
				stringBuilder.AppendFormat(" {0}", text);
			}
		}
		if (stringBuilder.Length > 2)
		{
			style[prefix + "-stoplist"] = stringBuilder.ToString(2, stringBuilder.Length - 2);
		}
	}

	internal static string[] smethod_16(Class495.Class497 style, string name)
	{
		string text = style[name];
		if (text == null)
		{
			return null;
		}
		Class1149 @class = new Class1149(text);
		List<string> list = new List<string>();
		string item;
		while ((item = @class.method_3()) != "")
		{
			list.Add(item);
			@class.method_8();
			if (@class.method_9() == ',')
			{
				@class.method_7();
			}
		}
		return list.ToArray();
	}

	private static void smethod_17(IDictionary style, string name, string fontName)
	{
		style[name] = smethod_18(fontName);
	}

	private static string smethod_18(string str)
	{
		if (str.IndexOfAny(char_0) >= 0)
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			while (num < str.Length)
			{
				int num2 = str.IndexOfAny(char_0, num);
				if (num2 < 0)
				{
					num2 = str.Length;
				}
				if (num < num2)
				{
					stringBuilder.Append(str, num, num2);
				}
				if (num2 < str.Length)
				{
					switch (str[num2])
					{
					case '\\':
						stringBuilder.Append("\\\\");
						break;
					case '\'':
						stringBuilder.Append("\\'");
						break;
					case '\n':
						stringBuilder.Append("\\0000000a");
						break;
					}
					num2++;
				}
				num = num2;
			}
			return stringBuilder.ToString();
		}
		return $"'{str}'";
	}

	private static float smethod_19(Class495.Class497 style, string name, float defaultValue)
	{
		string text = style[name];
		if (text == null)
		{
			return defaultValue;
		}
		Class1149 @class = new Class1149(text);
		return @class.method_10();
	}

	private static void smethod_20(IDictionary style, string name, float value, float defaultValue)
	{
		if (Class1165.smethod_0(value, defaultValue))
		{
			style.Remove(name);
		}
		else
		{
			style[name] = XmlConvert.ToString(value) + "pt";
		}
	}

	private static float smethod_21(Class495.Class497 style, string name, float defaultValue)
	{
		string text = style[name];
		if (text == null)
		{
			return defaultValue;
		}
		Class1149 @class = new Class1149(text);
		return @class.method_11(defaultValue);
	}

	private static void smethod_22(IDictionary style, string name, float value, float defaultValue)
	{
		if (Class1165.smethod_0(value, defaultValue))
		{
			style.Remove(name);
		}
		else
		{
			style[name] = XmlConvert.ToString(value);
		}
	}

	private static float smethod_23(Class495.Class497 style, string name, float defaultValue)
	{
		string text = style[name];
		if (text == null)
		{
			return defaultValue;
		}
		Class1149 @class = new Class1149(text);
		return @class.method_14(defaultValue);
	}

	private static void smethod_24(IDictionary style, string name, float value, float defaultValue)
	{
		if (Class1165.smethod_0(value, defaultValue))
		{
			style.Remove(name);
		}
		else
		{
			style[name] = XmlConvert.ToString(value) + '%';
		}
	}

	private static float smethod_25(Class495.Class497 style, string name, float defaultValue)
	{
		string text = style[name];
		if (text == null)
		{
			return defaultValue;
		}
		Class1149 @class = new Class1149(text);
		if (text.IndexOf("%") >= 0)
		{
			return @class.method_13();
		}
		return @class.method_10();
	}

	private static int smethod_26(Class495.Class497 style, string name, Class1151 enumDescriptor, int defaultValue)
	{
		string text = style[name];
		if (text != null && enumDescriptor.Contains(text))
		{
			return enumDescriptor[text];
		}
		return defaultValue;
	}

	private static void smethod_27(IDictionary style, string name, Class1151 enumDescriptor, int value, int defaultValue)
	{
		if (value == defaultValue)
		{
			style.Remove(name);
		}
		else
		{
			style[name] = enumDescriptor[value];
		}
	}
}
