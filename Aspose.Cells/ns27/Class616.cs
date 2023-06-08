using System;
using ns2;

namespace ns27;

internal class Class616 : Class538
{
	internal Class616()
	{
		method_2(442);
	}

	internal void method_4(string string_0)
	{
		byte[] array = Class937.smethod_2(string_0);
		method_0((short)(array.Length + 3));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(string_0.Length), byte_0, 2);
		if (array.Length != string_0.Length)
		{
			byte_0[2] = 1;
		}
		Array.Copy(array, 0, byte_0, 3, base.Length - 3);
	}
}
