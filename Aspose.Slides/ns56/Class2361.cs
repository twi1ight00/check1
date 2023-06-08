using ns33;

namespace ns56;

internal class Class2361
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "average", "count", "countNums", "max", "min", "product", "stdDev", "stdDevp", "sum", "var", "varp");

	public static Enum194 smethod_0(string xmlValue)
	{
		return (Enum194)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum194 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
