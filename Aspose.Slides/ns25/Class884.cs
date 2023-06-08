using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Charts;

namespace ns25;

internal class Class884 : IEnumerable, IEnumerable<IChartDataPoint>, ICollection<IChartDataPoint>
{
	private IChartSeriesGroup ichartSeriesGroup_0;

	private List<IChartDataPoint> list_0 = new List<IChartDataPoint>();

	public IChartDataPoint this[int index] => list_0[index];

	public int Count => list_0.Count;

	public bool IsReadOnly => ((ICollection<IChartDataPoint>)list_0).IsReadOnly;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	public void Add(IChartDataPoint dataPoint)
	{
		list_0.Add(dataPoint);
	}

	public void Clear()
	{
		list_0.Clear();
	}

	public bool Contains(IChartDataPoint item)
	{
		return list_0.Contains(item);
	}

	public void CopyTo(IChartDataPoint[] array, int arrayIndex)
	{
		list_0.CopyTo(array, arrayIndex);
	}

	public void Add(int dataPointIndex)
	{
		list_0.Add(ichartSeriesGroup_0[0].DataPoints[dataPointIndex]);
	}

	public bool Remove(IChartDataPoint dataPoint)
	{
		return list_0.Remove(dataPoint);
	}

	public void Remove(int dataPointIndex)
	{
		list_0.Remove(ichartSeriesGroup_0[0].DataPoints[dataPointIndex]);
	}

	public void method_0()
	{
		list_0.Clear();
	}

	public void CopyTo(Array array, int index)
	{
		((ICollection)list_0).CopyTo(array, index);
	}

	IEnumerator<IChartDataPoint> IEnumerable<IChartDataPoint>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public Class884(IChartSeriesGroup parentSeriesGroup)
	{
		ichartSeriesGroup_0 = parentSeriesGroup;
	}
}
