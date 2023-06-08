using System.Xml;

namespace ns56;

internal class Class2218 : Class1351
{
	public delegate Class2218 Delegate2390();

	public delegate void Delegate2391(Class2218 elementData);

	public delegate void Delegate2392(Class2218 elementData);

	private string string_0;

	private string string_1;

	public string Tocolor
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

	public string Fromcolor
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
				case "fromcolor":
					string_1 = reader.Value;
					break;
				case "tocolor":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2218(XmlReader reader)
		: base(reader)
	{
	}

	public Class2218()
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
		writer.WriteAttributeString("tocolor", string_0);
		writer.WriteAttributeString("fromcolor", string_1);
		writer.WriteEndElement();
	}
}
