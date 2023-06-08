using System;
using System.Xml;

namespace ns56;

internal class Class1816 : Class1351
{
	public delegate Class1816 Delegate1327();

	public delegate void Delegate1328(Class1816 elementData);

	public delegate void Delegate1329(Class1816 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 ColorMappingOverride
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
				case "overrideClrMapping":
					class2605_0 = new Class2605("overrideClrMapping", new Class1815(reader));
					break;
				case "masterClrMapping":
					class2605_0 = new Class2605("masterClrMapping", new Class1839(reader));
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

	public Class1816(XmlReader reader)
		: base(reader)
	{
	}

	public Class1816()
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
			case "overrideClrMapping":
				((Class1815)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			case "masterClrMapping":
				((Class1839)class2605_0.Object).vmethod_4("a", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("ColorMappingOverride already is initialized.");
		}
		switch (elementName)
		{
		case "overrideClrMapping":
			class2605_0 = new Class2605("overrideClrMapping", new Class1815());
			break;
		case "masterClrMapping":
			class2605_0 = new Class2605("masterClrMapping", new Class1839());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
