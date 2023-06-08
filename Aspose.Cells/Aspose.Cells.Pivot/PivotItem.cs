using System;
using System.Runtime.CompilerServices;
using ns45;

namespace Aspose.Cells.Pivot;

/// <summary>
///       Summary description for PivotItem.
///       </summary>
public class PivotItem
{
	internal PivotItemCollection pivotItemCollection_0;

	internal ushort ushort_0;

	internal ushort ushort_1;

	internal string string_0;

	internal PivotField pivotField_0;

	private int int_0;

	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	internal object object_0;

	public bool IsHidden
	{
		get
		{
			return method_5(1);
		}
		set
		{
			method_6(value, 1);
		}
	}

	/// <summary>
	///       Gets the value of the pivot item
	///       </summary>
	public object Value
	{
		get
		{
			if (method_7() != null && method_7().sxRng_0 != null && method_7().sxRng_0.arrayList_0 != null && int_0 < method_7().sxRng_0.arrayList_0.Count && method_7().sxRng_0.arrayList_0[int_0] != null)
			{
				return ((Class1158)method_7().sxRng_0.arrayList_0[int_0]).object_0;
			}
			if (method_7() != null && method_7().arrayList_0 != null && int_0 < method_7().arrayList_0.Count && method_7().arrayList_0[int_0] != null)
			{
				return ((Class1158)method_7().arrayList_0[int_0]).object_0;
			}
			return null;
		}
	}

	/// <summary>
	///       Gets the name of the pivot item.
	///       </summary>
	public string Name
	{
		get
		{
			if (string_0 == null)
			{
				if (Index == -1)
				{
					string_0 = pivotItemCollection_0.pivotField_0.pivotFieldCollection_0.pivotTable_0.GrandTotalName;
					if (string_0 == null)
					{
						return "Grand Total";
					}
				}
				if (method_7().method_20())
				{
					if (method_7().sxRng_0 != null && method_7().sxRng_0.arrayList_0 != null && method_7().sxRng_0.arrayList_0[Index] != null)
					{
						return ((Class1158)method_7().sxRng_0.arrayList_0[int_0]).object_0.ToString();
					}
					return null;
				}
				if (method_7().arrayList_0 != null && method_7().arrayList_0[Index] != null && ((Class1158)method_7().arrayList_0[Index]).object_0 != null)
				{
					return ((Class1158)method_7().arrayList_0[Index]).object_0.ToString();
				}
				return null;
			}
			return string_0;
		}
	}

	/// <summary>
	///       Gets the index of the pivot item in the pivot field
	///       </summary>
	public int Index
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	internal bool IsFormula => method_5(8);

	internal PivotItem(PivotItemCollection pivotItemCollection_1)
	{
		pivotItemCollection_0 = pivotItemCollection_1;
		ushort_0 = 0;
		int_0 = -1;
	}

	/// <summary>
	///       Moves the item up or down.
	///       </summary>
	/// <param name="count">The number of moving up or down.
	///       Move the item up if this is less than zero;
	///       Move the item down if this is greater than zero.
	///       </param>
	public void Move(int count)
	{
		_ = Index;
		if (count < 0)
		{
			int index = Index;
			int num = Index + count;
			if (num < 0)
			{
				num = 0;
			}
			pivotItemCollection_0.method_1(index, num);
		}
		else
		{
			int index2 = Index;
			int num2 = index2 + count + 1;
			if (num2 >= pivotItemCollection_0.Count)
			{
				num2 = pivotItemCollection_0.Count - 1;
			}
			pivotItemCollection_0.method_2(index2, num2);
		}
	}

	[SpecialName]
	internal bool method_0()
	{
		return method_5(2);
	}

	[SpecialName]
	internal void method_1(bool bool_3)
	{
		method_6(bool_3, 2);
	}

	[SpecialName]
	internal void method_2(bool bool_3)
	{
		method_6(bool_3, 8);
	}

	[SpecialName]
	internal bool method_3()
	{
		return method_5(16);
	}

	[SpecialName]
	internal void method_4(bool bool_3)
	{
		method_6(bool_3, 16);
	}

	internal bool method_5(int int_1)
	{
		return (ushort_1 & int_1) != 0;
	}

	internal void method_6(bool bool_3, int int_1)
	{
		ushort_1 &= (ushort)(~int_1);
		ushort_1 |= (ushort)(bool_3 ? int_1 : 0);
	}

	[SpecialName]
	internal Class1161 method_7()
	{
		return pivotItemCollection_0.pivotField_0.class1161_0;
	}

	public string GetStringValue()
	{
		object value = Value;
		if (value == null)
		{
			return "";
		}
		return value.ToString();
	}

	public double GetDoubleValue()
	{
		object value = Value;
		if (value == null)
		{
			return 0.0;
		}
		if (value is double)
		{
			return (double)value;
		}
		if (value is int)
		{
			return (int)value;
		}
		if (value is DateTime)
		{
			return CellsHelper.GetDoubleFromDateTime((DateTime)value, date1904: false);
		}
		return 0.0;
	}

	public DateTime GetDateTimeValue()
	{
		object value = Value;
		if (value == null)
		{
			return DateTime.MinValue;
		}
		if (value is DateTime)
		{
			return (DateTime)value;
		}
		if (value is double)
		{
			return CellsHelper.GetDateTimeFromDouble((double)value, date1904: false);
		}
		if (value is int)
		{
			return CellsHelper.GetDateTimeFromDouble((int)value, date1904: false);
		}
		return DateTime.MinValue;
	}
}
