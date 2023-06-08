using ns33;

namespace ns56;

internal class Class2400
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "doubleQuote", "singleQuote", "none");

	public static Enum233 smethod_0(string xmlValue)
	{
		return (Enum233)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum233 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
