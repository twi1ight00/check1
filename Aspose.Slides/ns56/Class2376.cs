using ns33;

namespace ns56;

internal class Class2376
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "ref", "refError", "area", "areaError", "computedArea");

	public static Enum209 smethod_0(string xmlValue)
	{
		return (Enum209)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum209 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
