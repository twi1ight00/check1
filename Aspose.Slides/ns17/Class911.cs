using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns18;
using ns53;
using ns55;
using ns56;

namespace ns17;

internal class Class911
{
	public static IChart smethod_0(IShapeCollection shapes, Class1991 graphicFrameElementData, Class1030 slideDeserializationContext)
	{
		if (graphicFrameElementData == null)
		{
			return null;
		}
		Class2019 chartRef = graphicFrameElementData.Graphic.GraphicData.ChartRef;
		string r_Id = chartRef.R_Id;
		Class1342 targetPart = slideDeserializationContext.DeserializationContext.RelationshipsOfCurrentPartEntry[r_Id].TargetPart;
		Class1197 @class = new Class1197(targetPart, slideDeserializationContext.DeserializationContext);
		return @class.method_5(shapes, null, graphicFrameElementData, slideDeserializationContext);
	}

	public static void smethod_1(IChart chart, Class1991 graphicFrameElementData, Class1031 slideSerializationContext)
	{
		Class2019 @class = graphicFrameElementData.Graphic.GraphicData.delegate1846_0();
		Class1346 serializationContext = slideSerializationContext.SerializationContext;
		Class1342 class2 = serializationContext.Package.method_4("/ppt/charts/chart{0}.xml", serializationContext.method_11, new Class1228());
		Class1197 class3 = new Class1197(class2, serializationContext);
		class3.method_7(chart, graphicFrameElementData, slideSerializationContext);
		Class1347 class4 = serializationContext.RelationshipsOfCurrentPartEntry.method_4(class2);
		@class.R_Id = class4.Id;
	}
}
