using ns33;

namespace ns56;

internal class Class2465
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "cnt", "pos", "revPos", "posEven", "posOdd", "var", "depth", "maxDepth");

	public static Enum334 smethod_0(string xmlValue)
	{
		return (Enum334)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum334 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
