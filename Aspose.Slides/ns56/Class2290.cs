using System.Xml;

namespace ns56;

internal class Class2290 : Class1351
{
	public delegate Class2290 Delegate2617();

	public delegate void Delegate2618(Class2290 elementData);

	public delegate void Delegate2619(Class2290 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = true;

	private string string_0;

	private uint uint_0;

	private bool bool_2;

	private Enum358 enum358_0;

	private bool bool_3;

	public static readonly Enum358 enum358_1 = Class2494.smethod_0("allAtOnce");

	public string Spid
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

	public uint GrpId
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

	public bool UiExpand
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

	public Enum358 Bld
	{
		get
		{
			return enum358_0;
		}
		set
		{
			enum358_0 = value;
		}
	}

	public bool AnimBg
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
				case "animBg":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "bld":
					enum358_0 = Class2494.smethod_0(reader.Value);
					break;
				case "uiExpand":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "grpId":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "spid":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2290(XmlReader reader)
		: base(reader)
	{
	}

	public Class2290()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		enum358_0 = enum358_1;
		bool_3 = true;
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
		writer.WriteAttributeString("spid", string_0);
		writer.WriteAttributeString("grpId", XmlConvert.ToString(uint_0));
		if (bool_2)
		{
			writer.WriteAttributeString("uiExpand", bool_2 ? "1" : "0");
		}
		if (enum358_0 != enum358_1)
		{
			writer.WriteAttributeString("bld", Class2494.smethod_1(enum358_0));
		}
		if (!bool_3)
		{
			writer.WriteAttributeString("animBg", bool_3 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
