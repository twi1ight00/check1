using ns33;

namespace ns56;

internal class Class2374
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "major", "minor");

	public static Enum207 smethod_0(string xmlValue)
	{
		return (Enum207)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum207 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
