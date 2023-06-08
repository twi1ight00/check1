using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1871 : Class1351
{
	public delegate Class1871 Delegate1492();

	public delegate void Delegate1493(Class1871 elementData);

	public delegate void Delegate1494(Class1871 elementData);

	public const LineArrowheadStyle lineArrowheadStyle_0 = LineArrowheadStyle.NotDefined;

	public const LineArrowheadWidth lineArrowheadWidth_0 = LineArrowheadWidth.NotDefined;

	public const LineArrowheadLength lineArrowheadLength_0 = LineArrowheadLength.NotDefined;

	private LineArrowheadStyle lineArrowheadStyle_1;

	private LineArrowheadWidth lineArrowheadWidth_1;

	private LineArrowheadLength lineArrowheadLength_1;

	public LineArrowheadStyle Type
	{
		get
		{
			return lineArrowheadStyle_1;
		}
		set
		{
			lineArrowheadStyle_1 = value;
		}
	}

	public LineArrowheadWidth W
	{
		get
		{
			return lineArrowheadWidth_1;
		}
		set
		{
			lineArrowheadWidth_1 = value;
		}
	}

	public LineArrowheadLength Len
	{
		get
		{
			return lineArrowheadLength_1;
		}
		set
		{
			lineArrowheadLength_1 = value;
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
				case "len":
					lineArrowheadLength_1 = Class2536.smethod_0(reader.Value);
					break;
				case "w":
					lineArrowheadWidth_1 = Class2538.smethod_0(reader.Value);
					break;
				case "type":
					lineArrowheadStyle_1 = Class2537.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1871(XmlReader reader)
		: base(reader)
	{
	}

	public Class1871()
	{
	}

	protected override void vmethod_1()
	{
		lineArrowheadStyle_1 = LineArrowheadStyle.NotDefined;
		lineArrowheadWidth_1 = LineArrowheadWidth.NotDefined;
		lineArrowheadLength_1 = LineArrowheadLength.NotDefined;
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
		if (lineArrowheadStyle_1 != LineArrowheadStyle.NotDefined)
		{
			writer.WriteAttributeString("type", Class2537.smethod_1(lineArrowheadStyle_1));
		}
		if (lineArrowheadWidth_1 != LineArrowheadWidth.NotDefined)
		{
			writer.WriteAttributeString("w", Class2538.smethod_1(lineArrowheadWidth_1));
		}
		if (lineArrowheadLength_1 != LineArrowheadLength.NotDefined)
		{
			writer.WriteAttributeString("len", Class2536.smethod_1(lineArrowheadLength_1));
		}
		writer.WriteEndElement();
	}
}
