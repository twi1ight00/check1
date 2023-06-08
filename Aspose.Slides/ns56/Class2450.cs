using ns33;

namespace ns56;

internal class Class2450
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "standard", "marker", "filled");

	public static Enum322 smethod_0(string xmlValue)
	{
		return (Enum322)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum322 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
