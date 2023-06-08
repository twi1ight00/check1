using ns33;
using ns57;

namespace ns56;

internal class Class2592
{
	internal static readonly Class1151 class1151_0 = new Class1151("none", "seek");

	public static Enum294 smethod_0(string xmlValue)
	{
		return (Enum294)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum294 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
