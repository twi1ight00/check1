using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using ns16;
using ns26;
using ns53;
using ns55;
using ns56;

namespace ns18;

internal class Class995
{
	public static SmartArt smethod_0(IShapeCollection shapes, Class1991 graphicFrameElementData, Class1030 slideDeserializationContext)
	{
		if (graphicFrameElementData == null)
		{
			return null;
		}
		ShapeCollection shapeCollection = (ShapeCollection)shapes;
		SmartArt smartArt = new SmartArt(shapeCollection.groupShape_0.Slide);
		shapeCollection.Add(smartArt);
		Class290 pPTXUnsupportedProps = smartArt.PPTXUnsupportedProps;
		Class959.smethod_0(smartArt, graphicFrameElementData, slideDeserializationContext);
		Class1341 deserializationContext = slideDeserializationContext.DeserializationContext;
		Class2214 smartArtRelIds = graphicFrameElementData.Graphic.GraphicData.SmartArtRelIds;
		string r_Cs = smartArtRelIds.R_Cs;
		Class1342 targetPart = deserializationContext.RelationshipsOfCurrentPartEntry[r_Cs].TargetPart;
		Class1201 @class = new Class1201(targetPart, deserializationContext);
		@class.method_5(pPTXUnsupportedProps);
		string r_Dm = smartArtRelIds.R_Dm;
		Class1342 targetPart2 = deserializationContext.RelationshipsOfCurrentPartEntry[r_Dm].TargetPart;
		Class1202 class2 = new Class1202(targetPart2, deserializationContext);
		class2.method_5(pPTXUnsupportedProps);
		Class1348 relationships = targetPart2.Relationships;
		string r_Lo = smartArtRelIds.R_Lo;
		Class1342 targetPart3 = deserializationContext.RelationshipsOfCurrentPartEntry[r_Lo].TargetPart;
		Class1204 class3 = new Class1204(targetPart3, deserializationContext);
		class3.method_5(pPTXUnsupportedProps);
		string r_Qs = smartArtRelIds.R_Qs;
		Class1342 targetPart4 = deserializationContext.RelationshipsOfCurrentPartEntry[r_Qs].TargetPart;
		Class1205 class4 = new Class1205(targetPart4, deserializationContext);
		class4.method_5(pPTXUnsupportedProps);
		XmlElement xmlElement = null;
		Class1451 class5 = Class2472.smethod_0(pPTXUnsupportedProps.DataModelElementData.ExtLst);
		if (class5 != null)
		{
			string namespaceURI = "http://schemas.microsoft.com/office/drawing/2008/diagram";
			xmlElement = (XmlElement)Class1029.smethod_11(class5.XmlDocument.DocumentElement, "dataModelExt", namespaceURI);
		}
		if (xmlElement != null)
		{
			string attribute = xmlElement.GetAttribute("relId");
			Class1342 targetPart5 = deserializationContext.RelationshipsOfCurrentPartEntry[attribute].TargetPart;
			if (targetPart5 != null && targetPart5.ContentType is Class1293)
			{
				Class1203 class6 = new Class1203(targetPart5, deserializationContext);
				class6.method_5(pPTXUnsupportedProps, slideDeserializationContext);
			}
			((GroupShape)pPTXUnsupportedProps.ShapesRoot).PPTXUnsupportedProps.ParentShape = smartArt;
		}
		Class1348 relationshipsOfCurrentPartEntry = deserializationContext.RelationshipsOfCurrentPartEntry;
		deserializationContext.RelationshipsOfCurrentPartEntry = relationships;
		if (pPTXUnsupportedProps.DataModelElementData.Bg != null && pPTXUnsupportedProps.DataModelElementData.Bg.FillProperties != null)
		{
			Class949.smethod_0(smartArt.fillFormat_0, pPTXUnsupportedProps.DataModelElementData.Bg.FillProperties, deserializationContext);
		}
		if (pPTXUnsupportedProps.DataModelElementData.Whole != null && pPTXUnsupportedProps.DataModelElementData.Whole.Ln != null)
		{
			Class968.smethod_0(smartArt.lineFormat_0, pPTXUnsupportedProps.DataModelElementData.Whole.Ln);
		}
		smartArt.method_14(deserializationContext);
		deserializationContext.RelationshipsOfCurrentPartEntry = relationshipsOfCurrentPartEntry;
		return smartArt;
	}

	public static void smethod_1(SmartArt smartArt, Class1991 graphicFrameElementData, Class1031 slideSerializationContext)
	{
		Class290 pPTXUnsupportedProps = smartArt.PPTXUnsupportedProps;
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		Class1341 @class = new Class1341(smartArt.Presentation);
		@class.RelationshipsOfCurrentPartEntry = pPTXUnsupportedProps.DataModel_RelsOfDataPart;
		Class959.smethod_2(smartArt, graphicFrameElementData, serializationContext);
		int num = serializationContext.method_19();
		Class1347 relToDrawingPart = null;
		if (pPTXUnsupportedProps.DrawingElementData != null)
		{
			Class1342 class2 = serializationContext.Package.method_4("/ppt/diagrams/drawing" + num + ".xml", null, new Class1293());
			Class1203 class3 = new Class1203(class2, serializationContext);
			class3.method_6(pPTXUnsupportedProps, slideSerializationContext);
			relToDrawingPart = serializationContext.RelationshipsOfCurrentPartEntry.method_4(class2);
		}
		Class2214 class4 = graphicFrameElementData.Graphic.GraphicData.delegate2378_0();
		Class1342 class5 = serializationContext.Package.method_4("/ppt/diagrams/data" + num + ".xml", null, new Class1231());
		Class1348 relationshipsOfCurrentPartEntry = serializationContext.RelationshipsOfCurrentPartEntry;
		serializationContext.RelationshipsOfCurrentPartEntry = class5.Relationships;
		smartArt.method_15(serializationContext);
		serializationContext.RelationshipsOfCurrentPartEntry = relationshipsOfCurrentPartEntry;
		Class1202 class6 = new Class1202(class5, serializationContext);
		class6.method_6(pPTXUnsupportedProps, relToDrawingPart);
		Class1347 class7 = serializationContext.RelationshipsOfCurrentPartEntry.method_4(class5);
		class4.R_Dm = class7.Id;
		Class1342 class8 = serializationContext.Package.method_4("/ppt/diagrams/layout" + num + ".xml", null, new Class1232());
		Class1204 class9 = new Class1204(class8, serializationContext);
		class9.method_6(pPTXUnsupportedProps);
		class7 = serializationContext.RelationshipsOfCurrentPartEntry.method_4(class8);
		class4.R_Lo = class7.Id;
		Class1342 class10 = serializationContext.Package.method_4("/ppt/diagrams/quickStyle" + num + ".xml", null, new Class1233());
		Class1205 class11 = new Class1205(class10, serializationContext);
		class11.method_6(pPTXUnsupportedProps);
		class7 = serializationContext.RelationshipsOfCurrentPartEntry.method_4(class10);
		class4.R_Qs = class7.Id;
		Class1342 class12 = serializationContext.Package.method_4("/ppt/diagrams/colors" + num + ".xml", null, new Class1230());
		Class1201 class13 = new Class1201(class12, serializationContext);
		class13.method_6(pPTXUnsupportedProps);
		class7 = serializationContext.RelationshipsOfCurrentPartEntry.method_4(class12);
		class4.R_Cs = class7.Id;
	}

	private static Dictionary<Class1347, IPPImage> smethod_2(Class1341 deserializationContext, Class1348 dataRelationships)
	{
		Dictionary<Class1347, IPPImage> dictionary = new Dictionary<Class1347, IPPImage>();
		foreach (Class1347 item in (IEnumerable)dataRelationships)
		{
			string type = item.Type;
			int num = type.LastIndexOf('/');
			string text = ((num < 0) ? type : type.Substring(num + 1, type.Length - num - 1));
			if (text.ToLower() == "image")
			{
				dictionary.Add(item, deserializationContext.method_1(item.TargetPart));
			}
		}
		return dictionary;
	}
}
