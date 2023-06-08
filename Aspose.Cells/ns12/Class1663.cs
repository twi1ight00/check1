using System.Collections;
using System.Collections.Generic;
using ns1;

namespace ns12;

internal class Class1663
{
	internal ushort ushort_0;

	internal string string_0;

	internal byte byte_0;

	internal byte byte_1;

	internal Enum227[] enum227_0;

	internal Enum227 enum227_1;

	internal static Enum227[] enum227_2 = new Enum227[1] { Enum227.const_1 };

	internal static Enum227[] enum227_3;

	internal static Enum227[] enum227_4;

	internal static Enum227[] enum227_5;

	internal static Enum227[] enum227_6;

	internal static Enum227[] enum227_7;

	internal static Enum227[] enum227_8;

	internal static Enum227[] enum227_9;

	internal static Enum227[] enum227_10;

	internal static Enum227[] enum227_11;

	internal static Enum227[] enum227_12;

	internal static Enum227[] enum227_13;

	internal static Enum227[] enum227_14;

	private static Class1663[] class1663_0;

	private static Hashtable hashtable_0;

	internal Class1663(ushort ushort_1, string string_1, int int_0, int int_1, Enum227[] enum227_15, Enum227 enum227_16)
	{
		ushort_0 = ushort_1;
		string_0 = string_1;
		byte_0 = (byte)int_0;
		byte_1 = (byte)int_1;
		enum227_0 = enum227_15;
		enum227_1 = enum227_16;
	}

	internal static bool smethod_0(string string_1)
	{
		string key;
		if ((key = string_1) != null)
		{
			if (Class1742.dictionary_206 == null)
			{
				Class1742.dictionary_206 = new Dictionary<string, int>(14)
				{
					{ "CUBEVALUE", 0 },
					{ "CUBESETCOUNT", 1 },
					{ "CUBESET", 2 },
					{ "CUBERANKEDMEMBER", 3 },
					{ "CUBEMEMBERPROPERTY", 4 },
					{ "CUBEMEMBER", 5 },
					{ "CUBEKPIMEMBER", 6 },
					{ "_xlfn.CUBEVALUE", 7 },
					{ "_xlfn.CUBESETCOUNT", 8 },
					{ "_xlfn.CUBESET", 9 },
					{ "_xlfn.CUBERANKEDMEMBER", 10 },
					{ "_xlfn.CUBEMEMBERPROPERTY", 11 },
					{ "_xlfn.CUBEMEMBER", 12 },
					{ "_xlfn.CUBEKPIMEMBER", 13 }
				};
			}
			if (Class1742.dictionary_206.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
					return true;
				}
			}
		}
		return false;
	}

	internal static void AddAddInFunction(string string_1, int int_0, int int_1, Enum227[] enum227_15, Enum227 enum227_16)
	{
		smethod_1();
		if (hashtable_0[string_1.ToUpper()] == null)
		{
			hashtable_0.Add(string_1.ToUpper(), new Class1663(255, string_1, int_0, int_1, enum227_15, enum227_16));
		}
	}

	internal static void smethod_1()
	{
		lock (hashtable_0)
		{
			class1663_0 = new Class1663[266]
			{
				new Class1663(0, "COUNT", 0, 255, enum227_3, Enum227.const_1),
				new Class1663(1, "IF", 2, 3, enum227_8, Enum227.const_0),
				new Class1663(2, "ISNA", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(3, "ISERROR", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(4, "SUM", 0, 255, enum227_3, Enum227.const_1),
				new Class1663(5, "AVERAGE", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(6, "MIN", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(7, "MAX", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(8, "ROW", 0, 1, enum227_2, Enum227.const_1),
				new Class1663(9, "COLUMN", 0, 1, enum227_2, Enum227.const_1),
				new Class1663(10, "NA", 0, 0, enum227_2, Enum227.const_1),
				new Class1663(11, "NPV", 2, 255, enum227_8, Enum227.const_1),
				new Class1663(12, "STDEV", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(13, "DOLLAR", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(14, "FIXED", 2, 3, enum227_2, Enum227.const_1),
				new Class1663(15, "SIN", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(16, "COS", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(17, "TAN", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(18, "ARCTAN", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(19, "PI", 0, 0, enum227_2, Enum227.const_1),
				new Class1663(20, "SQRT", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(21, "EXP", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(22, "LN", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(23, "LOG10", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(24, "ABS", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(25, "INT", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(26, "SIGN", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(27, "ROUND", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(28, "LOOKUP", 2, 3, enum227_8, Enum227.const_1),
				new Class1663(29, "INDEX", 2, 4, enum227_6, Enum227.const_0),
				new Class1663(30, "REPT", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(31, "MID", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(32, "LEN", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(33, "VALUE", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(34, "TRUE", 0, 0, enum227_2, Enum227.const_1),
				new Class1663(35, "FALSE", 0, 0, enum227_2, Enum227.const_1),
				new Class1663(36, "AND", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(37, "OR", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(38, "NOT", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(39, "MOD", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(40, "DCOUNT", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(41, "DSUM", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(42, "DAVERAGE", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(43, "DMIN", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(44, "DMAX", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(45, "DSTDEV", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(46, "VAR", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(47, "DVAR", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(48, "TEXT", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(49, "LINEST", 1, 4, enum227_13, Enum227.const_2),
				new Class1663(50, "TREND", 1, 3, enum227_14, Enum227.const_2),
				new Class1663(51, "LOGEST", 1, 4, enum227_13, Enum227.const_2),
				new Class1663(52, "GROWTH", 1, 4, enum227_14, Enum227.const_2),
				new Class1663(56, "PV", 3, 5, enum227_2, Enum227.const_1),
				new Class1663(57, "FV", 3, 5, enum227_2, Enum227.const_1),
				new Class1663(58, "NPER", 3, 5, enum227_2, Enum227.const_1),
				new Class1663(59, "PMT", 3, 5, enum227_2, Enum227.const_1),
				new Class1663(60, "RATE", 3, 6, enum227_2, Enum227.const_1),
				new Class1663(61, "MIRR", 3, 3, enum227_6, Enum227.const_1),
				new Class1663(62, "IRR", 1, 2, enum227_6, Enum227.const_1),
				new Class1663(63, "RAND", 0, 0, enum227_2, Enum227.const_1),
				new Class1663(64, "MATCH", 2, 3, enum227_8, Enum227.const_1),
				new Class1663(65, "DATE", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(66, "TIME", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(67, "DAY", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(68, "MONTH", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(69, "YEAR", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(70, "WEEKDAY", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(71, "HOUR", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(72, "MINUTE", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(73, "SECOND", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(74, "NOW", 0, 0, enum227_2, Enum227.const_1),
				new Class1663(75, "AREAS", 1, 1, enum227_3, Enum227.const_1),
				new Class1663(76, "ROWS", 1, 1, enum227_3, Enum227.const_1),
				new Class1663(77, "COLUMNS", 1, 1, enum227_3, Enum227.const_1),
				new Class1663(78, "OFFSET", 3, 5, enum227_6, Enum227.const_0),
				new Class1663(82, "SEARCH", 2, 3, enum227_2, Enum227.const_0),
				new Class1663(83, "TRANSPOSE", 1, 1, enum227_4, Enum227.const_2),
				new Class1663(86, "TYPE", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(97, "ATAN2", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(98, "ASIN", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(99, "ACOS", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(100, "CHOOSE", 2, 255, enum227_8, Enum227.const_0),
				new Class1663(101, "HLOOKUP", 3, 4, enum227_11, Enum227.const_1),
				new Class1663(102, "VLOOKUP", 3, 4, enum227_11, Enum227.const_1),
				new Class1663(105, "ISREF", 1, 1, enum227_3, Enum227.const_1),
				new Class1663(109, "LOG", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(111, "CHAR", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(112, "LOWER", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(113, "UPPER", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(114, "PROPER", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(115, "LEFT", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(116, "RIGHT", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(117, "EXACT", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(118, "TRIM", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(119, "REPLACE", 4, 4, enum227_2, Enum227.const_1),
				new Class1663(120, "SUBSTITUTE", 3, 4, enum227_2, Enum227.const_1),
				new Class1663(121, "CODE", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(124, "FIND", 2, 3, enum227_2, Enum227.const_1),
				new Class1663(125, "CELL", 1, 2, enum227_8, Enum227.const_1),
				new Class1663(126, "ISERR", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(127, "ISTEXT", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(128, "ISNUMBER", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(129, "ISBLANK", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(130, "T", 1, 1, enum227_3, Enum227.const_1),
				new Class1663(131, "N", 1, 1, enum227_3, Enum227.const_1),
				new Class1663(140, "DATEVALUE", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(141, "TIMEVALUE", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(142, "SLN", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(143, "SYD", 4, 4, enum227_2, Enum227.const_1),
				new Class1663(144, "DDB", 4, 5, enum227_2, Enum227.const_1),
				new Class1663(148, "INDIRECT", 1, 2, enum227_2, Enum227.const_0),
				new Class1663(162, "CLEAN", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(163, "MDETERM", 1, 1, enum227_4, Enum227.const_1),
				new Class1663(164, "MINVERSE", 1, 1, enum227_4, Enum227.const_2),
				new Class1663(165, "MMULT", 2, 2, enum227_4, Enum227.const_2),
				new Class1663(167, "IPMT", 4, 6, enum227_2, Enum227.const_1),
				new Class1663(168, "PPMT", 4, 6, enum227_2, Enum227.const_1),
				new Class1663(169, "COUNTA", 0, 255, enum227_3, Enum227.const_1),
				new Class1663(170, "CANCEL.KEY", 1, 2, enum227_8, Enum227.const_1),
				new Class1663(171, "FOR", 3, 4, enum227_2, Enum227.const_1),
				new Class1663(172, "WHILE", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(173, "BREAK", 0, 0, enum227_2, Enum227.const_1),
				new Class1663(174, "NEXT", 0, 0, enum227_2, Enum227.const_1),
				new Class1663(175, "INITIATE", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(176, "REQUEST", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(177, "POKE", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(178, "EXECUTE", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(179, "TERMINATE", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(180, "RESTART", 0, 1, enum227_2, Enum227.const_1),
				new Class1663(181, "HELP", 0, 1, enum227_2, Enum227.const_1),
				new Class1663(182, "GET.BAR", 4, 4, enum227_2, Enum227.const_1),
				new Class1663(183, "PRODUCT", 0, 255, enum227_3, Enum227.const_1),
				new Class1663(184, "FACT", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(185, "GET.CELL", 1, 2, enum227_8, Enum227.const_1),
				new Class1663(186, "GET.WORKSPACE", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(187, "GET.WINDOW", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(188, "GET.DOCUMENT", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(189, "DPRODUCT", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(190, "ISNONTEXT", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(193, "STDEVP", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(194, "VARP", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(195, "DSTDEVP", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(196, "DVARP", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(197, "TRUNC", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(198, "ISLOGICAL", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(199, "DCOUNTA", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(204, "USDOLLAR", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(205, "FINDB", 2, 3, enum227_2, Enum227.const_1),
				new Class1663(206, "SEARCHB", 2, 3, enum227_2, Enum227.const_1),
				new Class1663(207, "REPLACEB", 4, 4, enum227_2, Enum227.const_1),
				new Class1663(208, "LEFTB", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(209, "RIGHTB", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(210, "MIDB", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(211, "LENB", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(212, "ROUNDUP", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(213, "ROUNDDOWN", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(214, "ASC", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(215, "DBSC", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(216, "RANK", 2, 3, enum227_10, Enum227.const_1),
				new Class1663(219, "ADDRESS", 2, 5, enum227_2, Enum227.const_1),
				new Class1663(220, "DAYS360", 2, 3, enum227_2, Enum227.const_1),
				new Class1663(221, "TODAY", 0, 0, enum227_2, Enum227.const_1),
				new Class1663(222, "VDB", 5, 7, enum227_2, Enum227.const_1),
				new Class1663(227, "MEDIAN", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(228, "SUMPRODUCT", 1, 255, enum227_4, Enum227.const_1),
				new Class1663(229, "SINH", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(230, "COSH", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(231, "TANH", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(232, "ASINH", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(233, "ACOSH", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(234, "ATANH", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(235, "DGET", 3, 3, enum227_3, Enum227.const_1),
				new Class1663(244, "INFO", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(247, "DB", 4, 5, enum227_2, Enum227.const_1),
				new Class1663(252, "FREQUENCY", 2, 2, enum227_3, Enum227.const_2),
				new Class1663(261, "ERROR.TYPE", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(268, "GET.WORKBOOK", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(269, "AVEDEV", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(270, "BETADIST", 3, 5, enum227_2, Enum227.const_1),
				new Class1663(271, "GAMMALN", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(272, "BETAINV", 3, 5, enum227_2, Enum227.const_1),
				new Class1663(273, "BINOMDIST", 4, 4, enum227_2, Enum227.const_1),
				new Class1663(274, "CHIDIST", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(275, "CHIINV", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(276, "COMBIN", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(277, "CONFIDENCE", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(278, "CRITBINOM", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(279, "EVEN", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(280, "EXPONDIST", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(281, "FDIST", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(282, "FINV", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(283, "FISHER", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(284, "FISHERINV", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(285, "FLOOR", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(286, "GAMMADIST", 4, 4, enum227_2, Enum227.const_1),
				new Class1663(287, "GAMMAINV", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(288, "CEILING", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(289, "HYPGEOMDIST", 4, 4, enum227_2, Enum227.const_1),
				new Class1663(290, "LOGNORMDIST", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(291, "LOGINV", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(292, "NEGBINOMDIST", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(293, "NORMDIST", 4, 4, enum227_2, Enum227.const_1),
				new Class1663(294, "NORMSDIST", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(295, "NORMINV", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(296, "MNORMSINV", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(297, "STANDARDIZE", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(298, "ODD", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(299, "PERMUT", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(300, "POISSON", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(301, "TDIST", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(302, "WEIBULL", 4, 4, enum227_2, Enum227.const_1),
				new Class1663(303, "SUMXMY2", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(304, "SUMX2MY2", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(305, "SUMX2PY2", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(306, "CHITEST", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(307, "CORREL", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(308, "COVAR", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(309, "FORECAST", 3, 3, enum227_12, Enum227.const_1),
				new Class1663(310, "FTEST", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(311, "INTERCEPT", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(312, "PEARSON", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(313, "RSQ", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(314, "STEYX", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(315, "SLOPE", 2, 2, enum227_4, Enum227.const_1),
				new Class1663(316, "TTEST", 4, 4, enum227_5, Enum227.const_1),
				new Class1663(317, "PROB", 3, 4, enum227_5, Enum227.const_1),
				new Class1663(318, "DEVSQ", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(319, "GEOMEAN", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(320, "HARMEAN", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(321, "SUMSQ", 0, 255, enum227_3, Enum227.const_1),
				new Class1663(322, "KURT", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(323, "SKEW", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(324, "ZTEST", 2, 3, enum227_6, Enum227.const_1),
				new Class1663(325, "LARGE", 2, 2, enum227_6, Enum227.const_1),
				new Class1663(326, "SMALL", 2, 2, enum227_6, Enum227.const_1),
				new Class1663(327, "QUARTILE", 2, 2, enum227_6, Enum227.const_1),
				new Class1663(328, "PERCENTILE", 2, 2, enum227_6, Enum227.const_1),
				new Class1663(329, "PERCENTRANK", 2, 2, enum227_6, Enum227.const_1),
				new Class1663(330, "MODE", 1, 255, enum227_4, Enum227.const_1),
				new Class1663(331, "TRIMMEAN", 2, 2, enum227_6, Enum227.const_1),
				new Class1663(332, "TINV", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(336, "CONCATENATE", 0, 255, enum227_2, Enum227.const_1),
				new Class1663(337, "POWER", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(342, "RADIANS", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(343, "DEGREES", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(344, "SUBTOTAL", 2, 255, enum227_8, Enum227.const_1),
				new Class1663(345, "SUMIF", 2, 3, enum227_7, Enum227.const_1),
				new Class1663(346, "COUNTIF", 2, 2, enum227_7, Enum227.const_1),
				new Class1663(347, "COUNTBLANK", 1, 1, enum227_3, Enum227.const_1),
				new Class1663(350, "ISPMT", 4, 4, enum227_2, Enum227.const_1),
				new Class1663(351, "DATEDIF", 3, 3, enum227_2, Enum227.const_1),
				new Class1663(352, "DATESTRING", 1, 1, enum227_2, Enum227.const_1),
				new Class1663(353, "NUMBERSTRING", 2, 2, enum227_2, Enum227.const_1),
				new Class1663(354, "ROMAN", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(358, "GETPIVOTDATA", 2, 255, enum227_2, Enum227.const_1),
				new Class1663(359, "HYPERLINK", 1, 2, enum227_2, Enum227.const_1),
				new Class1663(360, "PHONETIC", 1, 1, enum227_3, Enum227.const_1),
				new Class1663(361, "AVERAGEA", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(362, "MAXA", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(363, "MINA", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(364, "STDEVPA", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(365, "VARPA", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(366, "STDEVA", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(367, "VARA", 1, 255, enum227_3, Enum227.const_1),
				new Class1663(480, "IFERROR", 2, 2, enum227_2, Enum227.const_1)
			};
			hashtable_0 = new Hashtable();
			for (int i = 0; i < class1663_0.Length; i++)
			{
				if (class1663_0[i] != null)
				{
					hashtable_0.Add(class1663_0[i].string_0, class1663_0[i]);
				}
			}
			hashtable_0.Add("EDATE", new Class1663(255, "EDATE", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("EOMONTH", new Class1663(255, "EOMONTH", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("NETWORKDAYS", new Class1663(255, "NETWORKDAYS", 2, 3, enum227_3, Enum227.const_1));
			hashtable_0.Add("WEEKNUM", new Class1663(255, "WEEKNUM", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("WORKDAY", new Class1663(255, "WORKDAY", 2, 3, enum227_2, Enum227.const_1));
			hashtable_0.Add("YEARFRAC", new Class1663(255, "YEARFRAC", 2, 3, enum227_2, Enum227.const_1));
			hashtable_0.Add("EUROCONVERT", new Class1663(255, "EUROCONVERT", 3, 5, enum227_2, Enum227.const_1));
			hashtable_0.Add("FACTDOUBLE", new Class1663(255, "FACTDOUBLE", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("GCD", new Class1663(255, "GCD", 1, 255, enum227_2, Enum227.const_1));
			hashtable_0.Add("LCM", new Class1663(255, "LCM", 1, 255, enum227_2, Enum227.const_1));
			hashtable_0.Add("MULTINOMIAL", new Class1663(255, "MULTINOMIAL", 1, 255, enum227_2, Enum227.const_1));
			hashtable_0.Add("QUOTIENT", new Class1663(255, "QUOTIENT", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("RANDBETWEEN", new Class1663(255, "RANDBETWEEN", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("MROUND", new Class1663(255, "MROUND", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("SQRTPI", new Class1663(255, "SQRTPI", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("SERIESSUM", new Class1663(255, "SERIESSUM ", 4, 4, enum227_9, Enum227.const_1));
			hashtable_0.Add("ISEVEN", new Class1663(255, "ISEVEN", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("ISODD", new Class1663(255, "ISODD", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("ACCRINT", new Class1663(255, "ACCRINT", 5, 7, enum227_2, Enum227.const_1));
			hashtable_0.Add("ACCRINTM", new Class1663(255, "ACCRINTM", 5, 7, enum227_2, Enum227.const_1));
			hashtable_0.Add("AMORDEGRC", new Class1663(255, "AMORDEGRC", 6, 7, enum227_2, Enum227.const_1));
			hashtable_0.Add("AMORLINC", new Class1663(255, "AMORLINC", 6, 7, enum227_2, Enum227.const_1));
			hashtable_0.Add("COUPDAYBS", new Class1663(255, "COUPDAYBS", 3, 4, enum227_2, Enum227.const_1));
			hashtable_0.Add("COUPDAYS", new Class1663(255, "COUPDAYS", 3, 4, enum227_2, Enum227.const_1));
			hashtable_0.Add("COUPDAYSNC", new Class1663(255, "COUPDAYSNC", 3, 4, enum227_2, Enum227.const_1));
			hashtable_0.Add("COUPNCD", new Class1663(255, "COUPNCD", 3, 4, enum227_2, Enum227.const_1));
			hashtable_0.Add("COUPNUM", new Class1663(255, "COUPNUM", 3, 4, enum227_2, Enum227.const_1));
			hashtable_0.Add("COUPPCD", new Class1663(255, "COUPPCD", 3, 4, enum227_2, Enum227.const_1));
			hashtable_0.Add("CUMIPMT", new Class1663(255, "CUMIPMT", 6, 6, enum227_2, Enum227.const_1));
			hashtable_0.Add("CUMPRINC", new Class1663(255, "CUMPRINC", 6, 6, enum227_2, Enum227.const_1));
			hashtable_0.Add("DISC", new Class1663(255, "DISC", 4, 5, enum227_2, Enum227.const_1));
			hashtable_0.Add("DOLLARDE", new Class1663(255, "DOLLARDE", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("DOLLARFR", new Class1663(255, "DOLLARFR", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("DURATION", new Class1663(255, "DURATION", 4, 5, enum227_2, Enum227.const_1));
			hashtable_0.Add("EFFECT", new Class1663(255, "EFFECT", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("FVSCHEDULE", new Class1663(255, "FVSCHEDULE", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("INTRATE", new Class1663(255, "INTRATE", 4, 5, enum227_2, Enum227.const_1));
			hashtable_0.Add("MDURATION", new Class1663(255, "MDURATION", 5, 6, enum227_2, Enum227.const_1));
			hashtable_0.Add("NOMINAL", new Class1663(255, "NOMINAL", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("ODDFPRICE", new Class1663(255, "ODDFPRICE", 8, 9, enum227_2, Enum227.const_1));
			hashtable_0.Add("ODDFYIELD", new Class1663(255, "ODDFYIELD", 8, 9, enum227_2, Enum227.const_1));
			hashtable_0.Add("ODDLPRICE", new Class1663(255, "ODDLPRICE", 7, 8, enum227_2, Enum227.const_1));
			hashtable_0.Add("ODDLYIELD", new Class1663(255, "ODDLYIELD", 7, 8, enum227_2, Enum227.const_1));
			hashtable_0.Add("PRICE", new Class1663(255, "PRICE", 6, 7, enum227_2, Enum227.const_1));
			hashtable_0.Add("PRICEDISC", new Class1663(255, "PRICEDISC", 4, 5, enum227_2, Enum227.const_1));
			hashtable_0.Add("PRICEMAT", new Class1663(255, "PRICEMAT", 5, 6, enum227_2, Enum227.const_1));
			hashtable_0.Add("RECEIVED", new Class1663(255, "RECEIVED", 4, 5, enum227_2, Enum227.const_1));
			hashtable_0.Add("TBILLEQ", new Class1663(255, "TBILLEQ", 3, 3, enum227_2, Enum227.const_1));
			hashtable_0.Add("TBILLPRICE", new Class1663(255, "TBILLPRICE", 3, 3, enum227_2, Enum227.const_1));
			hashtable_0.Add("TBILLYIELD", new Class1663(255, "TBILLYIELD", 3, 3, enum227_2, Enum227.const_1));
			hashtable_0.Add("XIRR", new Class1663(255, "XIRR", 2, 3, enum227_13, Enum227.const_1));
			hashtable_0.Add("XNPV", new Class1663(255, "XNPV", 3, 3, enum227_8, Enum227.const_1));
			hashtable_0.Add("YIELD", new Class1663(255, "YIELD", 6, 7, enum227_2, Enum227.const_1));
			hashtable_0.Add("YIELDDISC", new Class1663(255, "YIELDDISC", 4, 5, enum227_2, Enum227.const_1));
			hashtable_0.Add("YIELDMAT", new Class1663(255, "YIELDMAT", 5, 6, enum227_2, Enum227.const_1));
			hashtable_0.Add("BESSELI", new Class1663(255, "BESSELI", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("BESSELJ", new Class1663(255, "BESSELJ", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("BESSELK", new Class1663(255, "BESSELK", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("BESSELY", new Class1663(255, "BESSELY", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("BIN2DEC", new Class1663(255, "BIN2DEC", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("BIN2HEX", new Class1663(255, "BIN2HEX", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("BIN2OCT", new Class1663(255, "BIN2OCT", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("COMPLEX", new Class1663(255, "COMPLEX", 2, 3, enum227_2, Enum227.const_1));
			hashtable_0.Add("CONVERT", new Class1663(255, "CONVERT", 3, 3, enum227_2, Enum227.const_1));
			hashtable_0.Add("DEC2BIN", new Class1663(255, "DEC2BIN", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("DEC2HEX", new Class1663(255, "DEC2HEX", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("DEC2OCT", new Class1663(255, "DEC2OCT", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("DELTA", new Class1663(255, "DELTA", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("ERF", new Class1663(255, "ERF", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("ERFC", new Class1663(255, "ERFC", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("GESTEP", new Class1663(255, "GESTEP", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("HEX2BIN", new Class1663(255, "HEX2BIN", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("HEX2DEC", new Class1663(255, "HEX2DEC", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("HEX2OCT", new Class1663(255, "ERFC", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMABS", new Class1663(255, "IMABS", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMAGINARY", new Class1663(255, "IMAGINARY", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMARGUMENT", new Class1663(255, "IMARGUMENT", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMCONJUGATE", new Class1663(255, "IMCONJUGATE", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMCOS", new Class1663(255, "IMCOS", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMDIV", new Class1663(255, "IMDIV", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMEXP", new Class1663(255, "IMEXP", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMLN", new Class1663(255, "IMLN", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMLOG10", new Class1663(255, "IMLOG10", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMLOG2", new Class1663(255, "IMLOG2", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMPOWER", new Class1663(255, "IMPOWER", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMPRODUCT", new Class1663(255, "IMPRODUCT", 1, 255, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMREAL", new Class1663(255, "IMREAL", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMSIN", new Class1663(255, "IMSIN", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMSQRT", new Class1663(255, "IMSQRT", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMSUB", new Class1663(255, "IMSUB", 2, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("IMSUM", new Class1663(255, "IMSUM", 1, 255, enum227_2, Enum227.const_1));
			hashtable_0.Add("OCT2BIN", new Class1663(255, "OCT2BIN", 1, 2, enum227_2, Enum227.const_1));
			hashtable_0.Add("OCT2DEC", new Class1663(255, "OCT2DEC", 1, 1, enum227_2, Enum227.const_1));
			hashtable_0.Add("OCT2HEX", new Class1663(255, "OCT2HEX", 1, 2, enum227_2, Enum227.const_1));
		}
	}

	internal static bool smethod_2(string string_1)
	{
		string key;
		if ((key = string_1) != null)
		{
			if (Class1742.dictionary_207 == null)
			{
				Class1742.dictionary_207 = new Dictionary<string, int>(94)
				{
					{ "EDATE", 0 },
					{ "EOMONTH", 1 },
					{ "NETWORKDAYS", 2 },
					{ "WEEKNUM", 3 },
					{ "WORKDAY", 4 },
					{ "YEARFRAC", 5 },
					{ "EUROCONVERT", 6 },
					{ "FACTDOUBLE", 7 },
					{ "GCD", 8 },
					{ "LCM", 9 },
					{ "MULTINOMIAL", 10 },
					{ "QUOTIENT", 11 },
					{ "RANDBETWEEN", 12 },
					{ "MROUND", 13 },
					{ "SQRTPI", 14 },
					{ "SERIESSUM", 15 },
					{ "ISEVEN", 16 },
					{ "ISODD", 17 },
					{ "ACCRINT", 18 },
					{ "ACCRINTM", 19 },
					{ "AMORDEGRC", 20 },
					{ "AMORLINC", 21 },
					{ "COUPDAYBS", 22 },
					{ "COUPDAYS", 23 },
					{ "COUPDAYSNC", 24 },
					{ "COUPNCD", 25 },
					{ "COUPNUM", 26 },
					{ "COUPPCD", 27 },
					{ "CUMIPMT", 28 },
					{ "CUMPRINC", 29 },
					{ "DISC", 30 },
					{ "DOLLARDE", 31 },
					{ "DOLLARFR", 32 },
					{ "DURATION", 33 },
					{ "EFFECT", 34 },
					{ "FVSCHEDULE", 35 },
					{ "INTRATE", 36 },
					{ "MDURATION", 37 },
					{ "NOMINAL", 38 },
					{ "ODDFPRICE", 39 },
					{ "ODDFYIELD", 40 },
					{ "ODDLPRICE", 41 },
					{ "ODDLYIELD", 42 },
					{ "PRICE", 43 },
					{ "PRICEDISC", 44 },
					{ "PRICEMAT", 45 },
					{ "RECEIVED", 46 },
					{ "TBILLEQ", 47 },
					{ "TBILLPRICE", 48 },
					{ "TBILLYIELD", 49 },
					{ "XIRR", 50 },
					{ "XNPV", 51 },
					{ "YIELD", 52 },
					{ "YIELDDISC", 53 },
					{ "YIELDMAT", 54 },
					{ "BESSELI", 55 },
					{ "BESSELJ", 56 },
					{ "BESSELK", 57 },
					{ "BESSELY", 58 },
					{ "BIN2DEC", 59 },
					{ "BIN2HEX", 60 },
					{ "BIN2OCT", 61 },
					{ "COMPLEX", 62 },
					{ "CONVERT", 63 },
					{ "DEC2BIN", 64 },
					{ "DEC2HEX", 65 },
					{ "DEC2OCT", 66 },
					{ "DELTA", 67 },
					{ "ERF", 68 },
					{ "ERFC", 69 },
					{ "GESTEP", 70 },
					{ "HEX2BIN", 71 },
					{ "HEX2DEC", 72 },
					{ "HEX2OCT", 73 },
					{ "IMABS", 74 },
					{ "IMAGINARY", 75 },
					{ "IMARGUMENT", 76 },
					{ "IMCONJUGATE", 77 },
					{ "IMCOS", 78 },
					{ "IMDIV", 79 },
					{ "IMEXP", 80 },
					{ "IMLN", 81 },
					{ "IMLOG10", 82 },
					{ "IMLOG2", 83 },
					{ "IMPOWER", 84 },
					{ "IMPRODUCT", 85 },
					{ "IMREAL", 86 },
					{ "IMSIN", 87 },
					{ "IMSQRT", 88 },
					{ "IMSUB", 89 },
					{ "IMSUM", 90 },
					{ "OCT2BIN", 91 },
					{ "OCT2DEC", 92 },
					{ "OCT2HEX", 93 }
				};
			}
			if (Class1742.dictionary_207.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
				case 19:
				case 20:
				case 21:
				case 22:
				case 23:
				case 24:
				case 25:
				case 26:
				case 27:
				case 28:
				case 29:
				case 30:
				case 31:
				case 32:
				case 33:
				case 34:
				case 35:
				case 36:
				case 37:
				case 38:
				case 39:
				case 40:
				case 41:
				case 42:
				case 43:
				case 44:
				case 45:
				case 46:
				case 47:
				case 48:
				case 49:
				case 50:
				case 51:
				case 52:
				case 53:
				case 54:
				case 55:
				case 56:
				case 57:
				case 58:
				case 59:
				case 60:
				case 61:
				case 62:
				case 63:
				case 64:
				case 65:
				case 66:
				case 67:
				case 68:
				case 69:
				case 70:
				case 71:
				case 72:
				case 73:
				case 74:
				case 75:
				case 76:
				case 77:
				case 78:
				case 79:
				case 80:
				case 81:
				case 82:
				case 83:
				case 84:
				case 85:
				case 86:
				case 87:
				case 88:
				case 89:
				case 90:
				case 91:
				case 92:
				case 93:
					return false;
				}
			}
		}
		return true;
	}

	internal static Class1663 smethod_3(int int_0)
	{
		if (class1663_0 == null)
		{
			smethod_1();
		}
		int num = 0;
		int num2 = class1663_0.Length - 1;
		int num3;
		while (true)
		{
			if (num <= num2)
			{
				num3 = num + num2 >> 1;
				int num4 = class1663_0[num3].ushort_0;
				if (num4 < int_0)
				{
					num = num3 + 1;
					continue;
				}
				if (num4 <= int_0)
				{
					break;
				}
				num2 = num3 - 1;
				continue;
			}
			return null;
		}
		return class1663_0[num3];
	}

	internal static Class1663 smethod_4(string string_1, Enum226 enum226_0)
	{
		if (class1663_0 == null)
		{
			smethod_1();
		}
		if (enum226_0 == Enum226.const_1)
		{
			switch (string_1)
			{
			case "LOOKUP":
				return new Class1663(28, "LOOKUP", 2, 3, enum227_12, Enum227.const_1);
			case "IF":
				return new Class1663(1, "IF", 2, 3, enum227_12, Enum227.const_0);
			}
		}
		return (Class1663)hashtable_0[string_1];
	}

	internal static bool smethod_5(int int_0)
	{
		if (int_0 == 480)
		{
			return true;
		}
		return false;
	}

	static Class1663()
	{
		Enum227[] array = new Enum227[1];
		enum227_3 = array;
		enum227_4 = new Enum227[1] { Enum227.const_2 };
		enum227_5 = new Enum227[3]
		{
			Enum227.const_2,
			Enum227.const_2,
			Enum227.const_1
		};
		enum227_6 = new Enum227[2]
		{
			Enum227.const_0,
			Enum227.const_1
		};
		enum227_7 = new Enum227[3]
		{
			Enum227.const_0,
			Enum227.const_1,
			Enum227.const_0
		};
		enum227_8 = new Enum227[2]
		{
			Enum227.const_1,
			Enum227.const_0
		};
		enum227_9 = new Enum227[4]
		{
			Enum227.const_1,
			Enum227.const_1,
			Enum227.const_1,
			Enum227.const_0
		};
		enum227_10 = new Enum227[3]
		{
			Enum227.const_1,
			Enum227.const_0,
			Enum227.const_1
		};
		enum227_11 = new Enum227[4]
		{
			Enum227.const_1,
			Enum227.const_0,
			Enum227.const_0,
			Enum227.const_1
		};
		enum227_12 = new Enum227[2]
		{
			Enum227.const_1,
			Enum227.const_2
		};
		enum227_13 = new Enum227[3]
		{
			Enum227.const_0,
			Enum227.const_0,
			Enum227.const_1
		};
		enum227_14 = new Enum227[4]
		{
			Enum227.const_0,
			Enum227.const_0,
			Enum227.const_0,
			Enum227.const_1
		};
		hashtable_0 = new Hashtable();
	}
}
