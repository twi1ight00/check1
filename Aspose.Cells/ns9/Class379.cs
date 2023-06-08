using System;
using ns10;
using ns2;

namespace ns9;

internal class Class379 : Class316
{
	internal Class379(Class1348 class1348_0)
	{
		int_0 = 427;
		int num = class1348_0.Formula.Length;
		byte_0 = new byte[16 + num];
		Class1217.smethod_4(class1348_0.CellArea, byte_0, 0);
		Array.Copy(class1348_0.Formula, 0, byte_0, 16, num);
	}
}
