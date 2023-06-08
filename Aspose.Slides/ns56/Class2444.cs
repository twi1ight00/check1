using ns33;

namespace ns56;

internal class Class2444
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "percentStacked", "clustered", "standard", "stacked");

	public static Enum316 smethod_0(string xmlValue)
	{
		return (Enum316)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum316 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
