using System.Xml;

namespace ns56;

internal class Class2177 : Class1351
{
	public delegate Class2177 Delegate2263();

	public delegate void Delegate2264(Class2177 elementData);

	public delegate void Delegate2265(Class2177 elementData);

	private Enum304 enum304_0;

	private string string_0;

	public Enum304 Type
	{
		get
		{
			return enum304_0;
		}
		set
		{
			enum304_0 = value;
		}
	}

	public string Val
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "val":
					string_0 = reader.Value;
					break;
				case "type":
					enum304_0 = Class2468.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2177(XmlReader reader)
		: base(reader)
	{
	}

	public Class2177()
	{
	}

	protected override void vmethod_1()
	{
		enum304_0 = Enum304.const_0;
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
		writer.WriteAttributeString("type", Class2468.smethod_1(enum304_0));
		writer.WriteAttributeString("val", string_0);
		writer.WriteEndElement();
	}
}
