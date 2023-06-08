using ns33;

namespace ns56;

internal class Class2435
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "cust", "fixedVal", "percentage", "stdDev", "stdErr");

	public static Enum265 smethod_0(string xmlValue)
	{
		return (Enum265)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum265 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
