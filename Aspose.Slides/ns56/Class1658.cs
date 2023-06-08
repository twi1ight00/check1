using System.Xml;

namespace ns56;

internal class Class1658 : Class1351
{
	public delegate Class1658 Delegate853();

	public delegate void Delegate854(Class1658 elementData);

	public delegate void Delegate855(Class1658 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const uint uint_0 = uint.MaxValue;

	private uint uint_1;

	private bool bool_2;

	private bool bool_3;

	private uint uint_2;

	public uint RId
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

	public bool Ua
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool Ra
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public uint SheetId
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
				case "sheetId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ra":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ua":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1658(XmlReader reader)
		: base(reader)
	{
	}

	public Class1658()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		bool_3 = false;
		uint_2 = uint.MaxValue;
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
		writer.WriteAttributeString("rId", XmlConvert.ToString(uint_1));
		if (bool_2)
		{
			writer.WriteAttributeString("ua", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("ra", bool_3 ? "1" : "0");
		}
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("sheetId", XmlConvert.ToString(uint_2));
		}
		writer.WriteEndElement();
	}
}
