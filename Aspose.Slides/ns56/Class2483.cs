using ns33;

namespace ns56;

internal class Class2483
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "top", "middle", "bottom", "left", "center", "right");

	public static Enum347 smethod_0(string xmlValue)
	{
		return (Enum347)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum347 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
