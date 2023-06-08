using System;

namespace ns27;

internal class Class685 : Class538
{
	internal Class685()
	{
		method_2(2138);
	}

	internal void method_4(int int_0, int int_1)
	{
		if (int_0 != -1 && int_1 != -1)
		{
			method_0(16);
			byte_0 = new byte[16]
			{
				90, 8, 0, 0, 9, 0, 2, 0, 1, 0,
				0, 0, 1, 0, 0, 0
			};
			Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 10, 2);
			Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, 14, 2);
		}
		else
		{
			int num = ((int_0 == -1) ? int_1 : int_0);
			method_0(12);
			byte_0 = new byte[12]
			{
				90, 8, 0, 0, 9, 0, 1, 0, 1, 0,
				5, 0
			};
			Array.Copy(BitConverter.GetBytes((ushort)num), 0, byte_0, 10, 2);
		}
	}
}
