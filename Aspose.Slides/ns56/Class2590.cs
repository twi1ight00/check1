using ns33;
using ns57;

namespace ns56;

internal class Class2590
{
	private static readonly Class1151 class1151_0 = new Class1151("gridLegend", "series", "category", "ptInSeries", "ptInCategory");

	public static Enum295 smethod_0(string xmlValue)
	{
		return (Enum295)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum295 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
