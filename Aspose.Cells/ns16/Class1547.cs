using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns16;

internal class Class1547
{
	internal Workbook workbook_0;

	private Hashtable hashtable_0;

	private Hashtable hashtable_1;

	private Hashtable hashtable_2;

	internal Hashtable hashtable_3;

	internal Hashtable hashtable_4;

	internal Hashtable hashtable_5;

	internal string string_0;

	internal ArrayList arrayList_0 = new ArrayList();

	private Hashtable hashtable_6 = new Hashtable();

	internal ArrayList arrayList_1 = new ArrayList();

	internal Class1547(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		hashtable_1 = new Hashtable();
		hashtable_5 = new Hashtable();
	}

	internal void method_0(Worksheet worksheet_0, int int_0, string string_1, string string_2)
	{
		int num = Class1618.smethod_87(string_1);
		if (num < 1)
		{
			throw new ApplicationException("Invalid SheetId " + string_1);
		}
		Class1548 @class = new Class1548(this, worksheet_0);
		@class.int_0 = int_0;
		@class.string_0 = string_1;
		@class.string_1 = string_2;
		hashtable_1.Add(int_0, @class);
	}

	internal Worksheet method_1(int int_0)
	{
		if (!hashtable_1.ContainsKey(int_0))
		{
			throw new ApplicationException("Invalid localSheetId");
		}
		return ((Class1548)hashtable_1[int_0]).worksheet_0;
	}

	internal void method_2(Hashtable hashtable_7)
	{
		hashtable_0 = hashtable_7;
	}

	internal Hashtable method_3()
	{
		return hashtable_0;
	}

	[SpecialName]
	internal Hashtable method_4()
	{
		return hashtable_0;
	}

	[SpecialName]
	internal void method_5(Hashtable hashtable_7)
	{
		hashtable_0 = hashtable_7;
	}

	[SpecialName]
	internal Hashtable method_6()
	{
		return hashtable_2;
	}

	[SpecialName]
	internal void method_7(Hashtable hashtable_7)
	{
		hashtable_2 = hashtable_7;
	}

	[SpecialName]
	internal Hashtable method_8()
	{
		return hashtable_1;
	}

	[SpecialName]
	internal Hashtable method_9()
	{
		return hashtable_6;
	}

	[SpecialName]
	internal void method_10(Hashtable hashtable_7)
	{
		hashtable_6 = hashtable_7;
	}

	internal Hashtable method_11()
	{
		return hashtable_1;
	}

	internal void method_12(ArrayList arrayList_2)
	{
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/connections");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/customXml");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.microsoft.com/office/2007/relationships/customDataProps");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/usernames");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/revisionHeaders");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/slicerCache");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.microsoft.com/office/2007/relationships/slicerCache");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.microsoft.com/office/2006/relationships/attachedToolbars");
	}

	internal void method_13(ArrayList arrayList_2)
	{
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.microsoft.com/office/2007/relationships/customDataProps");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/usernames");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/revisionHeaders");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.openxmlformats.org/officeDocument/2006/relationships/slicerCache");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.microsoft.com/office/2007/relationships/slicerCache");
		Class1608.smethod_8(hashtable_0, arrayList_2, "http://schemas.microsoft.com/office/2006/relationships/attachedToolbars");
	}
}
