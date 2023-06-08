using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Charts;

namespace ns2;

internal class Class13 : ICollection, IEnumerable, IEnumerable<IChartSeriesGroup>, IChartSeriesGroupCollection
{
	private List<IChartSeriesGroup> list_0 = new List<IChartSeriesGroup>();

	public IChartSeriesGroup this[IChartSeries ofSeries] => ofSeries.ParentSeriesGroup;

	public IChartSeriesGroup this[int groupIndex] => list_0[groupIndex];

	ICollection IChartSeriesGroupCollection.AsICollection => this;

	public int Count => list_0.Count;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	IEnumerable IChartSeriesGroupCollection.AsIEnumerable => this;

	internal Class13()
	{
	}

	void ICollection.CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}

	public IEnumerator<IChartSeriesGroup> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	internal void method_0(ChartSeries series)
	{
		if (series.ParentSeriesGroup == null)
		{
			method_2(series);
		}
		else if (!ChartTypeCharacterizer.smethod_3(series, series.ParentSeriesGroup))
		{
			method_1(series);
			method_2(series);
		}
	}

	internal void method_1(ChartSeries series)
	{
		IChartSeriesGroup parentSeriesGroup = series.ParentSeriesGroup;
		((Class14)parentSeriesGroup.Series).Remove(series);
		if (parentSeriesGroup.Series.Count == 0)
		{
			list_0.Remove(parentSeriesGroup);
		}
	}

	private void method_2(ChartSeries series)
	{
		CombinableSeriesTypesGroup combinableSeriesTypesGroup = ChartTypeCharacterizer.smethod_2(series.Type);
		if (combinableSeriesTypesGroup != CombinableSeriesTypesGroup.PieChart && combinableSeriesTypesGroup != CombinableSeriesTypesGroup.Pie3DChart)
		{
			foreach (ChartSeriesGroup item in list_0)
			{
				if (ChartTypeCharacterizer.smethod_3(series, item))
				{
					((Class14)item.Series).Add(series);
					return;
				}
			}
		}
		Add(series);
	}

	internal ChartSeriesGroup Add(ChartSeries series)
	{
		ChartSeriesGroup chartSeriesGroup = new ChartSeriesGroup(series);
		list_0.Add(chartSeriesGroup);
		return chartSeriesGroup;
	}
}
