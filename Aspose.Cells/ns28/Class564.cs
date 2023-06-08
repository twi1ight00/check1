using System;
using ns27;
using ns45;

namespace ns28;

internal class Class564 : Class538
{
	internal Class564(Class1148 class1148_0)
	{
		method_2(259);
		method_0(4);
		byte_0 = new byte[base.Length];
		Array.Copy(BitConverter.GetBytes((short)class1148_0.int_1), 0, byte_0, 2, 2);
	}
}
