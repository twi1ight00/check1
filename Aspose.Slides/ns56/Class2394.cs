using ns33;

namespace ns56;

internal class Class2394
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "none", "solid", "mediumGray", "darkGray", "lightGray", "darkHorizontal", "darkVertical", "darkDown", "darkUp", "darkGrid", "darkTrellis", "lightHorizontal", "lightVertical", "lightDown", "lightUp", "lightGrid", "lightTrellis", "gray125", "gray0625");

	public static Enum227 smethod_0(string xmlValue)
	{
		return (Enum227)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum227 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
