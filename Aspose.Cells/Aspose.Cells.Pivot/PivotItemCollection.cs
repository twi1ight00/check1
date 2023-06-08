using System.Collections;
using ns28;
using ns59;

namespace Aspose.Cells.Pivot;

/// <summary>
///       Summary description for PivotItems.
///       </summary>
public class PivotItemCollection
{
	internal PivotField pivotField_0;

	internal ArrayList arrayList_0;

	/// <summary>
	/// </summary>
	public PivotItem this[int index] => (PivotItem)arrayList_0[index];

	/// <summary>
	/// </summary>
	/// <param name="itemValue">
	/// </param>
	/// <returns>
	/// </returns>
	public PivotItem this[string itemValue]
	{
		get
		{
			int num = 0;
			while (true)
			{
				if (num < Count)
				{
					object value = this[num].Value;
					if (value == null)
					{
						if (itemValue == null)
						{
							return this[num];
						}
					}
					else if (value.ToString().Equals(itemValue))
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return this[num];
		}
	}

	/// <summary>
	/// </summary>
	public int Count => arrayList_0.Count;

	internal PivotItemCollection(PivotField pivotField_1)
	{
		pivotField_0 = pivotField_1;
		arrayList_0 = new ArrayList();
	}

	internal int Add(PivotItem pivotItem_0)
	{
		arrayList_0.Add(pivotItem_0);
		return Count - 1;
	}

	internal void RemoveAt(int int_0)
	{
		arrayList_0.RemoveAt(int_0);
	}

	internal int method_0()
	{
		int num = 0;
		foreach (PivotItem item in arrayList_0)
		{
			if (item.IsHidden)
			{
				num++;
			}
		}
		return num;
	}

	/// <summary>
	///       Directly chanages the orders of the two items.
	///       </summary>
	/// <param name="sourceIndex">The current index</param>
	/// <param name="destIndex">The dest index</param>
	public void ChangeitemsOrder(int sourceIndex, int destIndex)
	{
		object value = arrayList_0[destIndex];
		object value2 = arrayList_0[sourceIndex];
		arrayList_0[destIndex] = value2;
		arrayList_0[sourceIndex] = value;
	}

	internal void method_1(int int_0, int int_1)
	{
		object value = arrayList_0[int_0];
		arrayList_0.Insert(int_1, value);
		arrayList_0.RemoveAt(int_0 + 1);
	}

	internal void method_2(int int_0, int int_1)
	{
		object value = arrayList_0[int_0];
		arrayList_0.Insert(int_1, value);
		arrayList_0.RemoveAt(int_0);
	}

	internal void Write(Class1725 class1725_0)
	{
		Class577 @class = new Class577();
		foreach (PivotItem item in arrayList_0)
		{
			@class.method_4(item);
			@class.vmethod_0(class1725_0);
		}
		PivotField pivotField = pivotField_0;
		if (pivotField.IsAutoSubtotals && ((uint)pivotField.class1173_0.ushort_0 & (true ? 1u : 0u)) != 0)
		{
			@class.method_5(1, 0, ushort.MaxValue, null);
			@class.vmethod_0(class1725_0);
		}
		else
		{
			if (pivotField.GetSubtotals(PivotFieldSubtotalType.None))
			{
				return;
			}
			ushort ushort_ = pivotField.class1173_0.ushort_0;
			for (int i = 1; i < 14; i++)
			{
				if (((uint)(ushort_ >> i) & (true ? 1u : 0u)) != 0)
				{
					@class.method_5((short)(i + 1), 0, ushort.MaxValue, null);
					@class.vmethod_0(class1725_0);
				}
			}
		}
	}
}
