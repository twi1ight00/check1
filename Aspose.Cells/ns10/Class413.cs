using System;
using Aspose.Cells;
using ns16;

namespace ns10;

internal class Class413
{
	private Workbook workbook_0;

	private Class1218 class1218_0;

	private Class1212 class1212_0;

	private Worksheet worksheet_0;

	private Class1548 class1548_0;

	private Class1547 class1547_0;

	private int int_0;

	private byte[] byte_0;

	private int int_1;

	internal Class413(Class1218 class1218_1)
	{
		class1218_0 = class1218_1;
		workbook_0 = class1218_1.workbook_0;
		class1547_0 = class1218_1.class1547_0;
	}

	internal void Read(Class1548 class1548_1, Class1212 class1212_1)
	{
		class1212_0 = class1212_1;
		class1548_0 = class1548_1;
		worksheet_0 = class1548_1.worksheet_0;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 447:
				method_0();
				break;
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 448:
				class1212_0.Seek(1L);
				return;
			}
		}
	}

	private void method_0()
	{
		byte_0 = class1218_0.method_0(class1212_0);
		QueryTable queryTable = new QueryTable();
		worksheet_0.QueryTables.Add(queryTable);
		int num = BitConverter.ToInt32(byte_0, 0);
		queryTable.bool_0 = ((((uint)num & 0x20u) != 0) ? true : false);
		queryTable.bool_1 = ((((uint)num & 0x800u) != 0) ? true : false);
	}
}
