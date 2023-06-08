using System.Xml;

namespace ns56;

internal class Class1557 : Class1351
{
	public delegate Class1557 Delegate550();

	public delegate void Delegate551(Class1557 elementData);

	public delegate void Delegate552(Class1557 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const uint uint_0 = uint.MaxValue;

	private string string_0;

	private bool bool_2;

	private bool bool_3;

	private string string_1;

	private uint uint_1;

	public string R
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

	public bool Deleted
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

	public bool Undone
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

	public string Val
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

	public uint NumFmtId
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
				case "numFmtId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "val":
					string_1 = reader.Value;
					break;
				case "undone":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "deleted":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "r":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1557(XmlReader reader)
		: base(reader)
	{
	}

	public Class1557()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		bool_3 = false;
		uint_1 = uint.MaxValue;
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
		writer.WriteAttributeString("r", string_0);
		if (bool_2)
		{
			writer.WriteAttributeString("deleted", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("undone", bool_3 ? "1" : "0");
		}
		writer.WriteAttributeString("val", string_1);
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("numFmtId", XmlConvert.ToString(uint_1));
		}
		writer.WriteEndElement();
	}
}
