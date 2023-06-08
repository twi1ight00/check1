using System.Xml;

namespace ns56;

internal class Class2003 : Class1351
{
	public delegate Class2003 Delegate1830();

	public delegate void Delegate1831(Class2003 elementData);

	public delegate void Delegate1832(Class2003 elementData);

	private double double_0;

	private double double_1;

	public double X
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

	public double Y
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
				switch (reader.LocalName)
				{
				case "y":
					reader.Read();
					double_1 = ToDouble(reader.Value);
					break;
				case "x":
					reader.Read();
					double_0 = ToDouble(reader.Value);
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
			}
		}
	}

	private void method_2(XmlReader reader)
	{
	}

	public Class2003(XmlReader reader)
		: base(reader)
	{
	}

	public Class2003()
	{
	}

	protected override void vmethod_1()
	{
		double_0 = double.NaN;
		double_1 = double.NaN;
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
		method_1("cdr", writer, "x", XmlConvert.ToString(double_0));
		method_1("cdr", writer, "y", XmlConvert.ToString(double_1));
		writer.WriteEndElement();
	}
}
