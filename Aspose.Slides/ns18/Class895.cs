using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class895
{
	public static void smethod_0(IAutoShape autoShape, Class2011 shapeElementData, Class1030 slideDeserializationContext)
	{
		if (shapeElementData != null)
		{
			Class285 pPTXUnsupportedProps = ((AutoShape)autoShape).PPTXUnsupportedProps;
			if (shapeElementData is Class2014)
			{
				autoShape.UseBackgroundFill = shapeElementData.UseBgFill;
			}
			else if (shapeElementData is Class2012)
			{
				shapeElementData.NvSpPr.CNvPr.Id = 0u;
				pPTXUnsupportedProps.Macro = shapeElementData.Macro;
				pPTXUnsupportedProps.Textlink = shapeElementData.Textlink;
				pPTXUnsupportedProps.FLocksText = shapeElementData.FLocksText;
				pPTXUnsupportedProps.FPublished = shapeElementData.FPublished;
			}
			else if (shapeElementData is Class2013)
			{
				pPTXUnsupportedProps.ModelId = shapeElementData.ModelId;
				pPTXUnsupportedProps.TxXfrm = shapeElementData.TxXfrm;
			}
			Class956.smethod_0(autoShape, shapeElementData.SpPr, slideDeserializationContext.DeserializationContext);
			Class2015 nvSpPr = shapeElementData.NvSpPr;
			Class983.smethod_1(autoShape, nvSpPr.NvPr, slideDeserializationContext);
			Class983.smethod_2(autoShape, nvSpPr.CNvPr, slideDeserializationContext);
			Class1881 cNvSpPr = nvSpPr.CNvSpPr;
			Class894.smethod_0(autoShape.ShapeLock, cNvSpPr.SpLocks);
			Class984.smethod_0(autoShape, shapeElementData.Style);
			pPTXUnsupportedProps.ExtensionListOfNonVisualDrawingShapeProps = cNvSpPr.ExtLst;
			autoShape.AddTextFrame("");
			Class1002.smethod_0(autoShape.TextFrame, shapeElementData.TxBody, slideDeserializationContext.DeserializationContext);
			pPTXUnsupportedProps.IsTextBox = cNvSpPr.TxBox;
			pPTXUnsupportedProps.ExtensionList = shapeElementData.ExtLst;
			((AutoShape)autoShape).method_26();
		}
	}

	public static void smethod_1(IAutoShape autoShape, Class2011 shapeElementData, Class1031 slideSerializationContext, Class882 chartPartSerializationContext)
	{
		Class285 pPTXUnsupportedProps = ((AutoShape)autoShape).PPTXUnsupportedProps;
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		if (shapeElementData is Class2014)
		{
			shapeElementData.UseBgFill = autoShape.UseBackgroundFill;
			shapeElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
		else if (shapeElementData is Class2012)
		{
			pPTXUnsupportedProps.ShapeId = chartPartSerializationContext.method_0();
			shapeElementData.Macro = pPTXUnsupportedProps.Macro;
			shapeElementData.Textlink = pPTXUnsupportedProps.Textlink;
			shapeElementData.FLocksText = pPTXUnsupportedProps.FLocksText;
			shapeElementData.FPublished = pPTXUnsupportedProps.FPublished;
		}
		else if (shapeElementData is Class2013)
		{
			shapeElementData.ModelId = pPTXUnsupportedProps.ModelId;
			shapeElementData.delegate1797_0(pPTXUnsupportedProps.TxXfrm);
			shapeElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
		if (autoShape.TextFrame != null && autoShape.TextFrame.TextFrameFormat.AutofitType == TextAutofitType.Normal)
		{
			((AutoShape)autoShape).method_29();
		}
		Class2015 nvSpPr = shapeElementData.NvSpPr;
		Class983.smethod_6(autoShape, nvSpPr.NvPr, serializationContext);
		Class983.smethod_7(autoShape, nvSpPr.CNvPr, serializationContext);
		Class1881 cNvSpPr = nvSpPr.CNvSpPr;
		Class894.smethod_1(autoShape.ShapeLock, cNvSpPr.delegate1627_0);
		cNvSpPr.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfNonVisualDrawingShapeProps);
		Class984.smethod_1(autoShape.ShapeStyle, shapeElementData.delegate1633_0);
		if (autoShape.Placeholder == null || autoShape.Placeholder.Type != PlaceholderType.SlideImage)
		{
			Class1002.smethod_1(autoShape.TextFrame, shapeElementData.delegate1705_0, serializationContext);
		}
		Class956.smethod_1(autoShape, shapeElementData.SpPr, serializationContext);
		cNvSpPr.TxBox = pPTXUnsupportedProps.IsTextBox;
	}
}
