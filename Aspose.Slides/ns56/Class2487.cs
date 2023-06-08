using ns33;

namespace ns56;

internal class Class2487
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "", "t", "f", "true", "false");

	public static Enum351 smethod_0(string xmlValue)
	{
		return (Enum351)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum351 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
