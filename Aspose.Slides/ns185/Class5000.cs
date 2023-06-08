using System;
using System.Collections;
using ns184;

namespace ns185;

internal class Class5000 : Class4988
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

	private static Hashtable hashtable_0;

	private bool bool_0;

	static Class5000()
	{
		string_0 = "Times-Roman";
		string_1 = "Times Roman";
		string_2 = "WinAnsiEncoding";
		int_0 = 662;
		int_1 = 450;
		int_2 = 683;
		int_3 = -217;
		int_4 = 32;
		int_5 = 255;
		int_6 = new int[256];
		int_6[65] = 722;
		int_6[198] = 889;
		int_6[193] = 722;
		int_6[194] = 722;
		int_6[196] = 722;
		int_6[192] = 722;
		int_6[197] = 722;
		int_6[195] = 722;
		int_6[66] = 667;
		int_6[67] = 667;
		int_6[199] = 667;
		int_6[68] = 722;
		int_6[69] = 611;
		int_6[201] = 611;
		int_6[202] = 611;
		int_6[203] = 611;
		int_6[200] = 611;
		int_6[208] = 722;
		int_6[128] = 500;
		int_6[70] = 556;
		int_6[71] = 722;
		int_6[72] = 722;
		int_6[73] = 333;
		int_6[205] = 333;
		int_6[206] = 333;
		int_6[207] = 333;
		int_6[204] = 333;
		int_6[74] = 389;
		int_6[75] = 722;
		int_6[76] = 611;
		int_6[77] = 889;
		int_6[78] = 722;
		int_6[209] = 722;
		int_6[79] = 722;
		int_6[140] = 889;
		int_6[211] = 722;
		int_6[212] = 722;
		int_6[214] = 722;
		int_6[210] = 722;
		int_6[216] = 722;
		int_6[213] = 722;
		int_6[80] = 556;
		int_6[81] = 722;
		int_6[82] = 667;
		int_6[83] = 556;
		int_6[138] = 556;
		int_6[84] = 611;
		int_6[222] = 556;
		int_6[85] = 722;
		int_6[218] = 722;
		int_6[219] = 722;
		int_6[220] = 722;
		int_6[217] = 722;
		int_6[86] = 722;
		int_6[87] = 944;
		int_6[88] = 722;
		int_6[89] = 722;
		int_6[221] = 722;
		int_6[159] = 722;
		int_6[90] = 611;
		int_6[142] = 611;
		int_6[97] = 444;
		int_6[225] = 444;
		int_6[226] = 444;
		int_6[180] = 333;
		int_6[228] = 444;
		int_6[230] = 667;
		int_6[224] = 444;
		int_6[38] = 778;
		int_6[229] = 444;
		int_6[94] = 469;
		int_6[126] = 541;
		int_6[42] = 500;
		int_6[64] = 921;
		int_6[227] = 444;
		int_6[98] = 500;
		int_6[92] = 278;
		int_6[124] = 200;
		int_6[123] = 480;
		int_6[125] = 480;
		int_6[91] = 333;
		int_6[93] = 333;
		int_6[166] = 200;
		int_6[149] = 350;
		int_6[99] = 444;
		int_6[231] = 444;
		int_6[184] = 333;
		int_6[162] = 500;
		int_6[136] = 333;
		int_6[58] = 278;
		int_6[44] = 250;
		int_6[169] = 760;
		int_6[164] = 500;
		int_6[100] = 500;
		int_6[134] = 500;
		int_6[135] = 500;
		int_6[176] = 400;
		int_6[168] = 333;
		int_6[247] = 564;
		int_6[36] = 500;
		int_6[101] = 444;
		int_6[233] = 444;
		int_6[234] = 444;
		int_6[235] = 444;
		int_6[232] = 444;
		int_6[56] = 500;
		int_6[133] = 1000;
		int_6[151] = 1000;
		int_6[150] = 500;
		int_6[61] = 564;
		int_6[240] = 500;
		int_6[33] = 333;
		int_6[161] = 333;
		int_6[102] = 333;
		int_6[53] = 500;
		int_6[131] = 500;
		int_6[52] = 500;
		int_6[103] = 500;
		int_6[223] = 500;
		int_6[96] = 333;
		int_6[62] = 564;
		int_6[171] = 500;
		int_6[187] = 500;
		int_6[139] = 333;
		int_6[155] = 333;
		int_6[104] = 500;
		int_6[45] = 333;
		int_6[105] = 278;
		int_6[237] = 278;
		int_6[238] = 278;
		int_6[239] = 278;
		int_6[236] = 278;
		int_6[106] = 278;
		int_6[107] = 500;
		int_6[108] = 278;
		int_6[60] = 564;
		int_6[172] = 564;
		int_6[109] = 778;
		int_6[175] = 333;
		int_6[181] = 500;
		int_6[215] = 564;
		int_6[110] = 500;
		int_6[57] = 500;
		int_6[241] = 500;
		int_6[35] = 500;
		int_6[111] = 500;
		int_6[243] = 500;
		int_6[244] = 500;
		int_6[246] = 500;
		int_6[156] = 722;
		int_6[242] = 500;
		int_6[49] = 500;
		int_6[189] = 750;
		int_6[188] = 750;
		int_6[185] = 300;
		int_6[170] = 276;
		int_6[186] = 310;
		int_6[248] = 500;
		int_6[245] = 500;
		int_6[112] = 500;
		int_6[182] = 453;
		int_6[40] = 333;
		int_6[41] = 333;
		int_6[37] = 833;
		int_6[46] = 250;
		int_6[183] = 250;
		int_6[137] = 1000;
		int_6[43] = 564;
		int_6[177] = 564;
		int_6[113] = 500;
		int_6[63] = 444;
		int_6[191] = 444;
		int_6[34] = 408;
		int_6[132] = 444;
		int_6[147] = 444;
		int_6[148] = 444;
		int_6[145] = 333;
		int_6[146] = 333;
		int_6[130] = 333;
		int_6[39] = 180;
		int_6[114] = 333;
		int_6[174] = 760;
		int_6[115] = 389;
		int_6[154] = 389;
		int_6[167] = 500;
		int_6[59] = 278;
		int_6[55] = 500;
		int_6[54] = 500;
		int_6[47] = 278;
		int_6[32] = 250;
		int_6[163] = 500;
		int_6[116] = 278;
		int_6[254] = 500;
		int_6[51] = 500;
		int_6[190] = 750;
		int_6[179] = 300;
		int_6[152] = 333;
		int_6[153] = 980;
		int_6[50] = 500;
		int_6[178] = 300;
		int_6[117] = 500;
		int_6[250] = 500;
		int_6[251] = 500;
		int_6[252] = 500;
		int_6[249] = 500;
		int_6[95] = 500;
		int_6[118] = 500;
		int_6[119] = 722;
		int_6[120] = 500;
		int_6[121] = 500;
		int_6[253] = 500;
		int_6[255] = 500;
		int_6[165] = 500;
		int_6[122] = 444;
		int_6[158] = 444;
		int_6[48] = 500;
		hashtable_0 = new Hashtable();
		int num = 79;
		Hashtable hashtable = (Hashtable)hashtable_0[79];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -35);
		hashtable.Add(87, -35);
		hashtable.Add(89, -50);
		hashtable.Add(84, -40);
		hashtable.Add(46, 0);
		hashtable.Add(86, -50);
		hashtable.Add(88, -40);
		hashtable.Add(44, 0);
		num = 107;
		hashtable = (Hashtable)hashtable_0[107];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -10);
		hashtable.Add(121, -15);
		hashtable.Add(101, -10);
		num = 112;
		hashtable = (Hashtable)hashtable_0[112];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(121, -10);
		num = 80;
		hashtable = (Hashtable)hashtable_0[80];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, 0);
		hashtable.Add(97, -15);
		hashtable.Add(65, -92);
		hashtable.Add(46, -111);
		hashtable.Add(101, 0);
		hashtable.Add(44, -111);
		num = 86;
		hashtable = (Hashtable)hashtable_0[86];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -129);
		hashtable.Add(79, -40);
		hashtable.Add(58, -74);
		hashtable.Add(71, -15);
		hashtable.Add(44, -129);
		hashtable.Add(59, -74);
		hashtable.Add(45, -100);
		hashtable.Add(105, -60);
		hashtable.Add(65, -135);
		hashtable.Add(97, -111);
		hashtable.Add(117, -75);
		hashtable.Add(46, -129);
		hashtable.Add(101, -111);
		num = 118;
		hashtable = (Hashtable)hashtable_0[118];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -20);
		hashtable.Add(97, -25);
		hashtable.Add(46, -65);
		hashtable.Add(101, -15);
		hashtable.Add(44, -65);
		num = 32;
		hashtable = (Hashtable)hashtable_0[32];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -55);
		hashtable.Add(87, -30);
		hashtable.Add(147, 0);
		hashtable.Add(89, -90);
		hashtable.Add(84, -18);
		hashtable.Add(145, 0);
		hashtable.Add(86, -50);
		num = 97;
		hashtable = (Hashtable)hashtable_0[97];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(119, -15);
		hashtable.Add(116, 0);
		hashtable.Add(121, 0);
		hashtable.Add(112, 0);
		hashtable.Add(103, 0);
		hashtable.Add(98, 0);
		hashtable.Add(118, -20);
		num = 70;
		hashtable = (Hashtable)hashtable_0[70];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -15);
		hashtable.Add(105, 0);
		hashtable.Add(114, 0);
		hashtable.Add(97, -15);
		hashtable.Add(65, -74);
		hashtable.Add(46, -80);
		hashtable.Add(101, 0);
		hashtable.Add(44, -80);
		num = 85;
		hashtable = (Hashtable)hashtable_0[85];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -40);
		hashtable.Add(46, 0);
		hashtable.Add(44, 0);
		num = 100;
		hashtable = (Hashtable)hashtable_0[100];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(100, 0);
		hashtable.Add(119, 0);
		hashtable.Add(121, 0);
		hashtable.Add(46, 0);
		hashtable.Add(118, 0);
		hashtable.Add(44, 0);
		num = 83;
		hashtable = (Hashtable)hashtable_0[83];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(46, 0);
		hashtable.Add(44, 0);
		num = 122;
		hashtable = (Hashtable)hashtable_0[122];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, 0);
		hashtable.Add(101, 0);
		num = 68;
		hashtable = (Hashtable)hashtable_0[68];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -40);
		hashtable.Add(87, -30);
		hashtable.Add(89, -55);
		hashtable.Add(46, 0);
		hashtable.Add(86, -40);
		hashtable.Add(44, 0);
		num = 146;
		hashtable = (Hashtable)hashtable_0[146];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(148, 0);
		hashtable.Add(100, -50);
		hashtable.Add(32, -74);
		hashtable.Add(146, -74);
		hashtable.Add(114, -50);
		hashtable.Add(116, -18);
		hashtable.Add(108, -10);
		hashtable.Add(115, -55);
		hashtable.Add(118, -50);
		num = 58;
		hashtable = (Hashtable)hashtable_0[58];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(32, 0);
		num = 119;
		hashtable = (Hashtable)hashtable_0[119];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -10);
		hashtable.Add(97, -10);
		hashtable.Add(104, 0);
		hashtable.Add(46, -65);
		hashtable.Add(101, 0);
		hashtable.Add(44, -65);
		num = 75;
		hashtable = (Hashtable)hashtable_0[75];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -35);
		hashtable.Add(79, -30);
		hashtable.Add(117, -15);
		hashtable.Add(121, -25);
		hashtable.Add(101, -25);
		num = 82;
		hashtable = (Hashtable)hashtable_0[82];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(79, -40);
		hashtable.Add(87, -55);
		hashtable.Add(85, -40);
		hashtable.Add(89, -65);
		hashtable.Add(84, -60);
		hashtable.Add(86, -80);
		num = 145;
		hashtable = (Hashtable)hashtable_0[145];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -80);
		hashtable.Add(145, -74);
		num = 103;
		hashtable = (Hashtable)hashtable_0[103];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, 0);
		hashtable.Add(105, 0);
		hashtable.Add(114, 0);
		hashtable.Add(97, -5);
		hashtable.Add(121, 0);
		hashtable.Add(46, 0);
		hashtable.Add(103, 0);
		hashtable.Add(101, 0);
		hashtable.Add(44, 0);
		num = 66;
		hashtable = (Hashtable)hashtable_0[66];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -35);
		hashtable.Add(85, -10);
		hashtable.Add(46, 0);
		hashtable.Add(44, 0);
		num = 98;
		hashtable = (Hashtable)hashtable_0[98];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(117, -20);
		hashtable.Add(121, 0);
		hashtable.Add(46, -40);
		hashtable.Add(108, 0);
		hashtable.Add(98, 0);
		hashtable.Add(118, -15);
		hashtable.Add(44, 0);
		num = 81;
		hashtable = (Hashtable)hashtable_0[81];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(85, -10);
		hashtable.Add(46, 0);
		hashtable.Add(44, 0);
		num = 44;
		hashtable = (Hashtable)hashtable_0[44];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(148, -70);
		hashtable.Add(32, 0);
		hashtable.Add(146, -70);
		num = 102;
		hashtable = (Hashtable)hashtable_0[102];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(148, 0);
		hashtable.Add(111, 0);
		hashtable.Add(105, -20);
		hashtable.Add(146, 55);
		hashtable.Add(97, -10);
		hashtable.Add(102, -25);
		hashtable.Add(46, 0);
		hashtable.Add(108, 0);
		hashtable.Add(101, 0);
		hashtable.Add(44, 0);
		num = 84;
		hashtable = (Hashtable)hashtable_0[84];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -80);
		hashtable.Add(79, -18);
		hashtable.Add(119, -80);
		hashtable.Add(58, -50);
		hashtable.Add(114, -35);
		hashtable.Add(104, 0);
		hashtable.Add(44, -74);
		hashtable.Add(59, -55);
		hashtable.Add(45, -92);
		hashtable.Add(105, -35);
		hashtable.Add(65, -93);
		hashtable.Add(97, -80);
		hashtable.Add(117, -45);
		hashtable.Add(121, -80);
		hashtable.Add(46, -74);
		hashtable.Add(101, -70);
		num = 121;
		hashtable = (Hashtable)hashtable_0[121];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, 0);
		hashtable.Add(97, 0);
		hashtable.Add(46, -65);
		hashtable.Add(101, 0);
		hashtable.Add(44, -65);
		num = 120;
		hashtable = (Hashtable)hashtable_0[120];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(101, -15);
		num = 101;
		hashtable = (Hashtable)hashtable_0[101];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(119, -25);
		hashtable.Add(121, -15);
		hashtable.Add(112, 0);
		hashtable.Add(46, 0);
		hashtable.Add(103, -15);
		hashtable.Add(98, 0);
		hashtable.Add(120, -15);
		hashtable.Add(118, -25);
		hashtable.Add(44, 0);
		num = 99;
		hashtable = (Hashtable)hashtable_0[99];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(107, 0);
		hashtable.Add(104, 0);
		hashtable.Add(121, -15);
		hashtable.Add(46, 0);
		hashtable.Add(108, 0);
		hashtable.Add(44, 0);
		num = 87;
		hashtable = (Hashtable)hashtable_0[87];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -80);
		hashtable.Add(79, -10);
		hashtable.Add(58, -37);
		hashtable.Add(104, 0);
		hashtable.Add(44, -92);
		hashtable.Add(59, -37);
		hashtable.Add(45, -65);
		hashtable.Add(105, -40);
		hashtable.Add(65, -120);
		hashtable.Add(97, -80);
		hashtable.Add(117, -50);
		hashtable.Add(121, -73);
		hashtable.Add(46, -92);
		hashtable.Add(101, -80);
		num = 104;
		hashtable = (Hashtable)hashtable_0[104];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(121, -5);
		num = 71;
		hashtable = (Hashtable)hashtable_0[71];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(46, 0);
		hashtable.Add(44, 0);
		num = 105;
		hashtable = (Hashtable)hashtable_0[105];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(118, -25);
		num = 65;
		hashtable = (Hashtable)hashtable_0[65];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(79, -55);
		hashtable.Add(146, -111);
		hashtable.Add(119, -92);
		hashtable.Add(87, -90);
		hashtable.Add(67, -40);
		hashtable.Add(112, 0);
		hashtable.Add(81, -55);
		hashtable.Add(71, -40);
		hashtable.Add(86, -135);
		hashtable.Add(118, -74);
		hashtable.Add(148, 0);
		hashtable.Add(85, -55);
		hashtable.Add(117, 0);
		hashtable.Add(89, -105);
		hashtable.Add(121, -92);
		hashtable.Add(84, -111);
		num = 147;
		hashtable = (Hashtable)hashtable_0[147];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -80);
		hashtable.Add(145, 0);
		num = 78;
		hashtable = (Hashtable)hashtable_0[78];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -35);
		hashtable.Add(46, 0);
		hashtable.Add(44, 0);
		num = 115;
		hashtable = (Hashtable)hashtable_0[115];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(119, 0);
		num = 111;
		hashtable = (Hashtable)hashtable_0[111];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(119, -25);
		hashtable.Add(121, -10);
		hashtable.Add(103, 0);
		hashtable.Add(120, 0);
		hashtable.Add(118, -15);
		num = 114;
		hashtable = (Hashtable)hashtable_0[114];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, 0);
		hashtable.Add(100, 0);
		hashtable.Add(107, 0);
		hashtable.Add(114, 0);
		hashtable.Add(99, 0);
		hashtable.Add(112, 0);
		hashtable.Add(103, -18);
		hashtable.Add(108, 0);
		hashtable.Add(113, 0);
		hashtable.Add(118, 0);
		hashtable.Add(44, -40);
		hashtable.Add(45, -20);
		hashtable.Add(105, 0);
		hashtable.Add(109, 0);
		hashtable.Add(97, 0);
		hashtable.Add(117, 0);
		hashtable.Add(116, 0);
		hashtable.Add(121, 0);
		hashtable.Add(46, -55);
		hashtable.Add(110, 0);
		hashtable.Add(115, 0);
		hashtable.Add(101, 0);
		num = 108;
		hashtable = (Hashtable)hashtable_0[108];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(119, -10);
		hashtable.Add(121, 0);
		num = 76;
		hashtable = (Hashtable)hashtable_0[76];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(148, 0);
		hashtable.Add(146, -92);
		hashtable.Add(87, -74);
		hashtable.Add(89, -100);
		hashtable.Add(121, -55);
		hashtable.Add(84, -92);
		hashtable.Add(86, -100);
		num = 148;
		hashtable = (Hashtable)hashtable_0[148];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(32, 0);
		num = 109;
		hashtable = (Hashtable)hashtable_0[109];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(117, 0);
		hashtable.Add(121, 0);
		num = 89;
		hashtable = (Hashtable)hashtable_0[89];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -110);
		hashtable.Add(45, -111);
		hashtable.Add(105, -55);
		hashtable.Add(79, -30);
		hashtable.Add(58, -92);
		hashtable.Add(97, -100);
		hashtable.Add(65, -120);
		hashtable.Add(117, -111);
		hashtable.Add(46, -129);
		hashtable.Add(101, -100);
		hashtable.Add(59, -92);
		hashtable.Add(44, -129);
		num = 74;
		hashtable = (Hashtable)hashtable_0[74];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, 0);
		hashtable.Add(97, 0);
		hashtable.Add(65, -60);
		hashtable.Add(117, 0);
		hashtable.Add(46, 0);
		hashtable.Add(101, 0);
		hashtable.Add(44, 0);
		num = 46;
		hashtable = (Hashtable)hashtable_0[46];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(148, -70);
		hashtable.Add(146, -70);
		num = 110;
		hashtable = (Hashtable)hashtable_0[110];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(117, 0);
		hashtable.Add(121, -15);
		hashtable.Add(118, -40);
		arrayList_1 = new ArrayList();
		arrayList_1.Add("Times");
	}

	public Class5000()
		: this(enableKerning: false)
	{
	}

	public Class5000(bool enableKerning)
	{
		bool_0 = enableKerning;
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
		return bool_0;
	}

	public override Hashtable imethod_13()
	{
		return hashtable_0;
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
