using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1670 : Class1351
{
	public delegate Class1670 Delegate889();

	public delegate void Delegate890(Class1670 elementData);

	public delegate void Delegate891(Class1670 elementData);

	public const uint uint_0 = uint.MaxValue;

	private uint uint_1;

	public uint Rgb
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "rgb")
			{
				uint_1 = uint.Parse(reader.Value, NumberStyles.HexNumber);
			}
		}
		reader.MoveToElement();
	}

	public Class1670(XmlReader reader)
		: base(reader)
	{
	}

	public Class1670()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
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
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("rgb", (uint_1 & 0xFFFFFFFFu).ToString("X8"));
		}
		writer.WriteEndElement();
	}
}
