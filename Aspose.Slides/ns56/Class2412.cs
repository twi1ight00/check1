using ns33;

namespace ns56;

internal class Class2412
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "worksheet", "external", "consolidation", "scenario");

	public static Enum245 smethod_0(string xmlValue)
	{
		return (Enum245)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum245 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
