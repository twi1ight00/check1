using ns33;

namespace ns56;

internal class Class2388
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "OLEUPDATE_ALWAYS", "OLEUPDATE_ONCALL");

	public static Enum221 smethod_0(string xmlValue)
	{
		return (Enum221)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum221 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
