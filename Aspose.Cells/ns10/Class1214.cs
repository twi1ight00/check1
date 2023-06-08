using System.IO;
using Aspose.Cells;
using ns16;
using ns9;

namespace ns10;

internal class Class1214
{
	private Class1540 class1540_0;

	private Workbook workbook_0;

	private MemoryStream memoryStream_0;

	private Class1229 class1229_0;

	private Class1541 class1541_0;

	internal Class1214(Class1229 class1229_1, Class1540 class1540_1)
	{
		class1540_0 = class1540_1;
		class1229_0 = class1229_1;
		workbook_0 = class1540_1.workbook_0;
		memoryStream_0 = new MemoryStream();
	}

	internal void Write(Class1541 class1541_1, string string_0, Stream6 stream6_0)
	{
		class1541_0 = class1541_1;
		Write();
		Class1229.smethod_1(string_0, memoryStream_0, stream6_0);
		memoryStream_0.Close();
		memoryStream_0 = null;
	}

	private void Write()
	{
		Worksheet worksheet_ = class1541_0.worksheet_0;
		Class316 @class = new Class316(129);
		@class.method_0(memoryStream_0);
		Class352 class2 = new Class352();
		class2.method_6(worksheet_);
		class2.method_0(memoryStream_0);
		method_0();
		method_1(worksheet_);
		if (class1541_0.worksheet_0.method_0() != null)
		{
			Class353 class3 = new Class353(worksheet_.Protection);
			class3.method_0(memoryStream_0);
		}
		if (class1541_0.class1358_0.string_0 != null)
		{
			Class356 class4 = new Class356(class1541_0.class1358_0.string_0);
			class4.method_0(memoryStream_0);
		}
		if (class1541_0.class1534_1.string_0 != null)
		{
			Class371 class5 = new Class371(class1541_0.class1534_1.string_0);
			class5.method_0(memoryStream_0);
		}
		if (class1541_0.class1534_0.string_0 != null)
		{
			Class370 class6 = new Class370(class1541_0.class1534_0.string_0);
			class6.method_0(memoryStream_0);
		}
		if (class1541_0.string_3 != null)
		{
			Class321 class7 = new Class321(class1541_0.string_3);
			class7.method_0(memoryStream_0);
		}
		Class316 class8 = new Class316(130);
		class8.method_0(memoryStream_0);
	}

	private void method_0()
	{
		Class316 @class = new Class316(139);
		@class.method_0(memoryStream_0);
		Class327 class2 = new Class327();
		class2.method_6(class1541_0.worksheet_0);
		class2.method_0(memoryStream_0);
		Class316 class3 = new Class316(142);
		class3.method_0(memoryStream_0);
		Class316 class4 = new Class316(140);
		class4.method_0(memoryStream_0);
	}

	private void method_1(Worksheet worksheet_0)
	{
		PageSetup pageSetup = worksheet_0.PageSetup;
		Class372 @class = new Class372(worksheet_0.PageSetup);
		@class.method_0(memoryStream_0);
		Class351 class2 = new Class351(worksheet_0.PageSetup);
		class2.method_0(memoryStream_0);
		method_2(pageSetup);
	}

	private void method_2(PageSetup pageSetup_0)
	{
		Class405 @class = new Class405();
		@class.method_6(pageSetup_0);
		@class.method_0(memoryStream_0);
		Class316 class2 = new Class316(480);
		class2.method_0(memoryStream_0);
	}
}
