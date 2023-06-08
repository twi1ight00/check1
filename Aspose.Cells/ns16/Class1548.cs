using System.Collections;
using Aspose.Cells;

namespace ns16;

internal class Class1548
{
	internal int int_0;

	internal string string_0;

	internal string string_1;

	internal Worksheet worksheet_0;

	internal Hashtable hashtable_0;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal string string_6;

	internal ArrayList arrayList_0 = new ArrayList();

	internal Hashtable hashtable_1;

	internal ArrayList arrayList_1 = new ArrayList();

	internal Class1547 class1547_0;

	internal Class1548(Class1547 class1547_1, Worksheet worksheet_1)
	{
		class1547_0 = class1547_1;
		worksheet_0 = worksheet_1;
	}

	private string method_0(string string_7)
	{
		string text = Class1608.smethod_3(hashtable_0, string_7);
		if (text != null && !(text == ""))
		{
			if (text[0] == '/')
			{
				return text;
			}
			return "xl/" + text.Substring(3);
		}
		return null;
	}

	internal string method_1()
	{
		return method_0("http://schemas.openxmlformats.org/officeDocument/2006/relationships/comments");
	}

	internal void method_2(ArrayList arrayList_2)
	{
		Class1608.smethod_8(hashtable_0, arrayList_0, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/printerSettings");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/slicer");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.microsoft.com/office/2007/relationships/slicer");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/ctrlProp");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/control");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/image");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/queryTable");
	}

	internal string method_3(string string_7)
	{
		if (string_7 != null && hashtable_0 != null && hashtable_0.ContainsKey(string_7))
		{
			Class1564 @class = (Class1564)hashtable_0[string_7];
			return @class.string_3;
		}
		return null;
	}

	internal Class1564 method_4(string string_7)
	{
		if (string_7 != null && hashtable_0.ContainsKey(string_7))
		{
			return (Class1564)hashtable_0[string_7];
		}
		return null;
	}
}
