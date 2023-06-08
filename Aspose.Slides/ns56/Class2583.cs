using ns33;
using ns57;

namespace ns56;

internal class Class2583
{
	private static readonly Class1151 class1151_0 = new Class1151("none", "in", "out");

	public static Enum281 smethod_0(string xmlValue)
	{
		return (Enum281)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum281 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
