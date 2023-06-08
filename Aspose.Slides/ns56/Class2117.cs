using System.Xml;

namespace ns56;

internal class Class2117 : Class1351
{
	public delegate Class2117 Delegate2078();

	public delegate void Delegate2080(Class2117 elementData);

	public delegate void Delegate2079(Class2117 elementData);

	private ushort ushort_0;

	public ushort Val
	{
		get
		{
			return ushort_0;
		}
		set
		{
			ushort_0 = value;
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
				ushort_0 = XmlConvert.ToUInt16(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2117(XmlReader reader)
		: base(reader)
	{
	}

	public Class2117()
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
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("val", XmlConvert.ToString(ushort_0));
		writer.WriteEndElement();
	}
}
