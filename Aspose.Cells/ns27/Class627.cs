using System;

namespace ns27;

internal class Class627 : Class538
{
	public Class627(int int_0)
	{
		method_2(4157);
		method_0(2);
		byte_0 = new byte[2];
		Array.Copy(BitConverter.GetBytes((ushort)int_0), 0, byte_0, 0, 2);
	}
}
