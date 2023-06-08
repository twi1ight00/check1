using System.Xml;

namespace ns56;

internal class Class1580 : Class1351
{
	public delegate Class1580 Delegate619();

	public delegate void Delegate620(Class1580 elementData);

	public delegate void Delegate621(Class1580 elementData);

	private string string_0;

	public string Ref
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "ref")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1580(XmlReader reader)
		: base(reader)
	{
	}

	public Class1580()
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
		writer.WriteAttributeString("ref", string_0);
		writer.WriteEndElement();
	}
}