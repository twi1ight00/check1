using System;
using System.Collections;
using System.Collections.Generic;
using ns2;
using ns25;

namespace Aspose.Slides.Charts;

public class ChartDataPointCollection : ICollection, IEnumerable, IEnumerable<IChartDataPoint>, IChartDataPointCollection
{
	private Class309 class309_0 = new Class309();

	private ChartSeries chartSeries_0;

	private Class1035 class1035_0 = new Class1035();

	private Class1035 class1035_1 = new Class1035();

	private Class1035 class1035_2 = new Class1035();

	private Class1035 class1035_3 = new Class1035();

	private List<IChartDataPoint> list_0 = new List<IChartDataPoint>();

	private DataSourceTypeForErrorBarsCustomValues dataSourceTypeForErrorBarsCustomValues_0 = new DataSourceTypeForErrorBarsCustomValues();

	public IChartDataPoint this[int index] => list_0[index];

	public int this[IChartDataPoint pt] => list_0.IndexOf(pt);

	public DataSourceType DataSourceTypeForXValues
	{
		get
		{
			return class1035_0.DataSourceType;
		}
		set
		{
			class1035_0.DataSourceType = value;
		}
	}

	public DataSourceType DataSourceTypeForYValues
	{
		get
		{
			return class1035_1.DataSourceType;
		}
		set
		{
			if (value != 0 && value != DataSourceType.DoubleLiterals)
			{
				throw new InvalidOperationException("DataSourceTypeForYValues can be DataSourceType.Worksheet or DataSourceType.DoubleLiterals");
			}
			class1035_1.DataSourceType = value;
		}
	}

	public DataSourceType DataSourceTypeForBubbleSizes
	{
		get
		{
			return class1035_2.DataSourceType;
		}
		set
		{
			if (value != 0 && value != DataSourceType.DoubleLiterals)
			{
				throw new InvalidOperationException("DataSourceTypeForBubbleSizes can be DataSourceType.Worksheet or DataSourceType.DoubleLiterals");
			}
			class1035_2.DataSourceType = value;
		}
	}

	public DataSourceType DataSourceTypeForValues
	{
		get
		{
			return class1035_3.DataSourceType;
		}
		set
		{
			if (value != 0 && value != DataSourceType.DoubleLiterals)
			{
				throw new InvalidOperationException("DataSourceTypeForValues can be DataSourceType.Worksheet or DataSourceType.DoubleLiterals");
			}
			class1035_3.DataSourceType = value;
		}
	}

	public IDataSourceTypeForErrorBarsCustomValues DataSourceTypeForErrorBarsCustomValues
	{
		get
		{
			if ((ParentSeries.ErrorBarsXFormat != null && ParentSeries.ErrorBarsXFormat.ValueType == ErrorBarValueType.Custom) || (ParentSeries.ErrorBarsYFormat != null && ParentSeries.ErrorBarsYFormat.ValueType == ErrorBarValueType.Custom))
			{
				return dataSourceTypeForErrorBarsCustomValues_0;
			}
			return null;
		}
	}

	ICollection IChartDataPointCollection.AsICollection => this;

	IEnumerable IChartDataPointCollection.AsIEnumerable => this;

	public int Count => list_0.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal ChartSeries ParentSeries => chartSeries_0;

	internal Class309 PPTXUnsupportedProps => class309_0;

	public IChartDataPoint GetOrCreateDataPointByIdx(uint idx)
	{
		if (idx > list_0.Count - 1)
		{
			int num = (int)idx - list_0.Count + 1;
			for (int i = 0; i < num; i++)
			{
				list_0.Add(new ChartDataPoint(this));
			}
		}
		return list_0[(int)idx];
	}

	public void CopyTo(Array array, int arrayIndex)
	{
		((ICollection)list_0).CopyTo(array, arrayIndex);
	}

	IEnumerator<IChartDataPoint> IEnumerable<IChartDataPoint>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IChartDataPoint AddDataPointForLineSeries(IChartDataCell value)
	{
		if (!ChartTypeCharacterizer.IsChartTypeLine(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Line series.");
		}
		return method_0(value);
	}

	public IChartDataPoint AddDataPointForLineSeries(double value)
	{
		if (!ChartTypeCharacterizer.IsChartTypeLine(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Line series.");
		}
		return method_1(value);
	}

	public IChartDataPoint AddDataPointForScatterSeries(IChartDataCell xValue, IChartDataCell yValue)
	{
		if (!ChartTypeCharacterizer.IsChartTypeScatter(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Scatter series.");
		}
		if (DataSourceTypeForXValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.Worksheet and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.Worksheet and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsCell = xValue;
		chartDataPoint.YValue.AsCell = yValue;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForScatterSeries(double xValue, IChartDataCell yValue)
	{
		if (!ChartTypeCharacterizer.IsChartTypeScatter(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Scatter series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.DoubleLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.Worksheet and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralDouble = xValue;
		chartDataPoint.YValue.AsCell = yValue;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForScatterSeries(string xValue, IChartDataCell yValue)
	{
		if (!ChartTypeCharacterizer.IsChartTypeScatter(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Scatter series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.StringLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.StringLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.Worksheet and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralString = xValue;
		chartDataPoint.YValue.AsCell = yValue;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForScatterSeries(IChartDataCell xValue, double yValue)
	{
		if (!ChartTypeCharacterizer.IsChartTypeScatter(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Scatter series.");
		}
		if (DataSourceTypeForXValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.Worksheet and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.DoubleLiterals and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsCell = xValue;
		chartDataPoint.YValue.AsLiteralDouble = yValue;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForScatterSeries(double xValue, double yValue)
	{
		if (!ChartTypeCharacterizer.IsChartTypeScatter(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Scatter series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.DoubleLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.DoubleLiterals and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralDouble = xValue;
		chartDataPoint.YValue.AsLiteralDouble = yValue;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForScatterSeries(string xValue, double yValue)
	{
		if (!ChartTypeCharacterizer.IsChartTypeScatter(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Scatter series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.StringLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.StringLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.DoubleLiterals and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralString = xValue;
		chartDataPoint.YValue.AsLiteralDouble = yValue;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForRadarSeries(IChartDataCell value)
	{
		if (!ChartTypeCharacterizer.IsChartTypeRadar(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Radar series.");
		}
		return method_0(value);
	}

	public IChartDataPoint AddDataPointForRadarSeries(double value)
	{
		if (!ChartTypeCharacterizer.IsChartTypeRadar(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Radar series.");
		}
		return method_1(value);
	}

	public IChartDataPoint AddDataPointForBarSeries(IChartDataCell value)
	{
		if (!ChartTypeCharacterizer.IsChartTypeColumn(chartSeries_0.Type) && !ChartTypeCharacterizer.IsChartTypeBar(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Column or Bar series.");
		}
		return method_0(value);
	}

	public IChartDataPoint AddDataPointForBarSeries(double value)
	{
		if (!ChartTypeCharacterizer.IsChartTypeColumn(chartSeries_0.Type) && !ChartTypeCharacterizer.IsChartTypeBar(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Column or Bar series.");
		}
		return method_1(value);
	}

	public IChartDataPoint AddDataPointForAreaSeries(IChartDataCell value)
	{
		if (!ChartTypeCharacterizer.IsChartTypeArea(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Area series.");
		}
		return method_0(value);
	}

	public IChartDataPoint AddDataPointForAreaSeries(double value)
	{
		if (!ChartTypeCharacterizer.IsChartTypeArea(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Area series.");
		}
		return method_1(value);
	}

	public IChartDataPoint AddDataPointForPieSeries(IChartDataCell value)
	{
		if (!ChartTypeCharacterizer.IsChartTypePie(chartSeries_0.Type) && !ChartTypeCharacterizer.IsChartTypeDoughnut(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Pie or Doughnut series.");
		}
		return method_0(value);
	}

	public IChartDataPoint AddDataPointForPieSeries(double value)
	{
		if (!ChartTypeCharacterizer.IsChartTypePie(chartSeries_0.Type) && !ChartTypeCharacterizer.IsChartTypeDoughnut(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Pie or Doughnut series.");
		}
		return method_1(value);
	}

	public IChartDataPoint AddDataPointForBubbleSeries(IChartDataCell xValue, IChartDataCell yValue, IChartDataCell bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.Worksheet and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.Worksheet and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.Worksheet and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsCell = xValue;
		chartDataPoint.YValue.AsCell = yValue;
		chartDataPoint.BubbleSize.AsCell = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(double xValue, IChartDataCell yValue, IChartDataCell bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.DoubleLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.Worksheet and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.Worksheet and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralDouble = xValue;
		chartDataPoint.YValue.AsCell = yValue;
		chartDataPoint.BubbleSize.AsCell = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(string xValue, IChartDataCell yValue, IChartDataCell bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.StringLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.StringLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.Worksheet and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.Worksheet and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralString = xValue;
		chartDataPoint.YValue.AsCell = yValue;
		chartDataPoint.BubbleSize.AsCell = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(IChartDataCell xValue, double yValue, IChartDataCell bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.Worksheet and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.DoubleLiterals and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.Worksheet and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsCell = xValue;
		chartDataPoint.YValue.AsLiteralDouble = yValue;
		chartDataPoint.BubbleSize.AsCell = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(double xValue, double yValue, IChartDataCell bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.DoubleLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.DoubleLiterals and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.Worksheet and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralDouble = xValue;
		chartDataPoint.YValue.AsLiteralDouble = yValue;
		chartDataPoint.BubbleSize.AsCell = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(string xValue, double yValue, IChartDataCell bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.StringLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.StringLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.DoubleLiterals and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.Worksheet and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralString = xValue;
		chartDataPoint.YValue.AsLiteralDouble = yValue;
		chartDataPoint.BubbleSize.AsCell = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(IChartDataCell xValue, IChartDataCell yValue, double bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.Worksheet and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.Worksheet and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsCell = xValue;
		chartDataPoint.YValue.AsCell = yValue;
		chartDataPoint.BubbleSize.AsLiteralDouble = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(double xValue, IChartDataCell yValue, double bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.DoubleLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.Worksheet and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralDouble = xValue;
		chartDataPoint.YValue.AsCell = yValue;
		chartDataPoint.BubbleSize.AsLiteralDouble = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(string xValue, IChartDataCell yValue, double bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.StringLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.StringLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.Worksheet and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralString = xValue;
		chartDataPoint.YValue.AsCell = yValue;
		chartDataPoint.BubbleSize.AsLiteralDouble = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(IChartDataCell xValue, double yValue, double bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.Worksheet and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.DoubleLiterals and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsCell = xValue;
		chartDataPoint.YValue.AsLiteralDouble = yValue;
		chartDataPoint.BubbleSize.AsLiteralDouble = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(double xValue, double yValue, double bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.DoubleLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.DoubleLiterals and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralDouble = xValue;
		chartDataPoint.YValue.AsLiteralDouble = yValue;
		chartDataPoint.BubbleSize.AsLiteralDouble = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForBubbleSeries(string xValue, double yValue, double bubbleSize)
	{
		if (!ChartTypeCharacterizer.IsChartTypeBubble(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Bubble series.");
		}
		if (DataSourceTypeForXValues != DataSourceType.StringLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForXValues != DataSourceType.StringLiterals and so xValue cannot be of ", xValue.GetType(), " type."));
		}
		if (DataSourceTypeForYValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForYValues != DataSourceType.DoubleLiterals and so yValue cannot be of ", yValue.GetType(), " type."));
		}
		if (DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForBubbleSizes != DataSourceType.DoubleLiterals and so bubbleSize cannot be of ", bubbleSize.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.XValue.AsLiteralString = xValue;
		chartDataPoint.YValue.AsLiteralDouble = yValue;
		chartDataPoint.BubbleSize.AsLiteralDouble = bubbleSize;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public IChartDataPoint AddDataPointForSurfaceSeries(IChartDataCell value)
	{
		if (!ChartTypeCharacterizer.IsChartTypeSurface(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Surface series.");
		}
		return method_0(value);
	}

	public IChartDataPoint AddDataPointForSurfaceSeries(double value)
	{
		if (!ChartTypeCharacterizer.IsChartTypeSurface(chartSeries_0.Type))
		{
			throw new InvalidOperationException("Parent series is not Surface series.");
		}
		return method_1(value);
	}

	internal IChartDataPoint method_0(IChartDataCell value)
	{
		if (DataSourceTypeForValues != 0)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForValues != DataSourceType.Worksheet and so value cannot be of ", value.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.Value.AsCell = value;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	internal IChartDataPoint method_1(double value)
	{
		if (DataSourceTypeForValues != DataSourceType.DoubleLiterals)
		{
			throw new ArgumentException(string.Concat("DataSourceTypeForValues != DataSourceType.DoubleLiterals and so value cannot be of ", value.GetType(), " type."));
		}
		ChartDataPoint chartDataPoint = new ChartDataPoint(this);
		chartDataPoint.Value.AsLiteralDouble = value;
		list_0.Add(chartDataPoint);
		return chartDataPoint;
	}

	public void Clear()
	{
		list_0.Clear();
	}

	public void Remove(IChartDataPoint value)
	{
		if (list_0.IndexOf(value) == -1)
		{
			throw new ArgumentException("The value parameter was not found in the collection.");
		}
		list_0.Remove(value);
	}

	internal ChartDataPointCollection(ChartSeries parentSeries)
	{
		chartSeries_0 = parentSeries;
	}

	internal Class1035 method_2()
	{
		return class1035_0;
	}

	internal Class1035 method_3()
	{
		return class1035_1;
	}

	internal Class1035 method_4()
	{
		return class1035_2;
	}

	internal Class1035 method_5()
	{
		return class1035_3;
	}
}
