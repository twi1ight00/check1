using Aspose.Cells;
using ns38;
using ns51;

namespace ns2;

internal class Class1667
{
	private WorksheetCollection worksheetCollection_0;

	private Class1255 class1255_0;

	private Class1276 class1276_0;

	internal Class1667(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		class1255_0 = new Class1255(worksheetCollection_1);
		class1276_0 = new Class1276(worksheetCollection_1);
	}

	internal string method_0(Cell cell_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return class1276_0.method_1(cell_0);
		}
		return class1255_0.method_1(cell_0);
	}

	internal string method_1(int int_0, byte[] byte_0, int int_1, int int_2, bool bool_0)
	{
		return method_2(int_0, -1, byte_0, int_1, int_2, bool_0);
	}

	internal string method_2(int int_0, int int_1, byte[] byte_0, int int_2, int int_3, bool bool_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return class1276_0.method_3(int_0, int_1, byte_0, int_2, int_3, bool_0);
		}
		return class1255_0.method_3(int_0, int_1, byte_0, int_2, int_3, bool_0);
	}
}
