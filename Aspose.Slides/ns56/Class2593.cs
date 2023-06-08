using ns33;
using ns57;

namespace ns56;

internal class Class2593
{
	internal static readonly Class1151 class1151_0 = new Class1151("none", "skipTimed");

	public static Enum297 smethod_0(string xmlValue)
	{
		return (Enum297)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum297 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
