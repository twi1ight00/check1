using System;
using System.Xml;

namespace ns56;

internal class Class1385 : Class1351
{
	public delegate Class1385 Delegate117();

	public delegate void Delegate118(Class1385 elementData);

	public delegate void Delegate119(Class1385 elementData);

	public const uint uint_0 = 0u;

	public Class2605.Delegate2773 delegate2773_0;

	private Enum245 enum245_0;

	private uint uint_1;

	private Class2605 class2605_0;

	public Enum245 Type
	{
		get
		{
			return enum245_0;
		}
		set
		{
			enum245_0 = value;
		}
	}

	public uint ConnectionId
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
		}
	}

	public Class2605 Source
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
				case "consolidation":
					class2605_0 = new Class2605("consolidation", new Class1432(reader));
					break;
				case "worksheetSource":
					class2605_0 = new Class2605("worksheetSource", new Class1748(reader));
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
				case "connectionId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "type":
					enum245_0 = Class2412.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1385(XmlReader reader)
		: base(reader)
	{
	}

	public Class1385()
	{
	}

	protected override void vmethod_1()
	{
		enum245_0 = Enum245.const_0;
		uint_1 = 0u;
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
		writer.WriteAttributeString("type", Class2412.smethod_1(enum245_0));
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("connectionId", XmlConvert.ToString(uint_1));
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "extLst":
				((Class1502)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "consolidation":
				((Class1432)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			case "worksheetSource":
				((Class1748)class2605_0.Object).vmethod_4("ssml", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Source already is initialized.");
		}
		switch (elementName)
		{
		case "extLst":
			class2605_0 = new Class2605("extLst", new Class1502());
			break;
		case "consolidation":
			class2605_0 = new Class2605("consolidation", new Class1432());
			break;
		case "worksheetSource":
			class2605_0 = new Class2605("worksheetSource", new Class1748());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
