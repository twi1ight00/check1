using ns33;

namespace ns56;

internal class Class2439
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "sib", "tree");

	public static Enum311 smethod_0(string xmlValue)
	{
		return (Enum311)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum311 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
