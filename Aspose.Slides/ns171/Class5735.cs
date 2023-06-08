using System.Collections;
using ns175;
using ns187;
using ns192;

namespace ns171;

internal class Class5735
{
	private class Class5074 : Class5040.Class5073
	{
		internal Class5074(int propId)
			: base(propId)
		{
		}

		protected override Class5024 vmethod_12(Class5024 p, Class5634 propertyList, Class5094 fo)
		{
			string text = p.vmethod_11();
			if (text != null)
			{
				Class5738 foUserAgent = ((fo == null) ? propertyList.method_0() : fo)?.method_2();
				return Class5040.smethod_0(foUserAgent, text);
			}
			return base.vmethod_12(p, propertyList, fo);
		}
	}

	private class Class5078 : Class5042.Class5075
	{
		private Class5735 class5735_0;

		public Class5078(int propId, Class5735 owner)
			: base(propId)
		{
			class5735_0 = owner;
		}

		public override Class5024 vmethod_4(int subpropId, Class5634 propertyList, bool bTryInherit, bool bTryDefault)
		{
			Class5024 @class = base.vmethod_4(subpropId, propertyList, bTryInherit, bTryDefault);
			if (@class != null)
			{
				int num = @class.imethod_0();
				if (num == 73 || num == 120)
				{
					@class = class5735_0.method_12(num, propertyList.method_6(Enum679.const_354).imethod_0());
				}
			}
			return @class;
		}
	}

	private class Class5079 : Class5042.Class5075
	{
		private Class5735 class5735_0;

		public Class5079(int propId, Class5735 owner)
			: base(propId)
		{
			class5735_0 = owner;
		}

		public override Class5024 vmethod_4(int subpropId, Class5634 propertyList, bool bTryInherit, bool bTryDefault)
		{
			Class5024 @class = base.vmethod_4(subpropId, propertyList, bTryInherit, bTryDefault);
			if (@class != null && @class.imethod_0() == 110)
			{
				@class = propertyList.method_7(246);
				if (@class.imethod_0() == 110)
				{
					return method_19(propertyList);
				}
			}
			return @class;
		}

		private Class5024 method_19(Class5634 propertyList)
		{
			Class5024 @class = propertyList.method_5(245);
			if (@class == null)
			{
				return null;
			}
			return @class.imethod_0() switch
			{
				70 => class5735_0.method_1(135, "START"), 
				39 => class5735_0.method_1(39, "END"), 
				135 => class5735_0.method_1(135, "START"), 
				23 => class5735_0.method_1(23, "CENTER"), 
				73 => class5735_0.method_12(73, propertyList.method_6(Enum679.const_354).imethod_0()), 
				120 => class5735_0.method_12(120, propertyList.method_6(Enum679.const_354).imethod_0()), 
				_ => null, 
			};
		}
	}

	private static Hashtable hashtable_0 = new Hashtable();

	private static Hashtable hashtable_1 = new Hashtable();

	private static Hashtable hashtable_2 = new Hashtable();

	private static Class5052[] class5052_0 = null;

	private Class5024[] class5024_0;

	private Class5052 class5052_1;

	private Class5052 class5052_2;

	private Class5052 class5052_3;

	private Class5052 class5052_4;

	private Class5052 class5052_5;

	private Class5052 class5052_6;

	private Class5052 class5052_7;

	private Class5052 class5052_8;

	private Class5052 class5052_9;

	private Class5052 class5052_10;

	private Class5052 class5052_11;

	private Class5735()
	{
	}

	private void method_0()
	{
		class5052_1 = new Class5040.Class5073(0);
		class5052_2 = new Class5042.Class5075(0);
		class5052_2.method_3("true", method_1(149, "TRUE"));
		class5052_2.method_3("false", method_1(48, "FALSE"));
		class5052_3 = new Class5043.Class5062(0);
		Class5052 @class = new Class5048.Class5081(5632);
		@class.method_9(setByShorthand: true);
		@class.method_6("auto");
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("always", method_1(7, "ALWAYS"));
		class5052_3.vmethod_1(@class);
		@class = new Class5048.Class5081(5120);
		@class.method_9(setByShorthand: true);
		@class.method_6("auto");
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("always", method_1(7, "ALWAYS"));
		class5052_3.vmethod_1(@class);
		@class = new Class5048.Class5081(4608);
		@class.method_9(setByShorthand: true);
		@class.method_6("auto");
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("always", method_1(7, "ALWAYS"));
		class5052_3.vmethod_1(@class);
		class5052_4 = new Class5032.Class5061(0);
		@class = new Class5034.Class5068(2048);
		@class.method_9(setByShorthand: true);
		class5052_4.vmethod_1(@class);
		@class = new Class5042.Class5075(1024);
		@class.method_3("discard", method_1(32, "DISCARD"));
		@class.method_3("retain", method_1(118, "RETAIN"));
		class5052_4.vmethod_1(@class);
		class5052_5 = new Class5032.Class5061(0);
		class5052_5.vmethod_0(class5052_4);
		class5052_5.method_1(inheriteD: false);
		class5052_5.vmethod_2(2048).method_6("0pt");
		class5052_5.method_8(5);
		class5052_6 = new Class5034.Class5068(0);
		class5052_6.method_1(inheriteD: false);
		class5052_6.method_6("0pt");
		class5052_6.method_8(5);
		class5052_6.method_4(class5052_0[170]);
		class5052_7 = new Class5032.Class5061(0);
		class5052_7.method_1(inheriteD: false);
		class5052_7.method_2("thin", "0.5pt");
		class5052_7.method_2("medium", "1pt");
		class5052_7.method_2("thick", "2pt");
		@class = new Class5034.Class5068(2048);
		@class.method_9(setByShorthand: true);
		@class.method_2("thin", "0.5pt");
		@class.method_2("medium", "1pt");
		@class.method_2("thick", "2pt");
		@class.method_6("medium");
		class5052_7.vmethod_1(@class);
		@class = new Class5042.Class5075(1024);
		@class.method_3("discard", method_1(32, "DISCARD"));
		@class.method_3("retain", method_1(118, "RETAIN"));
		class5052_7.vmethod_1(@class);
		class5052_8 = new Class5034.Class5068(0);
		class5052_8.method_1(inheriteD: false);
		class5052_8.method_2("thin", "0.5pt");
		class5052_8.method_2("medium", "1pt");
		class5052_8.method_2("thick", "2pt");
		class5052_8.method_6("medium");
		class5052_9 = new Class5042.Class5075(0);
		class5052_9.method_1(inheriteD: false);
		class5052_9.method_3("none", method_1(95, "NONE"));
		class5052_9.method_3("hidden", method_1(57, "HIDDEN"));
		class5052_9.method_3("dotted", method_1(36, "DOTTED"));
		class5052_9.method_3("dashed", method_1(31, "DASHED"));
		class5052_9.method_3("solid", method_1(133, "SOLID"));
		class5052_9.method_3("double", method_1(37, "DOUBLE"));
		class5052_9.method_3("groove", method_1(55, "GROOVE"));
		class5052_9.method_3("ridge", method_1(119, "RIDGE"));
		class5052_9.method_3("inset", method_1(67, "INSET"));
		class5052_9.method_3("outset", method_1(101, "OUTSET"));
		class5052_9.method_6("none");
		class5052_10 = new Class5042.Class5075(0);
		class5052_10.method_1(inheriteD: false);
		class5052_10.method_3("auto", method_1(9, "AUTO"));
		class5052_10.method_3("column", method_1(28, "COLUMN"));
		class5052_10.method_3("page", method_1(104, "PAGE"));
		class5052_10.method_3("even-page", method_1(44, "EVEN_PAGE"));
		class5052_10.method_3("odd-page", method_1(100, "ODD_PAGE"));
		class5052_10.method_6("auto");
		class5052_11 = new Class5046.Class5065(0);
		class5052_11.method_1(inheriteD: false);
		@class = new Class5034.Class5068(3072);
		@class.method_6("0pt");
		@class.method_9(setByShorthand: true);
		class5052_11.vmethod_1(@class);
		@class = new Class5034.Class5068(3584);
		@class.method_6("0pt");
		@class.method_9(setByShorthand: true);
		class5052_11.vmethod_1(@class);
		@class = new Class5034.Class5068(2560);
		@class.method_6("0pt");
		@class.method_9(setByShorthand: true);
		class5052_11.vmethod_1(@class);
		@class = new Class5048.Class5081(4096);
		@class.method_3("force", method_1(53, "FORCE"));
		@class.method_6("0");
		class5052_11.vmethod_1(@class);
		@class = new Class5042.Class5075(1024);
		@class.method_3("discard", method_1(32, "DISCARD"));
		@class.method_3("retain", method_1(118, "RETAIN"));
		@class.method_6("discard");
		class5052_11.vmethod_1(@class);
	}

	private static void smethod_0(string name, Class5052 maker)
	{
		class5052_0[maker.method_0()] = maker;
		hashtable_0.Add(name, maker.method_0());
		hashtable_2.Add(maker.method_0(), name);
	}

	private static void smethod_1(string name, int id)
	{
		hashtable_1.Add(name, id);
		hashtable_2.Add(id, name);
	}

	private Class5024 method_1(int enumValue, string text)
	{
		if (class5024_0 == null)
		{
			class5024_0 = new Class5024[216];
		}
		if (class5024_0[enumValue] == null)
		{
			class5024_0[enumValue] = Class5042.smethod_0(enumValue, text);
		}
		return class5024_0[enumValue];
	}

	public static Class5052[] smethod_2()
	{
		if (class5052_0 == null)
		{
			class5052_0 = new Class5052[300];
			Class5735 @class = new Class5735();
			@class.method_28();
			@class.method_0();
			smethod_6();
			@class.method_2();
			smethod_7();
			@class.method_3();
			@class.method_4();
			@class.method_5();
			@class.method_6();
			@class.method_7();
			@class.method_8();
			@class.method_9();
			@class.method_10();
			@class.method_11();
			@class.method_14();
			@class.method_15();
			@class.method_16();
			@class.method_17();
			@class.method_18();
			@class.method_19();
			@class.method_20();
			@class.method_21();
			@class.method_22();
			@class.method_23();
			@class.method_24();
			@class.method_25();
			@class.method_26();
			@class.method_27();
			smethod_1("length", 2048);
			smethod_1("conditionality", 1024);
			smethod_1("block-progression-direction", 512);
			smethod_1("inline-progression-direction", 1536);
			smethod_1("within-line", 5120);
			smethod_1("within-column", 4608);
			smethod_1("within-page", 5632);
			smethod_1("minimum", 3072);
			smethod_1("maximum", 2560);
			smethod_1("optimum", 3584);
			smethod_1("precedence", 4096);
		}
		return class5052_0;
	}

	public static int smethod_3(string name)
	{
		if (name != null)
		{
			object obj = hashtable_0[name];
			if (obj != null)
			{
				return (int)obj;
			}
		}
		return -1;
	}

	public static int smethod_4(string name)
	{
		if (name != null)
		{
			object obj = hashtable_1[name];
			if (obj != null)
			{
				return (int)obj;
			}
		}
		return -1;
	}

	public static string smethod_5(int id)
	{
		if (((uint)id & 0xFFFFFE00u) != 0 && ((uint)id & 0x1FFu) != 0)
		{
			return string.Concat(hashtable_2[id & 0x1FF], ".", hashtable_2[id & -512]);
		}
		return (string)hashtable_2[id];
	}

	private static void smethod_6()
	{
		Class5052 @class = new Class5050.Class5085(221);
		@class.method_1(inheriteD: false);
		@class.method_6("none");
		smethod_0("source-document", @class);
		@class = new Class5050.Class5085(212);
		@class.method_1(inheriteD: false);
		@class.method_6("none");
		smethod_0("role", @class);
	}

	private void method_2()
	{
		Class5052 @class = new Class5042.Class5075(1);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("fixed", method_1(51, "FIXED"));
		@class.method_3("absolute", method_1(1, "ABSOLUTE"));
		@class.method_3("absoluterelative", method_1(1, "ABSOLUTERELATIVE"));
		@class.method_3("inlineabsolute", method_1(215, "INLINEABSOLUTE"));
		@class.method_6("auto");
		@class.method_4(class5052_0[193]);
		smethod_0("absolute-position", @class);
		Class5034.Class5068 class2 = new Class5034.Class5068(253);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_6("auto");
		class2.method_8(6);
		smethod_0("top", class2);
		class2 = new Class5034.Class5068(211);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_6("auto");
		class2.method_8(5);
		smethod_0("right", class2);
		class2 = new Class5034.Class5068(57);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_6("auto");
		class2.method_8(6);
		smethod_0("bottom", class2);
		class2 = new Class5034.Class5068(140);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_6("auto");
		class2.method_8(5);
		smethod_0("left", class2);
	}

	private static void smethod_7()
	{
		Class5052 @class = new Class5051.Class5086(6);
		@class.method_1(inheriteD: true);
		@class.method_6("center");
		smethod_0("azimuth", @class);
		@class = new Class5051.Class5086(83);
		@class.method_1(inheriteD: false);
		@class.method_6("none");
		smethod_0("cue-after", @class);
		@class = new Class5051.Class5086(84);
		@class.method_1(inheriteD: false);
		@class.method_6("none");
		smethod_0("cue-before", @class);
		@class = new Class5051.Class5086(89);
		@class.method_1(inheriteD: true);
		@class.method_6("level");
		smethod_0("elevation", @class);
		@class = new Class5051.Class5086(188);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("pause-after", @class);
		@class = new Class5051.Class5086(189);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("pause-before", @class);
		@class = new Class5051.Class5086(190);
		@class.method_1(inheriteD: true);
		@class.method_6("medium");
		smethod_0("pitch", @class);
		@class = new Class5051.Class5086(191);
		@class.method_1(inheriteD: true);
		@class.method_6("50");
		smethod_0("pitch-range", @class);
		@class = new Class5051.Class5086(192);
		@class.method_1(inheriteD: false);
		@class.method_6("auto");
		smethod_0("play-during", @class);
		@class = new Class5051.Class5086(210);
		@class.method_1(inheriteD: true);
		@class.method_6("50");
		smethod_0("richness", @class);
		@class = new Class5051.Class5086(227);
		@class.method_1(inheriteD: true);
		@class.method_6("normal");
		smethod_0("speak", @class);
		@class = new Class5051.Class5086(228);
		@class.method_1(inheriteD: true);
		@class.method_6("once");
		smethod_0("speak-header", @class);
		@class = new Class5051.Class5086(229);
		@class.method_1(inheriteD: true);
		@class.method_6("continuous");
		smethod_0("speak-numeral", @class);
		@class = new Class5051.Class5086(230);
		@class.method_1(inheriteD: true);
		@class.method_6("none");
		smethod_0("speak-punctuation", @class);
		@class = new Class5051.Class5086(231);
		@class.method_1(inheriteD: true);
		@class.method_6("medium");
		smethod_0("speech-rate", @class);
		@class = new Class5051.Class5086(236);
		@class.method_1(inheriteD: true);
		@class.method_6("50");
		smethod_0("stress", @class);
		@class = new Class5051.Class5086(258);
		@class.method_1(inheriteD: true);
		@class.method_6(string.Empty);
		smethod_0("voice-family", @class);
		@class = new Class5051.Class5086(259);
		@class.method_1(inheriteD: true);
		@class.method_6("medium");
		smethod_0("volume", @class);
	}

	private void method_3()
	{
		Class5052 @class = new Class5042.Class5075(297);
		@class.method_1(inheriteD: false);
		@class.method_3("false", method_1(48, "FALSE"));
		@class.method_3("true", method_1(149, "TRUE"));
		@class.method_6("false");
		smethod_0("background-all-page", @class);
		@class = new Class5042.Class5075(8);
		@class.method_1(inheriteD: false);
		@class.method_3("scroll", method_1(126, "SCROLL"));
		@class.method_3("fixed", method_1(51, "FIXED"));
		@class.method_6("scroll");
		smethod_0("background-attachment", @class);
		@class = new Class5074(9);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: false);
		@class.method_6("transparent");
		smethod_0("background-color", @class);
		@class = new Class5050.Class5085(10);
		@class.method_1(inheriteD: false);
		@class.method_6("none");
		smethod_0("background-image", @class);
		@class = new Class5042.Class5075(14);
		@class.method_1(inheriteD: false);
		@class.method_3("repeat", method_1(112, "REPEAT"));
		@class.method_3("repeat-x", method_1(113, "REPEATX"));
		@class.method_3("repeat-y", method_1(114, "REPEATY"));
		@class.method_3("no-repeat", method_1(96, "NOREPEAT"));
		@class.method_6("repeat");
		smethod_0("background-repeat", @class);
		@class = new Class5034.Class5068(12);
		@class.method_1(inheriteD: false);
		@class.method_6("0pt");
		@class.method_2("left", "0pt");
		@class.method_2("center", "50%");
		@class.method_2("right", "100%");
		@class.method_8(9);
		@class.method_4(class5052_0[11]);
		smethod_0("background-position-horizontal", @class);
		@class = new Class5034.Class5068(13);
		@class.method_1(inheriteD: false);
		@class.method_6("0pt");
		@class.method_2("top", "0pt");
		@class.method_2("center", "50%");
		@class.method_2("bottom", "100%");
		@class.method_8(10);
		@class.method_4(class5052_0[11]);
		smethod_0("background-position-vertical", @class);
		@class = new Class5040.Class5073(23);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: false);
		@class.method_6("black");
		Class5723 class2 = new Class5723(@class);
		class2.method_0(53, 53, 42, 38);
		class2.method_2(relativE: true);
		smethod_0("border-before-color", @class);
		@class = new Class5042.Class5075(25);
		@class.vmethod_0(class5052_9);
		class2 = new Class5723(@class);
		class2.method_0(54, 54, 43, 39);
		class2.method_2(relativE: true);
		smethod_0("border-before-style", @class);
		@class = new Class5032.Class5061(26);
		@class.vmethod_0(class5052_7);
		@class.vmethod_2(1024).method_6("discard");
		class2 = new Class5723(@class);
		class2.method_0(55, 55, 44, 40);
		class2.method_2(relativE: true);
		smethod_0("border-before-width", @class);
		@class = new Class5040.Class5073(19);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: false);
		@class.method_6("black");
		class2 = new Class5723(@class);
		class2.method_0(28, 28, 38, 42);
		class2.method_2(relativE: true);
		smethod_0("border-after-color", @class);
		@class = new Class5042.Class5075(21);
		@class.vmethod_0(class5052_9);
		class2 = new Class5723(@class);
		class2.method_0(29, 29, 39, 43);
		class2.method_2(relativE: true);
		smethod_0("border-after-style", @class);
		@class = new Class5032.Class5061(22);
		@class.vmethod_0(class5052_7);
		@class.vmethod_2(1024).method_6("discard");
		class2 = new Class5723(@class);
		class2.method_0(30, 30, 40, 40);
		class2.method_2(relativE: true);
		smethod_0("border-after-width", @class);
		@class = new Class5040.Class5073(47);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: false);
		@class.method_6("black");
		class2 = new Class5723(@class);
		class2.method_0(38, 42, 53, 53);
		class2.method_2(relativE: true);
		smethod_0("border-start-color", @class);
		@class = new Class5042.Class5075(49);
		@class.vmethod_0(class5052_9);
		class2 = new Class5723(@class);
		class2.method_0(39, 43, 54, 54);
		class2.method_2(relativE: true);
		smethod_0("border-start-style", @class);
		@class = new Class5032.Class5061(50);
		@class.vmethod_0(class5052_7);
		@class.vmethod_2(1024).method_6("discard");
		class2 = new Class5723(@class);
		class2.method_0(40, 44, 55, 55);
		class2.method_2(relativE: true);
		smethod_0("border-start-width", @class);
		@class = new Class5040.Class5073(33);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: false);
		@class.method_6("black");
		class2 = new Class5723(@class);
		class2.method_0(42, 38, 28, 28);
		class2.method_2(relativE: true);
		smethod_0("border-end-color", @class);
		@class = new Class5042.Class5075(35);
		@class.vmethod_0(class5052_9);
		class2 = new Class5723(@class);
		class2.method_0(43, 39, 29, 29);
		class2.method_2(relativE: true);
		smethod_0("border-end-style", @class);
		@class = new Class5032.Class5061(36);
		@class.vmethod_0(class5052_7);
		@class.vmethod_2(1024).method_6("discard");
		class2 = new Class5723(@class);
		class2.method_0(44, 40, 30, 30);
		class2.method_2(relativE: true);
		smethod_0("border-end-width", @class);
		@class = new Class5040.Class5073(53);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: false);
		@class.method_6("black");
		@class.method_4(class5052_0[52]);
		@class.method_4(class5052_0[32]);
		@class.method_4(class5052_0[18]);
		class2 = new Class5723(@class);
		class2.method_0(23, 23, 47, 47);
		smethod_0("border-top-color", @class);
		@class = new Class5042.Class5075(54);
		@class.vmethod_0(class5052_9);
		@class.method_4(class5052_0[52]);
		@class.method_4(class5052_0[51]);
		@class.method_4(class5052_0[18]);
		class2 = new Class5723(@class);
		class2.method_0(25, 25, 49, 49);
		smethod_0("border-top-style", @class);
		Class5069 class3 = new Class5069(55);
		class3.vmethod_0(class5052_8);
		class3.method_19(54);
		class3.method_4(class5052_0[52]);
		class3.method_4(class5052_0[56]);
		class3.method_4(class5052_0[18]);
		class2 = new Class5723(class3);
		class2.method_0(26, 26, 50, 50);
		smethod_0("border-top-width", class3);
		@class = new Class5040.Class5073(28);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: false);
		@class.method_6("black");
		@class.method_4(class5052_0[27]);
		@class.method_4(class5052_0[32]);
		@class.method_4(class5052_0[18]);
		class2 = new Class5723(@class);
		class2.method_0(19, 19, 33, 33);
		smethod_0("border-bottom-color", @class);
		@class = new Class5042.Class5075(29);
		@class.vmethod_0(class5052_9);
		@class.method_4(class5052_0[27]);
		@class.method_4(class5052_0[51]);
		@class.method_4(class5052_0[18]);
		class2 = new Class5723(@class);
		class2.method_0(21, 21, 35, 35);
		smethod_0("border-bottom-style", @class);
		class3 = new Class5069(30);
		class3.vmethod_0(class5052_8);
		class3.method_19(29);
		class3.method_4(class5052_0[27]);
		class3.method_4(class5052_0[56]);
		class3.method_4(class5052_0[18]);
		class2 = new Class5723(class3);
		class2.method_0(22, 22, 36, 36);
		smethod_0("border-bottom-width", class3);
		@class = new Class5040.Class5073(38);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: false);
		@class.method_6("black");
		@class.method_4(class5052_0[37]);
		@class.method_4(class5052_0[32]);
		@class.method_4(class5052_0[18]);
		class2 = new Class5723(@class);
		class2.method_0(47, 33, 19, 23);
		smethod_0("border-left-color", @class);
		@class = new Class5042.Class5075(39);
		@class.vmethod_0(class5052_9);
		@class.method_4(class5052_0[37]);
		@class.method_4(class5052_0[51]);
		@class.method_4(class5052_0[18]);
		class2 = new Class5723(@class);
		class2.method_0(49, 35, 21, 25);
		smethod_0("border-left-style", @class);
		class3 = new Class5069(40);
		class3.vmethod_0(class5052_8);
		class3.method_19(39);
		class3.method_4(class5052_0[37]);
		class3.method_4(class5052_0[56]);
		class3.method_4(class5052_0[18]);
		class2 = new Class5723(class3);
		class2.method_0(50, 36, 22, 26);
		smethod_0("border-left-width", class3);
		@class = new Class5040.Class5073(42);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: false);
		@class.method_6("black");
		@class.method_4(class5052_0[41]);
		@class.method_4(class5052_0[32]);
		@class.method_4(class5052_0[18]);
		class2 = new Class5723(@class);
		class2.method_0(33, 47, 23, 19);
		smethod_0("border-right-color", @class);
		@class = new Class5042.Class5075(43);
		@class.vmethod_0(class5052_9);
		@class.method_4(class5052_0[41]);
		@class.method_4(class5052_0[51]);
		@class.method_4(class5052_0[18]);
		class2 = new Class5723(@class);
		class2.method_0(35, 49, 25, 21);
		smethod_0("border-right-style", @class);
		@class = new Class5034.Class5068(289);
		smethod_0("border-top-left-radius-w", @class);
		@class = new Class5034.Class5068(290);
		smethod_0("border-top-left-radius-h", @class);
		@class = new Class5034.Class5068(291);
		smethod_0("border-top-right-radius-w", @class);
		@class = new Class5034.Class5068(292);
		smethod_0("border-top-right-radius-h", @class);
		@class = new Class5034.Class5068(293);
		smethod_0("border-bottom-right-radius-w", @class);
		@class = new Class5034.Class5068(294);
		smethod_0("border-bottom-right-radius-h", @class);
		@class = new Class5034.Class5068(295);
		smethod_0("border-bottom-left-radius-w", @class);
		@class = new Class5034.Class5068(296);
		smethod_0("border-bottom-left-radius-h", @class);
		class3 = new Class5069(44);
		class3.vmethod_0(class5052_8);
		class3.method_19(43);
		class3.method_4(class5052_0[41]);
		class3.method_4(class5052_0[56]);
		class3.method_4(class5052_0[18]);
		class2 = new Class5723(class3);
		class2.method_0(36, 50, 26, 22);
		smethod_0("border-right-width", class3);
		@class = new Class5032.Class5061(172);
		@class.vmethod_0(class5052_5);
		@class.vmethod_2(1024).method_6("discard");
		class2 = new Class5723(@class);
		class2.method_0(178, 178, 176, 175);
		class2.method_2(relativE: true);
		smethod_0("padding-before", @class);
		@class = new Class5032.Class5061(171);
		@class.vmethod_0(class5052_5);
		@class.vmethod_2(1024).method_6("discard");
		class2 = new Class5723(@class);
		class2.method_0(173, 173, 175, 176);
		class2.method_2(relativE: true);
		smethod_0("padding-after", @class);
		@class = new Class5032.Class5061(177);
		@class.vmethod_0(class5052_5);
		@class.vmethod_2(1024).method_6("discard");
		class2 = new Class5723(@class);
		class2.method_0(175, 176, 178, 178);
		class2.method_2(relativE: true);
		smethod_0("padding-start", @class);
		@class = new Class5032.Class5061(174);
		@class.vmethod_0(class5052_5);
		@class.vmethod_2(1024).method_6("discard");
		class2 = new Class5723(@class);
		class2.method_0(176, 175, 173, 173);
		class2.method_2(relativE: true);
		smethod_0("padding-end", @class);
		@class = new Class5034.Class5068(178);
		@class.vmethod_0(class5052_6);
		class2 = new Class5723(@class);
		class2.method_0(172, 172, 177, 177);
		smethod_0("padding-top", @class);
		@class = new Class5034.Class5068(173);
		@class.vmethod_0(class5052_6);
		class2 = new Class5723(@class);
		class2.method_0(171, 171, 174, 174);
		smethod_0("padding-bottom", @class);
		@class = new Class5034.Class5068(175);
		@class.vmethod_0(class5052_6);
		class2 = new Class5723(@class);
		class2.method_0(177, 174, 171, 172);
		smethod_0("padding-left", @class);
		@class = new Class5034.Class5068(176);
		@class.vmethod_0(class5052_6);
		class2 = new Class5723(@class);
		class2.method_0(174, 177, 172, 171);
		smethod_0("padding-right", @class);
	}

	private void method_4()
	{
		Class5052 @class = new Class5040.Class5073(280);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: false);
		@class.method_6("black");
		@class.method_4(class5052_0[277]);
		smethod_0("outline-color", @class);
		@class = new Class5042.Class5075(279);
		@class.vmethod_0(class5052_9);
		@class.method_4(class5052_0[277]);
		smethod_0("outline-style", @class);
		Class5069 class2 = new Class5069(278);
		class2.vmethod_0(class5052_8);
		class2.method_19(279);
		class2.method_4(class5052_0[277]);
		smethod_0("outline-width", class2);
	}

	private void method_5()
	{
		Class5052 @class = new Class5030.Class5080(101);
		@class.method_1(inheriteD: true);
		@class.method_7("sans-serif,Symbol,ZapfDingbats,SimSun", contextDep: true);
		@class.method_4(class5052_0[100]);
		smethod_0("font-family", @class);
		@class = new Class5042.Class5075(102);
		@class.method_1(inheriteD: true);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("character-by-character", method_1(25, "CHARACTER_BY_CHARACTER"));
		@class.method_6("auto");
		smethod_0("font-selection-strategy", @class);
		@class = new Class5070(103);
		@class.method_1(inheriteD: true);
		@class.method_6("12pt");
		@class.method_2("xx-small", "6.944pt");
		@class.method_2("x-small", "8.333pt");
		@class.method_2("small", "10pt");
		@class.method_2("medium", "12pt");
		@class.method_2("large", "14.4pt");
		@class.method_2("x-large", "17.28pt");
		@class.method_2("xx-large", "20.736pt");
		@class.method_3("larger", method_1(71, "LARGER"));
		@class.method_3("smaller", method_1(132, "SMALLER"));
		@class.method_8(2);
		@class.method_4(class5052_0[100]);
		smethod_0("font-size", @class);
		@class = new Class5076(105);
		@class.method_3("normal", method_1(97, "NORMAL"));
		@class.method_3("wider", method_1(160, "WIDER"));
		@class.method_3("narrower", method_1(85, "NARROWER"));
		@class.method_3("ultra-condensed", method_1(150, "ULTRA_CONDENSED"));
		@class.method_3("extra-condensed", method_1(46, "EXTRA_CONDENSED"));
		@class.method_3("condensed", method_1(29, "CONDENSED"));
		@class.method_3("semi-condensed", method_1(127, "SEMI_CONDENSED"));
		@class.method_3("semi-expanded", method_1(128, "SEMI_EXPANDED"));
		@class.method_3("expanded", method_1(45, "EXPANDED"));
		@class.method_3("extra-expanded", method_1(47, "EXTRA_EXPANDED"));
		@class.method_3("ultra-expanded", method_1(151, "ULTRA_EXPANDED"));
		@class.method_6("normal");
		smethod_0("font-stretch", @class);
		@class = new Class5048.Class5081(104);
		@class.method_1(inheriteD: true);
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_6("none");
		smethod_0("font-size-adjust", @class);
		@class = new Class5042.Class5075(106);
		@class.method_1(inheriteD: true);
		@class.method_3("normal", method_1(97, "NORMAL"));
		@class.method_3("italic", method_1(164, "ITALIC"));
		@class.method_3("oblique", method_1(165, "OBLIQUE"));
		@class.method_3("backslant", method_1(166, "BACKSLANT"));
		@class.method_6("normal");
		@class.method_4(class5052_0[100]);
		smethod_0("font-style", @class);
		@class = new Class5042.Class5075(107);
		@class.method_1(inheriteD: true);
		@class.method_3("normal", method_1(97, "NORMAL"));
		@class.method_3("small-caps", method_1(131, "SMALL_CAPS"));
		@class.method_6("normal");
		@class.method_4(class5052_0[100]);
		smethod_0("font-variant", @class);
		@class = new Class5077(108);
		@class.method_1(inheriteD: true);
		@class.method_2("normal", "400");
		@class.method_2("bold", "700");
		@class.method_3("bolder", method_1(167, "BOLDER"));
		@class.method_3("lighter", method_1(168, "LIGHTER"));
		@class.method_3("100", method_1(169, "100"));
		@class.method_3("200", method_1(170, "200"));
		@class.method_3("300", method_1(171, "300"));
		@class.method_3("400", method_1(172, "400"));
		@class.method_3("500", method_1(173, "500"));
		@class.method_3("600", method_1(174, "600"));
		@class.method_3("700", method_1(175, "700"));
		@class.method_3("800", method_1(176, "800"));
		@class.method_3("900", method_1(177, "900"));
		@class.method_6("400");
		@class.method_4(class5052_0[100]);
		smethod_0("font-weight", @class);
	}

	private void method_6()
	{
		Class5052 @class = new Class5050.Class5085(81);
		@class.method_1(inheriteD: true);
		@class.method_6("none");
		@class.method_4(class5052_0[268]);
		smethod_0("country", @class);
		@class = new Class5050.Class5085(134);
		@class.method_1(inheriteD: true);
		@class.method_6("none");
		@class.method_4(class5052_0[268]);
		smethod_0("language", @class);
		@class = new Class5050.Class5085(218);
		@class.method_1(inheriteD: true);
		@class.method_6("auto");
		smethod_0("script", @class);
		@class = new Class5042.Class5075(116);
		@class.vmethod_0(class5052_2);
		@class.method_1(inheriteD: true);
		@class.method_6("false");
		smethod_0("hyphenate", @class);
		@class = new Class5039.Class5072(117);
		@class.method_1(inheriteD: true);
		@class.method_6("-");
		smethod_0("hyphenation-character", @class);
		@class = new Class5048.Class5084(120);
		@class.method_1(inheriteD: true);
		@class.method_6("2");
		smethod_0("hyphenation-push-character-count", @class);
		@class = new Class5048.Class5084(121);
		@class.method_1(inheriteD: true);
		@class.method_6("2");
		smethod_0("hyphenation-remain-character-count", @class);
	}

	private void method_7()
	{
		Class5052 @class = new Class5034.Class5068(151);
		@class.method_1(inheriteD: false);
		@class.method_6("0pt");
		@class.method_4(class5052_0[147]);
		@class.method_8(5);
		@class.method_3("auto", method_1(9, "AUTO"));
		smethod_0("margin-top", @class);
		@class = new Class5034.Class5068(148);
		@class.method_1(inheriteD: false);
		@class.method_6("0pt");
		@class.method_4(class5052_0[147]);
		@class.method_8(5);
		@class.method_3("auto", method_1(9, "AUTO"));
		smethod_0("margin-bottom", @class);
		@class = new Class5034.Class5068(149);
		@class.method_1(inheriteD: false);
		@class.method_6("0pt");
		@class.method_4(class5052_0[147]);
		@class.method_8(5);
		@class.method_3("auto", method_1(9, "AUTO"));
		smethod_0("margin-left", @class);
		@class = new Class5034.Class5068(150);
		@class.method_1(inheriteD: false);
		@class.method_6("0pt");
		@class.method_4(class5052_0[147]);
		@class.method_8(5);
		@class.method_3("auto", method_1(9, "AUTO"));
		smethod_0("margin-right", @class);
		@class = new Class5046.Class5065(223);
		@class.vmethod_0(class5052_11);
		Class5723 class2 = new Class5726(@class);
		class2.method_0(151, 151, 150, 149);
		class2.method_1(useParenT: false);
		class2.method_2(relativE: true);
		smethod_0("space-before", @class);
		@class = new Class5046.Class5065(222);
		@class.vmethod_0(class5052_11);
		class2 = new Class5726(@class);
		class2.method_0(148, 148, 149, 150);
		class2.method_1(useParenT: false);
		class2.method_2(relativE: true);
		smethod_0("space-after", @class);
		@class = new Class5034.Class5068(233);
		@class.method_1(inheriteD: true);
		@class.method_6("0pt");
		@class.method_8(4);
		Class5725 class3 = new Class5725(@class);
		class3.method_0(149, 150, 151, 151);
		class3.method_1(useParenT: false);
		class3.method_2(relativE: true);
		class3.method_4(new int[4] { 175, 176, 178, 178 });
		class3.method_5(new int[4] { 40, 44, 55, 55 });
		smethod_0("start-indent", @class);
		@class = new Class5034.Class5068(91);
		@class.method_1(inheriteD: true);
		@class.method_6("0pt");
		@class.method_8(4);
		Class5725 class4 = new Class5725(@class);
		class4.method_0(150, 149, 148, 148);
		class4.method_1(useParenT: false);
		class4.method_2(relativE: true);
		class4.method_4(new int[4] { 176, 175, 173, 173 });
		class4.method_5(new int[4] { 44, 40, 30, 30 });
		smethod_0("end-indent", @class);
	}

	private void method_8()
	{
		Class5052 @class = new Class5046.Class5065(224);
		@class.vmethod_0(class5052_11);
		smethod_0("space-end", @class);
		@class = new Class5046.Class5065(225);
		@class.vmethod_0(class5052_11);
		smethod_0("space-start", @class);
	}

	private void method_9()
	{
		Class5052 @class = new Class5042.Class5075(203);
		@class.method_1(inheriteD: false);
		@class.method_3("static", method_1(136, "STATIC"));
		@class.method_3("relative", method_1(110, "RELATIVE"));
		@class.method_6("static");
		@class.method_4(class5052_0[193]);
		smethod_0("relative-position", @class);
	}

	private void method_10()
	{
		Class5052 @class = new Class5034.Class5068(3);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("baseline", method_1(12, "BASELINE"));
		@class.method_3("before-edge", method_1(14, "BEFORE_EDGE"));
		@class.method_3("text-before-edge", method_1(142, "TEXT_BEFORE_EDGE"));
		@class.method_3("middle", method_1(84, "MIDDLE"));
		@class.method_3("central", method_1(24, "CENTRAL"));
		@class.method_3("after-edge", method_1(4, "AFTER_EDGE"));
		@class.method_3("text-after-edge", method_1(141, "TEXT_AFTER_EDGE"));
		@class.method_3("ideographic", method_1(59, "IDEOGRAPHIC"));
		@class.method_3("alphabetic", method_1(6, "ALPHABETIC"));
		@class.method_3("hanging", method_1(56, "HANGING"));
		@class.method_3("mathematical", method_1(82, "MATHEMATICAL"));
		@class.method_6("auto");
		@class.method_8(12);
		@class.method_4(class5052_0[256]);
		smethod_0("alignment-adjust", @class);
		@class = new Class5042.Class5075(4);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("baseline", method_1(12, "BASELINE"));
		@class.method_3("before-edge", method_1(14, "BEFORE_EDGE"));
		@class.method_3("text-before-edge", method_1(142, "TEXT_BEFORE_EDGE"));
		@class.method_3("middle", method_1(84, "MIDDLE"));
		@class.method_3("central", method_1(24, "CENTRAL"));
		@class.method_3("after-edge", method_1(4, "AFTER_EDGE"));
		@class.method_3("text-after-edge", method_1(141, "TEXT_AFTER_EDGE"));
		@class.method_3("ideographic", method_1(59, "IDEOGRAPHIC"));
		@class.method_3("alphabetic", method_1(6, "ALPHABETIC"));
		@class.method_3("hanging", method_1(56, "HANGING"));
		@class.method_3("mathematical", method_1(82, "MATHEMATICAL"));
		@class.method_6("auto");
		@class.method_4(class5052_0[256]);
		smethod_0("alignment-baseline", @class);
		@class = new Class5034.Class5068(15);
		@class.method_1(inheriteD: false);
		@class.method_3("baseline", method_1(12, "BASELINE"));
		@class.method_3("sub", method_1(137, "SUB"));
		@class.method_3("super", method_1(138, "SUPER"));
		@class.method_6("baseline");
		@class.method_4(class5052_0[256]);
		@class.method_8(0);
		smethod_0("baseline-shift", @class);
		@class = new Class5042.Class5075(87);
		@class.method_1(inheriteD: true);
		@class.method_3("before", method_1(13, "BEFORE"));
		@class.method_3("after", method_1(3, "AFTER"));
		@class.method_3("center", method_1(23, "CENTER"));
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("distribute", method_1(163, "DISTRIBUTE"));
		@class.method_3("fill", method_1(162, "FILL"));
		@class.method_6("auto");
		smethod_0("display-align", @class);
		@class = new Class5042.Class5075(88);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("use-script", method_1(157, "USE_SCRIPT"));
		@class.method_3("no-change", method_1(87, "NO_CHANGE"));
		@class.method_3("reset-size", method_1(116, "RESET_SIZE"));
		@class.method_3("ideographic", method_1(59, "IDEOGRAPHIC"));
		@class.method_3("alphabetic", method_1(6, "ALPHABETIC"));
		@class.method_3("hanging", method_1(56, "HANGING"));
		@class.method_3("mathematical", method_1(82, "MATHEMATICAL"));
		@class.method_3("central", method_1(24, "CENTRAL"));
		@class.method_3("middle", method_1(84, "MIDDLE"));
		@class.method_3("text-after-edge", method_1(141, "TEXT_AFTER_EDGE"));
		@class.method_3("text-before-edge", method_1(142, "TEXT_BEFORE_EDGE"));
		@class.method_6("auto");
		@class.method_4(class5052_0[256]);
		smethod_0("dominant-baseline", @class);
		@class = new Class5042.Class5075(202);
		@class.method_1(inheriteD: true);
		@class.method_3("before", method_1(13, "BEFORE"));
		@class.method_3("baseline", method_1(12, "BASELINE"));
		@class.method_6("before");
		smethod_0("relative-align", @class);
	}

	private void method_11()
	{
		Class5052 @class = new Class5045.Class5064(17);
		@class.method_1(inheriteD: false);
		@class.method_8(6);
		Class5034.Class5068 class2 = new Class5034.Class5068(3072);
		class2.method_6("auto");
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_8(6);
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		class2 = new Class5034.Class5068(3584);
		class2.method_6("auto");
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_8(6);
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		class2 = new Class5034.Class5068(2560);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_6("auto");
		class2.method_8(6);
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		Class5724 class3 = new Class5724(@class);
		class3.method_0(115, 115, 264, 264);
		class3.method_4(new int[2][]
		{
			new int[4] { 162, 162, 163, 163 },
			new int[4] { 155, 155, 157, 157 }
		});
		class3.method_2(relativE: true);
		@class.method_10(class3);
		smethod_0("block-progression-dimension", @class);
		class2 = new Class5034.Class5068(78);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_3("scale-to-fit", method_1(125, "SCALE_TO_FIT"));
		class2.method_3("scale-down-to-fit", method_1(187, "SCALE_DOWN_TO_FIT"));
		class2.method_3("scale-up-to-fit", method_1(188, "SCALE_UP_TO_FIT"));
		class2.method_6("auto");
		class2.method_8(8);
		smethod_0("content-height", class2);
		class2 = new Class5034.Class5068(80);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_3("scale-to-fit", method_1(125, "SCALE_TO_FIT"));
		class2.method_3("scale-down-to-fit", method_1(187, "SCALE_DOWN_TO_FIT"));
		class2.method_3("scale-up-to-fit", method_1(188, "SCALE_UP_TO_FIT"));
		class2.method_6("auto");
		class2.method_8(7);
		smethod_0("content-width", class2);
		class2 = new Class5034.Class5068(115);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_8(6);
		class2.method_6("auto");
		smethod_0("height", class2);
		@class = new Class5045.Class5064(127);
		@class.method_1(inheriteD: false);
		@class.method_8(5);
		class2 = new Class5034.Class5068(3072);
		class2.method_6("auto");
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_8(5);
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		class2 = new Class5034.Class5068(3584);
		class2.method_6("auto");
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_8(5);
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		class2 = new Class5034.Class5068(2560);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_6("auto");
		class2.method_8(5);
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		class3 = new Class5724(@class);
		class3.method_2(relativE: true);
		class3.method_0(264, 264, 115, 115);
		class3.method_4(new int[2][]
		{
			new int[4] { 163, 163, 162, 162 },
			new int[4] { 157, 157, 155, 162 }
		});
		@class.method_10(class3);
		smethod_0("inline-progression-dimension", @class);
		@class = new Class5034.Class5068(155);
		@class.method_3("NONE", method_1(95, "NONE"));
		@class.method_1(inheriteD: false);
		@class.method_6("0pt");
		@class.method_8(6);
		smethod_0("max-height", @class);
		@class = new Class5034.Class5068(157);
		@class.method_3("NONE", method_1(95, "NONE"));
		@class.method_1(inheriteD: false);
		@class.method_6("none");
		@class.method_8(5);
		smethod_0("max-width", @class);
		@class = new Class5034.Class5068(162);
		@class.method_1(inheriteD: false);
		@class.method_6("0pt");
		@class.method_8(6);
		smethod_0("min-height", @class);
		@class = new Class5034.Class5068(163);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_8(5);
		smethod_0("min-width", @class);
		@class = new Class5042.Class5075(215);
		@class.method_1(inheriteD: true);
		@class.method_3("uniform", method_1(154, "UNIFORM"));
		@class.method_3("non-uniform", method_1(94, "NON_UNIFORM"));
		@class.method_6("uniform");
		smethod_0("scaling", @class);
		@class = new Class5042.Class5075(216);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("integer-pixels", method_1(69, "INTEGER_PIXELS"));
		@class.method_3("resample-any-method", method_1(115, "RESAMPLE_ANY_METHOD"));
		@class.method_6("auto");
		smethod_0("scaling-method", @class);
		class2 = new Class5034.Class5068(264);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_8(5);
		class2.method_6("auto");
		smethod_0("width", class2);
		class2 = new Class5034.Class5068(270);
		class2.method_1(inheriteD: false);
		class2.method_6("0pt");
		smethod_0("fox:block-progression-unit", class2);
	}

	private Class5024 method_12(int pv, int wm)
	{
		switch (pv)
		{
		case 73:
			pv = wm switch
			{
				79 => 135, 
				121 => 39, 
				_ => 135, 
			};
			break;
		case 120:
			pv = wm switch
			{
				79 => 39, 
				121 => 135, 
				_ => 39, 
			};
			break;
		}
		return method_13(pv);
	}

	private Class5024 method_13(int pv)
	{
		return pv switch
		{
			135 => method_1(135, "START"), 
			39 => method_1(39, "END"), 
			_ => null, 
		};
	}

	private void method_14()
	{
		Class5052 @class = new Class5042.Class5075(118);
		@class.method_1(inheriteD: true);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("column", method_1(28, "COLUMN"));
		@class.method_3("page", method_1(104, "PAGE"));
		@class.method_6("auto");
		smethod_0("hyphenation-keep", @class);
		@class = new Class5048.Class5081(119);
		@class.method_1(inheriteD: true);
		@class.method_3("no-limit", method_1(89, "NO_LIMIT"));
		@class.method_6("no-limit");
		smethod_0("hyphenation-ladder-count", @class);
		@class = new Class5034.Class5068(135);
		@class.method_1(inheriteD: true);
		@class.method_6("0pt");
		@class.method_8(5);
		smethod_0("last-line-end-indent", @class);
		@class = new Class5066(144);
		@class.vmethod_0(class5052_11);
		@class.method_1(inheriteD: true);
		@class.method_2("normal", "1.2");
		@class.method_8(1);
		@class.method_7("normal", contextDep: true);
		@class.method_4(class5052_0[100]);
		smethod_0("line-height", @class);
		@class = new Class5042.Class5075(145);
		@class.method_1(inheriteD: true);
		@class.method_3("consider-shifts", method_1(30, "CONSIDER_SHIFTS"));
		@class.method_3("disregard-shifts", method_1(33, "DISREGARD_SHIFTS"));
		@class.method_6("consider-shifts");
		smethod_0("line-height-shift-adjustment", @class);
		@class = new Class5042.Class5075(146);
		@class.method_1(inheriteD: true);
		@class.method_3("line-height", method_1(76, "LINE_HEIGHT"));
		@class.method_3("font-height", method_1(52, "FONT_HEIGHT"));
		@class.method_3("max-height", method_1(83, "MAX_HEIGHT"));
		@class.method_6("max-height");
		smethod_0("line-stacking-strategy", @class);
		@class = new Class5042.Class5075(143);
		@class.method_1(inheriteD: true);
		@class.method_3("ignore", method_1(60, "IGNORE"));
		@class.method_3("preserve", method_1(108, "PRESERVE"));
		@class.method_3("treat-as-space", method_1(147, "TREAT_AS_SPACE"));
		@class.method_3("treat-as-zero-width-space", method_1(148, "TREAT_AS_ZERO_WIDTH_SPACE"));
		@class.method_6("treat-as-space");
		@class.method_4(class5052_0[260]);
		smethod_0("linefeed-treatment", @class);
		@class = new Class5042.Class5075(262);
		@class.method_1(inheriteD: true);
		@class.method_3("ignore", method_1(60, "IGNORE"));
		@class.method_3("preserve", method_1(108, "PRESERVE"));
		@class.method_3("ignore-if-before-linefeed", method_1(62, "IGNORE_IF_BEFORE_LINEFEED"));
		@class.method_3("ignore-if-after-linefeed", method_1(61, "IGNORE_IF_AFTER_LINEFEED"));
		@class.method_3("ignore-if-surrounding-linefeed", method_1(63, "IGNORE_IF_SURROUNDING_LINEFEED"));
		@class.method_6("ignore-if-surrounding-linefeed");
		@class.method_4(class5052_0[260]);
		smethod_0("white-space-treatment", @class);
		@class = new Class5078(245, this);
		@class.method_1(inheriteD: true);
		@class.method_3("center", method_1(23, "CENTER"));
		@class.method_3("end", method_1(39, "END"));
		@class.method_3("start", method_1(135, "START"));
		@class.method_3("justify", method_1(70, "JUSTIFY"));
		@class.method_3("left", method_1(73, "LEFT"));
		@class.method_3("right", method_1(120, "RIGHT"));
		@class.method_3("inside", method_1(135, "START"));
		@class.method_3("outside", method_1(39, "END"));
		@class.method_6("start");
		smethod_0("text-align", @class);
		@class = new Class5079(246, this);
		@class.method_1(inheriteD: false);
		@class.method_3("relative", method_1(110, "RELATIVE"));
		@class.method_3("center", method_1(23, "CENTER"));
		@class.method_3("end", method_1(39, "END"));
		@class.method_3("right", method_1(39, "END"));
		@class.method_3("start", method_1(135, "START"));
		@class.method_3("left", method_1(135, "START"));
		@class.method_3("justify", method_1(70, "JUSTIFY"));
		@class.method_3("inside", method_1(135, "START"));
		@class.method_3("outside", method_1(39, "END"));
		@class.method_7("relative", contextDep: true);
		smethod_0("text-align-last", @class);
		@class = new Class5034.Class5068(250);
		@class.method_1(inheriteD: true);
		@class.method_6("0pt");
		@class.method_8(5);
		smethod_0("text-indent", @class);
		@class = new Class5042.Class5075(261);
		@class.vmethod_0(class5052_2);
		@class.method_1(inheriteD: true);
		@class.method_6("true");
		@class.method_4(class5052_0[260]);
		smethod_0("white-space-collapse", @class);
		@class = new Class5042.Class5075(266);
		@class.method_1(inheriteD: true);
		@class.method_3("wrap", method_1(161, "WRAP"));
		@class.method_3("no-wrap", method_1(93, "NO_WRAP"));
		@class.method_6("wrap");
		@class.method_4(class5052_0[260]);
		smethod_0("wrap-option", @class);
	}

	private void method_15()
	{
		Class5052 @class = new Class5039.Class5072(69);
		@class.method_1(inheriteD: false);
		@class.method_6("none");
		smethod_0("character", @class);
		@class = new Class5067(141);
		@class.vmethod_0(class5052_11);
		@class.method_1(inheriteD: true);
		@class.vmethod_2(4096).method_6("force");
		@class.vmethod_2(1024).method_6("discard");
		@class.method_6("normal");
		@class.method_3("normal", method_1(97, "NORMAL"));
		smethod_0("letter-spacing", @class);
		@class = new Class5042.Class5075(237);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("suppress", method_1(139, "SUPPRESS"));
		@class.method_3("retain", method_1(118, "RETAIN"));
		@class.method_6("auto");
		smethod_0("suppress-at-line-break", @class);
		@class = new Class5056(248);
		@class.method_1(inheriteD: false);
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_3("underline", method_1(153, "UNDERLINE"));
		@class.method_3("overline", method_1(103, "OVERLINE"));
		@class.method_3("line-through", method_1(77, "LINE_THROUGH"));
		@class.method_3("blink", method_1(17, "BLINK"));
		@class.method_3("no-underline", method_1(92, "NO_UNDERLINE"));
		@class.method_3("no-overline", method_1(91, "NO_OVERLINE"));
		@class.method_3("no-line-through", method_1(90, "NO_LINE_THROUGH"));
		@class.method_3("no-blink", method_1(86, "NO_BLINK"));
		@class.method_6("none");
		smethod_0("text-decoration", @class);
		@class = new Class5051.Class5086(251);
		@class.method_1(inheriteD: false);
		@class.method_6("none");
		smethod_0("text-shadow", @class);
		@class = new Class5042.Class5075(252);
		@class.method_1(inheriteD: true);
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_3("capitalize", method_1(22, "CAPITALIZE"));
		@class.method_3("uppercase", method_1(155, "UPPERCASE"));
		@class.method_3("lowercase", method_1(78, "LOWERCASE"));
		@class.method_6("none");
		smethod_0("text-transform", @class);
		@class = new Class5042.Class5075(254);
		@class.vmethod_0(class5052_2);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_1(inheriteD: false);
		@class.method_6("auto");
		smethod_0("treat-as-word-space", @class);
		@class = new Class5067(265);
		@class.vmethod_0(class5052_11);
		@class.method_1(inheriteD: true);
		@class.vmethod_2(4096).method_6("force");
		@class.vmethod_2(1024).method_6("discard");
		@class.method_6("normal");
		@class.method_3("normal", method_1(97, "NORMAL"));
		smethod_0("word-spacing", @class);
	}

	private void method_16()
	{
		Class5052 @class = new Class5040.Class5073(72);
		@class.vmethod_0(class5052_1);
		@class.method_1(inheriteD: true);
		@class.method_6("black");
		smethod_0("color", @class);
		@class = new Class5050.Class5085(73);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("color-profile-name", @class);
		@class = new Class5042.Class5075(204);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("perceptual", method_1(107, "PERCEPTUAL"));
		@class.method_3("relative-colorimetric", method_1(111, "RELATIVE_COLOMETRIC"));
		@class.method_3("saturation", method_1(124, "SATURATION"));
		@class.method_3("absolute-colorimetric", method_1(2, "ABSOLUTE_COLORMETRIC"));
		@class.method_6("auto");
		smethod_0("rendering-intent", @class);
	}

	private void method_17()
	{
		Class5052 @class = new Class5042.Class5075(70);
		@class.method_1(inheriteD: false);
		@class.method_3("start", method_1(135, "START"));
		@class.method_3("end", method_1(39, "END"));
		@class.method_3("left", method_1(135, "START"));
		@class.method_3("right", method_1(39, "END"));
		@class.method_3("both", method_1(19, "BOTH"));
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_6("none");
		smethod_0("clear", @class);
		@class = new Class5042.Class5075(95);
		@class.method_1(inheriteD: false);
		@class.method_3("before", method_1(13, "BEFORE"));
		@class.method_3("start", method_1(135, "START"));
		@class.method_3("end", method_1(39, "END"));
		@class.method_3("left", method_1(135, "START"));
		@class.method_3("right", method_1(39, "END"));
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_6("none");
		smethod_0("float", @class);
		@class = new Class5042.Class5075(130);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_3("line", method_1(75, "LINE"));
		@class.method_3("indent", method_1(65, "INDENT"));
		@class.method_3("block", method_1(18, "BLOCK"));
		@class.method_6("none");
		smethod_0("intrusion-displace", @class);
	}

	private void method_18()
	{
		Class5052 @class = new Class5042.Class5075(58);
		@class.vmethod_0(class5052_10);
		@class.method_4(class5052_0[179]);
		smethod_0("break-after", @class);
		@class = new Class5042.Class5075(59);
		@class.vmethod_0(class5052_10);
		@class.method_4(class5052_0[180]);
		smethod_0("break-before", @class);
		@class = new Class5043.Class5062(131);
		@class.vmethod_0(class5052_3);
		@class.method_1(inheriteD: true);
		@class.method_6("auto");
		@class.method_4(class5052_0[181]);
		smethod_0("keep-together", @class);
		@class = new Class5043.Class5062(132);
		@class.vmethod_0(class5052_3);
		@class.method_1(inheriteD: false);
		@class.method_6("auto");
		@class.method_4(class5052_0[179]);
		smethod_0("keep-with-next", @class);
		@class = new Class5043.Class5062(133);
		@class.vmethod_0(class5052_3);
		@class.method_1(inheriteD: false);
		@class.method_6("auto");
		@class.method_4(class5052_0[180]);
		smethod_0("keep-with-previous", @class);
		@class = new Class5048.Class5081(168);
		@class.method_1(inheriteD: true);
		@class.method_6("2");
		smethod_0("orphans", @class);
		@class = new Class5048.Class5081(263);
		@class.method_1(inheriteD: true);
		@class.method_6("2");
		smethod_0("widows", @class);
		@class = new Class5034.Class5068(271);
		@class.method_1(inheriteD: true);
		@class.method_6("0pt");
		smethod_0("fox:widow-content-limit", @class);
		@class = new Class5034.Class5068(272);
		@class.method_1(inheriteD: true);
		@class.method_6("0pt");
		smethod_0("fox:orphan-content-limit", @class);
	}

	private void method_19()
	{
		Class5052 @class = new Class5025.Class5053(71);
		@class.method_1(inheriteD: false);
		@class.method_6("auto");
		@class.method_3("auto", method_1(9, "AUTO"));
		smethod_0("clip", @class);
		@class = new Class5042.Class5075(169);
		@class.method_1(inheriteD: false);
		@class.method_3("visible", method_1(159, "VISIBLE"));
		@class.method_3("hidden", method_1(57, "HIDDEN"));
		@class.method_3("scroll", method_1(126, "SCROLL"));
		@class.method_3("error-if-overflow", method_1(42, "ERROR_IF_OVERFLOW"));
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_6("auto");
		smethod_0("overflow", @class);
		@class = new Class5082(197);
		@class.method_1(inheriteD: true);
		@class.method_6("0");
		smethod_0("reference-orientation", @class);
		@class = new Class5042.Class5075(226);
		@class.method_1(inheriteD: false);
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_3("all", method_1(5, "ALL"));
		@class.method_6("none");
		smethod_0("span", @class);
		@class = new Class5042.Class5075(273);
		@class.vmethod_0(class5052_2);
		@class.method_1(inheriteD: true);
		@class.method_6("false");
		smethod_0("fox:disable-column-balancing", @class);
		@class = new Class5042.Class5075(298);
		@class.method_1(inheriteD: false);
		@class.method_3("false", method_1(48, "FALSE"));
		@class.method_3("true", method_1(149, "TRUE"));
		@class.method_6("false");
		smethod_0("html-body", @class);
	}

	private void method_20()
	{
		Class5052 @class = new Class5042.Class5075(136);
		@class.method_1(inheriteD: true);
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_3("reference-area", method_1(109, "REFERENCE_AREA"));
		@class.method_3("page", method_1(104, "PAGE"));
		@class.method_6("none");
		smethod_0("leader-alignment", @class);
		@class = new Class5042.Class5075(138);
		@class.method_1(inheriteD: true);
		@class.method_3("space", method_1(134, "SPACE"));
		@class.method_3("rule", method_1(123, "RULE"));
		@class.method_3("dots", method_1(35, "DOTS"));
		@class.method_3("use-content", method_1(158, "USECONTENT"));
		@class.method_6("space");
		smethod_0("leader-pattern", @class);
		@class = new Class5034.Class5068(139);
		@class.method_1(inheriteD: true);
		@class.method_7("use-font-metrics", contextDep: true);
		@class.method_2("use-font-metrics", "0pt");
		@class.method_8(3);
		smethod_0("leader-pattern-width", @class);
		@class = new Class5045.Class5064(137);
		@class.method_1(inheriteD: true);
		@class.method_8(3);
		Class5052 class2 = new Class5034.Class5068(3072);
		class2.method_6("0pt");
		class2.method_8(5);
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		class2 = new Class5034.Class5068(3584);
		class2.method_6("12.0pt");
		class2.method_8(5);
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		class2 = new Class5034.Class5068(2560);
		class2.method_7("100%", contextDep: true);
		class2.method_8(5);
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		smethod_0("leader-length", @class);
		@class = new Class5042.Class5075(213);
		@class.method_1(inheriteD: true);
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_3("dotted", method_1(36, "DOTTED"));
		@class.method_3("dashed", method_1(31, "DASHED"));
		@class.method_3("solid", method_1(133, "SOLID"));
		@class.method_3("double", method_1(37, "DOUBLE"));
		@class.method_3("groove", method_1(55, "GROOVE"));
		@class.method_3("ridge", method_1(119, "RIDGE"));
		@class.method_6("solid");
		smethod_0("rule-style", @class);
		@class = new Class5034.Class5068(214);
		@class.method_1(inheriteD: true);
		@class.method_6("1.0pt");
		smethod_0("rule-thickness", @class);
	}

	private void method_21()
	{
		Class5052 @class = new Class5051.Class5086(2);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("active-state", @class);
		@class = new Class5051.Class5086(5);
		@class.method_1(inheriteD: true);
		@class.method_6("false");
		smethod_0("auto-restore", @class);
		@class = new Class5051.Class5086(61);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("case-name", @class);
		@class = new Class5051.Class5086(62);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("case-title", @class);
		@class = new Class5051.Class5086(85);
		@class.method_1(inheriteD: false);
		@class.method_6("0pt");
		smethod_0("destination-placement-offset", @class);
		@class = new Class5050.Class5085(94);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("external-destination", @class);
		@class = new Class5050.Class5085(299);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("base-dir", @class);
		@class = new Class5051.Class5086(123);
		@class.method_1(inheriteD: false);
		@class.method_6("false");
		smethod_0("indicate-destination", @class);
		@class = new Class5050.Class5085(128);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("internal-destination", @class);
		@class = new Class5042.Class5075(219);
		@class.method_1(inheriteD: false);
		@class.method_3("new", method_1(190, "NEW"));
		@class.method_3("replace", method_1(189, "REPLACE"));
		@class.method_6("replace");
		smethod_0("show-destination", @class);
		@class = new Class5042.Class5075(234);
		@class.method_1(inheriteD: false);
		@class.method_3("show", method_1(130, "SHOW"));
		@class.method_3("hide", method_1(58, "HIDE"));
		@class.method_6("show");
		smethod_0("starting-state", @class);
		@class = new Class5051.Class5086(238);
		@class.method_1(inheriteD: false);
		@class.method_6("xsl-any");
		smethod_0("switch-to", @class);
		@class = new Class5051.Class5086(242);
		@class.method_1(inheriteD: false);
		@class.method_6("use-target-processing-context");
		smethod_0("target-presentation-context", @class);
		@class = new Class5051.Class5086(243);
		@class.method_1(inheriteD: false);
		@class.method_6("document-root");
		smethod_0("target-processing-context", @class);
		@class = new Class5051.Class5086(244);
		@class.method_1(inheriteD: false);
		@class.method_6("use-normal-stylesheet");
		smethod_0("target-stylesheet", @class);
	}

	private void method_22()
	{
		Class5052 @class = new Class5050.Class5085(152);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("marker-class-name", @class);
		@class = new Class5050.Class5085(207);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("retrieve-class-name", @class);
		@class = new Class5042.Class5075(208);
		@class.method_1(inheriteD: false);
		@class.method_3("first-starting-within-page", method_1(54, "FSWP"));
		@class.method_3("first-including-carryover", method_1(49, "FIC"));
		@class.method_3("last-starting-within-page", method_1(81, "LSWP"));
		@class.method_3("last-ending-within-page", method_1(74, "LEWP"));
		@class.method_6("first-starting-within-page");
		smethod_0("retrieve-position", @class);
		@class = new Class5042.Class5075(205);
		@class.method_1(inheriteD: false);
		@class.method_3("page", method_1(104, "PAGE"));
		@class.method_3("page-sequence", method_1(105, "PAGE_SEQUENCE"));
		@class.method_3("document", method_1(34, "DOCUMENT"));
		@class.method_6("page-sequence");
		smethod_0("retrieve-boundary", @class);
		@class = new Class5042.Class5075(209);
		@class.method_1(inheriteD: false);
		@class.method_3("first-starting", method_1(191, "FIRST_STARTING"));
		@class.method_3("first-including-carryover", method_1(49, "FIC"));
		@class.method_3("last-starting", method_1(192, "LAST_STARTING"));
		@class.method_3("last-ending", method_1(193, "LAST_ENDING"));
		@class.method_6("first-starting");
		smethod_0("retrieve-position-within-table", @class);
		@class = new Class5042.Class5075(206);
		@class.method_1(inheriteD: false);
		@class.method_3("table", method_1(194, "TABLE"));
		@class.method_3("table-fragment", method_1(195, "TABLE_FRAGMENT"));
		@class.method_3("page", method_1(34, "PAGE"));
		@class.method_6("table");
		smethod_0("retrieve-boundary-within-table", @class);
	}

	private void method_23()
	{
		Class5052 @class = new Class5050.Class5085(110);
		@class.method_1(inheriteD: false);
		@class.method_6("1");
		smethod_0("format", @class);
		@class = new Class5039.Class5072(113);
		@class.method_1(inheriteD: false);
		@class.method_6("none");
		smethod_0("grouping-separator", @class);
		@class = new Class5048.Class5081(114);
		@class.method_1(inheriteD: false);
		@class.method_6("0");
		smethod_0("grouping-size", @class);
		@class = new Class5042.Class5075(142);
		@class.method_1(inheriteD: false);
		@class.method_3("alphabetic", method_1(6, "ALPHABETIC"));
		@class.method_3("traditional", method_1(146, "TRADITIONAL"));
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_6("auto");
		smethod_0("letter-value", @class);
		@class = new Class5050.Class5085(276);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("fox:number-conversion-features", @class);
	}

	private void method_24()
	{
		Class5052 @class = new Class5042.Class5075(16);
		@class.method_1(inheriteD: false);
		@class.method_3("blank", method_1(16, "BLANK"));
		@class.method_3("not-blank", method_1(98, "NOT_BLANK"));
		@class.method_3("any", method_1(8, "ANY"));
		@class.method_6("any");
		smethod_0("blank-or-not-blank", @class);
		@class = new Class5048.Class5084(74);
		@class.method_1(inheriteD: false);
		@class.method_6("1");
		smethod_0("column-count", @class);
		Class5034.Class5068 class2 = new Class5034.Class5068(75);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_6("0.25in");
		smethod_0("column-gap", class2);
		@class = new Class5034.Class5068(93);
		@class.method_1(inheriteD: true);
		@class.method_6("0pt");
		@class.method_8(0);
		smethod_0("extent", @class);
		@class = new Class5050.Class5085(98);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("flow-name", @class);
		@class = new Class5042.Class5075(109);
		@class.method_1(inheriteD: false);
		@class.method_3("even", method_1(43, "EVEN"));
		@class.method_3("odd", method_1(99, "ODD"));
		@class.method_3("end-on-even", method_1(40, "END_ON_EVEN"));
		@class.method_3("end-on-odd", method_1(41, "END_ON_ODD"));
		@class.method_3("no-force", method_1(88, "NO_FORCE"));
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_6("auto");
		smethod_0("force-page-count", @class);
		@class = new Class5048.Class5084(126);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("auto-odd", method_1(11, "AUTO_ODD"));
		@class.method_3("auto-even", method_1(10, "AUTO_EVEN"));
		@class.method_6("auto");
		smethod_0("initial-page-number", @class);
		@class = new Class5050.Class5085(153);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("master-name", @class);
		@class = new Class5050.Class5085(154);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("master-reference", @class);
		@class = new Class5048.Class5081(156);
		@class.method_1(inheriteD: false);
		@class.method_3("no-limit", method_1(89, "NO_LIMIT"));
		@class.method_6("no-limit");
		smethod_0("maximum-repeats", @class);
		@class = new Class5042.Class5075(161);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("paginate", method_1(106, "PAGINATE"));
		@class.method_3("bounded-in-one-dimension", method_1(21, "BOUNDED_IN_ONE_DIMENSION"));
		@class.method_3("unbounded", method_1(152, "UNBOUNDED"));
		@class.method_6("auto");
		smethod_0("media-usage", @class);
		@class = new Class5042.Class5075(167);
		@class.method_1(inheriteD: false);
		@class.method_3("odd", method_1(99, "ODD"));
		@class.method_3("even", method_1(43, "EVEN"));
		@class.method_3("any", method_1(8, "ANY"));
		@class.method_6("any");
		smethod_0("odd-or-even", @class);
		class2 = new Class5071(183);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_3("indefinite", method_1(64, "INDEFINITE"));
		class2.method_6("auto");
		smethod_0("page-height", class2);
		@class = new Class5042.Class5075(185);
		@class.method_1(inheriteD: false);
		@class.method_3("first", method_1(50, "FIRST"));
		@class.method_3("last", method_1(72, "LAST"));
		@class.method_3("rest", method_1(117, "REST"));
		@class.method_3("any", method_1(8, "ANY"));
		@class.method_3("only", method_1(186, "ONLY"));
		@class.method_6("any");
		smethod_0("page-position", @class);
		class2 = new Class5071(186);
		class2.method_1(inheriteD: false);
		class2.method_3("auto", method_1(9, "AUTO"));
		class2.method_3("indefinite", method_1(64, "INDEFINITE"));
		class2.method_6("auto");
		smethod_0("page-width", class2);
		@class = new Class5042.Class5075(194);
		@class.vmethod_0(class5052_2);
		@class.method_1(inheriteD: false);
		@class.method_6("false");
		smethod_0("precedence", @class);
		@class = new Class5050.Class5085(199);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("region-name", @class);
	}

	private void method_25()
	{
		Class5052 @class = new Class5083(20);
		@class.method_1(inheriteD: false);
		@class.method_3("force", method_1(53, "FORCE"));
		smethod_0("border-after-precedence", @class);
		@class = new Class5083(24);
		@class.method_1(inheriteD: false);
		@class.method_3("force", method_1(53, "FORCE"));
		smethod_0("border-before-precedence", @class);
		@class = new Class5042.Class5075(31);
		@class.method_1(inheriteD: true);
		@class.method_6("collapse");
		@class.method_3("separate", method_1(129, "SEPARATE"));
		@class.method_3("collapse-with-precedence", method_1(27, "COLLAPSE_WITH_PRECEDENCE"));
		@class.method_3("collapse", method_1(26, "COLLAPSE"));
		smethod_0("border-collapse", @class);
		@class = new Class5083(34);
		@class.method_1(inheriteD: false);
		@class.method_3("force", method_1(53, "FORCE"));
		smethod_0("border-end-precedence", @class);
		@class = new Class5044.Class5063(45);
		@class.method_1(inheriteD: true);
		@class.method_4(class5052_0[46]);
		Class5052 class2 = new Class5034.Class5068(512);
		class2.method_6("0pt");
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		class2 = new Class5034.Class5068(1536);
		class2.method_6("0pt");
		class2.method_9(setByShorthand: true);
		@class.vmethod_1(class2);
		smethod_0("border-separation", @class);
		@class = new Class5083(48);
		@class.method_1(inheriteD: false);
		@class.method_3("force", method_1(53, "FORCE"));
		smethod_0("border-start-precedence", @class);
		@class = new Class5042.Class5075(60);
		@class.method_1(inheriteD: true);
		@class.method_3("before", method_1(13, "BEFORE"));
		@class.method_3("after", method_1(3, "AFTER"));
		@class.method_3("start", method_1(135, "START"));
		@class.method_3("end", method_1(39, "END"));
		@class.method_3("top", method_1(145, "TOP"));
		@class.method_3("bottom", method_1(20, "BOTTOM"));
		@class.method_3("left", method_1(73, "LEFT"));
		@class.method_3("right", method_1(120, "RIGHT"));
		@class.method_6("before");
		smethod_0("caption-side", @class);
		@class = new Class5149.Class5059(76);
		@class.method_1(inheriteD: false);
		smethod_0("column-number", @class);
		@class = new Class5034.Class5068(77);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_6("auto");
		@class.method_8(5);
		smethod_0("column-width", @class);
		@class = new Class5042.Class5075(90);
		@class.method_1(inheriteD: true);
		@class.method_3("show", method_1(130, "SHOW"));
		@class.method_3("hide", method_1(58, "HIDE"));
		@class.method_6("show");
		smethod_0("empty-cells", @class);
		@class = new Class5042.Class5075(92);
		@class.method_1(inheriteD: false);
		@class.vmethod_0(class5052_2);
		@class.method_6("false");
		smethod_0("ends-row", @class);
		@class = new Class5048.Class5084(164);
		@class.method_1(inheriteD: false);
		@class.method_6("1");
		smethod_0("number-columns-repeated", @class);
		@class = new Class5048.Class5084(165);
		@class.method_1(inheriteD: false);
		@class.method_6("1");
		smethod_0("number-columns-spanned", @class);
		@class = new Class5048.Class5084(166);
		@class.method_1(inheriteD: false);
		@class.method_6("1");
		smethod_0("number-rows-spanned", @class);
		@class = new Class5042.Class5075(235);
		@class.vmethod_0(class5052_2);
		@class.method_1(inheriteD: false);
		@class.method_6("false");
		smethod_0("starts-row", @class);
		@class = new Class5042.Class5075(239);
		@class.method_1(inheriteD: false);
		@class.method_6("auto");
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("fixed", method_1(51, "FIXED"));
		smethod_0("table-layout", @class);
		@class = new Class5042.Class5075(240);
		@class.vmethod_0(class5052_2);
		@class.method_1(inheriteD: false);
		@class.method_6("false");
		smethod_0("table-omit-footer-at-break", @class);
		@class = new Class5042.Class5075(241);
		@class.vmethod_0(class5052_2);
		@class.method_1(inheriteD: false);
		@class.method_6("false");
		smethod_0("table-omit-header-at-break", @class);
	}

	private void method_26()
	{
		Class5052 @class = new Class5042.Class5075(86);
		@class.method_1(inheriteD: true);
		@class.method_3("ltr", method_1(80, "LTR"));
		@class.method_3("rtl", method_1(122, "RTL"));
		@class.method_6("ltr");
		smethod_0("direction", @class);
		@class = new Class5051.Class5086(111);
		@class.method_1(inheriteD: true);
		@class.method_6("0deg");
		smethod_0("glyph-orientation-horizontal", @class);
		@class = new Class5051.Class5086(112);
		@class.method_1(inheriteD: true);
		@class.method_6("auto");
		smethod_0("glyph-orientation-vertical", @class);
		@class = new Class5034.Class5068(247);
		@class.method_1(inheriteD: false);
		@class.method_3("use-font-metrics", method_1(156, "USE_FONT_METRICS"));
		@class.method_6("use-font-metrics");
		@class.method_8(1);
		smethod_0("text-altitude", @class);
		@class = new Class5034.Class5068(249);
		@class.method_1(inheriteD: false);
		@class.method_3("use-font-metrics", method_1(156, "USE_FONT_METRICS"));
		@class.method_6("use-font-metrics");
		@class.method_8(1);
		smethod_0("text-depth", @class);
		@class = new Class5042.Class5075(255);
		@class.method_1(inheriteD: false);
		@class.method_3("normal", method_1(97, "NORMAL"));
		@class.method_3("embed", method_1(38, "EMBED"));
		@class.method_3("bidi-override", method_1(15, "BIDI_OVERRIDE"));
		@class.method_6("normal");
		smethod_0("unicode-bidi", @class);
		@class = new Class5042.Class5075(267);
		@class.method_1(inheriteD: true);
		@class.method_6("lr-tb");
		@class.method_3("lr-tb", method_1(79, "LR_TB"));
		@class.method_3("rl-tb", method_1(121, "RL_TB"));
		@class.method_3("tb-rl", method_1(140, "TB_RL"));
		@class.method_3("tb-lr", method_1(205, "TB_LR"));
		@class.method_2("lr", "lr-tb");
		@class.method_2("rl", "rl-tb");
		@class.method_2("tb", "tb-rl");
		smethod_0("writing-mode", @class);
	}

	private void method_27()
	{
		Class5052 @class = new Class5050.Class5085(79);
		@class.method_1(inheriteD: false);
		@class.method_6("auto");
		smethod_0("content-type", @class);
		@class = new Class5050.Class5085(122);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("id", @class);
		@class = new Class5050.Class5085(274);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("fox:alt-text", @class);
		@class = new Class5034.Class5068(196);
		@class.method_1(inheriteD: true);
		@class.method_6("6pt");
		@class.method_8(5);
		smethod_0("provisional-label-separation", @class);
		@class = new Class5034.Class5068(195);
		@class.method_1(inheriteD: true);
		@class.method_6("24pt");
		@class.method_8(5);
		smethod_0("provisional-distance-between-starts", @class);
		@class = new Class5050.Class5085(198);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("ref-id", @class);
		@class = new Class5042.Class5075(217);
		@class.vmethod_0(class5052_2);
		@class.method_1(inheriteD: true);
		@class.method_6("true");
		smethod_0("score-spaces", @class);
		@class = new Class5031.Class5058(232);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("src", @class);
		@class = new Class5042.Class5075(257);
		@class.method_1(inheriteD: false);
		@class.method_3("visible", method_1(159, "VISIBLE"));
		@class.method_3("hidden", method_1(57, "HIDDEN"));
		@class.method_3("collapse", method_1(26, "COLLAPSE"));
		@class.method_6("visible");
		smethod_0("visibility", @class);
		@class = new Class5048.Class5081(269);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_6("auto");
		smethod_0("z-index", @class);
		@class = new Class5042.Class5075(281);
		@class.method_1(inheriteD: false);
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_3("editbox", method_1(207, "EDITBOX"));
		@class.method_3("checkbox", method_1(208, "CHECKBOX"));
		@class.method_3("radiobutton", method_1(209, "RADIOBUTTON"));
		@class.method_3("combobox", method_1(210, "COMBOBOX"));
		@class.method_3("listbox", method_1(211, "LISTBOX"));
		@class.method_3("button", method_1(212, "BUTTON"));
		@class.method_3("content", method_1(214, "CONTENT"));
		@class.method_3("end", method_1(39, "END"));
		@class.method_6("none");
		smethod_0("control-type", @class);
		@class = new Class5034.Class5068(283);
		@class.method_1(inheriteD: false);
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_6("none");
		@class.method_8(5);
		smethod_0("control-width", @class);
		@class = new Class5034.Class5068(284);
		@class.method_1(inheriteD: false);
		@class.method_3("none", method_1(95, "NONE"));
		@class.method_6("none");
		@class.method_8(6);
		smethod_0("control-height", @class);
		@class = new Class5042.Class5075(286);
		@class.vmethod_0(class5052_2);
		@class.method_1(inheriteD: false);
		@class.method_6("false");
		smethod_0("control-value", @class);
		@class = new Class5042.Class5075(287);
		@class.vmethod_0(class5052_2);
		@class.method_1(inheriteD: false);
		@class.method_6("false");
		smethod_0("control-selected", @class);
	}

	private void method_28()
	{
		Class5052 @class = new Class5051.Class5086(7);
		@class.method_1(inheriteD: false);
		@class.method_6("none");
		smethod_0("background", @class);
		@class = new Class5029.Class5055(11);
		@class.method_1(inheriteD: false);
		@class.method_2("left", "0pt 50%");
		@class.method_2("left center", "0pt 50%");
		@class.method_2("center left", "0pt 50%");
		@class.method_2("right", "100% 50%");
		@class.method_2("right center", "100% 50%");
		@class.method_2("center right", "100% 50%");
		@class.method_2("center", "50% 50%");
		@class.method_2("center center", "50% 50%");
		@class.method_2("top", "50% 0pt");
		@class.method_2("top center", "50% 0pt");
		@class.method_2("center top", "50% 0pt");
		@class.method_2("bottom", "50% 100%");
		@class.method_2("bottom center", "50% 100%");
		@class.method_2("center bottom", "50% 100%");
		@class.method_2("top left", "0pt 0pt");
		@class.method_2("left top", "0pt 0pt");
		@class.method_2("top right", "100% 0pt");
		@class.method_2("right top", "100% 0pt");
		@class.method_2("bottom left", "0pt 100%");
		@class.method_2("left bottom", "0pt 100%");
		@class.method_2("bottom right", "100% 100%");
		@class.method_2("right bottom", "100% 100%");
		@class.method_6("0pt 0pt");
		@class.method_8(0);
		@class.method_5(new Class5029.Class5381());
		smethod_0("background-position", @class);
		@class = new Class5027.Class5054(18);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_5(new Class5376());
		smethod_0("border", @class);
		@class = new Class5027.Class5054(27);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_5(new Class5376());
		smethod_0("border-bottom", @class);
		@class = new Class5027.Class5054(32);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_5(new Class5378());
		smethod_0("border-color", @class);
		@class = new Class5027.Class5054(37);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_5(new Class5376());
		smethod_0("border-left", @class);
		@class = new Class5027.Class5054(41);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_5(new Class5376());
		smethod_0("border-right", @class);
		@class = new Class5027.Class5054(51);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_5(new Class5378());
		smethod_0("border-style", @class);
		@class = new Class5027.Class5054(46);
		@class.method_1(inheriteD: true);
		@class.method_6("0pt");
		@class.method_5(new Class5377());
		smethod_0("border-spacing", @class);
		@class = new Class5027.Class5054(52);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_5(new Class5376());
		smethod_0("border-top", @class);
		@class = new Class5027.Class5054(56);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_5(new Class5378());
		smethod_0("border-width", @class);
		@class = new Class5051.Class5086(82);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("cue", @class);
		@class = new Class5028.Class5057(100);
		@class.method_1(inheriteD: true);
		@class.method_3("caption", method_1(180, "CAPTION"));
		@class.method_3("icon", method_1(181, "ICON"));
		@class.method_3("message-box", method_1(183, "MESSAGE_BOX"));
		@class.method_3("menu", method_1(182, "MENU"));
		@class.method_3("small-caption", method_1(184, "SMALL_CAPTION"));
		@class.method_3("status-bar", method_1(185, "STATUS_BAR"));
		@class.method_6(string.Empty);
		@class.method_5(new Class5379());
		smethod_0("font", @class);
		@class = new Class5027.Class5054(147);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_5(new Class5378());
		@class.method_8(5);
		smethod_0("margin", @class);
		@class = new Class5027.Class5054(170);
		@class.method_1(inheriteD: false);
		@class.method_5(new Class5378());
		@class.method_8(5);
		smethod_0("padding", @class);
		@class = new Class5042.Class5075(179);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("always", method_1(7, "ALWAYS"));
		@class.method_3("avoid", method_1(178, "AVOID"));
		@class.method_3("left", method_1(73, "LEFT"));
		@class.method_3("right", method_1(120, "RIGHT"));
		@class.method_6("auto");
		@class.method_5(new Class5389());
		smethod_0("page-break-after", @class);
		@class = new Class5042.Class5075(180);
		@class.method_1(inheriteD: false);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("always", method_1(7, "ALWAYS"));
		@class.method_3("avoid", method_1(178, "AVOID"));
		@class.method_3("left", method_1(73, "LEFT"));
		@class.method_3("right", method_1(120, "RIGHT"));
		@class.method_6("auto");
		@class.method_5(new Class5389());
		smethod_0("page-break-before", @class);
		@class = new Class5042.Class5075(181);
		@class.method_1(inheriteD: true);
		@class.method_3("auto", method_1(9, "AUTO"));
		@class.method_3("avoid", method_1(178, "AVOID"));
		@class.method_6("auto");
		@class.method_5(new Class5389());
		smethod_0("page-break-inside", @class);
		@class = new Class5051.Class5086(187);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		smethod_0("pause", @class);
		@class = new Class5042.Class5075(193);
		@class.method_1(inheriteD: false);
		@class.method_3("static", method_1(136, "STATIC"));
		@class.method_3("relative", method_1(110, "RELATIVE"));
		@class.method_3("absolute", method_1(1, "ABSOLUTE"));
		@class.method_3("absoluterelative", method_1(206, "ABSOLUTERELATIVE"));
		@class.method_3("inlineabsolute", method_1(215, "INLINEABSOLUTE"));
		@class.method_3("fixed", method_1(51, "FIXED"));
		@class.method_6("static");
		@class.method_5(new Class5390());
		smethod_0("position", @class);
		@class = new Class5051.Class5086(220);
		@class.method_1(inheriteD: false);
		@class.method_6("auto");
		smethod_0("size", @class);
		@class = new Class5034.Class5068(256);
		@class.method_1(inheriteD: false);
		@class.method_3("baseline", method_1(12, "BASELINE"));
		@class.method_3("middle", method_1(84, "MIDDLE"));
		@class.method_3("sub", method_1(137, "SUB"));
		@class.method_3("super", method_1(138, "SUPER"));
		@class.method_3("text-top", method_1(144, "TEXT_TOP"));
		@class.method_3("text-bottom", method_1(143, "TEXT_BOTTOM"));
		@class.method_3("top", method_1(145, "TOP"));
		@class.method_3("bottom", method_1(20, "BOTTOM"));
		@class.method_5(new Class5391());
		@class.method_6("baseline");
		@class.method_8(12);
		smethod_0("vertical-align", @class);
		@class = new Class5042.Class5075(260);
		@class.method_1(inheriteD: true);
		@class.method_3("normal", method_1(97, "NORMAL"));
		@class.method_3("pre", method_1(179, "PRE"));
		@class.method_3("nowrap", method_1(93, "NO_WRAP"));
		@class.method_6("normal");
		@class.method_5(new Class5392());
		smethod_0("white-space", @class);
		@class = new Class5050.Class5085(268);
		@class.method_1(inheriteD: true);
		@class.method_6(string.Empty);
		@class.method_5(new Class5380());
		smethod_0("xml:lang", @class);
		@class = new Class5031.Class5058(275);
		@class.method_1(inheriteD: true);
		@class.method_6(string.Empty);
		smethod_0("xml:base", @class);
		@class = new Class5027.Class5054(277);
		@class.method_1(inheriteD: false);
		@class.method_6(string.Empty);
		@class.method_5(new Class5376());
		smethod_0("outline", @class);
	}
}
