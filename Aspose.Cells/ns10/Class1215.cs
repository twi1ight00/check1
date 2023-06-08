using System;
using System.Collections;
using Aspose.Cells;
using ns16;

namespace ns10;

internal class Class1215
{
	private Class1218 class1218_0;

	private Workbook workbook_0;

	private Class1547 class1547_0;

	private Class1212 class1212_0;

	private int int_0;

	private byte[] byte_0;

	private int int_1;

	private ArrayList arrayList_0;

	private Class1548 class1548_0;

	private Worksheet worksheet_0;

	internal Class1215(Class1218 class1218_1)
	{
		class1218_0 = class1218_1;
		workbook_0 = class1218_1.workbook_0;
		class1547_0 = class1218_1.class1547_0;
		arrayList_0 = new ArrayList();
	}

	internal void Read(Class1548 class1548_1, Class1212 class1212_1)
	{
		class1212_0 = class1212_1;
		class1548_0 = class1548_1;
		worksheet_0 = class1548_1.worksheet_0;
		Comment comment = null;
		while (true)
		{
			int_0 = class1212_0.method_0();
			switch (int_0)
			{
			case 635:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				int num = BitConverter.ToInt32(byte_0, 4);
				CellArea cellArea = Class1217.smethod_1(byte_0, 4);
				int index = worksheet_0.Comments.Add(cellArea.StartRow, cellArea.StartColumn);
				comment = worksheet_0.Comments[index];
				if (num < arrayList_0.Count && num >= 0)
				{
					comment.Author = (string)arrayList_0[num];
				}
				break;
			}
			default:
				int_1 = class1212_0.method_1();
				class1212_0.Seek(int_1);
				break;
			case 637:
				byte_0 = class1218_0.method_0(class1212_0);
				Class1217.smethod_0(workbook_0.Worksheets, class1547_0.method_9(), comment.method_2(), byte_0, 0);
				break;
			case 632:
			{
				byte_0 = class1218_0.method_0(class1212_0);
				string value = Class1217.smethod_8(byte_0, 0);
				arrayList_0.Add(value);
				break;
			}
			case 629:
				class1212_0.Seek(1L);
				return;
			}
		}
	}
}
