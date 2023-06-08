using ns33;

namespace ns56;

internal class Class2347
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "full", "textAndBackground");

	public static Enum181 smethod_0(string xmlValue)
	{
		return (Enum181)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum181 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
