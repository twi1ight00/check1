using System.Globalization;

namespace ns183;

internal class Class4985
{
	private static Class4985 class4985_0;

	private readonly CultureInfo cultureInfo_0;

	public CultureInfo Ci => cultureInfo_0;

	protected Class4985()
	{
		cultureInfo_0 = (CultureInfo)CultureInfo.CurrentCulture.Clone();
		cultureInfo_0.NumberFormat.CurrencyDecimalSeparator = ".";
	}

	public static Class4985 smethod_0()
	{
		if (class4985_0 == null)
		{
			class4985_0 = new Class4985();
		}
		return class4985_0;
	}
}
