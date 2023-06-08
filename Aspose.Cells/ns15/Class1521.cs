using System.IO;
using System.Xml;
using Aspose.Cells;
using ns16;
using ns25;
using ns26;

namespace ns15;

internal class Class1521
{
	private Workbook workbook_0;

	private Class746 class746_0;

	private Class1489 class1489_0;

	internal Class1521(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		class1489_0 = new Class1489(workbook_1);
		workbook_1.Initialize();
		workbook_1.Worksheets.Clear();
	}

	internal void Read(string string_0)
	{
		FileStream fileStream = null;
		try
		{
			fileStream = File.Open(string_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
			Read(fileStream);
		}
		finally
		{
			fileStream?.Close();
		}
	}

	internal void Read(Stream stream_0)
	{
		Read(Class746.Read(stream_0));
	}

	internal void Read(Class746 class746_1)
	{
		class746_0 = class746_1;
		class1489_0.class746_0 = class746_1;
		try
		{
			Class440 @class = new Class440(class746_1, workbook_0);
			@class.Read();
			method_2();
			method_0(bool_0: false);
			method_1();
			method_0(bool_0: true);
		}
		finally
		{
			class746_0.Close();
		}
	}

	private void method_0(bool bool_0)
	{
		Class1514 @class = new Class1514(workbook_0, class1489_0, bool_0);
		@class.method_1(class746_0);
	}

	private void method_1()
	{
		Class1512 @class = new Class1512(class1489_0);
		@class.Read(class746_0);
	}

	private void method_2()
	{
		Class1513 @class = new Class1513(class1489_0);
		@class.Read(class746_0);
	}

	internal static XmlTextReader smethod_0(Class746 class746_1, string string_0)
	{
		return Class536.smethod_5(class746_1, string_0);
	}
}
