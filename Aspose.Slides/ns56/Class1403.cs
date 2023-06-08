using System.Xml;

namespace ns56;

internal class Class1403 : Class1351
{
	public delegate Class1403 Delegate171();

	public delegate void Delegate172(Class1403 elementData);

	public delegate void Delegate173(Class1403 elementData);

	private string string_0;

	public string R
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "r")
			{
				string_0 = reader.Value;
			}
		}
		reader.MoveToElement();
	}

	public Class1403(XmlReader reader)
		: base(reader)
	{
	}

	public Class1403()
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
		writer.WriteAttributeString("r", string_0);
		writer.WriteEndElement();
	}
}