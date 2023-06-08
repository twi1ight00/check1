using ns33;

namespace ns56;

internal class Class2348
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "first", "last", "all");

	public static Enum182 smethod_0(string xmlValue)
	{
		return (Enum182)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum182 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
