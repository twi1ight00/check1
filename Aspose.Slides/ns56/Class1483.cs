using System.Xml;

namespace ns56;

internal class Class1483 : Class1351
{
	public delegate Class1483 Delegate326();

	public delegate void Delegate327(Class1483 elementData);

	public delegate void Delegate328(Class1483 elementData);

	public const ushort ushort_0 = 0;

	public const ushort ushort_1 = 0;

	public const ushort ushort_2 = 0;

	public const ushort ushort_3 = 0;

	public const ushort ushort_4 = 0;

	private ushort ushort_5;

	private ushort ushort_6;

	private ushort ushort_7;

	private ushort ushort_8;

	private ushort ushort_9;

	private ushort ushort_10;

	private Enum199 enum199_0;

	public ushort Year
	{
		get
		{
			return ushort_5;
		}
		set
		{
			ushort_5 = value;
		}
	}

	public ushort Month
	{
		get
		{
			return ushort_6;
		}
		set
		{
			ushort_6 = value;
		}
	}

	public ushort Day
	{
		get
		{
			return ushort_7;
		}
		set
		{
			ushort_7 = value;
		}
	}

	public ushort Hour
	{
		get
		{
			return ushort_8;
		}
		set
		{
			ushort_8 = value;
		}
	}

	public ushort Minute
	{
		get
		{
			return ushort_9;
		}
		set
		{
			ushort_9 = value;
		}
	}

	public ushort Second
	{
		get
		{
			return ushort_10;
		}
		set
		{
			ushort_10 = value;
		}
	}

	public Enum199 DateTimeGrouping
	{
		get
		{
			return enum199_0;
		}
		set
		{
			enum199_0 = value;
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
				case "year":
					ushort_5 = XmlConvert.ToUInt16(reader.Value);
					break;
				case "month":
					ushort_6 = XmlConvert.ToUInt16(reader.Value);
					break;
				case "day":
					ushort_7 = XmlConvert.ToUInt16(reader.Value);
					break;
				case "hour":
					ushort_8 = XmlConvert.ToUInt16(reader.Value);
					break;
				case "minute":
					ushort_9 = XmlConvert.ToUInt16(reader.Value);
					break;
				case "second":
					ushort_10 = XmlConvert.ToUInt16(reader.Value);
					break;
				case "dateTimeGrouping":
					enum199_0 = Class2366.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1483(XmlReader reader)
		: base(reader)
	{
	}

	public Class1483()
	{
	}

	protected override void vmethod_1()
	{
		ushort_6 = 0;
		ushort_7 = 0;
		ushort_8 = 0;
		ushort_9 = 0;
		ushort_10 = 0;
		enum199_0 = Enum199.const_0;
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
		writer.WriteAttributeString("year", XmlConvert.ToString(ushort_5));
		if (ushort_6 != 0)
		{
			writer.WriteAttributeString("month", XmlConvert.ToString(ushort_6));
		}
		if (ushort_7 != 0)
		{
			writer.WriteAttributeString("day", XmlConvert.ToString(ushort_7));
		}
		if (ushort_8 != 0)
		{
			writer.WriteAttributeString("hour", XmlConvert.ToString(ushort_8));
		}
		if (ushort_9 != 0)
		{
			writer.WriteAttributeString("minute", XmlConvert.ToString(ushort_9));
		}
		if (ushort_10 != 0)
		{
			writer.WriteAttributeString("second", XmlConvert.ToString(ushort_10));
		}
		writer.WriteAttributeString("dateTimeGrouping", Class2366.smethod_1(enum199_0));
		writer.WriteEndElement();
	}
}
