using System.Xml;

namespace ns56;

internal class Class1772 : Class1351
{
	public delegate Class1772 Delegate1195();

	public delegate void Delegate1196(Class1772 elementData);

	public delegate void Delegate1197(Class1772 elementData);

	private uint uint_0;

	private double double_0;

	private uint uint_1;

	private double double_1;

	public uint Col
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public double ColOff
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

	public uint Row
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

	public double RowOff
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
				case "rowOff":
					reader.Read();
					double_1 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "row":
					reader.Read();
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "colOff":
					reader.Read();
					double_0 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "col":
					reader.Read();
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
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

	public Class1772(XmlReader reader)
		: base(reader)
	{
	}

	public Class1772()
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
		method_1("xdr", writer, "col", XmlConvert.ToString(uint_0));
		method_1("xdr", writer, "colOff", XmlConvert.ToString(double_0));
		method_1("xdr", writer, "row", XmlConvert.ToString(uint_1));
		method_1("xdr", writer, "rowOff", XmlConvert.ToString(double_1));
		writer.WriteEndElement();
	}
}
