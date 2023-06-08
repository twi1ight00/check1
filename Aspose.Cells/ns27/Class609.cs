using System;

namespace ns27;

internal class Class609 : Class538
{
	internal Class609()
	{
		method_2(2134);
		method_0(12);
		byte_0 = new byte[12];
	}

	internal void method_4(int int_0, bool bool_0)
	{
		byte_0[0] = 86;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 4, 2);
		byte_0[6] = 2;
		if (bool_0)
		{
			byte_0[8] = 249;
		}
		else
		{
			byte_0[8] = 248;
		}
		byte_0[9] = 131;
	}
}
