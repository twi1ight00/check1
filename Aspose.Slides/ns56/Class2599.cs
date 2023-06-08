using ns33;
using ns57;

namespace ns56;

internal class Class2599
{
	private static readonly Class1151 class1151_0 = new Class1151("clickEffect", "withEffect", "afterEffect", "mainSeq", "interactiveSeq", "clickPar", "withGroup", "afterGroup", "tmRoot");

	public static Enum303 smethod_0(string xmlValue)
	{
		return (Enum303)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum303 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
