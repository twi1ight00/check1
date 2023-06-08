using ns33;

namespace ns56;

internal class Class2373
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "equal", "lessThan", "lessThanOrEqual", "notEqual", "greaterThanOrEqual", "greaterThan");

	public static Enum206 smethod_0(string xmlValue)
	{
		return (Enum206)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum206 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
