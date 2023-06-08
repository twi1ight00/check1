using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal class Class2115 : Class1351
{
	public delegate Class2115 Delegate2072();

	public delegate void Delegate2074(Class2115 elementData);

	public delegate void Delegate2073(Class2115 elementData);

	private ChartShapeType chartShapeType_0;

	public static readonly ChartShapeType chartShapeType_1 = Class2554.smethod_0("box");

	public ChartShapeType Val
	{
		get
		{
			return chartShapeType_0;
		}
		set
		{
			chartShapeType_0 = value;
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
				chartShapeType_0 = Class2554.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2115(XmlReader reader)
		: base(reader)
	{
	}

	public Class2115()
	{
	}

	protected override void vmethod_1()
	{
		chartShapeType_0 = chartShapeType_1;
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
		if (chartShapeType_0 != chartShapeType_1)
		{
			writer.WriteAttributeString("val", Class2554.smethod_1(chartShapeType_0));
		}
		writer.WriteEndElement();
	}
}
