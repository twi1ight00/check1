using System.Globalization;
using Aspose.Cells;
using ns14;

namespace ns22;

internal class Class1023
{
	internal static CultureInfo smethod_0(CountryCode countryCode_0)
	{
		try
		{
			short num = Class519.smethod_3(countryCode_0);
			if (num != 0)
			{
				return Class519.smethod_5(num);
			}
		}
		catch
		{
		}
		return CultureInfo.InvariantCulture;
	}
}
