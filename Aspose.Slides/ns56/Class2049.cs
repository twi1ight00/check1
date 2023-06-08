using System.Xml;

namespace ns56;

internal class Class2049 : Class1351
{
	public delegate Class2049 Delegate1867();

	public delegate void Delegate1868(Class2049 elementData);

	public delegate void Delegate1869(Class2049 elementData);

	private Enum315 enum315_0;

	public Enum315 Val
	{
		get
		{
			return enum315_0;
		}
		set
		{
			enum315_0 = value;
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
				enum315_0 = Class2443.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2049(XmlReader reader)
		: base(reader)
	{
	}

	public Class2049()
	{
	}

	protected override void vmethod_1()
	{
		enum315_0 = Class2443.smethod_0("col");
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
		writer.WriteAttributeString("val", Class2443.smethod_1(enum315_0));
		writer.WriteEndElement();
	}
}
