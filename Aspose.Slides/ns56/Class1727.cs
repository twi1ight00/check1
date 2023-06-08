using System.Xml;

namespace ns56;

internal class Class1727 : Class1351
{
	public delegate Class1727 Delegate1060();

	public delegate void Delegate1061(Class1727 elementData);

	public delegate void Delegate1062(Class1727 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	public uint Fld
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

	public uint Hier
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

	public uint Item
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
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
				case "item":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "hier":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "fld":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1727(XmlReader reader)
		: base(reader)
	{
	}

	public Class1727()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = uint.MaxValue;
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
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("fld", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("hier", XmlConvert.ToString(uint_3));
		}
		writer.WriteAttributeString("item", XmlConvert.ToString(uint_4));
		writer.WriteEndElement();
	}
}
