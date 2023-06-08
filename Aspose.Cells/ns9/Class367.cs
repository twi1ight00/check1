using System;
using ns10;

namespace ns9;

internal class Class367 : Class316
{
	internal Class367()
	{
		int_0 = 44;
	}

	internal void method_6(int int_1, string string_0)
	{
		int num = 6 + 2 * string_0.Length;
		byte_0 = new byte[num];
		Array.Copy(BitConverter.GetBytes((ushort)int_1), 0, byte_0, 0, 2);
		int num2 = 2;
		Class1217.smethod_7(byte_0, ref num2, string_0);
	}
}
