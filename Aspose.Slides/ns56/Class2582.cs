using ns33;
using ns57;

namespace ns56;

internal class Class2582
{
	private static readonly Class1151 class1151_0 = new Class1151("rgb", "hsl");

	public static Enum279 smethod_0(string xmlValue)
	{
		return (Enum279)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum279 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
