using ns33;

namespace ns56;

internal class Class2357
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "num", "percent", "max", "min", "formula", "percentile");

	public static Enum190 smethod_0(string xmlValue)
	{
		return (Enum190)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum190 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
