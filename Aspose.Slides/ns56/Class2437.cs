using ns33;

namespace ns56;

internal class Class2437
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "persistPropertyBag", "persistStream", "persistStreamInit", "persistStorage");

	public static Enum309 smethod_0(string xmlValue)
	{
		return (Enum309)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum309 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
