namespace Aspose.Slides.Charts;

public class ErrorBarsCustomValues : IErrorBarsCustomValues
{
	private DoubleChartValue doubleChartValue_0;

	private DoubleChartValue doubleChartValue_1;

	private DoubleChartValue doubleChartValue_2;

	private DoubleChartValue doubleChartValue_3;

	private ChartDataPointCollection chartDataPointCollection_0;

	public IDoubleChartValue XMinus
	{
		get
		{
			if (chartDataPointCollection_0.ParentSeries.ErrorBarsXFormat != null && chartDataPointCollection_0.ParentSeries.ErrorBarsXFormat.ValueType == ErrorBarValueType.Custom)
			{
				if (doubleChartValue_0 == null)
				{
					DataSourceTypeForErrorBarsCustomValues dataSourceTypeForErrorBarsCustomValues = (DataSourceTypeForErrorBarsCustomValues)chartDataPointCollection_0.DataSourceTypeForErrorBarsCustomValues;
					doubleChartValue_0 = new DoubleChartValue(dataSourceTypeForErrorBarsCustomValues.method_0(), centralizedTypeChangingRestriction: true);
				}
				return doubleChartValue_0;
			}
			return null;
		}
	}

	public IDoubleChartValue YMinus
	{
		get
		{
			if (chartDataPointCollection_0.ParentSeries.ErrorBarsYFormat != null && chartDataPointCollection_0.ParentSeries.ErrorBarsYFormat.ValueType == ErrorBarValueType.Custom)
			{
				if (doubleChartValue_2 == null)
				{
					DataSourceTypeForErrorBarsCustomValues dataSourceTypeForErrorBarsCustomValues = (DataSourceTypeForErrorBarsCustomValues)chartDataPointCollection_0.DataSourceTypeForErrorBarsCustomValues;
					doubleChartValue_2 = new DoubleChartValue(dataSourceTypeForErrorBarsCustomValues.method_2(), centralizedTypeChangingRestriction: true);
				}
				return doubleChartValue_2;
			}
			return null;
		}
	}

	public IDoubleChartValue XPlus
	{
		get
		{
			if (chartDataPointCollection_0.ParentSeries.ErrorBarsXFormat != null && chartDataPointCollection_0.ParentSeries.ErrorBarsXFormat.ValueType == ErrorBarValueType.Custom)
			{
				if (doubleChartValue_1 == null)
				{
					DataSourceTypeForErrorBarsCustomValues dataSourceTypeForErrorBarsCustomValues = (DataSourceTypeForErrorBarsCustomValues)chartDataPointCollection_0.DataSourceTypeForErrorBarsCustomValues;
					doubleChartValue_1 = new DoubleChartValue(dataSourceTypeForErrorBarsCustomValues.method_1(), centralizedTypeChangingRestriction: true);
				}
				return doubleChartValue_1;
			}
			return null;
		}
	}

	public IDoubleChartValue YPlus
	{
		get
		{
			if (chartDataPointCollection_0.ParentSeries.ErrorBarsYFormat != null && chartDataPointCollection_0.ParentSeries.ErrorBarsYFormat.ValueType == ErrorBarValueType.Custom)
			{
				if (doubleChartValue_3 == null)
				{
					DataSourceTypeForErrorBarsCustomValues dataSourceTypeForErrorBarsCustomValues = (DataSourceTypeForErrorBarsCustomValues)chartDataPointCollection_0.DataSourceTypeForErrorBarsCustomValues;
					doubleChartValue_3 = new DoubleChartValue(dataSourceTypeForErrorBarsCustomValues.method_3(), centralizedTypeChangingRestriction: true);
				}
				return doubleChartValue_3;
			}
			return null;
		}
	}

	internal ErrorBarsCustomValues(ChartDataPointCollection dataPointCollection)
	{
		chartDataPointCollection_0 = dataPointCollection;
	}
}
