using System;
using ns2;

namespace ns27;

internal class Class648 : Class538
{
	internal Class648()
	{
		method_2(516);
	}

	internal void method_4(ushort ushort_0, ushort ushort_1, ushort ushort_2, string string_0)
	{
		if (string_0 == "")
		{
			method_0(9);
			byte_0 = new byte[base.Length];
			Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 0, 2);
			Array.Copy(BitConverter.GetBytes(ushort_1), 0, byte_0, 2, 2);
			Array.Copy(BitConverter.GetBytes(ushort_2), 0, byte_0, 4, 2);
			return;
		}
		byte[] array = Class1677.smethod_15(string_0);
		method_0((short)(9 + array.Length));
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(ushort_0), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes(ushort_1), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes(ushort_2), 0, byte_0, 4, 2);
		Array.Copy(BitConverter.GetBytes((ushort)string_0.Length), 0, byte_0, 6, 2);
		if (string_0.Length != array.Length)
		{
			byte_0[8] = 1;
		}
		Array.Copy(array, 0, byte_0, 9, array.Length);
	}
}
