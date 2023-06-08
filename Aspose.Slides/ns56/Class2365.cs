using ns33;

namespace ns56;

internal class Class2365
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "whole", "decimal", "list", "date", "time", "textLength", "custom");

	public static Enum198 smethod_0(string xmlValue)
	{
		return (Enum198)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum198 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
