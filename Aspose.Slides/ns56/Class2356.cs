using ns33;

namespace ns56;

internal class Class2356
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "expression", "cellIs", "colorScale", "dataBar", "iconSet", "top10", "uniqueValues", "duplicateValues", "containsText", "notContainsText", "beginsWith", "endsWith", "containsBlanks", "notContainsBlanks", "containsErrors", "notContainsErrors", "timePeriod", "aboveAverage");

	public static Enum189 smethod_0(string xmlValue)
	{
		return (Enum189)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum189 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
