using System.Drawing;
using System.Runtime.CompilerServices;

namespace Aspose.Cells;

public class NegativeBarFormat
{
	private InternalColor internalColor_0;

	private DataBarNegativeColorType dataBarNegativeColorType_0;

	private InternalColor internalColor_1;

	private DataBarNegativeColorType dataBarNegativeColorType_1;

	private Workbook workbook_0;

	public Color BorderColor
	{
		get
		{
			return internalColor_0.method_6(workbook_0);
		}
		set
		{
			internalColor_0.SetColor(Aspose.Cells.ColorType.RGB, value.ToArgb());
		}
	}

	public DataBarNegativeColorType BorderColorType
	{
		get
		{
			return dataBarNegativeColorType_0;
		}
		set
		{
			dataBarNegativeColorType_0 = value;
		}
	}

	public Color Color
	{
		get
		{
			return internalColor_1.method_6(workbook_0);
		}
		set
		{
			internalColor_1.SetColor(Aspose.Cells.ColorType.RGB, value.ToArgb());
		}
	}

	public DataBarNegativeColorType ColorType
	{
		get
		{
			return dataBarNegativeColorType_1;
		}
		set
		{
			dataBarNegativeColorType_1 = value;
		}
	}

	internal NegativeBarFormat(DataBar dataBar_0)
	{
		internalColor_1 = new InternalColor(bool_0: false);
		internalColor_0 = new InternalColor(bool_0: false);
		workbook_0 = dataBar_0.workbook_0;
	}

	internal void Copy(NegativeBarFormat negativeBarFormat_0)
	{
		workbook_0 = negativeBarFormat_0.workbook_0;
		internalColor_0 = negativeBarFormat_0.internalColor_0;
		dataBarNegativeColorType_0 = negativeBarFormat_0.dataBarNegativeColorType_0;
		internalColor_1 = negativeBarFormat_0.internalColor_1;
		dataBarNegativeColorType_1 = negativeBarFormat_0.dataBarNegativeColorType_1;
	}

	[SpecialName]
	internal InternalColor method_0()
	{
		return internalColor_0;
	}

	[SpecialName]
	internal void method_1(InternalColor internalColor_2)
	{
		internalColor_0 = internalColor_2;
	}

	[SpecialName]
	internal InternalColor method_2()
	{
		return internalColor_1;
	}

	[SpecialName]
	internal void method_3(InternalColor internalColor_2)
	{
		internalColor_1 = internalColor_2;
	}
}
