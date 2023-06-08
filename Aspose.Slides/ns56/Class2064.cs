using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal class Class2064 : Class1351
{
	public delegate Class2064 Delegate1905();

	public delegate void Delegate1907(Class2064 elementData);

	public delegate void Delegate1906(Class2064 elementData);

	private DisplayBlanksAsType displayBlanksAsType_0;

	public static readonly DisplayBlanksAsType displayBlanksAsType_1 = Class2527.smethod_0("zero");

	public DisplayBlanksAsType Val
	{
		get
		{
			return displayBlanksAsType_0;
		}
		set
		{
			displayBlanksAsType_0 = value;
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
				displayBlanksAsType_0 = Class2527.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2064(XmlReader reader)
		: base(reader)
	{
	}

	public Class2064()
	{
	}

	protected override void vmethod_1()
	{
		displayBlanksAsType_0 = displayBlanksAsType_1;
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
		if (displayBlanksAsType_0 != displayBlanksAsType_1)
		{
			writer.WriteAttributeString("val", Class2527.smethod_1(displayBlanksAsType_0));
		}
		writer.WriteEndElement();
	}
}
