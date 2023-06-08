using System.Xml;

namespace ns56;

internal class Class2102 : Class1351
{
	public delegate Class2102 Delegate2025();

	public delegate void Delegate2026(Class2102 elementData);

	public delegate void Delegate2027(Class2102 elementData);

	private Enum321 enum321_0;

	public static readonly Enum321 enum321_1 = Class2449.smethod_0("minMax");

	public Enum321 Val
	{
		get
		{
			return enum321_0;
		}
		set
		{
			enum321_0 = value;
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
				enum321_0 = Class2449.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2102(XmlReader reader)
		: base(reader)
	{
	}

	public Class2102()
	{
	}

	protected override void vmethod_1()
	{
		enum321_0 = enum321_1;
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
		if (enum321_0 != enum321_1)
		{
			writer.WriteAttributeString("val", Class2449.smethod_1(enum321_0));
		}
		writer.WriteEndElement();
	}
}
