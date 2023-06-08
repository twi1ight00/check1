using ns33;
using ns57;

namespace ns56;

internal class Class2594
{
	private static readonly Class1151 class1151_0 = new Class1151("remove", "freeze", "hold", "transition");

	public static Enum289 smethod_0(string xmlValue)
	{
		return (Enum289)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum289 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
