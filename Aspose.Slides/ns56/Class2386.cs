using ns33;

namespace ns56;

internal class Class2386
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "u", "a", "d", "aa", "ad", "na", "nd");

	public static Enum219 smethod_0(string xmlValue)
	{
		return (Enum219)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum219 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
