using System;
using System.Xml;

namespace ns56;

internal class Class1764 : Class1351
{
	public delegate Class1764 Delegate1171();

	public delegate void Delegate1172(Class1764 elementData);

	public delegate void Delegate1173(Class1764 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class1772 class1772_0;

	private Class1906 class1906_0;

	private Class2605 class2605_0;

	private Class1756 class1756_0;

	public Class1772 From => class1772_0;

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

	public Class1756 ClientData => class1756_0;

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
					class1772_0 = new Class1772(reader);
					break;
				case "ext":
					class1906_0 = new Class1906(reader);
					break;
				case "sp":
					class2605_0 = new Class2605("sp", new Class1767(reader));
					break;
				case "grpSp":
					class2605_0 = new Class2605("grpSp", new Class1762(reader));
					break;
				case "graphicFrame":
					class2605_0 = new Class2605("graphicFrame", new Class1760(reader));
					break;
				case "cxnSp":
					class2605_0 = new Class2605("cxnSp", new Class1757(reader));
					break;
				case "pic":
					class2605_0 = new Class2605("pic", new Class1765(reader));
					break;
				case "clientData":
					class1756_0 = new Class1756(reader);
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

	public Class1764(XmlReader reader)
		: base(reader)
	{
	}

	public Class1764()
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
		class1772_0 = new Class1772();
		class1906_0 = new Class1906();
		class1756_0 = new Class1756();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class1772_0.vmethod_4("xdr", writer, "from");
		class1906_0.vmethod_4("xdr", writer, "ext");
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "pic":
				((Class1765)class2605_0.Object).vmethod_4("xdr", writer, class2605_0.Name);
				break;
			case "cxnSp":
				((Class1757)class2605_0.Object).vmethod_4("xdr", writer, class2605_0.Name);
				break;
			case "graphicFrame":
				((Class1760)class2605_0.Object).vmethod_4("xdr", writer, class2605_0.Name);
				break;
			case "grpSp":
				((Class1762)class2605_0.Object).vmethod_4("xdr", writer, class2605_0.Name);
				break;
			case "sp":
				((Class1767)class2605_0.Object).vmethod_4("xdr", writer, class2605_0.Name);
				break;
			}
		}
		class1756_0.vmethod_4("xdr", writer, "clientData");
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
			class2605_0 = new Class2605("pic", new Class1765());
			break;
		case "cxnSp":
			class2605_0 = new Class2605("cxnSp", new Class1757());
			break;
		case "graphicFrame":
			class2605_0 = new Class2605("graphicFrame", new Class1760());
			break;
		case "grpSp":
			class2605_0 = new Class2605("grpSp", new Class1762());
			break;
		case "sp":
			class2605_0 = new Class2605("sp", new Class1767());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
