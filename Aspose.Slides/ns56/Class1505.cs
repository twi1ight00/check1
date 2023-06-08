using System.Xml;

namespace ns56;

internal class Class1505 : Class1351
{
	public delegate Class1505 Delegate394();

	public delegate void Delegate395(Class1505 elementData);

	public delegate void Delegate396(Class1505 elementData);

	public const uint uint_0 = uint.MaxValue;

	private string string_0;

	private string string_1;

	private uint uint_1;

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

	public string RefersTo
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

	public uint SheetId
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
				case "sheetId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "refersTo":
					string_1 = reader.Value;
					break;
				case "name":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1505(XmlReader reader)
		: base(reader)
	{
	}

	public Class1505()
	{
	}

	protected override void vmethod_1()
	{
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
		writer.WriteAttributeString("name", string_0);
		if (string_1 != null)
		{
			writer.WriteAttributeString("refersTo", string_1);
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("sheetId", XmlConvert.ToString(uint_1));
		}
		writer.WriteEndElement();
	}
}
