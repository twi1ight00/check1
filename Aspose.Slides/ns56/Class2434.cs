using ns33;

namespace ns56;

internal class Class2434
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "x", "y");

	public static Enum264 smethod_0(string xmlValue)
	{
		return (Enum264)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum264 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
