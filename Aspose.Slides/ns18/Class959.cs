using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class959
{
	public static void smethod_0(IGraphicalObject graphicalObject, Class1989 graphicFrameElementData, Class1030 slideDeserializationContext)
	{
		if (graphicFrameElementData != null)
		{
			smethod_1(graphicalObject, graphicFrameElementData);
			Class1992 nvGraphicFramePr = graphicFrameElementData.NvGraphicFramePr;
			Class983.smethod_1(graphicalObject, nvGraphicFramePr.NvPr, slideDeserializationContext);
			Class983.smethod_2(graphicalObject, nvGraphicFramePr.CNvPr, slideDeserializationContext);
			Class1882 cNvGraphicFramePr = nvGraphicFramePr.CNvGraphicFramePr;
			Class958.smethod_0(graphicalObject.ShapeLock, cNvGraphicFramePr.GraphicFrameLocks);
		}
	}

	private static void smethod_1(IGraphicalObject graphicalObject, Class1989 graphicFrameElementData)
	{
		Class287 pPTXUnsupportedProps = ((GraphicalObject)graphicalObject).PPTXUnsupportedProps;
		Class1021.smethod_1(((GraphicalObject)graphicalObject).RawFrameImpl, graphicFrameElementData.Xfrm);
		Class1882 cNvGraphicFramePr = graphicFrameElementData.NvGraphicFramePr.CNvGraphicFramePr;
		pPTXUnsupportedProps.ExtensionListOfNonVisualGraphicObjProps = cNvGraphicFramePr.ExtLst;
		pPTXUnsupportedProps.ExtensionList = graphicFrameElementData.ExtLst;
	}

	public static void smethod_2(IGraphicalObject graphicalObject, Class1989 graphicFrameElementData, Class1346 serializationContext)
	{
		Class1992 nvGraphicFramePr = graphicFrameElementData.NvGraphicFramePr;
		Class983.smethod_6(graphicalObject, nvGraphicFramePr.NvPr, serializationContext);
		Class983.smethod_7(graphicalObject, nvGraphicFramePr.CNvPr, serializationContext);
		Class1882 cNvGraphicFramePr = nvGraphicFramePr.CNvGraphicFramePr;
		Class958.smethod_1(graphicalObject.ShapeLock, cNvGraphicFramePr.delegate1447_0);
		smethod_3(graphicalObject, graphicFrameElementData);
	}

	private static void smethod_3(IGraphicalObject graphicalObject, Class1989 graphicFrameElementData)
	{
		Class287 pPTXUnsupportedProps = ((GraphicalObject)graphicalObject).PPTXUnsupportedProps;
		if (graphicFrameElementData is Class1991)
		{
			graphicFrameElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
		Class1021.smethod_4((GraphicalObject)graphicalObject, graphicFrameElementData.Xfrm);
		Class1882 cNvGraphicFramePr = graphicFrameElementData.NvGraphicFramePr.CNvGraphicFramePr;
		cNvGraphicFramePr.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfNonVisualGraphicObjProps);
	}
}
