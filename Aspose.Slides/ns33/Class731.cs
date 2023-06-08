using ns6;

namespace ns33;

internal class Class731
{
	private static readonly string[][,][] string_0;

	private static readonly string[] string_1;

	private static readonly string[] string_2;

	private static readonly string[] string_3;

	private static readonly string[] string_4;

	private static readonly string[] string_5;

	private static readonly string[] string_6;

	private static readonly string[] string_7;

	private static readonly string[] string_8;

	private static readonly string[] string_9;

	private static readonly string[] string_10;

	private static readonly string[] string_11;

	private static readonly string[] string_12;

	private static readonly string[] string_13;

	private static readonly string[] string_14;

	private static readonly string[] string_15;

	private static readonly string[] string_16;

	private static readonly string[] string_17;

	private static readonly string[] string_18;

	private static readonly string[] string_19;

	private static readonly string[] string_20;

	private static readonly string[] string_21;

	private static readonly string[] string_22;

	private static readonly string[] string_23;

	private static readonly string[] string_24;

	public static string[] smethod_0(Enum1 charSet, int pitchFamily, byte[] panose)
	{
		int num = pitchFamily >> 4;
		if (num > 5)
		{
			num = 0;
		}
		int num2 = pitchFamily & 0xF;
		if (num2 > 2)
		{
			num2 = ((num2 == 8) ? 1 : 0);
		}
		if (panose != null && panose[0] >= 2)
		{
			switch (panose[0])
			{
			default:
				return string_1;
			case 2:
				if (panose[3] == 9)
				{
					return smethod_6((int)charSet, 0, 1);
				}
				if (panose[1] < 11)
				{
					return smethod_6((int)charSet, 2, 1);
				}
				return smethod_6((int)charSet, 2, 2);
			case 3:
				return string_5;
			case 4:
				return smethod_6((int)charSet, 5, 0);
			case 5:
				return string_7;
			}
		}
		return smethod_6((int)charSet, num, num2);
	}

	static Class731()
	{
		string_0 = new string[256][,][];
		string_1 = new string[4] { "Arial", "MS Gothic", "Gulim", "Arial Unicode" };
		string_2 = new string[5] { "Courier", "Courier New", "MS Mincho", "Batang", "Arial Unicode" };
		string_3 = new string[4] { "Times New Roman", "MS Mincho", "Batang", "Arial Unicode" };
		string_4 = new string[4] { "Arial", "MS Gothic", "Gulim", "Arial Unicode" };
		string_5 = new string[5] { "Urdu Typesetting", "Times New Roman", "MS Mincho", "Batang", "Arial Unicode" };
		string_6 = new string[5] { "Sakkal Majalla", "Times New Roman", "MS Mincho", "Batang", "Arial Unicode" };
		string_7 = new string[1] { "Wingdings" };
		string_8 = new string[4] { "DaunPenh", "Cambria", "Arial", "MS Mincho" };
		string_9 = new string[4] { "DaunPenh", "Cambria", "Times New Roman", "MS Mincho" };
		string_10 = new string[3] { "Gabriola", "Times New Roman", "MS Mincho" };
		string_11 = new string[2] { "PMingLiU", "Times New Roman" };
		string_12 = new string[2] { "MingLiU", "Courier New" };
		string_13 = new string[3] { "Microsoft JhengHei", "Calibri", "Arial" };
		string_14 = new string[2] { "SimSun", "Times New Roman" };
		string_15 = new string[2] { "SimSun", "Courier New" };
		string_16 = new string[2] { "Microsoft YaHei", "Arial" };
		string_17 = new string[2] { "Gulim", "Arial" };
		string_18 = new string[2] { "GulimChe", "Courier New" };
		string_19 = new string[2] { "Batang", "Times New Roman" };
		string_20 = new string[2] { "BatangChe", "Courier New" };
		string_21 = new string[2] { "MS PGothic", "Arial" };
		string_22 = new string[2] { "MS Gothic", "Courier New" };
		string_23 = new string[2] { "MS PMincho", "Times New Roman" };
		string_24 = new string[2] { "MS Mincho", "Courier New" };
		string[,][] table = smethod_5(0);
		smethod_1(table, string_1);
		smethod_4(table, 0, 2, string_8);
		smethod_4(table, 1, 2, new string[2] { "Times New Roman", "MS Mincho" });
		smethod_4(table, 3, 1, new string[2] { "Courier New", "MS Mincho" });
		smethod_4(table, 3, 2, new string[4] { "OCR A Extended", "Calibri", "Courier New", "MS Mincho" });
		smethod_4(table, 4, 1, new string[3] { "DFKai-SB", "Cambria", "Courier New" });
		smethod_4(table, 4, 2, new string[5] { "Estrangelo Edessa", "Cambria", "Arabic Typesetting", "Times New Roman", "MS Mincho" });
		smethod_4(table, 5, 2, string_10);
		table = smethod_5(2);
		smethod_1(table, new string[1] { "Wingdings" });
		table = smethod_5(128);
		smethod_1(table, string_21);
		smethod_4(table, 0, 1, string_22);
		smethod_4(table, 1, 0, string_23);
		smethod_4(table, 1, 1, string_24);
		smethod_4(table, 1, 2, string_23);
		smethod_4(table, 2, 1, string_22);
		smethod_4(table, 3, 0, string_22);
		smethod_4(table, 3, 1, string_22);
		smethod_4(table, 4, 1, string_22);
		smethod_4(table, 5, 1, string_22);
		table = smethod_5(129);
		smethod_1(table, string_17);
		smethod_3(table, 1, string_18);
		smethod_4(table, 1, 0, string_19);
		smethod_4(table, 1, 1, string_20);
		smethod_4(table, 1, 2, string_19);
		smethod_4(table, 3, 0, string_18);
		table = smethod_5(130);
		smethod_1(table, new string[1] { "Arial Unicode MS" });
		table = smethod_5(134);
		smethod_1(table, string_14);
		smethod_3(table, 1, string_15);
		smethod_4(table, 1, 0, string_16);
		smethod_4(table, 1, 1, string_16);
		smethod_4(table, 1, 2, string_16);
		smethod_4(table, 2, 2, string_16);
		smethod_4(table, 3, 0, string_15);
		table = smethod_5(136);
		smethod_1(table, string_11);
		smethod_3(table, 1, string_12);
		smethod_4(table, 1, 0, string_13);
		smethod_4(table, 1, 1, string_13);
		smethod_4(table, 1, 2, string_11);
		smethod_4(table, 2, 2, string_13);
		smethod_4(table, 3, 0, string_12);
		smethod_4(table, 4, 1, new string[3] { "DFKai-SB", "Cambria", "Courier New" });
		table = smethod_5(161);
		smethod_4(table, 0, 2, new string[3] { "Segoe Print", "Arial", "MS Mincho" });
		smethod_4(table, 3, 2, string_1);
		smethod_4(table, 4, 1, string_1);
		smethod_4(table, 4, 2, new string[4] { "Comic Sans MS", "Arabic Typesetting", "Times New Roman", "MS Mincho" });
		smethod_4(table, 5, 2, string_10);
		table = smethod_5(162);
		smethod_4(table, 0, 2, new string[4] { "Nyala", "Cambria", "Arial", "MS Mincho" });
		smethod_4(table, 3, 2, string_1);
		smethod_4(table, 4, 1, string_1);
		smethod_4(table, 4, 2, string_9);
		smethod_4(table, 5, 2, string_10);
		table = smethod_5(163);
		smethod_4(table, 0, 2, string_1);
		smethod_4(table, 3, 2, string_1);
		smethod_4(table, 4, 1, string_1);
		smethod_4(table, 5, 2, string_1);
		table = smethod_5(177);
		smethod_4(table, 0, 2, new string[4] { "Aharoni", "Cambria", "Arial", "MS Mincho" });
		smethod_4(table, 3, 2, string_1);
		smethod_4(table, 4, 1, string_1);
		smethod_4(table, 5, 2, string_1);
		table = smethod_5(178);
		smethod_4(table, 0, 2, new string[4] { "Sakkal Majalla", "Cambria", "Arial", "MS Mincho" });
		smethod_4(table, 3, 2, string_1);
		smethod_4(table, 4, 1, string_1);
		smethod_4(table, 4, 2, string_9);
		smethod_4(table, 5, 2, string_1);
		table = smethod_5(186);
		smethod_4(table, 0, 2, new string[4] { "Nyala", "Cambria", "Arial", "MS Mincho" });
		smethod_4(table, 3, 2, string_1);
		smethod_4(table, 4, 1, string_1);
		smethod_4(table, 4, 2, string_9);
		smethod_4(table, 5, 2, string_10);
		table = smethod_5(204);
		smethod_4(table, 0, 2, new string[3] { "Segoe Print", "Arial", "MS Mincho" });
		smethod_4(table, 3, 2, string_1);
		smethod_4(table, 4, 1, string_1);
		smethod_4(table, 4, 2, new string[4] { "Comic Sans MS", "Arabic Typesetting", "Times New Roman", "MS Mincho" });
		smethod_4(table, 5, 2, string_10);
		table = smethod_5(222);
		smethod_1(table, new string[3] { "DokChampa", "Arial", "MS Gothic" });
		smethod_4(table, 1, 2, new string[4] { "Angsana New", "Cambria", "Times New Roman", "MS Mincho" });
		table = smethod_5(238);
		smethod_4(table, 0, 2, new string[4] { "Nyala", "Cambria", "Arial", "MS Mincho" });
		smethod_4(table, 3, 2, string_1);
		smethod_4(table, 4, 1, string_1);
		smethod_4(table, 4, 2, string_9);
		smethod_4(table, 5, 2, string_10);
		string[,][] array = string_0[0];
		for (int i = 1; i < 256; i++)
		{
			if (string_0[i] == null)
			{
				string_0[i] = array;
				continue;
			}
			table = string_0[i];
			for (int j = 0; j < 6; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					if (table[j, k] == null)
					{
						table[j, k] = array[j, k];
					}
				}
			}
		}
	}

	private static void smethod_1(string[,][] table, string[] substitutionFonts)
	{
		for (int i = 0; i < 6; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				table[i, j] = substitutionFonts;
			}
		}
	}

	private static void smethod_2(string[,][] table, int family, string[] substitutionFonts)
	{
		for (int i = 0; i < 3; i++)
		{
			table[family, i] = substitutionFonts;
		}
	}

	private static void smethod_3(string[,][] table, int pitch, string[] substitutionFonts)
	{
		for (int i = 0; i < 6; i++)
		{
			table[i, pitch] = substitutionFonts;
		}
	}

	private static void smethod_4(string[,][] table, int family, int pitch, string[] substitutionFonts)
	{
		table[family, pitch] = substitutionFonts;
	}

	private static string[,][] smethod_5(int charset)
	{
		string[,][] array = string_0[charset];
		if (array == null)
		{
			array = (string_0[charset] = new string[6, 3][]);
		}
		return array;
	}

	private static string[] smethod_6(int charset, int family, int pitch)
	{
		string[,][] array = string_0[charset];
		if (array == null)
		{
			array = string_0[0];
		}
		return array[family, pitch];
	}
}
