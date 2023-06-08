using System.Xml;

namespace ns56;

internal class Class1415 : Class1351
{
	public delegate Class1415 Delegate207();

	public delegate void Delegate208(Class1415 elementData);

	public delegate void Delegate209(Class1415 elementData);

	public const double double_0 = double.NaN;

	public const uint uint_0 = 0u;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const byte byte_0 = 0;

	public const bool bool_4 = false;

	private uint uint_1;

	private uint uint_2;

	private double double_1;

	private uint uint_3;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private byte byte_1;

	private bool bool_9;

	public uint Min
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

	public uint Max
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

	public double Width
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public uint Style
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

	public bool Hidden
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

	public bool BestFit
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

	public bool CustomWidth
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

	public bool Phonetic
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

	public byte OutlineLevel
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public bool Collapsed
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
				case "min":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "max":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "width":
					double_1 = ToDouble(reader.Value);
					break;
				case "style":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "hidden":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "bestFit":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "customWidth":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "phonetic":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "outlineLevel":
					byte_1 = XmlConvert.ToByte(reader.Value);
					break;
				case "collapsed":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1415(XmlReader reader)
		: base(reader)
	{
	}

	public Class1415()
	{
	}

	protected override void vmethod_1()
	{
		double_1 = double.NaN;
		uint_3 = 0u;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
		byte_1 = 0;
		bool_9 = false;
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
		writer.WriteAttributeString("min", XmlConvert.ToString(uint_1));
		writer.WriteAttributeString("max", XmlConvert.ToString(uint_2));
		if (!double.IsNaN(double_1))
		{
			writer.WriteAttributeString("width", XmlConvert.ToString(double_1));
		}
		if (uint_3 != 0)
		{
			writer.WriteAttributeString("style", XmlConvert.ToString(uint_3));
		}
		if (bool_5)
		{
			writer.WriteAttributeString("hidden", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("bestFit", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("customWidth", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("phonetic", bool_8 ? "1" : "0");
		}
		if (byte_1 != 0)
		{
			writer.WriteAttributeString("outlineLevel", XmlConvert.ToString(byte_1));
		}
		if (bool_9)
		{
			writer.WriteAttributeString("collapsed", bool_9 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
