using System.Collections;
using ns21;
using ns52;

namespace Aspose.Cells.Drawing;

/// <summary>
///       Reprensents the picture format.
///       </summary>
public class MsoFormatPicture
{
	private Class1711 class1711_0;

	internal Class1109 class1109_0;

	internal ArrayList arrayList_0;

	public double TopCrop
	{
		get
		{
			return class1711_0.method_7(256, 0f);
		}
		set
		{
			class1711_0.method_8(256, (float)value);
		}
	}

	public double BottomCrop
	{
		get
		{
			return class1711_0.method_7(257, 0f);
		}
		set
		{
			class1711_0.method_8(257, (float)value);
		}
	}

	public double LeftCrop
	{
		get
		{
			return class1711_0.method_7(258, 0f);
		}
		set
		{
			class1711_0.method_8(258, (float)value);
		}
	}

	public double RightCrop
	{
		get
		{
			return class1711_0.method_7(259, 0f);
		}
		set
		{
			class1711_0.method_8(259, (float)value);
		}
	}

	/// <summary>
	///       Gets and sets the transparent color of the picture.
	///       </summary>
	public CellsColor TransparentColor
	{
		get
		{
			if (class1109_0 == null)
			{
				return null;
			}
			if (class1109_0.cellsColor_0 != null && class1109_0.cellsColor_1 != null && class1109_0.cellsColor_0.internalColor_0.ColorType == class1109_0.cellsColor_1.internalColor_0.ColorType && class1109_0.cellsColor_0.internalColor_0.method_4() == class1109_0.cellsColor_1.internalColor_0.method_4() && class1109_0.int_0 == -1 && class1109_0.int_1 == 0)
			{
				CellsColor cellsColor = class1711_0.method_9().Workbook.CreateCellsColor();
				cellsColor.internalColor_0 = class1109_0.cellsColor_0.internalColor_0;
				return cellsColor;
			}
			return null;
		}
		set
		{
			if (value != null && !value.internalColor_0.method_2())
			{
				class1109_0 = new Class1109();
				class1109_0.cellsColor_0 = class1711_0.method_9().Workbook.CreateCellsColor();
				class1109_0.cellsColor_0.internalColor_0 = value.internalColor_0;
				class1109_0.cellsColor_1 = class1711_0.method_9().Workbook.CreateCellsColor();
				class1109_0.cellsColor_1.internalColor_0 = value.internalColor_0;
				class1109_0.int_1 = 0;
			}
			else
			{
				class1109_0 = null;
			}
		}
	}

	public double Contrast
	{
		get
		{
			double num = class1711_0.method_4(264, 65536);
			if (num == 0.0)
			{
				return 0.0;
			}
			if (num >= 65536.0)
			{
				return 100.0 - 100.0 / (num / 32768.0);
			}
			return 100.0 * (num / 131072.0);
		}
	}

	public double Brightness
	{
		get
		{
			double num = class1711_0.method_4(265, 0);
			if (num == 0.0)
			{
				return 50.0;
			}
			return 50.0 + 50.0 * num / 32768.0;
		}
	}

	public bool IsBiLevel => class1711_0.method_5(319, 1, bool_0: false);

	public bool IsGray => class1711_0.method_5(319, 2, bool_0: false);

	internal MsoFormatPicture(Shape shape_0)
	{
		class1711_0 = shape_0.method_27().method_2();
	}
}
