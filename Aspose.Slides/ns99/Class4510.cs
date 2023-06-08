using ns102;

namespace ns99;

internal class Class4510
{
	internal enum Enum644
	{
		const_0,
		const_1
	}

	internal class Class4511
	{
		public static readonly string[] string_0 = new string[256]
		{
			null, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null, null, null, null, null,
			null, null, "space", "exclam", "universal", "numbersign", "existential", "percent", "ampersand", "suchthat",
			"parenleft", "parenright", "asteriskmath", "plus", "comma", "minus", "period", "slash", "zero", "one",
			"two", "three", "four", "five", "six", "seven", "eight", "nine", "colon", "semicolon",
			"less", "equal", "greater", "question", "congruent", "Alpha", "Beta", "Chi", "Delta", "Epsilon",
			"Phi", "Gamma", "Eta", "Iota", "theta1", "Kappa", "Lambda", "Mu", "Nu", "Omicron",
			"Pi", "Theta", "Rho", "Sigma", "Tau", "Upsilon", "sigma1", "Omega", "Xi", "Psi",
			"Zeta", "bracketleft", "therefore", "bracketright", "perpendicular", "underscore", "radicalex", "alpha", "beta", "chi",
			"delta", "epsilon", "phi", "gamma", "eta", "iota", "phi1", "kappa", "lambda", "mu",
			"nu", "omicron", "pi", "theta", "rho", "sigma", "tau", "upsilon", "omega1", "omega",
			"xi", "psi", "zeta", "braceleft", "bar", "braceright", "similar", null, null, null,
			null, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null, null, null, null, null,
			null, "Upsilon1", "minute", "lessequal", "fraction", "infinity", "florin", "club", "diamond", "heart",
			"spade", "arrowboth", "arrowleft", "arrowup", "arrowright", "arrowdown", "degree", "plusminus", "second", "greaterequal",
			"multiply", "proportional", "partialdiff", "bullet", "divide", "notequal", "equivalence", "approxequal", "ellipsis", "arrowvertex",
			"arrowhorizex", "carriagereturn", "aleph", "Ifraktur", "Rfraktur", "weierstrass", "circlemultiply", "circleplus", "emptyset", "intersection",
			"union", "propersuperset", "reflexsuperset", "notsubset", "propersubset", "reflexsubset", "element", "notelement", "angle", "gradient",
			"registerserif", "copyrightserif", "trademarkserif", "product", "radical", "dotmath", "logicalnot", "logicaland", "logicalor", "arrowdblboth",
			"arrowdblleft", "arrowdblup", "arrowdblright", "arrowdbldown", "lozenge", "angleleft", "registersans", "copyrightsans", "trademarksans", "summation",
			"parenlefttp", "parenleftex", "parenleftbt", "bracketlefttp", "bracketleftex", "bracketleftbt", "bracelefttp", "braceleftmid", "braceleftbt", "braceex",
			null, "angleright", "integral", "integraltp", "integralex", "integralbt", "parenrighttp", "parenrightex", "parenrightbt", "bracketrighttp",
			"bracketrightex", "bracketrightbt", "bracerighttp", "bracerightmid", "bracerightbt", null
		};

		public static readonly string[] string_1 = new string[256]
		{
			null, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null, null, null, null, null,
			null, null, "space", "a1", "a2", "a202", "a3", "a4", "a5", "a119",
			"a118", "a117", "a11", "a12", "a13", "a14", "a15", "a16", "a105", "a17",
			"a18", "a19", "a20", "a21", "a22", "a23", "a24", "a25", "a26", "a27",
			"a28", "a6", "a7", "a8", "a9", "a10", "a29", "a30", "a31", "a32",
			"a33", "a34", "a35", "a36", "a37", "a38", "a39", "a40", "a41", "a42",
			"a43", "a44", "a45", "a46", "a47", "a48", "a49", "a50", "a51", "a52",
			"a53", "a54", "a55", "a56", "a57", "a58", "a59", "a60", "a61", "a62",
			"a63", "a64", "a65", "a66", "a67", "a68", "a69", "a70", "a71", "a72",
			"a73", "a74", "a203", "a75", "a204", "a76", "a77", "a78", "a79", "a81",
			"a82", "a83", "a84", "a97", "a98", "a99", "a100", null, null, null,
			null, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null, null, null, null, null,
			null, "a101", "a102", "a103", "a104", "a106", "a107", "a108", "a112", "a111",
			"a110", "a109", "a120", "a121", "a122", "a123", "a124", "a125", "a126", "a127",
			"a128", "a129", "a130", "a131", "a132", "a133", "a134", "a135", "a136", "a137",
			"a138", "a139", "a140", "a141", "a142", "a143", "a144", "a145", "a146", "a147",
			"a148", "a149", "a150", "a151", "a152", "a153", "a154", "a155", "a156", "a157",
			"a158", "a159", "a160", "a161", "a163", "a164", "a196", "a165", "a192", "a166",
			"a167", "a168", "a169", "a170", "a171", "a172", "a173", "a162", "a174", "a175",
			"a176", "a177", "a178", "a179", "a193", "a180", "a199", "a181", "a200", "a182",
			null, "a201", "a183", "a184", "a197", "a185", "a194", "a198", "a186", "a195",
			"a187", "a188", "a189", "a190", "a191", null
		};
	}

	private static Class4510 class4510_0;

	private static Class4694 class4694_0;

	private Enum644 enum644_0 = Enum644.const_1;

	public static Class4510 Current => class4510_0;

	public int CurrentPlatformID => 3;

	public Enum644 Strictness
	{
		get
		{
			return enum644_0;
		}
		set
		{
			enum644_0 = value;
		}
	}

	public Class4694 FontSpecificEncodings => class4694_0;

	static Class4510()
	{
		class4510_0 = new Class4510();
		class4694_0 = new Class4694();
		Current.FontSpecificEncodings.method_0("Symbol", Class4511.string_0);
		Current.FontSpecificEncodings.method_0("ZapfDingbats", Class4511.string_1);
	}
}
