using ns33;
using ns57;

namespace ns56;

internal class Class2595
{
	private static readonly Class1151 class1151_0 = new Class1151("sameClick", "lastClick", "nextClick");

	public static Enum293 smethod_0(string xmlValue)
	{
		return (Enum293)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum293 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
