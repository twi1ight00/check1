using ns33;

namespace ns56;

internal class Class2482
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "gradientCenter", "solid", "pattern", "tile", "frame", "gradientUnscaled", "gradientRadial", "gradient", "background");

	public static Enum346 smethod_0(string xmlValue)
	{
		return (Enum346)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum346 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
