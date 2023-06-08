using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1909 : Class1351
{
	public delegate Class1909 Delegate1594();

	public delegate void Delegate1595(Class1909 elementData);

	public delegate void Delegate1596(Class1909 elementData);

	public const LineDashStyle lineDashStyle_0 = LineDashStyle.NotDefined;

	private LineDashStyle lineDashStyle_1;

	public LineDashStyle Val
	{
		get
		{
			return lineDashStyle_1;
		}
		set
		{
			lineDashStyle_1 = value;
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
				lineDashStyle_1 = Class2548.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1909(XmlReader reader)
		: base(reader)
	{
	}

	public Class1909()
	{
	}

	protected override void vmethod_1()
	{
		lineDashStyle_1 = LineDashStyle.NotDefined;
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
		if (lineDashStyle_1 != LineDashStyle.NotDefined)
		{
			writer.WriteAttributeString("val", Class2548.smethod_1(lineDashStyle_1));
		}
		writer.WriteEndElement();
	}
}
