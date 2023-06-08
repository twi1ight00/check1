using System;
using ns7;

namespace ns27;

internal class Class634 : Class538
{
	internal void method_4(Class1383 class1383_0)
	{
		Array.Copy(BitConverter.GetBytes(class1383_0.ushort_0), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes(class1383_0.ushort_1), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes(class1383_0.ushort_3), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes(class1383_0.ushort_2), 0, byte_0, 6, 2);
		Array.Copy(BitConverter.GetBytes((ushort)class1383_0.int_0), 0, byte_0, 8, 2);
	}

	internal Class634()
	{
		method_2(4192);
		method_0(10);
		byte_0 = new byte[10];
	}
}
