using ns33;
using ns57;

namespace ns56;

internal class Class2586
{
	private static readonly Class1151 class1151_0 = new Class1151("none", "always");

	public static Enum284 smethod_0(string xmlValue)
	{
		return (Enum284)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum284 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
