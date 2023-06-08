using ns33;

namespace ns56;

internal class Class2358
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "commNone", "commIndicator", "commIndAndComment");

	public static Enum191 smethod_0(string xmlValue)
	{
		return (Enum191)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum191 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
