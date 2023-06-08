using System;

namespace ns27;

internal class Class613 : Class538
{
	internal Class613()
	{
		method_2(4116);
		method_0(20);
		byte_0 = new byte[20];
	}

	internal void method_4()
	{
		byte_0[16] = 1;
	}

	internal void method_5(int int_0)
	{
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 18, 2);
	}
}
