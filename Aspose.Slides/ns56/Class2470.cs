using ns33;

namespace ns56;

internal class Class2470
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "exact", "rel");

	public static Enum338 smethod_0(string xmlValue)
	{
		return (Enum338)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum338 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
