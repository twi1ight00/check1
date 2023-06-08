using ns33;
using ns57;

namespace ns56;

internal class Class2596
{
	private static readonly Class1151 class1151_0 = new Class1151("entr", "exit", "emph", "path", "verb", "mediacall");

	public static Enum296 smethod_0(string xmlValue)
	{
		return (Enum296)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum296 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
