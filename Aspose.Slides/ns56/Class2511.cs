using ns33;

namespace ns56;

internal class Class2511
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "margin", "page", "text", "line");

	public static Enum375 smethod_0(string xmlValue)
	{
		return (Enum375)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum375 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
