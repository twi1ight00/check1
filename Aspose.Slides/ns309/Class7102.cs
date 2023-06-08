using System.Globalization;

namespace ns309;

internal class Class7102
{
	private CultureInfo cultureInfo_0;

	private CultureInfo cultureInfo_1;

	private NumberFormatInfo numberFormatInfo_0;

	private DateTimeFormatInfo dateTimeFormatInfo_0;

	private RegionInfo regionInfo_0;

	private StringInfo stringInfo_0;

	public Class7102()
	{
		cultureInfo_0 = CultureInfo.CurrentCulture;
		cultureInfo_1 = CultureInfo.CurrentUICulture;
		numberFormatInfo_0 = NumberFormatInfo.CurrentInfo;
		dateTimeFormatInfo_0 = new DateTimeFormatInfo();
		regionInfo_0 = new RegionInfo("US");
		stringInfo_0 = new StringInfo();
	}
}
