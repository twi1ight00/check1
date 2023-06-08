using System;

namespace ns27;

internal class Class650 : Class538
{
	internal Class650(bool bool_0, int int_0)
	{
		method_2(4163);
		method_0(4);
		byte_0 = new byte[4];
		if (bool_0)
		{
			byte_0[2] |= 1;
		}
		else
		{
			byte_0[2] = 2;
		}
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 0, 2);
	}
}
