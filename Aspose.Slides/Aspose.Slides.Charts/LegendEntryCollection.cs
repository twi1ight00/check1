namespace Aspose.Slides.Charts;

public class LegendEntryCollection : ILegendEntryCollection
{
	private Chart chart_0;

	public ILegendEntryProperties this[int index]
	{
		get
		{
			if (chart_0.ChartData.Series.Count == 1 && ChartTypeCharacterizer.IsChartTypePie(chart_0.ChartData.Series[0].Type))
			{
				return ((ChartDataPoint)chart_0.ChartData.Series[0].DataPoints[index]).LegendEntryProperties;
			}
			return ((ChartSeries)chart_0.ChartData.Series[index]).LegendEntryProperties;
		}
	}

	public int Count
	{
		get
		{
			if (chart_0.ChartData.Series.Count == 1 && ChartTypeCharacterizer.IsChartTypePie(chart_0.ChartData.Series[0].Type))
			{
				return chart_0.ChartData.Series[0].DataPoints.Count;
			}
			return chart_0.ChartData.Series.Count;
		}
	}

	internal LegendEntryCollection(Chart parent)
	{
		chart_0 = parent;
	}
}
