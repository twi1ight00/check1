using ns33;

namespace ns56;

internal class Class2362
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "stop", "warning", "information");

	public static Enum195 smethod_0(string xmlValue)
	{
		return (Enum195)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum195 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
