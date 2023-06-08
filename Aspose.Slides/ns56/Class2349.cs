using ns33;

namespace ns56;

internal class Class2349
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "axisRow", "axisCol", "axisPage", "axisValues");

	public static Enum183 smethod_0(string xmlValue)
	{
		return (Enum183)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum183 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
