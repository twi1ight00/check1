using ns16;
using ns33;

namespace ns56;

internal class Class2523
{
	private static readonly Class1151 class1151_0 = new Class1151("between", "midCat");

	public static Enum268 smethod_0(string xmlValue)
	{
		return (Enum268)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum268 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
