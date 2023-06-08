using System.Collections;
using Aspose.Cells;
using ns14;

namespace ns16;

internal class Class1193
{
	internal Class1192 class1192_0 = new Class1192();

	internal Class1192 class1192_1 = new Class1192();

	private Hashtable hashtable_0 = new Hashtable();

	private Hashtable hashtable_1 = new Hashtable();

	internal Class1193()
	{
		method_4();
		method_5();
	}

	private int method_0(string string_0)
	{
		object obj = hashtable_0[string_0.ToLower()];
		if (obj == null)
		{
			return -1;
		}
		return (int)obj;
	}

	internal string method_1(CountryCode countryCode_0, bool bool_0)
	{
		if (countryCode_0 == CountryCode.Default)
		{
			countryCode_0 = CountryCode.USA;
		}
		int int_ = smethod_0(countryCode_0);
		return method_8(int_, bool_0);
	}

	private static int smethod_0(CountryCode countryCode_0)
	{
		return countryCode_0 switch
		{
			CountryCode.Russia => 25, 
			CountryCode.USA => 1033, 
			CountryCode.Canada => 4105, 
			CountryCode.Italy => 16, 
			CountryCode.France => 12, 
			CountryCode.Spain => 10, 
			CountryCode.Germany => 7, 
			CountryCode.UnitedKingdom => 9, 
			CountryCode.India => 9, 
			CountryCode.China => 2052, 
			CountryCode.Australia => 3081, 
			_ => 0, 
		};
	}

	internal int method_2(string string_0)
	{
		object obj = hashtable_1[string_0.ToUpper()];
		if (obj == null)
		{
			return -1;
		}
		return (int)obj;
	}

	private int method_3(int int_0)
	{
		switch (int_0)
		{
		case 1028:
			return 42;
		case 2052:
			return 41;
		default:
			return -1;
		case 17:
		case 1041:
			return 51;
		}
	}

	private void method_4()
	{
		hashtable_0.Add("af", 54);
		hashtable_0.Add("af-za", 1078);
		hashtable_0.Add("sq", 28);
		hashtable_0.Add("sq-al", 1052);
		hashtable_0.Add("ar", 1);
		hashtable_0.Add("ar-dz", 5121);
		hashtable_0.Add("ar-bh", 15361);
		hashtable_0.Add("ar-eg", 3073);
		hashtable_0.Add("ar-iq", 2049);
		hashtable_0.Add("ar-jo", 11265);
		hashtable_0.Add("ar-kw", 13313);
		hashtable_0.Add("ar-lb", 12289);
		hashtable_0.Add("ar-ly", 4097);
		hashtable_0.Add("ar-ma", 6145);
		hashtable_0.Add("ar-om", 8193);
		hashtable_0.Add("ar-qa", 16385);
		hashtable_0.Add("ar-sa", 1025);
		hashtable_0.Add("ar-sy", 10241);
		hashtable_0.Add("ar-tn", 7169);
		hashtable_0.Add("ar-ae", 14337);
		hashtable_0.Add("ar-ye", 9217);
		hashtable_0.Add("hy", 43);
		hashtable_0.Add("hy-am", 1067);
		hashtable_0.Add("az", 44);
		hashtable_0.Add("az-az-cyrl", 2092);
		hashtable_0.Add("az-az-latn", 1068);
		hashtable_0.Add("eu", 45);
		hashtable_0.Add("eu-es", 1069);
		hashtable_0.Add("be", 35);
		hashtable_0.Add("be-by", 1059);
		hashtable_0.Add("bg", 2);
		hashtable_0.Add("bg-bg", 1026);
		hashtable_0.Add("ca", 3);
		hashtable_0.Add("ca-es", 1027);
		hashtable_0.Add("zh-hk", 3076);
		hashtable_0.Add("zh-mo", 5124);
		hashtable_0.Add("zh-cn", 2052);
		hashtable_0.Add("zh-chs", 4);
		hashtable_0.Add("zh-sg", 4100);
		hashtable_0.Add("zh-tw", 1028);
		hashtable_0.Add("zh-cht", 31748);
		hashtable_0.Add("hr", 26);
		hashtable_0.Add("hr-hr", 1050);
		hashtable_0.Add("cs", 5);
		hashtable_0.Add("cs-cz", 1029);
		hashtable_0.Add("da", 6);
		hashtable_0.Add("da-dk", 1030);
		hashtable_0.Add("div", 101);
		hashtable_0.Add("div-mv", 1125);
		hashtable_0.Add("nl", 19);
		hashtable_0.Add("nl-be", 2067);
		hashtable_0.Add("nl-nl", 1043);
		hashtable_0.Add("en", 9);
		hashtable_0.Add("en-au", 3081);
		hashtable_0.Add("en-bz", 10249);
		hashtable_0.Add("en-ca", 4105);
		hashtable_0.Add("en-cb", 9225);
		hashtable_0.Add("en-ie", 6153);
		hashtable_0.Add("en-jm", 8201);
		hashtable_0.Add("en-nz", 5129);
		hashtable_0.Add("en-ph", 13321);
		hashtable_0.Add("en-za", 7177);
		hashtable_0.Add("en-tt", 11273);
		hashtable_0.Add("en-gb", 2057);
		hashtable_0.Add("en-us", 1033);
		hashtable_0.Add("en-zw", 12297);
		hashtable_0.Add("et", 37);
		hashtable_0.Add("et-ee", 1061);
		hashtable_0.Add("fo", 56);
		hashtable_0.Add("fo-fo", 1080);
		hashtable_0.Add("fa", 41);
		hashtable_0.Add("fa-ir", 1065);
		hashtable_0.Add("fi", 11);
		hashtable_0.Add("fi-fi", 1035);
		hashtable_0.Add("fr", 12);
		hashtable_0.Add("fr-be", 2060);
		hashtable_0.Add("fr-ca", 3084);
		hashtable_0.Add("fr-fr", 1036);
		hashtable_0.Add("fr-lu", 5132);
		hashtable_0.Add("fr-mc", 6156);
		hashtable_0.Add("fr-ch", 4108);
		hashtable_0.Add("gl", 86);
		hashtable_0.Add("gl-es", 1110);
		hashtable_0.Add("ka", 55);
		hashtable_0.Add("ka-ge", 1079);
		hashtable_0.Add("de", 7);
		hashtable_0.Add("de-at", 3079);
		hashtable_0.Add("de-de", 1031);
		hashtable_0.Add("de-li", 5127);
		hashtable_0.Add("de-lu", 4103);
		hashtable_0.Add("de-ch", 2055);
		hashtable_0.Add("el", 8);
		hashtable_0.Add("el-gr", 1032);
		hashtable_0.Add("gu", 71);
		hashtable_0.Add("gu-in", 1095);
		hashtable_0.Add("he", 13);
		hashtable_0.Add("he-il", 1037);
		hashtable_0.Add("hi", 57);
		hashtable_0.Add("hi-in", 1081);
		hashtable_0.Add("hu", 14);
		hashtable_0.Add("hu-hu", 1038);
		hashtable_0.Add("is", 15);
		hashtable_0.Add("is-is", 1039);
		hashtable_0.Add("id", 33);
		hashtable_0.Add("id-id", 1057);
		hashtable_0.Add("it", 16);
		hashtable_0.Add("it-it", 1040);
		hashtable_0.Add("it-ch", 2064);
		hashtable_0.Add("ja", 17);
		hashtable_0.Add("ja-jp", 1041);
		hashtable_0.Add("kn", 75);
		hashtable_0.Add("kn-in", 1099);
		hashtable_0.Add("kk", 63);
		hashtable_0.Add("kk-kz", 1087);
		hashtable_0.Add("kok", 87);
		hashtable_0.Add("kok-in", 1111);
		hashtable_0.Add("ko", 18);
		hashtable_0.Add("ko-kr", 1042);
		hashtable_0.Add("ky", 64);
		hashtable_0.Add("ky-kg", 1088);
		hashtable_0.Add("lv", 38);
		hashtable_0.Add("lv-lv", 1062);
		hashtable_0.Add("lt", 39);
		hashtable_0.Add("lt-lt", 1063);
		hashtable_0.Add("mk", 47);
		hashtable_0.Add("mk-mk", 1071);
		hashtable_0.Add("ms", 62);
		hashtable_0.Add("ms-bn", 2110);
		hashtable_0.Add("ms-my", 1086);
		hashtable_0.Add("mr", 78);
		hashtable_0.Add("mr-in", 1102);
		hashtable_0.Add("mn", 80);
		hashtable_0.Add("mn-mn", 1104);
		hashtable_0.Add("no", 20);
		hashtable_0.Add("nb-no", 1044);
		hashtable_0.Add("nn-no", 2068);
		hashtable_0.Add("pl", 21);
		hashtable_0.Add("pl-pl", 1045);
		hashtable_0.Add("pt", 22);
		hashtable_0.Add("pt-br", 1046);
		hashtable_0.Add("pt-pt", 2070);
		hashtable_0.Add("pa", 70);
		hashtable_0.Add("pa-in", 1094);
		hashtable_0.Add("ro", 24);
		hashtable_0.Add("ro-ro", 1048);
		hashtable_0.Add("ru", 25);
		hashtable_0.Add("ru-ru", 1049);
		hashtable_0.Add("sa", 79);
		hashtable_0.Add("sa-in", 1103);
		hashtable_0.Add("sr-sp-cyrl", 3098);
		hashtable_0.Add("sr-sp-latn", 2074);
		hashtable_0.Add("sk", 27);
		hashtable_0.Add("sk-sk", 1051);
		hashtable_0.Add("sl", 36);
		hashtable_0.Add("sl-si", 1060);
		hashtable_0.Add("es", 10);
		hashtable_0.Add("es-ar", 11274);
		hashtable_0.Add("es-bo", 16394);
		hashtable_0.Add("es-cl", 13322);
		hashtable_0.Add("es-co", 9226);
		hashtable_0.Add("es-cr", 5130);
		hashtable_0.Add("es-do", 7178);
		hashtable_0.Add("es-ec", 12298);
		hashtable_0.Add("es-sv", 17418);
		hashtable_0.Add("es-gt", 4106);
		hashtable_0.Add("es-hn", 18442);
		hashtable_0.Add("es-mx", 2058);
		hashtable_0.Add("es-ni", 19466);
		hashtable_0.Add("es-pa", 6154);
		hashtable_0.Add("es-py", 15370);
		hashtable_0.Add("es-pe", 10250);
		hashtable_0.Add("es-pr", 20490);
		hashtable_0.Add("es-es", 3082);
		hashtable_0.Add("es-uy", 14346);
		hashtable_0.Add("es-ve", 8202);
		hashtable_0.Add("sw", 65);
		hashtable_0.Add("sw-ke", 1089);
		hashtable_0.Add("sv", 29);
		hashtable_0.Add("sv-fi", 2077);
		hashtable_0.Add("sv-se", 1053);
		hashtable_0.Add("syr", 90);
		hashtable_0.Add("syr-sy", 1114);
		hashtable_0.Add("ta", 73);
		hashtable_0.Add("ta-in", 1097);
		hashtable_0.Add("tt", 68);
		hashtable_0.Add("tt-ru", 1092);
		hashtable_0.Add("te", 74);
		hashtable_0.Add("te-in", 1098);
		hashtable_0.Add("th", 30);
		hashtable_0.Add("th-th", 1054);
		hashtable_0.Add("tr", 31);
		hashtable_0.Add("tr-tr", 1055);
		hashtable_0.Add("uk", 34);
		hashtable_0.Add("uk-ua", 1058);
		hashtable_0.Add("ur", 32);
		hashtable_0.Add("ur-pk", 1056);
		hashtable_0.Add("uz", 67);
		hashtable_0.Add("uz-uz-cyrl", 2115);
		hashtable_0.Add("uz-uz-latn", 1091);
		hashtable_0.Add("vi", 42);
		hashtable_0.Add("vi-vn", 1066);
	}

	private void method_5()
	{
		hashtable_1.Add("ARAB", 1);
		hashtable_1.Add("ARMI", 2);
		hashtable_1.Add("ARMN", 3);
		hashtable_1.Add("AVST", 4);
		hashtable_1.Add("BALI", 5);
		hashtable_1.Add("BAMU", 6);
		hashtable_1.Add("BATK", 7);
		hashtable_1.Add("BENG", 8);
		hashtable_1.Add("BLIS", 9);
		hashtable_1.Add("BOPO", 10);
		hashtable_1.Add("BRAH", 11);
		hashtable_1.Add("BRAI", 12);
		hashtable_1.Add("BUGI", 13);
		hashtable_1.Add("BUHD", 14);
		hashtable_1.Add("CAKM", 15);
		hashtable_1.Add("CANS", 16);
		hashtable_1.Add("CARI", 17);
		hashtable_1.Add("CHAM", 18);
		hashtable_1.Add("CHER", 19);
		hashtable_1.Add("CIRT", 20);
		hashtable_1.Add("COPT", 21);
		hashtable_1.Add("CPRT", 22);
		hashtable_1.Add("CYRL", 23);
		hashtable_1.Add("CYRS", 24);
		hashtable_1.Add("DEVA", 25);
		hashtable_1.Add("DSRT", 26);
		hashtable_1.Add("EGYD", 27);
		hashtable_1.Add("EGYH", 28);
		hashtable_1.Add("EGYP", 29);
		hashtable_1.Add("ETHI", 30);
		hashtable_1.Add("GEOR", 31);
		hashtable_1.Add("GEOK", 32);
		hashtable_1.Add("GLAG", 33);
		hashtable_1.Add("GOTH", 34);
		hashtable_1.Add("GREK", 35);
		hashtable_1.Add("GUJR", 36);
		hashtable_1.Add("GURU", 37);
		hashtable_1.Add("HANG", 38);
		hashtable_1.Add("HANI", 39);
		hashtable_1.Add("HANO", 40);
		hashtable_1.Add("HANS", 41);
		hashtable_1.Add("HANT", 42);
		hashtable_1.Add("HEBR", 43);
		hashtable_1.Add("HIRA", 44);
		hashtable_1.Add("HMNG", 45);
		hashtable_1.Add("HRKT", 46);
		hashtable_1.Add("HUNG", 47);
		hashtable_1.Add("INDS", 48);
		hashtable_1.Add("ITAL", 49);
		hashtable_1.Add("JAVA", 50);
		hashtable_1.Add("JPAN", 51);
		hashtable_1.Add("KALI", 52);
		hashtable_1.Add("KANA", 53);
		hashtable_1.Add("KHAR", 54);
		hashtable_1.Add("KHMR", 55);
		hashtable_1.Add("KNDA", 56);
		hashtable_1.Add("KORE", 57);
		hashtable_1.Add("KTHI", 58);
		hashtable_1.Add("LANA", 59);
		hashtable_1.Add("LAOO", 60);
		hashtable_1.Add("LATF", 61);
		hashtable_1.Add("LATG", 62);
		hashtable_1.Add("LATN", 63);
		hashtable_1.Add("LEPC", 64);
		hashtable_1.Add("LIMB", 65);
		hashtable_1.Add("LINA", 66);
		hashtable_1.Add("LINB", 67);
		hashtable_1.Add("LISU", 68);
		hashtable_1.Add("LYCI", 69);
		hashtable_1.Add("LYDI", 70);
		hashtable_1.Add("MAND", 71);
		hashtable_1.Add("MANI", 72);
		hashtable_1.Add("MAYA", 73);
		hashtable_1.Add("MERO", 74);
		hashtable_1.Add("MLYM", 75);
		hashtable_1.Add("MONG", 76);
		hashtable_1.Add("MOON", 77);
		hashtable_1.Add("MTEI", 78);
		hashtable_1.Add("MYMR", 79);
		hashtable_1.Add("NKGB", 80);
		hashtable_1.Add("NKOO", 81);
		hashtable_1.Add("OGAM", 82);
		hashtable_1.Add("OLCK", 83);
		hashtable_1.Add("ORKH", 84);
		hashtable_1.Add("ORYA", 85);
		hashtable_1.Add("OSMA", 86);
		hashtable_1.Add("PERM", 87);
		hashtable_1.Add("PHAG", 88);
		hashtable_1.Add("PHLI", 89);
		hashtable_1.Add("PHLP", 90);
		hashtable_1.Add("PHLV", 91);
		hashtable_1.Add("PHNX", 92);
		hashtable_1.Add("PLRD", 93);
		hashtable_1.Add("PRTI", 94);
		hashtable_1.Add("QAAA", 95);
		hashtable_1.Add("RJNG", 96);
		hashtable_1.Add("RORO", 97);
		hashtable_1.Add("RUNR", 98);
		hashtable_1.Add("SAMR", 99);
		hashtable_1.Add("SARA", 100);
		hashtable_1.Add("SAUR", 101);
		hashtable_1.Add("SGNW", 102);
		hashtable_1.Add("SHAW", 103);
		hashtable_1.Add("SINH", 104);
		hashtable_1.Add("SUND", 105);
		hashtable_1.Add("SYLO", 106);
		hashtable_1.Add("SYRC", 107);
		hashtable_1.Add("SYRJ", 109);
		hashtable_1.Add("SYRN", 110);
		hashtable_1.Add("TAGB", 111);
		hashtable_1.Add("TALE", 112);
		hashtable_1.Add("TALU", 113);
		hashtable_1.Add("TAML", 114);
		hashtable_1.Add("TAVT", 115);
		hashtable_1.Add("TELU", 116);
		hashtable_1.Add("TENG", 117);
		hashtable_1.Add("TFNG", 118);
		hashtable_1.Add("TGLG", 119);
		hashtable_1.Add("THAA", 120);
		hashtable_1.Add("THAI", 121);
		hashtable_1.Add("TIBT", 122);
		hashtable_1.Add("UGAR", 123);
		hashtable_1.Add("VAII", 124);
		hashtable_1.Add("VISP", 125);
		hashtable_1.Add("XPEO", 126);
		hashtable_1.Add("XSUX", 127);
		hashtable_1.Add("YIII", 128);
		hashtable_1.Add("ZINH", 129);
		hashtable_1.Add("ZMTH", 130);
		hashtable_1.Add("ZSYM", 131);
		hashtable_1.Add("ZXXX", 132);
		hashtable_1.Add("ZYYY", 133);
		hashtable_1.Add("ZZZZ", 134);
		hashtable_1.Add("VIET", 135);
		hashtable_1.Add("UIGH", 136);
	}

	internal string method_6(string string_0, string string_1, bool bool_0)
	{
		string string_2 = ((string_0 == null) ? string_1 : string_0);
		return method_7(string_2, bool_0);
	}

	internal string method_7(string string_0, bool bool_0)
	{
		if (string_0 == null)
		{
			return null;
		}
		int num = method_0(string_0);
		if (num == -1)
		{
			return null;
		}
		return method_8(num, bool_0);
	}

	private string method_8(int int_0, bool bool_0)
	{
		if (int_0 == -1)
		{
			return null;
		}
		Class1192 @class = (bool_0 ? class1192_0 : class1192_1);
		string text = null;
		if (Class519.smethod_0(int_0))
		{
			if (@class.string_0 != null)
			{
				text = @class.string_0;
			}
		}
		else if (Class519.smethod_1(int_0) && @class.string_1 != null)
		{
			text = @class.string_1;
		}
		if (text == null)
		{
			int num = method_3(int_0);
			if (num != -1)
			{
				if (bool_0)
				{
					object obj = class1192_0.hashtable_0[num];
					if (obj != null)
					{
						text = (string)obj;
					}
				}
				else
				{
					object obj2 = class1192_1.hashtable_0[num];
					if (obj2 != null)
					{
						text = (string)obj2;
					}
				}
			}
		}
		return text;
	}
}
