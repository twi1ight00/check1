using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1720 : Class1351
{
	public delegate void Delegate1041(Class1720 elementData);

	public delegate Class1720 Delegate1039();

	public delegate void Delegate1040(Class1720 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const NullableBool nullableBool_2 = NullableBool.NotDefined;

	public const NullableBool nullableBool_3 = NullableBool.NotDefined;

	private string string_0;

	private NullableBool nullableBool_4;

	private NullableBool nullableBool_5;

	private NullableBool nullableBool_6;

	private NullableBool nullableBool_7;

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

	public NullableBool ShowFirstColumn
	{
		get
		{
			return nullableBool_4;
		}
		set
		{
			nullableBool_4 = value;
		}
	}

	public NullableBool ShowLastColumn
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

	public NullableBool ShowRowStripes
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

	public NullableBool ShowColumnStripes
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
				case "showColumnStripes":
					nullableBool_7 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "showRowStripes":
					nullableBool_6 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "showLastColumn":
					nullableBool_5 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "showFirstColumn":
					nullableBool_4 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "name":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1720(XmlReader reader)
		: base(reader)
	{
	}

	public Class1720()
	{
	}

	protected override void vmethod_1()
	{
		nullableBool_4 = NullableBool.NotDefined;
		nullableBool_5 = NullableBool.NotDefined;
		nullableBool_6 = NullableBool.NotDefined;
		nullableBool_7 = NullableBool.NotDefined;
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
		if (nullableBool_4 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("showFirstColumn", (nullableBool_4 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_5 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("showLastColumn", (nullableBool_5 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_6 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("showRowStripes", (nullableBool_6 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_7 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("showColumnStripes", (nullableBool_7 == NullableBool.True) ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
