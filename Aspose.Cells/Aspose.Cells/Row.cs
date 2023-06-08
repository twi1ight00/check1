using System.Collections;
using System.Runtime.CompilerServices;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Represents a single row in a worksheet.
///       </summary>
public class Row
{
	private ArrayList arrayList_0;

	internal int int_0;

	private int int_1 = 983296;

	private short short_0;

	private bool bool_0;

	internal RowCollection rowCollection_0;

	/// <summary>
	///       Indicates whether the row contains any data
	///       </summary>
	public bool IsBlank
	{
		get
		{
			if (arrayList_0.Count == 0)
			{
				return true;
			}
			int num = 0;
			while (true)
			{
				if (num < arrayList_0.Count)
				{
					Cell cell = (Cell)arrayList_0[num];
					if (!cell.IsBlank)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}
	}

	/// <summary>
	///       Gets the cell.
	///       </summary>
	/// <param name="column">The column index</param>
	/// <returns>
	/// </returns>
	public Cell this[int column]
	{
		get
		{
			rowCollection_0.method_7();
			return GetCell(column, bool_1: false, bool_2: true);
		}
	}

	/// <summary>
	///       Gets and sets the row height in unit of Points.
	///       </summary>
	public double Height
	{
		get
		{
			if (IsHidden)
			{
				return 0.0;
			}
			return (float)short_0 / 20f;
		}
		set
		{
			if (value <= 0.0)
			{
				IsHidden = true;
			}
			short_0 = (short)(value * 20.0 + 0.5);
			IsHeightMatched = false;
		}
	}

	/// <summary>
	///       Indicates whether the row is hidden.
	///       </summary>
	public bool IsHidden
	{
		get
		{
			return (int_1 & 0x20) != 0;
		}
		set
		{
			if (value)
			{
				int_1 |= 32;
				return;
			}
			int_1 &= -33;
			if (short_0 == 0)
			{
				short_0 = (short)rowCollection_0.cells_0.method_0();
			}
		}
	}

	/// <summary>
	///       Gets the index of this row.
	///       </summary>
	public int Index => int_0;

	/// <summary>
	///       Gets the group level of the row.
	///       </summary>
	public byte GroupLevel => method_24();

	/// <summary>
	///       Indicates that row height and default font height matches
	///       </summary>
	public bool IsHeightMatched
	{
		get
		{
			return (int_1 & 0x40) == 0;
		}
		set
		{
			if (value)
			{
				int_1 &= -65;
			}
			else
			{
				int_1 |= 64;
			}
		}
	}

	/// <summary>
	///       Represents the style of this row.
	///       </summary>
	/// <remarks> You have to call Row.ApplyStyle() method to save your changing with the row style,
	///       otherwise it will not effect.
	///       </remarks>
	public Style Style
	{
		get
		{
			Style style = new Style(method_28().method_2());
			if (!method_20())
			{
				style.Copy(method_28().method_2().DefaultStyle);
			}
			else
			{
				int num = method_10();
				if (num < method_28().method_2().method_58().Count)
				{
					style.GetStyle(method_28().method_2(), num);
				}
				else
				{
					style.Copy(method_28().method_2().DefaultStyle);
				}
			}
			return style;
		}
	}

	/// <summary>
	///       Gets the first cell in the row.
	///       </summary>
	public Cell FirstCell
	{
		get
		{
			if (method_0() == 0)
			{
				return null;
			}
			return (Cell)arrayList_0[0];
		}
	}

	/// <summary>
	///       Gets the last cell in the row.
	///       </summary>
	public Cell LastCell
	{
		get
		{
			if (method_0() == 0)
			{
				return null;
			}
			return (Cell)arrayList_0[method_0() - 1];
		}
	}

	public Cell LastDataCell
	{
		get
		{
			if (method_0() == 0)
			{
				return null;
			}
			int num = method_0() - 1;
			Cell cell;
			while (true)
			{
				if (num >= 0)
				{
					cell = (Cell)arrayList_0[num];
					if (!cell.IsBlank)
					{
						break;
					}
					num--;
					continue;
				}
				return null;
			}
			return cell;
		}
	}

	internal ArrayList Cells => arrayList_0;

	internal double InnerHeight => (double)(int)method_13() / 20.0;

	internal int StartColumn
	{
		get
		{
			if (method_0() == 0)
			{
				return 0;
			}
			return ((Cell)arrayList_0[0]).Column;
		}
	}

	internal int EndColumn
	{
		get
		{
			if (method_0() == 0)
			{
				return 0;
			}
			return ((Cell)arrayList_0[method_0() - 1]).Column;
		}
	}

	[SpecialName]
	internal int method_0()
	{
		return arrayList_0.Count;
	}

	[SpecialName]
	internal bool method_1()
	{
		return arrayList_0.Count > 0;
	}

	internal void method_2(int int_2, int int_3)
	{
		int num = -1;
		int num2 = -1;
		for (int i = 0; i < method_0(); i++)
		{
			Cell cellByIndex = GetCellByIndex(i);
			if (cellByIndex.Column >= int_2 && cellByIndex.Column <= int_3)
			{
				if (num == -1)
				{
					num = i;
				}
				num2 = i;
			}
		}
		if (num != -1)
		{
			method_28().Workbook.method_3();
			arrayList_0.RemoveRange(num, num2 - num + 1);
			rowCollection_0.int_0 -= num2 - num + 1;
		}
	}

	internal void RemoveRange(int int_2, int int_3)
	{
		method_28().Workbook.method_3();
		arrayList_0.RemoveRange(int_2, int_3);
		rowCollection_0.int_0 -= int_3;
	}

	internal void method_3(int int_2)
	{
		if (method_28().Workbook.bool_0)
		{
			((Cell)arrayList_0[int_2]).method_6();
		}
		arrayList_0.RemoveAt(int_2);
		rowCollection_0.int_0--;
	}

	internal void Clear()
	{
		method_28().Workbook.method_3();
		rowCollection_0.int_0 -= arrayList_0.Count;
		arrayList_0.Clear();
	}

	internal int method_4(int int_2)
	{
		if (arrayList_0.Count == 0)
		{
			return -1;
		}
		int num = arrayList_0.Count - 1;
		_ = (Cell)arrayList_0[num];
		int num2 = 0;
		int num3 = 0;
		while (true)
		{
			if (num3 <= num)
			{
				num2 = (num3 + num) / 2;
				int num4 = int_2 - ((Cell)arrayList_0[num2]).Column;
				if (num4 == 0)
				{
					break;
				}
				if (num4 < 0)
				{
					num = num2 - 1;
				}
				else
				{
					num3 = num2 + 1;
				}
				continue;
			}
			return -1;
		}
		return num2;
	}

	/// <summary>
	///       Get the cell by specific index in the list.
	///       </summary>
	/// <param name="index">The position.</param>
	/// <returns>The Cell object.</returns>
	public Cell GetCellByIndex(int index)
	{
		return (Cell)arrayList_0[index];
	}

	internal Cell method_5(int int_2)
	{
		Cell cell = new Cell(int_0, (short)int_2, rowCollection_0.cells_0);
		arrayList_0.Add(cell);
		return cell;
	}

	internal void method_6(Cell cell_0)
	{
		arrayList_0.Add(cell_0);
	}

	/// <summary>
	///       Gets the cells enumerator
	///       </summary>
	/// <returns>The cells enumerator</returns>
	public IEnumerator GetEnumerator()
	{
		return new Class1349(this);
	}

	internal Cell GetCell(int int_2, bool bool_1, bool bool_2)
	{
		int num = -1;
		int num2 = 0;
		int num3 = arrayList_0.Count - 1;
		Cell cell = null;
		if (arrayList_0.Count != 0 && int_2 <= ((Cell)arrayList_0[num3]).Column)
		{
			Cell cell2 = null;
			while (true)
			{
				if (num2 <= num3)
				{
					num = (num2 + num3) / 2;
					cell2 = (Cell)arrayList_0[num];
					if (cell2.Column == int_2)
					{
						break;
					}
					if (cell2.Column > int_2)
					{
						num3 = num - 1;
					}
					else
					{
						num2 = num + 1;
					}
					continue;
				}
				if (bool_1)
				{
					return null;
				}
				if (int_2 > ((Cell)arrayList_0[num]).Column)
				{
					num++;
				}
				cell = new Cell(int_0, (short)int_2, rowCollection_0.cells_0);
				arrayList_0.Insert(num, cell);
				if (bool_2)
				{
					rowCollection_0.int_0++;
				}
				return cell;
			}
			return cell2;
		}
		if (bool_1)
		{
			return null;
		}
		cell = new Cell(int_0, (short)int_2, rowCollection_0.cells_0);
		arrayList_0.Add(cell);
		if (bool_2)
		{
			rowCollection_0.int_0++;
		}
		return cell;
	}

	internal int method_7(int int_2, int int_3, int int_4)
	{
		if (int_3 <= int_2 && arrayList_0.Count != 0)
		{
			int column = ((Cell)arrayList_0[int_3]).Column;
			if (column == int_2)
			{
				return int_3;
			}
			if (column > int_2)
			{
				return -int_3 - 1;
			}
			if (int_4 > int_2)
			{
				int_4 = int_2;
			}
			if (int_3 == int_4)
			{
				return -int_4 - 2;
			}
			column = ((Cell)arrayList_0[int_4]).Column;
			if (column == int_2)
			{
				return int_4;
			}
			if (column < int_2)
			{
				return -int_4 - 2;
			}
			int_3++;
			int_4--;
			if (int_4 < int_3)
			{
				return -int_3 - 1;
			}
			int num = -1;
			while (true)
			{
				if (int_3 <= int_4)
				{
					num = (int_3 + int_4) / 2;
					column = ((Cell)arrayList_0[num]).Column;
					if (column == int_2)
					{
						break;
					}
					if (column > int_2)
					{
						int_4 = num - 1;
					}
					else
					{
						int_3 = num + 1;
					}
					continue;
				}
				if (num < int_3)
				{
					num++;
				}
				return -num - 1;
			}
			return num;
		}
		return -int_3 - 1;
	}

	internal Cell GetCell(int int_2)
	{
		return GetCell(int_2, bool_1: false, bool_2: true);
	}

	internal Cell GetCell(RowCollection rowCollection_1, int int_2, bool bool_1, bool bool_2, bool bool_3, int int_3)
	{
		if (arrayList_0.Count == 0)
		{
			if (bool_1)
			{
				return null;
			}
			Cell cell = new Cell(int_0, (short)int_2, rowCollection_1.cells_0);
			arrayList_0.Add(cell);
			rowCollection_1.int_0++;
			if (bool_2)
			{
				rowCollection_1.method_11(cell, this);
			}
			if (bool_3 && int_3 < rowCollection_1.int_2)
			{
				rowCollection_1.int_1++;
			}
			return cell;
		}
		int num = arrayList_0.Count - 1;
		Cell cell2 = (Cell)arrayList_0[num];
		if (int_2 == cell2.Column)
		{
			return cell2;
		}
		if (int_2 > cell2.Column)
		{
			if (bool_1)
			{
				return null;
			}
			Cell cell3 = new Cell(int_0, (short)int_2, rowCollection_0.cells_0);
			arrayList_0.Add(cell3);
			rowCollection_1.int_0++;
			if (bool_2)
			{
				rowCollection_1.method_11(cell3, this);
			}
			if (bool_3 && int_3 < rowCollection_1.int_2)
			{
				rowCollection_1.int_1++;
			}
			return cell3;
		}
		int num2 = 0;
		int num3 = -1;
		while (true)
		{
			if (num2 <= num)
			{
				num3 = (num2 + num) / 2;
				cell2 = (Cell)arrayList_0[num3];
				if (cell2.Column == int_2)
				{
					break;
				}
				if (cell2.Column > int_2)
				{
					num = num3 - 1;
				}
				else
				{
					num2 = num3 + 1;
				}
				continue;
			}
			if (bool_1)
			{
				return null;
			}
			if (int_2 > ((Cell)arrayList_0[num3]).Column)
			{
				num3++;
			}
			Cell cell4 = new Cell(int_0, (short)int_2, rowCollection_0.cells_0);
			arrayList_0.Insert(num3, cell4);
			rowCollection_1.int_0++;
			if (bool_2)
			{
				rowCollection_1.method_11(cell4, this);
			}
			if (bool_3)
			{
				if (int_3 < rowCollection_1.int_2)
				{
					rowCollection_1.int_1++;
				}
				else if (int_3 == rowCollection_1.int_2 && num3 <= rowCollection_1.int_3)
				{
					rowCollection_1.int_1++;
					rowCollection_1.int_3++;
				}
			}
			return cell4;
		}
		return cell2;
	}

	/// <summary>
	///       Gets the cell or null in the specific index.
	///       </summary>
	/// <param name="column">The column index</param>
	/// <returns>Returns the cell object if the cell exists.
	///       Or returns null if the cell object does not exist.</returns>
	public Cell GetCellOrNull(int column)
	{
		return GetCell(column, bool_1: true, bool_2: false);
	}

	[SpecialName]
	internal int method_8()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_9(int int_2)
	{
		int_1 = int_2;
	}

	[SpecialName]
	internal int method_10()
	{
		if (!method_20())
		{
			return 15;
		}
		return (int)((int_1 & 0xFFFF0000u) >> 16);
	}

	[SpecialName]
	internal void method_11(int int_2)
	{
		int_1 &= 65535;
		int num = int_2;
		if (num == -1)
		{
			num = 15;
		}
		int_1 |= num << 16;
		if (!method_20())
		{
			method_21(num != 15);
		}
	}

	internal void method_12(ushort ushort_0)
	{
		short_0 = (short)ushort_0;
		if (short_0 > 8190)
		{
			short_0 = 8190;
		}
	}

	[SpecialName]
	internal ushort method_13()
	{
		return (ushort)short_0;
	}

	[SpecialName]
	internal void method_14(ushort ushort_0)
	{
		if (ushort_0 > 0)
		{
			IsHidden = false;
			short_0 = (short)ushort_0;
		}
		else
		{
			IsHidden = true;
		}
	}

	[SpecialName]
	internal bool method_15()
	{
		return bool_0;
	}

	[SpecialName]
	internal void method_16(bool bool_1)
	{
		bool_0 = bool_1;
	}

	internal void method_17(bool bool_1)
	{
		if (bool_1)
		{
			int_1 |= 32;
		}
		else
		{
			int_1 &= -33;
		}
	}

	[SpecialName]
	internal bool method_18()
	{
		return (int_1 & 0x10) != 0;
	}

	[SpecialName]
	internal void method_19(bool bool_1)
	{
		if (bool_1)
		{
			int_1 |= 16;
		}
		else
		{
			int_1 &= -17;
		}
	}

	[SpecialName]
	internal bool method_20()
	{
		return (int_1 & 0x80) != 0;
	}

	[SpecialName]
	internal void method_21(bool bool_1)
	{
		if (bool_1)
		{
			int_1 |= 128;
		}
		else
		{
			int_1 &= -129;
		}
	}

	internal Row(int int_2, RowCollection rowCollection_1, double double_0, int int_3)
	{
		int_0 = int_2;
		short_0 = (short)double_0;
		rowCollection_0 = rowCollection_1;
		int_3 = ((int_3 < 16) ? 16 : int_3);
		arrayList_0 = new ArrayList(int_3);
	}

	internal Row(int int_2, RowCollection rowCollection_1, double double_0, bool bool_1)
	{
		int_0 = int_2;
		short_0 = (short)double_0;
		rowCollection_0 = rowCollection_1;
		arrayList_0 = new ArrayList(16);
		IsHeightMatched = bool_1;
	}

	internal Row(RowCollection rowCollection_1)
	{
		rowCollection_0 = rowCollection_1;
		arrayList_0 = new ArrayList(1);
	}

	internal void method_22()
	{
		short_0 = (short)rowCollection_0.cells_0.method_1();
		int_1 = 983296;
	}

	internal void method_23(int int_2)
	{
		int_0 = int_2;
	}

	[SpecialName]
	internal byte method_24()
	{
		return (byte)((uint)int_1 & 0xFu);
	}

	[SpecialName]
	internal void method_25(byte byte_0)
	{
		int_1 &= -16;
		int_1 |= byte_0;
	}

	internal void SetStyle(Style style_0)
	{
		method_21(bool_1: true);
		method_11(method_28().method_2().method_59(style_0));
	}

	internal Style method_26()
	{
		if (!method_20())
		{
			return method_28().method_2().DefaultStyle;
		}
		int num = method_10();
		if (num < method_28().method_2().method_58().Count)
		{
			return method_28().method_2().method_58()[num];
		}
		return method_28().method_2().DefaultStyle;
	}

	[SpecialName]
	internal bool method_27()
	{
		if (method_20())
		{
			return method_10() != 15;
		}
		return false;
	}

	internal void CopyData(Row row_0)
	{
		int_1 = row_0.int_1;
		if (row_0.method_27() && method_28().method_2() != row_0.method_28().method_2())
		{
			method_11(method_28().method_2().method_59(row_0.method_26()));
		}
		short_0 = row_0.short_0;
	}

	[SpecialName]
	internal Worksheet method_28()
	{
		return rowCollection_0.cells_0.method_3();
	}

	internal void CopyData(Row row_0, CopyOptions copyOptions_0)
	{
		int_1 = row_0.int_1;
		if (row_0.method_27())
		{
			if (!copyOptions_0.bool_0 && method_28().method_2() != row_0.method_28().method_2())
			{
				if (copyOptions_0.hashtable_0[row_0.method_10()] != null)
				{
					method_11((int)copyOptions_0.hashtable_0[row_0.method_10()]);
				}
				else
				{
					int num = row_0.method_10();
					Style style = row_0.method_26();
					if (style == null)
					{
						method_11(15);
					}
					else
					{
						method_11(method_28().method_2().method_59(style));
					}
					copyOptions_0.hashtable_0.Add(num, method_10());
				}
			}
			else
			{
				method_11(row_0.method_10());
			}
		}
		short_0 = row_0.short_0;
	}

	/// <summary>
	///       Applies formattings for a whole row.
	///       </summary>
	/// <param name="style">The style object which will be applied.</param>
	/// <param name="flag">Flags which indicates applied formatting properties.</param>
	public virtual void ApplyStyle(Style style, StyleFlag flag)
	{
		Cells cells_ = rowCollection_0.cells_0;
		ColumnCollection columns = cells_.Columns;
		if (flag.All)
		{
			SetStyle(style);
			int int_ = method_10();
			for (int i = 0; i < arrayList_0.Count; i++)
			{
				Cell cell = (Cell)arrayList_0[i];
				cell.method_37(int_);
			}
			return;
		}
		Hashtable hashtable = new Hashtable();
		int num = 0;
		Style style2 = null;
		for (int j = 0; j < arrayList_0.Count; j++)
		{
			Cell cell2 = (Cell)arrayList_0[j];
			num = cell2.method_35();
			if (hashtable[num] != null)
			{
				cell2.method_37((int)hashtable[num]);
				continue;
			}
			style2 = cell2.method_28();
			Class1677.ApplyStyle(style, style2, flag);
			cell2.method_30(style2);
			hashtable.Add(num, cell2.method_35());
		}
		for (int k = 0; k < columns.Count; k++)
		{
			Column columnByIndex = columns.GetColumnByIndex(k);
			if (!columnByIndex.method_10())
			{
				continue;
			}
			Cell cell3 = cells_.CheckCell(int_0, columnByIndex.Index);
			if (cell3 == null)
			{
				cell3 = cells_.GetCell(int_0, columnByIndex.Index, bool_2: false);
				num = cell3.method_35();
				if (hashtable[num] != null)
				{
					cell3.method_37((int)hashtable[num]);
					continue;
				}
				style2 = cell3.method_28();
				Class1677.ApplyStyle(style, style2, flag);
				cell3.method_30(style2);
				hashtable[num] = cell3.method_35();
			}
		}
		num = method_10();
		style2 = Style;
		Class1677.ApplyStyle(style, style2, flag);
		SetStyle(style2);
	}

	internal bool method_29(Row row_0)
	{
		if (row_0 == null)
		{
			return !method_27();
		}
		return method_26().Equals(row_0.method_26());
	}
}
