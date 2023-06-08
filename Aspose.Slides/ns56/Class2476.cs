using ns33;

namespace ns56;

internal class Class2476
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "auto", "custom");

	public static Enum340 smethod_0(string xmlValue)
	{
		return (Enum340)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum340 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
