using ns33;

namespace ns56;

internal class Class2375
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "blank", "formatting", "drill", "formula");

	public static Enum208 smethod_0(string xmlValue)
	{
		return (Enum208)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum208 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
