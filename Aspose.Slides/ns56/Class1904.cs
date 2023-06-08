using System;
using System.Xml;

namespace ns56;

internal class Class1904 : Class1351
{
	public delegate Class1904 Delegate1579();

	public delegate void Delegate1580(Class1904 elementData);

	public delegate void Delegate1581(Class1904 elementData);

	private double double_0;

	private double double_1;

	private double double_2;

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

	public double Z
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
				case "z":
					double_2 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "y":
					double_1 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				case "x":
					double_0 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1904(XmlReader reader)
		: base(reader)
	{
	}

	public Class1904()
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
		writer.WriteAttributeString("x", XmlConvert.ToString((long)Math.Round(double_0 * 12700.0)));
		writer.WriteAttributeString("y", XmlConvert.ToString((long)Math.Round(double_1 * 12700.0)));
		writer.WriteAttributeString("z", XmlConvert.ToString((long)Math.Round(double_2 * 12700.0)));
		writer.WriteEndElement();
	}
}
