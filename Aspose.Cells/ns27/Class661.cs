using System;

namespace ns27;

internal class Class661 : Class538
{
	internal Class661()
	{
		method_2(515);
		method_0(14);
	}

	internal void method_4(ushort ushort_0, ushort ushort_1, ushort ushort_2, double double_0)
	{
		byte_0 = new byte[14];
		Array.Copy(BitConverter.GetBytes(ushort_0), byte_0, 2);
		Array.Copy(BitConverter.GetBytes(ushort_1), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes(ushort_2), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes(double_0), 0, byte_0, 6, 8);
	}
}
