using System;
using System.Xml;
using ns57;

namespace ns56;

internal class Class2301 : Class1351
{
	public delegate Class2301 Delegate2650();

	public delegate void Delegate2652(Class2301 elementData);

	public delegate void Delegate2651(Class2301 elementData);

	public const Enum277 enum277_0 = Enum277.const_0;

	public Class2605.Delegate2773 delegate2773_0;

	private Enum277 enum277_1;

	private string string_0;

	private Class2605 class2605_0;

	public Enum277 Evt
	{
		get
		{
			return enum277_1;
		}
		set
		{
			enum277_1 = value;
		}
	}

	public string Delay
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

	public Class2605 Trigger
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
				case "rtn":
					class2605_0 = new Class2605("rtn", new Class2307(reader));
					break;
				case "tn":
					class2605_0 = new Class2605("tn", new Class2308(reader));
					break;
				case "tgtEl":
					class2605_0 = new Class2605("tgtEl", new Class2306(reader));
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
				case "delay":
					string_0 = reader.Value;
					break;
				case "evt":
					enum277_1 = Class2600.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2301(XmlReader reader)
		: base(reader)
	{
	}

	public Class2301()
	{
	}

	protected override void vmethod_1()
	{
		enum277_1 = Enum277.const_0;
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
		if (enum277_1 != Enum277.const_0)
		{
			writer.WriteAttributeString("evt", Class2600.smethod_1(enum277_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("delay", string_0);
		}
		if (class2605_0 != null)
		{
			switch (class2605_0.Name)
			{
			case "rtn":
				((Class2307)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "tn":
				((Class2308)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			case "tgtEl":
				((Class2306)class2605_0.Object).vmethod_4("p", writer, class2605_0.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		if (class2605_0 != null)
		{
			throw new Exception("Trigger already is initialized.");
		}
		switch (elementName)
		{
		case "rtn":
			class2605_0 = new Class2605("rtn", new Class2307());
			break;
		case "tn":
			class2605_0 = new Class2605("tn", new Class2308());
			break;
		case "tgtEl":
			class2605_0 = new Class2605("tgtEl", new Class2306());
			break;
		default:
			throw new Exception("Wrong element: " + elementName);
		}
		return class2605_0;
	}
}
