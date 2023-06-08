using ns33;
using ns57;

namespace ns56;

internal class Class2598
{
	private static readonly Class1151 class1151_0 = new Class1151("canSlip", "locked");

	public static Enum300 smethod_0(string xmlValue)
	{
		return (Enum300)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum300 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
