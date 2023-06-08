using System.Text;
using Aspose.Cells;
using ns38;
using ns51;

namespace ns2;

internal class Class1659
{
	private Class1256 class1256_0;

	private Class1274 class1274_0;

	private Workbook workbook_0;

	internal void method_0()
	{
		if (workbook_0.method_24())
		{
			class1274_0.method_0();
		}
		else
		{
			class1256_0.method_0();
		}
	}

	internal void method_1()
	{
		if (workbook_0.method_24())
		{
			class1274_0.method_1();
		}
		else
		{
			class1256_0.method_1();
		}
	}

	internal Class1659(WorksheetCollection worksheetCollection_0)
	{
		workbook_0 = worksheetCollection_0.Workbook;
		class1256_0 = new Class1256(worksheetCollection_0);
		class1274_0 = new Class1274(worksheetCollection_0);
	}

	internal string method_2(Cell cell_0)
	{
		if (workbook_0.method_24())
		{
			return class1274_0.method_3(cell_0);
		}
		return class1256_0.method_3(cell_0);
	}

	internal string method_3(int int_0, byte[] byte_0, int int_1, int int_2, bool bool_0)
	{
		return method_4(int_0, -1, byte_0, int_1, int_2, bool_0);
	}

	internal string method_4(int int_0, int int_1, byte[] byte_0, int int_2, int int_3, bool bool_0)
	{
		if (workbook_0.method_24())
		{
			return class1274_0.method_5(int_0, int_1, byte_0, int_2, int_3, bool_0);
		}
		return class1256_0.method_5(int_0, int_1, byte_0, int_2, int_3, bool_0);
	}

	internal void method_5(StringBuilder stringBuilder_0, Class1661 class1661_0, int int_0, int int_1, bool bool_0)
	{
		if (workbook_0.method_24())
		{
			class1274_0.method_4(stringBuilder_0, class1661_0, int_0, int_1, bool_0);
		}
		else
		{
			class1256_0.method_6(stringBuilder_0, class1661_0, int_0, int_1, bool_0);
		}
	}

	internal string method_6(Class1653 class1653_0)
	{
		if (workbook_0.method_24())
		{
			Class1265 @class = new Class1265();
			return @class.ToString(class1653_0, bool_0: false);
		}
		Class1265 class2 = new Class1265();
		return class2.ToString(class1653_0, bool_0: true);
	}
}
