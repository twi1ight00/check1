using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells;

namespace ns2;

internal class Class1661
{
	private static string string_0 = "Invalid formula:";

	private WorksheetCollection worksheetCollection_0;

	private string string_1;

	internal string string_2;

	private Class1661 class1661_0;

	private ArrayList arrayList_0;

	private byte[] byte_0;

	private Enum180 enum180_0 = Enum180.const_1;

	internal int int_0;

	internal Enum180 Type
	{
		get
		{
			return enum180_0;
		}
		set
		{
			enum180_0 = value;
		}
	}

	internal Class1661()
	{
	}

	internal Class1661(WorksheetCollection worksheetCollection_1)
	{
		worksheetCollection_0 = worksheetCollection_1;
	}

	[SpecialName]
	internal bool method_0()
	{
		if (byte_0 != null)
		{
			return byte_0[0] == 22;
		}
		return false;
	}

	internal void method_1(Class1661 class1661_1)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		arrayList_0.Add(class1661_1);
		class1661_1.class1661_0 = this;
	}

	internal void method_2(Class1661[][] class1661_1)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		arrayList_0.Add(class1661_1);
	}

	[SpecialName]
	internal string method_3()
	{
		return string_1;
	}

	[SpecialName]
	internal void method_4(string string_3)
	{
		string_1 = string_3;
	}

	[SpecialName]
	internal Class1661 method_5()
	{
		return class1661_0;
	}

	[SpecialName]
	internal void method_6(Class1661 class1661_1)
	{
		class1661_0 = class1661_1;
	}

	[SpecialName]
	internal ArrayList method_7()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal void method_8(ArrayList arrayList_1)
	{
		arrayList_0 = arrayList_1;
	}

	[SpecialName]
	internal byte[] method_9()
	{
		return byte_0;
	}

	[SpecialName]
	internal void method_10(byte[] byte_1)
	{
		byte_0 = byte_1;
	}
}
