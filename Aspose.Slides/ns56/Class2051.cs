using System.Xml;

namespace ns56;

internal class Class2051 : Class1351
{
	public delegate Class2051 Delegate1875();

	public delegate void Delegate1877(Class2051 elementData);

	public delegate void Delegate1876(Class2051 elementData);

	public const uint uint_0 = 100u;

	private uint uint_1;

	public uint Val
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "val")
			{
				uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2051(XmlReader reader)
		: base(reader)
	{
	}

	public Class2051()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 100u;
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
		if (uint_1 != 100)
		{
			writer.WriteAttributeString("val", XmlConvert.ToString(uint_1));
		}
		writer.WriteEndElement();
	}
}
