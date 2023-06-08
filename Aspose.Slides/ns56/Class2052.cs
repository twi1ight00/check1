using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal class Class2052 : Class1351
{
	public delegate Class2052 Delegate1879();

	public delegate void Delegate1880(Class2052 elementData);

	public delegate void Delegate1881(Class2052 elementData);

	private DisplayUnitType displayUnitType_0;

	public static readonly DisplayUnitType displayUnitType_1 = Class2519.smethod_0("thousands");

	public DisplayUnitType Val
	{
		get
		{
			return displayUnitType_0;
		}
		set
		{
			displayUnitType_0 = value;
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
				displayUnitType_0 = Class2519.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2052(XmlReader reader)
		: base(reader)
	{
	}

	public Class2052()
	{
	}

	protected override void vmethod_1()
	{
		displayUnitType_0 = displayUnitType_1;
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
		if (displayUnitType_0 != displayUnitType_1)
		{
			writer.WriteAttributeString("val", Class2519.smethod_1(displayUnitType_0));
		}
		writer.WriteEndElement();
	}
}
