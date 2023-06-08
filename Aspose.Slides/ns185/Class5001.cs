using System;
using System.Collections;
using ns184;

namespace ns185;

internal class Class5001 : Class4988
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

	private Class5681 class5681_0 = Class5681.smethod_0("ZapfDingbatsEncoding");

	static Class5001()
	{
		string_0 = "ZapfDingbats";
		string_1 = "ITC Zapf Dingbats";
		string_2 = "ZapfDingbatsEncoding";
		int_0 = 820;
		int_1 = 426;
		int_2 = 820;
		int_3 = -143;
		int_4 = 32;
		int_5 = 255;
		int_6 = new int[256];
		int_6[32] = 278;
		int_6[33] = 974;
		int_6[34] = 961;
		int_6[35] = 974;
		int_6[36] = 980;
		int_6[37] = 719;
		int_6[38] = 789;
		int_6[39] = 790;
		int_6[40] = 791;
		int_6[41] = 690;
		int_6[42] = 960;
		int_6[43] = 939;
		int_6[44] = 549;
		int_6[45] = 855;
		int_6[46] = 911;
		int_6[47] = 933;
		int_6[48] = 911;
		int_6[49] = 945;
		int_6[50] = 974;
		int_6[51] = 755;
		int_6[52] = 846;
		int_6[53] = 762;
		int_6[54] = 761;
		int_6[55] = 571;
		int_6[56] = 677;
		int_6[57] = 763;
		int_6[58] = 760;
		int_6[59] = 759;
		int_6[60] = 754;
		int_6[61] = 494;
		int_6[62] = 552;
		int_6[63] = 537;
		int_6[64] = 577;
		int_6[65] = 692;
		int_6[66] = 786;
		int_6[67] = 788;
		int_6[68] = 788;
		int_6[69] = 790;
		int_6[70] = 793;
		int_6[71] = 794;
		int_6[72] = 816;
		int_6[73] = 823;
		int_6[74] = 789;
		int_6[75] = 841;
		int_6[76] = 823;
		int_6[77] = 833;
		int_6[78] = 816;
		int_6[79] = 831;
		int_6[80] = 923;
		int_6[81] = 744;
		int_6[82] = 723;
		int_6[83] = 749;
		int_6[84] = 790;
		int_6[85] = 792;
		int_6[86] = 695;
		int_6[87] = 776;
		int_6[88] = 768;
		int_6[89] = 792;
		int_6[90] = 759;
		int_6[91] = 707;
		int_6[92] = 708;
		int_6[93] = 682;
		int_6[94] = 701;
		int_6[95] = 826;
		int_6[96] = 815;
		int_6[97] = 789;
		int_6[98] = 789;
		int_6[99] = 707;
		int_6[100] = 687;
		int_6[101] = 696;
		int_6[102] = 689;
		int_6[103] = 786;
		int_6[104] = 787;
		int_6[105] = 713;
		int_6[106] = 791;
		int_6[107] = 785;
		int_6[108] = 791;
		int_6[109] = 873;
		int_6[110] = 761;
		int_6[111] = 762;
		int_6[112] = 762;
		int_6[113] = 759;
		int_6[114] = 759;
		int_6[115] = 892;
		int_6[116] = 892;
		int_6[117] = 788;
		int_6[118] = 784;
		int_6[119] = 438;
		int_6[120] = 138;
		int_6[121] = 277;
		int_6[122] = 415;
		int_6[123] = 392;
		int_6[124] = 392;
		int_6[125] = 668;
		int_6[126] = 668;
		int_6[161] = 732;
		int_6[162] = 544;
		int_6[163] = 544;
		int_6[164] = 910;
		int_6[165] = 667;
		int_6[166] = 760;
		int_6[167] = 760;
		int_6[168] = 776;
		int_6[169] = 595;
		int_6[170] = 694;
		int_6[171] = 626;
		int_6[172] = 788;
		int_6[173] = 788;
		int_6[174] = 788;
		int_6[175] = 788;
		int_6[176] = 788;
		int_6[177] = 788;
		int_6[178] = 788;
		int_6[179] = 788;
		int_6[180] = 788;
		int_6[181] = 788;
		int_6[182] = 788;
		int_6[183] = 788;
		int_6[184] = 788;
		int_6[185] = 788;
		int_6[186] = 788;
		int_6[187] = 788;
		int_6[188] = 788;
		int_6[189] = 788;
		int_6[190] = 788;
		int_6[191] = 788;
		int_6[192] = 788;
		int_6[193] = 788;
		int_6[194] = 788;
		int_6[195] = 788;
		int_6[196] = 788;
		int_6[197] = 788;
		int_6[198] = 788;
		int_6[199] = 788;
		int_6[200] = 788;
		int_6[201] = 788;
		int_6[202] = 788;
		int_6[203] = 788;
		int_6[204] = 788;
		int_6[205] = 788;
		int_6[206] = 788;
		int_6[207] = 788;
		int_6[208] = 788;
		int_6[209] = 788;
		int_6[210] = 788;
		int_6[211] = 788;
		int_6[212] = 894;
		int_6[213] = 838;
		int_6[214] = 1016;
		int_6[215] = 458;
		int_6[216] = 748;
		int_6[217] = 924;
		int_6[218] = 748;
		int_6[219] = 918;
		int_6[220] = 927;
		int_6[221] = 928;
		int_6[222] = 928;
		int_6[223] = 834;
		int_6[224] = 873;
		int_6[225] = 828;
		int_6[226] = 924;
		int_6[227] = 924;
		int_6[228] = 917;
		int_6[229] = 930;
		int_6[230] = 931;
		int_6[231] = 463;
		int_6[232] = 883;
		int_6[233] = 836;
		int_6[234] = 836;
		int_6[235] = 867;
		int_6[236] = 867;
		int_6[237] = 696;
		int_6[238] = 696;
		int_6[239] = 874;
		int_6[241] = 874;
		int_6[242] = 760;
		int_6[243] = 946;
		int_6[244] = 771;
		int_6[245] = 865;
		int_6[246] = 771;
		int_6[247] = 888;
		int_6[248] = 967;
		int_6[249] = 888;
		int_6[250] = 831;
		int_6[251] = 873;
		int_6[252] = 927;
		int_6[253] = 970;
		int_6[254] = 918;
		int_6[137] = 410;
		int_6[135] = 509;
		int_6[140] = 334;
		int_6[134] = 509;
		int_6[128] = 390;
		int_6[138] = 234;
		int_6[132] = 276;
		int_6[129] = 390;
		int_6[136] = 410;
		int_6[131] = 317;
		int_6[130] = 317;
		int_6[133] = 276;
		int_6[141] = 334;
		int_6[139] = 234;
		arrayList_1 = new ArrayList();
		arrayList_1.Add("ZapfDingbats");
	}

	public Class5001()
		: this(enableKerning: false)
	{
	}

	public Class5001(bool enableKerning)
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
