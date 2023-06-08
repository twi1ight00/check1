using ns33;

namespace ns56;

internal class Class2493
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "whole", "depthByNode", "depthByBranch", "breadthByNode", "breadthByLvl", "cw", "cwIn", "cwOut", "ccw", "ccwIn", "ccwOut", "inByRing", "outByRing", "up", "down", "allAtOnce", "cust");

	public static Enum357 smethod_0(string xmlValue)
	{
		return (Enum357)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum357 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
