using System;
using System.Xml;

namespace ns56;

internal class Class1906 : Class1351
{
	public delegate Class1906 Delegate1585();

	public delegate void Delegate1587(Class1906 elementData);

	public delegate void Delegate1586(Class1906 elementData);

	private double double_0;

	private double double_1;

	public double Cx
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

	public double Cy
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
				case "cy":
					double_1 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "cx":
					double_0 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1906(XmlReader reader)
		: base(reader)
	{
	}

	public Class1906()
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
		writer.WriteAttributeString("cx", XmlConvert.ToString((long)Math.Round(double_0 * 12700.0)));
		writer.WriteAttributeString("cy", XmlConvert.ToString((long)Math.Round(double_1 * 12700.0)));
		writer.WriteEndElement();
	}
}
