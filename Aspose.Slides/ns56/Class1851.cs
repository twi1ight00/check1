using System.Xml;

namespace ns56;

internal class Class1851 : Class1351
{
	public delegate Class1851 Delegate1432();

	public delegate void Delegate1434(Class1851 elementData);

	public delegate void Delegate1433(Class1851 elementData);

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	public string L
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

	public string T
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

	public string R
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

	public string B
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
				case "b":
					string_3 = reader.Value;
					break;
				case "r":
					string_2 = reader.Value;
					break;
				case "t":
					string_1 = reader.Value;
					break;
				case "l":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1851(XmlReader reader)
		: base(reader)
	{
	}

	public Class1851()
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
		writer.WriteAttributeString("l", string_0);
		writer.WriteAttributeString("t", string_1);
		writer.WriteAttributeString("r", string_2);
		writer.WriteAttributeString("b", string_3);
		writer.WriteEndElement();
	}
}
