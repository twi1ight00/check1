using System.Xml;

namespace ns56;

internal class Class2082 : Class1351
{
	public delegate Class2082 Delegate1961();

	public delegate void Delegate1962(Class2082 elementData);

	public delegate void Delegate1963(Class2082 elementData);

	private Enum319 enum319_0;

	public static readonly Enum319 enum319_1 = Class2447.smethod_0("outer");

	public Enum319 Val
	{
		get
		{
			return enum319_0;
		}
		set
		{
			enum319_0 = value;
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
				enum319_0 = Class2447.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2082(XmlReader reader)
		: base(reader)
	{
	}

	public Class2082()
	{
	}

	protected override void vmethod_1()
	{
		enum319_0 = enum319_1;
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
		if (enum319_0 != enum319_1)
		{
			writer.WriteAttributeString("val", Class2447.smethod_1(enum319_0));
		}
		writer.WriteEndElement();
	}
}
