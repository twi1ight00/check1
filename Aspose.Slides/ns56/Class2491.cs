using ns33;

namespace ns56;

internal class Class2491
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "typeAny", "invalid");

	public static Enum355 smethod_0(string xmlValue)
	{
		return (Enum355)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum355 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
