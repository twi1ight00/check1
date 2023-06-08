using System;
using ns27;
using ns45;

namespace ns28;

internal class Class554 : Class538
{
	private Class1163 class1163_0;

	internal Class554(Class1163 class1163_1)
	{
		class1163_0 = class1163_1;
		method_2(251);
		method_4();
	}

	internal void method_4()
	{
		method_0((short)4);
		byte_0 = new byte[base.Length];
		byte_0[0] = class1163_0.byte_0;
	}

	internal void method_5(short short_2)
	{
		Array.Copy(BitConverter.GetBytes(short_2), 0, byte_0, 2, 2);
	}
}
