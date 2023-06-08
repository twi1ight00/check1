using System;
using System.Xml;

namespace ns56;

internal class Class1982 : Class1351
{
	public delegate Class1982 Delegate1813();

	public delegate void Delegate1814(Class1982 elementData);

	public delegate void Delegate1815(Class1982 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2003 class2003_0;

	private Class1906 class1906_0;

	private Class2605 class2605_0;

	public Class2003 From => class2003_0;

	public Class1906 Ext => class1906_0;

	public Class2605 Shape
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
				case "from":
					class2003_0 = new Class2003(reader);
					break;
				case "ext":
					class1906_0 = new Class1906(reader);
					break;
				case "sp":
					class2605_0 = new Class2605("sp", new Class2012(reader));
					break;
				case "grpSp":
					class2605_0 = new Class2605("grpSp", new Class1996(reader));
					break;
				case "graphicFrame":
					class2605_0 = new Class2605("graphicFrame", new Class1990(reader));
					break;
				case "cxnSp":
					class2605_0 = new Class2605("cxnSp", new Class1984(reader));
					break;
				case "pic":
					class2605_0 = new Class2605("pic", new Class2005(reader));
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

	public Class1982(XmlReader reader)
		: base(reader)
	{
	}

	public Class1982()
	{
	}

	protected override void vmethod_1()
	{
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_3;
	}

	protected override void vmethod_3()
	{
		class2003_0 = new Class2003();
		class1906_0 = new Class1906();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2003_0.vmethod_4("cdr", writer, "from");
		class1906_0.vmethod_4("cdr", writer, "ext");
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "pic":
				((Class2005)class2605_0.Object).vmethod_4("cdr", writer, class2605_0.Name);
				break;
			case "cxnSp":
				((Class1984)class2605_0.Object).vmethod_4("cdr", writer, class2605_0.Name);
				break;
			case "graphicFrame":
				((Class1990)class2605_0.Object).vmethod_4("cdr", writer, class2605_0.Name);
				break;
			case "grpSp":
				((Class1996)class2605_0.Object).vmethod_4("cdr", writer, class2605_0.Name);
				break;
			case "sp":
				((Class2012)class2605_0.Object).vmethod_4("cdr", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Shape already is initialized.");
		}
		switch (elementName)
		{
		case "pic":
			class2605_0 = new Class2605("pic", new Class2005());
			break;
		case "cxnSp":
			class2605_0 = new Class2605("cxnSp", new Class1984());
			break;
		case "graphicFrame":
			class2605_0 = new Class2605("graphicFrame", new Class1990());
			break;
		case "grpSp":
			class2605_0 = new Class2605("grpSp", new Class1996());
			break;
		case "sp":
			class2605_0 = new Class2605("sp", new Class2012());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
