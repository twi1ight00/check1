using System.Collections;
using Aspose.Cells;
using Aspose.Cells.Drawing;
using ns29;

namespace ns16;

internal class Class1557
{
	internal Worksheet worksheet_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	internal string string_3;

	internal string string_4;

	internal Class1363 class1363_0 = new Class1363();

	internal ArrayList arrayList_0 = new ArrayList();

	internal ArrayList arrayList_1 = new ArrayList();

	internal ArrayList arrayList_2 = new ArrayList();

	internal ArrayList arrayList_3 = new ArrayList();

	internal ArrayList arrayList_4 = new ArrayList();

	internal ArrayList arrayList_5 = new ArrayList(1);

	internal ArrayList arrayList_6 = new ArrayList();

	internal ArrayList arrayList_7 = new ArrayList();

	internal ArrayList arrayList_8 = new ArrayList();

	internal ArrayList arrayList_9 = new ArrayList();

	internal ArrayList arrayList_10 = new ArrayList();

	internal Hashtable hashtable_0 = new Hashtable();

	internal string string_5;

	internal Hashtable hashtable_1 = new Hashtable();

	internal Class1557(Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
	}

	internal void InsertRows(int int_0, int int_1)
	{
		IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1554 @class = (Class1554)enumerator.Value;
			if (@class != null)
			{
				CellArea cellArea_ = Class1618.smethod_17(@class.string_1);
				bool bool_ = false;
				cellArea_ = Class1678.InsertRows(cellArea_, int_0, int_1, ref bool_);
				@class.string_1 = Class1618.smethod_15(cellArea_);
			}
		}
	}

	internal void InsertColumns(int int_0, int int_1)
	{
		IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1554 @class = (Class1554)enumerator.Value;
			if (@class != null)
			{
				CellArea cellArea_ = Class1618.smethod_17(@class.string_1);
				bool bool_ = false;
				cellArea_ = Class1678.InsertColumns(cellArea_, int_0, int_1, ref bool_);
				@class.string_1 = Class1618.smethod_15(cellArea_);
			}
		}
	}

	internal void method_0()
	{
		IDictionaryEnumerator enumerator = hashtable_0.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Class1554 @class = (Class1554)enumerator.Value;
			if (@class != null)
			{
				CellArea cellArea = Class1618.smethod_17(@class.string_1);
				int num = cellArea.StartRow;
				if (@class.string_2 != null)
				{
					int num2 = Class1618.smethod_87(@class.string_2);
					num -= num2 + 1;
				}
				worksheet_0.Cells.ClearRange(num, cellArea.StartColumn, cellArea.EndRow, cellArea.EndColumn);
			}
		}
		hashtable_0.Clear();
		ArrayList arrayList = new ArrayList();
		int count = arrayList_4.Count;
		for (int i = 0; i < count; i++)
		{
			Class1564 class2 = (Class1564)arrayList_4[i];
			if (class2.string_2 == "http://schemas.openxmlformats.org/officeDocument/2006/relationships/pivotTable")
			{
				arrayList.Add(class2);
			}
		}
		count = arrayList.Count;
		for (int j = 0; j < count; j++)
		{
			object obj = arrayList[j];
			arrayList_4.Remove(obj);
		}
		worksheet_0.Workbook.class1558_0.method_8();
	}

	internal void method_1(Shape shape_0)
	{
		if (shape_0.class1556_0 == null)
		{
			return;
		}
		int num = -1;
		int num2 = -1;
		if (shape_0.class1556_0.string_0 != null)
		{
			num = Class1618.smethod_145(shape_0.class1556_0.string_0);
		}
		if (shape_0.class1556_0.string_1 != null)
		{
			num2 = Class1618.smethod_145(shape_0.class1556_0.string_1);
		}
		if (num == -1 && num2 == -1)
		{
			return;
		}
		Class1550 @class = null;
		foreach (object item in arrayList_2)
		{
			Class1550 class2 = (Class1550)item;
			if (class2.string_0 == Class1618.smethod_80(num) || class2.string_0 == Class1618.smethod_80(num2))
			{
				@class = class2;
			}
		}
		if (@class != null)
		{
			arrayList_2.Remove(@class);
		}
	}
}
