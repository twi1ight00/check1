using System;

namespace ns27;

internal class Class662 : Class538
{
	internal Class662()
	{
		method_2(4135);
		method_0(6);
		byte_0 = new byte[6];
	}

	internal void method_4(byte byte_1)
	{
		byte_0[0] = byte_1;
	}

	internal void method_5(byte byte_1, int int_0, int int_1)
	{
		byte_0[0] = byte_1;
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, 4, 2);
	}
}
