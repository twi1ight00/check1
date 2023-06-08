using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal class Class2093 : Class1351
{
	public delegate Class2093 Delegate1997();

	public delegate void Delegate1999(Class2093 elementData);

	public delegate void Delegate1998(Class2093 elementData);

	private MarkerStyleType markerStyleType_0;

	public MarkerStyleType Val
	{
		get
		{
			return markerStyleType_0;
		}
		set
		{
			markerStyleType_0 = value;
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
				markerStyleType_0 = Class2539.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2093(XmlReader reader)
		: base(reader)
	{
	}

	public Class2093()
	{
	}

	protected override void vmethod_1()
	{
		markerStyleType_0 = MarkerStyleType.NotDefined;
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
		writer.WriteAttributeString("val", Class2539.smethod_1(markerStyleType_0));
		writer.WriteEndElement();
	}
}
