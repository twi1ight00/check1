using System.Collections;
using System.Text;
using ns16;

namespace ns17;

internal class Class534
{
	private byte[] byte_0;

	private int[] int_0;

	private static byte byte_1;

	protected static Hashtable hashtable_0;

	internal ArrayList method_0(Class1544 class1544_0)
	{
		ArrayList arrayList = new ArrayList();
		char[] array = class1544_0.string_0.ToCharArray();
		_ = class1544_0.string_0.Length;
		Class535 @class = new Class535(array, 0, class1544_0.string_0.Length, 0);
		byte_0 = new byte[class1544_0.string_0.Length];
		int_0 = new int[class1544_0.string_0.Length];
		byte[] array2 = @class.method_8();
		int num = method_2(array, 0, array.Length - 1) + 1;
		for (int i = 0; i < num; i++)
		{
			byte_0[i] = array2[i];
			int_0[i] = i;
		}
		int j = 0;
		int num2 = 0;
		while (true)
		{
			if (j < num)
			{
				char c = array[j];
				if ((c < '\u0600' || c > 'ۿ') && (c < '\u0590' || c > '\u05ff'))
				{
					if (j != num2)
					{
						array[num2] = array[j];
						byte_0[num2] = byte_0[j];
					}
					j++;
					num2++;
					continue;
				}
			}
			if (j >= num)
			{
				break;
			}
			int num3 = j;
			for (j++; j < num; j++)
			{
				char c2 = array[j];
				if ((c2 < '\u0600' || c2 > 'ۿ') && (c2 < '\u0590' || c2 > '\u05ff'))
				{
					break;
				}
			}
			int num4 = j - num3;
			int num5 = Class1078.smethod_10(array, num3, num4, array, num2, num4, 0);
			if (num3 != num2)
			{
				for (int k = 0; k < num5; k++)
				{
					byte_0[num2++] = byte_0[num3++];
				}
			}
			else
			{
				num2 += num5;
			}
		}
		num = num2;
		method_4(0, num - 1);
		new StringBuilder();
		method_3(array);
		for (int l = 0; l < num; l++)
		{
			int num6 = int_0[l];
			char c3 = array[num6];
			Class1544 class2 = new Class1544();
			class2.font_0 = class1544_0.font_0;
			class2.string_0 = "" + c3;
			arrayList.Add(class2);
		}
		return arrayList;
	}

	internal void method_1(ArrayList arrayList_0)
	{
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1544 @class = (Class1544)arrayList_0[i];
			char[] array = @class.string_0.ToCharArray();
			_ = @class.string_0.Length;
			Class535 class2 = new Class535(array, 0, @class.string_0.Length, 0);
			byte_0 = new byte[@class.string_0.Length];
			int_0 = new int[@class.string_0.Length];
			byte[] array2 = class2.method_8();
			int num = method_2(array, 0, array.Length - 1) + 1;
			for (int j = 0; j < num; j++)
			{
				byte_0[j] = array2[j];
				int_0[j] = j;
			}
			int k = 0;
			int num2 = 0;
			while (true)
			{
				if (k < num)
				{
					char c = array[k];
					if ((c < '\u0600' || c > 'ۿ') && (c < '\u0590' || c > '\u05ff'))
					{
						if (k != num2)
						{
							array[num2] = array[k];
							byte_0[num2] = byte_0[k];
						}
						k++;
						num2++;
						continue;
					}
				}
				if (k >= num)
				{
					break;
				}
				int num3 = k;
				for (k++; k < num; k++)
				{
					char c2 = array[k];
					if ((c2 < '\u0600' || c2 > 'ۿ') && (c2 < '\u0590' || c2 > '\u05ff'))
					{
						break;
					}
				}
				int num4 = k - num3;
				int num5 = Class1078.smethod_10(array, num3, num4, array, num2, num4, 0);
				if (num3 != num2)
				{
					for (int l = 0; l < num5; l++)
					{
						byte_0[num2++] = byte_0[num3++];
					}
				}
				else
				{
					num2 += num5;
				}
			}
			num = num2;
			method_4(0, num - 1);
			new StringBuilder();
			method_3(array);
			for (int m = 0; m < num; m++)
			{
				int num6 = int_0[m];
				char c3 = array[num6];
				Class1544 class3 = new Class1544();
				class3.string_0 = "" + c3;
				class3.font_0 = @class.font_0;
				arrayList.Add(class3);
			}
		}
		arrayList.Reverse();
		arrayList_0.Clear();
		arrayList_0.AddRange(arrayList);
	}

	public int method_2(char[] char_0, int int_1, int int_2)
	{
		int num;
		for (num = int_2; num >= int_1; num--)
		{
			char char_ = char_0[num];
			if (!smethod_0(char_))
			{
				break;
			}
		}
		return num;
	}

	public static bool smethod_0(char char_0)
	{
		return char_0 <= ' ';
	}

	public void method_3(char[] char_0)
	{
		for (int i = 0; i < char_0.Length; i++)
		{
			char c = char_0[i];
			if ((byte_0[i] & 1) == 1 && hashtable_0.Contains(char_0[i]))
			{
				int num = (int)hashtable_0[char_0[i]];
				char_0[i] = (char)num;
			}
			if ((c >= '\u0600' && c <= 'ۿ') || c < '\u0590')
			{
			}
		}
	}

	internal void method_4(int int_1, int int_2)
	{
		byte b = byte_0[int_1];
		byte b2 = b;
		byte b3 = b;
		byte b4 = b;
		for (int i = int_1 + 1; i <= int_2; i++)
		{
			byte b5 = byte_0[i];
			if (b5 > b)
			{
				b = b5;
			}
			else if (b5 < b2)
			{
				b2 = b5;
			}
			b3 = (byte)(b3 & b5);
			b4 = (byte)(b4 | b5);
		}
		if ((b4 & 1) == 0)
		{
			return;
		}
		if ((b3 & 1) == 1)
		{
			method_5(int_1, int_2 + 1);
			return;
		}
		b2 = (byte)(b2 | 1u);
		while (b >= b2)
		{
			int num = int_1;
			while (true)
			{
				if (num <= int_2 && byte_0[num] < b)
				{
					num++;
					continue;
				}
				if (num > int_2)
				{
					break;
				}
				int j;
				for (j = num + 1; j <= int_2 && byte_0[j] >= b; j++)
				{
				}
				method_5(num, j);
				num = j + 1;
			}
			b = (byte)(b - 1);
		}
	}

	internal void method_5(int int_1, int int_2)
	{
		int num = (int_1 + int_2) / 2;
		int_2--;
		while (int_1 < num)
		{
			int num2 = int_0[int_1];
			int_0[int_1] = int_0[int_2];
			int_0[int_2] = num2;
			int_1++;
			int_2--;
		}
	}

	static Class534()
	{
		byte_1 = 0;
		hashtable_0 = new Hashtable();
		hashtable_0[40] = 41;
		hashtable_0[41] = 40;
		hashtable_0[60] = 62;
		hashtable_0[62] = 60;
		hashtable_0[91] = 93;
		hashtable_0[93] = 91;
		hashtable_0[123] = 125;
		hashtable_0[125] = 123;
		hashtable_0[171] = 187;
		hashtable_0[187] = 171;
		hashtable_0[8249] = 8250;
		hashtable_0[8250] = 8249;
		hashtable_0[8261] = 8262;
		hashtable_0[8262] = 8261;
		hashtable_0[8317] = 8318;
		hashtable_0[8318] = 8317;
		hashtable_0[8333] = 8334;
		hashtable_0[8334] = 8333;
		hashtable_0[8712] = 8715;
		hashtable_0[8713] = 8716;
		hashtable_0[8714] = 8717;
		hashtable_0[8715] = 8712;
		hashtable_0[8716] = 8713;
		hashtable_0[8717] = 8714;
		hashtable_0[8725] = 10741;
		hashtable_0[8764] = 8765;
		hashtable_0[8765] = 8764;
		hashtable_0[8771] = 8909;
		hashtable_0[8786] = 8787;
		hashtable_0[8787] = 8786;
		hashtable_0[8788] = 8789;
		hashtable_0[8789] = 8788;
		hashtable_0[8804] = 8805;
		hashtable_0[8805] = 8804;
		hashtable_0[8806] = 8807;
		hashtable_0[8807] = 8806;
		hashtable_0[8808] = 8809;
		hashtable_0[8809] = 8808;
		hashtable_0[8810] = 8811;
		hashtable_0[8811] = 8810;
		hashtable_0[8814] = 8815;
		hashtable_0[8815] = 8814;
		hashtable_0[8816] = 8817;
		hashtable_0[8817] = 8816;
		hashtable_0[8818] = 8819;
		hashtable_0[8819] = 8818;
		hashtable_0[8820] = 8821;
		hashtable_0[8821] = 8820;
		hashtable_0[8822] = 8823;
		hashtable_0[8823] = 8822;
		hashtable_0[8824] = 8825;
		hashtable_0[8825] = 8824;
		hashtable_0[8826] = 8827;
		hashtable_0[8827] = 8826;
		hashtable_0[8828] = 8829;
		hashtable_0[8829] = 8828;
		hashtable_0[8830] = 8831;
		hashtable_0[8831] = 8830;
		hashtable_0[8832] = 8833;
		hashtable_0[8833] = 8832;
		hashtable_0[8834] = 8835;
		hashtable_0[8835] = 8834;
		hashtable_0[8836] = 8837;
		hashtable_0[8837] = 8836;
		hashtable_0[8838] = 8839;
		hashtable_0[8839] = 8838;
		hashtable_0[8840] = 8841;
		hashtable_0[8841] = 8840;
		hashtable_0[8842] = 8843;
		hashtable_0[8843] = 8842;
		hashtable_0[8847] = 8848;
		hashtable_0[8848] = 8847;
		hashtable_0[8849] = 8850;
		hashtable_0[8850] = 8849;
		hashtable_0[8856] = 10680;
		hashtable_0[8866] = 8867;
		hashtable_0[8867] = 8866;
		hashtable_0[8870] = 10974;
		hashtable_0[8872] = 10980;
		hashtable_0[8873] = 10979;
		hashtable_0[8875] = 10981;
		hashtable_0[8880] = 8881;
		hashtable_0[8881] = 8880;
		hashtable_0[8882] = 8883;
		hashtable_0[8883] = 8882;
		hashtable_0[8884] = 8885;
		hashtable_0[8885] = 8884;
		hashtable_0[8886] = 8887;
		hashtable_0[8887] = 8886;
		hashtable_0[8905] = 8906;
		hashtable_0[8906] = 8905;
		hashtable_0[8907] = 8908;
		hashtable_0[8908] = 8907;
		hashtable_0[8909] = 8771;
		hashtable_0[8912] = 8913;
		hashtable_0[8913] = 8912;
		hashtable_0[8918] = 8919;
		hashtable_0[8919] = 8918;
		hashtable_0[8920] = 8921;
		hashtable_0[8921] = 8920;
		hashtable_0[8922] = 8923;
		hashtable_0[8923] = 8922;
		hashtable_0[8924] = 8925;
		hashtable_0[8925] = 8924;
		hashtable_0[8926] = 8927;
		hashtable_0[8927] = 8926;
		hashtable_0[8928] = 8929;
		hashtable_0[8929] = 8928;
		hashtable_0[8930] = 8931;
		hashtable_0[8931] = 8930;
		hashtable_0[8932] = 8933;
		hashtable_0[8933] = 8932;
		hashtable_0[8934] = 8935;
		hashtable_0[8935] = 8934;
		hashtable_0[8936] = 8937;
		hashtable_0[8937] = 8936;
		hashtable_0[8938] = 8939;
		hashtable_0[8939] = 8938;
		hashtable_0[8940] = 8941;
		hashtable_0[8941] = 8940;
		hashtable_0[8944] = 8945;
		hashtable_0[8945] = 8944;
		hashtable_0[8946] = 8954;
		hashtable_0[8947] = 8955;
		hashtable_0[8948] = 8956;
		hashtable_0[8950] = 8957;
		hashtable_0[8951] = 8958;
		hashtable_0[8954] = 8946;
		hashtable_0[8955] = 8947;
		hashtable_0[8956] = 8948;
		hashtable_0[8957] = 8950;
		hashtable_0[8958] = 8951;
		hashtable_0[8968] = 8969;
		hashtable_0[8969] = 8968;
		hashtable_0[8970] = 8971;
		hashtable_0[8971] = 8970;
		hashtable_0[9001] = 9002;
		hashtable_0[9002] = 9001;
		hashtable_0[10088] = 10089;
		hashtable_0[10089] = 10088;
		hashtable_0[10090] = 10091;
		hashtable_0[10091] = 10090;
		hashtable_0[10092] = 10093;
		hashtable_0[10093] = 10092;
		hashtable_0[10094] = 10095;
		hashtable_0[10095] = 10094;
		hashtable_0[10096] = 10097;
		hashtable_0[10097] = 10096;
		hashtable_0[10098] = 10099;
		hashtable_0[10099] = 10098;
		hashtable_0[10100] = 10101;
		hashtable_0[10101] = 10100;
		hashtable_0[10197] = 10198;
		hashtable_0[10198] = 10197;
		hashtable_0[10205] = 10206;
		hashtable_0[10206] = 10205;
		hashtable_0[10210] = 10211;
		hashtable_0[10211] = 10210;
		hashtable_0[10212] = 10213;
		hashtable_0[10213] = 10212;
		hashtable_0[10214] = 10215;
		hashtable_0[10215] = 10214;
		hashtable_0[10216] = 10217;
		hashtable_0[10217] = 10216;
		hashtable_0[10218] = 10219;
		hashtable_0[10219] = 10218;
		hashtable_0[10627] = 10628;
		hashtable_0[10628] = 10627;
		hashtable_0[10629] = 10630;
		hashtable_0[10630] = 10629;
		hashtable_0[10631] = 10632;
		hashtable_0[10632] = 10631;
		hashtable_0[10633] = 10634;
		hashtable_0[10634] = 10633;
		hashtable_0[10635] = 10636;
		hashtable_0[10636] = 10635;
		hashtable_0[10637] = 10640;
		hashtable_0[10638] = 10639;
		hashtable_0[10639] = 10638;
		hashtable_0[10640] = 10637;
		hashtable_0[10641] = 10642;
		hashtable_0[10642] = 10641;
		hashtable_0[10643] = 10644;
		hashtable_0[10644] = 10643;
		hashtable_0[10645] = 10646;
		hashtable_0[10646] = 10645;
		hashtable_0[10647] = 10648;
		hashtable_0[10648] = 10647;
		hashtable_0[10680] = 8856;
		hashtable_0[10688] = 10689;
		hashtable_0[10689] = 10688;
		hashtable_0[10692] = 10693;
		hashtable_0[10693] = 10692;
		hashtable_0[10703] = 10704;
		hashtable_0[10704] = 10703;
		hashtable_0[10705] = 10706;
		hashtable_0[10706] = 10705;
		hashtable_0[10708] = 10709;
		hashtable_0[10709] = 10708;
		hashtable_0[10712] = 10713;
		hashtable_0[10713] = 10712;
		hashtable_0[10714] = 10715;
		hashtable_0[10715] = 10714;
		hashtable_0[10741] = 8725;
		hashtable_0[10744] = 10745;
		hashtable_0[10745] = 10744;
		hashtable_0[10748] = 10749;
		hashtable_0[10749] = 10748;
		hashtable_0[10795] = 10796;
		hashtable_0[10796] = 10795;
		hashtable_0[10797] = 10796;
		hashtable_0[10798] = 10797;
		hashtable_0[10804] = 10805;
		hashtable_0[10805] = 10804;
		hashtable_0[10812] = 10813;
		hashtable_0[10813] = 10812;
		hashtable_0[10852] = 10853;
		hashtable_0[10853] = 10852;
		hashtable_0[10873] = 10874;
		hashtable_0[10874] = 10873;
		hashtable_0[10877] = 10878;
		hashtable_0[10878] = 10877;
		hashtable_0[10879] = 10880;
		hashtable_0[10880] = 10879;
		hashtable_0[10881] = 10882;
		hashtable_0[10882] = 10881;
		hashtable_0[10883] = 10884;
		hashtable_0[10884] = 10883;
		hashtable_0[10891] = 10892;
		hashtable_0[10892] = 10891;
		hashtable_0[10897] = 10898;
		hashtable_0[10898] = 10897;
		hashtable_0[10899] = 10900;
		hashtable_0[10900] = 10899;
		hashtable_0[10901] = 10902;
		hashtable_0[10902] = 10901;
		hashtable_0[10903] = 10904;
		hashtable_0[10904] = 10903;
		hashtable_0[10905] = 10906;
		hashtable_0[10906] = 10905;
		hashtable_0[10907] = 10908;
		hashtable_0[10908] = 10907;
		hashtable_0[10913] = 10914;
		hashtable_0[10914] = 10913;
		hashtable_0[10918] = 10919;
		hashtable_0[10919] = 10918;
		hashtable_0[10920] = 10921;
		hashtable_0[10921] = 10920;
		hashtable_0[10922] = 10923;
		hashtable_0[10923] = 10922;
		hashtable_0[10924] = 10925;
		hashtable_0[10925] = 10924;
		hashtable_0[10927] = 10928;
		hashtable_0[10928] = 10927;
		hashtable_0[10931] = 10932;
		hashtable_0[10932] = 10931;
		hashtable_0[10939] = 10940;
		hashtable_0[10940] = 10939;
		hashtable_0[10941] = 10942;
		hashtable_0[10942] = 10941;
		hashtable_0[10943] = 10944;
		hashtable_0[10944] = 10943;
		hashtable_0[10945] = 10946;
		hashtable_0[10946] = 10945;
		hashtable_0[10947] = 10948;
		hashtable_0[10948] = 10947;
		hashtable_0[10949] = 10950;
		hashtable_0[10950] = 10949;
		hashtable_0[10957] = 10958;
		hashtable_0[10958] = 10957;
		hashtable_0[10959] = 10960;
		hashtable_0[10960] = 10959;
		hashtable_0[10961] = 10962;
		hashtable_0[10962] = 10961;
		hashtable_0[10963] = 10964;
		hashtable_0[10964] = 10963;
		hashtable_0[10965] = 10966;
		hashtable_0[10966] = 10965;
		hashtable_0[10974] = 8870;
		hashtable_0[10979] = 8873;
		hashtable_0[10980] = 8872;
		hashtable_0[10981] = 8875;
		hashtable_0[10988] = 10989;
		hashtable_0[10989] = 10988;
		hashtable_0[10999] = 11000;
		hashtable_0[11000] = 10999;
		hashtable_0[11001] = 11002;
		hashtable_0[11002] = 11001;
		hashtable_0[12296] = 12297;
		hashtable_0[12297] = 12296;
		hashtable_0[12298] = 12299;
		hashtable_0[12299] = 12298;
		hashtable_0[12300] = 12301;
		hashtable_0[12301] = 12300;
		hashtable_0[12302] = 12303;
		hashtable_0[12303] = 12302;
		hashtable_0[12304] = 12305;
		hashtable_0[12305] = 12304;
		hashtable_0[12308] = 12309;
		hashtable_0[12309] = 12308;
		hashtable_0[12310] = 12311;
		hashtable_0[12311] = 12310;
		hashtable_0[12312] = 12313;
		hashtable_0[12313] = 12312;
		hashtable_0[12314] = 12315;
		hashtable_0[12315] = 12314;
		hashtable_0[65288] = 65289;
		hashtable_0[65289] = 65288;
		hashtable_0[65308] = 65310;
		hashtable_0[65310] = 65308;
		hashtable_0[65339] = 65341;
		hashtable_0[65341] = 65339;
		hashtable_0[65371] = 65373;
		hashtable_0[65373] = 65371;
		hashtable_0[65375] = 65376;
		hashtable_0[65376] = 65375;
		hashtable_0[65378] = 65379;
		hashtable_0[65379] = 65378;
	}
}
