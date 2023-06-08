using System;
using System.Xml;

namespace ns56;

internal class Class1924 : Class1351
{
	public delegate Class1924 Delegate1639();

	public delegate void Delegate1640(Class1924 elementData);

	public delegate void Delegate1641(Class1924 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 Color
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
				case "scrgbClr":
					class2605_0 = new Class2605("scrgbClr", new Class1918(reader));
					break;
				case "srgbClr":
					class2605_0 = new Class2605("srgbClr", new Class1926(reader));
					break;
				case "hslClr":
					class2605_0 = new Class2605("hslClr", new Class1863(reader));
					break;
				case "sysClr":
					class2605_0 = new Class2605("sysClr", new Class1931(reader));
					break;
				case "schemeClr":
					class2605_0 = new Class2605("schemeClr", new Class1917(reader));
					break;
				case "prstClr":
					class2605_0 = new Class2605("prstClr", new Class1907(reader));
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

	public Class1924(XmlReader reader)
		: base(reader)
	{
	}

	public Class1924()
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
			case "scrgbClr":
				((Class1918)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "srgbClr":
				((Class1926)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "hslClr":
				((Class1863)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "sysClr":
				((Class1931)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "schemeClr":
				((Class1917)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "prstClr":
				((Class1907)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Color already is initialized.");
		}
		switch (elementName)
		{
		case "scrgbClr":
			class2605_0 = new Class2605("scrgbClr", new Class1918());
			break;
		case "srgbClr":
			class2605_0 = new Class2605("srgbClr", new Class1926());
			break;
		case "hslClr":
			class2605_0 = new Class2605("hslClr", new Class1863());
			break;
		case "sysClr":
			class2605_0 = new Class2605("sysClr", new Class1931());
			break;
		case "schemeClr":
			class2605_0 = new Class2605("schemeClr", new Class1917());
			break;
		case "prstClr":
			class2605_0 = new Class2605("prstClr", new Class1907());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
