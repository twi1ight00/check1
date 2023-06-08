using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1722 : IEnumerator
{
	private RowCollection rowCollection_0;

	private int int_0;

	public object Current
	{
		get
		{
			if (int_0 >= 0 && int_0 < rowCollection_0.Count)
			{
				return rowCollection_0.GetRowByIndex(int_0);
			}
			return null;
		}
	}

	internal Class1722(RowCollection rowCollection_1)
	{
		rowCollection_0 = rowCollection_1;
		int_0 = -1;
	}

	public bool MoveNext()
	{
		int_0++;
		return int_0 < rowCollection_0.Count;
	}

	public void Reset()
	{
		int_0 = -1;
	}
}
