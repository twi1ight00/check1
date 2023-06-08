using ns16;
using ns33;

namespace ns56;

internal class Class2541
{
	private static readonly Class1151 class1151_0 = new Class1151("none", "norm", "lighten", "lightenLess", "darken", "darkenLess");

	public static Enum271 smethod_0(string xmlValue)
	{
		return (Enum271)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum271 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
