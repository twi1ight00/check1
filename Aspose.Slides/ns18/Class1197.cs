using System;
using System.Xml;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns17;
using ns53;
using ns56;

namespace ns18;

internal class Class1197 : Class1188
{
	internal IChart method_5(IShapeCollection shapes, IChart chartOfTemplateTo, Class1991 graphicFrameElementData, Class1030 slideDeserializationContext)
	{
		Class892 @class = new Class892(slideDeserializationContext);
		method_0();
		IChart chart = null;
		while (base.XmlPartReader.Read())
		{
			if (base.XmlPartReader.NodeType == XmlNodeType.Element && base.XmlPartReader.LocalName == "chartSpace")
			{
				Class2020 class2 = new Class2020(base.XmlPartReader);
				@class.PlotAreaElementData = class2.Chart.PlotArea;
				chart = method_6(shapes, chartOfTemplateTo, class2);
				Class912.smethod_0(chart, graphicFrameElementData, class2, @class);
			}
		}
		method_2();
		return chart;
	}

	private IChart method_6(IShapeCollection shapes, IChart chartOfTemplateTo, Class2020 chartSpaceElementData)
	{
		if ((shapes != null && chartOfTemplateTo != null) || (shapes == null && chartOfTemplateTo == null))
		{
			throw new Exception("Wrong use of ChartPartParser.ReadPart() - only parameter 'chartOfTemplateTo' or only paramenter 'shapes' must be not null.");
		}
		IChart chart;
		if (chartOfTemplateTo != null)
		{
			chart = chartOfTemplateTo;
		}
		else
		{
			chart = shapes.AddChart(Class912.smethod_7(chartSpaceElementData.Chart.PlotArea, 0), 0f, 0f, 0f, 0f, initWithSample: false);
			Class983.smethod_3(chart);
		}
		return chart;
	}

	internal void method_7(IChart chart, Class1991 graphicFrameElementData, Class1031 slideSerializationContext)
	{
		Class882 chartPartSerializationContext = new Class882(slideSerializationContext);
		method_3();
		Class2020 @class = new Class2020();
		Class912.smethod_8(chart, @class, graphicFrameElementData, chartPartSerializationContext);
		@class.vmethod_4(null, base.XmlPartWriter, "chartSpace");
		method_4();
	}

	public Class1197(Class1342 part, Class1341 deserializationContext)
		: base(part, deserializationContext)
	{
	}

	public Class1197(Class1342 part, Class1346 serializationContext)
		: base(part, serializationContext)
	{
	}
}
