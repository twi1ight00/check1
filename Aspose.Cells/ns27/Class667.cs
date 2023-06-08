using System;
using ns7;

namespace ns27;

internal class Class667 : Class538
{
	internal Class667(Class1387 class1387_0)
	{
		method_2(4121);
		method_0(6);
		byte_0 = new byte[6];
		Array.Copy(BitConverter.GetBytes((ushort)class1387_0.FirstSliceAngle), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes((ushort)class1387_0.DoughnutHoleSize), 0, byte_0, 2, 2);
		byte_0[4] = 2;
		if (class1387_0.method_22())
		{
			byte_0[4] |= 1;
		}
		if (!class1387_0.HasLeaderLines)
		{
			byte_0[4] &= 253;
		}
	}
}
