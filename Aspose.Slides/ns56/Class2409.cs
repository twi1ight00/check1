using ns33;

namespace ns56;

internal class Class2409
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "value", "cellColor", "fontColor", "icon");

	public static Enum242 smethod_0(string xmlValue)
	{
		return (Enum242)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum242 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
