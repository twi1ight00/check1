using ns33;

namespace ns56;

internal class Class2377
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "linear", "path");

	public static Enum210 smethod_0(string xmlValue)
	{
		return (Enum210)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum210 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
