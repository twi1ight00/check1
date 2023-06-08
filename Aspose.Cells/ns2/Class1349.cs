using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1349 : IEnumerator
{
	private Row row_0;

	private int int_0 = -1;

	public object Current
	{
		get
		{
			if (int_0 >= 0 && int_0 < row_0.method_0())
			{
				return row_0.GetCellByIndex(int_0);
			}
			return null;
		}
	}

	internal Class1349(Row row_1)
	{
		row_0 = row_1;
		int_0 = -1;
	}

	public bool MoveNext()
	{
		int_0++;
		return int_0 < row_0.method_0();
	}

	public void Reset()
	{
		int_0 = -1;
	}
}
