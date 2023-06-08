using ns33;

namespace ns56;

internal class Class2504
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "block", "classic", "oval", "diamond", "open");

	public static Enum368 smethod_0(string xmlValue)
	{
		return (Enum368)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum368 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
