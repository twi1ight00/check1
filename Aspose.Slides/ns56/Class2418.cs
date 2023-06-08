using ns33;

namespace ns56;

internal class Class2418
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "all", "row", "column");

	public static Enum251 smethod_0(string xmlValue)
	{
		return (Enum251)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum251 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
