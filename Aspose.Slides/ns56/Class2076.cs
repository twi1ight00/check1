using System.Xml;

namespace ns56;

internal class Class2076 : Class1351
{
	public delegate Class2076 Delegate1943();

	public delegate void Delegate1945(Class2076 elementData);

	public delegate void Delegate1944(Class2076 elementData);

	public const ushort ushort_0 = 150;

	private ushort ushort_1;

	public ushort Val
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
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
				ushort_1 = XmlConvert.ToUInt16(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2076(XmlReader reader)
		: base(reader)
	{
	}

	public Class2076()
	{
	}

	protected override void vmethod_1()
	{
		ushort_1 = 150;
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
		if (ushort_1 != 150)
		{
			writer.WriteAttributeString("val", XmlConvert.ToString(ushort_1));
		}
		writer.WriteEndElement();
	}
}
