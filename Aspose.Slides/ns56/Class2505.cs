using ns33;

namespace ns56;

internal class Class2505
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "narrow", "medium", "wide");

	public static Enum369 smethod_0(string xmlValue)
	{
		return (Enum369)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum369 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
