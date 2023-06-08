using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1384 : IEnumerator
{
	private RowCollection rowCollection_0;

	private ArrayList arrayList_0;

	private int int_0 = -1;

	private int int_1 = -1;

	public object Current
	{
		get
		{
			if (int_1 >= 0 && int_1 < rowCollection_0.Count && int_0 >= 0 && int_0 < arrayList_0.Count)
			{
				return (Cell)arrayList_0[int_0];
			}
			return null;
		}
	}

	internal Class1384(RowCollection rowCollection_1)
	{
		rowCollection_0 = rowCollection_1;
	}

	public bool MoveNext()
	{
		if (rowCollection_0.int_0 == 0)
		{
			return false;
		}
		if (int_1 == -1)
		{
			int_1++;
			while (int_1 < rowCollection_0.Count)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(int_1);
				arrayList_0 = rowByIndex.Cells;
				if (arrayList_0 == null || arrayList_0.Count <= 0)
				{
					int_1++;
					continue;
				}
				int_0 = 0;
				return true;
			}
		}
		else
		{
			int_0++;
			if (int_0 < arrayList_0.Count)
			{
				return true;
			}
			int_1++;
			while (int_1 < rowCollection_0.Count)
			{
				Row rowByIndex2 = rowCollection_0.GetRowByIndex(int_1);
				arrayList_0 = rowByIndex2.Cells;
				if (arrayList_0 == null || arrayList_0.Count <= 0)
				{
					int_1++;
					continue;
				}
				int_0 = 0;
				return true;
			}
		}
		return false;
	}

	public void Reset()
	{
		int_1 = -1;
		int_0 = -1;
		arrayList_0 = null;
	}
}
