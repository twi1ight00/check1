using ns33;

namespace ns56;

internal class Class2402
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "add", "delete");

	public static Enum235 smethod_0(string xmlValue)
	{
		return (Enum235)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum235 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
