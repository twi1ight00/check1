using System;
using Aspose.Cells;

namespace ns25;

internal class Class521
{
	internal readonly int int_0;

	internal readonly short short_0;

	internal readonly int int_1;

	internal Workbook workbook_0;

	private int[] int_2;

	private int int_3 = 16384;

	private int int_4 = 15;

	internal Class521(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		if (workbook_1.method_24())
		{
			int_0 = 1048575;
			short_0 = 16383;
			int_1 = int.MaxValue;
		}
		else
		{
			int_0 = 65535;
			short_0 = 255;
			int_1 = 32767;
		}
	}

	public void method_0(Worksheet worksheet_0)
	{
		int_2 = null;
		int_3 = 16384;
		int_4 = 15;
		ColumnCollection columns = worksheet_0.Cells.Columns;
		Column column_ = worksheet_0.Cells.Columns.column_0;
		if (column_ != null && column_.method_10())
		{
			int_3 = column_.Index;
			int_4 = column_.method_5();
		}
		int count = columns.Count;
		if (count <= 0)
		{
			return;
		}
		count = Math.Min(columns.GetColumnByIndex(count - 1).Index, short_0) + 1;
		int_2 = new int[count];
		for (int i = 0; i < int_2.Length; i++)
		{
			int_2[i] = 15;
			if (i >= int_3)
			{
				int_2[i] = int_4;
			}
		}
		int num;
		for (num = columns.Count - 1; num > -1; num--)
		{
			Column columnByIndex = columns.GetColumnByIndex(num);
			if (columnByIndex.Index < count)
			{
				break;
			}
		}
		num++;
		for (int j = 0; j < num; j++)
		{
			Column columnByIndex2 = columns.GetColumnByIndex(j);
			if (columnByIndex2.method_5() != -1)
			{
				int_2[columnByIndex2.Index] = columnByIndex2.method_5();
			}
		}
	}

	public int method_1(int int_5)
	{
		if (int_2 != null && int_5 < int_2.Length)
		{
			return int_2[int_5];
		}
		if (int_5 >= int_3)
		{
			return int_4;
		}
		return 15;
	}
}
