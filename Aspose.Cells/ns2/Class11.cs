using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class11 : Interface0
{
	private IEnumerator ienumerator_0;

	private IEnumerator ienumerator_1;

	internal Class11(Worksheet worksheet_0)
	{
		ienumerator_0 = worksheet_0.Cells.Rows.GetEnumerator();
	}

	public Row NextRow()
	{
		if (ienumerator_0 != null && ienumerator_0.MoveNext())
		{
			Row row = (Row)ienumerator_0.Current;
			ienumerator_1 = row.GetEnumerator();
			return row;
		}
		return null;
	}

	public Cell NextCell()
	{
		if (ienumerator_1 != null && ienumerator_1.MoveNext())
		{
			return (Cell)ienumerator_1.Current;
		}
		return null;
	}
}
