using System;
using System.Xml;

namespace ns56;

internal class Class2055 : Class2053
{
	public delegate void Delegate1901(Class2055 elementData);

	private Class1774 class1774_0;

	private Class2111 class2111_0;

	private Class2339 class2339_0;

	private Class2048 class2048_0;

	private Class2059 class2059_0;

	private Class2059 class2059_1;

	private Class2128 class2128_0;

	private Class2097 class2097_0;

	private Class2126 class2126_0;

	private Class2126 class2126_1;

	private Class2125 class2125_0;

	private Class1921 class1921_0;

	private Class1946 class1946_0;

	private Class1774 class1774_1;

	private Class2605 class2605_0;

	private Class2339 class2339_1;

	private Class2084 class2084_0;

	private Class2127 class2127_0;

	private Class2047 class2047_0;

	private Class2127 class2127_1;

	private Class2047 class2047_1;

	private Class2127 class2127_2;

	private Class1887 class1887_0;

	public override Class1774 AxId => class1774_0;

	public override Class2111 Scaling => class2111_0;

	public override Class2339 Delete => class2339_0;

	public override Class2048 AxPos => class2048_0;

	public override Class2059 MajorGridlines => class2059_0;

	public override Class2059 MinorGridlines => class2059_1;

	public override Class2128 Title => class2128_0;

	public override Class2097 NumFmt => class2097_0;

	public override Class2126 MajorTickMark => class2126_0;

	public override Class2126 MinorTickMark => class2126_1;

	public override Class2125 TickLblPos => class2125_0;

	public override Class1921 SpPr => class1921_0;

	public override Class1946 TxPr => class1946_0;

	public override Class1774 CrossAx => class1774_1;

	public override Class2605 Crossing
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

	public override Class2339 Auto => class2339_1;

	public override Class2084 LblOffset => class2084_0;

	public override Class2127 BaseTimeUnit => class2127_0;

	public override Class2047 MajorUnit => class2047_0;

	public override Class2127 MajorTimeUnit => class2127_1;

	public override Class2047 MinorUnit => class2047_1;

	public override Class2127 MinorTimeUnit => class2127_2;

	public override Class1885 ExtLst => class1887_0;

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
				case "axId":
					class1774_0 = new Class1774(reader);
					break;
				case "scaling":
					class2111_0 = new Class2111(reader);
					break;
				case "delete":
					class2339_0 = new Class2339(reader);
					break;
				case "axPos":
					class2048_0 = new Class2048(reader);
					break;
				case "majorGridlines":
					class2059_0 = new Class2059(reader);
					break;
				case "minorGridlines":
					class2059_1 = new Class2059(reader);
					break;
				case "title":
					class2128_0 = new Class2128(reader);
					break;
				case "numFmt":
					class2097_0 = new Class2097(reader);
					break;
				case "majorTickMark":
					class2126_0 = new Class2126(reader);
					break;
				case "minorTickMark":
					class2126_1 = new Class2126(reader);
					break;
				case "tickLblPos":
					class2125_0 = new Class2125(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "txPr":
					class1946_0 = new Class1946(reader);
					break;
				case "crossAx":
					class1774_1 = new Class1774(reader);
					break;
				case "crosses":
					class2605_0 = new Class2605("crosses", new Class2061(reader));
					break;
				case "crossesAt":
					class2605_0 = new Class2605("crossesAt", new Class2070(reader));
					break;
				case "auto":
					class2339_1 = new Class2339(reader);
					break;
				case "lblOffset":
					class2084_0 = new Class2084(reader);
					break;
				case "baseTimeUnit":
					class2127_0 = new Class2127(reader);
					break;
				case "majorUnit":
					class2047_0 = new Class2047(reader);
					break;
				case "majorTimeUnit":
					class2127_1 = new Class2127(reader);
					break;
				case "minorUnit":
					class2047_1 = new Class2047(reader);
					break;
				case "minorTimeUnit":
					class2127_2 = new Class2127(reader);
					break;
				case "extLst":
					class1887_0 = new Class1887(reader);
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
	}

	public Class2055(XmlReader reader)
		: base(reader)
	{
	}

	public Class2055()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2763_0 = method_3;
		delegate2764_0 = method_4;
		delegate1889_0 = method_5;
		delegate1891_0 = method_6;
		delegate1889_1 = method_7;
		delegate1891_1 = method_8;
		delegate2115_0 = method_9;
		delegate2117_0 = method_10;
		delegate2009_0 = method_11;
		delegate2011_0 = method_12;
		delegate2109_0 = method_13;
		delegate2111_0 = method_14;
		delegate2109_1 = method_15;
		delegate2111_1 = method_16;
		delegate2106_0 = method_17;
		delegate2108_0 = method_18;
		delegate1630_0 = method_19;
		delegate1632_0 = method_20;
		delegate1705_0 = method_21;
		delegate1707_0 = method_22;
		delegate2773_0 = method_39;
		delegate2763_1 = method_23;
		delegate2764_1 = method_24;
		delegate1967_0 = method_25;
		delegate1969_0 = method_26;
		delegate2112_0 = method_27;
		delegate2114_0 = method_28;
		delegate1859_0 = method_29;
		delegate1861_0 = method_30;
		delegate2112_1 = method_31;
		delegate2114_1 = method_32;
		delegate1859_1 = method_33;
		delegate1861_1 = method_34;
		delegate2112_2 = method_35;
		delegate2114_2 = method_36;
		delegate1534_0 = method_37;
		delegate1535_0 = method_38;
	}

	protected override void vmethod_3()
	{
		class1774_0 = new Class1774();
		class2111_0 = new Class2111();
		class2048_0 = new Class2048();
		class1774_1 = new Class1774();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1774_0.vmethod_4("c", writer, "axId");
		class2111_0.vmethod_4("c", writer, "scaling");
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "delete");
		}
		class2048_0.vmethod_4("c", writer, "axPos");
		if (class2059_0 != null)
		{
			class2059_0.vmethod_4("c", writer, "majorGridlines");
		}
		if (class2059_1 != null)
		{
			class2059_1.vmethod_4("c", writer, "minorGridlines");
		}
		if (class2128_0 != null)
		{
			class2128_0.vmethod_4("c", writer, "title");
		}
		if (class2097_0 != null)
		{
			class2097_0.vmethod_4("c", writer, "numFmt");
		}
		if (class2126_0 != null)
		{
			class2126_0.vmethod_4("c", writer, "majorTickMark");
		}
		if (class2126_1 != null)
		{
			class2126_1.vmethod_4("c", writer, "minorTickMark");
		}
		if (class2125_0 != null)
		{
			class2125_0.vmethod_4("c", writer, "tickLblPos");
		}
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("c", writer, "spPr");
		}
		if (class1946_0 != null)
		{
			class1946_0.vmethod_4("c", writer, "txPr");
		}
		class1774_1.vmethod_4("c", writer, "crossAx");
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "crossesAt":
				((Class2070)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			case "crosses":
				((Class2061)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			}
		}
		if (class2339_1 != null)
		{
			class2339_1.vmethod_4("c", writer, "auto");
		}
		if (class2084_0 != null)
		{
			class2084_0.vmethod_4("c", writer, "lblOffset");
		}
		if (class2127_0 != null)
		{
			class2127_0.vmethod_4("c", writer, "baseTimeUnit");
		}
		if (class2047_0 != null)
		{
			class2047_0.vmethod_4("c", writer, "majorUnit");
		}
		if (class2127_1 != null)
		{
			class2127_1.vmethod_4("c", writer, "majorTimeUnit");
		}
		if (class2047_1 != null)
		{
			class2047_1.vmethod_4("c", writer, "minorUnit");
		}
		if (class2127_2 != null)
		{
			class2127_2.vmethod_4("c", writer, "minorTimeUnit");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2339 method_3()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <delete> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_4(Class2339 _delete)
	{
		class2339_0 = _delete;
	}

	private Class2059 method_5()
	{
		if (class2059_0 != null)
		{
			throw new Exception("Only one <majorGridlines> element can be added.");
		}
		class2059_0 = new Class2059();
		return class2059_0;
	}

	private void method_6(Class2059 _majorGridlines)
	{
		class2059_0 = _majorGridlines;
	}

	private Class2059 method_7()
	{
		if (class2059_1 != null)
		{
			throw new Exception("Only one <minorGridlines> element can be added.");
		}
		class2059_1 = new Class2059();
		return class2059_1;
	}

	private void method_8(Class2059 _minorGridlines)
	{
		class2059_1 = _minorGridlines;
	}

	private Class2128 method_9()
	{
		if (class2128_0 != null)
		{
			throw new Exception("Only one <title> element can be added.");
		}
		class2128_0 = new Class2128();
		return class2128_0;
	}

	private void method_10(Class2128 _title)
	{
		class2128_0 = _title;
	}

	private Class2097 method_11()
	{
		if (class2097_0 != null)
		{
			throw new Exception("Only one <numFmt> element can be added.");
		}
		class2097_0 = new Class2097();
		return class2097_0;
	}

	private void method_12(Class2097 _numFmt)
	{
		class2097_0 = _numFmt;
	}

	private Class2126 method_13()
	{
		if (class2126_0 != null)
		{
			throw new Exception("Only one <majorTickMark> element can be added.");
		}
		class2126_0 = new Class2126();
		return class2126_0;
	}

	private void method_14(Class2126 _majorTickMark)
	{
		class2126_0 = _majorTickMark;
	}

	private Class2126 method_15()
	{
		if (class2126_1 != null)
		{
			throw new Exception("Only one <minorTickMark> element can be added.");
		}
		class2126_1 = new Class2126();
		return class2126_1;
	}

	private void method_16(Class2126 _minorTickMark)
	{
		class2126_1 = _minorTickMark;
	}

	private Class2125 method_17()
	{
		if (class2125_0 != null)
		{
			throw new Exception("Only one <tickLblPos> element can be added.");
		}
		class2125_0 = new Class2125();
		return class2125_0;
	}

	private void method_18(Class2125 _tickLblPos)
	{
		class2125_0 = _tickLblPos;
	}

	private Class1921 method_19()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_20(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class1946 method_21()
	{
		if (class1946_0 != null)
		{
			throw new Exception("Only one <txPr> element can be added.");
		}
		class1946_0 = new Class1946();
		return class1946_0;
	}

	private void method_22(Class1946 _txPr)
	{
		class1946_0 = _txPr;
	}

	private Class2339 method_23()
	{
		if (class2339_1 != null)
		{
			throw new Exception("Only one <auto> element can be added.");
		}
		class2339_1 = new Class2339();
		return class2339_1;
	}

	private void method_24(Class2339 _auto)
	{
		class2339_1 = _auto;
	}

	private Class2084 method_25()
	{
		if (class2084_0 != null)
		{
			throw new Exception("Only one <lblOffset> element can be added.");
		}
		class2084_0 = new Class2084();
		return class2084_0;
	}

	private void method_26(Class2084 _lblOffset)
	{
		class2084_0 = _lblOffset;
	}

	private Class2127 method_27()
	{
		if (class2127_0 != null)
		{
			throw new Exception("Only one <baseTimeUnit> element can be added.");
		}
		class2127_0 = new Class2127();
		return class2127_0;
	}

	private void method_28(Class2127 _baseTimeUnit)
	{
		class2127_0 = _baseTimeUnit;
	}

	private Class2047 method_29()
	{
		if (class2047_0 != null)
		{
			throw new Exception("Only one <majorUnit> element can be added.");
		}
		class2047_0 = new Class2047();
		return class2047_0;
	}

	private void method_30(Class2047 _majorUnit)
	{
		class2047_0 = _majorUnit;
	}

	private Class2127 method_31()
	{
		if (class2127_1 != null)
		{
			throw new Exception("Only one <majorTimeUnit> element can be added.");
		}
		class2127_1 = new Class2127();
		return class2127_1;
	}

	private void method_32(Class2127 _majorTimeUnit)
	{
		class2127_1 = _majorTimeUnit;
	}

	private Class2047 method_33()
	{
		if (class2047_1 != null)
		{
			throw new Exception("Only one <minorUnit> element can be added.");
		}
		class2047_1 = new Class2047();
		return class2047_1;
	}

	private void method_34(Class2047 _minorUnit)
	{
		class2047_1 = _minorUnit;
	}

	private Class2127 method_35()
	{
		if (class2127_2 != null)
		{
			throw new Exception("Only one <minorTimeUnit> element can be added.");
		}
		class2127_2 = new Class2127();
		return class2127_2;
	}

	private void method_36(Class2127 _minorTimeUnit)
	{
		class2127_2 = _minorTimeUnit;
	}

	private Class1885 method_37()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_38(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}

	private Class2605 method_39(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Crossing already is initialized.");
		}
		switch (elementName)
		{
		case "crossesAt":
			class2605_0 = new Class2605("crossesAt", new Class2070());
			break;
		case "crosses":
			class2605_0 = new Class2605("crosses", new Class2061());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
