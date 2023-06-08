using ns33;

namespace ns56;

internal class Class2471
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "any", "30", "45", "60", "90", "auto");

	public static Enum339 smethod_0(string xmlValue)
	{
		return (Enum339)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum339 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
