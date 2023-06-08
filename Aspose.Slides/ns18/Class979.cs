using System;
using Aspose.Slides;
using ns16;
using ns24;
using ns4;
using ns56;

namespace ns18;

internal class Class979
{
	internal static readonly PortionFormat portionFormat_0 = new PortionFormat((Portion)null);

	public static void smethod_0(IPortionFormat portionFormat, Class1953 textCharPropsElementData, Class1341 deserializationContext)
	{
		if (textCharPropsElementData == null)
		{
			return;
		}
		Class349 pPTXUnsupportedProps = ((PortionFormat)portionFormat).PPTXUnsupportedProps;
		Class968.smethod_0(portionFormat.LineFormat, textCharPropsElementData.Ln);
		Class949.smethod_0(portionFormat.FillFormat, textCharPropsElementData.FillProperties, deserializationContext);
		Class939.smethod_0(portionFormat.EffectFormat, textCharPropsElementData.EffectProperties, deserializationContext);
		Class930.smethod_0(portionFormat.HighlightColor, textCharPropsElementData.Highlight);
		portionFormat.IsHardUnderlineLine = NullableBool.NotDefined;
		if (textCharPropsElementData.TextUnderlineLine != null)
		{
			switch (textCharPropsElementData.TextUnderlineLine.Name)
			{
			case "uLn":
			{
				Class1875 linePropertiesElementData = (Class1875)textCharPropsElementData.TextUnderlineLine.Object;
				Class968.smethod_0(portionFormat.UnderlineLineFormat, linePropertiesElementData);
				portionFormat.IsHardUnderlineLine = NullableBool.True;
				break;
			}
			case "uLnTx":
				portionFormat.IsHardUnderlineLine = NullableBool.False;
				break;
			default:
				throw new Exception("Unknown element \"" + textCharPropsElementData.TextUnderlineLine.Name + "\"");
			}
		}
		portionFormat.IsHardUnderlineFill = NullableBool.NotDefined;
		if (textCharPropsElementData.TextUnderlineFill != null)
		{
			switch (textCharPropsElementData.TextUnderlineFill.Name)
			{
			case "uFill":
			{
				Class1971 @class = (Class1971)textCharPropsElementData.TextUnderlineFill.Object;
				Class949.smethod_0(portionFormat.UnderlineFillFormat, @class.FillProperties, deserializationContext);
				portionFormat.IsHardUnderlineFill = NullableBool.True;
				break;
			}
			case "uFillTx":
				portionFormat.IsHardUnderlineFill = NullableBool.False;
				break;
			default:
				throw new Exception("Unknown element \"" + textCharPropsElementData.TextUnderlineFill.Name + "\"");
			}
		}
		portionFormat.Kumimoji = textCharPropsElementData.Kumimoji;
		portionFormat.LanguageId = textCharPropsElementData.Lang;
		portionFormat.AlternativeLanguageId = textCharPropsElementData.AltLang;
		portionFormat.FontHeight = textCharPropsElementData.Sz;
		portionFormat.FontBold = textCharPropsElementData.B;
		portionFormat.FontItalic = textCharPropsElementData.I;
		portionFormat.FontUnderline = textCharPropsElementData.U;
		portionFormat.StrikethroughType = textCharPropsElementData.Strike;
		portionFormat.KerningMinimalSize = textCharPropsElementData.Kern;
		portionFormat.TextCapType = textCharPropsElementData.Cap;
		portionFormat.Spacing = textCharPropsElementData.Spc;
		portionFormat.NormaliseHeight = textCharPropsElementData.NormalizeH;
		portionFormat.Escapement = textCharPropsElementData.Baseline;
		portionFormat.ProofDisabled = textCharPropsElementData.NoProof;
		portionFormat.SmartTagClean = textCharPropsElementData.SmtClean;
		pPTXUnsupportedProps.SmartTagId = textCharPropsElementData.SmtId;
		portionFormat.BookmarkId = textCharPropsElementData.Bmk;
		Class53.smethod_4(deserializationContext);
		if (textCharPropsElementData.Latin != null)
		{
			IFontData fontData = new FontData();
			Class950.smethod_0(fontData, textCharPropsElementData.Latin);
			portionFormat.LatinFont = fontData;
		}
		if (textCharPropsElementData.Ea != null)
		{
			IFontData fontData2 = new FontData();
			Class950.smethod_0(fontData2, textCharPropsElementData.Ea);
			portionFormat.EastAsianFont = fontData2;
		}
		if (textCharPropsElementData.Cs != null)
		{
			IFontData fontData3 = new FontData();
			Class950.smethod_0(fontData3, textCharPropsElementData.Cs);
			portionFormat.ComplexScriptFont = fontData3;
		}
		if (textCharPropsElementData.Sym != null)
		{
			Class950.smethod_0(((PortionFormat)portionFormat).method_1(), textCharPropsElementData.Sym);
		}
		Class964.smethod_0(portionFormat, textCharPropsElementData.HlinkClick, textCharPropsElementData.HlinkMouseOver, deserializationContext);
	}

	public static void smethod_1(IPortionFormat portionFormat, Class1953.Delegate1726 addRPr, Class1346 serializationContext)
	{
		Class349 pPTXUnsupportedProps = ((PortionFormat)portionFormat).PPTXUnsupportedProps;
		if (portionFormat != null && !portionFormat.Equals(portionFormat_0))
		{
			Class1953 @class = addRPr();
			Class968.smethod_2(portionFormat.LineFormat, @class.delegate1504_0);
			Class949.smethod_1(portionFormat.FillFormat, @class.delegate2773_1, serializationContext);
			Class939.smethod_1(portionFormat.EffectFormat, @class.delegate2773_0, serializationContext);
			Class930.smethod_2(portionFormat.HighlightColor, @class.delegate1321_0);
			switch (portionFormat.IsHardUnderlineLine)
			{
			default:
				throw new Exception();
			case NullableBool.False:
				@class.delegate2773_3("uLnTx");
				break;
			case NullableBool.True:
			{
				Class1875 linePropertiesElementData = (Class1875)@class.delegate2773_3("uLn").Object;
				Class968.smethod_3(portionFormat.UnderlineLineFormat, linePropertiesElementData);
				break;
			}
			case NullableBool.NotDefined:
				break;
			}
			switch (portionFormat.IsHardUnderlineFill)
			{
			default:
				throw new Exception();
			case NullableBool.False:
				@class.delegate2773_2("uFillTx");
				break;
			case NullableBool.True:
			{
				Class1971 class2 = (Class1971)@class.delegate2773_2("uFill").Object;
				Class949.smethod_1(portionFormat.UnderlineFillFormat, class2.delegate2773_0, serializationContext);
				break;
			}
			case NullableBool.NotDefined:
				break;
			}
			@class.Kumimoji = portionFormat.Kumimoji;
			@class.Lang = portionFormat.LanguageId;
			@class.AltLang = portionFormat.AlternativeLanguageId;
			@class.Sz = portionFormat.FontHeight;
			@class.B = portionFormat.FontBold;
			@class.I = portionFormat.FontItalic;
			@class.U = portionFormat.FontUnderline;
			@class.Strike = portionFormat.StrikethroughType;
			@class.Kern = portionFormat.KerningMinimalSize;
			@class.Cap = portionFormat.TextCapType;
			@class.Spc = portionFormat.Spacing;
			@class.NormalizeH = portionFormat.NormaliseHeight;
			@class.Baseline = portionFormat.Escapement;
			@class.NoProof = portionFormat.ProofDisabled;
			@class.SmtClean = portionFormat.SmartTagClean;
			@class.SmtId = pPTXUnsupportedProps.SmartTagId;
			@class.Bmk = portionFormat.BookmarkId;
			Class950.smethod_3(portionFormat.LatinFont, @class.delegate1735_0);
			Class950.smethod_3(portionFormat.EastAsianFont, @class.delegate1735_1);
			Class950.smethod_3(portionFormat.ComplexScriptFont, @class.delegate1735_2);
			Class950.smethod_3(portionFormat.SymbolFont, @class.delegate1735_3);
			Class964.smethod_2(portionFormat, @class.delegate1474_0, @class.delegate1474_1, serializationContext);
		}
	}
}
