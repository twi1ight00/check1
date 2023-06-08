using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class2222 : Class1351
{
	public delegate Class2222 Delegate2402();

	public delegate void Delegate2403(Class2222 elementData);

	public delegate void Delegate2404(Class2222 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private BlackWhiteMode blackWhiteMode_0;

	private Class2605 class2605_0;

	public static readonly BlackWhiteMode blackWhiteMode_1 = Class2517.smethod_0("white");

	public BlackWhiteMode BwMode
	{
		get
		{
			return blackWhiteMode_0;
		}
		set
		{
			blackWhiteMode_0 = value;
		}
	}

	public Class2605 Background
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
				case "bgRef":
					class2605_0 = new Class2605("bgRef", new Class1929(reader));
					break;
				case "bgPr":
					class2605_0 = new Class2605("bgPr", new Class2223(reader));
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "bwMode")
			{
				blackWhiteMode_0 = Class2517.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2222(XmlReader reader)
		: base(reader)
	{
	}

	public Class2222()
	{
	}

	protected override void vmethod_1()
	{
		blackWhiteMode_0 = blackWhiteMode_1;
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
		if (blackWhiteMode_0 != blackWhiteMode_1)
		{
			writer.WriteAttributeString("bwMode", Class2517.smethod_1(blackWhiteMode_0));
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "bgRef":
				((Class1929)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "bgPr":
				((Class2223)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Background already is initialized.");
		}
		switch (elementName)
		{
		case "bgRef":
			class2605_0 = new Class2605("bgRef", new Class1929());
			break;
		case "bgPr":
			class2605_0 = new Class2605("bgPr", new Class2223());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
