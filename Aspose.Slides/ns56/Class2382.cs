using ns33;

namespace ns56;

internal class Class2382
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "3Arrows", "3ArrowsGray", "3Flags", "3TrafficLights1", "3TrafficLights2", "3Signs", "3Symbols", "3Symbols2", "4Arrows", "4ArrowsGray", "4RedToBlack", "4Rating", "4TrafficLights", "5Arrows", "5ArrowsGray", "5Rating", "5Quarters");

	public static Enum215 smethod_0(string xmlValue)
	{
		return (Enum215)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum215 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
