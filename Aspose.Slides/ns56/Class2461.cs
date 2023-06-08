using ns33;

namespace ns56;

internal class Class2461
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "parOf", "presOf", "presParOf", "unknownRelationship");

	public static Enum330 smethod_0(string xmlValue)
	{
		return (Enum330)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum330 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
