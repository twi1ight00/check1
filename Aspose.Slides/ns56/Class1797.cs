using System;
using System.Xml;

namespace ns56;

internal class Class1797 : Class1351
{
	public delegate Class1797 Delegate1270();

	public delegate void Delegate1271(Class1797 elementData);

	public delegate void Delegate1272(Class1797 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 Animation
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
				case "chart":
					class2605_0 = new Class2605("chart", new Class1794(reader));
					break;
				case "dgm":
					class2605_0 = new Class2605("dgm", new Class1796(reader));
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

	public Class1797(XmlReader reader)
		: base(reader)
	{
	}

	public Class1797()
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
			case "chart":
				((Class1794)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "dgm":
				((Class1796)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Animation already is initialized.");
		}
		switch (elementName)
		{
		case "chart":
			class2605_0 = new Class2605("chart", new Class1794());
			break;
		case "dgm":
			class2605_0 = new Class2605("dgm", new Class1796());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
