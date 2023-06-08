using ns33;

namespace ns56;

internal class Class2401
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "A1", "R1C1");

	public static Enum234 smethod_0(string xmlValue)
	{
		return (Enum234)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum234 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
