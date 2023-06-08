using System;

namespace ns27;

internal class Class680 : Class538
{
	internal Class680()
	{
		method_2(2131);
	}

	internal void method_4(int int_0, int int_1, int int_2, int int_3)
	{
		method_0(12);
		byte_0 = new byte[base.Length];
		byte_0[0] = 83;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, 6, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_2), 0, byte_0, 8, 2);
		Array.Copy(BitConverter.GetBytes((ushort)int_3), 0, byte_0, 10, 2);
	}
}
