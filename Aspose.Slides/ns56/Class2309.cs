using System;
using System.Xml;

namespace ns56;

internal class Class2309 : Class1351
{
	public delegate Class2309 Delegate2674();

	public delegate void Delegate2676(Class2309 elementData);

	public delegate void Delegate2675(Class2309 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private Class2605 class2605_0;

	public Class2605 Action
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
				case "endSnd":
					class2605_0 = new Class2605("endSnd", new Class2235(reader));
					break;
				case "stSnd":
					class2605_0 = new Class2605("stSnd", new Class2310(reader));
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

	public Class2309(XmlReader reader)
		: base(reader)
	{
	}

	public Class2309()
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
			case "endSnd":
				((Class2235)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "stSnd":
				((Class2310)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Action already is initialized.");
		}
		switch (elementName)
		{
		case "endSnd":
			class2605_0 = new Class2605("endSnd", new Class2235());
			break;
		case "stSnd":
			class2605_0 = new Class2605("stSnd", new Class2310());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
