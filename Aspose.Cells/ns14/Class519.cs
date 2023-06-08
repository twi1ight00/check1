using System.Globalization;
using Aspose.Cells;

namespace ns14;

internal class Class519
{
	public static bool smethod_0(int int_0)
	{
		switch (int_0)
		{
		default:
			return false;
		case 9:
		case 1033:
		case 2057:
		case 3081:
		case 4105:
		case 5129:
		case 6153:
		case 7177:
		case 8201:
		case 9225:
		case 10249:
		case 11273:
		case 12297:
		case 13321:
			return true;
		}
	}

	public static bool smethod_1(int int_0)
	{
		switch (int_0)
		{
		default:
			return false;
		case 4:
		case 17:
		case 18:
		case 1028:
		case 1041:
		case 1042:
		case 2052:
		case 3076:
		case 4100:
		case 5124:
		case 31748:
			return true;
		}
	}

	public static bool smethod_2(short short_0, short short_1)
	{
		return (short_0 & 0xFF) == (short_1 & 0xFF);
	}

	public static short smethod_3(CountryCode countryCode_0)
	{
		return countryCode_0 switch
		{
			CountryCode.Brazil => 1046, 
			CountryCode.Egypt => 3073, 
			CountryCode.Greece => 1032, 
			CountryCode.Netherlands => 1043, 
			CountryCode.Belgium => 2067, 
			CountryCode.France => 1036, 
			CountryCode.Spain => 3082, 
			CountryCode.Hungary => 1038, 
			CountryCode.Italy => 1040, 
			CountryCode.Switzerland => 2055, 
			CountryCode.Austria => 3079, 
			CountryCode.UnitedKingdom => 2057, 
			CountryCode.Denmark => 1030, 
			CountryCode.Sweden => 1053, 
			CountryCode.Norway => 1044, 
			CountryCode.Poland => 1045, 
			CountryCode.Germany => 1031, 
			CountryCode.Mexico => 2058, 
			CountryCode.USA => 1033, 
			CountryCode.Canada => 4105, 
			CountryCode.LatinAmeric => 1033, 
			CountryCode.Russia => 1049, 
			CountryCode.NewZealand => 5129, 
			CountryCode.Thailand => 1054, 
			CountryCode.Australia => 3081, 
			CountryCode.Algeria => 5121, 
			CountryCode.Japan => 1041, 
			CountryCode.SouthKorea => 1042, 
			CountryCode.VietNam => 1066, 
			CountryCode.China => 2052, 
			CountryCode.Turkey => 1055, 
			CountryCode.India => 16393, 
			CountryCode.Portugal => 2070, 
			CountryCode.Morocco => 6145, 
			CountryCode.Libya => 4097, 
			CountryCode.Finland => 1035, 
			CountryCode.Iceland => 1039, 
			CountryCode.Taiwan => 1028, 
			CountryCode.Czech => 1029, 
			CountryCode.Iran => 1065, 
			CountryCode.Lebanon => 12289, 
			CountryCode.Jordan => 11265, 
			CountryCode.Syria => 10241, 
			CountryCode.Iraq => 2049, 
			CountryCode.Kuwait => 13313, 
			CountryCode.Saudi => 1025, 
			CountryCode.UnitedArabEmirates => 14337, 
			CountryCode.Israel => 1037, 
			CountryCode.Qatar => 16385, 
			_ => 0, 
		};
	}

	public static CountryCode smethod_4(short short_0)
	{
		return short_0 switch
		{
			2049 => CountryCode.Iraq, 
			1025 => CountryCode.Saudi, 
			1028 => CountryCode.Taiwan, 
			1029 => CountryCode.Czech, 
			1030 => CountryCode.Denmark, 
			1031 => CountryCode.Germany, 
			1032 => CountryCode.Greece, 
			1033 => CountryCode.USA, 
			1035 => CountryCode.Finland, 
			1036 => CountryCode.France, 
			1037 => CountryCode.Israel, 
			1038 => CountryCode.Hungary, 
			1039 => CountryCode.Iceland, 
			1040 => CountryCode.Italy, 
			1041 => CountryCode.Japan, 
			1042 => CountryCode.SouthKorea, 
			1043 => CountryCode.Netherlands, 
			1044 => CountryCode.Norway, 
			1045 => CountryCode.Poland, 
			1046 => CountryCode.Brazil, 
			1049 => CountryCode.Russia, 
			1053 => CountryCode.Sweden, 
			1054 => CountryCode.Thailand, 
			1055 => CountryCode.Turkey, 
			1065 => CountryCode.Iran, 
			1066 => CountryCode.VietNam, 
			2067 => CountryCode.Belgium, 
			2052 => CountryCode.China, 
			2055 => CountryCode.Switzerland, 
			2057 => CountryCode.UnitedKingdom, 
			2058 => CountryCode.Mexico, 
			3073 => CountryCode.Egypt, 
			2070 => CountryCode.Portugal, 
			4105 => CountryCode.Canada, 
			4097 => CountryCode.Libya, 
			3079 => CountryCode.Austria, 
			3081 => CountryCode.Australia, 
			3082 => CountryCode.Spain, 
			5129 => CountryCode.NewZealand, 
			5121 => CountryCode.Algeria, 
			11265 => CountryCode.Jordan, 
			10241 => CountryCode.Syria, 
			6145 => CountryCode.Morocco, 
			13313 => CountryCode.Kuwait, 
			12289 => CountryCode.Lebanon, 
			16393 => CountryCode.India, 
			16385 => CountryCode.Qatar, 
			14337 => CountryCode.UnitedArabEmirates, 
			_ => CountryCode.Default, 
		};
	}

	public static CultureInfo smethod_5(short short_0)
	{
		return new CultureInfo(short_0 & 0xFFFF, useUserOverride: true);
	}

	public static short smethod_6(CultureInfo cultureInfo_0)
	{
		string[] array = cultureInfo_0.Name.Split('-');
		return smethod_7(array[0], (array.Length > 1) ? array[1] : null, (array.Length > 2) ? array[2] : null);
	}

	public static short smethod_7(string string_0, string string_1, string string_2)
	{
		if (string_1 != null && !string_1.Equals(""))
		{
			string_1 = string_1.ToUpper();
			if (string_1.Equals("AE"))
			{
				return 14337;
			}
			if (string_1.Equals("AL"))
			{
				return 1052;
			}
			if (string_1.Equals("AM"))
			{
				return 1067;
			}
			if (string_1.Equals("AR"))
			{
				return 11274;
			}
			if (string_1.Equals("AT"))
			{
				return 3079;
			}
			if (string_1.Equals("AU"))
			{
				return 3081;
			}
			if (string_1.Equals("AZ"))
			{
				if (string_2 != null && string_2.ToLower().Equals("cyrl"))
				{
					return 2092;
				}
				return 1068;
			}
			if (string_1.Equals("BE"))
			{
				if (string_0 != null && string_0.ToLower().Equals("fr"))
				{
					return 2060;
				}
				return 2067;
			}
			if (string_1.Equals("BG"))
			{
				return 1026;
			}
			if (string_1.Equals("BH"))
			{
				return 15361;
			}
			if (string_1.Equals("BN"))
			{
				return 2110;
			}
			if (string_1.Equals("BO"))
			{
				return 16394;
			}
			if (string_1.Equals("BR"))
			{
				return 1046;
			}
			if (string_1.Equals("BY"))
			{
				return 1059;
			}
			if (string_1.Equals("BZ"))
			{
				return 10249;
			}
			if (string_1.Equals("CA"))
			{
				if (string_0 != null && string_0.ToLower().Equals("fr"))
				{
					return 3084;
				}
				return 4105;
			}
			if (string_1.Equals("CB"))
			{
				return 9225;
			}
			if (string_1.Equals("CH"))
			{
				if (string_0 != null)
				{
					string_0 = string_0.ToLower();
					if (string_0.Equals("fr"))
					{
						return 4108;
					}
					if (string_0.Equals("it"))
					{
						return 2064;
					}
				}
				return 2055;
			}
			if (string_1.Equals("CHS"))
			{
				return 4;
			}
			if (string_1.Equals("CHT"))
			{
				return 31748;
			}
			if (string_1.Equals("CL"))
			{
				return 13322;
			}
			if (string_1.Equals("CN"))
			{
				return 2052;
			}
			if (string_1.Equals("CO"))
			{
				return 9226;
			}
			if (string_1.Equals("CR"))
			{
				return 5130;
			}
			if (string_1.Equals("CZ"))
			{
				return 1029;
			}
			if (string_1.Equals("DE"))
			{
				return 1031;
			}
			if (string_1.Equals("DK"))
			{
				return 1030;
			}
			if (string_1.Equals("DO"))
			{
				return 7178;
			}
			if (string_1.Equals("DZ"))
			{
				return 5121;
			}
			if (string_1.Equals("EC"))
			{
				return 12298;
			}
			if (string_1.Equals("EE"))
			{
				return 1061;
			}
			if (string_1.Equals("EG"))
			{
				return 3073;
			}
			if (string_1.Equals("ES"))
			{
				if (string_0 != null)
				{
					string_0 = string_0.ToLower();
					if (string_0.Equals("ca"))
					{
						return 1027;
					}
					if (string_0.Equals("eu"))
					{
						return 1069;
					}
					if (string_0.Equals("gl"))
					{
						return 1110;
					}
				}
				return 3082;
			}
			if (string_1.Equals("FI"))
			{
				if (string_0 != null && string_0.ToLower().Equals("sv"))
				{
					return 2077;
				}
				return 1035;
			}
			if (string_1.Equals("FO"))
			{
				return 1080;
			}
			if (string_1.Equals("FR"))
			{
				return 1036;
			}
			if (string_1.Equals("GB"))
			{
				return 2057;
			}
			if (string_1.Equals("GE"))
			{
				return 1079;
			}
			if (string_1.Equals("GR"))
			{
				return 1032;
			}
			if (string_1.Equals("GT"))
			{
				return 4106;
			}
			if (string_1.Equals("HK"))
			{
				return 3076;
			}
			if (string_1.Equals("HN"))
			{
				return 18442;
			}
			if (string_1.Equals("HR"))
			{
				return 1050;
			}
			if (string_1.Equals("HU"))
			{
				return 1038;
			}
			if (string_1.Equals("ID"))
			{
				return 1057;
			}
			if (string_1.Equals("IE"))
			{
				return 6153;
			}
			if (string_1.Equals("IL"))
			{
				return 1037;
			}
			if (string_1.Equals("IN"))
			{
				if (string_0 != null)
				{
					string_0 = string_0.ToLower();
					if (string_0.Equals("gu"))
					{
						return 1095;
					}
					if (string_0.Equals("hi"))
					{
						return 1081;
					}
					if (string_0.Equals("kn"))
					{
						return 1099;
					}
					if (string_0.Equals("kok"))
					{
						return 1111;
					}
					if (string_0.Equals("mr"))
					{
						return 1102;
					}
					if (string_0.Equals("pa"))
					{
						return 1094;
					}
					if (string_0.Equals("sa"))
					{
						return 1103;
					}
					if (string_0.Equals("ta"))
					{
						return 1097;
					}
					if (string_0.Equals("te"))
					{
						return 1098;
					}
				}
				return 16393;
			}
			if (string_1.Equals("IN"))
			{
				return 1095;
			}
			if (string_1.Equals("IN"))
			{
				return 1081;
			}
			if (string_1.Equals("IN"))
			{
				return 1099;
			}
			if (string_1.Equals("IN"))
			{
				return 1111;
			}
			if (string_1.Equals("IN"))
			{
				return 1102;
			}
			if (string_1.Equals("IN"))
			{
				return 1094;
			}
			if (string_1.Equals("IN"))
			{
				return 1103;
			}
			if (string_1.Equals("IN"))
			{
				return 1097;
			}
			if (string_1.Equals("IN"))
			{
				return 1098;
			}
			if (string_1.Equals("IQ"))
			{
				return 2049;
			}
			if (string_1.Equals("IR"))
			{
				return 1065;
			}
			if (string_1.Equals("IS"))
			{
				return 1039;
			}
			if (string_1.Equals("IT"))
			{
				return 1040;
			}
			if (string_1.Equals("JM"))
			{
				return 8201;
			}
			if (string_1.Equals("JO"))
			{
				return 11265;
			}
			if (string_1.Equals("JP"))
			{
				return 1041;
			}
			if (string_1.Equals("KE"))
			{
				return 1089;
			}
			if (string_1.Equals("KG"))
			{
				return 1088;
			}
			if (string_1.Equals("KR"))
			{
				return 1042;
			}
			if (string_1.Equals("KW"))
			{
				return 13313;
			}
			if (string_1.Equals("KZ"))
			{
				return 1087;
			}
			if (string_1.Equals("LB"))
			{
				return 12289;
			}
			if (string_1.Equals("LI"))
			{
				return 5127;
			}
			if (string_1.Equals("LT"))
			{
				return 1063;
			}
			if (string_1.Equals("LU"))
			{
				if (string_0 != null && string_0.ToLower().Equals("fr"))
				{
					return 5132;
				}
				return 4103;
			}
			if (string_1.Equals("LV"))
			{
				return 1062;
			}
			if (string_1.Equals("LY"))
			{
				return 4097;
			}
			if (string_1.Equals("MA"))
			{
				return 6145;
			}
			if (string_1.Equals("MC"))
			{
				return 6156;
			}
			if (string_1.Equals("MK"))
			{
				return 1071;
			}
			if (string_1.Equals("MN"))
			{
				return 1104;
			}
			if (string_1.Equals("MO"))
			{
				return 5124;
			}
			if (string_1.Equals("MV"))
			{
				return 1125;
			}
			if (string_1.Equals("MX"))
			{
				return 2058;
			}
			if (string_1.Equals("MY"))
			{
				return 1086;
			}
			if (string_1.Equals("NI"))
			{
				return 19466;
			}
			if (string_1.Equals("NL"))
			{
				return 1043;
			}
			if (string_1.Equals("NO"))
			{
				if (string_0 != null && string_0.ToLower().Equals("nn"))
				{
					return 2068;
				}
				return 1044;
			}
			if (string_1.Equals("NZ"))
			{
				return 5129;
			}
			if (string_1.Equals("OM"))
			{
				return 8193;
			}
			if (string_1.Equals("PA"))
			{
				return 6154;
			}
			if (string_1.Equals("PE"))
			{
				return 10250;
			}
			if (string_1.Equals("PH"))
			{
				return 13321;
			}
			if (string_1.Equals("PK"))
			{
				return 1056;
			}
			if (string_1.Equals("PL"))
			{
				return 1045;
			}
			if (string_1.Equals("PR"))
			{
				return 20490;
			}
			if (string_1.Equals("PT"))
			{
				return 2070;
			}
			if (string_1.Equals("PY"))
			{
				return 15370;
			}
			if (string_1.Equals("QA"))
			{
				return 16385;
			}
			if (string_1.Equals("RO"))
			{
				return 1048;
			}
			if (string_1.Equals("RU"))
			{
				if (string_0 != null && string_0.ToLower().Equals("tt"))
				{
					return 1092;
				}
				return 1049;
			}
			if (string_1.Equals("SA"))
			{
				return 1025;
			}
			if (string_1.Equals("SE"))
			{
				return 1053;
			}
			if (string_1.Equals("SG"))
			{
				return 4100;
			}
			if (string_1.Equals("SI"))
			{
				return 1060;
			}
			if (string_1.Equals("SK"))
			{
				return 1051;
			}
			if (string_1.Equals("SP"))
			{
				if (string_2 != null && string_2.ToLower().Equals("cyrl"))
				{
					return 3098;
				}
				return 2074;
			}
			if (string_1.Equals("SV"))
			{
				return 17418;
			}
			if (string_1.Equals("SY"))
			{
				if (string_0 != null && string_0.ToLower().Equals("ar"))
				{
					return 10241;
				}
				return 1114;
			}
			if (string_1.Equals("TH"))
			{
				return 1054;
			}
			if (string_1.Equals("TN"))
			{
				return 7169;
			}
			if (string_1.Equals("TR"))
			{
				return 1055;
			}
			if (string_1.Equals("TT"))
			{
				return 11273;
			}
			if (string_1.Equals("TW"))
			{
				return 1028;
			}
			if (string_1.Equals("UA"))
			{
				return 1058;
			}
			if (string_1.Equals("US"))
			{
				return 1033;
			}
			if (string_1.Equals("UY"))
			{
				return 14346;
			}
			if (string_1.Equals("UZ"))
			{
				if (string_2 != null && string_2.ToLower().Equals("cyrl"))
				{
					return 2115;
				}
				return 1091;
			}
			if (string_1.Equals("VE"))
			{
				return 8202;
			}
			if (string_1.Equals("VN"))
			{
				return 1066;
			}
			if (string_1.Equals("YE"))
			{
				return 9217;
			}
			if (string_1.Equals("ZA"))
			{
				if (string_0 != null && string_0.ToLower().Equals("af"))
				{
					return 1078;
				}
				return 7177;
			}
			if (string_1.Equals("ZW"))
			{
				return 12297;
			}
		}
		if (string_0 != null && !string_0.Equals(""))
		{
			string_0 = string_0.ToLower();
			if (string_0.Equals("af"))
			{
				return 54;
			}
			if (string_0.Equals("ar"))
			{
				return 1;
			}
			if (string_0.Equals("az"))
			{
				return 44;
			}
			if (string_0.Equals("be"))
			{
				return 35;
			}
			if (string_0.Equals("bg"))
			{
				return 2;
			}
			if (string_0.Equals("ca"))
			{
				return 3;
			}
			if (string_0.Equals("cs"))
			{
				return 5;
			}
			if (string_0.Equals("da"))
			{
				return 6;
			}
			if (string_0.Equals("de"))
			{
				return 7;
			}
			if (string_0.Equals("div"))
			{
				return 101;
			}
			if (string_0.Equals("el"))
			{
				return 8;
			}
			if (string_0.Equals("en"))
			{
				return 9;
			}
			if (string_0.Equals("es"))
			{
				return 10;
			}
			if (string_0.Equals("et"))
			{
				return 37;
			}
			if (string_0.Equals("eu"))
			{
				return 45;
			}
			if (string_0.Equals("fo"))
			{
				return 56;
			}
			if (string_0.Equals("fa"))
			{
				return 41;
			}
			if (string_0.Equals("fi"))
			{
				return 11;
			}
			if (string_0.Equals("fr"))
			{
				return 12;
			}
			if (string_0.Equals("gl"))
			{
				return 86;
			}
			if (string_0.Equals("gu"))
			{
				return 71;
			}
			if (string_0.Equals("he"))
			{
				return 13;
			}
			if (string_0.Equals("hi"))
			{
				return 57;
			}
			if (string_0.Equals("hr"))
			{
				return 26;
			}
			if (string_0.Equals("hu"))
			{
				return 14;
			}
			if (string_0.Equals("hy"))
			{
				return 43;
			}
			if (string_0.Equals("id"))
			{
				return 33;
			}
			if (string_0.Equals("is"))
			{
				return 15;
			}
			if (string_0.Equals("it"))
			{
				return 16;
			}
			if (string_0.Equals("ja"))
			{
				return 17;
			}
			if (string_0.Equals("ka"))
			{
				return 55;
			}
			if (string_0.Equals("kk"))
			{
				return 63;
			}
			if (string_0.Equals("kn"))
			{
				return 75;
			}
			if (string_0.Equals("ko"))
			{
				return 18;
			}
			if (string_0.Equals("kok"))
			{
				return 87;
			}
			if (string_0.Equals("ky"))
			{
				return 64;
			}
			if (string_0.Equals("lv"))
			{
				return 38;
			}
			if (string_0.Equals("lt"))
			{
				return 39;
			}
			if (string_0.Equals("mk"))
			{
				return 47;
			}
			if (string_0.Equals("ms"))
			{
				return 62;
			}
			if (string_0.Equals("mr"))
			{
				return 78;
			}
			if (string_0.Equals("mn"))
			{
				return 80;
			}
			if (string_0.Equals("no"))
			{
				return 20;
			}
			if (string_0.Equals("nb"))
			{
				return 1044;
			}
			if (string_0.Equals("nl"))
			{
				return 19;
			}
			if (string_0.Equals("nn"))
			{
				return 2068;
			}
			if (string_0.Equals("pa"))
			{
				return 70;
			}
			if (string_0.Equals("pl"))
			{
				return 21;
			}
			if (string_0.Equals("pt"))
			{
				return 22;
			}
			if (string_0.Equals("ro"))
			{
				return 24;
			}
			if (string_0.Equals("ru"))
			{
				return 25;
			}
			if (string_0.Equals("sa"))
			{
				return 79;
			}
			if (string_0.Equals("sk"))
			{
				return 27;
			}
			if (string_0.Equals("sl"))
			{
				return 36;
			}
			if (string_0.Equals("sq"))
			{
				return 28;
			}
			if (string_0.Equals("sr"))
			{
				return 3098;
			}
			if (string_0.Equals("sv"))
			{
				return 29;
			}
			if (string_0.Equals("sw"))
			{
				return 65;
			}
			if (string_0.Equals("syr"))
			{
				return 90;
			}
			if (string_0.Equals("ta"))
			{
				return 73;
			}
			if (string_0.Equals("te"))
			{
				return 74;
			}
			if (string_0.Equals("th"))
			{
				return 30;
			}
			if (string_0.Equals("tr"))
			{
				return 31;
			}
			if (string_0.Equals("tt"))
			{
				return 68;
			}
			if (string_0.Equals("uk"))
			{
				return 34;
			}
			if (string_0.Equals("ur"))
			{
				return 32;
			}
			if (string_0.Equals("uz"))
			{
				return 67;
			}
			if (string_0.Equals("vi"))
			{
				return 42;
			}
			if (string_0.Equals("zh"))
			{
				return 2052;
			}
			if (string_0.Equals("zu"))
			{
				return 1077;
			}
		}
		return 0;
	}
}
