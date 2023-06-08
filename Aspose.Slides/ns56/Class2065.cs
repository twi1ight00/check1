using System;
using System.Xml;

namespace ns56;

internal class Class2065 : Class1351
{
	public delegate Class2065 Delegate1908();

	public delegate void Delegate1910(Class2065 elementData);

	public delegate void Delegate1909(Class2065 elementData);

	public Class2066.Delegate1911 delegate1911_0;

	public Class2066.Delegate1913 delegate1913_0;

	public Class1885.Delegate1534 delegate1534_0;

	public Class1885.Delegate1535 delegate1535_0;

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	private Class2066 class2066_0;

	private Class1887 class1887_0;

	public Class2605 DisplayUnit
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

	public Class2066 DispUnitsLbl => class2066_0;

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
				case "dispUnitsLbl":
					class2066_0 = new Class2066(reader);
					break;
				case "builtInUnit":
					class2605_0 = new Class2605("builtInUnit", new Class2052(reader));
					break;
				case "custUnit":
					class2605_0 = new Class2605("custUnit", new Class2070(reader));
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

	public Class2065(XmlReader reader)
		: base(reader)
	{
	}

	public Class2065()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_7;
		delegate1911_0 = method_3;
		delegate1913_0 = method_4;
		delegate1534_0 = method_5;
		delegate1535_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "builtInUnit":
				((Class2052)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			case "custUnit":
				((Class2070)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			}
		}
		if (class2066_0 != null)
		{
			class2066_0.vmethod_4("c", writer, "dispUnitsLbl");
		}
		if (class1887_0 != null)
		{
			class1887_0.vmethod_4("c", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class2066 method_3()
	{
		if (class2066_0 != null)
		{
			throw new Exception("Only one <dispUnitsLbl> element can be added.");
		}
		class2066_0 = new Class2066();
		return class2066_0;
	}

	private void method_4(Class2066 _dispUnitsLbl)
	{
		class2066_0 = _dispUnitsLbl;
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
			throw new Exception("DisplayUnit already is initialized.");
		}
		switch (elementName)
		{
		case "builtInUnit":
			class2605_0 = new Class2605("builtInUnit", new Class2052());
			break;
		case "custUnit":
			class2605_0 = new Class2605("custUnit", new Class2070());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
