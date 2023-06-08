using Aspose.Cells;
using ns38;
using ns51;

namespace ns2;

internal class Class1675
{
	internal static bool smethod_0(WorksheetCollection worksheetCollection_0, byte[] byte_0, int int_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1267.smethod_0(byte_0, int_0);
		}
		return Class1259.smethod_0(byte_0, int_0);
	}

	internal static byte[] smethod_1(WorksheetCollection sheets, int sheetIndex, string refString, bool externRef, bool validName, bool convertName, out bool isValid)
	{
		if (sheets.Workbook.method_24())
		{
			return Class1267.smethod_3(sheets, sheetIndex, refString, externRef, validName, convertName, out isValid);
		}
		return Class1259.smethod_3(sheets, sheetIndex, refString, externRef, validName, convertName, out isValid);
	}
}
