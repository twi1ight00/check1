using System.Collections.Generic;
using Aspose.Cells.Tables;
using ns1;

namespace ns58;

internal class Class1736
{
	internal static string smethod_0(TableStyleType tableStyleType_0)
	{
		return tableStyleType_0 switch
		{
			TableStyleType.None => "None", 
			TableStyleType.TableStyleLight1 => "TableStyleLight1", 
			TableStyleType.TableStyleLight2 => "TableStyleLight2", 
			TableStyleType.TableStyleLight3 => "TableStyleLight3", 
			TableStyleType.TableStyleLight4 => "TableStyleLight4", 
			TableStyleType.TableStyleLight5 => "TableStyleLight5", 
			TableStyleType.TableStyleLight6 => "TableStyleLight6", 
			TableStyleType.TableStyleLight7 => "TableStyleLight7", 
			TableStyleType.TableStyleLight8 => "TableStyleLight8", 
			TableStyleType.TableStyleLight9 => "TableStyleLight9", 
			TableStyleType.TableStyleLight10 => "TableStyleLight10", 
			TableStyleType.TableStyleLight11 => "TableStyleLight11", 
			TableStyleType.TableStyleLight12 => "TableStyleLight12", 
			TableStyleType.TableStyleLight13 => "TableStyleLight13", 
			TableStyleType.TableStyleLight14 => "TableStyleLight14", 
			TableStyleType.TableStyleLight15 => "TableStyleLight15", 
			TableStyleType.TableStyleLight16 => "TableStyleLight16", 
			TableStyleType.TableStyleLight17 => "TableStyleLight17", 
			TableStyleType.TableStyleLight18 => "TableStyleLight18", 
			TableStyleType.TableStyleLight19 => "TableStyleLight19", 
			TableStyleType.TableStyleLight20 => "TableStyleLight20", 
			TableStyleType.TableStyleLight21 => "TableStyleLight21", 
			TableStyleType.TableStyleMedium1 => "TableStyleMedium1", 
			TableStyleType.TableStyleMedium2 => "TableStyleMedium2", 
			TableStyleType.TableStyleMedium3 => "TableStyleMedium3", 
			TableStyleType.TableStyleMedium4 => "TableStyleMedium4", 
			TableStyleType.TableStyleMedium5 => "TableStyleMedium5", 
			TableStyleType.TableStyleMedium6 => "TableStyleMedium6", 
			TableStyleType.TableStyleMedium7 => "TableStyleMedium7", 
			TableStyleType.TableStyleMedium8 => "TableStyleMedium8", 
			TableStyleType.TableStyleMedium9 => "TableStyleMedium9", 
			TableStyleType.TableStyleMedium10 => "TableStyleMedium10", 
			TableStyleType.TableStyleMedium11 => "TableStyleMedium11", 
			TableStyleType.TableStyleMedium12 => "TableStyleMedium12", 
			TableStyleType.TableStyleMedium13 => "TableStyleMedium13", 
			TableStyleType.TableStyleMedium14 => "TableStyleMedium14", 
			TableStyleType.TableStyleMedium15 => "TableStyleMedium15", 
			TableStyleType.TableStyleMedium16 => "TableStyleMedium16", 
			TableStyleType.TableStyleMedium17 => "TableStyleMedium17", 
			TableStyleType.TableStyleMedium18 => "TableStyleMedium18", 
			TableStyleType.TableStyleMedium19 => "TableStyleMedium19", 
			TableStyleType.TableStyleMedium20 => "TableStyleMedium20", 
			TableStyleType.TableStyleMedium21 => "TableStyleMedium21", 
			TableStyleType.TableStyleMedium22 => "TableStyleMedium22", 
			TableStyleType.TableStyleMedium23 => "TableStyleMedium23", 
			TableStyleType.TableStyleMedium24 => "TableStyleMedium24", 
			TableStyleType.TableStyleMedium25 => "TableStyleMedium25", 
			TableStyleType.TableStyleMedium26 => "TableStyleMedium26", 
			TableStyleType.TableStyleMedium27 => "TableStyleMedium27", 
			TableStyleType.TableStyleMedium28 => "TableStyleMedium28", 
			TableStyleType.TableStyleDark1 => "TableStyleDark1", 
			TableStyleType.TableStyleDark2 => "TableStyleDark2", 
			TableStyleType.TableStyleDark3 => "TableStyleDark3", 
			TableStyleType.TableStyleDark4 => "TableStyleDark4", 
			TableStyleType.TableStyleDark5 => "TableStyleDark5", 
			TableStyleType.TableStyleDark6 => "TableStyleDark6", 
			TableStyleType.TableStyleDark7 => "TableStyleDark7", 
			TableStyleType.TableStyleDark8 => "TableStyleDark8", 
			TableStyleType.TableStyleDark9 => "TableStyleDark9", 
			TableStyleType.TableStyleDark10 => "TableStyleDark10", 
			TableStyleType.TableStyleDark11 => "TableStyleDark11", 
			TableStyleType.Custom => "Custom", 
			_ => "Custom", 
		};
	}

	internal static TableStyleType smethod_1(string string_0)
	{
		string key;
		if ((key = string_0) != null)
		{
			if (Class1742.dictionary_229 == null)
			{
				Class1742.dictionary_229 = new Dictionary<string, int>(62)
				{
					{ "None", 0 },
					{ "TableStyleLight1", 1 },
					{ "TableStyleLight2", 2 },
					{ "TableStyleLight3", 3 },
					{ "TableStyleLight4", 4 },
					{ "TableStyleLight5", 5 },
					{ "TableStyleLight6", 6 },
					{ "TableStyleLight7", 7 },
					{ "TableStyleLight8", 8 },
					{ "TableStyleLight9", 9 },
					{ "TableStyleLight10", 10 },
					{ "TableStyleLight11", 11 },
					{ "TableStyleLight12", 12 },
					{ "TableStyleLight13", 13 },
					{ "TableStyleLight14", 14 },
					{ "TableStyleLight15", 15 },
					{ "TableStyleLight16", 16 },
					{ "TableStyleLight17", 17 },
					{ "TableStyleLight18", 18 },
					{ "TableStyleLight19", 19 },
					{ "TableStyleLight20", 20 },
					{ "TableStyleLight21", 21 },
					{ "TableStyleMedium1", 22 },
					{ "TableStyleMedium2", 23 },
					{ "TableStyleMedium3", 24 },
					{ "TableStyleMedium4", 25 },
					{ "TableStyleMedium5", 26 },
					{ "TableStyleMedium6", 27 },
					{ "TableStyleMedium7", 28 },
					{ "TableStyleMedium8", 29 },
					{ "TableStyleMedium9", 30 },
					{ "TableStyleMedium10", 31 },
					{ "TableStyleMedium11", 32 },
					{ "TableStyleMedium12", 33 },
					{ "TableStyleMedium13", 34 },
					{ "TableStyleMedium14", 35 },
					{ "TableStyleMedium15", 36 },
					{ "TableStyleMedium16", 37 },
					{ "TableStyleMedium17", 38 },
					{ "TableStyleMedium18", 39 },
					{ "TableStyleMedium19", 40 },
					{ "TableStyleMedium20", 41 },
					{ "TableStyleMedium21", 42 },
					{ "TableStyleMedium22", 43 },
					{ "TableStyleMedium23", 44 },
					{ "TableStyleMedium24", 45 },
					{ "TableStyleMedium25", 46 },
					{ "TableStyleMedium26", 47 },
					{ "TableStyleMedium27", 48 },
					{ "TableStyleMedium28", 49 },
					{ "TableStyleDark1", 50 },
					{ "TableStyleDark2", 51 },
					{ "TableStyleDark3", 52 },
					{ "TableStyleDark4", 53 },
					{ "TableStyleDark5", 54 },
					{ "TableStyleDark6", 55 },
					{ "TableStyleDark7", 56 },
					{ "TableStyleDark8", 57 },
					{ "TableStyleDark9", 58 },
					{ "TableStyleDark10", 59 },
					{ "TableStyleDark11", 60 },
					{ "Custom", 61 }
				};
			}
			if (Class1742.dictionary_229.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
					return TableStyleType.None;
				case 1:
					return TableStyleType.TableStyleLight1;
				case 2:
					return TableStyleType.TableStyleLight2;
				case 3:
					return TableStyleType.TableStyleLight3;
				case 4:
					return TableStyleType.TableStyleLight4;
				case 5:
					return TableStyleType.TableStyleLight5;
				case 6:
					return TableStyleType.TableStyleLight6;
				case 7:
					return TableStyleType.TableStyleLight7;
				case 8:
					return TableStyleType.TableStyleLight8;
				case 9:
					return TableStyleType.TableStyleLight9;
				case 10:
					return TableStyleType.TableStyleLight10;
				case 11:
					return TableStyleType.TableStyleLight11;
				case 12:
					return TableStyleType.TableStyleLight12;
				case 13:
					return TableStyleType.TableStyleLight13;
				case 14:
					return TableStyleType.TableStyleLight14;
				case 15:
					return TableStyleType.TableStyleLight15;
				case 16:
					return TableStyleType.TableStyleLight16;
				case 17:
					return TableStyleType.TableStyleLight17;
				case 18:
					return TableStyleType.TableStyleLight18;
				case 19:
					return TableStyleType.TableStyleLight19;
				case 20:
					return TableStyleType.TableStyleLight20;
				case 21:
					return TableStyleType.TableStyleLight21;
				case 22:
					return TableStyleType.TableStyleMedium1;
				case 23:
					return TableStyleType.TableStyleMedium2;
				case 24:
					return TableStyleType.TableStyleMedium3;
				case 25:
					return TableStyleType.TableStyleMedium4;
				case 26:
					return TableStyleType.TableStyleMedium5;
				case 27:
					return TableStyleType.TableStyleMedium6;
				case 28:
					return TableStyleType.TableStyleMedium7;
				case 29:
					return TableStyleType.TableStyleMedium8;
				case 30:
					return TableStyleType.TableStyleMedium9;
				case 31:
					return TableStyleType.TableStyleMedium10;
				case 32:
					return TableStyleType.TableStyleMedium11;
				case 33:
					return TableStyleType.TableStyleMedium12;
				case 34:
					return TableStyleType.TableStyleMedium13;
				case 35:
					return TableStyleType.TableStyleMedium14;
				case 36:
					return TableStyleType.TableStyleMedium15;
				case 37:
					return TableStyleType.TableStyleMedium16;
				case 38:
					return TableStyleType.TableStyleMedium17;
				case 39:
					return TableStyleType.TableStyleMedium18;
				case 40:
					return TableStyleType.TableStyleMedium19;
				case 41:
					return TableStyleType.TableStyleMedium20;
				case 42:
					return TableStyleType.TableStyleMedium21;
				case 43:
					return TableStyleType.TableStyleMedium22;
				case 44:
					return TableStyleType.TableStyleMedium23;
				case 45:
					return TableStyleType.TableStyleMedium24;
				case 46:
					return TableStyleType.TableStyleMedium25;
				case 47:
					return TableStyleType.TableStyleMedium26;
				case 48:
					return TableStyleType.TableStyleMedium27;
				case 49:
					return TableStyleType.TableStyleMedium28;
				case 50:
					return TableStyleType.TableStyleDark1;
				case 51:
					return TableStyleType.TableStyleDark2;
				case 52:
					return TableStyleType.TableStyleDark3;
				case 53:
					return TableStyleType.TableStyleDark4;
				case 54:
					return TableStyleType.TableStyleDark5;
				case 55:
					return TableStyleType.TableStyleDark6;
				case 56:
					return TableStyleType.TableStyleDark7;
				case 57:
					return TableStyleType.TableStyleDark8;
				case 58:
					return TableStyleType.TableStyleDark9;
				case 59:
					return TableStyleType.TableStyleDark10;
				case 60:
					return TableStyleType.TableStyleDark11;
				case 61:
					return TableStyleType.Custom;
				}
			}
		}
		return TableStyleType.Custom;
	}
}
