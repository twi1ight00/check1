using Aspose.Slides;
using ns16;
using ns24;
using ns56;

namespace ns18;

internal class Class976
{
	public static void smethod_0(IPictureFrame pictureFrame, Class2004 picElementData, Class1030 slideDeserializationContext)
	{
		if (picElementData != null)
		{
			Class282 pPTXUnsupportedProps = ((PictureFrame)pictureFrame).PPTXUnsupportedProps;
			Class956.smethod_0(pictureFrame, picElementData.SpPr, slideDeserializationContext.DeserializationContext);
			Class974.smethod_0(pictureFrame.PictureFormat, picElementData.BlipFill, slideDeserializationContext.DeserializationContext);
			Class2007 nvPicPr = picElementData.NvPicPr;
			Class983.smethod_1(pictureFrame, nvPicPr.NvPr, slideDeserializationContext);
			Class983.smethod_2(pictureFrame, nvPicPr.CNvPr, slideDeserializationContext);
			Class1884 cNvPicPr = nvPicPr.CNvPicPr;
			Class975.smethod_0(pictureFrame.ShapeLock, cNvPicPr.PicLocks);
			Class984.smethod_0(pictureFrame, picElementData.Style);
			pPTXUnsupportedProps.ExtensionListOfNonVisualDrawingShapeProps = cNvPicPr.ExtLst;
			smethod_1(pictureFrame, picElementData);
		}
	}

	private static void smethod_1(IPictureFrame pictureFrame, Class2004 picElementData)
	{
		Class282 pPTXUnsupportedProps = ((PictureFrame)pictureFrame).PPTXUnsupportedProps;
		Class1884 cNvPicPr = picElementData.NvPicPr.CNvPicPr;
		pPTXUnsupportedProps.RelativeResizePreferred = cNvPicPr.PreferRelativeResize;
	}

	public static void smethod_2(IPictureFrame pictureFrame, Class2004 picElementData, Class1346 serializationContext)
	{
		Class282 pPTXUnsupportedProps = ((PictureFrame)pictureFrame).PPTXUnsupportedProps;
		Class956.smethod_1(pictureFrame, picElementData.SpPr, serializationContext);
		Class974.smethod_1(pictureFrame.PictureFormat, picElementData.BlipFill, serializationContext);
		Class984.smethod_1(pictureFrame.ShapeStyle, picElementData.delegate1633_0);
		Class2007 nvPicPr = picElementData.NvPicPr;
		Class983.smethod_6(pictureFrame, nvPicPr.NvPr, serializationContext);
		Class983.smethod_7(pictureFrame, nvPicPr.CNvPr, serializationContext);
		Class1884 cNvPicPr = nvPicPr.CNvPicPr;
		Class975.smethod_1(pictureFrame.ShapeLock, cNvPicPr.delegate1573_0);
		cNvPicPr.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfNonVisualDrawingShapeProps);
		smethod_3(pictureFrame, picElementData);
	}

	private static void smethod_3(IPictureFrame pictureFrame, Class2004 picElementData)
	{
		Class282 pPTXUnsupportedProps = ((PictureFrame)pictureFrame).PPTXUnsupportedProps;
		Class1884 cNvPicPr = picElementData.NvPicPr.CNvPicPr;
		cNvPicPr.PreferRelativeResize = pPTXUnsupportedProps.RelativeResizePreferred;
	}
}
