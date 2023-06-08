using ns33;

namespace ns56;

internal class Class2426
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "sheet", "printArea", "autoFilter", "range", "chart", "pivotTable", "query", "label");

	public static Enum259 smethod_0(string xmlValue)
	{
		return (Enum259)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum259 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
