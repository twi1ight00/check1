using ns33;

namespace ns56;

internal class Class2469
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "node", "asst", "doc", "pres", "parTrans", "sibTrans");

	public static Enum337 smethod_0(string xmlValue)
	{
		return (Enum337)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum337 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
