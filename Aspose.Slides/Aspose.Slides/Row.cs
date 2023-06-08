using System;
using System.Collections;
using ns33;

namespace Aspose.Slides;

public sealed class Row : CellCollection, ICollection, IEnumerable, IPresentationComponent, ISlideComponent, ICellCollection, IRow
{
	internal const double double_0 = 9.2;

	private RowCollection rowCollection_0;

	internal int int_0 = -1;

	internal double double_1;

	private ArrayList arrayList_0 = new ArrayList();

	private double double_2;

	private double double_3;

	internal RowCollection ParentRowsCollection => rowCollection_0;

	internal int RowIndex
	{
		get
		{
			rowCollection_0.method_11();
			return int_0;
		}
	}

	internal double RowOffset
	{
		get
		{
			rowCollection_0.method_12();
			return double_1;
		}
	}

	public double Height
	{
		get
		{
			base.ParentTable.vmethod_6();
			return double_3;
		}
	}

	internal double ActualHeightInternal
	{
		get
		{
			return double_3;
		}
		set
		{
			if (double_3 != value)
			{
				rowCollection_0.bool_1 = false;
			}
			double_3 = value;
		}
	}

	public double MinimalHeight
	{
		get
		{
			return double_2;
		}
		set
		{
			if (value >= 2.0 && !double.IsInfinity(value))
			{
				double_2 = value;
			}
			else
			{
				double_2 = 0.0;
			}
			if (double_2 > double_3)
			{
				method_3();
			}
		}
	}

	ICellCollection IRow.AsICellCollection => this;

	internal Row(RowCollection parentCollection, double height)
	{
		double_2 = height;
		double_3 = height;
		rowCollection_0 = parentCollection;
	}

	internal override int vmethod_2()
	{
		return arrayList_0.Count;
	}

	internal void method_0(int desiredCount)
	{
		if (arrayList_0.Count < desiredCount)
		{
			method_1(-1, desiredCount - arrayList_0.Count);
		}
	}

	internal void method_1(int index, int count)
	{
		if (count < 1)
		{
			return;
		}
		int num = count;
		if (index >= 0 && index < base.Count)
		{
			int index2 = index;
			while (num > 0)
			{
				num--;
				Cell value = new Cell(this, (Column)rowCollection_0.columnCollection_0[index2]);
				arrayList_0.Insert(index2++, value);
			}
		}
		else
		{
			while (num > 0)
			{
				num--;
				Cell cell = new Cell(this, (Column)rowCollection_0.columnCollection_0[arrayList_0.Count]);
				arrayList_0.Add(cell);
				cell.textFrame_0.Text = "";
			}
		}
	}

	internal override Table vmethod_1()
	{
		return ParentRowsCollection.ParentTable;
	}

	internal override Cell vmethod_3(int index)
	{
		if (index >= 0 && index < base.Count)
		{
			return (Cell)arrayList_0[index];
		}
		return null;
	}

	internal void method_2(int startCellIndex, int cellCount)
	{
		int num = startCellIndex;
		for (int i = 0; i < cellCount; i++)
		{
			Cell cell = vmethod_3(num++);
			cell.method_0();
		}
		arrayList_0.RemoveRange(startCellIndex, cellCount);
	}

	internal override IEnumerator vmethod_4()
	{
		return new Class1169(arrayList_0.GetEnumerator(0, arrayList_0.Count), CellCollection.delegate16_0, null);
	}

	internal override int vmethod_0(double offset)
	{
		return rowCollection_0.ColumnsCollection.method_1(offset);
	}

	internal override void vmethod_5(Array array, int destIndex)
	{
		if (base.Count >= 1)
		{
			arrayList_0.CopyTo(0, array, destIndex, base.Count);
		}
	}

	internal void method_3()
	{
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Cell cell = (Cell)enumerator.Current;
				cell.NeedToUpdateSize = true;
			}
		}
		finally
		{
			IDisposable disposable = enumerator as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		base.ParentTable.method_16();
	}
}
