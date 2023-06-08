using System;

namespace ns9;

internal class Class363 : Class316
{
	internal Class363(int int_1, bool bool_0)
	{
		int_0 = 363;
		byte_0 = new byte[5];
		Array.Copy(BitConverter.GetBytes(int_1), 0, byte_0, 0, 4);
		if (bool_0)
		{
			byte_0[4] = 1;
		}
		else
		{
			byte_0[4] = 0;
		}
	}
}
