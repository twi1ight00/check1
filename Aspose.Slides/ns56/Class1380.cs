using System.Xml;

namespace ns56;

internal class Class1380 : Class1351
{
	public delegate Class1380 Delegate102();

	public delegate void Delegate103(Class1380 elementData);

	public delegate void Delegate104(Class1380 elementData);

	public const uint uint_0 = 0u;

	public const uint uint_1 = 0u;

	public const uint uint_2 = 0u;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private bool bool_2;

	private bool bool_3;

	public uint Id
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

	public uint Min
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

	public uint Max
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public bool Man
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

	public bool Pt
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
				case "pt":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "man":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "max":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "min":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "id":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1380(XmlReader reader)
		: base(reader)
	{
	}

	public Class1380()
	{
	}

	protected override void vmethod_1()
	{
		uint_3 = 0u;
		uint_4 = 0u;
		uint_5 = 0u;
		bool_2 = false;
		bool_3 = false;
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
		if (uint_3 != 0)
		{
			writer.WriteAttributeString("id", XmlConvert.ToString(uint_3));
		}
		if (uint_4 != 0)
		{
			writer.WriteAttributeString("min", XmlConvert.ToString(uint_4));
		}
		if (uint_5 != 0)
		{
			writer.WriteAttributeString("max", XmlConvert.ToString(uint_5));
		}
		if (bool_2)
		{
			writer.WriteAttributeString("man", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("pt", bool_3 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
