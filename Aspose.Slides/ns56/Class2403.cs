using ns33;

namespace ns56;

internal class Class2403
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "insertRow", "deleteRow", "insertCol", "deleteCol");

	public static Enum236 smethod_0(string xmlValue)
	{
		return (Enum236)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum236 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
