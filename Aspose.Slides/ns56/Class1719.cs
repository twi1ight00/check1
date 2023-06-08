using System.Xml;

namespace ns56;

internal class Class1719 : Class1351
{
	public delegate Class1719 Delegate1036();

	public delegate void Delegate1037(Class1719 elementData);

	public delegate void Delegate1038(Class1719 elementData);

	public const uint uint_0 = 1u;

	public const uint uint_1 = uint.MaxValue;

	private Enum246 enum246_0;

	private uint uint_2;

	private uint uint_3;

	public Enum246 Type
	{
		get
		{
			return enum246_0;
		}
		set
		{
			enum246_0 = value;
		}
	}

	public uint Size
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public uint DxfId
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
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
				case "dxfId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "size":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "type":
					enum246_0 = Class2413.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1719(XmlReader reader)
		: base(reader)
	{
	}

	public Class1719()
	{
	}

	protected override void vmethod_1()
	{
		enum246_0 = Enum246.const_0;
		uint_2 = 1u;
		uint_3 = uint.MaxValue;
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
		writer.WriteAttributeString("type", Class2413.smethod_1(enum246_0));
		if (uint_2 != 1)
		{
			writer.WriteAttributeString("size", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("dxfId", XmlConvert.ToString(uint_3));
		}
		writer.WriteEndElement();
	}
}
