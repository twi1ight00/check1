using System.Xml;

namespace ns56;

internal class Class1639 : Class1351
{
	public delegate void Delegate798(Class1639 elementData);

	public delegate Class1639 Delegate796();

	public delegate void Delegate797(Class1639 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = true;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	public bool HorizontalCentered
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

	public bool VerticalCentered
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

	public bool Headings
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

	public bool GridLines
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public bool GridLinesSet
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
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
				case "gridLinesSet":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "gridLines":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "headings":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "verticalCentered":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "horizontalCentered":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1639(XmlReader reader)
		: base(reader)
	{
	}

	public Class1639()
	{
	}

	protected override void vmethod_1()
	{
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
		bool_9 = true;
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
		if (bool_5)
		{
			writer.WriteAttributeString("horizontalCentered", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("verticalCentered", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("headings", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("gridLines", bool_8 ? "1" : "0");
		}
		if (!bool_9)
		{
			writer.WriteAttributeString("gridLinesSet", bool_9 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
