using System.Xml;

namespace ns56;

internal class Class1529 : Class1351
{
	public delegate Class1529 Delegate466();

	public delegate void Delegate467(Class1529 elementData);

	public delegate void Delegate468(Class1529 elementData);

	private Enum207 enum207_0;

	public Enum207 Val
	{
		get
		{
			return enum207_0;
		}
		set
		{
			enum207_0 = value;
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
				enum207_0 = Class2374.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1529(XmlReader reader)
		: base(reader)
	{
	}

	public Class1529()
	{
	}

	protected override void vmethod_1()
	{
		enum207_0 = Enum207.const_0;
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
		writer.WriteAttributeString("val", Class2374.smethod_1(enum207_0));
		writer.WriteEndElement();
	}
}
