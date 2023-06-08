using System.Xml;

namespace ns56;

internal class Class1398 : Class1351
{
	public delegate Class1398 Delegate156();

	public delegate void Delegate157(Class1398 elementData);

	public delegate void Delegate158(Class1398 elementData);

	private string string_0;

	private string string_1;

	public string Key
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

	public string Val
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "val":
					string_1 = reader.Value;
					break;
				case "key":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1398(XmlReader reader)
		: base(reader)
	{
	}

	public Class1398()
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
		writer.WriteAttributeString("key", string_0);
		writer.WriteAttributeString("val", string_1);
		writer.WriteEndElement();
	}
}
