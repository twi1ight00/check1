using System.Xml;
using ns16;

namespace ns56;

internal class Class2083 : Class1351
{
	public delegate Class2083 Delegate1964();

	public delegate void Delegate1966(Class2083 elementData);

	public delegate void Delegate1965(Class2083 elementData);

	private Enum269 enum269_0;

	public Enum269 Val
	{
		get
		{
			return enum269_0;
		}
		set
		{
			enum269_0 = value;
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
				enum269_0 = Class2531.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2083(XmlReader reader)
		: base(reader)
	{
	}

	public Class2083()
	{
	}

	protected override void vmethod_1()
	{
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
		writer.WriteAttributeString("val", Class2531.smethod_1(enum269_0));
		writer.WriteEndElement();
	}
}
