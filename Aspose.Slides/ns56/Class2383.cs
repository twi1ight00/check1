using ns33;

namespace ns56;

internal class Class2383
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "data", "default", "sum", "countA", "avg", "max", "min", "product", "count", "stdDev", "stdDevP", "var", "varP", "grand", "blank");

	public static Enum216 smethod_0(string xmlValue)
	{
		return (Enum216)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum216 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
