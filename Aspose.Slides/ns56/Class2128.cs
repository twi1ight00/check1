using System;
using System.Xml;

namespace ns56;

internal class Class2128 : Class1351
{
	public delegate Class2128 Delegate2115();

	public delegate void Delegate2117(Class2128 elementData);

	public delegate void Delegate2116(Class2128 elementData);

	public Class2134.Delegate2133 delegate2133_0;

	public Class2134.Delegate2135 delegate2135_0;

	public Class2080.Delegate1955 delegate1955_0;

	public Class2080.Delegate1957 delegate1957_0;

	public Class2339.Delegate2763 delegate2763_0;

	public Class2339.Delegate2764 delegate2764_0;

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class1946.Delegate1705 delegate1705_0;

	public Class1946.Delegate1707 delegate1707_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2134 class2134_0;

	private Class2080 class2080_0;

	private Class2339 class2339_0;

	private Class1921 class1921_0;

	private Class1946 class1946_0;

	private Class1887 class1887_0;

	public Class2134 Tx => class2134_0;

	public Class2080 Layout => class2080_0;

	public Class2339 Overlay => class2339_0;

	public Class1921 SpPr => class1921_0;

	public Class1946 TxPr => class1946_0;

	public Class1885 ExtLst => class1887_0;

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
				case "tx":
					class2134_0 = new Class2134(reader);
					break;
				case "layout":
					class2080_0 = new Class2080(reader);
					break;
				case "overlay":
					class2339_0 = new Class2339(reader);
					break;
				case "spPr":
					class1921_0 = new Class1921(reader);
					break;
				case "txPr":
					class1946_0 = new Class1946(reader);
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

	public Class2128(XmlReader reader)
		: base(reader)
	{
	}

	public Class2128()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2133_0 = method_3;
		delegate2135_0 = method_4;
		delegate1955_0 = method_5;
		delegate1957_0 = method_6;
		delegate2763_0 = method_7;
		delegate2764_0 = method_8;
		delegate1630_0 = method_9;
		delegate1632_0 = method_10;
		delegate1705_0 = method_11;
		delegate1707_0 = method_12;
		delegate1534_0 = method_13;
		delegate1535_0 = method_14;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2134_0 != null)
		{
			class2134_0.vmethod_4("c", writer, "tx");
		}
		if (class2080_0 != null)
		{
			class2080_0.vmethod_4("c", writer, "layout");
		}
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "overlay");
		}
		if (class1921_0 != null)
		{
			class1921_0.vmethod_4("c", writer, "spPr");
		}
		if (class1946_0 != null)
		{
			class1946_0.vmethod_4("c", writer, "txPr");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2134 method_3()
	{
		if (class2134_0 != null)
		{
			throw new Exception("Only one <tx> element can be added.");
		}
		class2134_0 = new Class2134();
		return class2134_0;
	}

	private void method_4(Class2134 _tx)
	{
		class2134_0 = _tx;
	}

	private Class2080 method_5()
	{
		if (class2080_0 != null)
		{
			throw new Exception("Only one <layout> element can be added.");
		}
		class2080_0 = new Class2080();
		return class2080_0;
	}

	private void method_6(Class2080 _layout)
	{
		class2080_0 = _layout;
	}

	private Class2339 method_7()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <overlay> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_8(Class2339 _overlay)
	{
		class2339_0 = _overlay;
	}

	private Class1921 method_9()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_10(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class1946 method_11()
	{
		if (class1946_0 != null)
		{
			throw new Exception("Only one <txPr> element can be added.");
		}
		class1946_0 = new Class1946();
		return class1946_0;
	}

	private void method_12(Class1946 _txPr)
	{
		class1946_0 = _txPr;
	}

	private Class1885 method_13()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_14(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
