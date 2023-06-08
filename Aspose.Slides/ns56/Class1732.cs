using System.Xml;

namespace ns56;

internal class Class1732 : Class1351
{
	public delegate Class1732 Delegate1075();

	public delegate void Delegate1076(Class1732 elementData);

	public delegate void Delegate1077(Class1732 elementData);

	private Enum255 enum255_0;

	public Enum255 Val
	{
		get
		{
			return enum255_0;
		}
		set
		{
			enum255_0 = value;
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
				enum255_0 = Class2422.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1732(XmlReader reader)
		: base(reader)
	{
	}

	public Class1732()
	{
	}

	protected override void vmethod_1()
	{
		enum255_0 = Enum255.const_0;
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
		writer.WriteAttributeString("val", Class2422.smethod_1(enum255_0));
		writer.WriteEndElement();
	}
}
