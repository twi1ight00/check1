using ns33;
using ns57;

namespace ns56;

internal class Class2584
{
	private static readonly Class1151 class1151_0 = new Class1151("parent", "layout");

	public static Enum282 smethod_0(string xmlValue)
	{
		return (Enum282)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum282 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
