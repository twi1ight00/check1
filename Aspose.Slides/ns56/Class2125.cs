using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal class Class2125 : Class1351
{
	public delegate Class2125 Delegate2106();

	public delegate void Delegate2108(Class2125 elementData);

	public delegate void Delegate2107(Class2125 elementData);

	private TickLabelPositionType tickLabelPositionType_0;

	public static readonly TickLabelPositionType tickLabelPositionType_1 = Class2575.smethod_0("nextTo");

	public TickLabelPositionType Val
	{
		get
		{
			return tickLabelPositionType_0;
		}
		set
		{
			tickLabelPositionType_0 = value;
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
				tickLabelPositionType_0 = Class2575.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2125(XmlReader reader)
		: base(reader)
	{
	}

	public Class2125()
	{
	}

	protected override void vmethod_1()
	{
		tickLabelPositionType_0 = tickLabelPositionType_1;
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
		if (tickLabelPositionType_0 != tickLabelPositionType_1)
		{
			writer.WriteAttributeString("val", Class2575.smethod_1(tickLabelPositionType_0));
		}
		writer.WriteEndElement();
	}
}
