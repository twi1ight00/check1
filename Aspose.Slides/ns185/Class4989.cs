using System;
using System.Collections;
using ns184;

namespace ns185;

internal class Class4989 : Class4988
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

	private Class5681 class5681_0 = Class5681.smethod_0("WinAnsiEncoding");

	static Class4989()
	{
		string_0 = "Courier";
		string_1 = "Courier";
		string_2 = "WinAnsiEncoding";
		int_0 = 562;
		int_1 = 426;
		int_2 = 629;
		int_3 = -157;
		int_4 = 32;
		int_5 = 255;
		int_6 = new int[256];
		int_6[65] = 600;
		int_6[198] = 600;
		int_6[193] = 600;
		int_6[194] = 600;
		int_6[196] = 600;
		int_6[192] = 600;
		int_6[197] = 600;
		int_6[195] = 600;
		int_6[66] = 600;
		int_6[67] = 600;
		int_6[199] = 600;
		int_6[68] = 600;
		int_6[69] = 600;
		int_6[201] = 600;
		int_6[202] = 600;
		int_6[203] = 600;
		int_6[200] = 600;
		int_6[208] = 600;
		int_6[128] = 600;
		int_6[70] = 600;
		int_6[71] = 600;
		int_6[72] = 600;
		int_6[73] = 600;
		int_6[205] = 600;
		int_6[206] = 600;
		int_6[207] = 600;
		int_6[204] = 600;
		int_6[74] = 600;
		int_6[75] = 600;
		int_6[76] = 600;
		int_6[77] = 600;
		int_6[78] = 600;
		int_6[209] = 600;
		int_6[79] = 600;
		int_6[140] = 600;
		int_6[211] = 600;
		int_6[212] = 600;
		int_6[214] = 600;
		int_6[210] = 600;
		int_6[216] = 600;
		int_6[213] = 600;
		int_6[80] = 600;
		int_6[81] = 600;
		int_6[82] = 600;
		int_6[83] = 600;
		int_6[138] = 600;
		int_6[84] = 600;
		int_6[222] = 600;
		int_6[85] = 600;
		int_6[218] = 600;
		int_6[219] = 600;
		int_6[220] = 600;
		int_6[217] = 600;
		int_6[86] = 600;
		int_6[87] = 600;
		int_6[88] = 600;
		int_6[89] = 600;
		int_6[221] = 600;
		int_6[159] = 600;
		int_6[90] = 600;
		int_6[142] = 600;
		int_6[97] = 600;
		int_6[225] = 600;
		int_6[226] = 600;
		int_6[180] = 600;
		int_6[228] = 600;
		int_6[230] = 600;
		int_6[224] = 600;
		int_6[38] = 600;
		int_6[229] = 600;
		int_6[94] = 600;
		int_6[126] = 600;
		int_6[42] = 600;
		int_6[64] = 600;
		int_6[227] = 600;
		int_6[98] = 600;
		int_6[92] = 600;
		int_6[124] = 600;
		int_6[123] = 600;
		int_6[125] = 600;
		int_6[91] = 600;
		int_6[93] = 600;
		int_6[166] = 600;
		int_6[149] = 600;
		int_6[99] = 600;
		int_6[231] = 600;
		int_6[184] = 600;
		int_6[162] = 600;
		int_6[136] = 600;
		int_6[58] = 600;
		int_6[44] = 600;
		int_6[169] = 600;
		int_6[164] = 600;
		int_6[100] = 600;
		int_6[134] = 600;
		int_6[135] = 600;
		int_6[176] = 600;
		int_6[168] = 600;
		int_6[247] = 600;
		int_6[36] = 600;
		int_6[101] = 600;
		int_6[233] = 600;
		int_6[234] = 600;
		int_6[235] = 600;
		int_6[232] = 600;
		int_6[56] = 600;
		int_6[133] = 600;
		int_6[151] = 600;
		int_6[150] = 600;
		int_6[61] = 600;
		int_6[240] = 600;
		int_6[33] = 600;
		int_6[161] = 600;
		int_6[102] = 600;
		int_6[53] = 600;
		int_6[131] = 600;
		int_6[52] = 600;
		int_6[103] = 600;
		int_6[223] = 600;
		int_6[96] = 600;
		int_6[62] = 600;
		int_6[171] = 600;
		int_6[187] = 600;
		int_6[139] = 600;
		int_6[155] = 600;
		int_6[104] = 600;
		int_6[45] = 600;
		int_6[105] = 600;
		int_6[237] = 600;
		int_6[238] = 600;
		int_6[239] = 600;
		int_6[236] = 600;
		int_6[106] = 600;
		int_6[107] = 600;
		int_6[108] = 600;
		int_6[60] = 600;
		int_6[172] = 600;
		int_6[109] = 600;
		int_6[175] = 600;
		int_6[181] = 600;
		int_6[215] = 600;
		int_6[110] = 600;
		int_6[57] = 600;
		int_6[241] = 600;
		int_6[35] = 600;
		int_6[111] = 600;
		int_6[243] = 600;
		int_6[244] = 600;
		int_6[246] = 600;
		int_6[156] = 600;
		int_6[242] = 600;
		int_6[49] = 600;
		int_6[189] = 600;
		int_6[188] = 600;
		int_6[185] = 600;
		int_6[170] = 600;
		int_6[186] = 600;
		int_6[248] = 600;
		int_6[245] = 600;
		int_6[112] = 600;
		int_6[182] = 600;
		int_6[40] = 600;
		int_6[41] = 600;
		int_6[37] = 600;
		int_6[46] = 600;
		int_6[183] = 600;
		int_6[137] = 600;
		int_6[43] = 600;
		int_6[177] = 600;
		int_6[113] = 600;
		int_6[63] = 600;
		int_6[191] = 600;
		int_6[34] = 600;
		int_6[132] = 600;
		int_6[147] = 600;
		int_6[148] = 600;
		int_6[145] = 600;
		int_6[146] = 600;
		int_6[130] = 600;
		int_6[39] = 600;
		int_6[114] = 600;
		int_6[174] = 600;
		int_6[115] = 600;
		int_6[154] = 600;
		int_6[167] = 600;
		int_6[59] = 600;
		int_6[55] = 600;
		int_6[54] = 600;
		int_6[47] = 600;
		int_6[32] = 600;
		int_6[163] = 600;
		int_6[116] = 600;
		int_6[254] = 600;
		int_6[51] = 600;
		int_6[190] = 600;
		int_6[179] = 600;
		int_6[152] = 600;
		int_6[153] = 600;
		int_6[50] = 600;
		int_6[178] = 600;
		int_6[117] = 600;
		int_6[250] = 600;
		int_6[251] = 600;
		int_6[252] = 600;
		int_6[249] = 600;
		int_6[95] = 600;
		int_6[118] = 600;
		int_6[119] = 600;
		int_6[120] = 600;
		int_6[121] = 600;
		int_6[253] = 600;
		int_6[255] = 600;
		int_6[165] = 600;
		int_6[122] = 600;
		int_6[158] = 600;
		int_6[48] = 600;
		arrayList_1 = new ArrayList();
		arrayList_1.Add("Courier");
	}

	public Class4989()
		: this(enableKerning: false)
	{
	}

	public Class4989(bool enableKerning)
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
