using System;
using ns12;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents a scroll bar object.
///       </summary>
/// <remarks>Scroll value must be between 0 and 30000.</remarks>
public class ScrollBar : Shape
{
	private ushort ushort_1;

	private ushort ushort_2;

	private ushort ushort_3;

	private ushort ushort_4;

	private ushort ushort_5;

	private bool bool_3;

	private bool bool_4;

	/// <summary>
	///       Gets or sets the current value.
	///       </summary>
	public int CurrentValue
	{
		get
		{
			return ushort_1;
		}
		set
		{
			method_70(value);
			if (value < ushort_2)
			{
				ushort_1 = ushort_2;
			}
			else if (value > ushort_3)
			{
				ushort_1 = ushort_3;
			}
			else
			{
				ushort_1 = (ushort)value;
			}
			if (method_58() == null)
			{
				return;
			}
			byte[] data = method_58();
			bool isArea = false;
			CellArea cellArea = Class1279.smethod_2(method_25(), data, 0, 0, 0, out isArea);
			if (isArea)
			{
				if (value >= 0)
				{
					method_26().Cells.GetCell(cellArea.StartRow, cellArea.StartColumn, bool_2: false).PutValue(ushort_1);
				}
				else
				{
					method_26().Cells.GetCell(cellArea.StartRow, cellArea.StartColumn, bool_2: false).PutValue(null);
				}
			}
		}
	}

	/// <summary>
	///       Gets or sets the minimum value of a scroll bar or spinner range.
	///       </summary>
	public int Min
	{
		get
		{
			return ushort_2;
		}
		set
		{
			method_70(value);
			if (value > ushort_3)
			{
				throw new ArgumentException("The scroll value maximum cannot be less than the scroll value minmum");
			}
			ushort_2 = (ushort)value;
			if (ushort_1 < value)
			{
				ushort_1 = (ushort)value;
			}
		}
	}

	/// <summary>
	///       Gets or sets the maximum value of a scroll bar or spinner range.
	///       </summary>
	public int Max
	{
		get
		{
			return ushort_3;
		}
		set
		{
			method_70(value);
			if (value < ushort_2)
			{
				throw new ArgumentException("The scroll value maximum cannot be less than the scroll value minmum");
			}
			ushort_3 = (ushort)value;
			if (ushort_1 > value)
			{
				ushort_1 = (ushort)value;
			}
		}
	}

	/// <summary>
	///       Gets or sets the amount that the scroll bar or spinner is incremented a line scroll.
	///       </summary>
	public int IncrementalChange
	{
		get
		{
			return ushort_4;
		}
		set
		{
			method_70(value);
			ushort_4 = (ushort)value;
		}
	}

	/// <summary>
	/// </summary>
	public int PageChange
	{
		get
		{
			return ushort_5;
		}
		set
		{
			method_70(value);
			ushort_5 = (ushort)value;
		}
	}

	/// <summary>
	///       Indicates whether the shape has 3-D shading.
	///       </summary>
	public bool Shadow
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	/// <summary>
	///       Indicates whether this is a horizontal scroll bar.
	///       </summary>
	public bool IsHorizontal
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	internal ScrollBar(ShapeCollection shapeCollection_1)
		: base(shapeCollection_1, MsoDrawingType.ScrollBar, shapeCollection_1)
	{
		ushort_1 = 0;
		ushort_2 = 0;
		ushort_3 = 100;
		ushort_4 = 1;
		ushort_5 = 10;
		bool_3 = true;
	}

	internal void method_69(int int_0)
	{
		ushort_1 = (ushort)int_0;
	}

	private void method_70(int int_0)
	{
		if (int_0 < 0 || int_0 > 30000)
		{
			throw new ArgumentException("Scroll value must be between 0 and 30000.");
		}
	}

	internal void Copy(ScrollBar scrollBar_0, CopyOptions copyOptions_0)
	{
		ushort_2 = scrollBar_0.ushort_2;
		ushort_3 = scrollBar_0.ushort_3;
		ushort_5 = scrollBar_0.ushort_5;
		ushort_4 = scrollBar_0.ushort_4;
		ushort_1 = scrollBar_0.ushort_1;
		bool_3 = scrollBar_0.bool_3;
		Copy((Shape)scrollBar_0, copyOptions_0);
	}
}
