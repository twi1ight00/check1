using System;
using System.Collections;

namespace ns46;

internal class Class996 : IEnumerator
{
	private ArrayList arrayList_0;

	private int int_0 = -1;

	public object Current
	{
		get
		{
			try
			{
				return arrayList_0[int_0];
			}
			catch (IndexOutOfRangeException)
			{
				throw new InvalidOperationException();
			}
		}
	}

	public Class996(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}

	public bool MoveNext()
	{
		int_0++;
		return int_0 < arrayList_0.Count;
	}

	public void Reset()
	{
		int_0 = -1;
	}
}
