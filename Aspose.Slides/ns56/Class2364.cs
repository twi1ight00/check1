using ns33;

namespace ns56;

internal class Class2364
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "between", "notBetween", "equal", "notEqual", "lessThan", "lessThanOrEqual", "greaterThan", "greaterThanOrEqual");

	public static Enum197 smethod_0(string xmlValue)
	{
		return (Enum197)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum197 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
