using ns33;
using ns57;

namespace ns56;

internal class Class2587
{
	private static readonly Class1151 class1151_0 = new Class1151("none", "base", "sum", "repl", "mult");

	public static Enum285 smethod_0(string xmlValue)
	{
		return (Enum285)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum285 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
