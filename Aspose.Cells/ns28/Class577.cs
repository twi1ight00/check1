using System;
using Aspose.Cells.Pivot;
using ns2;
using ns27;

namespace ns28;

internal class Class577 : Class538
{
	internal Class577()
	{
		method_2(178);
	}

	internal void method_4(PivotItem pivotItem_0)
	{
		method_5((short)pivotItem_0.ushort_0, pivotItem_0.ushort_1, (ushort)pivotItem_0.Index, pivotItem_0.string_0);
	}

	internal void method_5(short short_2, ushort ushort_0, ushort ushort_1, string string_0)
	{
		int num = 0;
		method_0((short)(8 + Class1677.smethod_29(string_0)));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(short_2), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 0 + 2, 2);
		Array.Copy(BitConverter.GetBytes(ushort_1), 0, byte_0, 0 + 4, 2);
		num = 0 + 6;
		if (string_0 == null)
		{
			byte_0[num++] = byte.MaxValue;
			byte_0[num++] = byte.MaxValue;
			return;
		}
		int length = string_0.Length;
		Array.Copy(BitConverter.GetBytes((ushort)length), 0, byte_0, num, 2);
		num += 2;
		num += Class937.smethod_4(byte_0, num, string_0);
	}
}
