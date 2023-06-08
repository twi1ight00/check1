using System;
using ns287;
using ns305;

namespace ns284;

internal class Class7058 : Class7057
{
	protected internal override Class6981 CreateElement(Class7096 name, Class7046 doc)
	{
		if (!name.method_0())
		{
			return new Class6992(name, doc);
		}
		switch (name.LocalName.ToUpper())
		{
		case "A":
			return new Class6996(name, doc);
		case "ADDRESS":
			return new Class6991(name, doc);
		case "APPLET":
			return new Class6997(name, doc);
		case "AREA":
			return new Class6998(name, doc);
		case "BASE":
			return new Class6999(name, doc);
		case "BASEFONT":
			return new Class7000(name, doc);
		case "BODY":
			return new Class7001(name, doc);
		case "BR":
			return new Class7002(name, doc);
		case "BUTTON":
			return new Class7003(name, doc);
		case "DIR":
			return new Class7004(name, doc);
		case "DIV":
			return new Class7005(name, doc);
		case "DL":
			return new Class7006(name, doc);
		case "FIELDSET":
			return new Class7007(name, doc);
		case "FONT":
			return new Class7008(name, doc);
		case "FORM":
			return new Class7009(name, doc);
		case "FRAME":
			return new Class7010(name, doc);
		case "FRAMESET":
			return new Class7011(name, doc);
		case "HEAD":
			return new Class7012(name, doc);
		case "H1":
		case "H2":
		case "H3":
		case "H4":
		case "H5":
		case "H6":
			return new Class7013(name, doc);
		case "HR":
			return new Class7014(name, doc);
		case "HTML":
			return new Class7015(name, doc);
		case "IFRAME":
			return new Class7016(name, doc);
		case "IMG":
			return new Class7017(name, doc);
		case "INPUT":
			return new Class6995(name, doc);
		case "ISINDEX":
			return new Class7018(name, doc);
		case "LABEL":
			return new Class7019(name, doc);
		case "LEGEND":
			return new Class7020(name, doc);
		case "LI":
			return new Class7021(name, doc);
		case "LINK":
			return new Class7022(name, doc);
		case "MAP":
			return new Class7023(name, doc);
		case "MENU":
			return new Class7024(name, doc);
		case "META":
			return new Class7025(name, doc);
		case "INS":
		case "DEL":
			return new Class7026(name, doc);
		case "OBJECT":
			return new Class6994(name, doc);
		case "OL":
			return new Class7027(name, doc);
		case "OPTGROUP":
			return new Class7028(name, doc);
		case "OPTION":
			return new Class7029(name, doc);
		case "P":
			return new Class7030(name, doc);
		case "PARAM":
			return new Class7031(name, doc);
		case "PRE":
			return new Class7032(name, doc);
		case "Q":
			return new Class7033(name, doc);
		case "SCRIPT":
			return new Class7034(name, doc);
		case "NOSCRIPT":
			return new Class6990(name, doc);
		case "SELECT":
			return new Class7035(name, doc);
		case "STYLE":
			return new Class7036(name, doc);
		case "CAPTION":
			return new Class7037(name, doc);
		case "TH":
		case "TD":
			return new Class7038(name, doc);
		case "COL":
			return new Class7039(name, doc);
		case "TABLE":
			return new Class6993(name, doc);
		case "TR":
			return new Class7040(name, doc);
		case "TBODY":
		case "THEAD":
		case "TFOOT":
			return new Class7041(name, doc);
		case "TEXTAREA":
			return new Class7042(name, doc);
		case "UL":
			return new Class7043(name, doc);
		case "TIME":
			return new Class6989(name, doc);
		case "AUDIO":
			return new Class6984(name, doc);
		case "VIDEO":
			return new Class6985(name, doc);
		case "SVG":
			return new Class6986(name, doc);
		case "EMBED":
			return new Class6987(name, doc);
		case "EM":
		case "STRONG":
		case "DFN":
		case "CODE":
		case "SAMP":
		case "KBD":
		case "VAR":
		case "CITE":
		case "ABBR":
		case "ACRONYM":
		case "WBR":
		case "DD":
		case "DT":
		case "TITLE":
		case "NOFRAMESET":
		case "SPAN":
		case "B":
		case "I":
		case "U":
		case "BLOCKQUOTE":
			return new Class6983(name, doc);
		default:
			return new Class6992(name, doc);
		}
	}

	protected internal override Class7046 vmethod_0(Class7097 implementation)
	{
		return new Class7047(implementation);
	}

	protected internal override bool vmethod_1(Class7096 name)
	{
		return name.LocalName.Equals("id", StringComparison.OrdinalIgnoreCase);
	}
}
