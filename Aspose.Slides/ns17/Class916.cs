using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns18;
using ns24;
using ns4;
using ns56;

namespace ns17;

internal class Class916
{
	private static readonly TextFrameFormat textFrameFormat_0 = new TextFrameFormat(null);

	private static readonly ParagraphFormat paragraphFormat_0 = new ParagraphFormat(null);

	private static readonly ChartPortionFormat chartPortionFormat_0 = new ChartPortionFormat(null);

	public static void smethod_0(IChartTextFormat textProps, Class1946 txPrElementData, Class1341 deserializationContext)
	{
		if (txPrElementData != null)
		{
			smethod_1(textProps.TextBlockFormat, txPrElementData.BodyPr);
			smethod_2(textProps.ParagraphFormat, txPrElementData.PList[0]);
			if (txPrElementData.PList[0].PPr != null)
			{
				smethod_4(textProps.PortionFormat, txPrElementData.PList[0].PPr.DefRPr, deserializationContext);
			}
		}
	}

	private static void smethod_1(IChartTextBlockFormat textBlockProps, Class1947 bodyPrElementData)
	{
		textBlockProps.TextVerticalType = bodyPrElementData.Vert;
		textBlockProps.AnchoringType = bodyPrElementData.Anchor;
		textBlockProps.CenterText = bodyPrElementData.AnchorCtr;
		Class356 pPTXUnsupportedProps = ((TextFrameFormat)textBlockProps).PPTXUnsupportedProps;
		pPTXUnsupportedProps.RotationAngle = bodyPrElementData.Rot;
		pPTXUnsupportedProps.FirstLastParagraphSpacing = bodyPrElementData.SpcFirstLastPara;
		pPTXUnsupportedProps.TextHorizontalOverflowType = bodyPrElementData.HorzOverflow;
		pPTXUnsupportedProps.TextVerticalOverflowType = bodyPrElementData.VertOverflow;
		pPTXUnsupportedProps.ForceAntiAliased = bodyPrElementData.ForceAA;
		pPTXUnsupportedProps.CompatibleLineSpacing = bodyPrElementData.CompatLnSpc;
		pPTXUnsupportedProps.ExtensionList = bodyPrElementData.ExtLst;
	}

	private static void smethod_2(IChartParagraphFormat paragraphProps, Class1962 pElementData)
	{
		Class1963 pPr = pElementData.PPr;
		if (pElementData == null || pPr == null)
		{
			return;
		}
		paragraphProps.SpaceWithin = smethod_3(pPr.LnSpc);
		paragraphProps.SpaceBefore = smethod_3(pPr.SpcBef);
		paragraphProps.SpaceAfter = smethod_3(pPr.SpcAft);
		if (pPr.TabLst != null)
		{
			Class1968[] tabList = pPr.TabLst.TabList;
			foreach (Class1968 @class in tabList)
			{
				paragraphProps.Tabs.Add(double.IsNaN(@class.Pos) ? 0.0 : @class.Pos, @class.Algn);
			}
		}
		switch (pPr.Algn)
		{
		case Enum313.const_0:
			paragraphProps.Alignment = TextAlignment.NotDefined;
			break;
		default:
			paragraphProps.Alignment = TextAlignment.Left;
			break;
		case Enum313.const_2:
			paragraphProps.Alignment = TextAlignment.Center;
			break;
		case Enum313.const_3:
			paragraphProps.Alignment = TextAlignment.Right;
			break;
		case Enum313.const_4:
			paragraphProps.Alignment = TextAlignment.Justify;
			break;
		}
		paragraphProps.MarginLeft = (float)pPr.MarL;
		paragraphProps.MarginRight = (float)pPr.MarR;
		paragraphProps.Indent = (float)pPr.Indent;
		paragraphProps.DefaultTabSize = (float)pPr.DefTabSz;
		paragraphProps.FontAlignment = pPr.FontAlgn;
		paragraphProps.RightToLeft = pPr.Rtl;
		paragraphProps.EastAsianLineBreak = pPr.EaLnBrk;
		paragraphProps.LatinLineBreak = pPr.LatinLnBrk;
		paragraphProps.HangingPunctuation = pPr.HangingPunct;
		((ParagraphFormat)paragraphProps).PPTXUnsupportedProps.EndParaRPr = pElementData.EndParaRPr;
	}

	private static float smethod_3(Class1965 textSpacingElementData)
	{
		if (textSpacingElementData != null && textSpacingElementData.TextSpacing != null)
		{
			Class2605 textSpacing = textSpacingElementData.TextSpacing;
			switch (textSpacing.Name)
			{
			case "spcPts":
			{
				Class1967 class2 = (Class1967)textSpacing.Object;
				if (!float.IsNaN(class2.Val))
				{
					return 0f - class2.Val;
				}
				return -12f;
			}
			case "spcPct":
			{
				Class1966 @class = (Class1966)textSpacing.Object;
				if (!float.IsNaN(@class.Val))
				{
					return @class.Val;
				}
				return 100f;
			}
			default:
				throw new Exception("Unknown element \"" + textSpacing.Name + "\"");
			}
		}
		return float.NaN;
	}

	private static void smethod_4(IChartPortionFormat portionProps, Class1953 textCharPropsElementData, Class1341 deserializationContext)
	{
		if (textCharPropsElementData == null)
		{
			return;
		}
		Class968.smethod_0(portionProps.LineFormat, textCharPropsElementData.Ln);
		Class949.smethod_0(portionProps.FillFormat, textCharPropsElementData.FillProperties, deserializationContext);
		Class939.smethod_0(portionProps.EffectFormat, textCharPropsElementData.EffectProperties, deserializationContext);
		Class930.smethod_0(portionProps.HighlightColor, textCharPropsElementData.Highlight);
		portionProps.IsHardUnderlineLine = NullableBool.NotDefined;
		if (textCharPropsElementData.TextUnderlineLine != null)
		{
			switch (textCharPropsElementData.TextUnderlineLine.Name)
			{
			case "uLn":
			{
				Class1875 linePropertiesElementData = (Class1875)textCharPropsElementData.TextUnderlineLine.Object;
				Class968.smethod_0(portionProps.UnderlineLineFormat, linePropertiesElementData);
				portionProps.IsHardUnderlineLine = NullableBool.True;
				break;
			}
			case "uLnTx":
				portionProps.IsHardUnderlineLine = NullableBool.False;
				break;
			default:
				throw new Exception("Unknown element \"" + textCharPropsElementData.TextUnderlineLine.Name + "\"");
			}
		}
		portionProps.IsHardUnderlineFill = NullableBool.NotDefined;
		if (textCharPropsElementData.TextUnderlineLine != null)
		{
			switch (textCharPropsElementData.TextUnderlineFill.Name)
			{
			case "uFill":
			{
				Class1971 @class = (Class1971)textCharPropsElementData.TextUnderlineFill.Object;
				Class949.smethod_0(portionProps.UnderlineFillFormat, @class.FillProperties, deserializationContext);
				portionProps.IsHardUnderlineFill = NullableBool.True;
				break;
			}
			case "uFillTx":
				portionProps.IsHardUnderlineFill = NullableBool.False;
				break;
			default:
				throw new Exception("Unknown element \"" + textCharPropsElementData.TextUnderlineFill.Name + "\"");
			}
		}
		portionProps.Kumimoji = textCharPropsElementData.Kumimoji;
		portionProps.LanguageId = textCharPropsElementData.Lang;
		portionProps.AlternativeLanguageId = textCharPropsElementData.AltLang;
		portionProps.FontHeight = textCharPropsElementData.Sz;
		portionProps.FontBold = textCharPropsElementData.B;
		portionProps.FontItalic = textCharPropsElementData.I;
		portionProps.FontUnderline = textCharPropsElementData.U;
		portionProps.StrikethroughType = textCharPropsElementData.Strike;
		portionProps.KerningMinimalSize = textCharPropsElementData.Kern;
		portionProps.TextCapType = textCharPropsElementData.Cap;
		portionProps.Spacing = textCharPropsElementData.Spc;
		portionProps.NormaliseHeight = textCharPropsElementData.NormalizeH;
		portionProps.Escapement = textCharPropsElementData.Baseline;
		portionProps.ProofDisabled = textCharPropsElementData.NoProof;
		Class349 pPTXUnsupportedProps = ((BasePortionFormat)portionProps).PPTXUnsupportedProps;
		pPTXUnsupportedProps.SmartTagId = textCharPropsElementData.SmtId;
		Class53.smethod_4(deserializationContext);
		if (textCharPropsElementData.Latin != null)
		{
			IFontData fontData = new FontData();
			Class950.smethod_0(fontData, textCharPropsElementData.Latin);
			portionProps.LatinFont = fontData;
		}
		if (textCharPropsElementData.Ea != null)
		{
			IFontData fontData2 = new FontData();
			Class950.smethod_0(fontData2, textCharPropsElementData.Ea);
			portionProps.EastAsianFont = fontData2;
		}
		if (textCharPropsElementData.Cs != null)
		{
			IFontData fontData3 = new FontData();
			Class950.smethod_0(fontData3, textCharPropsElementData.Cs);
			portionProps.ComplexScriptFont = fontData3;
		}
		if (textCharPropsElementData.Sym != null)
		{
			Class950.smethod_0(((BasePortionFormat)portionProps).method_1(), textCharPropsElementData.Sym);
		}
	}

	public static void smethod_5(IChartTextFormat textProps, Class1946.Delegate1705 addTxPr, Class1346 serializationContext)
	{
		if (smethod_10(textProps))
		{
			Class1946 @class = addTxPr();
			smethod_6(textProps.TextBlockFormat, @class.BodyPr);
			smethod_7(textProps.ParagraphFormat, @class.delegate1753_0());
			smethod_9(textProps.PortionFormat, @class, serializationContext);
		}
	}

	private static void smethod_6(IChartTextBlockFormat textBlockProps, Class1947 bodyPrElementData)
	{
		bodyPrElementData.Vert = textBlockProps.TextVerticalType;
		bodyPrElementData.Anchor = textBlockProps.AnchoringType;
		bodyPrElementData.AnchorCtr = textBlockProps.CenterText;
		Class356 pPTXUnsupportedProps = ((TextFrameFormat)textBlockProps).PPTXUnsupportedProps;
		bodyPrElementData.Rot = pPTXUnsupportedProps.RotationAngle;
		bodyPrElementData.SpcFirstLastPara = pPTXUnsupportedProps.FirstLastParagraphSpacing;
		bodyPrElementData.HorzOverflow = pPTXUnsupportedProps.TextHorizontalOverflowType;
		bodyPrElementData.VertOverflow = pPTXUnsupportedProps.TextVerticalOverflowType;
		bodyPrElementData.ForceAA = pPTXUnsupportedProps.ForceAntiAliased;
		bodyPrElementData.CompatLnSpc = pPTXUnsupportedProps.CompatibleLineSpacing;
		bodyPrElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}

	private static void smethod_7(IChartParagraphFormat paragraphProps, Class1962 pElementData)
	{
		Class345 pPTXUnsupportedProps = ((ParagraphFormat)paragraphProps).PPTXUnsupportedProps;
		if (!smethod_12(paragraphProps) && pPTXUnsupportedProps.EndParaRPr == null)
		{
			return;
		}
		pElementData.delegate1728_0(pPTXUnsupportedProps.EndParaRPr);
		if (!smethod_12(paragraphProps))
		{
			return;
		}
		Class1963 @class = pElementData.delegate1756_0();
		smethod_8(paragraphProps.SpaceWithin, @class.delegate1762_0);
		smethod_8(paragraphProps.SpaceBefore, @class.delegate1762_1);
		smethod_8(paragraphProps.SpaceAfter, @class.delegate1762_2);
		if (paragraphProps.Tabs.Count > 0)
		{
			Class1969 class2 = @class.delegate1774_0();
			foreach (ITab tab in paragraphProps.Tabs)
			{
				Class1968 class3 = class2.delegate1771_0();
				class3.Algn = tab.Alignment;
				class3.Pos = tab.Position;
			}
		}
		switch (paragraphProps.Alignment)
		{
		case TextAlignment.NotDefined:
			@class.Algn = Enum313.const_0;
			break;
		default:
			@class.Algn = Enum313.const_1;
			break;
		case TextAlignment.Center:
			@class.Algn = Enum313.const_2;
			break;
		case TextAlignment.Right:
			@class.Algn = Enum313.const_3;
			break;
		case TextAlignment.Justify:
			@class.Algn = Enum313.const_4;
			break;
		}
		@class.MarL = paragraphProps.MarginLeft;
		@class.MarR = paragraphProps.MarginRight;
		@class.Indent = paragraphProps.Indent;
		@class.DefTabSz = paragraphProps.DefaultTabSize;
		@class.FontAlgn = paragraphProps.FontAlignment;
		@class.Rtl = paragraphProps.RightToLeft;
		@class.EaLnBrk = paragraphProps.EastAsianLineBreak;
		@class.LatinLnBrk = paragraphProps.LatinLineBreak;
		@class.HangingPunct = paragraphProps.HangingPunctuation;
	}

	private static void smethod_8(float spaceValue, Class1965.Delegate1762 addTextSpacing)
	{
		if (!float.IsNaN(spaceValue))
		{
			Class1965 @class = addTextSpacing();
			if (spaceValue < 0f)
			{
				Class1967 class2 = (Class1967)@class.delegate2773_0("spcPts").Object;
				class2.Val = 0f - spaceValue;
			}
			else
			{
				Class1966 class3 = (Class1966)@class.delegate2773_0("spcPct").Object;
				class3.Val = spaceValue;
			}
		}
	}

	private static void smethod_9(IChartPortionFormat portionProps, Class1946 txPrElementData, Class1346 serializationContext)
	{
		Class349 pPTXUnsupportedProps = ((BasePortionFormat)portionProps).PPTXUnsupportedProps;
		if (txPrElementData.PList.Length == 0)
		{
			txPrElementData.delegate1753_0();
		}
		if (txPrElementData.PList[0].PPr == null)
		{
			txPrElementData.PList[0].delegate1756_0();
		}
		Class1953 @class = txPrElementData.PList[0].PPr.delegate1726_0();
		if (!smethod_13(portionProps))
		{
			return;
		}
		Class968.smethod_2(portionProps.LineFormat, @class.delegate1504_0);
		Class949.smethod_1(portionProps.FillFormat, @class.delegate2773_1, serializationContext);
		Class939.smethod_1(portionProps.EffectFormat, @class.delegate2773_0, serializationContext);
		Class930.smethod_2(portionProps.HighlightColor, @class.delegate1321_0);
		if (portionProps.IsHardUnderlineLine != NullableBool.NotDefined)
		{
			if (portionProps.IsHardUnderlineLine == NullableBool.True)
			{
				Class1875 linePropertiesElementData = (Class1875)@class.delegate2773_3("uLn").Object;
				Class968.smethod_3(portionProps.UnderlineLineFormat, linePropertiesElementData);
			}
			else
			{
				@class.delegate2773_3("uLnTx");
			}
		}
		if (portionProps.IsHardUnderlineFill != NullableBool.NotDefined)
		{
			if (portionProps.IsHardUnderlineFill == NullableBool.True)
			{
				Class1971 class2 = (Class1971)@class.delegate2773_2("uFill").Object;
				Class949.smethod_1(portionProps.UnderlineFillFormat, class2.delegate2773_0, serializationContext);
			}
			else
			{
				@class.delegate2773_2("uFillTx");
			}
		}
		@class.Kumimoji = portionProps.Kumimoji;
		@class.Lang = portionProps.LanguageId;
		@class.AltLang = portionProps.AlternativeLanguageId;
		@class.Sz = portionProps.FontHeight;
		@class.B = portionProps.FontBold;
		@class.I = portionProps.FontItalic;
		@class.U = portionProps.FontUnderline;
		@class.Strike = portionProps.StrikethroughType;
		@class.Kern = portionProps.KerningMinimalSize;
		@class.Cap = portionProps.TextCapType;
		@class.Spc = portionProps.Spacing;
		@class.NormalizeH = portionProps.NormaliseHeight;
		@class.Baseline = portionProps.Escapement;
		@class.NoProof = portionProps.ProofDisabled;
		@class.SmtId = pPTXUnsupportedProps.SmartTagId;
		Class950.smethod_3(portionProps.LatinFont, @class.delegate1735_0);
		Class950.smethod_3(portionProps.EastAsianFont, @class.delegate1735_1);
		Class950.smethod_3(portionProps.ComplexScriptFont, @class.delegate1735_2);
		Class950.smethod_3(portionProps.SymbolFont, @class.delegate1735_3);
	}

	internal static bool smethod_10(IChartTextFormat textProps)
	{
		if (!smethod_11(textProps.TextBlockFormat) && !smethod_12(textProps.ParagraphFormat) && !smethod_13(textProps.PortionFormat))
		{
			return ((ParagraphFormat)textProps.ParagraphFormat).PPTXUnsupportedProps.EndParaRPr != null;
		}
		return true;
	}

	internal static bool smethod_11(IChartTextBlockFormat textBlockFormat)
	{
		return !((TextFrameFormat)textBlockFormat).method_4(textFrameFormat_0);
	}

	internal static bool smethod_12(IChartParagraphFormat textProps)
	{
		return !((ParagraphFormat)textProps).method_2(paragraphFormat_0);
	}

	internal static bool smethod_13(IChartPortionFormat textProps)
	{
		return !textProps.Equals(chartPortionFormat_0);
	}
}
