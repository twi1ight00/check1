using System;
using System.Xml;

namespace ns56;

internal class Class1811 : Class1351
{
	public delegate Class1811 Delegate1312();

	public delegate void Delegate1313(Class1811 elementData);

	public delegate void Delegate1314(Class1811 elementData);

	public const double double_0 = 0.0;

	public const bool bool_0 = true;

	private double double_1;

	private bool bool_1;

	public double Rad
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

	public bool Grow
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
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
				case "grow":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rad":
					double_1 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1811(XmlReader reader)
		: base(reader)
	{
	}

	public Class1811()
	{
	}

	protected override void vmethod_1()
	{
		double_1 = 0.0;
		bool_1 = true;
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
		if (double_1 != 0.0)
		{
			writer.WriteAttributeString("rad", XmlConvert.ToString((long)Math.Round(double_1 * 12700.0)));
		}
		if (!bool_1)
		{
			writer.WriteAttributeString("grow", bool_1 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
