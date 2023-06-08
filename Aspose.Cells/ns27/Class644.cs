using System;

namespace ns27;

internal class Class644 : Class538
{
	internal Class644()
	{
		method_2(128);
		method_0(8);
		byte_0 = new byte[8];
	}

	internal void method_4(ushort ushort_0)
	{
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 2, 2);
	}

	internal void method_5(byte byte_1)
	{
		byte_0[6] = byte_1;
	}

	internal void method_6(ushort ushort_0)
	{
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 0, 2);
	}

	internal void method_7(byte byte_1)
	{
		byte_0[4] = byte_1;
	}
}
