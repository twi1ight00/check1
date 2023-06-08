using System.Xml;

namespace ns56;

internal class Class1773 : Class1351
{
	public delegate Class1773 Delegate1198();

	public delegate void Delegate1199(Class1773 elementData);

	public delegate void Delegate1200(Class1773 elementData);

	private Enum265 enum265_0;

	public static readonly Enum265 enum265_1 = Class2435.smethod_0("percentage");

	public Enum265 Val
	{
		get
		{
			return enum265_0;
		}
		set
		{
			enum265_0 = value;
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
				enum265_0 = Class2435.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1773(XmlReader reader)
		: base(reader)
	{
	}

	public Class1773()
	{
	}

	protected override void vmethod_1()
	{
		enum265_0 = enum265_1;
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
		writer.WriteAttributeString("val", Class2435.smethod_1(enum265_0));
		writer.WriteEndElement();
	}
}
