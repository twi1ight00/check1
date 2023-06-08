using System;
using Aspose.Cells.Pivot;
using ns2;
using ns27;
using ns45;

namespace ns28;

internal class Class574 : Class538
{
	internal Class574()
	{
		method_2(177);
	}

	internal void method_4(Class1173 class1173_0)
	{
		PivotField pivotField_ = class1173_0.pivotField_0;
		method_0((short)(10 + Class1677.smethod_29(class1173_0.string_0)));
		byte_0 = new byte[base.Length];
		int num = ((pivotField_.pivotItemCollection_0 != null) ? pivotField_.pivotItemCollection_0.Count : 0);
		int num2 = 0;
		short num3 = class1173_0.method_0();
		ushort num4 = (ushort)pivotField_.pivotFieldType_0;
		if (pivotField_.method_4())
		{
			num4 = (ushort)(num4 | 8u);
		}
		Array.Copy(BitConverter.GetBytes(num4), 0, byte_0, num2, 2);
		Array.Copy(BitConverter.GetBytes(num3), 0, byte_0, num2 + 2, 2);
		Array.Copy(BitConverter.GetBytes(class1173_0.ushort_0), 0, byte_0, num2 + 4, 2);
		Array.Copy(BitConverter.GetBytes((num != 0) ? (num + num3) : 0), 0, byte_0, num2 + 6, 2);
		num2 += 8;
		if (class1173_0.string_0 == null)
		{
			byte_0[num2++] = byte.MaxValue;
			byte_0[num2++] = byte.MaxValue;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes((short)class1173_0.string_0.Length), 0, byte_0, num2, 2);
			num2 += 2;
			num2 += Class937.smethod_4(byte_0, num2, class1173_0.string_0);
		}
	}
}
