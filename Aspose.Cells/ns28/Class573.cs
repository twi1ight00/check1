using System;
using ns27;
using ns45;

namespace ns28;

internal class Class573 : Class538
{
	internal Class573()
	{
		method_2(256);
		method_0(20);
		byte_0 = new byte[base.Length];
	}

	internal void method_4(Class1174 class1174_0)
	{
		Array.Copy(BitConverter.GetBytes(class1174_0.ushort_0), 0, byte_0, 0, 2);
		byte_0[0 + 2] = class1174_0.byte_0;
		byte_0[0 + 3] = class1174_0.byte_1;
		Array.Copy(BitConverter.GetBytes(class1174_0.method_3()), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes(class1174_0.method_2()), 0, byte_0, 4 + 2, 2);
		Array.Copy(BitConverter.GetBytes(class1174_0.short_0), 0, byte_0, 4 + 4, 2);
		byte[] array = byte_0;
		_ = 10 + 1;
		array[10] = byte.MaxValue;
		byte[] array2 = byte_0;
		_ = 11 + 1;
		array2[11] = byte.MaxValue;
	}
}
