using System;
using Aspose.Cells.Pivot;
using ns27;

namespace ns28;

internal class Class570 : Class538
{
	internal Class570()
	{
		method_2(182);
	}

	internal void method_4(PivotFieldCollection pivotFieldCollection_0)
	{
		method_0((short)(6 * pivotFieldCollection_0.Count));
		byte_0 = new byte[base.Length];
		int num = 0;
		int int_ = pivotFieldCollection_0.int_0;
		foreach (PivotField item in pivotFieldCollection_0.arrayList_0)
		{
			Array.Copy(BitConverter.GetBytes((short)item.BaseIndex), 0, byte_0, num, 2);
			Array.Copy(BitConverter.GetBytes(item.class1170_0.short_0), 0, byte_0, num + 2, 2);
			Array.Copy(BitConverter.GetBytes(int_++), 0, byte_0, num + 4, 2);
			num += 6;
		}
	}
}
