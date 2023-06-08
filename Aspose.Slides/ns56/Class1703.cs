using System.Xml;

namespace ns56;

internal class Class1703 : Class1351
{
	public delegate Class1703 Delegate988();

	public delegate void Delegate989(Class1703 elementData);

	public delegate void Delegate990(Class1703 elementData);

	private string string_0;

	private string string_1;

	private string string_2;

	public string NamespaceUri
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

	public string Name
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

	public string Url
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
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
				case "url":
					string_2 = reader.Value;
					break;
				case "name":
					string_1 = reader.Value;
					break;
				case "namespaceUri":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1703(XmlReader reader)
		: base(reader)
	{
	}

	public Class1703()
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
		if (string_0 != null)
		{
			writer.WriteAttributeString("namespaceUri", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("name", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("url", string_2);
		}
		writer.WriteEndElement();
	}
}
