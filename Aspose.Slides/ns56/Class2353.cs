using ns33;

namespace ns56;

internal class Class2353
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "asDisplayed", "atEnd");

	public static Enum187 smethod_0(string xmlValue)
	{
		return (Enum187)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum187 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
