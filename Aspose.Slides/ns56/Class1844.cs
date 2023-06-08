using System;
using System.Xml;

namespace ns56;

internal class Class1844 : Class1351
{
	public delegate Class1844 Delegate1411();

	public delegate void Delegate1412(Class1844 elementData);

	public delegate void Delegate1413(Class1844 elementData);

	public const double double_0 = 0.0;

	private double double_1;

	public double Z
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "z")
			{
				double_1 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
			}
		}
		reader.MoveToElement();
	}

	public Class1844(XmlReader reader)
		: base(reader)
	{
	}

	public Class1844()
	{
	}

	protected override void vmethod_1()
	{
		double_1 = 0.0;
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
			writer.WriteAttributeString("z", XmlConvert.ToString((long)Math.Round(double_1 * 12700.0)));
		}
		writer.WriteEndElement();
	}
}
