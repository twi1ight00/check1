using System.Xml;

namespace ns56;

internal class Class2295 : Class1351
{
	public delegate Class2295 Delegate2632();

	public delegate void Delegate2633(Class2295 elementData);

	public delegate void Delegate2634(Class2295 elementData);

	private string string_0;

	public string Spid
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "spid")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class2295(XmlReader reader)
		: base(reader)
	{
	}

	public Class2295()
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
		writer.WriteAttributeString("spid", string_0);
		writer.WriteEndElement();
	}
}
