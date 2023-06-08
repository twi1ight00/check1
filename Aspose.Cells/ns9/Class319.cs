using System;
using ns10;
using ns16;

namespace ns9;

internal class Class319 : Class316
{
	internal Class319(Class1550 class1550_0)
	{
		int_0 = 644;
		int length = class1550_0.string_3.Length;
		int length2 = class1550_0.string_1.Length;
		byte_0 = new byte[12 + length * 2 + length2 * 2];
		Array.Copy(BitConverter.GetBytes(Class1618.smethod_87(class1550_0.string_0)), 0, byte_0, 0, 4);
		int num = 4;
		Class1217.smethod_7(byte_0, ref num, class1550_0.string_3);
		Class1217.smethod_7(byte_0, ref num, class1550_0.string_1);
	}
}
