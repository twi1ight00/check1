using System.Collections;
using Aspose.Cells;
using ns16;

namespace ns26;

internal class Class1489
{
	internal double double_0;

	internal Workbook workbook_0;

	internal Hashtable hashtable_0;

	internal Hashtable hashtable_1;

	internal Hashtable hashtable_2;

	internal Hashtable hashtable_3;

	internal Hashtable hashtable_4;

	internal Hashtable hashtable_5;

	internal Hashtable hashtable_6;

	internal Hashtable hashtable_7;

	internal Class746 class746_0;

	internal Hashtable hashtable_8;

	internal Hashtable hashtable_9;

	internal ArrayList arrayList_0;

	internal Class1350 class1350_0;

	internal string string_0 = "Default";

	internal Hashtable hashtable_10;

	internal string method_0(string string_1)
	{
		return ((Class524)hashtable_2[string_1])?.method_0(hashtable_2);
	}

	internal void method_1(string string_1, string string_2, ArrayList arrayList_1)
	{
		hashtable_2.Add(string_1, new Class524(string_2, arrayList_1));
	}

	internal Class1489(Workbook workbook_1)
	{
		workbook_0 = workbook_1;
		double_0 = workbook_0.Worksheets.method_75();
		hashtable_0 = new Hashtable();
		hashtable_1 = new Hashtable();
		hashtable_3 = new Hashtable();
		hashtable_2 = new Hashtable();
		hashtable_5 = new Hashtable();
		hashtable_6 = new Hashtable();
		hashtable_7 = new Hashtable();
		hashtable_8 = new Hashtable();
		hashtable_4 = new Hashtable();
		hashtable_9 = new Hashtable();
		arrayList_0 = new ArrayList();
		class1350_0 = new Class1350();
		hashtable_10 = new Hashtable();
	}
}
