using System.Xml;

namespace ns56;

internal class Class1690 : Class1351
{
	public delegate Class1690 Delegate949();

	public delegate void Delegate950(Class1690 elementData);

	public delegate void Delegate951(Class1690 elementData);

	private string string_0;

	private uint uint_0;

	private Enum238 enum238_0;

	private string string_1;

	public static readonly Enum238 enum238_1 = Class2405.smethod_0("visible");

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

	public uint SheetId
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

	public Enum238 State
	{
		get
		{
			return enum238_0;
		}
		set
		{
			enum238_0 = value;
		}
	}

	public string R_Id
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
				case "r:id":
					string_1 = reader.Value;
					break;
				case "state":
					enum238_0 = Class2405.smethod_0(reader.Value);
					break;
				case "sheetId":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "name":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1690(XmlReader reader)
		: base(reader)
	{
	}

	public Class1690()
	{
	}

	protected override void vmethod_1()
	{
		enum238_0 = enum238_1;
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
		writer.WriteAttributeString("name", string_0);
		writer.WriteAttributeString("sheetId", XmlConvert.ToString(uint_0));
		if (enum238_0 != enum238_1)
		{
			writer.WriteAttributeString("state", Class2405.smethod_1(enum238_0));
		}
		writer.WriteAttributeString("r:id", string_1);
		writer.WriteEndElement();
	}
}
