using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Charts;

namespace ns2;

internal class Class14 : ICollection, IEnumerable, IEnumerable<IChartSeries>, IChartSeriesReadonlyCollection
{
	private List<IChartSeries> list_0 = new List<IChartSeries>();

	private ChartSeriesGroup chartSeriesGroup_0;

	public IChartSeries this[int index] => list_0[index];

	ICollection IChartSeriesReadonlyCollection.AsICollection => this;

	public int Count => list_0.Count;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => this;

	IEnumerable IChartSeriesReadonlyCollection.AsIEnumerable => this;

	void ICollection.CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}

	public IEnumerator<IChartSeries> GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	internal Class14(ChartSeriesGroup parentGroup)
	{
		chartSeriesGroup_0 = parentGroup;
	}

	internal void Add(ChartSeries series)
	{
		series.method_4(chartSeriesGroup_0);
		list_0.Add(series);
	}

	internal void Remove(ChartSeries series)
	{
		series.method_4(null);
		list_0.Remove(series);
	}
}
