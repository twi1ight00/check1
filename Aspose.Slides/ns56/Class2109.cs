using System.Xml;

namespace ns56;

internal class Class2109 : Class1351
{
	public delegate Class2109 Delegate2051();

	public delegate void Delegate2052(Class2109 elementData);

	public delegate void Delegate2053(Class2109 elementData);

	public const sbyte sbyte_0 = 0;

	private sbyte sbyte_1;

	public sbyte Val
	{
		get
		{
			return sbyte_1;
		}
		set
		{
			sbyte_1 = value;
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
				sbyte_1 = XmlConvert.ToSByte(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2109(XmlReader reader)
		: base(reader)
	{
	}

	public Class2109()
	{
	}

	protected override void vmethod_1()
	{
		sbyte_1 = 0;
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
		if (sbyte_1 != 0)
		{
			writer.WriteAttributeString("val", XmlConvert.ToString(sbyte_1));
		}
		writer.WriteEndElement();
	}
}
