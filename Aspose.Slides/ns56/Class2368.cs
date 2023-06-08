using ns33;

namespace ns56;

internal class Class2368
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "DVASPECT_CONTENT", "DVASPECT_ICON");

	public static Enum201 smethod_0(string xmlValue)
	{
		return (Enum201)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum201 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
