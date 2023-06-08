using System;

namespace ns27;

internal class Class587 : Class538
{
	internal Class587()
	{
		method_2(2172);
		method_0(20);
		byte_0 = new byte[base.Length];
	}

	internal void method_4(int int_0, uint uint_0)
	{
		byte_0[0] = 124;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 14, 2);
		Array.Copy(BitConverter.GetBytes(uint_0), 0, byte_0, 16, 4);
	}
}
