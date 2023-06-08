using System.Xml;

namespace ns56;

internal class Class1357 : Class1351
{
	public delegate Class1357 Delegate33();

	public delegate void Delegate34(Class1357 elementData);

	public delegate void Delegate35(Class1357 elementData);

	private Enum264 enum264_0;

	public Enum264 Val
	{
		get
		{
			return enum264_0;
		}
		set
		{
			enum264_0 = value;
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
				enum264_0 = Class2434.smethod_0(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1357(XmlReader reader)
		: base(reader)
	{
	}

	public Class1357()
	{
	}

	protected override void vmethod_1()
	{
		enum264_0 = Enum264.const_0;
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
		writer.WriteAttributeString("val", Class2434.smethod_1(enum264_0));
		writer.WriteEndElement();
	}
}
