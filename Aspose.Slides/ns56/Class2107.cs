using System.Xml;

namespace ns56;

internal class Class2107 : Class1351
{
	public delegate Class2107 Delegate2045();

	public delegate void Delegate2046(Class2107 elementData);

	public delegate void Delegate2047(Class2107 elementData);

	private Enum322 enum322_0;

	public Enum322 Val
	{
		get
		{
			return enum322_0;
		}
		set
		{
			enum322_0 = value;
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
				enum322_0 = Class2450.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2107(XmlReader reader)
		: base(reader)
	{
	}

	public Class2107()
	{
	}

	protected override void vmethod_1()
	{
		enum322_0 = Enum322.const_0;
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
		writer.WriteAttributeString("val", Class2450.smethod_1(enum322_0));
		writer.WriteEndElement();
	}
}
