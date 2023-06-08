using System.Xml;
using Aspose.Slides.Charts;

namespace ns56;

internal class Class2127 : Class1351
{
	public delegate Class2127 Delegate2112();

	public delegate void Delegate2114(Class2127 elementData);

	public delegate void Delegate2113(Class2127 elementData);

	private TimeUnitType timeUnitType_0;

	public static readonly TimeUnitType timeUnitType_1 = Class2578.smethod_0("days");

	public TimeUnitType Val
	{
		get
		{
			return timeUnitType_0;
		}
		set
		{
			timeUnitType_0 = value;
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
				timeUnitType_0 = Class2578.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2127(XmlReader reader)
		: base(reader)
	{
	}

	public Class2127()
	{
	}

	protected override void vmethod_1()
	{
		timeUnitType_0 = timeUnitType_1;
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
		if (timeUnitType_0 != timeUnitType_1)
		{
			writer.WriteAttributeString("val", Class2578.smethod_1(timeUnitType_0));
		}
		writer.WriteEndElement();
	}
}
