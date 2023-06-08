using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1963 : Class1351
{
	public delegate Class1963 Delegate1756();

	public delegate void Delegate1758(Class1963 elementData);

	public delegate void Delegate1757(Class1963 elementData);

	public const double double_0 = double.NaN;

	public const double double_1 = double.NaN;

	public const int int_0 = -1;

	public const double double_2 = double.NaN;

	public const Enum313 enum313_0 = Enum313.const_0;

	public const double double_3 = double.NaN;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const FontAlignment fontAlignment_0 = FontAlignment.Default;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const NullableBool nullableBool_3 = NullableBool.NotDefined;

	public Class1965.Delegate1762 delegate1762_0;

	public Class1965.Delegate1764 delegate1764_0;

	public Class1965.Delegate1762 delegate1762_1;

	public Class1965.Delegate1764 delegate1764_1;

	public Class1965.Delegate1762 delegate1762_2;

	public Class1965.Delegate1764 delegate1764_2;

	public Class1969.Delegate1774 delegate1774_0;

	public Class1969.Delegate1776 delegate1776_0;

	public Class1953.Delegate1726 delegate1726_0;

	public Class1953.Delegate1728 delegate1728_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	public Class2605.Delegate2773 delegate2773_1;

	public Class2605.Delegate2773 delegate2773_2;

	public Class2605.Delegate2773 delegate2773_3;

	private double double_4;

	private double double_5;

	private int int_1;

	private double double_6;

	private Enum313 enum313_1;

	private double double_7;

	private NullableBool nullableBool_4;

	private NullableBool nullableBool_5;

	private FontAlignment fontAlignment_1;

	private NullableBool nullableBool_6;

	private NullableBool nullableBool_7;

	private Class1965 class1965_0;

	private Class1965 class1965_1;

	private Class1965 class1965_2;

	private Class2605 class2605_0;

	private Class2605 class2605_1;

	private Class2605 class2605_2;

	private Class2605 class2605_3;

	private Class1969 class1969_0;

	private Class1953 class1953_0;

	private Class1886 class1886_0;

	public double MarL
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public double MarR
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

	public int Lvl
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public double Indent
	{
		get
		{
			return double_6;
		}
		set
		{
			double_6 = value;
		}
	}

	public Enum313 Algn
	{
		get
		{
			return enum313_1;
		}
		set
		{
			enum313_1 = value;
		}
	}

	public double DefTabSz
	{
		get
		{
			return double_7;
		}
		set
		{
			double_7 = value;
		}
	}

	public NullableBool Rtl
	{
		get
		{
			return nullableBool_4;
		}
		set
		{
			nullableBool_4 = value;
		}
	}

	public NullableBool EaLnBrk
	{
		get
		{
			return nullableBool_5;
		}
		set
		{
			nullableBool_5 = value;
		}
	}

	public FontAlignment FontAlgn
	{
		get
		{
			return fontAlignment_1;
		}
		set
		{
			fontAlignment_1 = value;
		}
	}

	public NullableBool LatinLnBrk
	{
		get
		{
			return nullableBool_6;
		}
		set
		{
			nullableBool_6 = value;
		}
	}

	public NullableBool HangingPunct
	{
		get
		{
			return nullableBool_7;
		}
		set
		{
			nullableBool_7 = value;
		}
	}

	public Class1965 LnSpc => class1965_0;

	public Class1965 SpcBef => class1965_1;

	public Class1965 SpcAft => class1965_2;

	public Class2605 TextBulletColor
	{
		get
		{
			return class2605_0;
		}
		set
		{
			class2605_0 = value;
		}
	}

	public Class2605 TextBulletSize
	{
		get
		{
			return class2605_1;
		}
		set
		{
			class2605_1 = value;
		}
	}

	public Class2605 TextBulletTypeface
	{
		get
		{
			return class2605_2;
		}
		set
		{
			class2605_2 = value;
		}
	}

	public Class2605 TextBullet
	{
		get
		{
			return class2605_3;
		}
		set
		{
			class2605_3 = value;
		}
	}

	public Class1969 TabLst => class1969_0;

	public Class1953 DefRPr => class1953_0;

	public Class1885 ExtLst => class1886_0;

	protected override void vmethod_0(XmlReader reader)
	{
		string localName = reader.LocalName;
		method_2(reader);
		if (reader.IsEmptyElement)
		{
			return;
		}
		bool flag = false;
		while (((flag && !reader.EOF) || reader.Read()) && (reader.NodeType != XmlNodeType.EndElement || !(reader.LocalName == localName)))
		{
			flag = false;
			if (reader.NodeType == XmlNodeType.Element)
			{
				switch (reader.LocalName)
				{
				case "lnSpc":
					class1965_0 = new Class1965(reader);
					break;
				case "spcBef":
					class1965_1 = new Class1965(reader);
					break;
				case "spcAft":
					class1965_2 = new Class1965(reader);
					break;
				case "buClrTx":
					class2605_0 = new Class2605("buClrTx", new Class1948(reader));
					break;
				case "buClr":
					class2605_0 = new Class2605("buClr", new Class1814(reader));
					break;
				case "buSzTx":
					class2605_1 = new Class2605("buSzTx", new Class1949(reader));
					break;
				case "buSzPct":
					class2605_1 = new Class2605("buSzPct", new Class1950(reader));
					break;
				case "buSzPts":
					class2605_1 = new Class2605("buSzPts", new Class1951(reader));
					break;
				case "buFontTx":
					class2605_2 = new Class2605("buFontTx", new Class1952(reader));
					break;
				case "buFont":
					class2605_2 = new Class2605("buFont", new Class1956(reader));
					break;
				case "buNone":
					class2605_3 = new Class2605("buNone", new Class1960(reader));
					break;
				case "buAutoNum":
					class2605_3 = new Class2605("buAutoNum", new Class1944(reader));
					break;
				case "buChar":
					class2605_3 = new Class2605("buChar", new Class1954(reader));
					break;
				case "buBlip":
					class2605_3 = new Class2605("buBlip", new Class1945(reader));
					break;
				case "tabLst":
					class1969_0 = new Class1969(reader);
					break;
				case "defRPr":
					class1953_0 = new Class1953(reader);
					break;
				case "extLst":
					class1886_0 = new Class1886(reader);
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
		while (reader.MoveToNextAttribute())
		{
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "marL":
					double_4 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "marR":
					double_5 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "lvl":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "indent":
					double_6 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "algn":
					enum313_1 = Class2441.smethod_0(reader.Value);
					break;
				case "defTabSz":
					double_7 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "rtl":
					nullableBool_4 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "eaLnBrk":
					nullableBool_5 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "fontAlgn":
					fontAlignment_1 = Class2567.smethod_0(reader.Value);
					break;
				case "latinLnBrk":
					nullableBool_6 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "hangingPunct":
					nullableBool_7 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1963(XmlReader reader)
		: base(reader)
	{
	}

	public Class1963()
	{
	}

	protected override void vmethod_1()
	{
		double_4 = double.NaN;
		double_5 = double.NaN;
		int_1 = -1;
		double_6 = double.NaN;
		enum313_1 = Enum313.const_0;
		double_7 = double.NaN;
		nullableBool_4 = NullableBool.NotDefined;
		nullableBool_5 = NullableBool.NotDefined;
		fontAlignment_1 = FontAlignment.Default;
		nullableBool_6 = NullableBool.NotDefined;
		nullableBool_7 = NullableBool.NotDefined;
	}

	protected override void vmethod_2()
	{
		delegate1762_0 = method_3;
		delegate1764_0 = method_4;
		delegate1762_1 = method_5;
		delegate1764_1 = method_6;
		delegate1762_2 = method_7;
		delegate1764_2 = method_8;
		delegate2773_1 = method_16;
		delegate2773_2 = method_17;
		delegate2773_3 = method_18;
		delegate2773_0 = method_15;
		delegate1774_0 = method_9;
		delegate1776_0 = method_10;
		delegate1726_0 = method_11;
		delegate1728_0 = method_12;
		delegate1534_0 = method_13;
		delegate1535_0 = method_14;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!double.IsNaN(double_4))
		{
			writer.WriteAttributeString("marL", XmlConvert.ToString((long)Math.Round(double_4 * 12700.0)));
		}
		if (!double.IsNaN(double_5))
		{
			writer.WriteAttributeString("marR", XmlConvert.ToString((long)Math.Round(double_5 * 12700.0)));
		}
		if (int_1 != -1)
		{
			writer.WriteAttributeString("lvl", XmlConvert.ToString(int_1));
		}
		if (!double.IsNaN(double_6))
		{
			writer.WriteAttributeString("indent", XmlConvert.ToString((long)Math.Round(double_6 * 12700.0)));
		}
		if (enum313_1 != 0)
		{
			writer.WriteAttributeString("algn", Class2441.smethod_1(enum313_1));
		}
		if (!double.IsNaN(double_7))
		{
			writer.WriteAttributeString("defTabSz", XmlConvert.ToString((long)Math.Round(double_7 * 12700.0)));
		}
		if (nullableBool_4 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("rtl", (nullableBool_4 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_5 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("eaLnBrk", (nullableBool_5 == NullableBool.True) ? "1" : "0");
		}
		if (fontAlignment_1 != FontAlignment.Default)
		{
			writer.WriteAttributeString("fontAlgn", Class2567.smethod_1(fontAlignment_1));
		}
		if (nullableBool_6 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("latinLnBrk", (nullableBool_6 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_7 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("hangingPunct", (nullableBool_7 == NullableBool.True) ? "1" : "0");
		}
		if (class1965_0 != null)
		{
			class1965_0.vmethod_4("a", writer, "lnSpc");
		}
		if (class1965_1 != null)
		{
			class1965_1.vmethod_4("a", writer, "spcBef");
		}
		if (class1965_2 != null)
		{
			class1965_2.vmethod_4("a", writer, "spcAft");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "buClr":
				((Class1814)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "buClrTx":
				((Class1948)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		if (class2605_1 != null)
		{
			switch (class2605_1.Name)
			{
			case "buSzPts":
				((Class1951)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "buSzPct":
				((Class1950)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			case "buSzTx":
				((Class1949)class2605_1.Object).vmethod_4("a", writer, class2605_1.Name);
				break;
			}
		}
		if (class2605_2 != null)
		{
			switch (class2605_2.Name)
			{
			case "buFont":
				((Class1956)class2605_2.Object).vmethod_4("a", writer, class2605_2.Name);
				break;
			case "buFontTx":
				((Class1952)class2605_2.Object).vmethod_4("a", writer, class2605_2.Name);
				break;
			}
		}
		if (class2605_3 != null)
		{
			switch (class2605_3.Name)
			{
			case "buBlip":
				((Class1945)class2605_3.Object).vmethod_4("a", writer, class2605_3.Name);
				break;
			case "buChar":
				((Class1954)class2605_3.Object).vmethod_4("a", writer, class2605_3.Name);
				break;
			case "buAutoNum":
				((Class1944)class2605_3.Object).vmethod_4("a", writer, class2605_3.Name);
				break;
			case "buNone":
				((Class1960)class2605_3.Object).vmethod_4("a", writer, class2605_3.Name);
				break;
			}
		}
		if (class1969_0 != null)
		{
			class1969_0.vmethod_4("a", writer, "tabLst");
		}
		if (class1953_0 != null)
		{
			class1953_0.vmethod_4("a", writer, "defRPr");
		}
		if (class1886_0 != null)
		{
			class1886_0.vmethod_4("a", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1965 method_3()
	{
		if (class1965_0 != null)
		{
			throw new Exception("Only one <lnSpc> element can be added.");
		}
		class1965_0 = new Class1965();
		return class1965_0;
	}

	private void method_4(Class1965 _lnSpc)
	{
		class1965_0 = _lnSpc;
	}

	private Class1965 method_5()
	{
		if (class1965_1 != null)
		{
			throw new Exception("Only one <spcBef> element can be added.");
		}
		class1965_1 = new Class1965();
		return class1965_1;
	}

	private void method_6(Class1965 _spcBef)
	{
		class1965_1 = _spcBef;
	}

	private Class1965 method_7()
	{
		if (class1965_2 != null)
		{
			throw new Exception("Only one <spcAft> element can be added.");
		}
		class1965_2 = new Class1965();
		return class1965_2;
	}

	private void method_8(Class1965 _spcAft)
	{
		class1965_2 = _spcAft;
	}

	private Class1969 method_9()
	{
		if (class1969_0 != null)
		{
			throw new Exception("Only one <tabLst> element can be added.");
		}
		class1969_0 = new Class1969();
		return class1969_0;
	}

	private void method_10(Class1969 _tabLst)
	{
		class1969_0 = _tabLst;
	}

	private Class1953 method_11()
	{
		if (class1953_0 != null)
		{
			throw new Exception("Only one <defRPr> element can be added.");
		}
		class1953_0 = new Class1953();
		return class1953_0;
	}

	private void method_12(Class1953 _defRPr)
	{
		class1953_0 = _defRPr;
	}

	private Class1885 method_13()
	{
		if (class1886_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1886_0 = new Class1886();
		return class1886_0;
	}

	private void method_14(Class1885 _extLst)
	{
		class1886_0 = (Class1886)_extLst;
	}

	private Class2605 method_15(string elementName)
	{
		if (class2605_3 != null)
		{
			throw new Exception("TextBullet already is initialized.");
		}
		switch (elementName)
		{
		case "buBlip":
			class2605_3 = new Class2605("buBlip", new Class1945());
			break;
		case "buChar":
			class2605_3 = new Class2605("buChar", new Class1954());
			break;
		case "buAutoNum":
			class2605_3 = new Class2605("buAutoNum", new Class1944());
			break;
		case "buNone":
			class2605_3 = new Class2605("buNone", new Class1960());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_3;
	}

	private Class2605 method_16(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("TextBulletColor already is initialized.");
		}
		switch (elementName)
		{
		case "buClr":
			class2605_0 = new Class2605("buClr", new Class1814());
			break;
		case "buClrTx":
			class2605_0 = new Class2605("buClrTx", new Class1948());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}

	private Class2605 method_17(string elementName)
	{
		if (class2605_1 != null)
		{
			throw new Exception("TextBulletSize already is initialized.");
		}
		switch (elementName)
		{
		case "buSzPts":
			class2605_1 = new Class2605("buSzPts", new Class1951());
			break;
		case "buSzPct":
			class2605_1 = new Class2605("buSzPct", new Class1950());
			break;
		case "buSzTx":
			class2605_1 = new Class2605("buSzTx", new Class1949());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_1;
	}

	private Class2605 method_18(string elementName)
	{
		if (class2605_2 != null)
		{
			throw new Exception("TextBulletTypeface already is initialized.");
		}
		switch (elementName)
		{
		case "buFont":
			class2605_2 = new Class2605("buFont", new Class1956());
			break;
		case "buFontTx":
			class2605_2 = new Class2605("buFontTx", new Class1952());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_2;
	}
}
