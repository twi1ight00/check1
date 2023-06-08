using System;
using System.Collections;
using System.Collections.Generic;
using Aspose.Slides.Charts;

namespace ns2;

internal class Class12 : IDisposable, IEnumerator, IEnumerator<IChartDataCell>
{
	private int int_0 = -1;

	private List<ChartDataCell> list_0;

	object IEnumerator.Current => Current;

	public ChartDataCell Current
	{
		get
		{
			try
			{
				return list_0[int_0];
			}
			catch (IndexOutOfRangeException ex)
			{
				throw new InvalidOperationException(ex.Message, ex);
			}
		}
	}

	IChartDataCell IEnumerator<IChartDataCell>.Current => Current;

	internal Class12(List<ChartDataCell> cellsCellsArray)
	{
		list_0 = cellsCellsArray;
	}

	public bool MoveNext()
	{
		int_0++;
		return int_0 < list_0.Count;
	}

	public void Reset()
	{
		int_0 = -1;
	}

	public void Dispose()
	{
	}
}
