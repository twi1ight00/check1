using System;

namespace ns27;

internal class Class606 : Class538
{
	internal Class606()
	{
		method_2(517);
		method_0(8);
		byte_0 = new byte[8];
	}

	internal void method_4(ushort ushort_0, byte byte_1, ushort ushort_1, byte byte_2, bool bool_0)
	{
		Array.Copy(BitConverter.GetBytes(ushort_0), byte_0, 2);
		byte_0[2] = byte_1;
		Array.Copy(BitConverter.GetBytes(ushort_1), 0, byte_0, 4, 2);
		byte_0[6] = byte_2;
		if (bool_0)
		{
			byte_0[7] = 1;
		}
	}
}
