using ns33;
using ns57;

namespace ns56;

internal class Class2588
{
	private static readonly Class1151 class1151_0 = new Class1151("normal", "childStyle");

	public static Enum286 smethod_0(string xmlValue)
	{
		return (Enum286)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum286 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
