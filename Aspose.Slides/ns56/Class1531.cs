using System.Xml;

namespace ns56;

internal class Class1531 : Class1351
{
	public delegate Class1531 Delegate472();

	public delegate void Delegate473(Class1531 elementData);

	public delegate void Delegate474(Class1531 elementData);

	private double double_0;

	public double Val
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "val")
			{
				double_0 = ToDouble(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1531(XmlReader reader)
		: base(reader)
	{
	}

	public Class1531()
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
		writer.WriteAttributeString("val", XmlConvert.ToString(double_0));
		writer.WriteEndElement();
	}
}
