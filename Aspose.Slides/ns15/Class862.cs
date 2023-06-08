using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Effects;
using ns4;
using ns60;
using ns63;

namespace ns15;

internal class Class862
{
	internal class Class863
	{
		internal short? nullable_0;

		internal short? nullable_1;

		internal float float_0;

		internal float float_1;
	}

	internal static void smethod_0(Class2974 textPFException, ParagraphFormat resultParagraphFormat, Class48 fontsList)
	{
		if (textPFException == null || resultParagraphFormat == null)
		{
			return;
		}
		BulletFormat bulletFormat_ = resultParagraphFormat.bulletFormat_0;
		NullableBool hasBullet = textPFException.HasBullet;
		if (hasBullet == NullableBool.NotDefined)
		{
			bulletFormat_.bulletType_0 = BulletType.NotDefined;
		}
		else
		{
			bulletFormat_.bulletType_0 = ((hasBullet == NullableBool.True) ? BulletType.Symbol : BulletType.None);
		}
		bulletFormat_.IsBulletHardColor = textPFException.BulletHasColor;
		bulletFormat_.IsBulletHardFont = textPFException.BulletHasFont;
		if (textPFException.BulletChar.HasValue)
		{
			bulletFormat_.PPTXUnsupportedProps.BulletChar = textPFException.BulletChar.Value;
		}
		if (textPFException.BulletFontRef.HasValue && textPFException.BulletFontRef.Value != ushort.MaxValue)
		{
			bulletFormat_.ifontData_0 = fontsList.method_6(textPFException.BulletFontRef.Value).FontData;
		}
		if (textPFException.BulletSize.HasValue)
		{
			bulletFormat_.float_0 = textPFException.BulletSize.Value;
		}
		if (textPFException.BulletColor != null)
		{
			Class1049.smethod_9(bulletFormat_.colorFormat_0, textPFException.BulletColor);
		}
		if (textPFException.TextAlignment.HasValue)
		{
			resultParagraphFormat.textAlignment_0 = (TextAlignment)(textPFException.TextAlignment.Value & Enum455.const_4);
		}
		else
		{
			resultParagraphFormat.textAlignment_0 = TextAlignment.NotDefined;
		}
		if (textPFException.LineSpacing.HasValue)
		{
			resultParagraphFormat.float_1 = smethod_15(textPFException.LineSpacing.Value);
		}
		if (textPFException.SpaceBefore.HasValue)
		{
			resultParagraphFormat.float_2 = smethod_15(textPFException.SpaceBefore.Value);
		}
		if (textPFException.SpaceAfter.HasValue)
		{
			resultParagraphFormat.float_3 = smethod_15(textPFException.SpaceAfter.Value);
		}
		Class863 @class = new Class863();
		@class.nullable_0 = textPFException.LeftMargin;
		@class.nullable_1 = textPFException.Indent;
		smethod_19(@class);
		resultParagraphFormat.double_0 = @class.float_0;
		resultParagraphFormat.double_2 = @class.float_1;
		if (textPFException.DefaultTabSize.HasValue)
		{
			resultParagraphFormat.double_3 = smethod_17(textPFException.DefaultTabSize.Value);
		}
		resultParagraphFormat.Tabs.Clear();
		if (textPFException.TabStops != null)
		{
			for (int i = 0; i < textPFException.TabStops.Count; i++)
			{
				double position = (double)textPFException.TabStops[i].Position / 8.0;
				TabAlignment align = smethod_13(textPFException.TabStops[i].TabType);
				resultParagraphFormat.Tabs.Add(position, align);
			}
		}
		if (textPFException.FontAlign.HasValue)
		{
			resultParagraphFormat.FontAlignment = smethod_11(textPFException.FontAlign.Value);
		}
		if (textPFException.TextDirection.HasValue)
		{
			resultParagraphFormat.RightToLeft = ((textPFException.TextDirection.Value == Enum445.const_1) ? NullableBool.True : NullableBool.False);
		}
		resultParagraphFormat.nullableBool_0 = textPFException.CharWrap;
		resultParagraphFormat.nullableBool_3 = textPFException.Overflow;
		resultParagraphFormat.PPTUnsupportedProps.TextPFException_Masks_SWordWrap = textPFException.WordWrap != NullableBool.NotDefined;
		resultParagraphFormat.PPTUnsupportedProps.TextPFException_WrapFlags_BWordWrap = textPFException.WordWrap == NullableBool.True;
	}

	internal static void smethod_1(IParagraphFormat domParagraphFormat, Class2974 resultTextPFException, Class856 pptSerializationContext)
	{
		if (domParagraphFormat == null)
		{
			return;
		}
		domParagraphFormat.DefaultPortionFormat.KerningMinimalSize = 12f;
		BulletFormat bulletFormat_ = ((ParagraphFormat)domParagraphFormat).bulletFormat_0;
		if (bulletFormat_.Type != BulletType.NotDefined)
		{
			resultTextPFException.HasBullet = ((bulletFormat_.Type != 0) ? NullableBool.True : NullableBool.False);
		}
		else
		{
			resultTextPFException.HasBullet = NullableBool.NotDefined;
		}
		resultTextPFException.BulletHasFont = domParagraphFormat.Bullet.IsBulletHardFont;
		resultTextPFException.BulletHasColor = domParagraphFormat.Bullet.IsBulletHardColor;
		if (!float.IsNaN(domParagraphFormat.Bullet.Height))
		{
			resultTextPFException.BulletHasSize = NullableBool.True;
			resultTextPFException.BulletSize = (short)domParagraphFormat.Bullet.Height;
		}
		else
		{
			resultTextPFException.BulletHasSize = NullableBool.NotDefined;
			resultTextPFException.BulletSize = null;
		}
		if ((short)domParagraphFormat.Bullet.Char != -1)
		{
			resultTextPFException.BulletChar = (short)domParagraphFormat.Bullet.Char;
		}
		else
		{
			resultTextPFException.BulletChar = null;
		}
		if (domParagraphFormat.Bullet.IsBulletHardFont != NullableBool.NotDefined)
		{
			resultTextPFException.BulletFontRef = ((domParagraphFormat.Bullet.IsBulletHardFont == NullableBool.True) ? new ushort?(Class53.smethod_1(pptSerializationContext).Add(Enum2.const_0, domParagraphFormat.Bullet.Font)) : new ushort?(ushort.MaxValue));
		}
		if (domParagraphFormat.Bullet.IsBulletHardColor == NullableBool.True)
		{
			resultTextPFException.BulletColor = Class1049.smethod_10(domParagraphFormat.Bullet.Color);
		}
		if (domParagraphFormat.Alignment != TextAlignment.NotDefined)
		{
			resultTextPFException.TextAlignment = (Enum455)domParagraphFormat.Alignment;
		}
		else
		{
			resultTextPFException.TextAlignment = null;
		}
		if (!float.IsNaN(domParagraphFormat.SpaceWithin))
		{
			resultTextPFException.LineSpacing = smethod_16(domParagraphFormat.SpaceWithin);
		}
		else
		{
			resultTextPFException.LineSpacing = null;
		}
		if (!float.IsNaN(domParagraphFormat.SpaceBefore))
		{
			resultTextPFException.SpaceBefore = smethod_16(domParagraphFormat.SpaceBefore);
		}
		else
		{
			resultTextPFException.SpaceBefore = null;
		}
		if (!float.IsNaN(domParagraphFormat.SpaceAfter))
		{
			resultTextPFException.SpaceAfter = smethod_16(domParagraphFormat.SpaceAfter);
		}
		else
		{
			resultTextPFException.SpaceAfter = null;
		}
		Class863 @class = new Class863();
		@class.float_0 = domParagraphFormat.MarginLeft;
		@class.float_1 = domParagraphFormat.Indent;
		smethod_20(@class);
		resultTextPFException.LeftMargin = @class.nullable_0;
		resultTextPFException.Indent = @class.nullable_1;
		if (!double.IsNaN(domParagraphFormat.DefaultTabSize))
		{
			resultTextPFException.DefaultTabSize = smethod_18(domParagraphFormat.DefaultTabSize);
		}
		else
		{
			resultTextPFException.DefaultTabSize = null;
		}
		if (domParagraphFormat.Tabs.Count > 0)
		{
			resultTextPFException.TabStops = new Class2942();
			for (int i = 0; i < domParagraphFormat.Tabs.Count; i++)
			{
				short position = (short)(domParagraphFormat.Tabs[i].Position * 8.0);
				Enum456 type = smethod_14(domParagraphFormat.Tabs[i].Alignment);
				resultTextPFException.TabStops.Add(new Class2978(position, type));
			}
		}
		else
		{
			resultTextPFException.TabStops = null;
		}
		if (domParagraphFormat.FontAlignment != FontAlignment.Default)
		{
			resultTextPFException.FontAlign = smethod_12(domParagraphFormat.FontAlignment);
		}
		else
		{
			resultTextPFException.FontAlign = null;
		}
		if (domParagraphFormat.RightToLeft != NullableBool.NotDefined)
		{
			resultTextPFException.TextDirection = ((domParagraphFormat.RightToLeft == NullableBool.True) ? Enum445.const_1 : Enum445.const_0);
		}
		else
		{
			resultTextPFException.TextDirection = null;
		}
		resultTextPFException.CharWrap = domParagraphFormat.EastAsianLineBreak;
		resultTextPFException.Overflow = domParagraphFormat.HangingPunctuation;
		if (((ParagraphFormat)domParagraphFormat).PPTUnsupportedProps.TextPFException_Masks_SWordWrap)
		{
			resultTextPFException.WordWrap = (((ParagraphFormat)domParagraphFormat).PPTUnsupportedProps.TextPFException_WrapFlags_BWordWrap ? NullableBool.True : NullableBool.False);
		}
	}

	internal static void smethod_2(Class2971 textCFException, PortionFormat resultPortionFormat, Class48 fontsList)
	{
		resultPortionFormat.FontBold = textCFException.Bold;
		resultPortionFormat.FontItalic = textCFException.Italic;
		if (textCFException.Underline != NullableBool.NotDefined)
		{
			resultPortionFormat.FontUnderline = ((textCFException.Underline == NullableBool.True) ? TextUnderlineType.Single : TextUnderlineType.None);
		}
		else
		{
			resultPortionFormat.FontUnderline = TextUnderlineType.NotDefined;
		}
		resultPortionFormat.Kumimoji = textCFException.Kumi;
		bool flag = textCFException.Shadow == NullableBool.True;
		_ = textCFException.Emboss == NullableBool.True;
		if (textCFException.FontRef.HasValue && textCFException.FontRef != ushort.MaxValue && fontsList.method_7() > textCFException.FontRef.Value)
		{
			resultPortionFormat.LatinFont = fontsList.method_6(textCFException.FontRef.Value).FontData;
		}
		if (textCFException.PP9RT.HasValue)
		{
			resultPortionFormat.ParentParagraphFormat.bulletFormat_0.PPTUnsupportedProps.BulletSchemeIndex = textCFException.PP9RT;
		}
		if (textCFException.OldEAFontRef.HasValue && textCFException.OldEAFontRef != ushort.MaxValue)
		{
			resultPortionFormat.EastAsianFont = fontsList.method_6(textCFException.OldEAFontRef.Value).FontData;
		}
		if (textCFException.SymbolFontRef.HasValue && textCFException.SymbolFontRef != ushort.MaxValue)
		{
			resultPortionFormat.SymbolFont = fontsList.method_6(textCFException.SymbolFontRef.Value).FontData;
		}
		if (textCFException.FontSize.HasValue)
		{
			short? fontSize = textCFException.FontSize;
			if (fontSize.GetValueOrDefault() != 0 || !fontSize.HasValue)
			{
				resultPortionFormat.FontHeight = textCFException.FontSize.Value;
			}
		}
		if (textCFException.Color != null && textCFException.Color.Index != Class2966.Enum441.const_9)
		{
			resultPortionFormat.FillFormat.FillType = FillType.Solid;
			Class1049.smethod_9(resultPortionFormat.FillFormat.SolidFillColor, textCFException.Color);
		}
		if (textCFException.Position.HasValue)
		{
			short? position = textCFException.Position;
			if (position.GetValueOrDefault() != 0 || !position.HasValue)
			{
				resultPortionFormat.Escapement = textCFException.Position.Value;
			}
		}
		if (flag)
		{
			OuterShadow outerShadow = new OuterShadow(null);
			double distance = 3.0;
			outerShadow.BlurRadius = 3.0;
			outerShadow.Distance = distance;
			outerShadow.Direction = 45f;
			outerShadow.RectangleAlign = RectangleAlignment.TopLeft;
			outerShadow.ShadowColor.Color = ((resultPortionFormat.FillFormat.FillType != FillType.Solid || (double)resultPortionFormat.FillFormat.SolidFillColor.Color.GetBrightness() <= 0.5) ? Color.White : Color.Black);
			((ColorFormat)outerShadow.ShadowColor).SchemeColor = Class232.smethod_13(2);
			resultPortionFormat.EffectFormat.OuterShadowEffect = outerShadow;
		}
	}

	internal static void smethod_3(IPortionFormat domPortionFormat, Class2971 resultTextCFException, Class856 pptSerializationContext)
	{
		if (domPortionFormat != null)
		{
			resultTextCFException.Bold = domPortionFormat.FontBold;
			resultTextCFException.Italic = domPortionFormat.FontItalic;
			if (domPortionFormat.FontUnderline != TextUnderlineType.NotDefined)
			{
				resultTextCFException.Underline = ((domPortionFormat.FontUnderline != 0) ? NullableBool.True : NullableBool.False);
			}
			else
			{
				resultTextCFException.Underline = NullableBool.NotDefined;
			}
			resultTextCFException.Shadow = ((domPortionFormat.EffectFormat.InnerShadowEffect != null || domPortionFormat.EffectFormat.OuterShadowEffect != null || domPortionFormat.EffectFormat.PresetShadowEffect != null) ? NullableBool.True : NullableBool.NotDefined);
			resultTextCFException.Kumi = domPortionFormat.Kumimoji;
			if (domPortionFormat.LatinFont != null)
			{
				resultTextCFException.FontRef = Class53.smethod_1(pptSerializationContext).Add(Enum2.const_0, domPortionFormat.LatinFont);
			}
			if (domPortionFormat.EastAsianFont != null)
			{
				resultTextCFException.OldEAFontRef = Class53.smethod_1(pptSerializationContext).Add(Enum2.const_1, domPortionFormat.EastAsianFont);
			}
			if (domPortionFormat.SymbolFont != null)
			{
				resultTextCFException.SymbolFontRef = Class53.smethod_1(pptSerializationContext).Add(Enum2.const_0, domPortionFormat.SymbolFont);
			}
			if (!float.IsNaN(domPortionFormat.FontHeight))
			{
				resultTextCFException.FontSize = (short)domPortionFormat.FontHeight;
			}
			else
			{
				resultTextCFException.FontSize = null;
			}
			if (domPortionFormat.FillFormat.FillType == FillType.Solid)
			{
				resultTextCFException.Color = Class1049.smethod_10(domPortionFormat.FillFormat.SolidFillColor);
			}
			if (!float.IsNaN(domPortionFormat.Escapement))
			{
				resultTextCFException.Position = (short)domPortionFormat.Escapement;
			}
		}
	}

	public static void smethod_4(Class2894 relatedTextMasterStyleAtom, ushort indentLevel, Class201 shapeSerializationContext)
	{
		shapeSerializationContext.RelatedTextStyleLevel = null;
		shapeSerializationContext.CurrentTextDefaultStyleLevel = null;
		shapeSerializationContext.CurrentTextMasterStyleLevel = null;
		if (relatedTextMasterStyleAtom != null && indentLevel < relatedTextMasterStyleAtom.Levels.Count)
		{
			shapeSerializationContext.RelatedTextStyleLevel = relatedTextMasterStyleAtom.Levels[indentLevel];
		}
		if (shapeSerializationContext.IsPlaceholder)
		{
			if (shapeSerializationContext.CurrentTextMasterStyle != null && indentLevel < shapeSerializationContext.CurrentTextMasterStyle.Levels.Count)
			{
				shapeSerializationContext.CurrentTextMasterStyleLevel = shapeSerializationContext.CurrentTextMasterStyle.Levels[indentLevel];
			}
		}
		else if (shapeSerializationContext.CurrentTextDefaultStyle != null && indentLevel < shapeSerializationContext.CurrentTextDefaultStyle.Levels.Count)
		{
			shapeSerializationContext.CurrentTextDefaultStyleLevel = shapeSerializationContext.CurrentTextDefaultStyle.Levels[indentLevel];
		}
	}

	public static void smethod_5(Class2974 paragraphFormat, Class201 shapeSerializationContext)
	{
		Class2974 @class = new Class2974();
		if (shapeSerializationContext.RelatedTextStyleLevel != null)
		{
			paragraphFormat.vmethod_0(shapeSerializationContext.RelatedTextStyleLevel.ParagraphFormat);
			@class.vmethod_0(shapeSerializationContext.RelatedTextStyleLevel.ParagraphFormat);
		}
		if (shapeSerializationContext.CurrentTextMasterStyleLevel != null)
		{
			@class.vmethod_0(shapeSerializationContext.CurrentTextMasterStyleLevel.ParagraphFormat);
		}
		if (shapeSerializationContext.CurrentTextDefaultStyleLevel != null)
		{
			@class.vmethod_0(shapeSerializationContext.CurrentTextDefaultStyleLevel.ParagraphFormat);
		}
		paragraphFormat.vmethod_1(@class);
	}

	public static void smethod_6(Class2971 charFormat, Class2894 relatedTextMasterStyleAtom, Class201 shapeSerializationContext, int indentLevel)
	{
		Class2971 @class = new Class2971();
		if (shapeSerializationContext.RelatedTextStyleLevel != null)
		{
			charFormat.method_3(shapeSerializationContext.RelatedTextStyleLevel.CharFormat);
			@class.method_3(shapeSerializationContext.RelatedTextStyleLevel.CharFormat);
		}
		if (shapeSerializationContext.CurrentTextMasterStyleLevel != null)
		{
			@class.method_3(shapeSerializationContext.CurrentTextMasterStyleLevel.CharFormat);
		}
		if (shapeSerializationContext.CurrentTextDefaultStyleLevel != null)
		{
			@class.method_3(shapeSerializationContext.CurrentTextDefaultStyleLevel.CharFormat);
		}
		charFormat.vmethod_0(@class);
	}

	internal static Class2894 smethod_7(ITextStyle domTextStyle, Class856 pptSerializationContext)
	{
		if (domTextStyle == null)
		{
			return null;
		}
		Class2894 @class = new Class2894();
		if (((TextStyle)domTextStyle).nullable_0.HasValue)
		{
			@class.Header.Instance = (short)((TextStyle)domTextStyle).nullable_0.Value;
		}
		for (int i = 0; i < 5; i++)
		{
			IParagraphFormat level = domTextStyle.GetLevel(i);
			if (level == null)
			{
				break;
			}
			IPortionFormat defaultPortionFormat = level.DefaultPortionFormat;
			Class2987 class2 = new Class2987((ushort)i);
			@class.Levels.Add(class2);
			smethod_1(level, class2.ParagraphFormat, pptSerializationContext);
			smethod_3(defaultPortionFormat, class2.CharFormat, pptSerializationContext);
		}
		if (@class.Levels.Count < 1)
		{
			return null;
		}
		return @class;
	}

	internal static void smethod_8(Class2894 textMasterStyleAtom)
	{
		if (textMasterStyleAtom != null)
		{
			for (int num = textMasterStyleAtom.Levels.Count; num > 1; num--)
			{
				textMasterStyleAtom.Levels[num - 1].method_1(textMasterStyleAtom.Levels[num - 2]);
			}
		}
	}

	internal static void smethod_9(Class2894 destTextMasterStyleAtom, ITextStyle domTextStyle, Class856 pptSerializationContext)
	{
		if (destTextMasterStyleAtom != null)
		{
			_ = destTextMasterStyleAtom.presetStyle;
			Class2894 @class = smethod_7(domTextStyle, pptSerializationContext);
			if (@class != null)
			{
				destTextMasterStyleAtom.Levels.Clear();
				destTextMasterStyleAtom.Levels.AddRange(@class.Levels);
				destTextMasterStyleAtom.presetStyle = false;
			}
			if (destTextMasterStyleAtom.Levels.Count > 0 && destTextMasterStyleAtom.Instance < 5)
			{
				destTextMasterStyleAtom.Levels[0].CharFormat.IncludeUnusedFlags = true;
			}
		}
	}

	internal static ParagraphFormat smethod_10(TextStyle textStyle, Class2974 textPFException, Class2971 textCFException, Class857 deserializationContext)
	{
		ParagraphFormat paragraphFormat = new ParagraphFormat(textStyle.Parent);
		smethod_0(textPFException, paragraphFormat, Class53.smethod_2(deserializationContext));
		PortionFormat resultPortionFormat = (PortionFormat)((IParagraphFormat)paragraphFormat).DefaultPortionFormat;
		smethod_2(textCFException, resultPortionFormat, Class53.smethod_2(deserializationContext));
		return paragraphFormat;
	}

	internal static FontAlignment smethod_11(Enum380 pptFontAlignment)
	{
		return pptFontAlignment switch
		{
			Enum380.const_0 => FontAlignment.Baseline, 
			Enum380.const_1 => FontAlignment.Top, 
			Enum380.const_2 => FontAlignment.Center, 
			Enum380.const_3 => FontAlignment.Bottom, 
			_ => FontAlignment.Automatic, 
		};
	}

	internal static Enum380 smethod_12(FontAlignment domFontAlignment)
	{
		return domFontAlignment switch
		{
			FontAlignment.Default => Enum380.const_0, 
			FontAlignment.Automatic => Enum380.const_0, 
			FontAlignment.Top => Enum380.const_1, 
			FontAlignment.Center => Enum380.const_2, 
			FontAlignment.Bottom => Enum380.const_3, 
			FontAlignment.Baseline => Enum380.const_0, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	internal static TabAlignment smethod_13(Enum456 textTabType)
	{
		if ((uint)textTabType > 3u)
		{
			throw new ArgumentOutOfRangeException();
		}
		return (TabAlignment)textTabType;
	}

	internal static Enum456 smethod_14(TabAlignment domTabAlignment)
	{
		if ((uint)domTabAlignment > 3u)
		{
			throw new ArgumentOutOfRangeException();
		}
		return (Enum456)domTabAlignment;
	}

	internal static float smethod_15(short value)
	{
		if (value >= 0)
		{
			return value;
		}
		return (float)value / 8f;
	}

	internal static short smethod_16(float value)
	{
		return (short)((value < 0f) ? (value * 8f) : value);
	}

	internal static float smethod_17(short value)
	{
		return (float)value / 8f;
	}

	internal static short smethod_18(float value)
	{
		return (short)(value * 8f);
	}

	internal static void smethod_19(Class863 data)
	{
		bool hasValue = data.nullable_0.HasValue;
		bool hasValue2 = data.nullable_1.HasValue;
		if (hasValue)
		{
			if (hasValue2)
			{
				data.float_0 = smethod_17(data.nullable_0.Value);
				data.float_1 = smethod_17(data.nullable_1.Value) - data.float_0;
			}
			else
			{
				data.float_0 = smethod_17(data.nullable_0.Value);
				data.float_1 = 0f - data.float_0;
			}
		}
		else if (hasValue2)
		{
			data.float_0 = 0f;
			data.float_1 = 0f - smethod_17(data.nullable_1.Value);
		}
		else
		{
			data.float_0 = float.NaN;
			data.float_1 = float.NaN;
		}
	}

	internal static void smethod_20(Class863 data)
	{
		bool flag = !float.IsNaN(data.float_0);
		bool flag2 = !float.IsNaN(data.float_1);
		if (flag)
		{
			if (flag2)
			{
				data.nullable_0 = smethod_18(data.float_0);
				data.nullable_1 = (short)(data.nullable_0.Value + smethod_18(data.float_1));
			}
			else
			{
				data.nullable_0 = smethod_18(data.float_0);
				data.nullable_1 = data.nullable_0;
			}
		}
		else if (flag2)
		{
			if (data.float_1 < 0f)
			{
				data.nullable_1 = smethod_18(0f - data.float_1);
			}
			data.nullable_1 = smethod_18(data.float_1);
			data.nullable_0 = 0;
		}
		else
		{
			data.nullable_0 = null;
			data.nullable_1 = null;
		}
	}
}
