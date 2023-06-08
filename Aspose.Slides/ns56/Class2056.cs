using System;
using System.Xml;

namespace ns56;

internal class Class2056 : Class2053
{
	public delegate void Delegate2068(Class2056 elementData);

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

	private Class2117 class2117_0;

	private Class2117 class2117_1;

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

	public override Class2117 TickLblSkip => class2117_0;

	public override Class2117 TickMarkSkip => class2117_1;

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
				case "tickLblSkip":
					class2117_0 = new Class2117(reader);
					break;
				case "tickMarkSkip":
					class2117_1 = new Class2117(reader);
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

	public Class2056(XmlReader reader)
		: base(reader)
	{
	}

	public Class2056()
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
		delegate2773_0 = method_29;
		delegate2078_0 = method_23;
		delegate2080_0 = method_24;
		delegate2078_1 = method_25;
		delegate2080_1 = method_26;
		delegate1534_0 = method_27;
		delegate1535_0 = method_28;
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
		if (class2117_0 != null)
		{
			class2117_0.vmethod_4("c", writer, "tickLblSkip");
		}
		if (class2117_1 != null)
		{
			class2117_1.vmethod_4("c", writer, "tickMarkSkip");
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

	private Class2117 method_23()
	{
		if (class2117_0 != null)
		{
			throw new Exception("Only one <tickLblSkip> element can be added.");
		}
		class2117_0 = new Class2117();
		return class2117_0;
	}

	private void method_24(Class2117 _tickLblSkip)
	{
		class2117_0 = _tickLblSkip;
	}

	private Class2117 method_25()
	{
		if (class2117_1 != null)
		{
			throw new Exception("Only one <tickMarkSkip> element can be added.");
		}
		class2117_1 = new Class2117();
		return class2117_1;
	}

	private void method_26(Class2117 _tickMarkSkip)
	{
		class2117_1 = _tickMarkSkip;
	}

	private Class1885 method_27()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_28(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}

	private Class2605 method_29(string elementName)
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
