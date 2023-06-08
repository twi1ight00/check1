using ns33;

namespace ns56;

internal class Class2443
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "bar", "col");

	public static Enum315 smethod_0(string xmlValue)
	{
		return (Enum315)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum315 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
