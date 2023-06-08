using System;

namespace ns27;

internal class Class625 : Class538
{
	internal Class625(ushort ushort_0)
	{
		if (ushort_0 == 0)
		{
			ushort_0 = 8;
		}
		method_2(85);
		method_0(2);
		byte_0 = BitConverter.GetBytes(ushort_0);
	}
}
