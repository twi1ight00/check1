using ns33;

namespace ns56;

internal class Class2510
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "margin", "page", "text", "char");

	public static Enum374 smethod_0(string xmlValue)
	{
		return (Enum374)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum374 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
