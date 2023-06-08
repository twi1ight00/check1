using ns33;

namespace ns56;

internal class Class2411
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "ascending", "descending", "ascendingAlpha", "descendingAlpha", "ascendingNatural", "descendingNatural");

	public static Enum244 smethod_0(string xmlValue)
	{
		return (Enum244)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum244 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
