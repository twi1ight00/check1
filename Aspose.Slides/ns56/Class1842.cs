using System;
using System.Xml;

namespace ns56;

internal class Class1842 : Class1351
{
	public delegate Class1842 Delegate1405();

	public delegate void Delegate1406(Class1842 elementData);

	public delegate void Delegate1407(Class1842 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 FillProperties
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
				case "noFill":
					class2605_0 = new Class2605("noFill", new Class1878(reader));
					break;
				case "solidFill":
					class2605_0 = new Class2605("solidFill", new Class1924(reader));
					break;
				case "gradFill":
					class2605_0 = new Class2605("gradFill", new Class1853(reader));
					break;
				case "blipFill":
					class2605_0 = new Class2605("blipFill", new Class1810(reader));
					break;
				case "pattFill":
					class2605_0 = new Class2605("pattFill", new Class1900(reader));
					break;
				case "grpFill":
					class2605_0 = new Class2605("grpFill", new Class1859(reader));
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

	public Class1842(XmlReader reader)
		: base(reader)
	{
	}

	public Class1842()
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
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "noFill":
				((Class1878)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "solidFill":
				((Class1924)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "gradFill":
				((Class1853)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "blipFill":
				((Class1810)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "pattFill":
				((Class1900)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "grpFill":
				((Class1859)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("FillProperties already is initialized.");
		}
		switch (elementName)
		{
		case "noFill":
			class2605_0 = new Class2605("noFill", new Class1878());
			break;
		case "solidFill":
			class2605_0 = new Class2605("solidFill", new Class1924());
			break;
		case "gradFill":
			class2605_0 = new Class2605("gradFill", new Class1853());
			break;
		case "blipFill":
			class2605_0 = new Class2605("blipFill", new Class1810());
			break;
		case "pattFill":
			class2605_0 = new Class2605("pattFill", new Class1900());
			break;
		case "grpFill":
			class2605_0 = new Class2605("grpFill", new Class1859());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
