using System;
using System.Collections;
using System.Drawing;

namespace Aspose.Slides;

public sealed class ColumnCollection : ICollection, IEnumerable, IColumnCollection
{
	private ArrayList arrayList_0 = new ArrayList();

	private bool bool_0 = true;

	private bool bool_1 = true;

	private double double_0;

	private RowCollection rowCollection_0;

	internal Table ParentTable => rowCollection_0.ParentTable;

	internal RowCollection RowsCollection => rowCollection_0;

	internal double TotalWidth
	{
		get
		{
			method_12();
			return double_0;
		}
	}

	public int Count => arrayList_0.Count;

	public IColumn this[int index]
	{
		get
		{
			if (index < 0 || index > Count - 1)
			{
				throw new IndexOutOfRangeException($"value of index = {index} is out of range 0..{Count - 1}");
			}
			return (IColumn)arrayList_0[index];
		}
	}

	IEnumerable IColumnCollection.AsIEnumerable => this;

	ICollection IColumnCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal ColumnCollection(RowCollection rowsCollection)
	{
		rowCollection_0 = rowsCollection;
	}

	internal Column method_0(int index)
	{
		return (Column)arrayList_0[index];
	}

	internal int method_1(double targetOffset)
	{
		method_12();
		if (!(targetOffset < 0.0) && targetOffset <= double_0)
		{
			if (Count == 1)
			{
				return 0;
			}
			int num = 0;
			int num2 = Count - 1;
			int num3;
			while (true)
			{
				if (num < num2)
				{
					num3 = num + num2 >> 1;
					Column column = method_0(num3);
					if (targetOffset < column.double_1)
					{
						num2 = num3 - 1;
						continue;
					}
					if (!(targetOffset >= column.double_1 + column.Width))
					{
						break;
					}
					num = num3 + 1;
					continue;
				}
				return num;
			}
			return num3;
		}
		return -1;
	}

	internal void method_2(double width)
	{
		method_3(-1, width);
	}

	internal Column method_3(int index, double width)
	{
		Column column = new Column(this, width);
		int count = rowCollection_0.Count;
		int index2 = -1;
		if (index >= 0 && index < Count)
		{
			arrayList_0.Insert(index, column);
			column.int_0 = index;
			bool_0 = false;
			index2 = index;
		}
		else
		{
			column.int_0 = arrayList_0.Count;
			arrayList_0.Add(column);
		}
		bool_1 = false;
		for (int i = 0; i < count; i++)
		{
			rowCollection_0.method_0(i).method_1(index2, 1);
		}
		return column;
	}

	public IColumn[] AddClone(IColumn templ, bool withAttachedColumns)
	{
		int count = Count;
		return InsertClone(count, templ, withAttachedColumns);
	}

	public IColumn[] InsertClone(int index, IColumn templ, bool withAttachedColumns)
	{
		Column column = (Column)templ;
		Table parentTable = column.ParentTable;
		if (ParentTable != parentTable)
		{
			throw new PptxEditException("Clonning columns between different tables isn't supported.");
		}
		if (index >= 0 && index <= Count)
		{
			if (method_13(index, checkOnly: true))
			{
				throw new PptxEditException("Can't insert columns: target index breaks merged cells.");
			}
			Column[] array = new Column[0];
			if (withAttachedColumns)
			{
				array = column.ParentColumnsCollection.method_10(column.ColumnIndex);
			}
			else
			{
				if (method_14(column.ColumnIndex, checkOnly: true))
				{
					throw new PptxEditException("Some of row's cells lay outside column.");
				}
				array = new Column[1] { column };
			}
			IColumn[] array2 = new IColumn[array.Length];
			int num = array.Length;
			while (num > 0)
			{
				num--;
				column = array[num];
				Column column2 = (Column)(array2[num] = method_3(index, column.Width));
				int num2 = rowCollection_0.Count;
				while (num2 > 0)
				{
					num2--;
					Cell cell = column.vmethod_3(num2);
					Cell cell2 = column2.vmethod_3(num2);
					cell2.method_3(cell);
					cell2.int_1 = cell.int_1;
					cell2.int_0 = cell.int_0;
					if (!cell2.IsSingleCell)
					{
						column2.int_0 = index;
						bool_0 = true;
						cell2.method_1(mergeText: false);
					}
				}
			}
			bool_0 = false;
			return array2;
		}
		throw new ArgumentOutOfRangeException("index", index, "Wrong index of column");
	}

	internal void method_4(double splitOffset)
	{
		int num = method_1(splitOffset);
		if (num < 0)
		{
			throw new PptxEditException("Invalid vertical split offset!");
		}
		method_5(num, splitOffset - method_0(num).ColumnOffset);
	}

	internal void method_5(int columnIndex, double newWidth)
	{
		Column column = method_0(columnIndex);
		if (!(newWidth <= 0.0) && newWidth < column.Width)
		{
			Column column2 = method_3(columnIndex + 1, column.Width - newWidth);
			column.Width = newWidth;
			int count = rowCollection_0.Count;
			int num = 0;
			while (num < count)
			{
				Cell cell = column.vmethod_3(num);
				if (cell.cell_0 != null)
				{
					cell = cell.cell_0;
				}
				cell.int_1++;
				int num2 = cell.RowSpan;
				while (num2 > 0)
				{
					num2--;
					column2.vmethod_3(num).cell_0 = cell;
					num++;
				}
			}
			return;
		}
		throw new ArgumentOutOfRangeException("Splitting width must be in greater than 0 and less than cell's width");
	}

	internal void Clear()
	{
		method_6(0, Count);
		bool_0 = true;
		bool_1 = true;
		double_0 = 0.0;
	}

	public void RemoveAt(int firstColumnIndex, bool withAttachedRows)
	{
		int count = Count;
		if (withAttachedRows)
		{
			Size size = method_9(firstColumnIndex);
			method_6(size.Width, size.Height);
		}
		else
		{
			int count2 = rowCollection_0.Count;
			Column column = method_0(firstColumnIndex);
			for (int i = 0; i < count2; i++)
			{
				ICell cell = column[i];
				if (cell.ColSpan > 1)
				{
					throw new PptxEditException("Some of column's cells lay outside column.");
				}
			}
			method_6(firstColumnIndex, 1);
		}
		if (count != Count && Count > 0)
		{
			rowCollection_0.method_7();
		}
	}

	private void method_6(int startColumnIndex, int columnsCount)
	{
		if (columnsCount != 0)
		{
			if (startColumnIndex + columnsCount < Count)
			{
				bool_0 = false;
			}
			bool_1 = false;
			int num = rowCollection_0.Count;
			while (num > 0)
			{
				Row row = rowCollection_0.method_0(--num);
				row.method_2(startColumnIndex, columnsCount);
			}
			if (startColumnIndex == 0 && columnsCount == Count)
			{
				arrayList_0.Clear();
			}
			else
			{
				arrayList_0.RemoveRange(startColumnIndex, columnsCount);
			}
		}
	}

	internal void method_7()
	{
		method_8(0, Count);
	}

	internal void method_8(int startColumnIndex, int columnsCount)
	{
		bool flag = bool_1;
		int num = startColumnIndex + columnsCount;
		int count = rowCollection_0.Count;
		while (num > startColumnIndex)
		{
			num--;
			Column column = method_0(num);
			bool flag2 = true;
			for (int i = 0; i < count; i++)
			{
				if (column.vmethod_3(i).MergedTo == null)
				{
					flag2 = false;
					break;
				}
			}
			if (flag2)
			{
				if (num > 0)
				{
					method_0(num - 1).Width += column.Width;
				}
				method_6(num, 1);
			}
		}
		bool_1 = flag;
	}

	private Size method_9(int columnIndex)
	{
		int count = rowCollection_0.Count;
		int num = columnIndex;
		Column column = method_0(num);
		int i = 0;
		if (columnIndex > 0)
		{
			Cell cell;
			for (; i < count; i += cell.RowSpan)
			{
				cell = column.vmethod_3(i);
				if (cell.FirstColumnIndex < num)
				{
					num = cell.FirstColumnIndex;
					column = method_0(num);
					i = 0;
				}
			}
		}
		int num2 = columnIndex + 1;
		if (num2 < Count)
		{
			column = method_0(columnIndex);
			Cell baseCell;
			for (i = 0; i < count; i += baseCell.RowSpan)
			{
				baseCell = column.vmethod_3(i).BaseCell;
				if (baseCell.FirstColumnIndex + baseCell.ColSpan > num2)
				{
					num2 = baseCell.FirstColumnIndex + baseCell.ColSpan;
					column = method_0(num2 - 1);
					i = 0;
				}
			}
		}
		return new Size(num, num2 - num);
	}

	private Column[] method_10(int columnIndex)
	{
		Size size = method_9(columnIndex);
		Column[] array = new Column[size.Height];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = method_0(size.Width + i);
		}
		return array;
	}

	internal void method_11()
	{
		if (!bool_0)
		{
			for (int i = 0; i < Count; i++)
			{
				method_0(i).int_0 = i;
			}
			bool_0 = true;
		}
	}

	internal void method_12()
	{
		if (!bool_1)
		{
			double_0 = 0.0;
			for (int i = 0; i < Count; i++)
			{
				Column column = method_0(i);
				column.int_0 = i;
				column.double_1 = double_0;
				double_0 += column.Width;
			}
			bool_1 = true;
			bool_0 = true;
		}
	}

	internal bool method_13(int index, bool checkOnly)
	{
		if (index >= 1 && index != Count)
		{
			int count = rowCollection_0.Count;
			Column column = method_0(index);
			int num = 0;
			while (true)
			{
				if (num < count)
				{
					Cell baseCell = column.vmethod_3(num).BaseCell;
					int firstColumnIndex = baseCell.FirstColumnIndex;
					if (firstColumnIndex < index)
					{
						if (checkOnly)
						{
							break;
						}
						baseCell.method_4(index - firstColumnIndex);
					}
					num += baseCell.RowSpan;
					continue;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	internal bool method_14(int index, bool checkOnly)
	{
		if (index == Count)
		{
			return false;
		}
		int count = rowCollection_0.Count;
		Column column = method_0(index);
		int num = 0;
		while (true)
		{
			if (num < count)
			{
				Cell cell = column.vmethod_3(num);
				if (cell.IsSlaveCell)
				{
					cell = cell.BaseCell;
					int firstColumnIndex = cell.FirstColumnIndex;
					if (firstColumnIndex < index)
					{
						if (checkOnly)
						{
							return true;
						}
						cell = cell.method_4(index - firstColumnIndex);
					}
				}
				if (cell.ColSpan > 1)
				{
					if (checkOnly)
					{
						break;
					}
					cell.method_4(1);
				}
				num += cell.RowSpan;
				continue;
			}
			return false;
		}
		return true;
	}

	public IEnumerator GetEnumerator()
	{
		return arrayList_0.GetEnumerator(0, Count);
	}

	public void CopyTo(Array array, int index)
	{
		arrayList_0.CopyTo(array, index);
	}
}
