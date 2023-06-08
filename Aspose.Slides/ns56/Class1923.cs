using System;
using System.Xml;

namespace ns56;

internal class Class1923 : Class1351
{
	public delegate Class1923 Delegate1636();

	public delegate void Delegate1638(Class1923 elementData);

	public delegate void Delegate1637(Class1923 elementData);

	private double double_0;

	public double Rad
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "rad")
			{
				double_0 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
			}
		}
		reader.MoveToElement();
	}

	public Class1923(XmlReader reader)
		: base(reader)
	{
	}

	public Class1923()
	{
	}

	protected override void vmethod_1()
	{
		double_0 = double.NaN;
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
		writer.WriteAttributeString("rad", XmlConvert.ToString((long)Math.Round(double_0 * 12700.0)));
		writer.WriteEndElement();
	}
}
