using System;
using System.Collections;
using System.Text;
using ns99;

namespace ns100;

internal class Class4421 : Interface114, Interface115
{
	private const int int_0 = 390;

	private bool bool_0;

	private ArrayList arrayList_0;

	private Class4409 class4409_0;

	private Class4485 class4485_0;

	private Class4485 class4485_1;

	private Class4485 class4485_2;

	private string[] string_0;

	private object object_0 = new object();

	private object object_1 = new object();

	private object object_2 = new object();

	internal ArrayList EncodingDictionary => arrayList_0;

	internal bool UseStandardEncoding
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	protected string[] StandardStrings
	{
		get
		{
			if (string_0 == null)
			{
				lock (object_0)
				{
					if (string_0 == null)
					{
						string_0 = new string[391];
						method_3();
					}
				}
			}
			return string_0;
		}
	}

	internal Class4421(Class4409 font)
	{
		arrayList_0 = new ArrayList();
		class4409_0 = font;
	}

	public char imethod_0(Class4506 gid)
	{
		Class4507 @class = gid as Class4507;
		if (@class != null)
		{
			return Class4479.Instance.imethod_5(@class.Value);
		}
		return '\0';
	}

	public void imethod_1(ushort gid, char charCode)
	{
		throw new NotSupportedException();
	}

	public Class4506 imethod_2(char unicode)
	{
		int num = Class4479.Instance.imethod_0(unicode);
		int num2 = 0;
		string text;
		while (true)
		{
			if (num2 < num)
			{
				text = Class4479.Instance.imethod_1(unicode, num2);
				if (imethod_5().ContainsKey(text) && imethod_5()[text] != 0)
				{
					break;
				}
				num2++;
				continue;
			}
			return Class4507.class4507_0;
		}
		return new Class4507(text);
	}

	public Class4506 imethod_3(char charCode)
	{
		if (charCode < class4409_0.Internals.Charset.SIDtoGID.Length)
		{
			return new Class4508(class4409_0.Internals.Charset.SIDtoGID[(uint)charCode]);
		}
		return new Class4508(0);
	}

	public Class4506 imethod_4(Interface129 parameters, char charCode)
	{
		throw new NotSupportedException();
	}

	public Class4485 imethod_5()
	{
		if (class4485_0 == null)
		{
			lock (object_2)
			{
				if (class4485_0 == null)
				{
					class4485_0 = new Class4485();
					for (int i = 0; i < 256; i++)
					{
						int sid = class4409_0.Internals.Encoding.ushort_1[i];
						string name = method_2(sid);
						if (!class4485_0.ContainsKey(name))
						{
							class4485_0.Add(name, i);
						}
					}
				}
			}
		}
		return class4485_0;
	}

	public Class4485 method_0()
	{
		if (class4485_1 == null)
		{
			lock (object_1)
			{
				if (class4485_1 == null)
				{
					class4485_1 = new Class4485();
					for (int i = 0; i <= 390 + class4409_0.Internals.StringIndex.ObjectsCount; i++)
					{
						string name = method_2(i);
						ushort num = 0;
						while (num < class4409_0.Internals.Charset.GIDToSID.Length)
						{
							if (class4409_0.Internals.Charset.GIDToSID[num] != i)
							{
								num = (ushort)(num + 1);
								continue;
							}
							class4485_1.Add(name, num);
							break;
						}
					}
				}
			}
		}
		return class4485_1;
	}

	public Class4485 method_1()
	{
		if (class4485_2 == null)
		{
			lock (object_1)
			{
				if (class4485_2 == null)
				{
					class4485_2 = new Class4485();
					for (int i = 0; i <= 390 + class4409_0.Internals.StringIndex.ObjectsCount; i++)
					{
						string name = method_2(i);
						class4485_2[name] = i;
					}
				}
			}
		}
		return class4485_2;
	}

	private string method_2(int sid)
	{
		if (sid > 390)
		{
			class4409_0.Internals.StringIndex.method_0(sid - 390 - 1, out var offset, out var length);
			return Encoding.ASCII.GetString(class4409_0.Internals.StringIndex.IndexData, offset, length);
		}
		return StandardStrings[sid];
	}

	private void method_3()
	{
		string_0[0] = ".notdef";
		string_0[1] = "space";
		string_0[2] = "exclam";
		string_0[3] = "quotedbl";
		string_0[4] = "numbersign";
		string_0[5] = "dollar";
		string_0[6] = "percent";
		string_0[7] = "ampersand";
		string_0[8] = "quoteright";
		string_0[9] = "parenleft";
		string_0[10] = "parenright";
		string_0[11] = "asterisk";
		string_0[12] = "plus";
		string_0[13] = "comma";
		string_0[14] = "hyphen";
		string_0[15] = "period";
		string_0[16] = "slash";
		string_0[17] = "zero";
		string_0[18] = "one";
		string_0[19] = "two";
		string_0[20] = "three";
		string_0[21] = "four";
		string_0[22] = "five";
		string_0[23] = "six";
		string_0[24] = "seven";
		string_0[25] = "eight";
		string_0[26] = "nine";
		string_0[27] = "colon";
		string_0[28] = "semicolon";
		string_0[29] = "less";
		string_0[30] = "equal";
		string_0[31] = "greater";
		string_0[32] = "question";
		string_0[33] = "at";
		string_0[34] = "A";
		string_0[35] = "B";
		string_0[36] = "C";
		string_0[37] = "D";
		string_0[38] = "E";
		string_0[39] = "F";
		string_0[40] = "G";
		string_0[41] = "H";
		string_0[42] = "I";
		string_0[43] = "J";
		string_0[44] = "K";
		string_0[45] = "L";
		string_0[46] = "M";
		string_0[47] = "N";
		string_0[48] = "O";
		string_0[49] = "P";
		string_0[50] = "Q";
		string_0[51] = "R";
		string_0[52] = "S";
		string_0[53] = "T";
		string_0[54] = "U";
		string_0[55] = "V";
		string_0[56] = "W";
		string_0[57] = "X";
		string_0[58] = "Y";
		string_0[59] = "Z";
		string_0[60] = "bracketleft";
		string_0[61] = "backslash";
		string_0[62] = "bracketright";
		string_0[63] = "asciicircum";
		string_0[64] = "underscore";
		string_0[65] = "quoteleft";
		string_0[66] = "a";
		string_0[67] = "b";
		string_0[68] = "c";
		string_0[69] = "d";
		string_0[70] = "e";
		string_0[71] = "f";
		string_0[72] = "g";
		string_0[73] = "h";
		string_0[74] = "i";
		string_0[75] = "j";
		string_0[76] = "k";
		string_0[77] = "l";
		string_0[78] = "m";
		string_0[79] = "n";
		string_0[80] = "o";
		string_0[81] = "p";
		string_0[82] = "q";
		string_0[83] = "r";
		string_0[84] = "s";
		string_0[85] = "t";
		string_0[86] = "u";
		string_0[87] = "v";
		string_0[88] = "w";
		string_0[89] = "x";
		string_0[90] = "y";
		string_0[91] = "z";
		string_0[92] = "braceleft";
		string_0[93] = "bar";
		string_0[94] = "braceright";
		string_0[95] = "asciitilde";
		string_0[96] = "exclamdown";
		string_0[97] = "cent";
		string_0[98] = "sterling";
		string_0[99] = "fraction";
		string_0[100] = "yen";
		string_0[101] = "florin";
		string_0[102] = "section";
		string_0[103] = "currency";
		string_0[104] = "quotesingle";
		string_0[105] = "quotedblleft";
		string_0[106] = "guillemotleft";
		string_0[107] = "guilsinglleft";
		string_0[108] = "guilsinglright";
		string_0[109] = "fi";
		string_0[110] = "fl";
		string_0[111] = "endash";
		string_0[112] = "dagger";
		string_0[113] = "daggerdbl";
		string_0[114] = "periodcentered";
		string_0[115] = "paragraph";
		string_0[116] = "bullet";
		string_0[117] = "quotesinglbase";
		string_0[118] = "quotedblbase";
		string_0[119] = "quotedblright";
		string_0[120] = "guillemotright";
		string_0[121] = "ellipsis";
		string_0[122] = "perthousand";
		string_0[123] = "questiondown";
		string_0[124] = "grave";
		string_0[125] = "acute";
		string_0[126] = "circumflex";
		string_0[127] = "tilde";
		string_0[128] = "macron";
		string_0[129] = "breve";
		string_0[130] = "dotaccent";
		string_0[131] = "dieresis";
		string_0[132] = "ring";
		string_0[133] = "cedilla";
		string_0[134] = "hungarumlaut";
		string_0[135] = "ogonek";
		string_0[136] = "caron";
		string_0[137] = "emdash";
		string_0[138] = "AE";
		string_0[139] = "ordfeminine";
		string_0[140] = "Lslash";
		string_0[141] = "Oslash";
		string_0[142] = "OE";
		string_0[143] = "ordmasculine";
		string_0[144] = "ae";
		string_0[145] = "dotlessi";
		string_0[146] = "lslash";
		string_0[147] = "oslash";
		string_0[148] = "oe";
		string_0[149] = "germandbls";
		string_0[150] = "onesuperior";
		string_0[151] = "logicalnot";
		string_0[152] = "mu";
		string_0[153] = "trademark";
		string_0[154] = "Eth";
		string_0[155] = "onehalf";
		string_0[156] = "plusminus ";
		string_0[157] = "Thorn";
		string_0[158] = "onequarter";
		string_0[159] = "divide";
		string_0[160] = "brokenbar";
		string_0[161] = "degree";
		string_0[162] = "thorn";
		string_0[163] = "threequarters";
		string_0[164] = "twosuperior";
		string_0[165] = "registered";
		string_0[166] = "minus";
		string_0[167] = "eth";
		string_0[168] = "multiply";
		string_0[169] = "threesuperior";
		string_0[170] = "copyright";
		string_0[171] = "Aacute";
		string_0[172] = "Acircumflex";
		string_0[173] = "Adieresis";
		string_0[174] = "Agrave";
		string_0[175] = "Aring";
		string_0[176] = "Atilde";
		string_0[177] = "Ccedilla";
		string_0[178] = "Eacute";
		string_0[179] = "Ecircumflex";
		string_0[180] = "Edieresis";
		string_0[181] = "Egrave";
		string_0[182] = "Iacute";
		string_0[183] = "Icircumflex";
		string_0[184] = "Idieresis";
		string_0[185] = "Igrave";
		string_0[186] = "Ntilde";
		string_0[187] = "Oacute";
		string_0[188] = "Ocircumflex";
		string_0[189] = "Odieresis";
		string_0[190] = "Ograve";
		string_0[191] = "Otilde";
		string_0[192] = "Scaron";
		string_0[193] = "Uacute";
		string_0[194] = "Ucircumflex";
		string_0[195] = "Udieresis";
		string_0[196] = "Ugrave";
		string_0[197] = "Yacute";
		string_0[198] = "Ydieresis";
		string_0[199] = "Zcaron";
		string_0[200] = "aacute";
		string_0[201] = "acircumflex";
		string_0[202] = "adieresis";
		string_0[203] = "agrave";
		string_0[204] = "aring";
		string_0[205] = "atilde";
		string_0[206] = "ccedilla";
		string_0[207] = "eacute";
		string_0[208] = "ecircumflex";
		string_0[209] = "edieresis";
		string_0[210] = "egrave";
		string_0[211] = "iacute";
		string_0[212] = "icircumflex";
		string_0[213] = "idieresis";
		string_0[214] = "igrave";
		string_0[215] = "ntilde";
		string_0[216] = "oacute";
		string_0[217] = "ocircumflex";
		string_0[218] = "odieresis";
		string_0[219] = "ograve";
		string_0[220] = "otilde";
		string_0[221] = "scaron";
		string_0[222] = "uacute";
		string_0[223] = "ucircumflex";
		string_0[224] = "udieresis";
		string_0[225] = "ugrave";
		string_0[226] = "yacute";
		string_0[227] = "ydieresis";
		string_0[228] = "zcaron";
		string_0[229] = "exclamsmall";
		string_0[230] = "Hungarumlautsmall";
		string_0[231] = "dollaroldstyle";
		string_0[232] = "dollarsuperior";
		string_0[233] = "ampersandsmall";
		string_0[234] = "Acutesmall";
		string_0[235] = "parenleftsuperior";
		string_0[236] = "parenrightsuperior";
		string_0[237] = "twodotenleader";
		string_0[238] = "onedotenleader";
		string_0[239] = "zerooldstyle";
		string_0[240] = "oneoldstyle";
		string_0[241] = "twooldstyle";
		string_0[242] = "threeoldstyle";
		string_0[243] = "fouroldstyle";
		string_0[244] = "fiveoldstyle";
		string_0[245] = "sixoldstyle";
		string_0[246] = "sevenoldstyle";
		string_0[247] = "eightoldstyle";
		string_0[248] = "nineoldstyle";
		string_0[249] = "commasuperior";
		string_0[250] = "threequartersemdash";
		string_0[251] = "periodsuperior";
		string_0[252] = "questionsmall";
		string_0[253] = "asuperior";
		string_0[254] = "bsuperior";
		string_0[255] = "centsuperior";
		string_0[256] = "dsuperior";
		string_0[257] = "esuperior";
		string_0[258] = "isuperior";
		string_0[259] = "lsuperior";
		string_0[260] = "msuperior";
		string_0[261] = "nsuperior";
		string_0[262] = "osuperior";
		string_0[263] = "rsuperior";
		string_0[264] = "ssuperior";
		string_0[265] = "tsuperior";
		string_0[266] = "ff";
		string_0[267] = "ffi";
		string_0[268] = "ffl";
		string_0[269] = "parenleftinferior";
		string_0[270] = "parenrightinferior";
		string_0[271] = "Circumflexsmall";
		string_0[272] = "hyphensuperior";
		string_0[273] = "Gravesmall";
		string_0[274] = "Asmall";
		string_0[275] = "Bsmall";
		string_0[276] = "Csmall";
		string_0[277] = "Dsmall";
		string_0[278] = "Esmall";
		string_0[279] = "Fsmall";
		string_0[280] = "Gsmall";
		string_0[281] = "Hsmall";
		string_0[282] = "Ismall";
		string_0[283] = "Jsmall";
		string_0[284] = "Ksmall";
		string_0[285] = "Lsmall";
		string_0[286] = "Msmall";
		string_0[287] = "Nsmall";
		string_0[288] = "Osmall";
		string_0[289] = "Psmall";
		string_0[290] = "Qsmall";
		string_0[291] = "Rsmall";
		string_0[292] = "Ssmall";
		string_0[293] = "Tsmall";
		string_0[294] = "Usmall";
		string_0[295] = "Vsmall";
		string_0[296] = "Wsmall";
		string_0[297] = "Xsmall";
		string_0[298] = "Ysmall";
		string_0[299] = "Zsmall";
		string_0[300] = "colonmonetary";
		string_0[301] = "onefitted";
		string_0[302] = "rupiah";
		string_0[303] = "Tildesmall";
		string_0[304] = "exclamdownsmall";
		string_0[305] = "centoldstyle";
		string_0[306] = "Lslashsmall";
		string_0[307] = "Scaronsmall";
		string_0[308] = "Zcaronsmall";
		string_0[309] = "Dieresissmall";
		string_0[310] = "Brevesmall";
		string_0[311] = "Caronsmall";
		string_0[312] = "Dotaccentsmall";
		string_0[313] = "Macronsmall";
		string_0[314] = "figuredash";
		string_0[315] = "hypheninferior";
		string_0[316] = "Ogoneksmall";
		string_0[317] = "Ringsmall";
		string_0[318] = "Cedillasmall";
		string_0[319] = "questiondownsmall";
		string_0[320] = "oneeighth";
		string_0[321] = "threeeighths";
		string_0[322] = "fiveeighths";
		string_0[323] = "seveneighths";
		string_0[324] = "onethird";
		string_0[325] = "twothirds";
		string_0[326] = "zerosuperior";
		string_0[327] = "foursuperior";
		string_0[328] = "fivesuperior";
		string_0[329] = "sixsuperior";
		string_0[330] = "sevensuperior";
		string_0[331] = "eightsuperior";
		string_0[332] = "ninesuperior";
		string_0[333] = "zeroinferior";
		string_0[334] = "oneinferior";
		string_0[335] = "twoinferior";
		string_0[336] = "threeinferior";
		string_0[337] = "fourinferior";
		string_0[338] = "fiveinferior";
		string_0[339] = "sixinferior";
		string_0[340] = "seveninferior";
		string_0[341] = "eightinferior";
		string_0[342] = "nineinferior";
		string_0[343] = "centinferior";
		string_0[344] = "dollarinferior";
		string_0[345] = "periodinferior";
		string_0[346] = "commainferior";
		string_0[347] = "Agravesmall";
		string_0[348] = "Aacutesmall";
		string_0[349] = "Acircumflexsmall";
		string_0[350] = "Atildesmall";
		string_0[351] = "Adieresissmall";
		string_0[352] = "Aringsmall";
		string_0[353] = "AEsmall";
		string_0[354] = "Ccedillasmall";
		string_0[355] = "Egravesmall";
		string_0[356] = "Eacutesmall";
		string_0[357] = "Ecircumflexsmall";
		string_0[358] = "Edieresissmall";
		string_0[359] = "Igravesmall";
		string_0[360] = "Iacutesmall";
		string_0[361] = "Icircumflexsmall";
		string_0[362] = "Idieresissmall";
		string_0[363] = "Ethsmall";
		string_0[364] = "Ntildesmall";
		string_0[365] = "Ogravesmall";
		string_0[366] = "Oacutesmall";
		string_0[367] = "Ocircumflexsmall";
		string_0[368] = "Otildesmall";
		string_0[369] = "Odieresissmall";
		string_0[370] = "OEsmall";
		string_0[371] = "Oslashsmall";
		string_0[372] = "Ugravesmall";
		string_0[373] = "Uacutesmall";
		string_0[374] = "Ucircumflexsmall";
		string_0[375] = "Udieresissmall";
		string_0[376] = "Yacutesmall";
		string_0[377] = "Thornsmall";
		string_0[378] = "Ydieresissmall";
		string_0[379] = "001.000";
		string_0[380] = "001.001";
		string_0[381] = "001.002";
		string_0[382] = "001.003";
		string_0[383] = "Black";
		string_0[384] = "Bold";
		string_0[385] = "Book";
		string_0[386] = "Light";
		string_0[387] = "Medium";
		string_0[388] = "Regular";
		string_0[389] = "Roman";
		string_0[390] = "Semibold";
	}
}
