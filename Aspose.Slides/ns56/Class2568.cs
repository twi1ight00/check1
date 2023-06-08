using ns16;
using ns33;

namespace ns56;

internal class Class2568
{
	private static readonly Class1151 class1151_0 = new Class1151("overflow", "clip");

	public static Enum378 smethod_0(string xmlValue)
	{
		return (Enum378)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum378 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
