using System.Xml;

namespace ns56;

internal class Class1619 : Class1351
{
	public delegate void Delegate738(Class1619 elementData);

	public delegate Class1619 Delegate736();

	public delegate void Delegate737(Class1619 elementData);

	private uint uint_0;

	private Enum229 enum229_0;

	private Enum228 enum228_0;

	public static readonly Enum229 enum229_1 = Class2396.smethod_0("fullwidthKatakana");

	public static readonly Enum228 enum228_1 = Class2395.smethod_0("left");

	public uint FontId
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

	public Enum229 Type
	{
		get
		{
			return enum229_0;
		}
		set
		{
			enum229_0 = value;
		}
	}

	public Enum228 Alignment
	{
		get
		{
			return enum228_0;
		}
		set
		{
			enum228_0 = value;
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
				case "alignment":
					enum228_0 = Class2395.smethod_0(reader.Value);
					break;
				case "type":
					enum229_0 = Class2396.smethod_0(reader.Value);
					break;
				case "fontId":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1619(XmlReader reader)
		: base(reader)
	{
	}

	public Class1619()
	{
	}

	protected override void vmethod_1()
	{
		enum229_0 = enum229_1;
		enum228_0 = enum228_1;
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
		writer.WriteAttributeString("fontId", XmlConvert.ToString(uint_0));
		if (enum229_0 != enum229_1)
		{
			writer.WriteAttributeString("type", Class2396.smethod_1(enum229_0));
		}
		if (enum228_0 != enum228_1)
		{
			writer.WriteAttributeString("alignment", Class2395.smethod_1(enum228_0));
		}
		writer.WriteEndElement();
	}
}
