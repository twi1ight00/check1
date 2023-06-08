using System;
using ns2;
using ns27;
using ns45;

namespace ns28;

internal class Class555 : Class538
{
	internal Class555()
	{
		method_2(2050);
	}

	internal void method_4(Class1172 class1172_0)
	{
		string string_ = class1172_0.string_0;
		method_0((short)(20 + Class1677.smethod_29(string_)));
		byte_0 = new byte[base.Length];
		byte_0[0] = 2;
		byte_0[1] = 8;
		Array.Copy(class1172_0.byte_0, 0, byte_0, 2, class1172_0.byte_0.Length);
		Array.Copy(BitConverter.GetBytes((short)string_.Length), 0, byte_0, 16, 2);
		int num = 18;
		if (string_.Length > 0)
		{
			num += Class937.smethod_4(byte_0, num, string_);
		}
		Array.Copy(BitConverter.GetBytes(class1172_0.ushort_0), 0, byte_0, num, 2);
	}
}
