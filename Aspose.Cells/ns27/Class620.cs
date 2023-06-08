using System;
using System.Collections.Generic;
using System.Globalization;
using Aspose.Cells;
using ns1;

namespace ns27;

internal class Class620 : Class538
{
	public Class620(CountryCode countryCode_0, CountryCode countryCode_1)
	{
		method_2(140);
		method_0(4);
		byte_0 = new byte[4];
		CultureInfo cultureInfo = null;
		ushort value;
		if (countryCode_0 == CountryCode.Default)
		{
			cultureInfo = CultureInfo.CurrentCulture;
			value = method_5(cultureInfo);
		}
		else
		{
			value = (ushort)countryCode_0;
		}
		Array.Copy(BitConverter.GetBytes(value), byte_0, 2);
		if (countryCode_1 == CountryCode.Default)
		{
			if (cultureInfo == null)
			{
				cultureInfo = CultureInfo.CurrentCulture;
			}
			value = method_4(RegionInfo.CurrentRegion, cultureInfo);
		}
		else
		{
			value = (ushort)countryCode_1;
		}
		Array.Copy(BitConverter.GetBytes(value), 0, byte_0, 2, 2);
	}

	private ushort method_4(RegionInfo regionInfo_0, CultureInfo cultureInfo_0)
	{
		try
		{
			string threeLetterISORegionName;
			if ((threeLetterISORegionName = regionInfo_0.ThreeLetterISORegionName) != null && threeLetterISORegionName == "BEL")
			{
				return 32;
			}
			return method_5(cultureInfo_0);
		}
		catch
		{
			return method_5(cultureInfo_0);
		}
	}

	private ushort method_5(CultureInfo cultureInfo_0)
	{
		string threeLetterISOLanguageName;
		if ((threeLetterISOLanguageName = cultureInfo_0.ThreeLetterISOLanguageName) != null)
		{
			if (Class1742.dictionary_226 == null)
			{
				Class1742.dictionary_226 = new Dictionary<string, int>(6)
				{
					{ "spa", 0 },
					{ "deu", 1 },
					{ "fra", 2 },
					{ "fre", 3 },
					{ "frm", 4 },
					{ "fro", 5 }
				};
			}
			if (Class1742.dictionary_226.TryGetValue(threeLetterISOLanguageName, out var value))
			{
				switch (value)
				{
				case 0:
					return 34;
				case 1:
					return 49;
				case 2:
				case 3:
				case 4:
				case 5:
					return 33;
				}
			}
		}
		return 1;
	}
}
