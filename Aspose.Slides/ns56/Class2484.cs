using ns33;

namespace ns56;

internal class Class2484
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "left", "right", "center");

	public static Enum348 smethod_0(string xmlValue)
	{
		return (Enum348)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum348 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
