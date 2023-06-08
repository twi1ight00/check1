using System.Collections;
using System.Drawing;
using System.IO;
using Aspose.Cells;
using Aspose.Cells.Tables;
using ns16;
using ns2;
using ns27;
using ns9;

namespace ns10;

internal class Class1221
{
	private Class1540 class1540_0;

	private Workbook workbook_0;

	private MemoryStream memoryStream_0;

	private Class1229 class1229_0;

	internal Class1221(Class1229 class1229_1, Class1540 class1540_1)
	{
		class1540_0 = class1540_1;
		class1229_0 = class1229_1;
		workbook_0 = class1540_1.workbook_0;
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
		Class316 @class = new Class316(278);
		@class.method_0(memoryStream_0);
		method_3();
		method_4();
		method_5(class1540_0.class1539_0);
		method_6(class1540_0.class1539_0);
		method_7(class1540_0.class1539_0);
		method_8(class1540_0.class1539_0);
		method_9(class1540_0.class1539_0);
		method_10();
		method_1();
		method_0();
		Class316 class2 = new Class316(279);
		class2.method_0(memoryStream_0);
	}

	private void method_0()
	{
		Class316 @class = new Class316(473);
		@class.method_0(memoryStream_0);
		Class316 class2 = new Class316(565);
		class2.method_0(memoryStream_0);
		for (int i = 0; i < 64; i++)
		{
			Color color = workbook_0.Worksheets.method_24().method_7(i);
			Class320 class3 = new Class320(color.A, color.R, color.G, color.B);
			class3.method_0(memoryStream_0);
		}
		Class316 class4 = new Class316(566);
		class4.method_0(memoryStream_0);
		Class316 class5 = new Class316(474);
		class5.method_0(memoryStream_0);
	}

	private void method_1()
	{
		TableStyleCollection tableStyleCollection = workbook_0.Worksheets.method_91();
		if (tableStyleCollection != null)
		{
			int count = tableStyleCollection.Count;
			Class339 @class = new Class339(tableStyleCollection);
			@class.method_0(memoryStream_0);
			for (int i = 0; i < count; i++)
			{
				TableStyle tableStyle_ = tableStyleCollection[i];
				method_2(tableStyle_);
			}
			Class316 class2 = new Class316(509);
			class2.method_0(memoryStream_0);
		}
	}

	private void method_2(TableStyle tableStyle_0)
	{
		Class338 @class = new Class338(tableStyle_0);
		@class.method_0(memoryStream_0);
		int count = tableStyle_0.TableStyleElements.Count;
		for (int i = 0; i < count; i++)
		{
			TableStyleElement tableStyleElement_ = tableStyle_0.TableStyleElements[i];
			Class389 class2 = new Class389(tableStyleElement_);
			class2.method_0(memoryStream_0);
		}
		Class316 class3 = new Class316(511);
		class3.method_0(memoryStream_0);
	}

	private void method_3()
	{
		ArrayList arrayList = workbook_0.Worksheets.method_55();
		if (arrayList.Count != 0)
		{
			Class316 @class = new Class316(615, arrayList.Count);
			@class.method_0(memoryStream_0);
			for (int i = 0; i < arrayList.Count; i++)
			{
				Class639 class2 = (Class639)arrayList[i];
				Class367 class3 = new Class367();
				class3.method_6(class2.Index, class2.Custom);
				class3.method_0(memoryStream_0);
			}
			Class316 class4 = new Class316(616);
			class4.method_0(memoryStream_0);
		}
	}

	private void method_4()
	{
		ArrayList arrayList = workbook_0.Worksheets.method_52();
		if (arrayList.Count == 0)
		{
			return;
		}
		Class316 @class = new Class316(611, arrayList.Count);
		@class.method_0(memoryStream_0);
		foreach (Aspose.Cells.Font item in arrayList)
		{
			Class368 class2 = new Class368();
			class2.method_6(item, workbook_0);
			class2.method_0(memoryStream_0);
		}
		Class316 class3 = new Class316(612);
		class3.method_0(memoryStream_0);
	}

	private void method_5(Class1539 class1539_0)
	{
		ArrayList arrayList_ = class1539_0.arrayList_0;
		if (arrayList_.Count == 0)
		{
			return;
		}
		Class316 @class = new Class316(603, arrayList_.Count);
		@class.method_0(memoryStream_0);
		foreach (Class1535 item in arrayList_)
		{
			Class365 class2 = new Class365(workbook_0);
			class2.method_6(item);
			class2.method_0(memoryStream_0);
		}
		Class316 class3 = new Class316(604);
		class3.method_0(memoryStream_0);
	}

	private void method_6(Class1539 class1539_0)
	{
		ArrayList arrayList_ = class1539_0.arrayList_1;
		if (arrayList_.Count == 0)
		{
			return;
		}
		Class316 @class = new Class316(613, arrayList_.Count);
		@class.method_0(memoryStream_0);
		foreach (Class1526 item in arrayList_)
		{
			Class342 class2 = new Class342();
			class2.SetBorder(item);
			class2.method_0(memoryStream_0);
		}
		Class316 class3 = new Class316(614);
		class3.method_0(memoryStream_0);
	}

	private void method_7(Class1539 class1539_0)
	{
		ArrayList arrayList_ = class1539_0.arrayList_2;
		if (arrayList_.Count != 0)
		{
			Class316 @class = new Class316(626, arrayList_.Count);
			@class.method_0(memoryStream_0);
			for (int i = 0; i < arrayList_.Count; i++)
			{
				Class1571 class1571_ = (Class1571)arrayList_[i];
				Class410 class2 = new Class410();
				class2.method_6(class1571_);
				class2.method_0(memoryStream_0);
			}
			Class316 class3 = new Class316(627);
			class3.method_0(memoryStream_0);
		}
	}

	private void method_8(Class1539 class1539_0)
	{
		ArrayList arrayList_ = class1539_0.arrayList_3;
		if (arrayList_.Count != 0)
		{
			Class316 @class = new Class316(617, arrayList_.Count);
			@class.method_0(memoryStream_0);
			for (int i = 0; i < arrayList_.Count; i++)
			{
				Class1571 class1571_ = (Class1571)arrayList_[i];
				Class410 class2 = new Class410();
				class2.method_6(class1571_);
				class2.method_0(memoryStream_0);
			}
			Class316 class3 = new Class316(618);
			class3.method_0(memoryStream_0);
		}
	}

	private void method_9(Class1539 class1539_0)
	{
		ArrayList arrayList_ = class1539_0.arrayList_4;
		if (arrayList_.Count != 0)
		{
			Class316 @class = new Class316(619, arrayList_.Count);
			@class.method_0(memoryStream_0);
			for (int i = 0; i < arrayList_.Count; i++)
			{
				Class1529 style = (Class1529)arrayList_[i];
				Class409 class2 = new Class409();
				class2.SetStyle(style);
				class2.method_0(memoryStream_0);
			}
			Class316 class3 = new Class316(620);
			class3.method_0(memoryStream_0);
		}
	}

	private void method_10()
	{
		Class1337 @class = workbook_0.Worksheets.method_56();
		int count = @class.Count;
		if (count != 0)
		{
			Class316 class2 = new Class316(505, count);
			class2.method_0(memoryStream_0);
			for (int i = 0; i < @class.Count; i++)
			{
				Style style_ = @class[i];
				Class357 class3 = new Class357();
				class3.SetStyle(style_, bool_0: false, workbook_0);
				class3.method_0(memoryStream_0);
			}
			Class316 class4 = new Class316(506);
			class4.method_0(memoryStream_0);
		}
	}
}
