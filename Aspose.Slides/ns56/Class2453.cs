using ns33;

namespace ns56;

internal class Class2453
{
	private static readonly Class1151 class1151_0 = new Class1151("composite", "conn", "cycle", "hierChild", "hierRoot", "lin", "pyra", "snake", "sp", "tx");

	public static Enum306 smethod_0(string xmlValue)
	{
		return (Enum306)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum306 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
