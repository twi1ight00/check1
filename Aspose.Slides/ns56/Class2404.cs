using ns33;

namespace ns56;

internal class Class2404
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "selection", "data", "field");

	public static Enum237 smethod_0(string xmlValue)
	{
		return (Enum237)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum237 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
