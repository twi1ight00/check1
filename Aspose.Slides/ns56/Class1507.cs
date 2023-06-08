using System;
using System.Xml;

namespace ns56;

internal class Class1507 : Class1351
{
	public delegate Class1507 Delegate400();

	public delegate void Delegate401(Class1507 elementData);

	public delegate void Delegate402(Class1507 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 Link
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
				case "extLst":
					class2605_0 = new Class2605("extLst", new Class1502(reader));
					break;
				case "oleLink":
					class2605_0 = new Class2605("oleLink", new Class1598(reader));
					break;
				case "ddeLink":
					class2605_0 = new Class2605("ddeLink", new Class1488(reader));
					break;
				case "externalBook":
					class2605_0 = new Class2605("externalBook", new Class1503(reader));
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

	public Class1507(XmlReader reader)
		: base(reader)
	{
	}

	public Class1507()
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
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		if (writer.LookupPrefix("http://schemas.openxmlformats.org/officeDocument/2006/relationships") == null)
		{
			writer.WriteAttributeString("xmlns", "r", null, "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "extLst":
				((Class1502)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "oleLink":
				((Class1598)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "ddeLink":
				((Class1488)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "externalBook":
				((Class1503)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Link already is initialized.");
		}
		switch (elementName)
		{
		case "extLst":
			class2605_0 = new Class2605("extLst", new Class1502());
			break;
		case "oleLink":
			class2605_0 = new Class2605("oleLink", new Class1598());
			break;
		case "ddeLink":
			class2605_0 = new Class2605("ddeLink", new Class1488());
			break;
		case "externalBook":
			class2605_0 = new Class2605("externalBook", new Class1503());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
