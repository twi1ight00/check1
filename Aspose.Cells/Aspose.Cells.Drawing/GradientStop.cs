using System;
using System.Runtime.CompilerServices;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Represents the gradient stop.
///       </summary>
public class GradientStop
{
	private GradientStopCollection gradientStopCollection_0;

	private int int_0;

	internal InternalColor internalColor_0;

	private int int_1 = 100000;

	/// <summary>
	///       The position of the stop.
	///       </summary>
	public double Position
	{
		get
		{
			return (double)int_0 / 1000.0;
		}
		set
		{
			int_0 = (int)(value * 1000.0 + 0.5);
		}
	}

	/// <summary>
	///       Gets the color of this gradient stop.
	///       </summary>
	public CellsColor CellsColor
	{
		get
		{
			Workbook workbook_ = gradientStopCollection_0.GradientFill.workbook_0;
			CellsColor cellsColor = new CellsColor(workbook_);
			cellsColor.internalColor_0 = internalColor_0;
			return cellsColor;
		}
	}

	public double Transparency
	{
		get
		{
			return Math.Round((double)(100 - method_2()) / 100.0, 2);
		}
		set
		{
			if (value < 0.0 || value > 1.0)
			{
				throw new CellsException(ExceptionType.InvalidData, "Transparency must between 0.0 (opaque) and 1.0 (clear)");
			}
			int int_ = 100 - (int)(value * 100.0);
			method_3(int_);
		}
	}

	internal GradientStop(GradientStopCollection gradientStopCollection_1)
	{
		gradientStopCollection_0 = gradientStopCollection_1;
		internalColor_0 = new InternalColor(bool_0: true);
	}

	[SpecialName]
	internal int method_0()
	{
		return int_1;
	}

	[SpecialName]
	internal void method_1(int int_2)
	{
		int_1 = int_2;
	}

	[SpecialName]
	internal int method_2()
	{
		return int_1 / 1000;
	}

	[SpecialName]
	internal void method_3(int int_2)
	{
		int_1 = int_2 * 1000;
	}

	internal void Copy(GradientStop gradientStop_0)
	{
		int_1 = gradientStop_0.int_1;
		internalColor_0.method_19(gradientStop_0.internalColor_0);
		int_0 = gradientStop_0.int_0;
	}
}
