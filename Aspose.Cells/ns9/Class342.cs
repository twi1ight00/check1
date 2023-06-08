using ns10;
using ns16;

namespace ns9;

internal class Class342 : Class316
{
	internal Class342()
	{
		int_0 = 46;
	}

	internal void SetBorder(Class1526 class1526_0)
	{
		byte_0 = new byte[51];
		int num = 0;
		if (class1526_0.bool_1)
		{
			num |= 2;
		}
		if (class1526_0.bool_0)
		{
			num |= 1;
		}
		byte_0[0] = (byte)num;
		method_6(1, class1526_0.class1527_0);
		method_6(11, class1526_0.class1527_2);
		method_6(21, class1526_0.class1527_1);
		method_6(31, class1526_0.class1527_3);
		if (class1526_0.bool_1 || class1526_0.bool_0)
		{
			method_6(41, class1526_0.class1527_4);
		}
	}

	private void method_6(int int_1, Class1527 class1527_0)
	{
		byte_0[int_1] = (byte)Class1224.smethod_11(class1527_0.cellBorderType_0);
		method_3(byte_0, int_1 + 2, class1527_0.internalColor_0, 64);
	}
}
