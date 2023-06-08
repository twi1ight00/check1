using ns33;

namespace ns56;

internal class Class2399
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "displayed", "blank", "dash", "NA");

	public static Enum232 smethod_0(string xmlValue)
	{
		return (Enum232)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum232 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
