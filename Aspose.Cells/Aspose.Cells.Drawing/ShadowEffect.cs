using System;
using System.Drawing;
using ns21;

namespace Aspose.Cells.Drawing;

/// <summary>
///       This class specifies the shadow effect of the chart element or shape.
///       </summary>
public class ShadowEffect
{
	private ShapePropertyCollection shapePropertyCollection_0;

	/// <summary>
	///       Gets and sets the preset shadow type of the shadow.
	///       </summary>
	public PresetShadowType PresetType
	{
		get
		{
			return method_0();
		}
		set
		{
			method_1(value);
			shapePropertyCollection_0.method_6();
		}
	}

	/// <summary>
	///       Gets and sets the color of the shadow.
	///       </summary>
	public CellsColor Color
	{
		get
		{
			Class1288 @class = shapePropertyCollection_0.method_5();
			Class1291 class2 = @class.method_9();
			Class1289 class3 = @class.method_7();
			if (class2 != null)
			{
				return class2.method_0();
			}
			if (class3 != null)
			{
				return class3.GetColor();
			}
			method_4(50800, 50800, 5400000, 100000, 100000, 0, 0, RectangleAlignmentType.Center, -1);
			class2 = @class.method_9();
			return class2.method_0();
		}
		set
		{
			if (value != null)
			{
				Class1288 @class = shapePropertyCollection_0.method_5();
				Class1291 class2 = @class.method_9();
				Class1289 class3 = @class.method_7();
				if (class2 != null)
				{
					class2.method_1(value);
					return;
				}
				if (class3 != null)
				{
					class3.SetColor(value);
					return;
				}
				method_4(50800, 50800, 5400000, 100000, 100000, 0, 0, RectangleAlignmentType.Center, -1);
				class2 = @class.method_9();
				class2.method_1(value);
			}
		}
	}

	/// <summary>
	///       Gets and sets the degree of transparency of the shadow. Range from 0.0 (opaque) to 1.0 (clear).
	///       </summary>
	public double Transparency
	{
		get
		{
			method_7();
			int num = ((shapePropertyCollection_0.method_5().method_7() == null) ? shapePropertyCollection_0.method_5().method_9().method_2() : shapePropertyCollection_0.method_5().method_7().method_1());
			return Math.Round(1.0 - (double)num / 100000.0, 2);
		}
		set
		{
			if (!(value < 0.0) && value <= 1.0)
			{
				method_7();
				if (shapePropertyCollection_0.method_5().method_7() != null)
				{
					shapePropertyCollection_0.method_5().method_7().method_2((int)((1.0 - value) * 100000.0));
				}
				else
				{
					shapePropertyCollection_0.method_5().method_9().method_3((int)((1.0 - value) * 100000.0));
				}
				return;
			}
			throw new CellsException(ExceptionType.InvalidData, "Transparency must between 0.0 (opaque) and 1.0 (clear)");
		}
	}

	/// <summary>
	///       Gets and sets the size of the shadow. Range from 0 to 2.0. 
	///       Meaningless in inner shadow.
	///       </summary>
	public double Size
	{
		get
		{
			Class1291 @class = shapePropertyCollection_0.method_5().method_9();
			if (@class != null)
			{
				if (@class.method_13() == @class.method_15())
				{
					return (double)@class.method_13() / 100000.0;
				}
				return 1.0;
			}
			return 0.0;
		}
		set
		{
			if (!(value < 0.0) && value <= 2.0)
			{
				method_7();
				Class1291 @class = shapePropertyCollection_0.method_5().method_9();
				if (@class != null)
				{
					@class.method_14((int)(value * 100000.0));
					@class.method_16((int)(value * 100000.0));
				}
				return;
			}
			throw new CellsException(ExceptionType.InvalidData, "Size must between 0.0 and 2.0");
		}
	}

	/// <summary>
	///       Gets and sets the blur of the shadow. Range from 0 to 100 points.
	///       </summary>
	public double Blur
	{
		get
		{
			return shapePropertyCollection_0.method_5().method_9()?.method_4() ?? shapePropertyCollection_0.method_5().method_7()?.method_3() ?? 0.0;
		}
		set
		{
			if (!(value < 0.0) && value <= 100.0)
			{
				method_7();
				shapePropertyCollection_0.method_5().method_9()?.method_5(value);
				shapePropertyCollection_0.method_5().method_7()?.method_4(value);
				return;
			}
			throw new CellsException(ExceptionType.InvalidData, "Blur must between 0 and 100 points");
		}
	}

	/// <summary>
	///       Gets and sets the lighting angle. Range from 0 to 359.9 degrees.
	///       </summary>
	public double Angle
	{
		get
		{
			return shapePropertyCollection_0.method_5().method_9()?.Direction ?? shapePropertyCollection_0.method_5().method_7()?.Direction ?? 0.0;
		}
		set
		{
			if (!(value < 0.0) && value <= 359.9)
			{
				method_7();
				Class1291 @class = shapePropertyCollection_0.method_5().method_9();
				if (@class != null)
				{
					@class.Direction = value;
				}
				Class1289 class2 = shapePropertyCollection_0.method_5().method_7();
				if (class2 != null)
				{
					class2.Direction = value;
				}
				return;
			}
			throw new CellsException(ExceptionType.InvalidData, "Angle must between 0 and 359.9 degrees");
		}
	}

	/// <summary>
	///       Gets and sets the distance of the shadow. Range from 0 to 200 points.
	///       </summary>
	public double Distance
	{
		get
		{
			return shapePropertyCollection_0.method_5().method_9()?.Distance ?? shapePropertyCollection_0.method_5().method_7()?.Distance ?? 0.0;
		}
		set
		{
			if (!(value < 0.0) && value <= 200.0)
			{
				method_7();
				Class1291 @class = shapePropertyCollection_0.method_5().method_9();
				if (@class != null)
				{
					@class.Distance = value;
				}
				Class1289 class2 = shapePropertyCollection_0.method_5().method_7();
				if (class2 != null)
				{
					class2.Distance = value;
				}
				return;
			}
			throw new CellsException(ExceptionType.InvalidData, "Distance must between 0 and 200 points");
		}
	}

	internal ShadowEffect(ShapePropertyCollection shapePropertyCollection_1)
	{
		shapePropertyCollection_0 = shapePropertyCollection_1;
	}

	private PresetShadowType method_0()
	{
		Class1288 @class = shapePropertyCollection_0.method_4();
		if (@class == null)
		{
			return PresetShadowType.NoShadow;
		}
		Class1291 class2 = @class.method_9();
		Class1289 class3 = @class.method_7();
		if (class2 == null && class3 == null)
		{
			return PresetShadowType.NoShadow;
		}
		if (class2 != null)
		{
			if (method_5(class2, 50800, 38100, 2700000, 100000, 100000, 0, 0, RectangleAlignmentType.TopLeft, 40000))
			{
				return PresetShadowType.OffsetDiagonalBottomRight;
			}
			if (method_5(class2, 50800, 38100, 5400000, 100000, 100000, 0, 0, RectangleAlignmentType.Top, 40000))
			{
				return PresetShadowType.OffsetBottom;
			}
			if (method_5(class2, 50800, 38100, 8100000, 100000, 100000, 0, 0, RectangleAlignmentType.TopRight, 40000))
			{
				return PresetShadowType.OffsetDiagonalBottomLeft;
			}
			if (method_5(class2, 50800, 38100, 0, 100000, 100000, 0, 0, RectangleAlignmentType.Left, 40000))
			{
				return PresetShadowType.OffsetRight;
			}
			if (method_5(class2, 63500, 0, 0, 102000, 102000, 0, 0, RectangleAlignmentType.Center, 40000))
			{
				return PresetShadowType.OffsetCenter;
			}
			if (method_5(class2, 50800, 38100, 10800000, 100000, 100000, 0, 0, RectangleAlignmentType.Right, 40000))
			{
				return PresetShadowType.OffsetLeft;
			}
			if (method_5(class2, 50800, 38100, 18900000, 100000, 100000, 0, 0, RectangleAlignmentType.BottomLeft, 40000))
			{
				return PresetShadowType.OffsetDiagonalTopRight;
			}
			if (method_5(class2, 50800, 38100, 16200000, 100000, 100000, 0, 0, RectangleAlignmentType.Bottom, 40000))
			{
				return PresetShadowType.OffsetTop;
			}
			if (method_5(class2, 50800, 38100, 13500000, 100000, 100000, 0, 0, RectangleAlignmentType.BottomRight, 40000))
			{
				return PresetShadowType.OffsetDiagonalTopLeft;
			}
			if (method_5(class2, 76200, 0, 13500000, 100000, 23000, 1200000, 0, RectangleAlignmentType.BottomRight, 20000))
			{
				return PresetShadowType.PerspectiveDiagonalUpperLeft;
			}
			if (method_5(class2, 76200, 0, 18900000, 100000, 23000, -1200000, 0, RectangleAlignmentType.BottomLeft, 20000))
			{
				return PresetShadowType.PerspectiveDiagonalUpperRight;
			}
			if (method_5(class2, 152400, 317500, 5400000, 90000, -19000, 0, 0, RectangleAlignmentType.Bottom, 15000))
			{
				return PresetShadowType.Below;
			}
			if (method_5(class2, 76200, 12700, 8100000, 100000, -23000, 800400, 0, RectangleAlignmentType.BottomRight, 20000))
			{
				return PresetShadowType.PerspectiveDiagonalLowerLeft;
			}
			if (method_5(class2, 76200, 12700, 2700000, 100000, -23000, -800400, 0, RectangleAlignmentType.BottomLeft, 20000))
			{
				return PresetShadowType.PerspectiveDiagonalLowerRight;
			}
		}
		if (class3 != null)
		{
			if (method_6(class3, 63500, 50800, 13500000))
			{
				return PresetShadowType.InsideDiagonalTopLeft;
			}
			if (method_6(class3, 63500, 50800, 16200000))
			{
				return PresetShadowType.InsideTop;
			}
			if (method_6(class3, 63500, 50800, 18900000))
			{
				return PresetShadowType.InsideDiagonalTopRight;
			}
			if (method_6(class3, 63500, 50800, 10800000))
			{
				return PresetShadowType.InsideLeft;
			}
			if (method_6(class3, 114300, 0, 0))
			{
				return PresetShadowType.InsideCenter;
			}
			if (method_6(class3, 63500, 50800, 0))
			{
				return PresetShadowType.InsideRight;
			}
			if (method_6(class3, 63500, 50800, 8100000))
			{
				return PresetShadowType.InsideDiagonalBottomLeft;
			}
			if (method_6(class3, 63500, 50800, 5400000))
			{
				return PresetShadowType.InsideBottom;
			}
			if (method_6(class3, 63500, 50800, 2700000))
			{
				return PresetShadowType.InsideDiagonalBottomRight;
			}
		}
		return PresetShadowType.Custom;
	}

	private void method_1(PresetShadowType presetShadowType_0)
	{
		switch (presetShadowType_0)
		{
		case PresetShadowType.NoShadow:
			shapePropertyCollection_0.ClearShadowEffect();
			break;
		case PresetShadowType.OffsetDiagonalBottomRight:
			method_4(50800, 38100, 2700000, 100000, 100000, 0, 0, RectangleAlignmentType.TopLeft, 40000);
			break;
		case PresetShadowType.OffsetBottom:
			method_4(50800, 38100, 5400000, 100000, 100000, 0, 0, RectangleAlignmentType.Top, 40000);
			break;
		case PresetShadowType.OffsetDiagonalBottomLeft:
			method_4(50800, 38100, 8100000, 100000, 100000, 0, 0, RectangleAlignmentType.TopRight, 40000);
			break;
		case PresetShadowType.OffsetRight:
			method_4(50800, 38100, 0, 100000, 100000, 0, 0, RectangleAlignmentType.Left, 40000);
			break;
		case PresetShadowType.OffsetCenter:
			method_4(63500, 0, 0, 102000, 102000, 0, 0, RectangleAlignmentType.Center, 40000);
			break;
		case PresetShadowType.OffsetLeft:
			method_4(50800, 38100, 10800000, 100000, 100000, 0, 0, RectangleAlignmentType.Right, 40000);
			break;
		case PresetShadowType.OffsetDiagonalTopRight:
			method_4(50800, 38100, 18900000, 100000, 100000, 0, 0, RectangleAlignmentType.BottomLeft, 40000);
			break;
		case PresetShadowType.OffsetTop:
			method_4(50800, 38100, 16200000, 100000, 100000, 0, 0, RectangleAlignmentType.Bottom, 40000);
			break;
		case PresetShadowType.OffsetDiagonalTopLeft:
			method_4(50800, 38100, 13500000, 100000, 100000, 0, 0, RectangleAlignmentType.BottomRight, 40000);
			break;
		case PresetShadowType.InsideDiagonalTopLeft:
			method_2(63500, 50800, 13500000);
			break;
		case PresetShadowType.InsideTop:
			method_2(63500, 50800, 16200000);
			break;
		case PresetShadowType.InsideDiagonalTopRight:
			method_2(63500, 50800, 18900000);
			break;
		case PresetShadowType.InsideLeft:
			method_2(63500, 50800, 10800000);
			break;
		case PresetShadowType.InsideCenter:
			method_3(114300, 0, 0, -1);
			break;
		case PresetShadowType.InsideRight:
			method_2(63500, 50800, 0);
			break;
		case PresetShadowType.InsideDiagonalBottomLeft:
			method_2(63500, 50800, 8100000);
			break;
		case PresetShadowType.InsideBottom:
			method_2(63500, 50800, 5400000);
			break;
		case PresetShadowType.InsideDiagonalBottomRight:
			method_2(63500, 50800, 2700000);
			break;
		case PresetShadowType.PerspectiveDiagonalUpperLeft:
			method_4(76200, 0, 13500000, 100000, 23000, 1200000, 0, RectangleAlignmentType.BottomRight, 20000);
			break;
		case PresetShadowType.PerspectiveDiagonalUpperRight:
			method_4(76200, 0, 18900000, 100000, 23000, -1200000, 0, RectangleAlignmentType.BottomLeft, 20000);
			break;
		case PresetShadowType.Below:
			method_4(152400, 317500, 5400000, 90000, -19000, 0, 0, RectangleAlignmentType.Bottom, 15000);
			break;
		case PresetShadowType.PerspectiveDiagonalLowerLeft:
			method_4(76200, 12700, 8100000, 100000, -23000, 800400, 0, RectangleAlignmentType.BottomRight, 20000);
			break;
		case PresetShadowType.PerspectiveDiagonalLowerRight:
			method_4(76200, 12700, 2700000, 100000, -23000, -800400, 0, RectangleAlignmentType.BottomLeft, 20000);
			break;
		}
	}

	private void method_2(int int_0, int int_1, int int_2)
	{
		method_3(int_0, int_1, int_2, 50000);
	}

	private void method_3(int int_0, int int_1, int int_2, int int_3)
	{
		Class1288 @class = shapePropertyCollection_0.method_5();
		@class.method_5();
		Class1289 class2 = @class.method_6();
		class2.int_0 = int_0;
		class2.int_2 = int_1;
		class2.int_1 = int_2;
		CellsColor cellsColor = new CellsColor(shapePropertyCollection_0.Workbook);
		cellsColor.Color = System.Drawing.Color.Black;
		class2.SetColor(cellsColor);
		if (int_3 != -1)
		{
			class2.method_2(int_3);
		}
	}

	private void method_4(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, RectangleAlignmentType rectangleAlignmentType_0, int int_7)
	{
		Class1288 @class = shapePropertyCollection_0.method_5();
		@class.method_5();
		Class1291 class2 = @class.method_8();
		class2.int_0 = int_0;
		class2.int_2 = int_1;
		class2.int_1 = int_2;
		class2.method_14(int_3);
		class2.method_16(int_4);
		class2.method_9(int_5);
		class2.method_11(int_6);
		class2.method_7(rectangleAlignmentType_0);
		class2.bool_0 = false;
		CellsColor cellsColor = new CellsColor(shapePropertyCollection_0.Workbook);
		cellsColor.Color = System.Drawing.Color.Black;
		class2.method_1(cellsColor);
		if (int_7 != -1)
		{
			class2.method_3(int_7);
		}
	}

	private bool method_5(Class1291 class1291_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, RectangleAlignmentType rectangleAlignmentType_0, int int_7)
	{
		if (class1291_0.int_0 == int_0 && class1291_0.int_2 == int_1 && class1291_0.int_1 == int_2 && class1291_0.method_13() == int_3 && class1291_0.method_15() == int_4 && class1291_0.method_8() == int_5 && class1291_0.method_10() == int_6 && class1291_0.method_6() == rectangleAlignmentType_0 && !class1291_0.method_12() && class1291_0.method_2() == int_7)
		{
			CellsColor cellsColor = class1291_0.method_0();
			if (cellsColor != null && cellsColor.Type == ColorType.RGB && cellsColor.internalColor_0.method_4() == 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private bool method_6(Class1289 class1289_0, int int_0, int int_1, int int_2)
	{
		if (class1289_0.int_0 == int_0 && class1289_0.int_2 == int_1 && class1289_0.int_1 == int_2 && class1289_0.method_0() == 50)
		{
			CellsColor color = class1289_0.GetColor();
			if (color != null && color.Type == ColorType.RGB && color.internalColor_0.method_4() == 0)
			{
				return true;
			}
			return false;
		}
		return false;
	}

	private void method_7()
	{
		Class1288 @class = shapePropertyCollection_0.method_5();
		Class1291 class2 = @class.method_9();
		Class1289 class3 = @class.method_7();
		if (class2 == null && class3 == null)
		{
			method_4(50800, 50800, 5400000, 100000, 100000, 0, 0, RectangleAlignmentType.Center, 43);
		}
		shapePropertyCollection_0.method_6();
	}
}
