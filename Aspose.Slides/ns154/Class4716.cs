using System;
using System.Collections;

namespace ns154;

internal class Class4716 : Hashtable
{
	public string this[int index]
	{
		get
		{
			return (string)base[index];
		}
		set
		{
			base[index] = value;
		}
	}

	public void Add(int index, string glyphName)
	{
		base[index] = glyphName;
	}

	public void method_0()
	{
		method_1("101", "A");
		method_1("341", "AE");
		method_1("102", "B");
		method_1("103", "C");
		method_1("104", "D");
		method_1("105", "E");
		method_1("106", "F");
		method_1("107", "G");
		method_1("110", "H");
		method_1("111", "I");
		method_1("112", "J");
		method_1("113", "K");
		method_1("114", "L");
		method_1("350", "Lslash");
		method_1("115", "M");
		method_1("116", "N");
		method_1("117", "O");
		method_1("352", "OE");
		method_1("351", "Oslash");
		method_1("120", "P");
		method_1("121", "Q");
		method_1("122", "R");
		method_1("123", "S");
		method_1("124", "T");
		method_1("125", "U");
		method_1("126", "V");
		method_1("127", "W");
		method_1("130", "X");
		method_1("131", "Y");
		method_1("132", "Z");
		method_1("141", "a");
		method_1("302", "acute");
		method_1("361", "ae");
		method_1("046", "ampersand");
		method_1("136", "asciicircum");
		method_1("176", "asciitilde");
		method_1("052", "asterisk");
		method_1("100", "at");
		method_1("142", "b");
		method_1("134", "backslash");
		method_1("174", "bar");
		method_1("173", "braceleft");
		method_1("175", "braceright");
		method_1("133", "bracketleft");
		method_1("135", "bracketright");
		method_1("306", "breve");
		method_1("267", "bullet");
		method_1("143", "c");
		method_1("317", "caron");
		method_1("313", "cedilla");
		method_1("242", "cent");
		method_1("303", "circumflex");
		method_1("072", "colon");
		method_1("054", "comma");
		method_1("250", "currency");
		method_1("144", "d");
		method_1("262", "dagger");
		method_1("263", "daggerdbl");
		method_1("310", "dieresis");
		method_1("044", "dollar");
		method_1("307", "dotaccent");
		method_1("365", "dotlessi");
		method_1("145", "e");
		method_1("070", "eight");
		method_1("274", "ellipsis");
		method_1("320", "emdash");
		method_1("261", "endash");
		method_1("075", "equal");
		method_1("041", "exclam");
		method_1("241", "exclamdown");
		method_1("146", "f");
		method_1("256", "fi");
		method_1("065", "five");
		method_1("257", "fl");
		method_1("246", "florin");
		method_1("064", "four");
		method_1("244", "fraction");
		method_1("147", "g");
		method_1("373", "germandbls");
		method_1("301", "grave");
		method_1("076", "greater");
		method_1("253", "guillemotleft");
		method_1("273", "guillemotright");
		method_1("254", "guilsinglleft");
		method_1("255", "guilsinglright");
		method_1("150", "h");
		method_1("315", "hungarumlaut");
		method_1("055", "hyphen");
		method_1("151", "i");
		method_1("152", "j");
		method_1("153", "k");
		method_1("154", "l");
		method_1("074", "less");
		method_1("370", "lslash");
		method_1("155", "m");
		method_1("305", "macron");
		method_1("156", "n");
		method_1("071", "nine");
		method_1("043", "numbersign");
		method_1("157", "o");
		method_1("372", "oe");
		method_1("316", "ogonek");
		method_1("061", "one");
		method_1("343", "ordfeminine");
		method_1("353", "ordmasculine");
		method_1("371", "oslash");
		method_1("160", "p");
		method_1("266", "paragraph");
		method_1("050", "parenleft");
		method_1("051", "parenright");
		method_1("045", "percent");
		method_1("056", "period");
		method_1("264", "periodcentered");
		method_1("275", "perthousand");
		method_1("053", "plus");
		method_1("161", "q");
		method_1("077", "question");
		method_1("277", "questiondown");
		method_1("042", "quotedbl");
		method_1("271", "quotedblbase");
		method_1("252", "quotedblleft");
		method_1("272", "quotedblright");
		method_1("140", "quoteleft");
		method_1("047", "quoteright");
		method_1("270", "quotesinglbase");
		method_1("251", "quotesingle");
		method_1("162", "r");
		method_1("312", "ring");
		method_1("163", "s");
		method_1("247", "section");
		method_1("073", "semicolon");
		method_1("067", "seven");
		method_1("066", "six");
		method_1("057", "slash");
		method_1("040", "space");
		method_1("243", "sterling");
		method_1("164", "t");
		method_1("063", "three");
		method_1("304", "tilde");
		method_1("062", "two");
		method_1("165", "u");
		method_1("137", "underscore");
		method_1("166", "v");
		method_1("167", "w");
		method_1("170", "x");
		method_1("171", "y");
		method_1("245", "yen");
		method_1("172", "z");
		method_1("060", "zero");
	}

	protected void method_1(string octalCode, string name)
	{
		int index = Convert.ToInt32(octalCode, 8);
		this[index] = name;
	}
}
