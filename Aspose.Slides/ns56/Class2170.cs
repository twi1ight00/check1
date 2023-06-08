using System.Xml;

namespace ns56;

internal class Class2170 : Class1351
{
	public delegate Class2170 Delegate2242();

	public delegate void Delegate2243(Class2170 elementData);

	public delegate void Delegate2244(Class2170 elementData);

	private Enum335 enum335_0;

	public static readonly Enum335 enum335_1 = Class2466.smethod_0("std");

	public Enum335 Val
	{
		get
		{
			return enum335_0;
		}
		set
		{
			enum335_0 = value;
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
				enum335_0 = Class2466.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2170(XmlReader reader)
		: base(reader)
	{
	}

	public Class2170()
	{
	}

	protected override void vmethod_1()
	{
		enum335_0 = enum335_1;
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
		if (enum335_0 != enum335_1)
		{
			writer.WriteAttributeString("val", Class2466.smethod_1(enum335_0));
		}
		writer.WriteEndElement();
	}
}
