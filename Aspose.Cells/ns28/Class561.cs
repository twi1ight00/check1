using System;
using ns27;

namespace ns28;

internal class Class561 : Class538
{
	internal Class561(ushort ushort_0)
	{
		method_2(443);
		method_0(2);
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 0, 2);
	}
}
