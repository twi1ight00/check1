using System;
using ns10;
using ns2;

namespace ns9;

internal class Class362 : Class316
{
	internal Class362()
	{
		int_0 = 371;
	}

	internal void method_6(Class1116 class1116_0)
	{
		string text = (string)class1116_0.object_0;
		byte_0 = new byte[8 + text.Length * 2];
		Array.Copy(BitConverter.GetBytes(class1116_0.int_0), 0, byte_0, 0, 4);
		int num = 4;
		Class1217.smethod_7(byte_0, ref num, text);
	}
}
