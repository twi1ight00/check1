using ns33;

namespace ns56;

internal class Class2440
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "shape", "circle", "rect");

	public static Enum312 smethod_0(string xmlValue)
	{
		return (Enum312)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum312 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
