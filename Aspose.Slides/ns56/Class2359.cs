using ns33;

namespace ns56;

internal class Class2359
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "lessThan", "lessThanOrEqual", "equal", "notEqual", "greaterThanOrEqual", "greaterThan", "between", "notBetween", "containsText", "notContains", "beginsWith", "endsWith");

	public static Enum192 smethod_0(string xmlValue)
	{
		return (Enum192)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum192 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
