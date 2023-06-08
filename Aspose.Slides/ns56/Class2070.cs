using System.Xml;

namespace ns56;

internal class Class2070 : Class1351
{
	public delegate Class2070 Delegate1923();

	public delegate void Delegate1925(Class2070 elementData);

	public delegate void Delegate1924(Class2070 elementData);

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

	public Class2070(XmlReader reader)
		: base(reader)
	{
	}

	public Class2070()
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
