using System;
using System.Xml;

namespace ns56;

internal class Class2086 : Class1351
{
	public delegate Class2086 Delegate1973();

	public delegate void Delegate1974(Class2086 elementData);

	public delegate void Delegate1975(Class2086 elementData);

	public Class1946.Delegate1705 delegate1705_0;

	public Class1946.Delegate1707 delegate1707_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	private Class2135 class2135_0;

	private Class1946 class1946_0;

	private Class2605 class2605_0;

	private Class1887 class1887_0;

	public Class2135 Idx => class2135_0;

	public Class1946 TxPr => class1946_0;

	public Class2605 Delete
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
				case "extLst":
					class1887_0 = new Class1887(reader);
					break;
				case "txPr":
					class1946_0 = new Class1946(reader);
					break;
				case "delete":
					class2605_0 = new Class2605("delete", new Class2339(reader));
					break;
				case "idx":
					class2135_0 = new Class2135(reader);
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

	public Class2086(XmlReader reader)
		: base(reader)
	{
	}

	public Class2086()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_7;
		delegate1705_0 = method_3;
		delegate1707_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
		class2135_0 = new Class2135();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2135_0.vmethod_4("c", writer, "idx");
		string name;
		if (class2605_0 != null && (name = class2605_0.Name) != null && name == "delete")
		{
			((Class2339)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
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

	private Class1946 method_3()
	{
		if (class1946_0 != null)
		{
			throw new Exception("Only one <txPr> element can be added.");
		}
		class1946_0 = new Class1946();
		return class1946_0;
	}

	private void method_4(Class1946 _txPr)
	{
		class1946_0 = _txPr;
	}

	private Class1885 method_5()
	{
		if (class1887_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1887_0 = new Class1887();
		return class1887_0;
	}

	private void method_6(Class1885 _extLst)
	{
		class1887_0 = (Class1887)_extLst;
	}

	private Class2605 method_7(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Delete already is initialized.");
		}
		string text;
		if ((text = elementName) == null || !(text == "delete"))
		{
			throw new Exception("Wrong element: " + elementName);
		}
		class2605_0 = new Class2605("delete", new Class2339());
		return class2605_0;
	}
}
