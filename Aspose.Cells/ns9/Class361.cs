using System;
using ns2;

namespace ns9;

internal class Class361 : Class316
{
	internal Class361()
	{
		int_0 = 368;
	}

	internal void method_6(Class1116 class1116_0)
	{
		byte_0 = new byte[12];
		Array.Copy(BitConverter.GetBytes(class1116_0.int_0), 0, byte_0, 0, 4);
		Array.Copy(BitConverter.GetBytes((double)class1116_0.object_0), 0, byte_0, 4, 8);
	}
}
