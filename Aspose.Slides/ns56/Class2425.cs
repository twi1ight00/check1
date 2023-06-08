using ns33;

namespace ns56;

internal class Class2425
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "b", "n", "e", "s");

	public static Enum258 smethod_0(string xmlValue)
	{
		return (Enum258)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum258 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
