using System;

namespace ns27;

internal class Class701 : Class538
{
	internal Class701()
	{
		method_2(4170);
		method_0(2);
		byte_0 = new byte[2];
	}

	internal void method_4(ushort ushort_0)
	{
		Array.Copy(BitConverter.GetBytes(ushort_0), byte_0, 2);
	}
}
