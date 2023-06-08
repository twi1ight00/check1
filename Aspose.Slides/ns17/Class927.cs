using Aspose.Slides.Charts;
using ns16;
using ns25;
using ns56;

namespace ns17;

internal class Class927
{
	public static void smethod_0(ITrendline trendline, Class2129 trendlineElementData, Class1341 deserializationContext)
	{
		if (trendlineElementData != null)
		{
			Class327 pPTXUnsupportedProps = ((Trendline)trendline).PPTXUnsupportedProps;
			trendline.TrendlineName = trendlineElementData.Name;
			Class921.smethod_0(trendline.Format, trendlineElementData.SpPr, deserializationContext);
			trendline.TrendlineType = trendlineElementData.TrendlineType.Val;
			if (trendlineElementData.Order != null)
			{
				trendline.Order = trendlineElementData.Order.Val;
			}
			if (trendlineElementData.Period != null)
			{
				trendline.Period = trendlineElementData.Period.Val;
			}
			if (trendlineElementData.Forward != null)
			{
				trendline.Forward = trendlineElementData.Forward.Val;
			}
			if (trendlineElementData.Backward != null)
			{
				trendline.Backward = trendlineElementData.Backward.Val;
			}
			if (trendlineElementData.Intercept != null)
			{
				trendline.Intercept = trendlineElementData.Intercept.Val;
			}
			if (trendlineElementData.DispRSqr != null)
			{
				trendline.DisplayRSquaredValue = trendlineElementData.DispRSqr.Val;
			}
			if (trendlineElementData.DispEq != null)
			{
				trendline.DisplayEquation = trendlineElementData.DispEq.Val;
			}
			if (trendlineElementData.TrendlineLbl != null)
			{
				Class925.smethod_0(trendline, trendlineElementData.TrendlineLbl.Tx, trendlineElementData.TrendlineLbl.TxPr, deserializationContext);
				pPTXUnsupportedProps.TrendlineLblLayout = trendlineElementData.TrendlineLbl.Layout;
				pPTXUnsupportedProps.TrendlineLblNumFmt = trendlineElementData.TrendlineLbl.NumFmt;
				pPTXUnsupportedProps.TrendlineLblSpPr = trendlineElementData.TrendlineLbl.SpPr;
				pPTXUnsupportedProps.ExtensionListOfTrendlineLabel = trendlineElementData.TrendlineLbl.ExtLst;
			}
			pPTXUnsupportedProps.ExtensionList = trendlineElementData.ExtLst;
		}
	}

	public static void smethod_1(ITrendline trendline, Class2129 trendlineElementData, Class1346 serializationContext)
	{
		if (trendline != null)
		{
			Class327 pPTXUnsupportedProps = ((Trendline)trendline).PPTXUnsupportedProps;
			trendlineElementData.Name = trendline.TrendlineName;
			Class921.smethod_1(trendline.Format, trendlineElementData.delegate1630_0, serializationContext);
			trendlineElementData.TrendlineType.Val = trendline.TrendlineType;
			if (trendline.TrendlineType == TrendlineType.Polynomial)
			{
				trendlineElementData.delegate2022_0().Val = trendline.Order;
			}
			if (trendline.TrendlineType == TrendlineType.MovingAverage)
			{
				trendlineElementData.delegate2031_0().Val = trendline.Period;
			}
			if (!double.IsNaN(trendline.Forward))
			{
				trendlineElementData.delegate1923_0().Val = trendline.Forward;
			}
			if (!double.IsNaN(trendline.Backward))
			{
				trendlineElementData.delegate1923_1().Val = trendline.Backward;
			}
			if (!double.IsNaN(trendline.Intercept))
			{
				trendlineElementData.delegate1923_2().Val = trendline.Intercept;
			}
			trendlineElementData.delegate2763_0().Val = trendline.DisplayRSquaredValue;
			trendlineElementData.delegate2763_1().Val = trendline.DisplayEquation;
			if ((trendline.TextFrameForOverriding != null && trendline.TextFrameForOverriding.Paragraphs.Count != 0) || Class916.smethod_10(trendline.TextFormat) || pPTXUnsupportedProps.TrendlineLblLayout != null || pPTXUnsupportedProps.TrendlineLblNumFmt != null || pPTXUnsupportedProps.TrendlineLblSpPr != null || pPTXUnsupportedProps.ExtensionListOfTrendlineLabel != null)
			{
				trendlineElementData.delegate2121_0();
				Class925.smethod_1(trendline, trendlineElementData.TrendlineLbl.delegate2133_0, trendlineElementData.TrendlineLbl.delegate1705_0, serializationContext);
				trendlineElementData.TrendlineLbl.delegate1957_0(pPTXUnsupportedProps.TrendlineLblLayout);
				trendlineElementData.TrendlineLbl.delegate2011_0(pPTXUnsupportedProps.TrendlineLblNumFmt);
				trendlineElementData.TrendlineLbl.delegate1632_0(pPTXUnsupportedProps.TrendlineLblSpPr);
				trendlineElementData.TrendlineLbl.delegate1535_0(pPTXUnsupportedProps.ExtensionListOfTrendlineLabel);
			}
			trendlineElementData.delegate1535_0(pPTXUnsupportedProps.ExtensionList);
		}
	}
}
