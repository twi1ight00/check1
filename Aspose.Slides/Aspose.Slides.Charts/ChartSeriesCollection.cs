using System;
using System.Collections;
using System.Collections.Generic;
using ns2;

namespace Aspose.Slides.Charts;

public class ChartSeriesCollection : ICollection, IEnumerable, IEnumerable<IChartSeries>, IChartSeriesCollection
{
	private Chart chart_0;

	private List<IChartSeries> list_0 = new List<IChartSeries>();

	public IChartSeries this[int index] => list_0[index];

	public int Count => list_0.Count;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	ICollection IChartSeriesCollection.AsICollection => this;

	IEnumerable IChartSeriesCollection.AsIEnumerable => this;

	internal ChartSeriesCollection(IChart mParent)
	{
		chart_0 = (Chart)mParent;
	}

	public IChartSeries Add(ChartType type)
	{
		ChartSeries chartSeries = new ChartSeries(chart_0, type);
		bool value = method_0(chartSeries);
		chartSeries.method_3(value);
		list_0.Add(chartSeries);
		chartSeries.method_0();
		return chartSeries;
	}

	public IChartSeries Insert(int index, ChartType type)
	{
		ChartSeries chartSeries = new ChartSeries(chart_0, type);
		bool value = method_0(chartSeries);
		chartSeries.method_3(value);
		list_0.Insert(index, chartSeries);
		chartSeries.method_0();
		return chartSeries;
	}

	private bool method_0(ChartSeries series)
	{
		if (list_0.Count > 0)
		{
			IChartSeries chartSeries = list_0[0];
			bool flag = ChartTypeCharacterizer.Is3DChart(chartSeries.Type);
			for (int i = 1; i < list_0.Count; i++)
			{
				chartSeries = list_0[i];
			}
			if (flag != ChartTypeCharacterizer.Is3DChart(series.Type))
			{
				if (flag)
				{
					throw new CannotCombine2DAnd3DChartsException("Cannot combine 2D and 3D chart types (the series to be added is 2D and present series is/are 3D).");
				}
				throw new CannotCombine2DAnd3DChartsException("Cannot combine 2D and 3D chart types (the series to be added is 3D and present series is/are 2D).");
			}
		}
		if (((AxesManager)chart_0.Axes).method_7(series.Type, secondaryAxes: false))
		{
			return false;
		}
		if (!((AxesManager)chart_0.Axes).method_7(series.Type, secondaryAxes: true))
		{
			throw new AxesCompositionNotCombinableException("Some chart types cannot be combined with other chart types. Select a different chart type. Details: axes composition of the series to be added is not combinable with present axes composition in chart. So series of this type cannot be added to this chart. Preferred axes composition for the series to be added is \"" + ChartTypeCharacterizer.smethod_1(ChartTypeCharacterizer.smethod_0(series.Type)) + "\".");
		}
		return true;
	}

	internal void method_1(int index, IChartSeries series)
	{
		if (list_0.Contains(series))
		{
			list_0.Remove(series);
			list_0.Insert(index, series);
		}
	}

	public IChartSeries Add(IChartDataCell cellWithSeriesName, ChartType type)
	{
		foreach (ChartSeries item in list_0)
		{
			if (item.Name.DataSourceType == DataSourceType.Worksheet && item.Name.AsCells.Count == 1 && item.Name.AsCells[0].Equals(cellWithSeriesName))
			{
				return item;
			}
		}
		IChartSeries chartSeries2 = Add(type);
		chartSeries2.Name.SetFromOneCell(cellWithSeriesName);
		return chartSeries2;
	}

	public IChartSeries Add(IChartCellCollection cellsWithSeriesName, ChartType type)
	{
		foreach (ChartSeries item in list_0)
		{
			if (item.Name.DataSourceType == DataSourceType.Worksheet && item.Name.AsCells.Count == cellsWithSeriesName.Count && item.Name.AsCells.GetConcatenatedValuesFromCells().Equals(cellsWithSeriesName.GetConcatenatedValuesFromCells()))
			{
				return item;
			}
		}
		IChartSeries chartSeries2 = Add(type);
		chartSeries2.Name.AsCells = cellsWithSeriesName;
		return chartSeries2;
	}

	public IChartSeries Add(string name, ChartType type)
	{
		ChartDataCell chartDataCell = ((ChartDataWorkbook)chart_0.ChartData.ChartDataWorkbook).method_3();
		chartDataCell.Value = name;
		return Add(chartDataCell, type);
	}

	internal IChartSeries method_2(ChartType type, IChartSeriesGroup seriesGroup, bool plotOnSecondAxis)
	{
		ChartSeries chartSeries = new ChartSeries(chart_0, type);
		chartSeries.method_3(plotOnSecondAxis);
		list_0.Add(chartSeries);
		((AxesManager)chart_0.Axes).method_1();
		((Class14)seriesGroup.Series).Add(chartSeries);
		return chartSeries;
	}

	internal IChartSeries method_3(ChartType type, bool plotOnSecondAxis)
	{
		ChartSeries chartSeries = new ChartSeries(chart_0, type);
		chartSeries.method_3(plotOnSecondAxis);
		list_0.Add(chartSeries);
		((AxesManager)chart_0.Axes).method_1();
		((Class13)chart_0.ChartData.SeriesGroups).Add(chartSeries);
		return chartSeries;
	}

	public int IndexOf(IChartSeries value)
	{
		return list_0.IndexOf(value);
	}

	public void Remove(IChartSeries value)
	{
		if (list_0.IndexOf(value) == -1)
		{
			throw new ArgumentException("The value parameter was not found in the collection.");
		}
		list_0.Remove(value);
		((AxesManager)chart_0.Axes).method_1();
		((Class13)chart_0.ChartData.SeriesGroups).method_1((ChartSeries)value);
	}

	public void RemoveAt(int index)
	{
		Remove(list_0[index]);
	}

	public void Clear()
	{
		while (list_0.Count > 0)
		{
			RemoveAt(list_0.Count - 1);
		}
	}

	IEnumerator<IChartSeries> IEnumerable<IChartSeries>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}
}
