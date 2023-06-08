using System;
using System.Collections;
using ns184;

namespace ns185;

internal class Class4996 : Class4988
{
	private static string string_0;

	private static string string_1;

	private static ArrayList arrayList_1;

	private static string string_2;

	private static int int_0;

	private static int int_1;

	private static int int_2;

	private static int int_3;

	private static int int_4;

	private static int int_5;

	private static int[] int_6;

	private Class5681 class5681_0 = Class5681.smethod_0("SymbolEncoding");

	static Class4996()
	{
		string_0 = "Symbol";
		string_1 = "Symbol";
		string_2 = "SymbolEncoding";
		int_0 = 1010;
		int_1 = 520;
		int_2 = 1010;
		int_3 = -293;
		int_4 = 32;
		int_5 = 255;
		int_6 = new int[256];
		int_6[32] = 250;
		int_6[33] = 333;
		int_6[34] = 713;
		int_6[35] = 500;
		int_6[36] = 549;
		int_6[37] = 833;
		int_6[38] = 778;
		int_6[39] = 439;
		int_6[40] = 333;
		int_6[41] = 333;
		int_6[42] = 500;
		int_6[43] = 549;
		int_6[44] = 250;
		int_6[45] = 549;
		int_6[46] = 250;
		int_6[47] = 278;
		int_6[48] = 500;
		int_6[49] = 500;
		int_6[50] = 500;
		int_6[51] = 500;
		int_6[52] = 500;
		int_6[53] = 500;
		int_6[54] = 500;
		int_6[55] = 500;
		int_6[56] = 500;
		int_6[57] = 500;
		int_6[58] = 278;
		int_6[59] = 278;
		int_6[60] = 549;
		int_6[61] = 549;
		int_6[62] = 549;
		int_6[63] = 444;
		int_6[64] = 549;
		int_6[65] = 722;
		int_6[66] = 667;
		int_6[67] = 722;
		int_6[68] = 612;
		int_6[69] = 611;
		int_6[70] = 763;
		int_6[71] = 603;
		int_6[72] = 722;
		int_6[73] = 333;
		int_6[74] = 631;
		int_6[75] = 722;
		int_6[76] = 686;
		int_6[77] = 889;
		int_6[78] = 722;
		int_6[79] = 722;
		int_6[80] = 768;
		int_6[81] = 741;
		int_6[82] = 556;
		int_6[83] = 592;
		int_6[84] = 611;
		int_6[85] = 690;
		int_6[86] = 439;
		int_6[87] = 768;
		int_6[88] = 645;
		int_6[89] = 795;
		int_6[90] = 611;
		int_6[91] = 333;
		int_6[92] = 863;
		int_6[93] = 333;
		int_6[94] = 658;
		int_6[95] = 500;
		int_6[96] = 500;
		int_6[97] = 631;
		int_6[98] = 549;
		int_6[99] = 549;
		int_6[100] = 494;
		int_6[101] = 439;
		int_6[102] = 521;
		int_6[103] = 411;
		int_6[104] = 603;
		int_6[105] = 329;
		int_6[106] = 603;
		int_6[107] = 549;
		int_6[108] = 549;
		int_6[109] = 576;
		int_6[110] = 521;
		int_6[111] = 549;
		int_6[112] = 549;
		int_6[113] = 521;
		int_6[114] = 549;
		int_6[115] = 603;
		int_6[116] = 439;
		int_6[117] = 576;
		int_6[118] = 713;
		int_6[119] = 686;
		int_6[120] = 493;
		int_6[121] = 686;
		int_6[122] = 494;
		int_6[123] = 480;
		int_6[124] = 200;
		int_6[125] = 480;
		int_6[126] = 549;
		int_6[160] = 750;
		int_6[161] = 620;
		int_6[162] = 247;
		int_6[163] = 549;
		int_6[164] = 167;
		int_6[165] = 713;
		int_6[166] = 500;
		int_6[167] = 753;
		int_6[168] = 753;
		int_6[169] = 753;
		int_6[170] = 753;
		int_6[171] = 1042;
		int_6[172] = 987;
		int_6[173] = 603;
		int_6[174] = 987;
		int_6[175] = 603;
		int_6[176] = 400;
		int_6[177] = 549;
		int_6[178] = 411;
		int_6[179] = 549;
		int_6[180] = 549;
		int_6[181] = 713;
		int_6[182] = 494;
		int_6[183] = 460;
		int_6[184] = 549;
		int_6[185] = 549;
		int_6[186] = 549;
		int_6[187] = 549;
		int_6[188] = 1000;
		int_6[189] = 603;
		int_6[190] = 1000;
		int_6[191] = 658;
		int_6[192] = 823;
		int_6[193] = 686;
		int_6[194] = 795;
		int_6[195] = 987;
		int_6[196] = 768;
		int_6[197] = 768;
		int_6[198] = 823;
		int_6[199] = 768;
		int_6[200] = 768;
		int_6[201] = 713;
		int_6[202] = 713;
		int_6[203] = 713;
		int_6[204] = 713;
		int_6[205] = 713;
		int_6[206] = 713;
		int_6[207] = 713;
		int_6[208] = 768;
		int_6[209] = 713;
		int_6[210] = 790;
		int_6[211] = 790;
		int_6[212] = 890;
		int_6[213] = 823;
		int_6[214] = 549;
		int_6[215] = 250;
		int_6[216] = 713;
		int_6[217] = 603;
		int_6[218] = 603;
		int_6[219] = 1042;
		int_6[220] = 987;
		int_6[221] = 603;
		int_6[222] = 987;
		int_6[223] = 603;
		int_6[224] = 494;
		int_6[225] = 329;
		int_6[226] = 790;
		int_6[227] = 790;
		int_6[228] = 786;
		int_6[229] = 713;
		int_6[230] = 384;
		int_6[231] = 384;
		int_6[232] = 384;
		int_6[233] = 384;
		int_6[234] = 384;
		int_6[235] = 384;
		int_6[236] = 494;
		int_6[237] = 494;
		int_6[238] = 494;
		int_6[239] = 494;
		int_6[241] = 329;
		int_6[242] = 274;
		int_6[243] = 686;
		int_6[244] = 686;
		int_6[245] = 686;
		int_6[246] = 384;
		int_6[247] = 384;
		int_6[248] = 384;
		int_6[249] = 384;
		int_6[250] = 384;
		int_6[251] = 384;
		int_6[252] = 494;
		int_6[253] = 494;
		int_6[254] = 494;
		arrayList_1 = new ArrayList();
		arrayList_1.Add("Symbol");
	}

	public Class4996()
		: this(enableKerning: false)
	{
	}

	public Class4996(bool enableKerning)
	{
	}

	public override string vmethod_0()
	{
		return string_2;
	}

	public override string imethod_0()
	{
		return string_0;
	}

	public override string imethod_3()
	{
		return imethod_0();
	}

	public override string imethod_1()
	{
		return string_1;
	}

	public override ArrayList imethod_2()
	{
		return arrayList_1;
	}

	public override Class5733 imethod_4()
	{
		return Class5733.class5733_2;
	}

	public override int imethod_6(int size)
	{
		return size * int_2;
	}

	public override int imethod_7(int size)
	{
		return size * int_0;
	}

	public override int imethod_8(int size)
	{
		return size * int_3;
	}

	public override int imethod_9(int size)
	{
		return size * int_1;
	}

	public int method_5()
	{
		return int_4;
	}

	public int method_6()
	{
		return int_5;
	}

	public override int imethod_10(int i, int size)
	{
		return size * int_6[i];
	}

	public override int[] imethod_11()
	{
		int[] array = new int[method_6() - method_5() + 1];
		Array.Copy(int_6, method_5(), array, 0, method_6() - method_5() + 1);
		return array;
	}

	public override bool imethod_12()
	{
		return false;
	}

	public override Hashtable imethod_13()
	{
		return new Hashtable();
	}

	public override char vmethod_1(char c)
	{
		method_0();
		char c2 = class5681_0.imethod_1(c);
		if (c2 != 0)
		{
			return c2;
		}
		method_4(c);
		return Class4986.char_0;
	}

	public override bool vmethod_2(char c)
	{
		return class5681_0.imethod_1(c) > '\0';
	}
}
