using ns33;

namespace ns56;

internal class Class2486
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "arc", "callout", "connector", "align");

	public static Enum350 smethod_0(string xmlValue)
	{
		return (Enum350)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum350 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
