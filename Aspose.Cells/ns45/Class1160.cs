using System;
using System.Collections;
using Aspose.Cells.Pivot;

namespace ns45;

internal class Class1160
{
	internal short short_0;

	internal string string_0;

	internal string string_1;

	internal string string_2;

	internal short short_1;

	internal ushort ushort_0;

	internal ushort ushort_1;

	internal string string_3;

	internal string string_4;

	internal string string_5;

	internal PivotTable pivotTable_0;

	internal ArrayList arrayList_0;

	internal Class1160(PivotTable pivotTable_1)
	{
		pivotTable_0 = pivotTable_1;
		ushort_0 = 512;
		ushort_1 = 79;
		short_0 = 0;
		short_1 = 0;
	}

	internal void Copy(Class1160 class1160_0)
	{
		short_0 = class1160_0.short_0;
		string_0 = class1160_0.string_0;
		string_1 = class1160_0.string_1;
		string_2 = class1160_0.string_2;
		short_1 = class1160_0.short_1;
		ushort_0 = class1160_0.ushort_0;
		ushort_1 = class1160_0.ushort_1;
		string_3 = class1160_0.string_3;
		string_4 = class1160_0.string_4;
		string_5 = class1160_0.string_5;
		if (class1160_0.arrayList_0 == null || class1160_0.arrayList_0.Count <= 0)
		{
			return;
		}
		arrayList_0 = new ArrayList();
		foreach (byte[] item in class1160_0.arrayList_0)
		{
			byte[] array2 = new byte[item.Length];
			Array.Copy(item, array2, array2.Length);
			arrayList_0.Add(array2);
		}
	}

	internal void method_0(bool bool_0, int int_0)
	{
		ushort_1 &= (ushort)(~int_0);
		ushort_1 |= (ushort)(bool_0 ? int_0 : 0);
	}

	internal bool method_1(int int_0)
	{
		return (ushort_1 & (ushort)int_0) != 0;
	}

	internal void method_2(bool bool_0, int int_0)
	{
		ushort_0 &= (ushort)(~int_0);
		ushort_0 |= (ushort)(bool_0 ? int_0 : 0);
	}

	internal bool method_3(int int_0)
	{
		return (ushort_0 | int_0) != 0;
	}
}
