using System.Collections;
using Aspose.Cells;

namespace ns8;

internal class Class1475
{
	internal int int_0 = -1;

	internal bool bool_0;

	internal bool bool_1;

	internal int int_1 = 1;

	internal int int_2 = 1;

	internal Hyperlink hyperlink_0;

	internal Cell cell_0;

	internal int int_3 = -1;

	internal Style style_0;

	internal bool bool_2;

	internal ArrayList arrayList_0;

	internal string string_0;

	internal Class1475(Cell cell_1)
	{
		if (cell_1 != null)
		{
			cell_0 = cell_1;
			int_0 = cell_1.Column;
			int_3 = cell_1.method_35();
			style_0 = cell_1.method_28();
		}
	}

	internal Class1475(int int_4)
	{
		int_0 = int_4;
	}
}
