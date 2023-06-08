using ns33;

namespace ns56;

internal class Class2498
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "view", "edit", "backwardCompatible");

	public static Enum362 smethod_0(string xmlValue)
	{
		return (Enum362)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum362 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
