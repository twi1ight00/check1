using ns16;
using ns33;

namespace ns56;

internal class Class2559
{
	private static readonly Class1151 class1151_0 = new Class1151("auto", "cust", "percent", "pos", "val");

	public static Enum270 smethod_0(string xmlValue)
	{
		return (Enum270)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum270 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
