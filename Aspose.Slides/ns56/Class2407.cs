using ns33;

namespace ns56;

internal class Class2407
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "normal", "difference", "percent", "percentDiff", "runTotal", "percentOfRow", "percentOfCol", "percentOfTotal", "index");

	public static Enum240 smethod_0(string xmlValue)
	{
		return (Enum240)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum240 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
