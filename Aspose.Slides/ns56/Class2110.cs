using System.Xml;

namespace ns56;

internal class Class2110 : Class1351
{
	public delegate Class2110 Delegate2054();

	public delegate void Delegate2055(Class2110 elementData);

	public delegate void Delegate2056(Class2110 elementData);

	public const ushort ushort_0 = 0;

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

	public Class2110(XmlReader reader)
		: base(reader)
	{
	}

	public Class2110()
	{
	}

	protected override void vmethod_1()
	{
		ushort_1 = 0;
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
		if (ushort_1 != 0)
		{
			writer.WriteAttributeString("val", XmlConvert.ToString(ushort_1));
		}
		writer.WriteEndElement();
	}
}
