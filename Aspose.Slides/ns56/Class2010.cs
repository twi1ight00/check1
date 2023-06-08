using System;
using System.Xml;

namespace ns56;

internal class Class2010 : Class1351
{
	public delegate Class2010 Delegate1839();

	public delegate void Delegate1840(Class2010 elementData);

	public delegate void Delegate1841(Class2010 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2003 class2003_0;

	private Class2003 class2003_1;

	private Class2605 class2605_0;

	public Class2003 From => class2003_0;

	public Class2003 To => class2003_1;

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
				case "to":
					class2003_1 = new Class2003(reader);
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

	public Class2010(XmlReader reader)
		: base(reader)
	{
	}

	public Class2010()
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
		class2003_1 = new Class2003();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		class2003_0.vmethod_4("cdr", writer, "from");
		class2003_1.vmethod_4("cdr", writer, "to");
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
