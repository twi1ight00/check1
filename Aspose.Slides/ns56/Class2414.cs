using ns33;

namespace ns56;

internal class Class2414
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "worksheet", "xml", "queryTable");

	public static Enum247 smethod_0(string xmlValue)
	{
		return (Enum247)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum247 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
