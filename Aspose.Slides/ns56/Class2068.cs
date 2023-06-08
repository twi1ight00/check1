using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal class Class2068 : Class1351
{
	public delegate Class2068 Delegate1917();

	public delegate void Delegate1919(Class2068 elementData);

	public delegate void Delegate1918(Class2068 elementData);

	private LegendDataLabelPosition legendDataLabelPosition_0;

	public LegendDataLabelPosition Val
	{
		get
		{
			return legendDataLabelPosition_0;
		}
		set
		{
			legendDataLabelPosition_0 = value;
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
				legendDataLabelPosition_0 = Class2528.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2068(XmlReader reader)
		: base(reader)
	{
	}

	public Class2068()
	{
	}

	protected override void vmethod_1()
	{
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
		writer.WriteAttributeString("val", Class2528.smethod_1(legendDataLabelPosition_0));
		writer.WriteEndElement();
	}
}
