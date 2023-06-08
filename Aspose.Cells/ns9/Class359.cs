using System;
using ns2;

namespace ns9;

internal class Class359 : Class316
{
	internal Class359()
	{
		int_0 = 369;
	}

	internal void method_6(Class1116 class1116_0)
	{
		byte_0 = new byte[5];
		Array.Copy(BitConverter.GetBytes(class1116_0.int_0), 0, byte_0, 0, 4);
		bool flag = (bool)class1116_0.object_0;
		byte_0[4] = (byte)(flag ? 1 : 0);
	}
}
