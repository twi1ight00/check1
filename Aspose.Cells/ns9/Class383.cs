using System;
using ns2;

namespace ns9;

internal class Class383 : Class316
{
	internal Class383(Class1653 class1653_0)
	{
		int_0 = 585;
		if (class1653_0.method_12() != null)
		{
			int num = class1653_0.method_12().Length;
			byte_0 = new byte[num];
			Array.Copy(class1653_0.method_12(), 0, byte_0, 0, num);
		}
		else
		{
			byte_0 = new byte[0];
		}
	}
}
