using System;
using System.Collections;
using System.Collections.Generic;

namespace Aspose.Slides.Charts;

public class TrendlineCollection : IEnumerable, IEnumerable<ITrendline>, ITrendlineCollection
{
	private List<ITrendline> list_0 = new List<ITrendline>();

	private ChartSeries chartSeries_0;

	public ITrendline this[int index] => list_0[index];

	public int Count => list_0.Count;

	IEnumerable ITrendlineCollection.AsIEnumerable => this;

	internal TrendlineCollection(ChartSeries parent)
	{
		chartSeries_0 = parent;
	}

	public ITrendline Add(TrendlineType trendlineType)
	{
		Trendline trendline = new Trendline(chartSeries_0);
		trendline.TrendlineType = trendlineType;
		list_0.Add(trendline);
		return trendline;
	}

	[Obsolete("Use Add(TrendlineType) method instead. Property will be removed after 01.09.2013.")]
	public void Add(ITrendline value)
	{
		if (value != null)
		{
			list_0.Add(value);
		}
	}

	public void Remove(ITrendline value)
	{
		list_0.Remove(value);
	}

	IEnumerator<ITrendline> IEnumerable<ITrendline>.GetEnumerator()
	{
		return list_0.GetEnumerator();
	}

	public IEnumerator GetEnumerator()
	{
		return list_0.GetEnumerator();
	}
}
