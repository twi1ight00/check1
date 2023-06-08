using System;
using ns7;

namespace ns27;

internal class Class666 : Class538
{
	internal Class666()
	{
		method_2(4107);
		method_0(2);
		byte_0 = new byte[2];
	}

	internal void method_4(Class1633 class1633_0)
	{
		Array.Copy(BitConverter.GetBytes((ushort)class1633_0.method_0()), 0, byte_0, 0, 2);
	}
}
