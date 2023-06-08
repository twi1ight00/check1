using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Tables;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Collects the <seealso cref="T:Aspose.Cells.Row" /> objects that represent the individual rows in a worksheet.
///       </summary>
public class RowCollection : CollectionBase
{
	internal Cells cells_0;

	internal int int_0;

	internal int int_1 = -1;

	internal int int_2 = -1;

	internal int int_3 = -1;

	/// <summary>
	///       Gets a <seealso cref="T:Aspose.Cells.Row" /> object by given row index. The Row object of given row index will be instantiated if it does not exist before.
	///       </summary>
	public Row this[int rowIndex]
	{
		get
		{
			if (rowIndex < 0)
			{
				throw new ArgumentException();
			}
			int arrIndex = -1;
			if (!method_15(rowIndex, out arrIndex))
			{
				Row row = new Row(rowIndex, this, cells_0.method_1(), cells_0.IsDefaultRowHeightMatched);
				base.InnerList.Insert(arrIndex, row);
				if (method_9() && int_2 >= arrIndex)
				{
					int_2++;
				}
				return row;
			}
			return (Row)base.InnerList[arrIndex];
		}
	}

	internal int EndRow
	{
		get
		{
			if (base.Count == 0)
			{
				return 0;
			}
			return ((Row)base.InnerList[base.InnerList.Count - 1]).int_0;
		}
	}

	internal int MaxDataRow
	{
		get
		{
			for (int num = base.Count - 1; num >= 0; num--)
			{
				Row rowByIndex = GetRowByIndex(num);
				ArrayList cells = rowByIndex.Cells;
				int num2 = cells.Count - 1;
				while (num2 >= 0)
				{
					Cell cell = (Cell)cells[num2];
					if (cell.method_20() == Enum199.const_7)
					{
						num2--;
						continue;
					}
					return rowByIndex.int_0;
				}
			}
			return -1;
		}
	}

	internal int MinDataRow
	{
		get
		{
			for (int i = 0; i < base.Count; i++)
			{
				Row rowByIndex = GetRowByIndex(i);
				ArrayList cells = rowByIndex.Cells;
				int num = cells.Count - 1;
				while (num >= 0)
				{
					Cell cell = (Cell)cells[num];
					if (cell.method_20() == Enum199.const_7)
					{
						num--;
						continue;
					}
					return rowByIndex.int_0;
				}
			}
			return -1;
		}
	}

	internal int MaxDataColumn
	{
		get
		{
			int num = -1;
			for (int i = 0; i < base.Count; i++)
			{
				Row rowByIndex = GetRowByIndex(i);
				ArrayList cells = rowByIndex.Cells;
				int num2 = cells.Count - 1;
				while (num2 >= 0)
				{
					Cell cell = (Cell)cells[num2];
					if (cell.Column < num)
					{
						break;
					}
					if (cell.method_20() == Enum199.const_7)
					{
						num2--;
						continue;
					}
					num = cell.Column;
					break;
				}
			}
			return num;
		}
	}

	internal int MinDataColumn
	{
		get
		{
			int num = int.MaxValue;
			for (int i = 0; i < base.Count; i++)
			{
				Row rowByIndex = GetRowByIndex(i);
				ArrayList cells = rowByIndex.Cells;
				for (int j = 0; j < cells.Count; j++)
				{
					Cell cell = (Cell)cells[j];
					if (cell.method_20() == Enum199.const_7)
					{
						if (cell.Column > num)
						{
							break;
						}
						continue;
					}
					if (cell.Column < num)
					{
						num = cell.Column;
					}
					break;
				}
			}
			if (num == int.MaxValue)
			{
				return -1;
			}
			return num;
		}
	}

	internal RowCollection(Cells cells_1, double double_0, int int_4)
		: base(int_4)
	{
		cells_0 = cells_1;
	}

	internal void method_0(double double_0, bool bool_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Row rowByIndex = GetRowByIndex(i);
			rowByIndex.method_14((ushort)double_0);
			rowByIndex.IsHeightMatched = bool_0;
		}
	}

	/// <summary>
	///       Gets the row object by the position in the list.
	///       </summary>
	/// <param name="index">The position.</param>
	/// <returns>The Row object at given position.</returns>
	public Row GetRowByIndex(int index)
	{
		return (Row)base.InnerList[index];
	}

	internal Row method_1(int int_4, int int_5)
	{
		Row row = new Row(int_4, this, cells_0.method_1(), int_5);
		base.InnerList.Add(row);
		return row;
	}

	internal Row method_2(Row row_0)
	{
		base.InnerList.Add(row_0);
		return row_0;
	}

	internal Row method_3(int int_4)
	{
		return GetRow(int_4, bool_0: true, bool_1: false);
	}

	internal Row method_4(int int_4)
	{
		return GetRowByIndex(int_4);
	}

	internal Row GetRow(int int_4, bool bool_0, bool bool_1)
	{
		Row row = null;
		if (base.Count == 0)
		{
			if (bool_0)
			{
				return null;
			}
			row = new Row(int_4, this, cells_0.method_1(), cells_0.IsDefaultRowHeightMatched);
			base.InnerList.Add(row);
			return row;
		}
		int num = 0;
		int num2 = base.Count - 1;
		int num3 = 0;
		Row row2 = (Row)base.InnerList[num2];
		if (row2.int_0 == int_4)
		{
			return row2;
		}
		if (row2.int_0 < int_4)
		{
			if (bool_0)
			{
				return null;
			}
			row = new Row(int_4, this, cells_0.method_1(), cells_0.IsDefaultRowHeightMatched);
			base.InnerList.Add(row);
			return row;
		}
		while (true)
		{
			if (num <= num2)
			{
				num3 = (num + num2) / 2;
				row2 = (Row)base.InnerList[num3];
				if (row2.int_0 == int_4)
				{
					break;
				}
				if (row2.int_0 < int_4)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3 - 1;
				}
				continue;
			}
			if (bool_0)
			{
				return null;
			}
			row = new Row(int_4, this, cells_0.method_1(), cells_0.IsDefaultRowHeightMatched);
			if (row2.int_0 < int_4)
			{
				num3++;
			}
			base.InnerList.Insert(num3, row);
			if (bool_1 && method_9() && int_2 >= num3)
			{
				int_2++;
			}
			return row;
		}
		return row2;
	}

	internal int method_5(int int_4)
	{
		if (base.Count == 0)
		{
			return -1;
		}
		return method_6(int_4, 0, base.Count - 1);
	}

	internal int method_6(int int_4, int int_5, int int_6)
	{
		if (base.Count == 0)
		{
			return -1;
		}
		int num = 0;
		Row row = (Row)base.InnerList[int_5];
		if (row.int_0 == int_4)
		{
			return int_5;
		}
		if (row.int_0 > int_4)
		{
			return -1;
		}
		row = (Row)base.InnerList[int_6];
		if (row.int_0 == int_4)
		{
			return int_6;
		}
		if (row.int_0 < int_4)
		{
			return -1;
		}
		while (true)
		{
			if (int_5 <= int_6)
			{
				num = (int_5 + int_6) / 2;
				row = (Row)base.InnerList[num];
				if (row.int_0 == int_4)
				{
					break;
				}
				if (row.int_0 < int_4)
				{
					int_5 = num + 1;
				}
				else
				{
					int_6 = num - 1;
				}
				continue;
			}
			return -1;
		}
		return num;
	}

	internal void method_7()
	{
		if (int_1 != -1)
		{
			int_3 = -1;
			int_2 = -1;
			int_1 = -1;
		}
	}

	internal Cell method_8(int int_4)
	{
		if (int_0 != 0 && int_4 < int_0)
		{
			int_1 = int_4;
			if (int_4 == int_0 - 1)
			{
				int_2 = base.InnerList.Count - 1;
				while (int_2 >= 0)
				{
					Row row = (Row)base.InnerList[int_2];
					int num = row.method_0();
					if (num == 0)
					{
						int_2--;
						continue;
					}
					int_3 = num - 1;
					return row.GetCellByIndex(int_3);
				}
			}
			int num2 = 0;
			Row row2;
			while (true)
			{
				if (num2 < base.InnerList.Count)
				{
					row2 = (Row)base.InnerList[num2];
					int num3 = row2.method_0();
					if (num3 != 0)
					{
						if (int_4 < num3)
						{
							break;
						}
						int_4 -= num3;
					}
					num2++;
					continue;
				}
				return null;
			}
			int_2 = num2;
			int_3 = int_4;
			return row2.GetCellByIndex(int_3);
		}
		return null;
	}

	[SpecialName]
	internal bool method_9()
	{
		if (int_1 != -1)
		{
			return int_1 < int_0;
		}
		return false;
	}

	internal void method_10(int int_4, int int_5, int int_6, int int_7)
	{
		cells_0.method_3().Workbook.method_3();
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Row row = (Row)base.InnerList[i];
			if (row.int_0 > int_6)
			{
				break;
			}
			if (row.int_0 < int_4)
			{
				continue;
			}
			if (int_2 >= i)
			{
				method_7();
			}
			int num = -1;
			int num2 = -1;
			for (int j = 0; j < row.method_0(); j++)
			{
				Cell cellByIndex = row.GetCellByIndex(j);
				if (cellByIndex.Column > int_7)
				{
					break;
				}
				if (cellByIndex.Column >= int_5)
				{
					if (num == -1)
					{
						num = j;
					}
					num2 = j;
				}
			}
			if (num != -1)
			{
				row.RemoveRange(num, num2 - num + 1);
			}
		}
		ListObjectCollection listObjects = cells_0.method_3().ListObjects;
		if (listObjects.Count == 0)
		{
			return;
		}
		for (int k = 0; k < listObjects.Count; k++)
		{
			ListObject listObject = listObjects[k];
			if (listObject.StartRow >= int_4 && listObject.EndRow <= int_6 && listObject.StartColumn >= int_5 && listObject.EndColumn <= int_7)
			{
				listObjects.RemoveAt(k);
			}
		}
	}

	/// <summary>
	///       Clear all rows and cells.
	///       </summary>
	public new void Clear()
	{
		cells_0.method_19().Workbook.method_3();
		base.InnerList.Clear();
		int_0 = 0;
		int_3 = -1;
		int_2 = -1;
		int_1 = -1;
	}

	internal void method_11(Cell cell_0, Row row_0)
	{
		if (row_0.method_27())
		{
			cell_0.method_37(row_0.method_10());
			return;
		}
		ColumnCollection columns = cells_0.Columns;
		int column = cell_0.Column;
		int num = columns.method_7(column);
		if (num != -1)
		{
			Column columnByIndex = columns.GetColumnByIndex(num);
			if (columnByIndex.method_10())
			{
				cell_0.method_37(columnByIndex.method_5());
			}
		}
		else
		{
			cell_0.int_1 = columns.method_1(cell_0.Column);
		}
	}

	internal Cell GetCell(int int_4, int int_5, bool bool_0, bool bool_1, bool bool_2)
	{
		Cells cells = cells_0;
		Cell cell = null;
		if (int_0 == 0)
		{
			if (bool_0)
			{
				return null;
			}
			Row row = GetRow(int_4, bool_0: false, bool_1: false);
			cell = row.method_5(int_5);
			if (bool_1)
			{
				method_11(cell, row);
			}
			int_0 = 1;
			return cell;
		}
		int arrIndex = -1;
		Row row2 = null;
		if (!method_15(int_4, out arrIndex))
		{
			if (bool_0)
			{
				return null;
			}
			row2 = new Row(int_4, this, cells_0.method_1(), cells.IsDefaultRowHeightMatched);
			base.InnerList.Insert(arrIndex, row2);
			cell = row2.method_5(int_5);
			int_0++;
			if (bool_1)
			{
				method_11(cell, row2);
			}
			if (bool_2 && method_9() && arrIndex <= int_2)
			{
				int_1++;
				int_2++;
			}
			return cell;
		}
		row2 = (Row)base.InnerList[arrIndex];
		return row2.GetCell(this, int_5, bool_0, bool_1, bool_2 && int_1 >= 0, arrIndex);
	}

	internal void method_12(int int_4, int int_5)
	{
		int arrIndex = -1;
		if (!method_15(int_4, out arrIndex))
		{
			return;
		}
		Row rowByIndex = GetRowByIndex(arrIndex);
		int num = rowByIndex.method_4(int_5);
		if (num == -1)
		{
			return;
		}
		rowByIndex.method_3(num);
		if (!method_9())
		{
			method_7();
		}
		else if (int_2 > arrIndex)
		{
			int_1--;
		}
		else
		{
			if (int_2 != arrIndex)
			{
				return;
			}
			if (int_3 > num)
			{
				int_3--;
				int_1--;
			}
			else
			{
				if (int_3 != num || rowByIndex.method_0() != num)
				{
					return;
				}
				if (rowByIndex.method_0() != 0)
				{
					int_3--;
					int_1--;
					return;
				}
				arrIndex++;
				while (true)
				{
					if (arrIndex < base.Count)
					{
						rowByIndex = GetRowByIndex(arrIndex);
						if (rowByIndex.method_0() != 0)
						{
							break;
						}
						arrIndex++;
						continue;
					}
					method_7();
					return;
				}
				int_3 = 0;
			}
		}
	}

	/// <summary>
	///       Remove the row at the specified index
	///       </summary>
	/// <param name="index">zero-based row index</param>
	public new void RemoveAt(int index)
	{
		Row row = (Row)base.InnerList[index];
		base.InnerList.RemoveAt(index);
		method_7();
		int_0 -= row.method_0();
	}

	internal Cell GetCellByIndex(int int_4)
	{
		if (int_4 >= 0 && int_4 < int_0)
		{
			if (method_9() && int_4 != 0)
			{
				int num = int_4 - int_1;
				if (num == 0)
				{
					return ((Row)base.InnerList[int_2]).GetCellByIndex(int_3);
				}
				if (num < 0)
				{
					int_1 = int_4;
					Row row = (Row)base.InnerList[int_2];
					if (int_3 + num >= 0)
					{
						int_3 += num;
						return row.GetCellByIndex(int_3);
					}
					num += int_3 + 1;
					int_2--;
					while (int_2 >= 0)
					{
						row = (Row)base.InnerList[int_2];
						num += row.method_0();
						if (num <= 0)
						{
							int_2--;
							continue;
						}
						int_3 = num - 1;
						return row.GetCellByIndex(int_3);
					}
				}
				else
				{
					int_1 = int_4;
					Row row2 = (Row)base.InnerList[int_2];
					int num2 = row2.method_0() - int_3 - 1;
					if (num2 >= num)
					{
						int_3 += num;
						return row2.GetCellByIndex(int_3);
					}
					num -= num2;
					int_2++;
					while (int_2 < base.InnerList.Count)
					{
						row2 = (Row)base.InnerList[int_2];
						if (row2.method_0() != 0)
						{
							if (num <= row2.method_0())
							{
								int_3 = num - 1;
								return row2.GetCellByIndex(int_3);
							}
							num -= row2.method_0();
						}
						int_2++;
					}
				}
				return null;
			}
			return method_8(int_4);
		}
		return null;
	}

	internal bool method_13(int row, int column, out int arrRowIndex, out int arrColumnIndex)
	{
		arrColumnIndex = -1;
		arrRowIndex = -1;
		if (!method_15(row, out arrRowIndex))
		{
			return false;
		}
		int index = arrRowIndex;
		arrColumnIndex = ((Row)base.InnerList[index]).method_4(column);
		return arrColumnIndex != -1;
	}

	internal int method_14(int int_4, int int_5)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			Row row = (Row)base.InnerList[i];
			if (row.int_0 > int_5)
			{
				break;
			}
			if (row.int_0 >= int_4)
			{
				return i;
			}
		}
		return -1;
	}

	internal bool method_15(int row, out int arrIndex)
	{
		if (base.InnerList.Count == 0)
		{
			arrIndex = 0;
			return false;
		}
		int num = 0;
		int num2 = 0;
		int num3 = base.InnerList.Count - 1;
		Row row2 = (Row)base.InnerList[num3];
		if (row2.int_0 == row)
		{
			arrIndex = num3;
			return true;
		}
		if (row2.int_0 < row)
		{
			arrIndex = num3 + 1;
			return false;
		}
		if (method_9())
		{
			row2 = (Row)base.InnerList[int_2];
			if (row2.int_0 == row)
			{
				arrIndex = int_2;
				return true;
			}
			if (row2.int_0 > row)
			{
				num3 = int_2;
			}
			else
			{
				num2 = int_2;
			}
		}
		while (true)
		{
			if (num2 <= num3)
			{
				num = (num2 + num3) / 2;
				int num4 = row - ((Row)base.InnerList[num]).int_0;
				if (num4 == 0)
				{
					break;
				}
				if (num4 < 0)
				{
					num3 = num - 1;
				}
				else
				{
					num2 = num + 1;
				}
				continue;
			}
			if (row > ((Row)base.InnerList[num]).int_0)
			{
				arrIndex = num + 1;
			}
			else
			{
				arrIndex = num;
			}
			return false;
		}
		arrIndex = num;
		return true;
	}

	internal void method_16(int int_4, int int_5, int int_6, RowCollection rowCollection_0)
	{
		if (int_4 == -1)
		{
			int row = rowCollection_0.GetRowByIndex(0).int_0;
			method_15(row, out int_4);
			base.InnerList.InsertRange(int_4, rowCollection_0.InnerList);
		}
		else
		{
			base.InnerList.RemoveRange(int_4, int_5 - int_4 + 1);
			base.InnerList.InsertRange(int_4, rowCollection_0.InnerList);
		}
		int_0 -= int_6;
		for (int i = 0; i < rowCollection_0.Count; i++)
		{
			int_0 += rowCollection_0.GetRowByIndex(i).method_0();
		}
	}

	internal void InsertRows(int int_4, int int_5, Class739 class739_0)
	{
		method_7();
		Hashtable hashtable = new Hashtable();
		CellArea cellArea = default(CellArea);
		cellArea.StartRow = int_4;
		cellArea.EndRow = int_4 + int_5 - 1;
		cellArea.StartColumn = 0;
		cellArea.EndColumn = 16383;
		for (int i = 0; i < base.Count; i++)
		{
			Row rowByIndex = GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_45())
				{
					cellByIndex.method_72();
				}
				else if (cellByIndex.IsInArray)
				{
					cells_0.method_19().Formula.method_14(cellByIndex.method_41(), out var row, out var column);
					long num = ((long)column << 32) | row;
					if (hashtable[num] == null)
					{
						Cell cell = cells_0[row, column];
						CellArea cellArea2 = cell.method_50().CellArea;
						if (int_4 > cellArea2.StartRow && int_4 <= cellArea2.EndRow)
						{
							throw new CellsException(ExceptionType.InvalidOperator, "You can not change part of an array.");
						}
						hashtable.Add(num, true);
					}
				}
				if (cellByIndex.method_20() != Enum199.const_7 && rowByIndex.int_0 + int_5 > 1048575)
				{
					throw new CellsException(ExceptionType.InvalidOperator, "Aspose.Cells cannot shift nonblank cell off the worksheet.");
				}
			}
			if (rowByIndex.int_0 + int_5 > 1048575)
			{
				RemoveAt(i--);
			}
		}
		for (int k = 0; k < base.Count; k++)
		{
			Row rowByIndex2 = GetRowByIndex(k);
			if (rowByIndex2.int_0 >= int_4)
			{
				rowByIndex2.method_23(rowByIndex2.int_0 + int_5);
			}
			for (int l = 0; l < rowByIndex2.method_0(); l++)
			{
				Cell cellByIndex2 = rowByIndex2.GetCellByIndex(l);
				cellByIndex2.InsertRows(int_4, int_5, cells_0.method_3(), bool_0: true);
			}
		}
		if (class739_0.bool_0 && base.Count != 0 && int_4 > 0)
		{
			Row row2 = GetRow(int_4 - 1, bool_0: true, bool_1: false);
			if (row2 != null)
			{
				for (int m = 0; m < int_5; m++)
				{
					Row row3 = GetRow(int_4 + m, bool_0: false, bool_1: false);
					row3.CopyData(row2);
				}
			}
		}
		if (class739_0.bool_1)
		{
			method_17(int_4, int_5);
		}
	}

	private void method_17(int int_4, int int_5)
	{
		if (int_4 <= 0)
		{
			return;
		}
		Hashtable hashtable = new Hashtable();
		Row row = GetRow(int_4 - 1, bool_0: true, bool_1: false);
		if (row != null)
		{
			for (int i = 0; i < row.method_0(); i++)
			{
				Cell cellByIndex = row.GetCellByIndex(i);
				hashtable.Add(cellByIndex.Column, cellByIndex.method_35());
			}
		}
		if (hashtable.Count == 0)
		{
			return;
		}
		for (int j = 0; j < int_5; j++)
		{
			row = GetRow(int_4 + j, bool_0: false, bool_1: false);
			foreach (int key in hashtable.Keys)
			{
				row.GetCell(key).method_37((int)hashtable[key]);
			}
		}
	}

	internal void DeleteColumns(int int_4, int int_5)
	{
		method_7();
		method_18();
		int num = int_4 + int_5 - 1;
		for (int i = 0; i < base.Count; i++)
		{
			Row rowByIndex = GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.Column >= int_4 && cellByIndex.Column <= num)
				{
					rowByIndex.method_3(j--);
				}
				else
				{
					cellByIndex.InsertColumns(int_4, -int_5, cells_0.method_3(), bool_0: true);
				}
			}
		}
	}

	internal void DeleteRows(int int_4, int int_5)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Row rowByIndex = GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_20() == Enum199.const_4)
				{
					cellByIndex.method_72();
				}
			}
		}
		int num = -1;
		int num2 = -1;
		int num3 = 0;
		for (int k = 0; k < base.Count; k++)
		{
			Row rowByIndex2 = GetRowByIndex(k);
			if (rowByIndex2.int_0 >= int_4)
			{
				if (rowByIndex2.int_0 < int_4 + int_5)
				{
					if (num == -1)
					{
						num = k;
					}
					num2 = k;
					num3 += GetRowByIndex(k).method_0();
					continue;
				}
				rowByIndex2.method_23(rowByIndex2.int_0 - int_5);
			}
			for (int l = 0; l < rowByIndex2.method_0(); l++)
			{
				Cell cellByIndex2 = rowByIndex2.GetCellByIndex(l);
				cellByIndex2.InsertRows(int_4, -int_5, cells_0.method_3(), bool_0: true);
			}
		}
		if (num != -1)
		{
			int_0 -= num3;
			base.InnerList.RemoveRange(num, num2 - num + 1);
		}
	}

	internal void method_18()
	{
		for (int i = 0; i < base.Count; i++)
		{
			Row rowByIndex = GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_45())
				{
					cellByIndex.method_72();
				}
			}
		}
	}

	internal void Copy(RowCollection rowCollection_0, CopyOptions copyOptions_0)
	{
		for (int i = 0; i < rowCollection_0.Count; i++)
		{
			Row rowByIndex = rowCollection_0.GetRowByIndex(i);
			Row row = method_1(rowByIndex.int_0, rowByIndex.Cells.Count);
			row.CopyData(rowByIndex, copyOptions_0);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				Cell cell = row.method_5(cellByIndex.Column);
				cell.method_56(cellByIndex, copyOptions_0);
			}
		}
		int_0 = rowCollection_0.int_0;
	}

	internal void CopyRows(RowCollection rowCollection_0, int int_4, int int_5, int int_6)
	{
		method_7();
		Cells cells = rowCollection_0.cells_0;
		if (rowCollection_0 != this)
		{
			for (int i = 0; i < cells.Columns.Count; i++)
			{
				Column columnByIndex = cells.Columns.GetColumnByIndex(i);
				if (!columnByIndex.method_10())
				{
					continue;
				}
				Column column_ = cells_0.Columns.method_5(columnByIndex.Index);
				if (!columnByIndex.method_11(column_))
				{
					for (int j = 0; j < int_6; j++)
					{
						cells.GetCell(int_4 + j, columnByIndex.Index, bool_2: false);
					}
				}
			}
		}
		if (rowCollection_0 == this && int_4 < int_5 && int_4 + int_6 > int_5)
		{
			for (int num = int_6 - 1; num >= 0; num--)
			{
				int num2 = rowCollection_0.method_5(int_4 + num);
				if (num2 != -1)
				{
					Row rowByIndex = rowCollection_0.GetRowByIndex(num2);
					int int_7 = num + int_5;
					Row row = GetRow(int_7, bool_0: false, bool_1: true);
					row.CopyData(rowByIndex);
					for (int k = 0; k < rowByIndex.method_0(); k++)
					{
						Cell cellByIndex = rowByIndex.GetCellByIndex(k);
						Cell cell = row.GetCell(cellByIndex.Column, bool_1: false, bool_2: true);
						cell.method_10(cellByIndex);
					}
				}
				else
				{
					num2 = method_5(int_5 + num);
					if (num2 != -1)
					{
						Row rowByIndex2 = GetRowByIndex(num2);
						rowByIndex2.method_21(bool_1: false);
						rowByIndex2.Clear();
					}
				}
			}
			return;
		}
		for (int l = 0; l < int_6; l++)
		{
			int num3 = rowCollection_0.method_5(int_4 + l);
			if (num3 != -1)
			{
				Row rowByIndex3 = rowCollection_0.GetRowByIndex(num3);
				int int_8 = l + int_5;
				Row row2 = GetRow(int_8, bool_0: false, bool_1: true);
				row2.CopyData(rowByIndex3);
				for (int m = 0; m < rowByIndex3.method_0(); m++)
				{
					Cell cellByIndex2 = rowByIndex3.GetCellByIndex(m);
					Cell cell2 = row2.GetCell(cellByIndex2.Column, bool_1: false, bool_2: true);
					cell2.method_10(cellByIndex2);
				}
			}
			else
			{
				num3 = method_5(int_5 + l);
				if (num3 != -1)
				{
					Row rowByIndex4 = GetRowByIndex(num3);
					rowByIndex4.method_21(bool_1: false);
					rowByIndex4.Clear();
				}
			}
		}
	}

	internal void CopyColumns(RowCollection rowCollection_0, int int_4, int int_5, int int_6)
	{
		Row row = null;
		method_7();
		for (int i = 0; i < base.Count; i++)
		{
			row = GetRowByIndex(i);
			for (int j = 0; j < row.method_0(); j++)
			{
				Cell cell = (Cell)row.Cells[j];
				if (cell.Column >= int_5)
				{
					if (cell.Column >= int_5 + int_6)
					{
						break;
					}
					row.method_3(j--);
				}
			}
		}
		for (int k = 0; k < rowCollection_0.Count; k++)
		{
			row = rowCollection_0.GetRowByIndex(k);
			if (row.method_27())
			{
				for (int l = 0; l < int_6; l++)
				{
					Cell cellOrNull = row.GetCellOrNull(int_4 + l);
					if (cellOrNull != null)
					{
						Cell cell2 = GetCell(cellOrNull.Row, int_5 + l, bool_0: false, bool_1: false, bool_2: true);
						cell2.method_9(cellOrNull);
					}
					else if (row.method_27())
					{
						Cell cell3 = GetCell(row.int_0, int_5 + l, bool_0: false, bool_1: false, bool_2: true);
						if (cells_0.method_19() == rowCollection_0.cells_0.method_19())
						{
							cell3.method_37(row.method_10());
						}
						else
						{
							cell3.method_30(row.Style);
						}
					}
				}
				continue;
			}
			for (int m = 0; m < row.method_0(); m++)
			{
				Cell cell4 = (Cell)row.Cells[m];
				if (cell4.Column >= int_4)
				{
					if (cell4.Column >= int_4 + int_6)
					{
						break;
					}
					Cell cell5 = GetCell(cell4.Row, int_5 + cell4.Column - int_4, bool_0: false, bool_1: false, bool_2: true);
					cell5.method_9(cell4);
				}
			}
		}
	}

	internal void InsertColumns(int int_4, int int_5)
	{
		method_7();
		for (int i = 0; i < base.Count; i++)
		{
			Row rowByIndex = GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.IsFormula)
				{
					cellByIndex.method_72();
				}
				if (cellByIndex.Column + int_5 > 16383)
				{
					if (cellByIndex.method_20() != Enum199.const_7)
					{
						throw new CellsException(ExceptionType.InvalidOperator, "Aspose.Cells cannot shift nonblank cell off the worksheet.");
					}
					rowByIndex.method_3(j--);
				}
			}
		}
		for (int k = 0; k < base.Count; k++)
		{
			Row rowByIndex2 = GetRowByIndex(k);
			for (int l = 0; l < rowByIndex2.method_0(); l++)
			{
				Cell cellByIndex2 = rowByIndex2.GetCellByIndex(l);
				cellByIndex2.InsertColumns(int_4, int_5, cells_0.method_3(), bool_0: true);
			}
		}
	}

	internal void InsertRange(CellArea cellArea_0, int int_4, ShiftType shiftType_0, Worksheet worksheet_0, bool bool_0)
	{
		method_18();
		int num = -1;
		method_7();
		ColumnCollection columns = cells_0.Columns;
		switch (shiftType_0)
		{
		case ShiftType.Right:
		{
			for (int num5 = 0; num5 < columns.Count; num5++)
			{
				Column columnByIndex = columns.GetColumnByIndex(num5);
				if (columnByIndex.Index < cellArea_0.StartColumn)
				{
					continue;
				}
				if (columnByIndex.method_10() && cellArea_0.StartColumn + int_4 <= columnByIndex.Index)
				{
					int int_6 = columnByIndex.Index - int_4;
					num = columns.method_9(int_6, (num5 - int_4 >= 0) ? (num5 - int_4) : 0, num5 - 1);
					if (num == -1)
					{
						method_20(cellArea_0, null, int_6);
					}
				}
				if (columnByIndex.Index + int_4 <= 255)
				{
					num = columns.method_9(columnByIndex.Index + int_4, num5 + 1, (num5 + int_4 >= columns.Count) ? (columns.Count - 1) : (num5 + int_4));
					Column column_ = null;
					if (num != -1)
					{
						column_ = columns.GetColumnByIndex(num);
					}
					if (!columnByIndex.method_11(column_))
					{
						method_20(cellArea_0, columnByIndex, columnByIndex.Index);
					}
				}
			}
			for (num = 0; num < base.Count; num++)
			{
				Row rowByIndex = GetRowByIndex(num);
				for (int num6 = 0; num6 < rowByIndex.method_0(); num6++)
				{
					Cell cellByIndex4 = rowByIndex.GetCellByIndex(num6);
					if (cellByIndex4.IsArrayHeader)
					{
						CellArea cellArea = cellByIndex4.method_50().CellArea;
						if (cellArea_0.StartRow <= cellArea.StartRow && cellArea_0.EndRow >= cellArea.EndRow && cellArea_0.StartColumn <= cellArea.StartColumn)
						{
							cellArea.StartColumn += int_4;
							cellArea.EndColumn += int_4;
							cellByIndex4.method_50().method_0(cellArea);
						}
					}
				}
			}
			for (num = 0; num < base.Count; num++)
			{
				Row rowByIndex2 = GetRowByIndex(num);
				for (int num7 = 0; num7 < rowByIndex2.method_0(); num7++)
				{
					Cell cellByIndex5 = rowByIndex2.GetCellByIndex(num7);
					cellByIndex5.method_13(cellArea_0, int_4, worksheet_0, bool_0: true);
				}
			}
			break;
		}
		default:
			throw new CellsException(ExceptionType.InvalidData, "Invalid shift option.");
		case ShiftType.Down:
		{
			Column[] array = new Column[cellArea_0.EndColumn - cellArea_0.StartColumn + 1];
			for (int i = cellArea_0.StartColumn; i <= cellArea_0.EndColumn; i++)
			{
				num = columns.method_7(i);
				if (num != -1)
				{
					array[i - cellArea_0.StartColumn] = columns.GetColumnByIndex(num);
				}
			}
			int endRow = EndRow;
			for (int num2 = endRow; num2 >= 0; num2--)
			{
				Row row = GetRow(num2, bool_0: true, bool_1: false);
				if (num2 < cellArea_0.StartRow)
				{
					if (row != null)
					{
						for (int j = 0; j < row.method_0(); j++)
						{
							Cell cellByIndex = row.GetCellByIndex(j);
							cellByIndex.method_11(cellArea_0, int_4, worksheet_0, bool_0: true);
						}
					}
				}
				else
				{
					int int_5 = num2 + int_4;
					Row row2 = GetRow(int_5, bool_0: false, bool_1: true);
					if (row == null)
					{
						if (row2 != null && row2.method_27())
						{
							for (int k = cellArea_0.StartColumn; k < cellArea_0.EndColumn; k++)
							{
								Cell cell = row2.GetCell(k, bool_1: false, bool_2: true);
								cell.method_37(15);
								cell.method_6();
							}
						}
					}
					else
					{
						int num3 = -1;
						int num4 = -1;
						if (row.method_29(row2))
						{
							for (int l = 0; l < row.method_0(); l++)
							{
								Cell cellByIndex2 = row.GetCellByIndex(l);
								if (cellByIndex2.Column >= cellArea_0.StartColumn && cellByIndex2.Column <= cellArea_0.EndColumn)
								{
									if (num3 == -1)
									{
										num3 = l;
									}
									num4 = l;
									cellByIndex2.method_11(cellArea_0, int_4, worksheet_0, bool_0: true);
									Cell cell2 = row2.GetCell(cellByIndex2.Column);
									cell2.method_54(cellByIndex2);
								}
								else
								{
									cellByIndex2.method_11(cellArea_0, int_4, worksheet_0, bool_0: true);
								}
							}
							if (num3 != -1)
							{
								row.RemoveRange(num3, num4 - num3 + 1);
							}
						}
						else
						{
							for (int m = cellArea_0.StartColumn; m <= cellArea_0.EndColumn; m++)
							{
								Cell cellOrNull = row.GetCellOrNull(m);
								Cell cell3 = row2.GetCell(m);
								if (cellOrNull == null)
								{
									cell3.method_37(row.method_27() ? row.method_10() : 15);
									continue;
								}
								cellOrNull.method_11(cellArea_0, int_4, worksheet_0, bool_0: true);
								cell3.method_54(cellOrNull);
							}
							row.method_2(cellArea_0.StartColumn, cellArea_0.EndColumn);
							for (int n = 0; n < row.method_0(); n++)
							{
								Cell cellByIndex3 = row.GetCellByIndex(n);
								cellByIndex3.method_11(cellArea_0, int_4, worksheet_0, bool_0: true);
							}
						}
					}
				}
			}
			break;
		}
		}
	}

	internal int DeleteRange(int int_4, int int_5, int int_6, int int_7, ShiftType shiftType_0, Worksheet worksheet_0, bool bool_0)
	{
		method_7();
		for (int i = 0; i < base.Count; i++)
		{
			Row rowByIndex = GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				Cell cellByIndex = rowByIndex.GetCellByIndex(j);
				if (cellByIndex.method_20() == Enum199.const_4)
				{
					cellByIndex.method_72();
				}
			}
		}
		int num = 0;
		CellArea cellArea_ = default(CellArea);
		cellArea_.StartRow = int_4;
		cellArea_.StartColumn = int_5;
		cellArea_.EndRow = int_6;
		cellArea_.EndColumn = int_7;
		switch (shiftType_0)
		{
		case ShiftType.Left:
		{
			num = int_7 - int_5 + 1;
			ColumnCollection columns = cells_0.Columns;
			if (columns.Count > 0)
			{
				for (int num8 = columns.Count - 1; num8 >= 0; num8--)
				{
					Column columnByIndex = columns.GetColumnByIndex(num8);
					if (columnByIndex.Index < int_5)
					{
						break;
					}
					if (columnByIndex.method_10())
					{
						if (columnByIndex.Index > int_7)
						{
							int num9 = columnByIndex.Index - num;
							int num10 = columns.method_9(num9, 0, num8);
							if (num10 != -1)
							{
								Column columnByIndex2 = columns.GetColumnByIndex(num10);
								if (!columnByIndex.method_11(columnByIndex2))
								{
									method_20(cellArea_, columnByIndex, columnByIndex.Index);
								}
							}
							else
							{
								method_20(cellArea_, columnByIndex, columnByIndex.Index);
							}
						}
						int num11 = ((num8 + num < columns.Count) ? (num8 + num) : (columns.Count - 1));
						int num12 = columnByIndex.Index + num;
						if (num12 <= 16383)
						{
							int num13 = columns.method_9(num12, num8, num11);
							if (num13 == -1)
							{
								method_20(cellArea_, null, num12);
							}
							else
							{
								Column columnByIndex3 = columns.GetColumnByIndex(num13);
								if (!columnByIndex3.method_10())
								{
									method_20(cellArea_, null, num12);
								}
							}
						}
					}
				}
			}
			for (int m = 0; m < base.Count; m++)
			{
				Row rowByIndex6 = GetRowByIndex(m);
				int num14 = -1;
				int num15 = -1;
				for (int n = 0; n < rowByIndex6.method_0(); n++)
				{
					Cell cellByIndex3 = rowByIndex6.GetCellByIndex(n);
					if (cellByIndex3.method_14(cellArea_, num, cells_0.method_3(), bool_0: true))
					{
						if (num14 == -1)
						{
							num14 = n;
						}
						num15 = n;
					}
				}
				if (num14 != -1)
				{
					rowByIndex6.RemoveRange(num14, num15 - num14 + 1);
				}
			}
			break;
		}
		case ShiftType.None:
			cells_0.ClearContents(int_4, int_5, int_6, int_7);
			return num;
		case ShiftType.Up:
		{
			num = int_6 - int_4 + 1;
			for (int num2 = base.Count - 1; num2 >= 0; num2--)
			{
				Row rowByIndex2 = GetRowByIndex(num2);
				if (rowByIndex2.int_0 <= int_4)
				{
					break;
				}
				if (rowByIndex2.method_27())
				{
					if (rowByIndex2.int_0 > int_6)
					{
						int int_8 = rowByIndex2.int_0 - num;
						int num3 = method_6(int_8, 0, num2);
						if (num3 != -1)
						{
							Row rowByIndex3 = GetRowByIndex(num3);
							if (!rowByIndex2.method_29(rowByIndex3))
							{
								method_19(cellArea_, rowByIndex2, rowByIndex2.int_0);
							}
						}
						else
						{
							method_19(cellArea_, rowByIndex2, rowByIndex2.int_0);
						}
					}
					int int_9 = ((num2 + num < base.Count) ? (num2 + num) : (base.Count - 1));
					int int_10 = rowByIndex2.int_0 + num;
					int num4 = method_6(int_10, num2, int_9);
					if (num4 == -1)
					{
						method_19(cellArea_, null, int_10);
					}
					else
					{
						Row rowByIndex4 = GetRowByIndex(num4);
						if (!rowByIndex4.method_27())
						{
							method_19(cellArea_, null, int_10);
						}
					}
				}
			}
			for (int k = 0; k < base.Count; k++)
			{
				Row rowByIndex5 = GetRowByIndex(k);
				int count = base.Count;
				Row row = null;
				int num5 = -1;
				int num6 = -1;
				int num7 = 0;
				for (int l = 0; l < rowByIndex5.method_0(); l++)
				{
					Cell cellByIndex2 = rowByIndex5.GetCellByIndex(l);
					switch (cellByIndex2.method_12(cellArea_, num, cells_0.method_3(), bool_0: true))
					{
					case 1:
					{
						if (num5 == -1)
						{
							num5 = l;
						}
						num6 = l;
						if (row == null)
						{
							row = GetRow(rowByIndex5.int_0 - num, bool_0: false, bool_1: true);
							if (count != base.Count)
							{
								k++;
							}
						}
						Cell cell = row.GetCell(cellByIndex2.Column, bool_1: false, bool_2: true);
						cell.method_37(cellByIndex2.method_36());
						cell.object_0 = cellByIndex2.object_0;
						break;
					}
					case 2:
						if (num5 == -1)
						{
							num5 = l;
						}
						num6 = l;
						break;
					}
				}
				if (num5 != -1)
				{
					rowByIndex5.RemoveRange(num5, num6 - num5 + 1);
				}
			}
			break;
		}
		}
		return num;
	}

	private void method_19(CellArea cellArea_0, Row row_0, int int_4)
	{
		for (int i = cellArea_0.StartColumn; i <= cellArea_0.EndColumn; i++)
		{
			Cell cell = GetCell(int_4, i, bool_0: false, bool_1: true, bool_2: true);
			if (cell.method_36() == -1)
			{
				if (row_0 == null)
				{
					cell.method_37(15);
				}
				else if (row_0.method_27())
				{
					cell.method_37(row_0.method_10());
				}
			}
		}
	}

	private void method_20(CellArea cellArea_0, Column column_0, int int_4)
	{
		for (int i = cellArea_0.StartRow; i <= cellArea_0.EndRow; i++)
		{
			Cell cell = GetCell(i, int_4, bool_0: false, bool_1: true, bool_2: true);
			if (cell.method_36() == -1)
			{
				if (column_0 == null)
				{
					cell.method_37(15);
				}
				else if (column_0.method_10())
				{
					cell.method_37(column_0.method_5());
				}
			}
		}
	}

	internal void RemoveExternalLinks(ArrayList arrayList_0)
	{
		WorksheetCollection worksheetCollection = cells_0.method_19();
		Cell cell = null;
		for (int i = 0; i < base.Count; i++)
		{
			Row rowByIndex = GetRowByIndex(i);
			for (int j = 0; j < rowByIndex.method_0(); j++)
			{
				cell = rowByIndex.GetCellByIndex(j);
				if (!cell.IsFormula)
				{
					continue;
				}
				if (cell.method_50() != null)
				{
					Class1348 @class = cell.method_50();
					byte[] formula = @class.Formula;
					if (!Class1674.smethod_12(formula, -1, -1, worksheetCollection))
					{
						continue;
					}
					CellArea cellArea = @class.CellArea;
					if (@class.method_1())
					{
						for (int k = cellArea.StartRow; k <= cellArea.EndRow; k++)
						{
							for (int l = cellArea.StartColumn; l <= cellArea.EndColumn; l++)
							{
								cell = GetCell(k, l, bool_0: true, bool_1: false, bool_2: false);
								cell?.PutValue(cell.Value);
							}
						}
						continue;
					}
					int row = cell.Row;
					int column = cell.Column;
					for (int m = cellArea.StartRow; m <= cellArea.EndRow; m++)
					{
						Row row2 = GetRow(m, bool_0: true, bool_1: false);
						if (row2 == null)
						{
							continue;
						}
						for (int n = cellArea.StartColumn; n <= cellArea.EndColumn; n++)
						{
							cell = row2.GetCellOrNull(n);
							if (cell == null || !cell.IsFormula)
							{
								continue;
							}
							formula = cell.method_41();
							if (worksheetCollection.Formula.method_13(1, formula))
							{
								worksheetCollection.Formula.method_14(formula, out var row3, out var column2);
								if (row3 == row && column2 == column)
								{
									cell.PutValue(cell.Value);
								}
							}
						}
					}
				}
				else
				{
					byte[] byte_ = cell.method_41();
					if (Class1674.smethod_12(byte_, -1, -1, worksheetCollection))
					{
						cell.PutValue(cell.Value);
					}
				}
			}
		}
	}

	internal void method_21()
	{
		Row row = null;
		Cell cell = null;
		bool flag = false;
		bool flag2 = false;
		method_7();
		int num = 0;
		for (int num2 = base.Count - 1; num2 >= 0; num2--)
		{
			row = GetRowByIndex(num2);
			if (row.int_0 <= 65535)
			{
				if (!flag)
				{
					if (num2 != base.Count - 1)
					{
						int_0 -= num;
						base.InnerList.RemoveRange(num2 + 1, base.Count - num2 - 1);
					}
					flag = true;
				}
				flag2 = false;
				int num3 = row.method_0() - 1;
				while (num3 >= 0)
				{
					cell = row.GetCellByIndex(num3);
					if (cell.Column > 255)
					{
						num3--;
						continue;
					}
					flag2 = true;
					if (num3 != row.method_0() - 1)
					{
						num += row.method_0() - num3 - 1;
						row.RemoveRange(num3 + 1, row.method_0() - num3 - 1);
					}
					break;
				}
				if (!flag2)
				{
					num += row.method_0();
					row.Clear();
				}
			}
			else
			{
				num += row.method_0();
				row.Clear();
			}
		}
		if (!flag)
		{
			Clear();
		}
	}

	internal int method_22(int int_4)
	{
		int num = base.Count - 1;
		Row rowByIndex;
		while (true)
		{
			if (num >= 0)
			{
				rowByIndex = GetRowByIndex(num);
				if (rowByIndex.method_1())
				{
					break;
				}
				num--;
				continue;
			}
			return int_4;
		}
		return rowByIndex.int_0;
	}
}
