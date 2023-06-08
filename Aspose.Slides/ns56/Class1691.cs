using System.Xml;

namespace ns56;

internal class Class1691 : Class1351
{
	public delegate void Delegate954(Class1691 elementData);

	public delegate Class1691 Delegate952();

	public delegate void Delegate953(Class1691 elementData);

	public const uint uint_0 = 8u;

	public const double double_0 = double.NaN;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const byte byte_0 = 0;

	public const byte byte_1 = 0;

	private uint uint_1;

	private double double_1;

	private double double_2;

	private bool bool_4;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private byte byte_2;

	private byte byte_3;

	public uint BaseColWidth
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

	public double DefaultColWidth
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

	public double DefaultRowHeight
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public bool CustomHeight
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

	public bool ZeroHeight
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

	public bool ThickTop
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

	public bool ThickBottom
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

	public byte OutlineLevelRow
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	public byte OutlineLevelCol
	{
		get
		{
			return byte_3;
		}
		set
		{
			byte_3 = value;
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
				case "baseColWidth":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "defaultColWidth":
					double_1 = ToDouble(reader.Value);
					break;
				case "defaultRowHeight":
					double_2 = ToDouble(reader.Value);
					break;
				case "customHeight":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "zeroHeight":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "thickTop":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "thickBottom":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "outlineLevelRow":
					byte_2 = XmlConvert.ToByte(reader.Value);
					break;
				case "outlineLevelCol":
					byte_3 = XmlConvert.ToByte(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1691(XmlReader reader)
		: base(reader)
	{
	}

	public Class1691()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 8u;
		double_1 = double.NaN;
		double_2 = double.NaN;
		bool_4 = false;
		bool_5 = false;
		bool_6 = false;
		bool_7 = false;
		byte_2 = 0;
		byte_3 = 0;
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
		if (uint_1 != 8)
		{
			writer.WriteAttributeString("baseColWidth", XmlConvert.ToString(uint_1));
		}
		if (!double.IsNaN(double_1))
		{
			writer.WriteAttributeString("defaultColWidth", XmlConvert.ToString(double_1));
		}
		writer.WriteAttributeString("defaultRowHeight", XmlConvert.ToString(double_2));
		if (bool_4)
		{
			writer.WriteAttributeString("customHeight", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("zeroHeight", bool_5 ? "1" : "0");
		}
		if (bool_6)
		{
			writer.WriteAttributeString("thickTop", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("thickBottom", bool_7 ? "1" : "0");
		}
		if (byte_2 != 0)
		{
			writer.WriteAttributeString("outlineLevelRow", XmlConvert.ToString(byte_2));
		}
		if (byte_3 != 0)
		{
			writer.WriteAttributeString("outlineLevelCol", XmlConvert.ToString(byte_3));
		}
		writer.WriteEndElement();
	}
}
