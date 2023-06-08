using System;
using ns27;
using ns45;

namespace ns28;

internal class Class568 : Class538
{
	internal Class568(Class1166 class1166_0)
	{
		method_2(246);
		method_0(8);
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes(class1166_0.ushort_0), 0, byte_0, 0, 2);
		Array.Copy(BitConverter.GetBytes(class1166_0.ushort_1), 0, byte_0, 2, 2);
		Array.Copy(BitConverter.GetBytes(class1166_0.ushort_2), 0, byte_0, 4, 2);
		if (class1166_0.method_0() != null)
		{
			Array.Copy(BitConverter.GetBytes((ushort)class1166_0.method_1().Count), 0, byte_0, 6, 2);
		}
	}
}
