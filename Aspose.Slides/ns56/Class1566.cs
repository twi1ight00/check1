using System;
using System.Xml;

namespace ns56;

internal class Class1566 : Class1351
{
	public delegate Class1566 Delegate577();

	public delegate void Delegate578(Class1566 elementData);

	public delegate void Delegate579(Class1566 elementData);

	public Class2605.Delegate2773 delegate2773_0;

	private uint uint_0;

	private Enum217 enum217_0;

	private Class2605 class2605_0;

	public uint N
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public Enum217 F
	{
		get
		{
			return enum217_0;
		}
		set
		{
			enum217_0 = value;
		}
	}

	public Class2605 MDXMetadata
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
				case "k":
					class2605_0 = new Class2605("k", new Class1567(reader));
					break;
				case "p":
					class2605_0 = new Class2605("p", new Class1568(reader));
					break;
				case "ms":
					class2605_0 = new Class2605("ms", new Class1570(reader));
					break;
				case "t":
					class2605_0 = new Class2605("t", new Class1571(reader));
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "f":
					enum217_0 = Class2384.smethod_0(reader.Value);
					break;
				case "n":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1566(XmlReader reader)
		: base(reader)
	{
	}

	public Class1566()
	{
	}

	protected override void vmethod_1()
	{
		enum217_0 = Enum217.const_0;
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
		writer.WriteAttributeString("n", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("f", Class2384.smethod_1(enum217_0));
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "k":
				((Class1567)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "p":
				((Class1568)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "ms":
				((Class1570)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "t":
				((Class1571)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("MDXMetadata already is initialized.");
		}
		switch (elementName)
		{
		case "k":
			class2605_0 = new Class2605("k", new Class1567());
			break;
		case "p":
			class2605_0 = new Class2605("p", new Class1568());
			break;
		case "ms":
			class2605_0 = new Class2605("ms", new Class1570());
			break;
		case "t":
			class2605_0 = new Class2605("t", new Class1571());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
