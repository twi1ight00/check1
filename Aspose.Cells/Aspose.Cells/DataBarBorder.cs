using System.Drawing;
using System.Runtime.CompilerServices;

namespace Aspose.Cells;

public class DataBarBorder
{
	private InternalColor internalColor_0;

	private DataBarBorderType dataBarBorderType_0;

	private Workbook workbook_0;

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

	public DataBarBorderType Type
	{
		get
		{
			return dataBarBorderType_0;
		}
		set
		{
			dataBarBorderType_0 = value;
		}
	}

	internal DataBarBorder(DataBar dataBar_0)
	{
		internalColor_0 = new InternalColor(bool_0: false);
		workbook_0 = dataBar_0.workbook_0;
	}

	internal void Copy(DataBarBorder dataBarBorder_0)
	{
		workbook_0 = dataBarBorder_0.workbook_0;
		internalColor_0 = dataBarBorder_0.internalColor_0;
		dataBarBorderType_0 = dataBarBorder_0.dataBarBorderType_0;
	}

	[SpecialName]
	internal InternalColor method_0()
	{
		return internalColor_0;
	}

	[SpecialName]
	internal void method_1(InternalColor internalColor_1)
	{
		internalColor_0 = internalColor_1;
	}
}
