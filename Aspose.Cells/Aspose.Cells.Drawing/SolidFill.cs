using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Aspose.Cells.Drawing;

public class SolidFill
{
	internal InternalColor internalColor_0 = new InternalColor(bool_0: true);

	internal InternalColor internalColor_1 = new InternalColor(bool_0: true);

	private object object_0;

	internal Workbook workbook_0;

	private int int_0 = 100000;

	public Color Color
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

	public CellsColor CellsColor
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

	internal Color BackgroundColor
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

	internal SolidFill(object object_1, Workbook workbook_1)
	{
		object_0 = object_1;
		workbook_0 = workbook_1;
	}

	[SpecialName]
	internal int method_0()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_1(int int_1)
	{
		int_0 = int_1;
	}

	[SpecialName]
	internal int method_2()
	{
		return int_0 / 1000;
	}

	[SpecialName]
	internal void method_3(int int_1)
	{
		int_0 = int_1 * 1000;
	}

	internal void Copy(SolidFill solidFill_0)
	{
		int_0 = solidFill_0.int_0;
		if (solidFill_0.internalColor_0.ColorType == ColorType.IndexedColor && solidFill_0.workbook_0 != workbook_0)
		{
			internalColor_0.SetColor(ColorType.RGB, solidFill_0.internalColor_0.method_7(solidFill_0.workbook_0));
		}
		else
		{
			internalColor_0.method_19(solidFill_0.internalColor_0);
		}
		if (solidFill_0.internalColor_1.ColorType == ColorType.IndexedColor && solidFill_0.workbook_0 != workbook_0)
		{
			internalColor_1.SetColor(ColorType.RGB, solidFill_0.internalColor_1.method_7(solidFill_0.workbook_0));
		}
		else
		{
			internalColor_1.method_19(solidFill_0.internalColor_1);
		}
	}
}
