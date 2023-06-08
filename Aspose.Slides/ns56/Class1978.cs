using System;
using System.Xml;

namespace ns56;

internal class Class1978 : Class1351
{
	public delegate Class1978 Delegate1801();

	public delegate void Delegate1802(Class1978 elementData);

	public delegate void Delegate1803(Class1978 elementData);

	private double double_0;

	private double double_1;

	private double double_2;

	public double Dx
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

	public double Dy
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

	public double Dz
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
				case "dz":
					double_2 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "dy":
					double_1 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "dx":
					double_0 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1978(XmlReader reader)
		: base(reader)
	{
	}

	public Class1978()
	{
	}

	protected override void vmethod_1()
	{
		double_0 = double.NaN;
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
		writer.WriteAttributeString("dx", XmlConvert.ToString((long)Math.Round(double_0 * 12700.0)));
		writer.WriteAttributeString("dy", XmlConvert.ToString((long)Math.Round(double_1 * 12700.0)));
		writer.WriteAttributeString("dz", XmlConvert.ToString((long)Math.Round(double_2 * 12700.0)));
		writer.WriteEndElement();
	}
}
