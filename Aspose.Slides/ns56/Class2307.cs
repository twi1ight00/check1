using System.Xml;

namespace ns56;

internal class Class2307 : Class1351
{
	public delegate Class2307 Delegate2668();

	public delegate void Delegate2669(Class2307 elementData);

	public delegate void Delegate2670(Class2307 elementData);

	private Enum182 enum182_0;

	public Enum182 Val
	{
		get
		{
			return enum182_0;
		}
		set
		{
			enum182_0 = value;
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
				enum182_0 = Class2348.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2307(XmlReader reader)
		: base(reader)
	{
	}

	public Class2307()
	{
	}

	protected override void vmethod_1()
	{
		enum182_0 = Enum182.const_0;
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
		writer.WriteAttributeString("val", Class2348.smethod_1(enum182_0));
		writer.WriteEndElement();
	}
}
