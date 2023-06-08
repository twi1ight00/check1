using System.Xml;

namespace ns56;

internal class Class1725 : Class1351
{
	public delegate Class1725 Delegate1054();

	public delegate void Delegate1055(Class1725 elementData);

	public delegate void Delegate1056(Class1725 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const double double_0 = double.NaN;

	private bool bool_2;

	private bool bool_3;

	private double double_1;

	private double double_2;

	public bool Top
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool Percent
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public double Val
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

	public double FilterVal
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
				case "filterVal":
					double_2 = ToDouble(reader.Value);
					break;
				case "val":
					double_1 = ToDouble(reader.Value);
					break;
				case "percent":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "top":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1725(XmlReader reader)
		: base(reader)
	{
	}

	public Class1725()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = true;
		bool_3 = false;
		double_1 = double.NaN;
		double_2 = double.NaN;
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
		if (!bool_2)
		{
			writer.WriteAttributeString("top", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("percent", bool_3 ? "1" : "0");
		}
		writer.WriteAttributeString("val", XmlConvert.ToString(double_1));
		if (!double.IsNaN(double_2))
		{
			writer.WriteAttributeString("filterVal", XmlConvert.ToString(double_2));
		}
		writer.WriteEndElement();
	}
}
