using System;
using ns10;
using ns2;

namespace ns9;

internal class Class377 : Class316
{
	internal Class377()
	{
		int_0 = 152;
	}

	internal void method_6(Class1732 class1732_0)
	{
		byte_0 = new byte[20 + class1732_0.method_3().Count * 16];
		byte_0[0] = class1732_0.method_1();
		Array.Copy(BitConverter.GetBytes(class1732_0.method_5()), 0, byte_0, 4, 4);
		Array.Copy(BitConverter.GetBytes(class1732_0.method_7()), 0, byte_0, 8, 4);
		Array.Copy(BitConverter.GetBytes(class1732_0.method_9()), 0, byte_0, 12, 4);
		Class1217.smethod_3(class1732_0.method_3(), byte_0, 16);
	}
}
