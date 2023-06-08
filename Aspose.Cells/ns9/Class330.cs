using System;
using System.Collections.Generic;
using Aspose.Cells;
using ns1;

namespace ns9;

internal class Class330 : Class316
{
	internal Class330(MultipleFilterCollection multipleFilterCollection_0)
	{
		int_0 = 165;
		byte_0 = new byte[8];
		if (multipleFilterCollection_0.MatchBlank)
		{
			byte_0[0] = 1;
		}
		if (multipleFilterCollection_0.string_0 != null)
		{
			Array.Copy(BitConverter.GetBytes(smethod_0(multipleFilterCollection_0.string_0)), 0, byte_0, 4, 4);
		}
	}

	internal static int smethod_0(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_55 == null)
			{
				Class1742.dictionary_55 = new Dictionary<string, int>(12)
				{
					{ "gregorian", 0 },
					{ "gregorianUs", 1 },
					{ "japan", 2 },
					{ "taiwan", 3 },
					{ "korea", 4 },
					{ "hijri", 5 },
					{ "thai", 6 },
					{ "hebrew", 7 },
					{ "gregorianMeFrench", 8 },
					{ "gregorianArabic", 9 },
					{ "gregorianXlitEnglish", 10 },
					{ "gregorianXlitFrench", 11 }
				};
			}
			if (Class1742.dictionary_55.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return 1;
				case 1:
					return 2;
				case 2:
					return 3;
				case 3:
					return 4;
				case 4:
					return 5;
				case 5:
					return 6;
				case 6:
					return 7;
				case 7:
					return 8;
				case 8:
					return 9;
				case 9:
					return 10;
				case 10:
					return 11;
				case 11:
					return 12;
				}
			}
		}
		return 0;
	}
}
