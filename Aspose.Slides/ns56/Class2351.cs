using ns33;

namespace ns56;

internal class Class2351
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "manual", "auto", "autoNoTable");

	public static Enum185 smethod_0(string xmlValue)
	{
		return (Enum185)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum185 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
