using ns33;

namespace ns56;

internal class Class2495
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "allAtOnce", "p", "cust", "whole");

	public static Enum359 smethod_0(string xmlValue)
	{
		return (Enum359)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum359 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
