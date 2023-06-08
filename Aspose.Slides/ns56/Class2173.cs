using System.Xml;

namespace ns56;

internal class Class2173 : Class1351
{
	public delegate Class2173 Delegate2251();

	public delegate void Delegate2252(Class2173 elementData);

	public delegate void Delegate2253(Class2173 elementData);

	public const string string_0 = "";

	private string string_1;

	private string string_2;

	public string Lang
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

	public string Val
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
				case "val":
					string_2 = reader.Value;
					break;
				case "lang":
					string_1 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2173(XmlReader reader)
		: base(reader)
	{
	}

	public Class2173()
	{
	}

	protected override void vmethod_1()
	{
		string_1 = "";
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
		if (string_1 != "")
		{
			writer.WriteAttributeString("lang", string_1);
		}
		writer.WriteAttributeString("val", string_2);
		writer.WriteEndElement();
	}
}
