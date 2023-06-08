using Aspose.Cells;
using ns53;
using ns54;

namespace ns7;

internal class Class1195
{
	internal static Interface45 smethod_0(WorksheetCollection worksheetCollection_0, Worksheet worksheet_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return new Class1198(worksheetCollection_0, worksheet_0);
		}
		return new Class1197(worksheetCollection_0, worksheet_0);
	}

	internal static Interface45 smethod_1(WorksheetCollection worksheetCollection_0, Worksheet worksheet_0, string string_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return new Class1198(worksheetCollection_0, worksheet_0, string_0);
		}
		return new Class1197(worksheetCollection_0, worksheet_0, string_0);
	}
}
