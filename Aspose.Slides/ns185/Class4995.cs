using System;
using System.Collections;
using ns184;

namespace ns185;

internal class Class4995 : Class4988
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

	static Class4995()
	{
		string_0 = "Helvetica-Oblique";
		string_1 = "Helvetica Oblique";
		string_2 = "WinAnsiEncoding";
		int_0 = 718;
		int_1 = 523;
		int_2 = 718;
		int_3 = -207;
		int_4 = 32;
		int_5 = 255;
		int_6 = new int[256];
		int_6[65] = 667;
		int_6[198] = 1000;
		int_6[193] = 667;
		int_6[194] = 667;
		int_6[196] = 667;
		int_6[192] = 667;
		int_6[197] = 667;
		int_6[195] = 667;
		int_6[66] = 667;
		int_6[67] = 722;
		int_6[199] = 722;
		int_6[68] = 722;
		int_6[69] = 667;
		int_6[201] = 667;
		int_6[202] = 667;
		int_6[203] = 667;
		int_6[200] = 667;
		int_6[208] = 722;
		int_6[128] = 556;
		int_6[70] = 611;
		int_6[71] = 778;
		int_6[72] = 722;
		int_6[73] = 278;
		int_6[205] = 278;
		int_6[206] = 278;
		int_6[207] = 278;
		int_6[204] = 278;
		int_6[74] = 500;
		int_6[75] = 667;
		int_6[76] = 556;
		int_6[77] = 833;
		int_6[78] = 722;
		int_6[209] = 722;
		int_6[79] = 778;
		int_6[140] = 1000;
		int_6[211] = 778;
		int_6[212] = 778;
		int_6[214] = 778;
		int_6[210] = 778;
		int_6[216] = 778;
		int_6[213] = 778;
		int_6[80] = 667;
		int_6[81] = 778;
		int_6[82] = 722;
		int_6[83] = 667;
		int_6[138] = 667;
		int_6[84] = 611;
		int_6[222] = 667;
		int_6[85] = 722;
		int_6[218] = 722;
		int_6[219] = 722;
		int_6[220] = 722;
		int_6[217] = 722;
		int_6[86] = 667;
		int_6[87] = 944;
		int_6[88] = 667;
		int_6[89] = 667;
		int_6[221] = 667;
		int_6[159] = 667;
		int_6[90] = 611;
		int_6[142] = 611;
		int_6[97] = 556;
		int_6[225] = 556;
		int_6[226] = 556;
		int_6[180] = 333;
		int_6[228] = 556;
		int_6[230] = 889;
		int_6[224] = 556;
		int_6[38] = 667;
		int_6[229] = 556;
		int_6[94] = 469;
		int_6[126] = 584;
		int_6[42] = 389;
		int_6[64] = 1015;
		int_6[227] = 556;
		int_6[98] = 556;
		int_6[92] = 278;
		int_6[124] = 260;
		int_6[123] = 334;
		int_6[125] = 334;
		int_6[91] = 278;
		int_6[93] = 278;
		int_6[166] = 260;
		int_6[149] = 350;
		int_6[99] = 500;
		int_6[231] = 500;
		int_6[184] = 333;
		int_6[162] = 556;
		int_6[136] = 333;
		int_6[58] = 278;
		int_6[44] = 278;
		int_6[169] = 737;
		int_6[164] = 556;
		int_6[100] = 556;
		int_6[134] = 556;
		int_6[135] = 556;
		int_6[176] = 400;
		int_6[168] = 333;
		int_6[247] = 584;
		int_6[36] = 556;
		int_6[101] = 556;
		int_6[233] = 556;
		int_6[234] = 556;
		int_6[235] = 556;
		int_6[232] = 556;
		int_6[56] = 556;
		int_6[133] = 1000;
		int_6[151] = 1000;
		int_6[150] = 556;
		int_6[61] = 584;
		int_6[240] = 556;
		int_6[33] = 278;
		int_6[161] = 333;
		int_6[102] = 278;
		int_6[53] = 556;
		int_6[131] = 556;
		int_6[52] = 556;
		int_6[103] = 556;
		int_6[223] = 611;
		int_6[96] = 333;
		int_6[62] = 584;
		int_6[171] = 556;
		int_6[187] = 556;
		int_6[139] = 333;
		int_6[155] = 333;
		int_6[104] = 556;
		int_6[45] = 333;
		int_6[105] = 222;
		int_6[237] = 278;
		int_6[238] = 278;
		int_6[239] = 278;
		int_6[236] = 278;
		int_6[106] = 222;
		int_6[107] = 500;
		int_6[108] = 222;
		int_6[60] = 584;
		int_6[172] = 584;
		int_6[109] = 833;
		int_6[175] = 333;
		int_6[181] = 556;
		int_6[215] = 584;
		int_6[110] = 556;
		int_6[57] = 556;
		int_6[241] = 556;
		int_6[35] = 556;
		int_6[111] = 556;
		int_6[243] = 556;
		int_6[244] = 556;
		int_6[246] = 556;
		int_6[156] = 944;
		int_6[242] = 556;
		int_6[49] = 556;
		int_6[189] = 834;
		int_6[188] = 834;
		int_6[185] = 333;
		int_6[170] = 370;
		int_6[186] = 365;
		int_6[248] = 611;
		int_6[245] = 556;
		int_6[112] = 556;
		int_6[182] = 537;
		int_6[40] = 333;
		int_6[41] = 333;
		int_6[37] = 889;
		int_6[46] = 278;
		int_6[183] = 278;
		int_6[137] = 1000;
		int_6[43] = 584;
		int_6[177] = 584;
		int_6[113] = 556;
		int_6[63] = 556;
		int_6[191] = 611;
		int_6[34] = 355;
		int_6[132] = 333;
		int_6[147] = 333;
		int_6[148] = 333;
		int_6[145] = 222;
		int_6[146] = 222;
		int_6[130] = 222;
		int_6[39] = 191;
		int_6[114] = 333;
		int_6[174] = 737;
		int_6[115] = 500;
		int_6[154] = 500;
		int_6[167] = 556;
		int_6[59] = 278;
		int_6[55] = 556;
		int_6[54] = 556;
		int_6[47] = 278;
		int_6[32] = 278;
		int_6[163] = 556;
		int_6[116] = 278;
		int_6[254] = 556;
		int_6[51] = 556;
		int_6[190] = 834;
		int_6[179] = 333;
		int_6[152] = 333;
		int_6[153] = 1000;
		int_6[50] = 556;
		int_6[178] = 333;
		int_6[117] = 556;
		int_6[250] = 556;
		int_6[251] = 556;
		int_6[252] = 556;
		int_6[249] = 556;
		int_6[95] = 556;
		int_6[118] = 500;
		int_6[119] = 722;
		int_6[120] = 500;
		int_6[121] = 500;
		int_6[253] = 500;
		int_6[255] = 500;
		int_6[165] = 556;
		int_6[122] = 500;
		int_6[158] = 500;
		int_6[48] = 556;
		hashtable_0 = new Hashtable();
		int num = 107;
		Hashtable hashtable = (Hashtable)hashtable_0[107];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -20);
		hashtable.Add(101, -20);
		num = 79;
		hashtable = (Hashtable)hashtable_0[79];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -20);
		hashtable.Add(87, -30);
		hashtable.Add(89, -70);
		hashtable.Add(84, -40);
		hashtable.Add(46, -40);
		hashtable.Add(86, -50);
		hashtable.Add(88, -60);
		hashtable.Add(44, -40);
		num = 104;
		hashtable = (Hashtable)hashtable_0[104];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(121, -30);
		num = 87;
		hashtable = (Hashtable)hashtable_0[87];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -30);
		hashtable.Add(45, -40);
		hashtable.Add(79, -20);
		hashtable.Add(97, -40);
		hashtable.Add(65, -50);
		hashtable.Add(117, -30);
		hashtable.Add(121, -20);
		hashtable.Add(46, -80);
		hashtable.Add(101, -30);
		hashtable.Add(44, -80);
		num = 99;
		hashtable = (Hashtable)hashtable_0[99];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(107, -20);
		hashtable.Add(44, -15);
		num = 112;
		hashtable = (Hashtable)hashtable_0[112];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(121, -30);
		hashtable.Add(46, -35);
		hashtable.Add(44, -35);
		num = 80;
		hashtable = (Hashtable)hashtable_0[80];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -50);
		hashtable.Add(97, -40);
		hashtable.Add(65, -120);
		hashtable.Add(46, -180);
		hashtable.Add(101, -50);
		hashtable.Add(44, -180);
		num = 86;
		hashtable = (Hashtable)hashtable_0[86];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -80);
		hashtable.Add(45, -80);
		hashtable.Add(79, -40);
		hashtable.Add(58, -40);
		hashtable.Add(97, -70);
		hashtable.Add(65, -80);
		hashtable.Add(117, -70);
		hashtable.Add(46, -125);
		hashtable.Add(71, -40);
		hashtable.Add(101, -80);
		hashtable.Add(59, -40);
		hashtable.Add(44, -125);
		num = 118;
		hashtable = (Hashtable)hashtable_0[118];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -25);
		hashtable.Add(97, -25);
		hashtable.Add(46, -80);
		hashtable.Add(101, -25);
		hashtable.Add(44, -80);
		num = 59;
		hashtable = (Hashtable)hashtable_0[59];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(32, -50);
		num = 32;
		hashtable = (Hashtable)hashtable_0[32];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(87, -40);
		hashtable.Add(147, -30);
		hashtable.Add(89, -90);
		hashtable.Add(84, -50);
		hashtable.Add(145, -60);
		hashtable.Add(86, -50);
		num = 97;
		hashtable = (Hashtable)hashtable_0[97];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(119, -20);
		hashtable.Add(121, -30);
		hashtable.Add(118, -20);
		num = 65;
		hashtable = (Hashtable)hashtable_0[65];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(79, -30);
		hashtable.Add(119, -40);
		hashtable.Add(87, -50);
		hashtable.Add(67, -30);
		hashtable.Add(81, -30);
		hashtable.Add(71, -30);
		hashtable.Add(86, -70);
		hashtable.Add(118, -40);
		hashtable.Add(85, -50);
		hashtable.Add(117, -30);
		hashtable.Add(89, -100);
		hashtable.Add(84, -120);
		hashtable.Add(121, -40);
		num = 70;
		hashtable = (Hashtable)hashtable_0[70];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -30);
		hashtable.Add(114, -45);
		hashtable.Add(97, -50);
		hashtable.Add(65, -80);
		hashtable.Add(46, -150);
		hashtable.Add(101, -30);
		hashtable.Add(44, -150);
		num = 85;
		hashtable = (Hashtable)hashtable_0[85];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -40);
		hashtable.Add(46, -40);
		hashtable.Add(44, -40);
		num = 115;
		hashtable = (Hashtable)hashtable_0[115];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(119, -30);
		hashtable.Add(46, -15);
		hashtable.Add(44, -15);
		num = 122;
		hashtable = (Hashtable)hashtable_0[122];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -15);
		hashtable.Add(101, -15);
		num = 83;
		hashtable = (Hashtable)hashtable_0[83];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(46, -20);
		hashtable.Add(44, -20);
		num = 111;
		hashtable = (Hashtable)hashtable_0[111];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(119, -15);
		hashtable.Add(121, -30);
		hashtable.Add(46, -40);
		hashtable.Add(120, -30);
		hashtable.Add(118, -15);
		hashtable.Add(44, -40);
		num = 68;
		hashtable = (Hashtable)hashtable_0[68];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(65, -40);
		hashtable.Add(87, -40);
		hashtable.Add(89, -90);
		hashtable.Add(46, -70);
		hashtable.Add(86, -70);
		hashtable.Add(44, -70);
		num = 146;
		hashtable = (Hashtable)hashtable_0[146];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(100, -50);
		hashtable.Add(32, -70);
		hashtable.Add(146, -57);
		hashtable.Add(114, -50);
		hashtable.Add(115, -50);
		num = 82;
		hashtable = (Hashtable)hashtable_0[82];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(79, -20);
		hashtable.Add(87, -30);
		hashtable.Add(85, -40);
		hashtable.Add(89, -50);
		hashtable.Add(84, -30);
		hashtable.Add(86, -50);
		num = 75;
		hashtable = (Hashtable)hashtable_0[75];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -40);
		hashtable.Add(79, -50);
		hashtable.Add(117, -30);
		hashtable.Add(121, -50);
		hashtable.Add(101, -40);
		num = 119;
		hashtable = (Hashtable)hashtable_0[119];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -10);
		hashtable.Add(97, -15);
		hashtable.Add(46, -60);
		hashtable.Add(101, -10);
		hashtable.Add(44, -60);
		num = 58;
		hashtable = (Hashtable)hashtable_0[58];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(32, -50);
		num = 114;
		hashtable = (Hashtable)hashtable_0[114];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(107, 15);
		hashtable.Add(58, 30);
		hashtable.Add(112, 30);
		hashtable.Add(108, 15);
		hashtable.Add(118, 30);
		hashtable.Add(44, -50);
		hashtable.Add(59, 30);
		hashtable.Add(105, 15);
		hashtable.Add(109, 25);
		hashtable.Add(97, -10);
		hashtable.Add(117, 15);
		hashtable.Add(116, 40);
		hashtable.Add(121, 30);
		hashtable.Add(46, -50);
		hashtable.Add(110, 25);
		num = 67;
		hashtable = (Hashtable)hashtable_0[67];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(46, -30);
		hashtable.Add(44, -30);
		num = 145;
		hashtable = (Hashtable)hashtable_0[145];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(145, -57);
		num = 103;
		hashtable = (Hashtable)hashtable_0[103];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(114, -10);
		num = 66;
		hashtable = (Hashtable)hashtable_0[66];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(85, -10);
		hashtable.Add(46, -20);
		hashtable.Add(44, -20);
		num = 81;
		hashtable = (Hashtable)hashtable_0[81];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(85, -10);
		num = 76;
		hashtable = (Hashtable)hashtable_0[76];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(148, -140);
		hashtable.Add(146, -160);
		hashtable.Add(87, -70);
		hashtable.Add(89, -140);
		hashtable.Add(121, -30);
		hashtable.Add(84, -110);
		hashtable.Add(86, -110);
		num = 98;
		hashtable = (Hashtable)hashtable_0[98];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(117, -20);
		hashtable.Add(121, -20);
		hashtable.Add(46, -40);
		hashtable.Add(108, -20);
		hashtable.Add(98, -10);
		hashtable.Add(118, -20);
		hashtable.Add(44, -40);
		num = 44;
		hashtable = (Hashtable)hashtable_0[44];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(148, -100);
		hashtable.Add(146, -100);
		num = 148;
		hashtable = (Hashtable)hashtable_0[148];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(32, -40);
		num = 109;
		hashtable = (Hashtable)hashtable_0[109];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(117, -10);
		hashtable.Add(121, -15);
		num = 248;
		hashtable = (Hashtable)hashtable_0[248];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(107, -55);
		hashtable.Add(104, -55);
		hashtable.Add(99, -55);
		hashtable.Add(112, -55);
		hashtable.Add(113, -55);
		hashtable.Add(118, -70);
		hashtable.Add(105, -55);
		hashtable.Add(97, -55);
		hashtable.Add(117, -55);
		hashtable.Add(116, -55);
		hashtable.Add(106, -55);
		hashtable.Add(115, -55);
		hashtable.Add(122, -55);
		hashtable.Add(100, -55);
		hashtable.Add(111, -55);
		hashtable.Add(119, -70);
		hashtable.Add(114, -55);
		hashtable.Add(103, -55);
		hashtable.Add(108, -55);
		hashtable.Add(98, -55);
		hashtable.Add(44, -95);
		hashtable.Add(109, -55);
		hashtable.Add(102, -55);
		hashtable.Add(121, -70);
		hashtable.Add(46, -95);
		hashtable.Add(110, -55);
		hashtable.Add(120, -85);
		hashtable.Add(101, -55);
		num = 102;
		hashtable = (Hashtable)hashtable_0[102];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(148, 60);
		hashtable.Add(111, -30);
		hashtable.Add(146, 50);
		hashtable.Add(97, -30);
		hashtable.Add(46, -30);
		hashtable.Add(101, -30);
		hashtable.Add(44, -30);
		num = 74;
		hashtable = (Hashtable)hashtable_0[74];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(97, -20);
		hashtable.Add(65, -20);
		hashtable.Add(117, -20);
		hashtable.Add(46, -30);
		hashtable.Add(44, -30);
		num = 89;
		hashtable = (Hashtable)hashtable_0[89];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -140);
		hashtable.Add(45, -140);
		hashtable.Add(105, -20);
		hashtable.Add(79, -85);
		hashtable.Add(58, -60);
		hashtable.Add(97, -140);
		hashtable.Add(65, -110);
		hashtable.Add(117, -110);
		hashtable.Add(46, -140);
		hashtable.Add(101, -140);
		hashtable.Add(59, -60);
		hashtable.Add(44, -140);
		num = 121;
		hashtable = (Hashtable)hashtable_0[121];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -20);
		hashtable.Add(97, -20);
		hashtable.Add(46, -100);
		hashtable.Add(101, -20);
		hashtable.Add(44, -100);
		num = 84;
		hashtable = (Hashtable)hashtable_0[84];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(111, -120);
		hashtable.Add(79, -40);
		hashtable.Add(58, -20);
		hashtable.Add(119, -120);
		hashtable.Add(114, -120);
		hashtable.Add(44, -120);
		hashtable.Add(59, -20);
		hashtable.Add(45, -140);
		hashtable.Add(65, -120);
		hashtable.Add(97, -120);
		hashtable.Add(117, -120);
		hashtable.Add(121, -120);
		hashtable.Add(46, -120);
		hashtable.Add(101, -120);
		num = 46;
		hashtable = (Hashtable)hashtable_0[46];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(148, -100);
		hashtable.Add(32, -60);
		hashtable.Add(146, -100);
		num = 110;
		hashtable = (Hashtable)hashtable_0[110];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(117, -10);
		hashtable.Add(121, -15);
		hashtable.Add(118, -20);
		num = 120;
		hashtable = (Hashtable)hashtable_0[120];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(101, -30);
		num = 101;
		hashtable = (Hashtable)hashtable_0[101];
		if (hashtable == null)
		{
			hashtable = new Hashtable();
			hashtable_0.Add(num, hashtable);
		}
		hashtable.Add(119, -20);
		hashtable.Add(121, -20);
		hashtable.Add(46, -15);
		hashtable.Add(120, -30);
		hashtable.Add(118, -30);
		hashtable.Add(44, -15);
		arrayList_1 = new ArrayList();
		arrayList_1.Add("Helvetica");
	}

	public Class4995()
		: this(enableKerning: false)
	{
	}

	public Class4995(bool enableKerning)
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
