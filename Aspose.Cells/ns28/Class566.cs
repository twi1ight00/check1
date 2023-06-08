using System;
using Aspose.Cells.Pivot;
using ns27;

namespace ns28;

internal class Class566 : Class538
{
	internal Class566()
	{
		method_2(180);
	}

	internal void method_4(PivotFieldCollection pivotFieldCollection_0)
	{
		method_0((short)(pivotFieldCollection_0.Count * 2));
		byte_0 = new byte[base.Length];
		int num = 0;
		foreach (PivotField item in pivotFieldCollection_0.arrayList_0)
		{
			Array.Copy(BitConverter.GetBytes((short)item.BaseIndex), 0, byte_0, num, 2);
			num += 2;
		}
	}
}
