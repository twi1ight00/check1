using System;

namespace ns27;

internal class Class552 : Class538
{
	internal Class552()
	{
		method_2(2212);
	}

	internal void method_4(int int_0, byte[] byte_1)
	{
		method_0((short)(16 + byte_1.Length));
		byte_0 = new byte[base.Length];
		byte_0[0] = 164;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes((short)int_0), 0, byte_0, 12, 2);
		byte_0[14] = 129;
		byte_0[15] = 1;
		Array.Copy(byte_1, 0, byte_0, 16, byte_1.Length);
	}
}
