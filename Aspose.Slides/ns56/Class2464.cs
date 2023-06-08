using ns33;

namespace ns56;

internal class Class2464
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "equ", "neq", "gt", "lt", "gte", "lte");

	public static Enum333 smethod_0(string xmlValue)
	{
		return (Enum333)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum333 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
