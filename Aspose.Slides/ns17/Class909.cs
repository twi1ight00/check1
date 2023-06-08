using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using ns16;
using ns18;
using ns56;

namespace ns17;

internal class Class909
{
	public static void smethod_0(IChartLinesFormat chartLinesFormat, Class2059 chartLinesElementData, Class1341 deserializationContext)
	{
		chartLinesFormat.Line.FillFormat.FillType = ((chartLinesElementData != null) ? FillType.NotDefined : FillType.NoFill);
		if (chartLinesElementData == null)
		{
			return;
		}
		Class1921 spPr = chartLinesElementData.SpPr;
		if (spPr != null)
		{
			if (spPr.Xfrm != null || spPr.Geometry != null || spPr.Scene3d != null || spPr.Sp3d != null || spPr.FillProperties != null)
			{
				throw new NotImplementedException();
			}
			Class968.smethod_0(chartLinesFormat.Line, spPr.Ln);
			Class939.smethod_0(chartLinesFormat.Effect, spPr.EffectProperties, deserializationContext);
			((ChartLinesFormat)chartLinesFormat).PPTXUnsupportedProps.ExtensionList = spPr.ExtLst;
		}
	}

	public static void smethod_1(IChartLinesFormat chartLinesFormat, Class2059 chartLinesElementData, Class1346 serializationContext)
	{
		if (chartLinesFormat != null && (!chartLinesFormat.Line.IsFormatNotDefined || !chartLinesFormat.Effect.IsNoEffects))
		{
			Class1921 @class = chartLinesElementData.delegate1630_0();
			Class968.smethod_2(chartLinesFormat.Line, @class.delegate1504_0);
			Class939.smethod_1(chartLinesFormat.Effect, @class.delegate2773_0, serializationContext);
			@class.delegate1535_0(((ChartLinesFormat)chartLinesFormat).PPTXUnsupportedProps.ExtensionList);
		}
	}
}
