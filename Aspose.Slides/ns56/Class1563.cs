using System.Xml;

namespace ns56;

internal class Class1563 : Class1351
{
	public delegate Class1563 Delegate568();

	public delegate void Delegate569(Class1563 elementData);

	public delegate void Delegate570(Class1563 elementData);

	public const uint uint_0 = 0u;

	public const uint uint_1 = 0u;

	private string string_0;

	private uint uint_2;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private uint uint_6;

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

	public uint FirstHeaderRow
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

	public uint FirstDataRow
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

	public uint FirstDataCol
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

	public uint RowPageCount
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

	public uint ColPageCount
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
				case "ref":
					string_0 = reader.Value;
					break;
				case "firstHeaderRow":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "firstDataRow":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "firstDataCol":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "rowPageCount":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "colPageCount":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1563(XmlReader reader)
		: base(reader)
	{
	}

	public Class1563()
	{
	}

	protected override void vmethod_1()
	{
		uint_5 = 0u;
		uint_6 = 0u;
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
		writer.WriteAttributeString("ref", string_0);
		writer.WriteAttributeString("firstHeaderRow", XmlConvert.ToString(uint_2));
		writer.WriteAttributeString("firstDataRow", XmlConvert.ToString(uint_3));
		writer.WriteAttributeString("firstDataCol", XmlConvert.ToString(uint_4));
		if (uint_5 != 0)
		{
			writer.WriteAttributeString("rowPageCount", XmlConvert.ToString(uint_5));
		}
		if (uint_6 != 0)
		{
			writer.WriteAttributeString("colPageCount", XmlConvert.ToString(uint_6));
		}
		writer.WriteEndElement();
	}
}
