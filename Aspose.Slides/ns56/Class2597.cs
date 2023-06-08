using ns33;
using ns57;

namespace ns56;

internal class Class2597
{
	private static readonly Class1151 class1151_0 = new Class1151("always", "whenNotActive", "never");

	public static Enum298 smethod_0(string xmlValue)
	{
		return (Enum298)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum298 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
