using System.Xml;

namespace ns56;

internal class Class1355 : Class1351
{
	public delegate Class1355 Delegate27();

	public delegate void Delegate28(Class1355 elementData);

	public delegate void Delegate29(Class1355 elementData);

	private byte byte_0;

	public byte Val
	{
		get
		{
			return byte_0;
		}
		set
		{
			byte_0 = value;
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
				byte_0 = XmlConvert.ToByte(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1355(XmlReader reader)
		: base(reader)
	{
	}

	public Class1355()
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
		writer.WriteStartElement("c14", elementName, "http://schemas.microsoft.com/office/drawing/2007/8/2/chart");
		writer.WriteAttributeString("val", XmlConvert.ToString(byte_0));
		writer.WriteEndElement();
	}
}
