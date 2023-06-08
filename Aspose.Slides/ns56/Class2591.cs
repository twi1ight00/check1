using ns33;
using ns57;

namespace ns56;

internal class Class2591
{
	private static readonly Class1151 class1151_0 = new Class1151("evt", "call", "verb");

	public static Enum288 smethod_0(string xmlValue)
	{
		return (Enum288)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum288 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
