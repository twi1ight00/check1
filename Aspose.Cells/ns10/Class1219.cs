using System.IO;
using Aspose.Cells;
using ns16;
using ns2;
using ns9;

namespace ns10;

internal class Class1219
{
	private Workbook workbook_0;

	private MemoryStream memoryStream_0;

	private Class1229 class1229_0;

	internal Class1219(Class1229 class1229_1, Workbook workbook_1)
	{
		class1229_0 = class1229_1;
		workbook_0 = workbook_1;
		memoryStream_0 = new MemoryStream();
	}

	internal void Write(string string_0, Stream6 stream6_0)
	{
		Write();
		Class1229.smethod_1(string_0, memoryStream_0, stream6_0);
		memoryStream_0.Close();
		memoryStream_0 = null;
	}

	internal void Write()
	{
		Class1301 class1301_ = workbook_0.Worksheets.class1301_0;
		Class334 @class = new Class334();
		@class.method_6(class1301_.method_2(), 0);
		@class.method_0(memoryStream_0);
		Class380 class2 = new Class380();
		int num = class1301_.method_3();
		for (int i = 0; i < num; i++)
		{
			Class1719 class3 = class1301_.class1719_0[i];
			if (class3.method_1())
			{
				class2.method_7((Class1720)class3, workbook_0);
			}
			else
			{
				class2.method_6(class3.string_0);
			}
			class2.method_0(memoryStream_0);
		}
		Class316 class4 = new Class316(160);
		class4.method_0(memoryStream_0);
	}
}
