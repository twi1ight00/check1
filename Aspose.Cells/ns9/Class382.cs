using System;
using ns2;

namespace ns9;

internal class Class382 : Class316
{
	internal Class382(Class1718 class1718_0, Class1653 class1653_0)
	{
		int_0 = 586;
		byte_0 = new byte[7];
		if (class1718_0.Type == Enum194.const_0)
		{
			Array.Copy(BitConverter.GetBytes(class1653_0.method_10()), 0, byte_0, 0, 2);
			Array.Copy(BitConverter.GetBytes(class1653_0.SheetIndex), 0, byte_0, 2, 2);
		}
		else if (class1718_0.Type == Enum194.const_4)
		{
			Array.Copy(BitConverter.GetBytes(class1653_0.method_10()), 0, byte_0, 0, 2);
			byte_0[6] = 1;
		}
		else
		{
			Array.Copy(BitConverter.GetBytes(class1653_0.method_10()), 0, byte_0, 0, 2);
			byte_0[6] = 1;
		}
	}
}
