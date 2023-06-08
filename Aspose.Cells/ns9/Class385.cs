using System;
using ns10;
using ns2;

namespace ns9;

internal class Class385 : Class316
{
	internal Class385(Class1718 class1718_0)
	{
		int_0 = 359;
		int num = class1718_0.method_4().Length;
		int num2 = 4;
		for (int i = 0; i < num; i++)
		{
			num2 += class1718_0.method_4()[i].Length * 2 + 4;
		}
		byte_0 = new byte[num2];
		Array.Copy(BitConverter.GetBytes(num), 0, byte_0, 0, 4);
		int num3 = 4;
		for (int j = 0; j < num; j++)
		{
			Class1217.smethod_7(byte_0, ref num3, class1718_0.method_4()[j]);
		}
	}
}
