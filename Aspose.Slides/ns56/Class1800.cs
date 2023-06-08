using System.Xml;

namespace ns56;

internal class Class1800 : Class1351
{
	public delegate Class1800 Delegate1279();

	public delegate void Delegate1280(Class1800 elementData);

	public delegate void Delegate1281(Class1800 elementData);

	public const uint uint_0 = 0u;

	private byte byte_0;

	private uint uint_1;

	public byte Track
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
		}
	}

	public uint Time
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
				case "time":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "track":
					byte_0 = XmlConvert.ToByte(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1800(XmlReader reader)
		: base(reader)
	{
	}

	public Class1800()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 0u;
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
		writer.WriteAttributeString("track", XmlConvert.ToString(byte_0));
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("time", XmlConvert.ToString(uint_1));
		}
		writer.WriteEndElement();
	}
}
