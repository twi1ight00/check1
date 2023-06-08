using System.Xml;

namespace ns56;

internal class Class1558 : Class1351
{
	public delegate Class1558 Delegate553();

	public delegate void Delegate554(Class1558 elementData);

	public delegate void Delegate555(Class1558 elementData);

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

	public Class1558(XmlReader reader)
		: base(reader)
	{
	}

	public Class1558()
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
		writer.WriteAttributeString("val", XmlConvert.ToString(int_0));
		writer.WriteEndElement();
	}
}
