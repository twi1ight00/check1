using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Warnings;
using ns16;
using ns17;
using ns24;
using ns56;
using ns7;

namespace ns18;

internal class Class961
{
	private const string string_0 = "http://schemas.openxmlformats.org/drawingml/2006/table";

	public static void smethod_0(IGroupShape groupShape, Class1995 groupShapeElementData, Class1030 slideDeserializationContext)
	{
		if (groupShapeElementData != null)
		{
			Class292 pPTXUnsupportedProps = ((GroupShape)groupShape).PPTXUnsupportedProps;
			Class1861 grpSpPr = groupShapeElementData.GrpSpPr;
			Class949.smethod_0(groupShape.FillFormat, grpSpPr.FillProperties, slideDeserializationContext.DeserializationContext);
			Class939.smethod_0(groupShape.EffectFormat, grpSpPr.EffectProperties, slideDeserializationContext.DeserializationContext);
			Class1007.smethod_0(groupShape.ThreeDFormat, grpSpPr.Scene3d, null, null);
			Class1999 nvGrpSpPr = groupShapeElementData.NvGrpSpPr;
			Class983.smethod_1(groupShape, nvGrpSpPr.NvPr, slideDeserializationContext);
			Class983.smethod_2(groupShape, nvGrpSpPr.CNvPr, slideDeserializationContext);
			Class1883 cNvGrpSpPr = nvGrpSpPr.CNvGrpSpPr;
			Class960.smethod_0(groupShape.ShapeLock, cNvGrpSpPr.GrpSpLocks);
			pPTXUnsupportedProps.ExtensionListOfNonVisualGroupShapeProps = cNvGrpSpPr.ExtLst;
			pPTXUnsupportedProps.ExtensionList = groupShapeElementData.ExtLst;
			((ShapeCollection)groupShape.Shapes).Clear();
			Class2605[] shapeList = groupShapeElementData.ShapeList;
			foreach (Class2605 subshape in shapeList)
			{
				smethod_1(subshape, groupShape, slideDeserializationContext);
			}
			Class155 rawFrameImpl = ((GroupShape)groupShape).RawFrameImpl;
			Class962.smethod_0(rawFrameImpl, groupShapeElementData);
		}
	}

	internal static IShape smethod_1(Class2605 subshape, IGroupShape groupShape, Class1030 slideDeserializationContext)
	{
		switch (subshape.Name)
		{
		case "pic":
		{
			Class2004 class2 = (Class2004)subshape.Object;
			IPictureFrame pictureFrame;
			if (class2.NvPicPr.NvPr.Media != null)
			{
				switch (class2.NvPicPr.NvPr.Media.Name)
				{
				case "quickTimeFile":
					_ = (Class1912)class2.NvPicPr.NvPr.Media.Object;
					pictureFrame = groupShape.Shapes.AddPictureFrame(ShapeType.NotDefined, 0f, 0f, 0f, 0f, null);
					Class983.smethod_3(pictureFrame);
					pictureFrame.PictureFormat.Picture.Image = ((ImageCollection)slideDeserializationContext.DeserializationContext.Presentation.Images).NoImage;
					slideDeserializationContext.DeserializationContext.method_4("Loading of the quickTimeFile media type is not implemented yet.", WarningType.DataLoss);
					break;
				case "videoFile":
				{
					Class1979 videoFileElementData = (Class1979)class2.NvPicPr.NvPr.Media.Object;
					pictureFrame = Class1022.smethod_0(groupShape, class2, videoFileElementData, slideDeserializationContext.DeserializationContext);
					break;
				}
				case "audioFile":
				{
					Class1801 audioFileElementData = (Class1801)class2.NvPicPr.NvPr.Media.Object;
					pictureFrame = Class893.smethod_2(groupShape, class2, audioFileElementData, slideDeserializationContext.DeserializationContext);
					break;
				}
				case "wavAudioFile":
				{
					Class1838 embeddedWavAudioFile = (Class1838)class2.NvPicPr.NvPr.Media.Object;
					pictureFrame = Class893.smethod_1(groupShape, embeddedWavAudioFile, slideDeserializationContext.DeserializationContext);
					break;
				}
				case "audioCd":
				{
					Class1799 audioCDElementData = (Class1799)class2.NvPicPr.NvPr.Media.Object;
					pictureFrame = Class893.smethod_0(groupShape, audioCDElementData);
					break;
				}
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			else
			{
				pictureFrame = groupShape.Shapes.AddPictureFrame(ShapeType.NotDefined, 0f, 0f, 0f, 0f, null);
				Class983.smethod_3(pictureFrame);
			}
			Class976.smethod_0(pictureFrame, class2, slideDeserializationContext);
			return pictureFrame;
		}
		case "cxnSp":
		{
			Class1983 connectorElementData = (Class1983)subshape.Object;
			Connector connector = (Connector)groupShape.Shapes.AddConnector(ShapeType.Line, 0f, 0f, 0f, 0f, createFromTemplate: false);
			Class983.smethod_3(connector);
			Class934.smethod_0(connector, connectorElementData, slideDeserializationContext);
			return connector;
		}
		case "graphicFrame":
		{
			Class1991 class3 = (Class1991)subshape.Object;
			switch (class3.Graphic.GraphicData.Uri)
			{
			case "http://schemas.openxmlformats.org/drawingml/2006/diagram":
				return Class995.smethod_0(groupShape.Shapes, class3, slideDeserializationContext);
			case "http://schemas.openxmlformats.org/drawingml/2006/chart":
				return Class911.smethod_0(groupShape.Shapes, class3, slideDeserializationContext);
			case "http://schemas.openxmlformats.org/presentationml/2006/ole":
			{
				OleObjectFrame oleObjectFrame = (OleObjectFrame)groupShape.Shapes.AddOleObjectFrame(0f, 0f, 0f, 0f, "", (byte[])null);
				Class983.smethod_3(oleObjectFrame);
				Class969.smethod_0(oleObjectFrame, class3, slideDeserializationContext);
				return oleObjectFrame;
			}
			case "http://schemas.openxmlformats.org/drawingml/2006/table":
				return Class999.smethod_0(groupShape.Shapes, class3, slideDeserializationContext);
			default:
			{
				GraphicalObject graphicalObject = (GraphicalObject)((ShapeCollection)groupShape.Shapes).method_17();
				Class959.smethod_0(graphicalObject, class3, slideDeserializationContext);
				graphicalObject.PPTXUnsupportedProps.Graphic = class3.Graphic;
				return graphicalObject;
			}
			}
		}
		case "grpSp":
		{
			Class1995 groupShapeElementData = (Class1995)subshape.Object;
			GroupShape groupShape2 = (GroupShape)groupShape.Shapes.AddGroupShape();
			smethod_0(groupShape2, groupShapeElementData, slideDeserializationContext);
			return groupShape2;
		}
		case "sp":
		{
			Class2011 @class = (Class2011)subshape.Object;
			if (!smethod_2(@class))
			{
				AutoShape autoShape = (AutoShape)groupShape.Shapes.AddAutoShape(ShapeType.NotDefined, 0f, 0f, 0f, 0f, createFromTemplate: false);
				Class983.smethod_3(autoShape);
				Class895.smethod_0(autoShape, @class, slideDeserializationContext);
				return autoShape;
			}
			return null;
		}
		default:
			throw new Exception("Unknown element \"" + subshape.Name + "\"");
		}
	}

	private static bool smethod_2(Class2011 sp)
	{
		if (sp.TxBody == null)
		{
			return false;
		}
		string text = "";
		Class1962[] pList = sp.TxBody.PList;
		foreach (Class1962 @class in pList)
		{
			Class2605[] textRunList = @class.TextRunList;
			foreach (Class2605 class2 in textRunList)
			{
				if (class2.Name == "r")
				{
					Class1354 class3 = (Class1354)class2.Object;
					text += class3.T;
				}
			}
		}
		int num = 0;
		while (true)
		{
			if (num < Class1196.string_1.Length)
			{
				if (text == Class1196.string_1[num])
				{
					break;
				}
				num++;
				continue;
			}
			return false;
		}
		return true;
	}

	public static void smethod_3(IGroupShape groupShape, Class1995 groupShapeElementData, Class1031 slideSerializationContext, Class882 chartPartSerializationContext)
	{
		if (groupShape == null)
		{
			return;
		}
		Class1861 grpSpPr = groupShapeElementData.GrpSpPr;
		Class292 pPTXUnsupportedProps = ((GroupShape)groupShape).PPTXUnsupportedProps;
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		if (groupShapeElementData is Class1998)
		{
			groupShapeElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
		else if (groupShapeElementData is Class1997)
		{
			groupShapeElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
		Class949.smethod_1(groupShape.FillFormat, grpSpPr.delegate2773_1, serializationContext);
		Class939.smethod_1(groupShape.EffectFormat, grpSpPr.delegate2773_0, serializationContext);
		Class1007.smethod_1(groupShape.ThreeDFormat, grpSpPr.delegate1615_0, null, null);
		Class962.smethod_1((GroupShape)groupShape, groupShapeElementData.GrpSpPr.delegate1465_0);
		Class1999 nvGrpSpPr = groupShapeElementData.NvGrpSpPr;
		Class983.smethod_6(groupShape, nvGrpSpPr.NvPr, serializationContext);
		Class983.smethod_7(groupShape, nvGrpSpPr.CNvPr, serializationContext);
		Class1883 cNvGrpSpPr = nvGrpSpPr.CNvGrpSpPr;
		cNvGrpSpPr.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfNonVisualGroupShapeProps);
		Class960.smethod_1(groupShape.ShapeLock, cNvGrpSpPr.delegate1459_0);
		foreach (IShape shape in groupShape.Shapes)
		{
			smethod_4(shape, groupShapeElementData, slideSerializationContext, chartPartSerializationContext);
		}
	}

	internal static void smethod_4(IShape shape, Class1995 groupShapeElementData, Class1031 slideSerializationContext, Class882 chartPartSerializationContext)
	{
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		if (shape is AutoShape)
		{
			Class2011 shapeElementData = (Class2011)groupShapeElementData.delegate2773_0("sp").Object;
			Class895.smethod_1((AutoShape)shape, shapeElementData, slideSerializationContext, chartPartSerializationContext);
		}
		else if (shape is Connector)
		{
			Class1983 connectorElementData = (Class1983)groupShapeElementData.delegate2773_0("cxnSp").Object;
			Class934.smethod_1((Connector)shape, connectorElementData, serializationContext);
		}
		else if (shape is AudioFrame)
		{
			Class2006 audioFrameElementData = (Class2006)groupShapeElementData.delegate2773_0("pic").Object;
			Class893.smethod_4((AudioFrame)shape, audioFrameElementData, serializationContext);
		}
		else if (shape is VideoFrame)
		{
			Class2006 videoFrameElementData = (Class2006)groupShapeElementData.delegate2773_0("pic").Object;
			Class1022.smethod_1((VideoFrame)shape, videoFrameElementData, serializationContext);
		}
		else if (shape is IChart)
		{
			Class1991 @class = (Class1991)groupShapeElementData.delegate2773_0("graphicFrame").Object;
			@class.Graphic.GraphicData.Uri = "http://schemas.openxmlformats.org/drawingml/2006/chart";
			Class911.smethod_1((IChart)shape, @class, slideSerializationContext);
		}
		else if (shape is SmartArt)
		{
			Class1991 class2 = (Class1991)groupShapeElementData.delegate2773_0("graphicFrame").Object;
			class2.Graphic.GraphicData.Uri = "http://schemas.openxmlformats.org/drawingml/2006/diagram";
			Class995.smethod_1((SmartArt)shape, class2, slideSerializationContext);
		}
		else if (shape is OleObjectFrame)
		{
			Class1991 class3 = (Class1991)groupShapeElementData.delegate2773_0("graphicFrame").Object;
			class3.Graphic.GraphicData.Uri = "http://schemas.openxmlformats.org/presentationml/2006/ole";
			Class969.smethod_1((OleObjectFrame)shape, class3, slideSerializationContext);
		}
		else if (shape is Table)
		{
			Class1991 class4 = (Class1991)groupShapeElementData.delegate2773_0("graphicFrame").Object;
			class4.Graphic.GraphicData.Uri = "http://schemas.openxmlformats.org/drawingml/2006/table";
			Class999.smethod_1((Table)shape, class4, serializationContext);
		}
		else if (shape is GroupShape)
		{
			Class1995 groupShapeElementData2 = (Class1995)groupShapeElementData.delegate2773_0("grpSp").Object;
			smethod_3((GroupShape)shape, groupShapeElementData2, slideSerializationContext, chartPartSerializationContext);
		}
		else if (shape is PictureFrame)
		{
			Class2004 picElementData = (Class2004)groupShapeElementData.delegate2773_0("pic").Object;
			Class976.smethod_2((PictureFrame)shape, picElementData, serializationContext);
		}
		else if (shape is GraphicalObject)
		{
			Class1989 class5 = (Class1989)groupShapeElementData.delegate2773_0("graphicFrame").Object;
			Class959.smethod_2((GraphicalObject)shape, class5, serializationContext);
			Class2346 graphic = ((GraphicalObject)shape).PPTXUnsupportedProps.Graphic;
			if (graphic != null)
			{
				class5.Graphic.GraphicData.Uri = graphic.GraphicData.Uri;
				class5.Graphic.GraphicData.XmlDocumentFragment = graphic.GraphicData.XmlDocumentFragment;
			}
		}
	}
}
