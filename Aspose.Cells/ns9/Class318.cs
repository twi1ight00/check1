using ns10;
using ns2;

namespace ns9;

internal class Class318 : Class316
{
	internal Class318(Class1653 class1653_0)
	{
		int_0 = 361;
		int length = class1653_0.Name.Length;
		byte_0 = new byte[4 + length * 2];
		int num = 0;
		Class1217.smethod_7(byte_0, ref num, class1653_0.Name);
	}
}
