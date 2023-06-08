using System;

namespace ns27;

internal class Class581 : Class538
{
	internal Class581(ushort ushort_0, bool bool_0)
	{
		method_2(2188);
		method_0(16);
		byte_0 = new byte[base.Length];
		byte_0[0] = 140;
		byte_0[1] = 8;
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 2, 2);
		if (!bool_0)
		{
			byte_0[12] = 1;
		}
	}
}
