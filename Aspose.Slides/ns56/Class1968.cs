using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1968 : Class1351
{
	public delegate Class1968 Delegate1771();

	public delegate void Delegate1772(Class1968 elementData);

	public delegate void Delegate1773(Class1968 elementData);

	public const double double_0 = double.NaN;

	public const TabAlignment tabAlignment_0 = TabAlignment.Left;

	private double double_1;

	private TabAlignment tabAlignment_1;

	public double Pos
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

	public TabAlignment Algn
	{
		get
		{
			return tabAlignment_1;
		}
		set
		{
			tabAlignment_1 = value;
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
				case "algn":
					tabAlignment_1 = Class2571.smethod_0(reader.Value);
					break;
				case "pos":
					double_1 = (double)XmlConvert.ToInt64(reader.Value) / 12700.0;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1968(XmlReader reader)
		: base(reader)
	{
	}

	public Class1968()
	{
	}

	protected override void vmethod_1()
	{
		double_1 = double.NaN;
		tabAlignment_1 = TabAlignment.Left;
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
		if (!double.IsNaN(double_1))
		{
			writer.WriteAttributeString("pos", XmlConvert.ToString((long)Math.Round(double_1 * 12700.0)));
		}
		if (tabAlignment_1 != 0)
		{
			writer.WriteAttributeString("algn", Class2571.smethod_1(tabAlignment_1));
		}
		writer.WriteEndElement();
	}
}
