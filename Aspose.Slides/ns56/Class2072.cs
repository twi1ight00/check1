using System;
using System.Xml;

namespace ns56;

internal class Class2072 : Class1351
{
	public delegate Class2072 Delegate1930();

	public delegate void Delegate1931(Class2072 elementData);

	public delegate void Delegate1932(Class2072 elementData);

	public Class2339.Delegate2763 delegate2763_0;

	public Class2339.Delegate2764 delegate2764_0;

	public Class2339.Delegate2763 delegate2763_1;

	public Class2339.Delegate2764 delegate2764_1;

	public Class2339.Delegate2763 delegate2763_2;

	public Class2339.Delegate2764 delegate2764_2;

	public Class2339.Delegate2763 delegate2763_3;

	public Class2339.Delegate2764 delegate2764_3;

	public Class1921.Delegate1630 delegate1630_0;

	public Class1921.Delegate1632 delegate1632_0;

	public Class1946.Delegate1705 delegate1705_0;

	public Class1946.Delegate1707 delegate1707_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	private Class2339 class2339_0;

	private Class2339 class2339_1;

	private Class2339 class2339_2;

	private Class2339 class2339_3;

	private Class1921 class1921_0;

	private Class1946 class1946_0;

	private Class1887 class1887_0;

	public Class2339 ShowHorzBorder => class2339_0;

	public Class2339 ShowVertBorder => class2339_1;

	public Class2339 ShowOutline => class2339_2;

	public Class2339 ShowKeys => class2339_3;

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
				case "showHorzBorder":
					class2339_0 = new Class2339(reader);
					break;
				case "showVertBorder":
					class2339_1 = new Class2339(reader);
					break;
				case "showOutline":
					class2339_2 = new Class2339(reader);
					break;
				case "showKeys":
					class2339_3 = new Class2339(reader);
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

	public Class2072(XmlReader reader)
		: base(reader)
	{
	}

	public Class2072()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2763_0 = method_3;
		delegate2764_0 = method_4;
		delegate2763_1 = method_5;
		delegate2764_1 = method_6;
		delegate2763_2 = method_7;
		delegate2764_2 = method_8;
		delegate2763_3 = method_9;
		delegate2764_3 = method_10;
		delegate1630_0 = method_11;
		delegate1632_0 = method_12;
		delegate1705_0 = method_13;
		delegate1707_0 = method_14;
		delegate1534_0 = method_15;
		delegate1535_0 = method_16;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2339_0 != null)
		{
			class2339_0.vmethod_4("c", writer, "showHorzBorder");
		}
		if (class2339_1 != null)
		{
			class2339_1.vmethod_4("c", writer, "showVertBorder");
		}
		if (class2339_2 != null)
		{
			class2339_2.vmethod_4("c", writer, "showOutline");
		}
		if (class2339_3 != null)
		{
			class2339_3.vmethod_4("c", writer, "showKeys");
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

	private Class2339 method_3()
	{
		if (class2339_0 != null)
		{
			throw new Exception("Only one <showHorzBorder> element can be added.");
		}
		class2339_0 = new Class2339();
		return class2339_0;
	}

	private void method_4(Class2339 _showHorzBorder)
	{
		class2339_0 = _showHorzBorder;
	}

	private Class2339 method_5()
	{
		if (class2339_1 != null)
		{
			throw new Exception("Only one <showVertBorder> element can be added.");
		}
		class2339_1 = new Class2339();
		return class2339_1;
	}

	private void method_6(Class2339 _showVertBorder)
	{
		class2339_1 = _showVertBorder;
	}

	private Class2339 method_7()
	{
		if (class2339_2 != null)
		{
			throw new Exception("Only one <showOutline> element can be added.");
		}
		class2339_2 = new Class2339();
		return class2339_2;
	}

	private void method_8(Class2339 _showOutline)
	{
		class2339_2 = _showOutline;
	}

	private Class2339 method_9()
	{
		if (class2339_3 != null)
		{
			throw new Exception("Only one <showKeys> element can be added.");
		}
		class2339_3 = new Class2339();
		return class2339_3;
	}

	private void method_10(Class2339 _showKeys)
	{
		class2339_3 = _showKeys;
	}

	private Class1921 method_11()
	{
		if (class1921_0 != null)
		{
			throw new Exception("Only one <spPr> element can be added.");
		}
		class1921_0 = new Class1921();
		return class1921_0;
	}

	private void method_12(Class1921 _spPr)
	{
		class1921_0 = _spPr;
	}

	private Class1946 method_13()
	{
		if (class1946_0 != null)
		{
			throw new Exception("Only one <txPr> element can be added.");
		}
		class1946_0 = new Class1946();
		return class1946_0;
	}

	private void method_14(Class1946 _txPr)
	{
		class1946_0 = _txPr;
	}

	private Class1885 method_15()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_16(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}
}
