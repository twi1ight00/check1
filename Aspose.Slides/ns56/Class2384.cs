using ns33;

namespace ns56;

internal class Class2384
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "m", "v", "s", "c", "r", "p", "k");

	public static Enum217 smethod_0(string xmlValue)
	{
		return (Enum217)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum217 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
