using System.Xml;

namespace ns56;

internal class Class2078 : Class1351
{
	public delegate Class2078 Delegate1949();

	public delegate void Delegate1951(Class2078 elementData);

	public delegate void Delegate1950(Class2078 elementData);

	public const byte byte_0 = 10;

	private byte byte_1;

	public byte Val
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
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
				byte_1 = XmlConvert.ToByte(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2078(XmlReader reader)
		: base(reader)
	{
	}

	public Class2078()
	{
	}

	protected override void vmethod_1()
	{
		byte_1 = 10;
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
		if (byte_1 != 10)
		{
			writer.WriteAttributeString("val", XmlConvert.ToString(byte_1));
		}
		writer.WriteEndElement();
	}
}
