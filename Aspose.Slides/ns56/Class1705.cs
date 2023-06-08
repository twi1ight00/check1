using System.Xml;

namespace ns56;

internal class Class1705 : Class1351
{
	public delegate Class1705 Delegate994();

	public delegate void Delegate995(Class1705 elementData);

	public delegate void Delegate996(Class1705 elementData);

	public const bool bool_0 = false;

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	private bool bool_1;

	private Enum242 enum242_0;

	private string string_0;

	private string string_1;

	private uint uint_2;

	private Enum215 enum215_0;

	private uint uint_3;

	public static readonly Enum242 enum242_1 = Class2409.smethod_0("value");

	public static readonly Enum215 enum215_1 = Class2382.smethod_0("3Arrows");

	public bool Descending
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

	public Enum242 SortBy
	{
		get
		{
			return enum242_0;
		}
		set
		{
			enum242_0 = value;
		}
	}

	public string Ref
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

	public string CustomList
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public uint DxfId
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

	public Enum215 IconSet
	{
		get
		{
			return enum215_0;
		}
		set
		{
			enum215_0 = value;
		}
	}

	public uint IconId
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
				case "descending":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sortBy":
					enum242_0 = Class2409.smethod_0(reader.Value);
					break;
				case "ref":
					string_0 = reader.Value;
					break;
				case "customList":
					string_1 = reader.Value;
					break;
				case "dxfId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "iconSet":
					enum215_0 = Class2382.smethod_0(reader.Value);
					break;
				case "iconId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1705(XmlReader reader)
		: base(reader)
	{
	}

	public Class1705()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		enum242_0 = enum242_1;
		uint_2 = uint.MaxValue;
		enum215_0 = enum215_1;
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
		if (bool_1)
		{
			writer.WriteAttributeString("descending", bool_1 ? "1" : "0");
		}
		if (enum242_0 != enum242_1)
		{
			writer.WriteAttributeString("sortBy", Class2409.smethod_1(enum242_0));
		}
		writer.WriteAttributeString("ref", string_0);
		if (string_1 != null)
		{
			writer.WriteAttributeString("customList", string_1);
		}
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("dxfId", XmlConvert.ToString(uint_2));
		}
		if (enum215_0 != enum215_1)
		{
			writer.WriteAttributeString("iconSet", Class2382.smethod_1(enum215_0));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("iconId", XmlConvert.ToString(uint_3));
		}
		writer.WriteEndElement();
	}
}
