using ns33;

namespace ns56;

internal class Class2391
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "bottomRight", "topRight", "bottomLeft", "topLeft");

	public static Enum224 smethod_0(string xmlValue)
	{
		return (Enum224)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum224 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
