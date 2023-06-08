using System.Xml;

namespace ns56;

internal class Class1607 : Class1351
{
	public delegate void Delegate702(Class1607 elementData);

	public delegate Class1607 Delegate700();

	public delegate void Delegate701(Class1607 elementData);

	private double double_0;

	private double double_1;

	private double double_2;

	private double double_3;

	private double double_4;

	private double double_5;

	public double Left
	{
		get
		{
			return double_0;
		}
		set
		{
			double_0 = value;
		}
	}

	public double Right
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

	public double Top
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

	public double Bottom
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

	public double Header
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public double Footer
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
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
				case "left":
					double_0 = ToDouble(reader.Value);
					break;
				case "right":
					double_1 = ToDouble(reader.Value);
					break;
				case "top":
					double_2 = ToDouble(reader.Value);
					break;
				case "bottom":
					double_3 = ToDouble(reader.Value);
					break;
				case "header":
					double_4 = ToDouble(reader.Value);
					break;
				case "footer":
					double_5 = ToDouble(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1607(XmlReader reader)
		: base(reader)
	{
	}

	public Class1607()
	{
	}

	protected override void vmethod_1()
	{
		double_0 = double.NaN;
		double_1 = double.NaN;
		double_2 = double.NaN;
		double_3 = double.NaN;
		double_4 = double.NaN;
		double_5 = double.NaN;
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
		writer.WriteAttributeString("left", XmlConvert.ToString(double_0));
		writer.WriteAttributeString("right", XmlConvert.ToString(double_1));
		writer.WriteAttributeString("top", XmlConvert.ToString(double_2));
		writer.WriteAttributeString("bottom", XmlConvert.ToString(double_3));
		writer.WriteAttributeString("header", XmlConvert.ToString(double_4));
		writer.WriteAttributeString("footer", XmlConvert.ToString(double_5));
		writer.WriteEndElement();
	}
}
