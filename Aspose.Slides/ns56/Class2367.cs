using ns33;

namespace ns56;

internal class Class2367
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "nil", "b", "n", "e", "str");

	public static Enum200 smethod_0(string xmlValue)
	{
		return (Enum200)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum200 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
