using System.Globalization;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1419 : Class1351
{
	public delegate Class1419 Delegate219();

	public delegate void Delegate221(Class1419 elementData);

	public delegate void Delegate220(Class1419 elementData);

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = uint.MaxValue;

	public const double double_0 = 0.0;

	private NullableBool nullableBool_1;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private double double_1;

	public NullableBool Auto
	{
		get
		{
			return nullableBool_1;
		}
		set
		{
			nullableBool_1 = value;
		}
	}

	public uint Indexed
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

	public uint Rgb
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

	public uint Theme
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

	public double Tint
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
				case "tint":
					double_1 = ToDouble(reader.Value);
					break;
				case "theme":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "rgb":
					uint_4 = uint.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				case "indexed":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "auto":
					nullableBool_1 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1419(XmlReader reader)
		: base(reader)
	{
	}

	public Class1419()
	{
	}

	protected override void vmethod_1()
	{
		nullableBool_1 = NullableBool.NotDefined;
		uint_3 = uint.MaxValue;
		uint_4 = uint.MaxValue;
		uint_5 = uint.MaxValue;
		double_1 = 0.0;
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
		if (nullableBool_1 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("auto", (nullableBool_1 == NullableBool.True) ? "1" : "0");
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("indexed", XmlConvert.ToString(uint_3));
		}
		if (uint_4 != uint.MaxValue)
		{
			writer.WriteAttributeString("rgb", (uint_4 & 0xFFFFFFFFu).ToString("X8"));
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("theme", XmlConvert.ToString(uint_5));
		}
		if (double_1 != 0.0)
		{
			writer.WriteAttributeString("tint", XmlConvert.ToString(double_1));
		}
		writer.WriteEndElement();
	}
}
