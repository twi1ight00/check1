using ns33;

namespace ns56;

internal class Class2485
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "auto", "custom");

	public static Enum349 smethod_0(string xmlValue)
	{
		return (Enum349)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum349 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
