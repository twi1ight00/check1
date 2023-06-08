using System.Drawing;
using System.Runtime.CompilerServices;

namespace Aspose.Cells;

/// <summary>
///       Represents the color filter.
///       </summary>
public class ColorFilter
{
	private FilterColumn filterColumn_0;

	private bool bool_0 = true;

	private int int_0;

	private InternalColor internalColor_0 = new InternalColor(bool_0: false);

	/// <summary>
	///       Flag indicating whether or not to filter by the cell's fill color.
	///       </summary>
	public bool FilterByFillColor
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	internal ColorFilter(FilterColumn filterColumn_1)
	{
		filterColumn_0 = filterColumn_1;
	}

	internal bool method_0(Cell cell_0, int int_1, int int_2)
	{
		Worksheet worksheet = filterColumn_0.method_4().AutoFilter.method_0();
		WorksheetCollection worksheetCollection = worksheet.method_2();
		if (int_0 >= 0 && int_0 <= worksheetCollection.method_56().Count)
		{
			Style style = worksheetCollection.method_56()[int_0];
			Style style2 = null;
			int num = worksheet.Cells.method_41(cell_0, 0, 0);
			style2 = ((num != -1) ? worksheetCollection.method_45(num) : worksheetCollection.DefaultStyle);
			if (bool_0)
			{
				switch (style.Pattern)
				{
				default:
					if (style2.Pattern == style.Pattern && style2.ForeInternalColor.method_10(style.ForeInternalColor, worksheetCollection.Workbook, worksheetCollection.Workbook))
					{
						return style2.BackgroundInternalColor.method_10(style.BackgroundInternalColor, worksheetCollection.Workbook, worksheetCollection.Workbook);
					}
					return false;
				case BackgroundType.None:
					return style2.Pattern == BackgroundType.None;
				case BackgroundType.Solid:
					if (style2.Pattern == BackgroundType.Solid)
					{
						return style2.ForeInternalColor.method_10(style.ForeInternalColor, worksheetCollection.Workbook, worksheetCollection.Workbook);
					}
					return false;
				}
			}
			if (style.ForeInternalColor.method_2())
			{
				return (style2.Font.Color.ToArgb() & 0xFFFFFF) == 0;
			}
			return style2.Font.InternalColor.method_10(style.ForeInternalColor, worksheetCollection.Workbook, worksheetCollection.Workbook);
		}
		return true;
	}

	internal void Copy(ColorFilter colorFilter_0, bool bool_1)
	{
		bool_0 = colorFilter_0.bool_0;
		int_0 = colorFilter_0.int_0;
	}

	[SpecialName]
	internal int method_1()
	{
		return int_0;
	}

	[SpecialName]
	internal void method_2(int int_1)
	{
		int_0 = int_1;
	}

	/// <summary>
	/// </summary>
	/// <param name="sheets">
	/// </param>
	/// <returns>
	/// </returns>
	public Color GetColor(WorksheetCollection sheets)
	{
		return internalColor_0.method_6(sheets.Workbook);
	}
}
