using System;
using System.Xml;

namespace ns56;

internal class Class2294 : Class1351
{
	public delegate Class2294 Delegate2629();

	public delegate void Delegate2630(Class2294 elementData);

	public delegate void Delegate2631(Class2294 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private string string_0;

	private Class2605 class2605_0;

	public string Spid
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public Class2605 TargetShape
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
				case "graphicEl":
					class2605_0 = new Class2605("graphicEl", new Class1797(reader));
					break;
				case "txEl":
					class2605_0 = new Class2605("txEl", new Class2298(reader));
					break;
				case "oleChartEl":
					class2605_0 = new Class2605("oleChartEl", new Class2291(reader));
					break;
				case "subSp":
					class2605_0 = new Class2605("subSp", new Class2295(reader));
					break;
				case "bg":
					class2605_0 = new Class2605("bg", new Class2235(reader));
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "spid")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class2294(XmlReader reader)
		: base(reader)
	{
	}

	public Class2294()
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
		writer.WriteAttributeString("spid", string_0);
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "graphicEl":
				((Class1797)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "txEl":
				((Class2298)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "oleChartEl":
				((Class2291)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "subSp":
				((Class2295)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "bg":
				((Class2235)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("TargetShape already is initialized.");
		}
		switch (elementName)
		{
		case "graphicEl":
			class2605_0 = new Class2605("graphicEl", new Class1797());
			break;
		case "txEl":
			class2605_0 = new Class2605("txEl", new Class2298());
			break;
		case "oleChartEl":
			class2605_0 = new Class2605("oleChartEl", new Class2291());
			break;
		case "subSp":
			class2605_0 = new Class2605("subSp", new Class2295());
			break;
		case "bg":
			class2605_0 = new Class2605("bg", new Class2235());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
