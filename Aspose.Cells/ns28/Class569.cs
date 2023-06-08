using System;
using ns27;
using ns45;

namespace ns28;

internal class Class569 : Class538
{
	internal Class569(Class1167 class1167_0)
	{
		method_2(248);
		method_0(8);
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(class1167_0.ushort_0), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes(class1167_0.ushort_1), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes(class1167_0.ushort_2), 0, byte_0, 6, 2);
	}
}
