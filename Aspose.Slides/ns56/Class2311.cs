using System.Xml;

namespace ns56;

internal class Class2311 : Class1351
{
	public delegate Class2311 Delegate2680();

	public delegate void Delegate2681(Class2311 elementData);

	public delegate void Delegate2682(Class2311 elementData);

	public const uint uint_0 = 4u;

	private uint uint_1;

	public uint Spokes
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "spokes")
			{
				uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2311(XmlReader reader)
		: base(reader)
	{
	}

	public Class2311()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 4u;
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
		if (uint_1 != 4)
		{
			writer.WriteAttributeString("spokes", XmlConvert.ToString(uint_1));
		}
		writer.WriteEndElement();
	}
}
