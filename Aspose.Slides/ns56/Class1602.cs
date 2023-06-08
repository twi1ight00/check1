using System.Xml;

namespace ns56;

internal class Class1602 : Class1351
{
	public delegate Class1602 Delegate685();

	public delegate void Delegate686(Class1602 elementData);

	public delegate void Delegate687(Class1602 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = true;

	public const bool bool_2 = true;

	public const bool bool_3 = true;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	public bool ApplyStyles
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool SummaryBelow
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool SummaryRight
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public bool ShowOutlineSymbols
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
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
				case "showOutlineSymbols":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "summaryRight":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "summaryBelow":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "applyStyles":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1602(XmlReader reader)
		: base(reader)
	{
	}

	public Class1602()
	{
	}

	protected override void vmethod_1()
	{
		bool_4 = false;
		bool_5 = true;
		bool_6 = true;
		bool_7 = true;
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
		if (bool_4)
		{
			writer.WriteAttributeString("applyStyles", bool_4 ? "1" : "0");
		}
		if (!bool_5)
		{
			writer.WriteAttributeString("summaryBelow", bool_5 ? "1" : "0");
		}
		if (!bool_6)
		{
			writer.WriteAttributeString("summaryRight", bool_6 ? "1" : "0");
		}
		if (!bool_7)
		{
			writer.WriteAttributeString("showOutlineSymbols", bool_7 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
