using System.Runtime.CompilerServices;
using Aspose.Cells.Pivot;

namespace ns45;

internal class Class1174
{
	internal ushort ushort_0;

	internal byte byte_0;

	internal byte byte_1;

	internal short short_0;

	internal string string_0;

	internal PivotField pivotField_0;

	internal string string_1;

	internal short short_1;

	internal short short_2;

	internal string NumberFormat
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	internal Class1174(PivotField pivotField_1)
	{
		pivotField_0 = pivotField_1;
		ushort_0 = 5150;
		byte_1 = 10;
		short_1 = -1;
		short_2 = -1;
	}

	internal void Copy(Class1174 class1174_0)
	{
		ushort_0 = class1174_0.ushort_0;
		byte_0 = class1174_0.byte_0;
		string_1 = class1174_0.string_1;
		short_0 = class1174_0.short_0;
		string_0 = class1174_0.string_0;
		byte_1 = class1174_0.byte_1;
		_ = pivotField_0.pivotFieldCollection_0.pivotTable_0.DataFields;
		short_1 = class1174_0.short_1;
		short_2 = class1174_0.short_2;
	}

	internal bool method_0(int int_0)
	{
		return (ushort_0 & int_0) != 0;
	}

	internal void method_1(bool bool_0, int int_0)
	{
		ushort_0 &= (ushort)(~int_0);
		ushort_0 |= (ushort)(bool_0 ? int_0 : 0);
	}

	[SpecialName]
	internal short method_2()
	{
		return short_2;
	}

	[SpecialName]
	internal short method_3()
	{
		return short_1;
	}
}
