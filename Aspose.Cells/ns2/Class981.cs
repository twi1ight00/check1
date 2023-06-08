using Aspose.Cells;

namespace ns2;

internal class Class981 : Row
{
	private Class978 class978_0;

	internal Class981(Cells cells_0, Class978 class978_1)
		: base(cells_0.Rows)
	{
		class978_0 = class978_1;
	}

	public override void ApplyStyle(Style style, StyleFlag flag)
	{
		if (!flag.All)
		{
			throw new CellsException(ExceptionType.Limitation, "You cannot apply only part of style to a row in light mode. StyleFlag.All should be true");
		}
		method_21(bool_1: true);
		method_11(class978_0.method_2(style));
	}
}
