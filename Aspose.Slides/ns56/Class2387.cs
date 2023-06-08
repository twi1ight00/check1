using ns33;

namespace ns56;

internal class Class2387
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "all", "placeholders", "none");

	public static Enum220 smethod_0(string xmlValue)
	{
		return (Enum220)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum220 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
