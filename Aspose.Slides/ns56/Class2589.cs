using ns33;
using ns57;

namespace ns56;

internal class Class2589
{
	private static readonly Class1151 class1151_0 = new Class1151("pt", "img");

	public static Enum287 smethod_0(string xmlValue)
	{
		return (Enum287)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum287 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
