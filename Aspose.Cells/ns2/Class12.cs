using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class12 : IEnumerator
{
	private bool bool_0;

	private int int_0 = -1;

	private int int_1 = -1;

	private CellArea cellArea_0;

	private ArrayList arrayList_0;

	private RowCollection rowCollection_0;

	public object Current
	{
		get
		{
			if (bool_0)
			{
				return null;
			}
			if (int_0 != -1 && int_1 != -1 && int_0 >= 0 && int_0 < arrayList_0.Count)
			{
				return (Cell)arrayList_0[int_0];
			}
			return null;
		}
	}

	internal Class12(Cells cells_0, CellArea cellArea_1)
	{
		cellArea_0 = cellArea_1;
		rowCollection_0 = cells_0.Rows;
	}

	public bool MoveNext()
	{
		if (bool_0)
		{
			return false;
		}
		if (rowCollection_0.int_0 == 0)
		{
			bool_0 = true;
			return false;
		}
		if (int_1 == -1)
		{
			int_1++;
			while (int_1 < rowCollection_0.Count)
			{
				Row rowByIndex = rowCollection_0.GetRowByIndex(int_1);
				if (rowByIndex.Index >= cellArea_0.StartRow)
				{
					if (rowByIndex.Index > cellArea_0.EndRow)
					{
						break;
					}
					arrayList_0 = rowByIndex.Cells;
					if (arrayList_0 != null && arrayList_0.Count > 0)
					{
						int_0 = 0;
						while (int_0 < arrayList_0.Count)
						{
							Cell cell = (Cell)arrayList_0[int_0];
							if (cell.Column < cellArea_0.StartColumn)
							{
								int_0++;
								continue;
							}
							if (cell.Column > cellArea_0.EndColumn)
							{
								break;
							}
							return true;
						}
					}
				}
				int_1++;
			}
		}
		else
		{
			int_0++;
			bool flag = false;
			if (int_0 < arrayList_0.Count)
			{
				Cell cell2 = (Cell)arrayList_0[int_0];
				if (cell2.Column > cellArea_0.EndColumn)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (!flag)
			{
				return true;
			}
			int_1++;
			while (int_1 < rowCollection_0.Count)
			{
				Row rowByIndex2 = rowCollection_0.GetRowByIndex(int_1);
				if (rowByIndex2.Index >= cellArea_0.StartRow)
				{
					if (rowByIndex2.Index > cellArea_0.EndRow)
					{
						break;
					}
					arrayList_0 = rowByIndex2.Cells;
					if (arrayList_0 != null && arrayList_0.Count > 0)
					{
						int_0 = 0;
						while (int_0 < arrayList_0.Count)
						{
							Cell cell3 = (Cell)arrayList_0[int_0];
							if (cell3.Column < cellArea_0.StartColumn)
							{
								int_0++;
								continue;
							}
							if (cell3.Column > cellArea_0.EndColumn)
							{
								break;
							}
							return true;
						}
					}
				}
				int_1++;
			}
		}
		bool_0 = true;
		return false;
	}

	public void Reset()
	{
		arrayList_0 = null;
		bool_0 = false;
	}
}
