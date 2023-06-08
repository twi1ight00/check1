using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1638 : Class1351
{
	public delegate Class1638 Delegate793();

	public delegate void Delegate795(Class1638 elementData);

	public delegate void Delegate794(Class1638 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const NullableBool nullableBool_3 = NullableBool.NotDefined;

	public const NullableBool nullableBool_4 = NullableBool.NotDefined;

	private string string_0;

	private NullableBool nullableBool_5;

	private NullableBool nullableBool_6;

	private NullableBool nullableBool_7;

	private NullableBool nullableBool_8;

	private NullableBool nullableBool_9;

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

	public NullableBool ShowRowHeaders
	{
		get
		{
			return nullableBool_5;
		}
		set
		{
			nullableBool_5 = value;
		}
	}

	public NullableBool ShowColHeaders
	{
		get
		{
			return nullableBool_6;
		}
		set
		{
			nullableBool_6 = value;
		}
	}

	public NullableBool ShowRowStripes
	{
		get
		{
			return nullableBool_7;
		}
		set
		{
			nullableBool_7 = value;
		}
	}

	public NullableBool ShowColStripes
	{
		get
		{
			return nullableBool_8;
		}
		set
		{
			nullableBool_8 = value;
		}
	}

	public NullableBool ShowLastColumn
	{
		get
		{
			return nullableBool_9;
		}
		set
		{
			nullableBool_9 = value;
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
				case "showRowHeaders":
					nullableBool_5 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "showColHeaders":
					nullableBool_6 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "showRowStripes":
					nullableBool_7 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "showColStripes":
					nullableBool_8 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "showLastColumn":
					nullableBool_9 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1638(XmlReader reader)
		: base(reader)
	{
	}

	public Class1638()
	{
	}

	protected override void vmethod_1()
	{
		nullableBool_5 = NullableBool.NotDefined;
		nullableBool_6 = NullableBool.NotDefined;
		nullableBool_7 = NullableBool.NotDefined;
		nullableBool_8 = NullableBool.NotDefined;
		nullableBool_9 = NullableBool.NotDefined;
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
		if (nullableBool_5 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("showRowHeaders", (nullableBool_5 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_6 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("showColHeaders", (nullableBool_6 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_7 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("showRowStripes", (nullableBool_7 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_8 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("showColStripes", (nullableBool_8 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_9 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("showLastColumn", (nullableBool_9 == NullableBool.True) ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
