using System.Xml;

namespace ns56;

internal class Class1500 : Class1351
{
	public delegate Class1500 Delegate377();

	public delegate void Delegate378(Class1500 elementData);

	public delegate void Delegate379(Class1500 elementData);

	public const double double_0 = double.NaN;

	public const double double_1 = double.NaN;

	private Enum202 enum202_0;

	private double double_2;

	private double double_3;

	public Enum202 Type
	{
		get
		{
			return enum202_0;
		}
		set
		{
			enum202_0 = value;
		}
	}

	public double Val
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

	public double MaxVal
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
				case "maxVal":
					double_3 = ToDouble(reader.Value);
					break;
				case "val":
					double_2 = ToDouble(reader.Value);
					break;
				case "type":
					enum202_0 = Class2369.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1500(XmlReader reader)
		: base(reader)
	{
	}

	public Class1500()
	{
	}

	protected override void vmethod_1()
	{
		enum202_0 = Enum202.const_0;
		double_2 = double.NaN;
		double_3 = double.NaN;
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
		writer.WriteAttributeString("type", Class2369.smethod_1(enum202_0));
		if (!double.IsNaN(double_2))
		{
			writer.WriteAttributeString("val", XmlConvert.ToString(double_2));
		}
		if (!double.IsNaN(double_3))
		{
			writer.WriteAttributeString("maxVal", XmlConvert.ToString(double_3));
		}
		writer.WriteEndElement();
	}
}
