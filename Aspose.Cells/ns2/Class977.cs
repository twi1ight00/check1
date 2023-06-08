using Aspose.Cells;

namespace ns2;

internal class Class977 : Cell
{
	private Class978 class978_0;

	internal Row row_0;

	internal bool bool_0;

	internal int int_2;

	internal Class977(Cells cells_1, Class978 class978_1)
		: base(cells_1)
	{
		class978_0 = class978_1;
	}

	internal override void vmethod_0(int int_3)
	{
		base.vmethod_0(int_3);
	}

	public override void SetStyle(Style style)
	{
		if (style == null)
		{
			int_1 = -1;
		}
		else
		{
			int_1 = class978_0.method_2(style);
		}
	}

	public override Style GetStyle()
	{
		Style style = new Style(class978_0.worksheetCollection_0);
		int num = int_1;
		if (num < 0)
		{
			num = ((!row_0.method_20() || int_2 <= 15) ? class978_0.class521_0.method_1(base.Column) : int_2);
		}
		style.Copy(class978_0.method_1(num));
		return style;
	}

	public override void PutValue(string stringValue)
	{
		object_0 = stringValue;
	}

	public override void SetStyle(Style style, bool explicitFlag)
	{
		throw new CellsException(ExceptionType.Limitation, "Only complete Style can be set for light mode");
	}

	public override void SetStyle(Style style, StyleFlag flag)
	{
		throw new CellsException(ExceptionType.Limitation, "Only complete Style can be set for light mode");
	}
}
