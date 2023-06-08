using System.Xml;

namespace ns56;

internal class Class2077 : Class1351
{
	public delegate Class2077 Delegate1946();

	public delegate void Delegate1948(Class2077 elementData);

	public delegate void Delegate1947(Class2077 elementData);

	private Enum317 enum317_0;

	public static readonly Enum317 enum317_1 = Class2445.smethod_0("standard");

	public Enum317 Val
	{
		get
		{
			return enum317_0;
		}
		set
		{
			enum317_0 = value;
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
				enum317_0 = Class2445.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2077(XmlReader reader)
		: base(reader)
	{
	}

	public Class2077()
	{
	}

	protected override void vmethod_1()
	{
		enum317_0 = enum317_1;
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
		if (enum317_0 != enum317_1)
		{
			writer.WriteAttributeString("val", Class2445.smethod_1(enum317_0));
		}
		writer.WriteEndElement();
	}
}
