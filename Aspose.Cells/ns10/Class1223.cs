using System.IO;
using Aspose.Cells.Tables;
using ns16;
using ns9;

namespace ns10;

internal class Class1223
{
	private ListObject listObject_0;

	private MemoryStream memoryStream_0;

	private Class1229 class1229_0;

	internal Class1223(Class1229 class1229_1, ListObject listObject_1)
	{
		class1229_0 = class1229_1;
		listObject_0 = listObject_1;
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
		Class337 @class = new Class337(listObject_0);
		@class.method_0(memoryStream_0);
		if (listObject_0.method_37() != null && listObject_0.method_37().Count > 0)
		{
			Class1228.smethod_0(listObject_0.method_37(), memoryStream_0);
		}
		method_0();
		method_2();
		Class316 class2 = new Class316(344);
		class2.method_0(memoryStream_0);
	}

	private void method_0()
	{
		int count = listObject_0.ListColumns.Count;
		Class316 @class = new Class316(345, count);
		@class.method_0(memoryStream_0);
		for (int i = 0; i < count; i++)
		{
			ListColumn listColumn_ = listObject_0.ListColumns[i];
			method_1(listColumn_);
		}
		Class316 class2 = new Class316(346);
		class2.method_0(memoryStream_0);
	}

	private void method_1(ListColumn listColumn_0)
	{
		Class336 @class = new Class336(listColumn_0);
		@class.method_0(memoryStream_0);
		if (listColumn_0.byte_0 != null)
		{
			Class386 class2 = new Class386(listColumn_0);
			class2.method_0(memoryStream_0);
		}
		if (listColumn_0.byte_1 != null)
		{
			Class390 class3 = new Class390(listColumn_0);
			class3.method_0(memoryStream_0);
		}
		Class316 class4 = new Class316(348);
		class4.method_0(memoryStream_0);
	}

	private void method_2()
	{
		Class388 @class = new Class388(listObject_0);
		@class.method_0(memoryStream_0);
	}
}
