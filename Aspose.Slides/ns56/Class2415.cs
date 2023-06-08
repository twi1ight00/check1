using ns33;

namespace ns56;

internal class Class2415
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "544x376", "640x480", "720x512", "800x600", "1024x768", "1152x882", "1152x900", "1280x1024", "1600x1200", "1800x1440", "1920x1200");

	public static Enum248 smethod_0(string xmlValue)
	{
		return (Enum248)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum248 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
