using ns7;

namespace ns27;

internal class Class672 : Class538
{
	internal Class672(Class1387 class1387_0)
	{
		method_2(4160);
		method_0(4);
		byte_0 = new byte[4];
		if (class1387_0.HasRadarAxisLabels)
		{
			byte_0[0] = 1;
		}
		if (class1387_0.method_22())
		{
			byte_0[0] |= 2;
		}
		byte_0[2] = 18;
	}
}
