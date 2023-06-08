using System.Xml;

namespace ns56;

internal class Class2277 : Class1351
{
	public delegate Class2277 Delegate2578();

	public delegate void Delegate2579(Class2277 elementData);

	public delegate void Delegate2580(Class2277 elementData);

	public const bool bool_0 = false;

	private string string_0;

	private uint uint_0;

	private bool bool_1;

	private Enum357 enum357_0;

	public static readonly Enum357 enum357_1 = Class2493.smethod_0("whole");

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
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Enum357 Bld
	{
		get
		{
			return enum357_0;
		}
		set
		{
			enum357_0 = value;
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
				case "bld":
					enum357_0 = Class2493.smethod_0(reader.Value);
					break;
				case "uiExpand":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
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

	public Class2277(XmlReader reader)
		: base(reader)
	{
	}

	public Class2277()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		enum357_0 = enum357_1;
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
		if (bool_1)
		{
			writer.WriteAttributeString("uiExpand", bool_1 ? "1" : "0");
		}
		if (enum357_0 != enum357_1)
		{
			writer.WriteAttributeString("bld", Class2493.smethod_1(enum357_0));
		}
		writer.WriteEndElement();
	}
}
