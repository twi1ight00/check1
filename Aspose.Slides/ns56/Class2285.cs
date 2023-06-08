using System;
using System.Xml;
using ns57;

namespace ns56;

internal class Class2285 : Class1351
{
	public delegate Class2285 Delegate2602();

	public delegate void Delegate2604(Class2285 elementData);

	public delegate void Delegate2603(Class2285 elementData);

	public const bool bool_0 = false;

	public Class2605.Delegate2773 delegate2773_0;

	private Enum276 enum276_0;

	private bool bool_1;

	private Class2605 class2605_0;

	public static readonly Enum276 enum276_1 = Class2530.smethod_0("el");

	public Enum276 Type
	{
		get
		{
			return enum276_0;
		}
		set
		{
			enum276_0 = value;
		}
	}

	public bool Backwards
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class2605 IterateInterval
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
				case "tmPct":
					class2605_0 = new Class2605("tmPct", new Class2286(reader));
					break;
				case "tmAbs":
					class2605_0 = new Class2605("tmAbs", new Class2287(reader));
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
				case "backwards":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "type":
					enum276_0 = Class2530.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2285(XmlReader reader)
		: base(reader)
	{
	}

	public Class2285()
	{
	}

	protected override void vmethod_1()
	{
		enum276_0 = enum276_1;
		bool_1 = false;
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
		if (enum276_0 != enum276_1)
		{
			writer.WriteAttributeString("type", Class2530.smethod_1(enum276_0));
		}
		if (bool_1)
		{
			writer.WriteAttributeString("backwards", bool_1 ? "1" : "0");
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "tmPct":
				((Class2286)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "tmAbs":
				((Class2287)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("IterateInterval already is initialized.");
		}
		switch (elementName)
		{
		case "tmPct":
			class2605_0 = new Class2605("tmPct", new Class2286());
			break;
		case "tmAbs":
			class2605_0 = new Class2605("tmAbs", new Class2287());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
