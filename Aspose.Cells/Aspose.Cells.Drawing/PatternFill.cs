using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Aspose.Cells.Drawing;

public class PatternFill
{
	private object object_0;

	private Workbook workbook_0;

	private int int_0 = 100000;

	private int int_1 = 100000;

	private FillPattern fillPattern_0;

	internal InternalColor internalColor_0;

	internal InternalColor internalColor_1;

	public FillPattern Pattern
	{
		get
		{
			return fillPattern_0;
		}
		set
		{
			fillPattern_0 = value;
		}
	}

	public Color BackgroundColor
	{
		get
		{
			return internalColor_0.method_6(workbook_0);
		}
		set
		{
			internalColor_0.SetColor(ColorType.RGB, value.ToArgb());
			if (object_0 is Area)
			{
				Area area = (Area)object_0;
				area.method_1();
			}
		}
	}

	public CellsColor BackgroundCellsColor
	{
		get
		{
			return new CellsColor(workbook_0, internalColor_0);
		}
		set
		{
			internalColor_0 = value.internalColor_0;
			if (object_0 is Area)
			{
				Area area = (Area)object_0;
				area.method_1();
			}
		}
	}

	public Color ForegroundColor
	{
		get
		{
			return internalColor_1.method_6(workbook_0);
		}
		set
		{
			internalColor_1.SetColor(ColorType.RGB, value.ToArgb());
			if (object_0 is Area)
			{
				Area area = (Area)object_0;
				area.method_1();
			}
		}
	}

	public CellsColor ForegroundCellsColor
	{
		get
		{
			return new CellsColor(workbook_0, internalColor_1);
		}
		set
		{
			internalColor_1 = value.internalColor_0;
			if (object_0 is Area)
			{
				Area area = (Area)object_0;
				area.method_1();
			}
		}
	}

	internal PatternFill(object object_1, Workbook workbook_1)
	{
		object_0 = object_1;
		workbook_0 = workbook_1;
		internalColor_0 = new InternalColor(bool_0: true);
		internalColor_1 = new InternalColor(bool_0: true);
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0 / 1000;
	}

	[SpecialName]
	internal void method_1(int int_2)
	{
		int_0 = int_2 * 1000;
	}

	[SpecialName]
	internal double method_2()
	{
		return Math.Round((double)(100 - method_0()) / 100.0, 2);
	}

	[SpecialName]
	internal void method_3(double double_0)
	{
		if (double_0 < 0.0 || double_0 > 1.0)
		{
			throw new CellsException(ExceptionType.InvalidData, "Transparency must between 0.0 (opaque) and 1.0 (clear)");
		}
		int int_ = 100 - (int)(double_0 * 100.0);
		method_1(int_);
	}

	[SpecialName]
	internal int method_4()
	{
		return int_1 / 1000;
	}

	[SpecialName]
	internal void method_5(int int_2)
	{
		int_1 = int_2 * 1000;
	}

	[SpecialName]
	internal double method_6()
	{
		return Math.Round((double)(100 - method_4()) / 100.0, 2);
	}

	internal void Copy(PatternFill patternFill_0)
	{
		int_0 = patternFill_0.int_0;
		int_1 = patternFill_0.int_1;
		fillPattern_0 = patternFill_0.fillPattern_0;
		if (patternFill_0.internalColor_0.ColorType == ColorType.IndexedColor && patternFill_0.workbook_0 != workbook_0)
		{
			internalColor_0.SetColor(ColorType.RGB, patternFill_0.internalColor_0.method_7(patternFill_0.workbook_0));
		}
		else
		{
			internalColor_0.method_19(patternFill_0.internalColor_0);
		}
		if (patternFill_0.internalColor_1.ColorType == ColorType.IndexedColor && patternFill_0.workbook_0 != workbook_0)
		{
			internalColor_1.SetColor(ColorType.RGB, patternFill_0.internalColor_1.method_7(patternFill_0.workbook_0));
		}
		else
		{
			internalColor_1.method_19(patternFill_0.internalColor_1);
		}
	}
}
