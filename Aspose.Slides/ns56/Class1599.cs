using System.Xml;

namespace ns56;

internal class Class1599 : Class1351
{
	public delegate Class1599 Delegate676();

	public delegate void Delegate677(Class1599 elementData);

	public delegate void Delegate678(Class1599 elementData);

	public const Enum221 enum221_0 = Enum221.const_0;

	public const bool bool_0 = false;

	private string string_0;

	private Enum201 enum201_0;

	private string string_1;

	private Enum221 enum221_1;

	private bool bool_1;

	private uint uint_0;

	private string string_2;

	public static readonly Enum201 enum201_1 = Class2368.smethod_0("DVASPECT_CONTENT");

	public string ProgId
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

	public Enum201 DvAspect
	{
		get
		{
			return enum201_0;
		}
		set
		{
			enum201_0 = value;
		}
	}

	public string Link
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

	public Enum221 OleUpdate
	{
		get
		{
			return enum221_1;
		}
		set
		{
			enum221_1 = value;
		}
	}

	public bool AutoLoad
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

	public uint ShapeId
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

	public string R_Id
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
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
				case "progId":
					string_0 = reader.Value;
					break;
				case "dvAspect":
					enum201_0 = Class2368.smethod_0(reader.Value);
					break;
				case "link":
					string_1 = reader.Value;
					break;
				case "oleUpdate":
					enum221_1 = Class2388.smethod_0(reader.Value);
					break;
				case "autoLoad":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "shapeId":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "r:id":
					string_2 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1599(XmlReader reader)
		: base(reader)
	{
	}

	public Class1599()
	{
	}

	protected override void vmethod_1()
	{
		enum201_0 = enum201_1;
		enum221_1 = Enum221.const_0;
		bool_1 = false;
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
			writer.WriteAttributeString("progId", string_0);
		}
		if (enum201_0 != enum201_1)
		{
			writer.WriteAttributeString("dvAspect", Class2368.smethod_1(enum201_0));
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("link", string_1);
		}
		if (enum221_1 != 0)
		{
			writer.WriteAttributeString("oleUpdate", Class2388.smethod_1(enum221_1));
		}
		if (bool_1)
		{
			writer.WriteAttributeString("autoLoad", bool_1 ? "1" : "0");
		}
		writer.WriteAttributeString("shapeId", XmlConvert.ToString(uint_0));
		if (string_2 != null)
		{
			writer.WriteAttributeString("r:id", string_2);
		}
		writer.WriteEndElement();
	}
}
