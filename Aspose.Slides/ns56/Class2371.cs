using ns33;

namespace ns56;

internal class Class2371
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "manual", "ascending", "descending");

	public static Enum204 smethod_0(string xmlValue)
	{
		return (Enum204)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum204 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
