using ns33;

namespace ns56;

internal class Class2462
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "norm", "rev");

	public static Enum331 smethod_0(string xmlValue)
	{
		return (Enum331)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum331 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
