using Aspose.Cells;
using ns38;
using ns51;
using ns7;

namespace ns12;

internal class Class1279
{
	internal static bool smethod_0(WorksheetCollection worksheetCollection_0, byte[] byte_0, int int_0)
	{
		if (byte_0 == null)
		{
			return false;
		}
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1270.smethod_0(byte_0, int_0);
		}
		return Class1261.smethod_0(byte_0, int_0);
	}

	internal static int[] GetRange(WorksheetCollection worksheetCollection_0, byte[] byte_0, int int_0, bool bool_0, int int_1, int int_2)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1270.GetRange(worksheetCollection_0, byte_0, int_0, bool_0, int_1, int_2);
		}
		return Class1261.GetRange(worksheetCollection_0, byte_0, int_0, bool_0, int_1, int_2);
	}

	internal static bool smethod_1(WorksheetCollection worksheetCollection_0, Class1309 class1309_0, byte[] byte_0, int int_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1270.smethod_2(worksheetCollection_0, class1309_0, byte_0, int_0);
		}
		return Class1261.smethod_2(worksheetCollection_0, class1309_0, byte_0, int_0);
	}

	internal static CellArea smethod_2(WorksheetCollection sheets, byte[] data, int offset, int row, int column, out bool isArea)
	{
		if (sheets.Workbook.method_24())
		{
			return Class1270.smethod_3(sheets, data, offset, row, column, out isArea);
		}
		return Class1261.smethod_3(sheets, data, offset, row, column, out isArea);
	}

	internal static void smethod_3(Name name, bool isPrintArea, out string first, out string second)
	{
		WorksheetCollection worksheetCollection = name.method_14();
		if (worksheetCollection.Workbook.method_24())
		{
			Class1270.smethod_5(name, isPrintArea, out first, out second);
		}
		else
		{
			Class1261.smethod_5(name, isPrintArea, out first, out second);
		}
	}

	internal static byte[] SetRange(WorksheetCollection worksheetCollection_0, int int_0, CellArea cellArea_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1270.SetRange(worksheetCollection_0, int_0, cellArea_0);
		}
		return Class1261.SetRange(worksheetCollection_0, int_0, cellArea_0);
	}

	internal static byte[] smethod_4(WorksheetCollection worksheetCollection_0, int int_0, string string_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return Class1270.smethod_6(worksheetCollection_0, int_0, string_0);
		}
		return Class1261.smethod_6(worksheetCollection_0, int_0, string_0);
	}
}
