using Aspose.Cells;

namespace ns45;

internal class Class1163
{
	private Class1164 class1164_0;

	internal byte byte_0;

	internal int int_0;

	internal Class1171 class1171_0;

	internal Class1163(Class1164 class1164_1)
	{
		byte_0 = 1;
		int_0 = -1;
		class1171_0 = new Class1171();
		class1164_0 = class1164_1;
	}

	internal void method_0(Style style_0)
	{
		int_0 = class1164_0.pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Add(style_0);
	}

	internal Style method_1()
	{
		if (int_0 != -1 && int_0 < class1164_0.pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56().Count)
		{
			return class1164_0.pivotTable_0.pivotTableCollection_0.worksheet_0.method_2().method_56()[int_0];
		}
		return null;
	}
}
