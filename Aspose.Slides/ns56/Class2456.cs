using ns33;

namespace ns56;

internal class Class2456
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "equ", "gte", "lte");

	public static Enum326 smethod_0(string xmlValue)
	{
		return (Enum326)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum326 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
