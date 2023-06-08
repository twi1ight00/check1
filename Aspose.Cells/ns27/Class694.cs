using System;

namespace ns27;

internal class Class694 : Class538
{
	internal Class694(int int_0)
	{
		method_2(160);
		method_0(4);
		byte_0 = new byte[4];
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 0, 2);
		byte_0[2] = 100;
	}
}
