using System;
using System.Collections;
using ns45;

namespace Aspose.Cells.Pivot;

/// <summary>
///       Represents Group Range in a PivotField.
///       </summary>
public class SxRng
{
	internal bool bool_0;

	internal bool bool_1;

	internal PivotGroupByType pivotGroupByType_0;

	internal ArrayList arrayList_0;

	internal byte[] byte_0;

	internal DateTime dateTime_0;

	internal DateTime dateTime_1;

	internal double double_0;

	internal double double_1;

	internal double double_2;

	internal int int_0;

	internal int int_1;

	internal Class1161 class1161_0;

	internal ArrayList arrayList_1;

	public object IsAutoStart => bool_0;

	public object IsAutoEnd => bool_1;

	/// <summary>
	///       Represents the start object for the group range.
	///       </summary>
	public object Start
	{
		get
		{
			if (pivotGroupByType_0 == PivotGroupByType.RangeOfValues)
			{
				return double_0;
			}
			return dateTime_0;
		}
	}

	/// <summary>
	///       Represents the end object for the group range.
	///       </summary>
	public object End
	{
		get
		{
			if (pivotGroupByType_0 == PivotGroupByType.RangeOfValues)
			{
				return double_1;
			}
			return dateTime_1;
		}
	}

	/// <summary>
	///       Represents the interval object for the group range.
	///       </summary>
	public object By => double_2;

	public bool[] GroupByTypes
	{
		get
		{
			bool[] array = new bool[8];
			bool[] array2 = array;
			if (class1161_0 != null && class1161_0.method_0() != null)
			{
				ArrayList arrayList = class1161_0.method_0().arrayList_0;
				foreach (Class1161 item in arrayList)
				{
					if (item.method_20() && item.sxRng_0.int_0 == int_0)
					{
						switch (item.sxRng_0.pivotGroupByType_0)
						{
						case PivotGroupByType.RangeOfValues:
							array2[0] = true;
							break;
						case PivotGroupByType.Seconds:
							array2[1] = true;
							break;
						case PivotGroupByType.Minutes:
							array2[2] = true;
							break;
						case PivotGroupByType.Hours:
							array2[3] = true;
							break;
						case PivotGroupByType.Days:
							array2[4] = true;
							break;
						case PivotGroupByType.Months:
							array2[5] = true;
							break;
						case PivotGroupByType.Quarters:
							array2[6] = true;
							break;
						case PivotGroupByType.Years:
							array2[7] = true;
							break;
						}
					}
				}
			}
			return array2;
		}
	}

	internal SxRng(Class1161 class1161_1)
	{
		byte_0 = new byte[2];
		int_0 = -1;
		int_1 = -1;
		double_2 = 1.0;
		class1161_0 = class1161_1;
		bool_0 = true;
		bool_1 = true;
	}
}
