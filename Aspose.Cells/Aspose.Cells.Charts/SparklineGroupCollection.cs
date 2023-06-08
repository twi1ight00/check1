using System;
using System.Collections;
using System.Runtime.CompilerServices;
using ns12;
using ns7;

namespace Aspose.Cells.Charts;

/// <summary>
///       Encapsulates a collection of <see cref="T:Aspose.Cells.Charts.SparklineGroup" /> objects.
///       </summary>
public class SparklineGroupCollection : CollectionBase
{
	private Worksheet worksheet_0;

	/// <summary>
	///       Gets the <see cref="T:Aspose.Cells.Charts.SparklineGroup" /> element at the specified index.
	///       </summary>
	/// <param name="index">The zero based index of the element.</param>
	/// <returns>The element at the specified index.</returns>
	public SparklineGroup this[int index] => (SparklineGroup)base.InnerList[index];

	internal SparklineGroupCollection(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	[SpecialName]
	internal Worksheet method_0()
	{
		return worksheet_0;
	}

	/// <summary>
	///       Adds an <see cref="T:Aspose.Cells.Charts.SparklineGroup" /> item to the collection.
	///       </summary>
	/// <param name="type">Specifies the type of the Sparkline group.</param>
	/// <param name="dataRange">Specifies the data range of the sparkline group.</param>
	/// <param name="isVertical">Specifies whether to plot the sparklines from the data range by row or by column.</param>
	/// <param name="locationRange">Specifies where the sparklines to be placed.</param>
	/// <returns>
	///   <see cref="T:Aspose.Cells.Charts.SparklineGroup" /> object index.</returns>
	public int Add(SparklineType type, string dataRange, bool isVertical, CellArea locationRange)
	{
		ClearSparklines(locationRange);
		SparklineGroup value = new SparklineGroup(this, type, dataRange, isVertical, locationRange);
		base.InnerList.Add(value);
		return base.Count - 1;
	}

	internal int Add(SparklineGroup sparklineGroup_0)
	{
		base.InnerList.Add(sparklineGroup_0);
		return base.Count - 1;
	}

	internal void method_1()
	{
		ArrayList arrayList = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SparklineGroup sparklineGroup = (SparklineGroup)enumerator.Current;
				SparklineCollection sparklineCollection = sparklineGroup.SparklineCollection;
				if (sparklineCollection.Count == 0)
				{
					arrayList.Add(sparklineGroup);
				}
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
		foreach (object item in arrayList)
		{
			base.InnerList.Remove(item);
		}
	}

	/// <summary>
	///       Clears the sparklines that is inside an area of cells.
	///       </summary>
	/// <param name="cellArea">Specifies the area of cells</param>
	public void ClearSparklines(CellArea cellArea)
	{
		ArrayList arrayList = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SparklineGroup sparklineGroup = (SparklineGroup)enumerator.Current;
				SparklineCollection sparklineCollection = sparklineGroup.SparklineCollection;
				ArrayList arrayList2 = new ArrayList();
				foreach (Sparkline item in sparklineCollection)
				{
					if (item.method_4(cellArea))
					{
						arrayList2.Add(item);
					}
				}
				foreach (object item2 in arrayList2)
				{
					sparklineCollection.Remove(item2);
				}
				if (sparklineCollection.Count == 0)
				{
					arrayList.Add(sparklineGroup);
				}
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
		foreach (object item3 in arrayList)
		{
			base.InnerList.Remove(item3);
		}
	}

	/// <summary>
	///       Clears the sparkline groups that overlaps an area of cells.
	///       </summary>
	/// <param name="cellArea">Specifies the area of cells</param>
	public void ClearSparklineGroups(CellArea cellArea)
	{
		ArrayList arrayList = new ArrayList();
		IEnumerator enumerator = GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				SparklineGroup sparklineGroup = (SparklineGroup)enumerator.Current;
				SparklineCollection sparklineCollection = sparklineGroup.SparklineCollection;
				foreach (Sparkline item in sparklineCollection)
				{
					if (item.method_4(cellArea))
					{
						arrayList.Add(sparklineGroup);
						break;
					}
				}
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
		foreach (object item2 in arrayList)
		{
			base.InnerList.Remove(item2);
		}
	}

	internal void method_2()
	{
		for (int i = 0; i < base.Count; i++)
		{
			SparklineGroup sparklineGroup = this[i];
			if (sparklineGroup.method_0() != null)
			{
				Class1309 @class = sparklineGroup.method_0();
				if (@class.byte_0 != null)
				{
					@class.byte_0 = Class1247.smethod_1(@class.byte_0, -1, 0, 0, bool_0: false);
				}
			}
			foreach (Sparkline item in sparklineGroup.SparklineCollection)
			{
				Class1309 class2 = item.method_0();
				if (class2 != null && class2.byte_0 != null)
				{
					class2.byte_0 = Class1247.smethod_1(class2.byte_0, -1, 0, 0, bool_0: false);
				}
			}
		}
	}

	internal void method_3()
	{
		for (int i = 0; i < base.Count; i++)
		{
			SparklineGroup sparklineGroup = this[i];
			if (sparklineGroup.method_0() != null)
			{
				Class1309 @class = sparklineGroup.method_0();
				if (@class.byte_0 != null)
				{
					@class.byte_0 = Class1248.smethod_1(@class.byte_0, -1);
				}
			}
			foreach (Sparkline item in sparklineGroup.SparklineCollection)
			{
				Class1309 class2 = item.method_0();
				if (class2 != null && class2.byte_0 != null)
				{
					class2.byte_0 = Class1248.smethod_1(class2.byte_0, -1);
				}
			}
		}
	}

	internal void InsertRows(Cells cells_0, int int_0, int int_1, bool bool_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			if (this[i].InsertRows(cells_0, int_0, int_1, bool_0) == 0)
			{
				base.InnerList.Remove(this[i]);
			}
		}
	}

	internal void InsertColumns(Cells cells_0, int int_0, int int_1, bool bool_0)
	{
		for (int i = 0; i < base.InnerList.Count; i++)
		{
			if (this[i].InsertColumns(cells_0, int_0, int_1, bool_0) == 0)
			{
				base.InnerList.Remove(this[i]);
			}
		}
	}

	internal void Copy(SparklineGroupCollection sparklineGroupCollection_0, CopyOptions copyOptions_0)
	{
		for (int i = 0; i < sparklineGroupCollection_0.Count; i++)
		{
			SparklineGroup sparklineGroup_ = sparklineGroupCollection_0[i];
			SparklineGroup sparklineGroup = new SparklineGroup(this);
			Add(sparklineGroup);
			sparklineGroup.Copy(sparklineGroup_, copyOptions_0);
		}
	}
}
