using ns33;
using ns57;

namespace ns56;

internal class Class2579
{
	private static readonly Class1151 class1151_0 = new Class1151("discrete", "lin", "fmla");

	public static Enum278 smethod_0(string xmlValue)
	{
		return (Enum278)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum278 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
