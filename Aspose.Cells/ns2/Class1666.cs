using Aspose.Cells;
using ns38;
using ns51;

namespace ns2;

internal class Class1666
{
	private Class1254 class1254_0;

	private Class1275 class1275_0;

	private WorksheetCollection worksheetCollection_0;

	internal Class1666(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
		class1254_0 = new Class1254(worksheetCollection_1);
		class1275_0 = new Class1275(worksheetCollection_1);
	}

	internal string method_0(int int_0, byte[] byte_0, int int_1, int int_2, bool bool_0)
	{
		return method_1(int_0, -1, byte_0, int_1, int_2, bool_0);
	}

	internal string method_1(int int_0, int int_1, byte[] byte_0, int int_2, int int_3, bool bool_0)
	{
		if (worksheetCollection_0.Workbook.method_24())
		{
			return class1275_0.method_1(int_0, int_1, byte_0, int_2, int_3, bool_0);
		}
		return class1254_0.method_1(int_0, int_1, byte_0, int_2, int_3, bool_0);
	}
}
