using System.Xml;

namespace ns56;

internal class Class2308 : Class1351
{
	public delegate Class2308 Delegate2671();

	public delegate void Delegate2672(Class2308 elementData);

	public delegate void Delegate2673(Class2308 elementData);

	private int int_0;

	public int Val
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
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
				int_0 = XmlConvert.ToInt32(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class2308(XmlReader reader)
		: base(reader)
	{
	}

	public Class2308()
	{
	}

	protected override void vmethod_1()
	{
		int_0 = -1;
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
		writer.WriteAttributeString("val", XmlConvert.ToString(int_0));
		writer.WriteEndElement();
	}
}
