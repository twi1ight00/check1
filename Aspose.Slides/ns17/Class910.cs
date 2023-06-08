using System;
using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class910
{
	public static void smethod_0(IChartPlotArea plotArea, Class2106 plotAreaElementData, Class1341 deserializationContext)
	{
		if (plotAreaElementData == null)
		{
			throw new Exception("plotAreaElementData must not be null.");
		}
		Class921.smethod_0(plotArea.Format, plotAreaElementData.SpPr, deserializationContext);
		Class313 pPTXUnsupportedProps = ((ChartPlotArea)plotArea).PPTXUnsupportedProps;
		Class922.smethod_0(pPTXUnsupportedProps, plotAreaElementData.Layout);
		if (float.IsNaN(pPTXUnsupportedProps.Width) && float.IsNaN(pPTXUnsupportedProps.Height) && float.IsNaN(pPTXUnsupportedProps.X) && float.IsNaN(pPTXUnsupportedProps.Y))
		{
			((ChartPlotArea)plotArea).bool_0 = true;
		}
		pPTXUnsupportedProps.ExtensionList = plotAreaElementData.ExtLst;
	}

	public static void smethod_1(IChartPlotArea plotArea, Class2106 plotAreaElementData, Class1346 serializationContext)
	{
		Class921.smethod_1(plotArea.Format, plotAreaElementData.delegate1630_0, serializationContext);
		Class313 pPTXUnsupportedProps = ((ChartPlotArea)plotArea).PPTXUnsupportedProps;
		Class922.smethod_1(pPTXUnsupportedProps, plotAreaElementData.delegate1955_0);
		plotAreaElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
	}
}
