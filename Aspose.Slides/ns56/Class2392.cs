using ns33;

namespace ns56;

internal class Class2392
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "split", "frozen", "frozenSplit");

	public static Enum225 smethod_0(string xmlValue)
	{
		return (Enum225)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum225 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
