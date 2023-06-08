using System;
using System.Xml;

namespace ns56;

internal class Class1659 : Class1351
{
	public delegate Class1659 Delegate856();

	public delegate void Delegate857(Class1659 elementData);

	public delegate void Delegate858(Class1659 elementData);

	private Guid guid_0;

	private Enum235 enum235_0;

	public Guid Guid
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public Enum235 Action
	{
		get
		{
			return enum235_0;
		}
		set
		{
			enum235_0 = value;
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
				case "action":
					enum235_0 = Class2402.smethod_0(reader.Value);
					break;
				case "guid":
					guid_0 = new Guid(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1659(XmlReader reader)
		: base(reader)
	{
	}

	public Class1659()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
		enum235_0 = Enum235.const_0;
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
		writer.WriteAttributeString("guid", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		writer.WriteAttributeString("action", Class2402.smethod_1(enum235_0));
		writer.WriteEndElement();
	}
}
