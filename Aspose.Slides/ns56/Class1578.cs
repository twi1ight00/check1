using System.Xml;

namespace ns56;

internal class Class1578 : Class1351
{
	public delegate Class1578 Delegate613();

	public delegate void Delegate614(Class1578 elementData);

	public delegate void Delegate615(Class1578 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = uint.MaxValue;

	public const uint uint_3 = uint.MaxValue;

	private string string_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private uint uint_4;

	private uint uint_5;

	private uint uint_6;

	private uint uint_7;

	private uint uint_8;

	public string Name
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

	public bool ShowCell
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

	public bool ShowTip
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool ShowAsCaption
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public uint NameLen
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

	public uint PPos
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

	public uint PLen
	{
		get
		{
			return uint_6;
		}
		set
		{
			uint_6 = value;
		}
	}

	public uint Level
	{
		get
		{
			return uint_7;
		}
		set
		{
			uint_7 = value;
		}
	}

	public uint Field
	{
		get
		{
			return uint_8;
		}
		set
		{
			uint_8 = value;
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
				case "name":
					string_0 = reader.Value;
					break;
				case "showCell":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showTip":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showAsCaption":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "nameLen":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "pPos":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "pLen":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "level":
					uint_7 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "field":
					uint_8 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1578(XmlReader reader)
		: base(reader)
	{
	}

	public Class1578()
	{
	}

	protected override void vmethod_1()
	{
		bool_3 = false;
		bool_4 = false;
		bool_5 = false;
		uint_4 = uint.MaxValue;
		uint_5 = uint.MaxValue;
		uint_6 = uint.MaxValue;
		uint_7 = uint.MaxValue;
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
		if (string_0 != null)
		{
			writer.WriteAttributeString("name", string_0);
		}
		if (bool_3)
		{
			writer.WriteAttributeString("showCell", bool_3 ? "1" : "0");
		}
		if (bool_4)
		{
			writer.WriteAttributeString("showTip", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("showAsCaption", bool_5 ? "1" : "0");
		}
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("nameLen", XmlConvert.ToString(uint_4));
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("pPos", XmlConvert.ToString(uint_5));
		}
		if (uint_6 != uint.MaxValue)
		{
			writer.WriteAttributeString("pLen", XmlConvert.ToString(uint_6));
		}
		if (uint_7 != uint.MaxValue)
		{
			writer.WriteAttributeString("level", XmlConvert.ToString(uint_7));
		}
		writer.WriteAttributeString("field", XmlConvert.ToString(uint_8));
		writer.WriteEndElement();
	}
}
