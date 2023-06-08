using ns33;

namespace ns56;

internal class Class2378
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "range", "seconds", "minutes", "hours", "days", "months", "quarters", "years");

	public static Enum211 smethod_0(string xmlValue)
	{
		return (Enum211)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum211 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
