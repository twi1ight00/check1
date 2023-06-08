using System;

namespace ns27;

internal class Class626 : Class538
{
	internal Class626()
	{
		method_2(549);
		method_0(4);
		byte_0 = new byte[4] { 0, 0, 255, 0 };
	}

	internal void method_4(byte byte_1, ushort ushort_0)
	{
		byte_0[0] = byte_1;
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 2, 2);
	}
}
