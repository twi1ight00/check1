using System;
using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class1002
{
	public static void smethod_0(ITextFrame textFrame, Class1946 textBodyElementData, Class1341 deserializationContext)
	{
		if (textBodyElementData == null)
		{
			return;
		}
		Class1947 bodyPr = textBodyElementData.BodyPr;
		Class356 pPTXUnsupportedProps = ((TextFrame)textFrame).textFrameFormat_0.PPTXUnsupportedProps;
		pPTXUnsupportedProps.TextHorizontalOverflowType = bodyPr.HorzOverflow;
		Class980.smethod_0(pPTXUnsupportedProps.TextShape, bodyPr.PrstTxWarp);
		pPTXUnsupportedProps.RightToLeftColumns = bodyPr.RtlCol;
		pPTXUnsupportedProps.RotationAngle = bodyPr.Rot;
		pPTXUnsupportedProps.FirstLastParagraphSpacing = bodyPr.SpcFirstLastPara;
		pPTXUnsupportedProps.TextVerticalOverflowType = bodyPr.VertOverflow;
		pPTXUnsupportedProps.ColumnCount = bodyPr.NumCol;
		pPTXUnsupportedProps.ColumnSpacing = bodyPr.SpcCol;
		pPTXUnsupportedProps.FromWordArt = bodyPr.FromWordArt;
		pPTXUnsupportedProps.ForceAntiAliased = bodyPr.ForceAA;
		pPTXUnsupportedProps.RemainUpright = bodyPr.Upright;
		pPTXUnsupportedProps.CompatibleLineSpacing = bodyPr.CompatLnSpc;
		pPTXUnsupportedProps.Scene3d = bodyPr.Scene3d;
		pPTXUnsupportedProps.Text3DFormat = bodyPr.Text3D;
		if (bodyPr.Wrap != 0)
		{
			pPTXUnsupportedProps.Wrap = ((bodyPr.Wrap == Enum314.const_2) ? NullableBool.True : NullableBool.False);
		}
		pPTXUnsupportedProps.ExtensionList = bodyPr.ExtLst;
		ITextFrameFormat textFrameFormat = textFrame.TextFrameFormat;
		((TextFrameFormat)textFrameFormat).AutofitTypeInternal = TextAutofitType.NotDefined;
		if (bodyPr.TextAutofit != null)
		{
			switch (bodyPr.TextAutofit.Name)
			{
			case "spAutoFit":
				((TextFrameFormat)textFrameFormat).AutofitTypeInternal = TextAutofitType.Shape;
				break;
			case "normAutofit":
			{
				Class1961 @class = (Class1961)bodyPr.TextAutofit.Object;
				((TextFrameFormat)textFrameFormat).AutofitTypeInternal = TextAutofitType.Normal;
				pPTXUnsupportedProps.NormalAutofitFontScale = @class.FontScale / 100f;
				pPTXUnsupportedProps.NormalAutofitLineSpaceReduction = @class.LnSpcReduction / 100f;
				break;
			}
			case "noAutofit":
				((TextFrameFormat)textFrameFormat).AutofitTypeInternal = TextAutofitType.None;
				break;
			default:
				throw new Exception("Unknown element \"" + bodyPr.TextAutofit.Name + "\"");
			}
		}
		textFrameFormat.TextVerticalType = bodyPr.Vert;
		textFrameFormat.MarginLeft = bodyPr.LIns;
		textFrameFormat.MarginTop = bodyPr.TIns;
		textFrameFormat.MarginRight = bodyPr.RIns;
		textFrameFormat.MarginBottom = bodyPr.BIns;
		textFrameFormat.AnchoringType = bodyPr.Anchor;
		textFrameFormat.CenterText = bodyPr.AnchorCtr;
		Class1003.smethod_0(textFrameFormat.TextStyle, textBodyElementData.LstStyle, deserializationContext);
		Class970.smethod_0(textFrame.Paragraphs, textBodyElementData.PList, deserializationContext);
	}

	public static void smethod_1(ITextFrame textFrame, Class1946.Delegate1705 addTxBody, Class1346 serializationContext)
	{
		if (textFrame != null)
		{
			Class1946 textBodyElementData = addTxBody();
			smethod_2(textFrame, textBodyElementData, serializationContext);
		}
	}

	public static void smethod_2(ITextFrame textFrame, Class1946 textBodyElementData, Class1346 serializationContext)
	{
		if (textFrame != null)
		{
			Class1947 bodyPr = textBodyElementData.BodyPr;
			Class356 pPTXUnsupportedProps = ((TextFrame)textFrame).textFrameFormat_0.PPTXUnsupportedProps;
			switch (textFrame.TextFrameFormat.AutofitType)
			{
			default:
				throw new Exception();
			case TextAutofitType.None:
				bodyPr.delegate2773_1("noAutofit");
				break;
			case TextAutofitType.Normal:
			{
				Class1961 @class = (Class1961)bodyPr.delegate2773_1("normAutofit").Object;
				@class.FontScale = pPTXUnsupportedProps.NormalAutofitFontScale * 100f;
				@class.LnSpcReduction = pPTXUnsupportedProps.NormalAutofitLineSpaceReduction * 100f;
				break;
			}
			case TextAutofitType.Shape:
				bodyPr.delegate2773_1("spAutoFit");
				break;
			case TextAutofitType.NotDefined:
				break;
			}
			ITextFrameFormat textFrameFormat = textFrame.TextFrameFormat;
			bodyPr.Vert = textFrameFormat.TextVerticalType;
			bodyPr.LIns = textFrameFormat.MarginLeft;
			bodyPr.TIns = textFrameFormat.MarginTop;
			bodyPr.RIns = textFrameFormat.MarginRight;
			bodyPr.BIns = textFrameFormat.MarginBottom;
			bodyPr.Anchor = textFrameFormat.AnchoringType;
			bodyPr.AnchorCtr = textFrameFormat.CenterText;
			Class1003.smethod_1(textFrameFormat.TextStyle, textBodyElementData.delegate1741_0, serializationContext);
			Class970.smethod_1(textFrame.Paragraphs, textBodyElementData.delegate1753_0, serializationContext);
			bodyPr.Rot = pPTXUnsupportedProps.RotationAngle;
			bodyPr.HorzOverflow = pPTXUnsupportedProps.TextHorizontalOverflowType;
			Class980.smethod_1(pPTXUnsupportedProps.TextShape, bodyPr.delegate1600_0, serializationContext);
			bodyPr.RtlCol = pPTXUnsupportedProps.RightToLeftColumns;
			bodyPr.SpcFirstLastPara = pPTXUnsupportedProps.FirstLastParagraphSpacing;
			bodyPr.VertOverflow = pPTXUnsupportedProps.TextVerticalOverflowType;
			if (pPTXUnsupportedProps.ColumnCount > 1)
			{
				bodyPr.NumCol = pPTXUnsupportedProps.ColumnCount;
				bodyPr.SpcCol = pPTXUnsupportedProps.ColumnSpacing;
			}
			bodyPr.FromWordArt = pPTXUnsupportedProps.FromWordArt;
			bodyPr.ForceAA = pPTXUnsupportedProps.ForceAntiAliased;
			bodyPr.Upright = pPTXUnsupportedProps.RemainUpright;
			bodyPr.CompatLnSpc = pPTXUnsupportedProps.CompatibleLineSpacing;
			bodyPr.delegate1617_0(pPTXUnsupportedProps.Scene3d);
			bodyPr.Text3D = pPTXUnsupportedProps.Text3DFormat;
			if (pPTXUnsupportedProps.Wrap != NullableBool.NotDefined)
			{
				bodyPr.Wrap = ((pPTXUnsupportedProps.Wrap != NullableBool.True) ? Enum314.const_1 : Enum314.const_2);
			}
			bodyPr.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
	}
}
