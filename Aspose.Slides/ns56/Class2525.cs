using ns33;
using ns57;

namespace ns56;

internal class Class2525
{
	private static readonly Class1151 class1151_0 = new Class1151("sp", "bg");

	public static Enum291 smethod_0(string xmlValue)
	{
		return (Enum291)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum291 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
