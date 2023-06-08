using ns33;

namespace ns56;

internal class Class2480
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "solid", "wireFrame", "boundingCube");

	public static Enum344 smethod_0(string xmlValue)
	{
		return (Enum344)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum344 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
