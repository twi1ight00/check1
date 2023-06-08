using System;

namespace ns27;

internal class Class638 : Class538
{
	internal Class638(int int_0)
	{
		method_2(4134);
		method_0(2);
		byte_0 = new byte[2];
		Array.Copy(BitConverter.GetBytes((ushort)int_0), byte_0, 2);
	}
}
