using ns33;

namespace ns56;

internal class Class2424
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "realTimeData", "olapFunctions");

	public static Enum257 smethod_0(string xmlValue)
	{
		return (Enum257)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum257 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
