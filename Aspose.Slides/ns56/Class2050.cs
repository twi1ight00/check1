using System.Xml;

namespace ns56;

internal class Class2050 : Class1351
{
	public delegate Class2050 Delegate1870();

	public delegate void Delegate1872(Class2050 elementData);

	public delegate void Delegate1871(Class2050 elementData);

	private Enum316 enum316_0;

	public Enum316 Val
	{
		get
		{
			return enum316_0;
		}
		set
		{
			enum316_0 = value;
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
				enum316_0 = Class2444.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2050(XmlReader reader)
		: base(reader)
	{
	}

	public Class2050()
	{
	}

	protected override void vmethod_1()
	{
		enum316_0 = Class2444.smethod_0("clustered");
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
		writer.WriteAttributeString("val", Class2444.smethod_1(enum316_0));
		writer.WriteEndElement();
	}
}
