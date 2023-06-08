using ns33;

namespace ns56;

internal class Class2422
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "baseline", "superscript", "subscript");

	public static Enum255 smethod_0(string xmlValue)
	{
		return (Enum255)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum255 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
