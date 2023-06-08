using System;
using System.Xml;

namespace ns56;

internal class Class1769 : Class1351
{
	public delegate Class1769 Delegate1186();

	public delegate void Delegate1187(Class1769 elementData);

	public delegate void Delegate1188(Class1769 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Enum261 enum261_0;

	private Class1772 class1772_0;

	private Class1772 class1772_1;

	private Class2605 class2605_0;

	private Class1756 class1756_0;

	public static readonly Enum261 enum261_1 = Class2428.smethod_0("twoCell");

	public Enum261 EditAs
	{
		get
		{
			return enum261_0;
		}
		set
		{
			enum261_0 = value;
		}
	}

	public Class1772 From => class1772_0;

	public Class1772 To => class1772_1;

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
				case "to":
					class1772_1 = new Class1772(reader);
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
		while (reader.MoveToNextAttribute())
		{
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "editAs")
			{
				enum261_0 = Class2428.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1769(XmlReader reader)
		: base(reader)
	{
	}

	public Class1769()
	{
	}

	protected override void vmethod_1()
	{
		enum261_0 = enum261_1;
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_3;
	}

	protected override void vmethod_3()
	{
		class1772_0 = new Class1772();
		class1772_1 = new Class1772();
		class1756_0 = new Class1756();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum261_0 != enum261_1)
		{
			writer.WriteAttributeString("editAs", Class2428.smethod_1(enum261_0));
		}
		class1772_0.vmethod_4("xdr", writer, "from");
		class1772_1.vmethod_4("xdr", writer, "to");
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
