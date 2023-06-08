using ns33;
using ns57;

namespace ns56;

internal class Class2580
{
	private static readonly Class1151 class1151_0 = new Class1151("str", "num", "clr");

	public static Enum379 smethod_0(string xmlValue)
	{
		return (Enum379)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum379 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
