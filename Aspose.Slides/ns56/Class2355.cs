using ns33;

namespace ns56;

internal class Class2355
{
	private static readonly Class1151 class1151_0 = new Class1151(0, "b", "n", "e", "s", "str", "inlineStr");

	public static Enum262 smethod_0(string xmlValue)
	{
		return (Enum262)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum262 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
