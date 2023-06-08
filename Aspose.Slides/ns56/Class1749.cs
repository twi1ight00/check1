using System.Xml;

namespace ns56;

internal class Class1749 : Class1351
{
	public delegate Class1749 Delegate1126();

	public delegate void Delegate1127(Class1749 elementData);

	public delegate void Delegate1128(Class1749 elementData);

	public const int int_0 = 0;

	private int int_1;

	public int V
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "v")
			{
				int_1 = XmlConvert.ToInt32(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1749(XmlReader reader)
		: base(reader)
	{
	}

	public Class1749()
	{
	}

	protected override void vmethod_1()
	{
		int_1 = 0;
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
		if (int_1 != 0)
		{
			writer.WriteAttributeString("v", XmlConvert.ToString(int_1));
		}
		writer.WriteEndElement();
	}
}
