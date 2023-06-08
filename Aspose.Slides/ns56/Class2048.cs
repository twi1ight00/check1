using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal class Class2048 : Class1351
{
	public delegate Class2048 Delegate1862();

	public delegate void Delegate1863(Class2048 elementData);

	public delegate void Delegate1864(Class2048 elementData);

	private AxisPositionType axisPositionType_0;

	public AxisPositionType Val
	{
		get
		{
			return axisPositionType_0;
		}
		set
		{
			axisPositionType_0 = value;
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
				axisPositionType_0 = Class2515.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2048(XmlReader reader)
		: base(reader)
	{
	}

	public Class2048()
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
		writer.WriteAttributeString("val", Class2515.smethod_1(axisPositionType_0));
		writer.WriteEndElement();
	}
}
