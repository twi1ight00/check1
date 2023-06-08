using ns33;
using ns57;

namespace ns56;

internal class Class2581
{
	private static readonly Class1151 class1151_0 = new Class1151("cw", "ccw");

	public static Enum280 smethod_0(string xmlValue)
	{
		return (Enum280)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum280 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
