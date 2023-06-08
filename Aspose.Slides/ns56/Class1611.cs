using System.Xml;

namespace ns56;

internal class Class1611 : Class1351
{
	public delegate Class1611 Delegate712();

	public delegate void Delegate714(Class1611 elementData);

	public delegate void Delegate713(Class1611 elementData);

	public const double double_0 = 0.0;

	public const double double_1 = 0.0;

	private double double_2;

	private double double_3;

	private string string_0;

	private Enum224 enum224_0;

	private Enum225 enum225_0;

	public static readonly Enum224 enum224_1 = Class2391.smethod_0("topLeft");

	public static readonly Enum225 enum225_1 = Class2392.smethod_0("split");

	public double XSplit
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

	public double YSplit
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public string TopLeftCell
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

	public Enum224 ActivePane
	{
		get
		{
			return enum224_0;
		}
		set
		{
			enum224_0 = value;
		}
	}

	public Enum225 State
	{
		get
		{
			return enum225_0;
		}
		set
		{
			enum225_0 = value;
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
				case "state":
					enum225_0 = Class2392.smethod_0(reader.Value);
					break;
				case "activePane":
					enum224_0 = Class2391.smethod_0(reader.Value);
					break;
				case "topLeftCell":
					string_0 = reader.Value;
					break;
				case "ySplit":
					double_3 = ToDouble(reader.Value);
					break;
				case "xSplit":
					double_2 = ToDouble(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1611(XmlReader reader)
		: base(reader)
	{
	}

	public Class1611()
	{
	}

	protected override void vmethod_1()
	{
		double_2 = 0.0;
		double_3 = 0.0;
		enum224_0 = enum224_1;
		enum225_0 = enum225_1;
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
		if (double_2 != 0.0)
		{
			writer.WriteAttributeString("xSplit", XmlConvert.ToString(double_2));
		}
		if (double_3 != 0.0)
		{
			writer.WriteAttributeString("ySplit", XmlConvert.ToString(double_3));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("topLeftCell", string_0);
		}
		if (enum224_0 != enum224_1)
		{
			writer.WriteAttributeString("activePane", Class2391.smethod_1(enum224_0));
		}
		if (enum225_0 != enum225_1)
		{
			writer.WriteAttributeString("state", Class2392.smethod_1(enum225_0));
		}
		writer.WriteEndElement();
	}
}
