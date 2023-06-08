using System;
using System.Xml;

namespace ns56;

internal class Class2279 : Class1351
{
	public delegate Class2279 Delegate2584();

	public delegate void Delegate2586(Class2279 elementData);

	public delegate void Delegate2585(Class2279 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 ColorTransform
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
				case "hsl":
					class2605_0 = new Class2605("hsl", new Class1775(reader));
					break;
				case "rgb":
					class2605_0 = new Class2605("rgb", new Class1776(reader));
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

	public Class2279(XmlReader reader)
		: base(reader)
	{
	}

	public Class2279()
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
			case "hsl":
				((Class1775)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "rgb":
				((Class1776)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("ColorTransform already is initialized.");
		}
		switch (elementName)
		{
		case "hsl":
			class2605_0 = new Class2605("hsl", new Class1775());
			break;
		case "rgb":
			class2605_0 = new Class2605("rgb", new Class1776());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
