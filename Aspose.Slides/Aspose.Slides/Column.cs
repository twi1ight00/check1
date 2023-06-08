using System;
using System.Collections;
using ns33;

namespace Aspose.Slides;

public sealed class Column : CellCollection, ICollection, IEnumerable, IPresentationComponent, ISlideComponent, ICellCollection, IColumn
{
	internal const double double_0 = 16.4;

	private ColumnCollection columnCollection_0;

	internal int int_0 = -1;

	internal double double_1;

	private double double_2;

	internal ColumnCollection ParentColumnsCollection => columnCollection_0;

	internal int ColumnIndex
	{
		get
		{
			columnCollection_0.method_11();
			return int_0;
		}
	}

	internal double ColumnOffset
	{
		get
		{
			columnCollection_0.method_12();
			return double_1;
		}
	}

	public double Width
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
			method_0();
		}
	}

	ICellCollection IColumn.AsICellCollection => this;

	internal Column(ColumnCollection parentCollection, double width)
	{
		double_2 = width;
		columnCollection_0 = parentCollection;
	}

	internal override int vmethod_2()
	{
		return columnCollection_0.RowsCollection.Count;
	}

	internal override Table vmethod_1()
	{
		return columnCollection_0.ParentTable;
	}

	internal override Cell vmethod_3(int index)
	{
		return columnCollection_0.RowsCollection.method_0(index).vmethod_3(int_0);
	}

	internal void method_0()
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

	internal override IEnumerator vmethod_4()
	{
		ArrayList arrayList = new ArrayList(base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			arrayList.Add(vmethod_3(i));
		}
		return new Class1169(arrayList.GetEnumerator(0, arrayList.Count), CellCollection.delegate16_0, null);
	}

	internal override int vmethod_0(double offset)
	{
		return columnCollection_0.RowsCollection.method_1(offset);
	}

	internal override void vmethod_5(Array array, int destIndex)
	{
		if (base.Count >= 1)
		{
			ArrayList arrayList = new ArrayList(base.Count);
			for (int i = 0; i < base.Count; i++)
			{
				arrayList.Add(base[i]);
			}
			arrayList.CopyTo(0, array, destIndex, base.Count);
		}
	}
}
