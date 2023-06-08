using System;
using System.Collections;
using System.Drawing;

namespace Aspose.Slides;

public sealed class RowCollection : ICollection, IEnumerable, IRowCollection
{
	private ArrayList arrayList_0 = new ArrayList();

	private bool bool_0 = true;

	internal bool bool_1 = true;

	internal double double_0;

	internal ColumnCollection columnCollection_0;

	private Table table_0;

	internal Table ParentTable => table_0;

	internal ColumnCollection ColumnsCollection => columnCollection_0;

	internal double TotalHeight
	{
		get
		{
			method_12();
			return double_0;
		}
	}

	public int Count => arrayList_0.Count;

	public IRow this[int index]
	{
		get
		{
			if (index < 0 || index > Count - 1)
			{
				throw new IndexOutOfRangeException($"value of index = {index} is out of range 0..{Count - 1}");
			}
			return (Row)arrayList_0[index];
		}
	}

	IEnumerable IRowCollection.AsIEnumerable => this;

	ICollection IRowCollection.AsICollection => this;

	public bool IsSynchronized => false;

	public object SyncRoot => this;

	internal RowCollection(Table parentTable)
	{
		table_0 = parentTable;
		columnCollection_0 = new ColumnCollection(this);
	}

	internal Row method_0(int index)
	{
		return (Row)arrayList_0[index];
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
					Row row = method_0(num3);
					if (targetOffset < row.double_1)
					{
						num2 = num3 - 1;
						continue;
					}
					if (!(targetOffset >= row.double_1 + row.Height))
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

	internal Row method_2(double height)
	{
		return method_3(-1, height);
	}

	internal Row method_3(int index, double height)
	{
		Row row = new Row(this, height);
		if (index >= 0 && index < Count)
		{
			arrayList_0.Insert(index, row);
			bool_0 = false;
		}
		else
		{
			row.int_0 = arrayList_0.Count;
			arrayList_0.Add(row);
		}
		bool_1 = false;
		row.method_0(columnCollection_0.Count);
		return row;
	}

	public IRow[] AddClone(IRow templ, bool withAttachedRows)
	{
		int count = Count;
		return InsertClone(count, templ, withAttachedRows);
	}

	public IRow[] InsertClone(int index, IRow templ, bool withAttachedRows)
	{
		Row row = (Row)templ;
		Table parentTable = row.ParentTable;
		if (ParentTable != parentTable)
		{
			throw new PptxEditException("Clonning rows between different tables isn't supported.");
		}
		if (index >= 0 && index <= Count)
		{
			if (method_13(index, checkOnly: true))
			{
				throw new PptxEditException("Can't insert rows: target index breaks merged cells.");
			}
			Row[] array;
			if (withAttachedRows)
			{
				array = row.ParentRowsCollection.method_10(row.RowIndex);
			}
			else
			{
				if (method_14(row.RowIndex, checkOnly: true))
				{
					throw new PptxEditException("Some of row's cells lay outside row.");
				}
				array = new Row[1] { row };
			}
			IRow[] array2 = new IRow[array.Length];
			int num = array.Length;
			while (num > 0)
			{
				num--;
				row = array[num];
				Row row2 = (Row)(array2[num] = method_3(index, row.Height));
				row2.MinimalHeight = row.MinimalHeight;
				int num2 = columnCollection_0.Count;
				while (num2 > 0)
				{
					num2--;
					Cell cell = row.vmethod_3(num2);
					Cell cell2 = row2.vmethod_3(num2);
					cell2.method_3(cell);
					cell2.int_1 = cell.int_1;
					cell2.int_0 = cell.int_0;
					if (!cell2.IsSingleCell)
					{
						row2.int_0 = index;
						bool_0 = true;
						cell2.method_1(mergeText: false);
					}
				}
			}
			bool_0 = false;
			return array2;
		}
		throw new ArgumentOutOfRangeException("index", index, "Wrong index of row");
	}

	internal void method_4(double splitOffset)
	{
		int num = method_1(splitOffset);
		if (num < 0)
		{
			throw new PptxEditException("Invalid horisontal split offset!");
		}
		method_5(num, splitOffset - method_0(num).RowOffset);
	}

	internal void method_5(int rowIndex, double newHeight)
	{
		Row row = method_0(rowIndex);
		if (!(newHeight <= 0.0) && newHeight < row.MinimalHeight)
		{
			Row row2 = method_3(rowIndex + 1, row.MinimalHeight - newHeight);
			row.MinimalHeight = newHeight;
			int count = columnCollection_0.Count;
			int num = 0;
			while (num < count)
			{
				Cell cell = row.vmethod_3(num);
				if (cell.cell_0 != null)
				{
					cell = cell.cell_0;
				}
				cell.int_0++;
				int num2 = cell.ColSpan;
				while (num2 > 0)
				{
					num2--;
					row2.vmethod_3(num).cell_0 = cell;
					num++;
				}
			}
			return;
		}
		throw new ArgumentOutOfRangeException("Splitting height must be in greater than 0 and less than row's minimal height");
	}

	internal void Clear()
	{
		method_6(0, Count);
		bool_0 = true;
		bool_1 = true;
		double_0 = 0.0;
	}

	public void RemoveAt(int firstRowIndex, bool withAttachedRows)
	{
		int count = Count;
		if (withAttachedRows)
		{
			Size size = method_9(firstRowIndex);
			method_6(size.Width, size.Height);
		}
		else
		{
			int count2 = columnCollection_0.Count;
			Row row = method_0(firstRowIndex);
			for (int i = 0; i < count2; i++)
			{
				ICell cell = row[i];
				if (cell.RowSpan > 1)
				{
					throw new PptxEditException("Some of row's cells lay outside row.");
				}
			}
			method_6(firstRowIndex, 1);
		}
		if (count != Count && Count > 0)
		{
			columnCollection_0.method_7();
		}
	}

	private void method_6(int startRowIndex, int rowsCount)
	{
		if (rowsCount != 0)
		{
			if (startRowIndex + rowsCount < Count)
			{
				bool_0 = false;
			}
			bool_1 = false;
			int num = startRowIndex;
			int count = columnCollection_0.Count;
			for (int i = 0; i < rowsCount; i++)
			{
				Row row = method_0(num++);
				row.method_2(0, count);
			}
			if (startRowIndex == 0 && rowsCount == Count)
			{
				arrayList_0.Clear();
			}
			else
			{
				arrayList_0.RemoveRange(startRowIndex, rowsCount);
			}
		}
	}

	internal void method_7()
	{
		method_8(0, Count);
	}

	internal void method_8(int startRowIndex, int rowsCount)
	{
		bool flag = bool_1;
		int num = startRowIndex + rowsCount;
		int count = columnCollection_0.Count;
		while (num > startRowIndex)
		{
			num--;
			Row row = method_0(num);
			bool flag2 = true;
			for (int i = 0; i < count; i++)
			{
				if (row.vmethod_3(i).MergedTo == null)
				{
					flag2 = false;
					break;
				}
			}
			if (flag2)
			{
				if (num > 0)
				{
					method_0(num - 1).MinimalHeight += row.MinimalHeight;
				}
				method_6(num, 1);
			}
		}
		bool_1 = flag;
	}

	private Size method_9(int rowIndex)
	{
		int count = columnCollection_0.Count;
		int num = rowIndex;
		Row row = method_0(num);
		int i = 0;
		if (rowIndex > 0)
		{
			Cell baseCell;
			for (; i < count; i += baseCell.ColSpan)
			{
				baseCell = row.vmethod_3(i).BaseCell;
				if (baseCell.FirstRowIndex < num)
				{
					num = baseCell.FirstRowIndex;
					row = method_0(num);
					i = 0;
				}
			}
		}
		int num2 = rowIndex + 1;
		if (num2 < Count)
		{
			row = method_0(rowIndex);
			Cell baseCell2;
			for (i = 0; i < count; i += baseCell2.ColSpan)
			{
				baseCell2 = row.vmethod_3(i).BaseCell;
				if (baseCell2.FirstRowIndex + baseCell2.RowSpan > num2)
				{
					num2 = baseCell2.FirstRowIndex + baseCell2.RowSpan;
					row = method_0(num2 - 1);
					i = 0;
				}
			}
		}
		return new Size(num, num2 - num);
	}

	private Row[] method_10(int rowIndex)
	{
		Size size = method_9(rowIndex);
		Row[] array = new Row[size.Height];
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
				Row row = method_0(i);
				row.int_0 = i;
				row.double_1 = double_0;
				double_0 += row.Height;
			}
			bool_1 = true;
			bool_0 = true;
		}
	}

	internal bool method_13(int index, bool checkOnly)
	{
		if (index >= 1 && index != Count)
		{
			int count = columnCollection_0.Count;
			Row row = method_0(index);
			int num = 0;
			while (true)
			{
				if (num < count)
				{
					Cell cell = row.vmethod_3(num);
					if (cell.MergedTo != null)
					{
						cell = cell.MergedTo;
					}
					int firstRowIndex = cell.FirstRowIndex;
					if (firstRowIndex < index)
					{
						if (checkOnly)
						{
							break;
						}
						cell.method_5(index - firstRowIndex);
					}
					num += cell.ColSpan;
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
		int count = columnCollection_0.Count;
		Row row = method_0(index);
		int num = 0;
		while (true)
		{
			if (num < count)
			{
				Cell cell = row.vmethod_3(num);
				if (cell.MergedTo != null)
				{
					cell = cell.MergedTo;
					int firstRowIndex = cell.FirstRowIndex;
					if (firstRowIndex < index)
					{
						if (checkOnly)
						{
							return true;
						}
						cell = cell.method_5(index - firstRowIndex);
					}
				}
				if (cell.RowSpan > 1)
				{
					if (checkOnly)
					{
						break;
					}
					cell.method_5(1);
				}
				num += cell.ColSpan;
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
