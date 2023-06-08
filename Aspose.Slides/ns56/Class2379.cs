using ns33;

namespace ns56;

internal class Class2379
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "insertDelete", "insertClear", "overwriteClear");

	public static Enum212 smethod_0(string xmlValue)
	{
		return (Enum212)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum212 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
