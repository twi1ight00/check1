using ns33;

namespace ns56;

internal class Class2413
{
	private static readonly Class1151 class1151_0 = new Class1151(1, "wholeTable", "headerRow", "totalRow", "firstColumn", "lastColumn", "firstRowStripe", "secondRowStripe", "firstColumnStripe", "secondColumnStripe", "firstHeaderCell", "lastHeaderCell", "firstTotalCell", "lastTotalCell", "firstSubtotalColumn", "secondSubtotalColumn", "thirdSubtotalColumn", "firstSubtotalRow", "secondSubtotalRow", "thirdSubtotalRow", "blankRow", "firstColumnSubheading", "secondColumnSubheading", "thirdColumnSubheading", "firstRowSubheading", "secondRowSubheading", "thirdRowSubheading", "pageFieldLabels", "pageFieldValues");

	public static Enum246 smethod_0(string xmlValue)
	{
		return (Enum246)class1151_0[xmlValue];
	}

	public static string smethod_1(Enum246 domValue)
	{
		return class1151_0[(int)domValue];
	}
}
