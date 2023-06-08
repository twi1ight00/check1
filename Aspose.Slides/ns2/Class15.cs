using System;
using System.Collections;
using Aspose.Slides.Charts;

namespace ns2;

internal class Class15 : IEnumerator
{
	private int int_0 = -1;

	private IChartDataPointCollection ichartDataPointCollection_0;

	object IEnumerator.Current => Current;

	public IDataLabel Current
	{
		get
		{
			try
			{
				return ichartDataPointCollection_0[int_0].Label;
			}
			catch (IndexOutOfRangeException)
			{
				throw new InvalidOperationException();
			}
		}
	}

	internal Class15(IChartDataPointCollection dataPoints)
	{
		ichartDataPointCollection_0 = dataPoints;
	}

	public bool MoveNext()
	{
		int_0++;
		return int_0 < ichartDataPointCollection_0.Count;
	}

	public void Reset()
	{
		int_0 = -1;
	}
}
