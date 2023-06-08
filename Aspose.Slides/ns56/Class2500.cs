using ns33;

namespace ns56;

internal class Class2500
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "solid", "gradient", "gradientRadial", "tile", "pattern", "frame");

	public static Enum364 smethod_0(string xmlValue)
	{
		return (Enum364)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum364 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
