using ns33;

namespace ns56;

internal class Class2417
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "sum", "min", "max", "average", "count", "countNums", "stdDev", "var", "custom");

	public static Enum250 smethod_0(string xmlValue)
	{
		return (Enum250)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum250 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
