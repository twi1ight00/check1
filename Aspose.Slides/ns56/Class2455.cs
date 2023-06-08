using ns33;

namespace ns56;

internal class Class2455
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "one", "branch");

	public static Enum325 smethod_0(string xmlValue)
	{
		return (Enum325)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum325 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
