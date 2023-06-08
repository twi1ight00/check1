using ns25;

namespace Aspose.Slides.Charts;

public class ChartDataPoint : IChartDataPoint
{
	private Class310 class310_0 = new Class310();

	private ChartDataPointCollection chartDataPointCollection_0;

	private StringOrDoubleChartValue stringOrDoubleChartValue_0;

	private DoubleChartValue doubleChartValue_0;

	private DoubleChartValue doubleChartValue_1;

	private DoubleChartValue doubleChartValue_2;

	private DataLabel dataLabel_0;

	private bool bool_0;

	private Format format_0;

	private bool bool_1;

	private int int_0 = -1;

	private Marker marker_0;

	private LegendEntryProperties legendEntryProperties_0;

	private ErrorBarsCustomValues errorBarsCustomValues_0;

	public IStringOrDoubleChartValue XValue
	{
		get
		{
			if (stringOrDoubleChartValue_0 == null)
			{
				stringOrDoubleChartValue_0 = new StringOrDoubleChartValue(chartDataPointCollection_0.method_2(), centralizedTypeChangingRestriction: true);
			}
			return stringOrDoubleChartValue_0;
		}
	}

	public IDoubleChartValue YValue
	{
		get
		{
			if (doubleChartValue_0 == null)
			{
				doubleChartValue_0 = new DoubleChartValue(chartDataPointCollection_0.method_3(), centralizedTypeChangingRestriction: true);
			}
			return doubleChartValue_0;
		}
	}

	public IDoubleChartValue BubbleSize
	{
		get
		{
			if (doubleChartValue_1 == null)
			{
				doubleChartValue_1 = new DoubleChartValue(chartDataPointCollection_0.method_4(), centralizedTypeChangingRestriction: true);
			}
			return doubleChartValue_1;
		}
	}

	public IDoubleChartValue Value
	{
		get
		{
			if (doubleChartValue_2 == null)
			{
				doubleChartValue_2 = new DoubleChartValue(chartDataPointCollection_0.method_5(), centralizedTypeChangingRestriction: true);
			}
			return doubleChartValue_2;
		}
	}

	public IErrorBarsCustomValues ErrorBarsCustomValues
	{
		get
		{
			if (errorBarsCustomValues_0 == null)
			{
				errorBarsCustomValues_0 = new ErrorBarsCustomValues(chartDataPointCollection_0);
			}
			return errorBarsCustomValues_0;
		}
	}

	public IDataLabel Label
	{
		get
		{
			if (dataLabel_0 == null)
			{
				dataLabel_0 = new DataLabel(chartDataPointCollection_0.ParentSeries);
			}
			return dataLabel_0;
		}
	}

	public bool IsBubble3D
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public int Explosion
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public IFormat Format
	{
		get
		{
			if (format_0 == null)
			{
				format_0 = new Format(chartDataPointCollection_0.ParentSeries.Chart);
			}
			return format_0;
		}
		set
		{
			format_0 = (Format)value;
		}
	}

	public IMarker Marker => marker_0;

	internal Class310 PPTXUnsupportedProps => class310_0;

	internal LegendEntryProperties LegendEntryProperties
	{
		get
		{
			if (legendEntryProperties_0 == null)
			{
				legendEntryProperties_0 = new LegendEntryProperties((Chart)chartDataPointCollection_0.ParentSeries.Chart);
			}
			return legendEntryProperties_0;
		}
	}

	internal ChartDataPoint(ChartDataPointCollection dataPointCollection)
	{
		chartDataPointCollection_0 = dataPointCollection;
		marker_0 = new Marker(dataPointCollection.ParentSeries);
	}

	public void Remove()
	{
		if (chartDataPointCollection_0 == null)
		{
			throw new PptxEditException("Data point is already removed from series.");
		}
		lock (chartDataPointCollection_0.SyncRoot)
		{
			chartDataPointCollection_0.Remove(this);
			chartDataPointCollection_0 = null;
		}
	}
}
