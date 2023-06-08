using System.Collections;
using System.IO;
using Aspose.Cells;
using ns16;
using ns2;
using ns9;

namespace ns10;

internal class Class1226
{
	private Class1540 class1540_0;

	private Workbook workbook_0;

	private WorksheetCollection worksheetCollection_0;

	private MemoryStream memoryStream_0;

	private Class1229 class1229_0;

	internal Class1226(Class1229 class1229_1, Class1540 class1540_1)
	{
		class1229_0 = class1229_1;
		class1540_0 = class1540_1;
		workbook_0 = class1540_1.workbook_0;
		worksheetCollection_0 = workbook_0.Worksheets;
		memoryStream_0 = new MemoryStream();
	}

	internal void Write(string string_0, Stream6 stream6_0)
	{
		Write();
		Class1229.smethod_1(string_0, memoryStream_0, stream6_0);
		memoryStream_0.Close();
		memoryStream_0 = null;
	}

	private void Write()
	{
		Class316 @class = new Class316(131);
		@class.method_0(memoryStream_0);
		Class364 class2 = new Class364();
		class2.method_0(memoryStream_0);
		Class392 class3 = new Class392();
		class3.method_6(workbook_0);
		class3.method_0(memoryStream_0);
		method_2();
		method_0();
		method_1();
		method_3();
		method_6();
		Class316 class4 = new Class316(132);
		class4.method_0(memoryStream_0);
	}

	private void method_0()
	{
		Class316 @class = new Class316(135);
		@class.method_0(memoryStream_0);
		Class341 class2 = new Class341();
		class2.method_6(workbook_0);
		class2.method_0(memoryStream_0);
		Class316 class3 = new Class316(136);
		class3.method_0(memoryStream_0);
	}

	private void method_1()
	{
		Class316 @class = new Class316(143);
		@class.method_0(memoryStream_0);
		for (int i = 0; i < class1540_0.arrayList_0.Count; i++)
		{
			Class1541 class1541_ = (Class1541)class1540_0.arrayList_0[i];
			Class345 class2 = new Class345();
			class2.method_6(class1541_);
			class2.method_0(memoryStream_0);
		}
		Class316 class3 = new Class316(144);
		class3.method_0(memoryStream_0);
	}

	private void method_2()
	{
		if (workbook_0.Worksheets.method_79() || workbook_0.Worksheets.method_77())
		{
			Class393 @class = new Class393(workbook_0.Worksheets);
			@class.method_0(memoryStream_0);
		}
	}

	private void method_3()
	{
		Class316 @class = new Class316(353);
		@class.method_0(memoryStream_0);
		Class1303 class2 = worksheetCollection_0.method_39();
		for (int i = 0; i < class2.Count; i++)
		{
			Class1718 class3 = class2[i];
			switch (class3.Type)
			{
			case Enum194.const_0:
				method_5(class3);
				break;
			case Enum194.const_1:
			{
				Class316 class5 = new Class316(357);
				class5.method_0(memoryStream_0);
				break;
			}
			case Enum194.const_2:
			{
				Class316 class6 = new Class316(667);
				class6.method_0(memoryStream_0);
				ArrayList arrayList2 = class3.method_0();
				if (arrayList2.Count != 0)
				{
					method_4(arrayList2);
				}
				break;
			}
			case Enum194.const_4:
				method_5(class3);
				break;
			case Enum194.const_5:
			{
				Class316 class4 = new Class316(358);
				class4.method_0(memoryStream_0);
				ArrayList arrayList = class3.method_0();
				if (arrayList.Count != 0)
				{
					method_4(arrayList);
				}
				break;
			}
			}
		}
		Class344 class7 = new Class344(worksheetCollection_0);
		class7.method_0(memoryStream_0);
		Class316 class8 = new Class316(354);
		class8.method_0(memoryStream_0);
	}

	private void method_4(ArrayList arrayList_0)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1653 class1653_ = (Class1653)arrayList_0[i];
			Class318 @class = new Class318(class1653_);
			@class.method_0(memoryStream_0);
		}
	}

	private void method_5(Class1718 class1718_0)
	{
		workbook_0.Worksheets.method_39();
		string text = class1718_0.method_25();
		if (text != null && text.Trim().Length != 0 && (class1718_0.Type == Enum194.const_3 || class1718_0.Type == Enum194.const_0 || class1718_0.Type == Enum194.const_4))
		{
			string string_ = (string)class1540_0.hashtable_4[class1718_0];
			Class381 @class = new Class381(string_);
			@class.method_0(memoryStream_0);
		}
	}

	private void method_6()
	{
		NameCollection names = workbook_0.Worksheets.Names;
		foreach (Name item in names)
		{
			Class374 @class = new Class374();
			@class.method_6(item);
			@class.method_0(memoryStream_0);
		}
	}
}
