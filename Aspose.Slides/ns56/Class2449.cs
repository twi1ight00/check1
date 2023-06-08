using ns33;

namespace ns56;

internal class Class2449
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "maxMin", "minMax");

	public static Enum321 smethod_0(string xmlValue)
	{
		return (Enum321)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum321 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
