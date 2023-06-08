using System;

namespace ns9;

internal class Class334 : Class316
{
	internal Class334()
	{
		int_0 = 159;
	}

	internal void method_6(uint uint_0, int int_1)
	{
		byte_0 = new byte[8];
		Array.Copy(BitConverter.GetBytes(uint_0), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes(int_1), 0, byte_0, 4, 4);
	}
}
