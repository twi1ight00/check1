using Aspose.Cells;

namespace ns55;

internal class Class1205
{
	internal bool bool_0;

	internal Style style_0;

	internal Font Font => style_0.Font;

	internal Class1205(WorksheetCollection worksheetCollection_0)
	{
		style_0 = new Style(worksheetCollection_0);
	}
}
