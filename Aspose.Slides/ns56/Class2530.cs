using ns33;
using ns57;

namespace ns56;

internal class Class2530
{
	private static readonly Class1151 class1151_0 = new Class1151("el", "wd", "lt");

	public static Enum276 smethod_0(string xmlValue)
	{
		return (Enum276)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum276 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
