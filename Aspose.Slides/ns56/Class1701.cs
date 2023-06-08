using System.Xml;

namespace ns56;

internal class Class1701 : Class1351
{
	public delegate void Delegate984(Class1701 elementData);

	public delegate Class1701 Delegate982();

	public delegate void Delegate983(Class1701 elementData);

	public const bool bool_0 = false;

	private bool bool_1;

	private Enum241 enum241_0;

	public static readonly Enum241 enum241_1 = Class2408.smethod_0("all");

	public bool Embed
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

	public Enum241 Show
	{
		get
		{
			return enum241_0;
		}
		set
		{
			enum241_0 = value;
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
				_ = reader.LocalName;
				reader.Skip();
				flag = true;
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
				case "show":
					enum241_0 = Class2408.smethod_0(reader.Value);
					break;
				case "embed":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1701(XmlReader reader)
		: base(reader)
	{
	}

	public Class1701()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		enum241_0 = enum241_1;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("embed", bool_1 ? "1" : "0");
		}
		if (enum241_0 != enum241_1)
		{
			writer.WriteAttributeString("show", Class2408.smethod_1(enum241_0));
		}
		writer.WriteEndElement();
	}
}
