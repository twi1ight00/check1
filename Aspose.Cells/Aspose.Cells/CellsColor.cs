using System.Drawing;
using ns2;

namespace Aspose.Cells;

/// <summary>
///       Represents all types of color.
///       </summary>
public class CellsColor
{
	private Workbook workbook_0;

	internal InternalColor internalColor_0;

	private int int_0 = 100000;

	/// <summary>
	///       Gets and set the color which should apply to cell or shape.
	///       </summary>
	/// <remarks>
	///       The expression of the color of the cell and the shape is different.
	///       For exampe :the theme color with same tint value will be not same in the cell and the shape.
	///       </remarks>
	public bool IsShapeColor
	{
		get
		{
			return internalColor_0.IsShapeColor;
		}
		set
		{
			internalColor_0.IsShapeColor = value;
		}
	}

	/// <summary>
	///       The color type.
	///       </summary>
	public ColorType Type => internalColor_0.ColorType;

	/// <summary>
	///       Gets the theme color. Only applies for theme color type.
	///       </summary>
	public ThemeColor ThemeColor
	{
		get
		{
			if (Type == ColorType.Theme)
			{
				ThemeColorType type = Class1673.smethod_1(internalColor_0.method_4());
				double tint = internalColor_0.Tint;
				return new ThemeColor(type, tint);
			}
			return new ThemeColor(ThemeColorType.Background1, 0.0);
		}
		set
		{
			internalColor_0.SetColor(ColorType.Theme, Class1673.smethod_2(value.ColorType));
			internalColor_0.Tint = value.Tint;
		}
	}

	/// <summary>
	///       Gets and sets the color index in the color palette.. Only applies of indexed color.
	///       </summary>
	public int ColorIndex
	{
		get
		{
			return internalColor_0.method_4() - 8;
		}
		set
		{
			internalColor_0.SetColor(ColorType.IndexedColor, value + 8);
		}
	}

	/// <summary>
	///       Gets and sets the RGB color.
	///       </summary>
	public Color Color
	{
		get
		{
			return internalColor_0.method_6(workbook_0);
		}
		set
		{
			internalColor_0.SetColor(ColorType.RGB, value.ToArgb());
		}
	}

	internal CellsColor(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		internalColor_0 = new InternalColor(bool_0: false);
	}

	internal CellsColor(Workbook workbook_1, InternalColor internalColor_1)
	{
		workbook_0 = workbook_1;
		internalColor_0 = internalColor_1;
	}

	internal void Copy(CellsColor cellsColor_0, CopyOptions copyOptions_0)
	{
		int_0 = cellsColor_0.int_0;
		if (cellsColor_0.workbook_0 != workbook_0 && !copyOptions_0.bool_0)
		{
			Color = cellsColor_0.Color;
		}
		else
		{
			internalColor_0.method_19(cellsColor_0.internalColor_0);
		}
	}

	/// <summary>
	///       Set the tint of the shape color
	///       </summary>
	/// <param name="tint">
	/// </param>
	public void SetTintOfShapeColor(double tint)
	{
		internalColor_0.method_16(tint);
	}
}
