using System;
using System.Xml;

namespace ns56;

internal class Class2134 : Class1351
{
	public delegate Class2134 Delegate2133();

	public delegate void Delegate2135(Class2134 elementData);

	public delegate void Delegate2134(Class2134 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 Text
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
				case "rich":
					class2605_0 = new Class2605("rich", new Class1946(reader));
					break;
				case "strRef":
					class2605_0 = new Class2605("strRef", new Class2120(reader));
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

	public Class2134(XmlReader reader)
		: base(reader)
	{
	}

	public Class2134()
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
			case "rich":
				((Class1946)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			case "strRef":
				((Class2120)class2605_0.Object).vmethod_4("c", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Text already is initialized.");
		}
		switch (elementName)
		{
		case "rich":
			class2605_0 = new Class2605("rich", new Class1946());
			break;
		case "strRef":
			class2605_0 = new Class2605("strRef", new Class2120());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
