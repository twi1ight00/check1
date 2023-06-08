using System.Xml;

namespace ns56;

internal class Class2100 : Class1351
{
	public delegate Class2100 Delegate2019();

	public delegate void Delegate2020(Class2100 elementData);

	public delegate void Delegate2021(Class2100 elementData);

	private Enum320 enum320_0;

	public Enum320 Val
	{
		get
		{
			return enum320_0;
		}
		set
		{
			enum320_0 = value;
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
				enum320_0 = Class2448.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2100(XmlReader reader)
		: base(reader)
	{
	}

	public Class2100()
	{
	}

	protected override void vmethod_1()
	{
		enum320_0 = Class2448.smethod_0("pie");
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
		writer.WriteAttributeString("val", Class2448.smethod_1(enum320_0));
		writer.WriteEndElement();
	}
}
