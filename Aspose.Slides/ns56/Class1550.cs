using System.Xml;

namespace ns56;

internal class Class1550 : Class1351
{
	public delegate Class1550 Delegate529();

	public delegate void Delegate530(Class1550 elementData);

	public delegate void Delegate531(Class1550 elementData);

	public const uint uint_0 = uint.MaxValue;

	private Enum215 enum215_0;

	private uint uint_1;

	public Enum215 IconSet
	{
		get
		{
			return enum215_0;
		}
		set
		{
			enum215_0 = value;
		}
	}

	public uint IconId
	{
		get
		{
			return uint_1;
		}
		set
		{
			uint_1 = value;
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
				case "iconId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "iconSet":
					enum215_0 = Class2382.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1550(XmlReader reader)
		: base(reader)
	{
	}

	public Class1550()
	{
	}

	protected override void vmethod_1()
	{
		enum215_0 = Enum215.const_0;
		uint_1 = uint.MaxValue;
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
		writer.WriteAttributeString("iconSet", Class2382.smethod_1(enum215_0));
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("iconId", XmlConvert.ToString(uint_1));
		}
		writer.WriteEndElement();
	}
}
