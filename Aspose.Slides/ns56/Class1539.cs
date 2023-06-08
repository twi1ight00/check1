using System.Xml;

namespace ns56;

internal class Class1539 : Class1351
{
	public delegate Class1539 Delegate496();

	public delegate void Delegate497(Class1539 elementData);

	public delegate void Delegate498(Class1539 elementData);

	private double double_0;

	private Class1419 class1419_0;

	public double Position
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

	public Class1419 Color => class1419_0;

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "color")
				{
					class1419_0 = new Class1419(reader);
					continue;
				}
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "position")
			{
				double_0 = ToDouble(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1539(XmlReader reader)
		: base(reader)
	{
	}

	public Class1539()
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
		class1419_0 = new Class1419();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("position", XmlConvert.ToString(double_0));
		class1419_0.vmethod_4("ssml", writer, "color");
		writer.WriteEndElement();
	}
}
