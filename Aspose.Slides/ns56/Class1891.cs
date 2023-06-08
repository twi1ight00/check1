using System.Xml;

namespace ns56;

internal class Class1891 : Class1351
{
	public delegate Class1891 Delegate1540();

	public delegate void Delegate1541(Class1891 elementData);

	public delegate void Delegate1542(Class1891 elementData);

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	public string WR
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

	public string HR
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

	public string StAng
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

	public string SwAng
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
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
				case "swAng":
					string_3 = reader.Value;
					break;
				case "stAng":
					string_2 = reader.Value;
					break;
				case "hR":
					string_1 = reader.Value;
					break;
				case "wR":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1891(XmlReader reader)
		: base(reader)
	{
	}

	public Class1891()
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
		writer.WriteAttributeString("wR", string_0);
		writer.WriteAttributeString("hR", string_1);
		writer.WriteAttributeString("stAng", string_2);
		writer.WriteAttributeString("swAng", string_3);
		writer.WriteEndElement();
	}
}
