using System.Xml;

namespace ns56;

internal class Class2081 : Class1351
{
	public delegate void Delegate1960(Class2081 elementData);

	public delegate Class2081 Delegate1958();

	public delegate void Delegate1959(Class2081 elementData);

	private Enum318 enum318_0;

	public static readonly Enum318 enum318_1 = Class2446.smethod_0("factor");

	public Enum318 Val
	{
		get
		{
			return enum318_0;
		}
		set
		{
			enum318_0 = value;
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
				enum318_0 = Class2446.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2081(XmlReader reader)
		: base(reader)
	{
	}

	public Class2081()
	{
	}

	protected override void vmethod_1()
	{
		enum318_0 = enum318_1;
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
		if (enum318_0 != enum318_1)
		{
			writer.WriteAttributeString("val", Class2446.smethod_1(enum318_0));
		}
		writer.WriteEndElement();
	}
}
