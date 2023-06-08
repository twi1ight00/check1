using System.Xml;

namespace ns56;

internal class Class2336 : Class1351
{
	public delegate Class2336 Delegate2755();

	public delegate void Delegate2756(Class2336 elementData);

	public delegate void Delegate2757(Class2336 elementData);

	public const Enum373 enum373_0 = Enum373.const_0;

	public const int int_0 = 0;

	public const Enum372 enum372_0 = Enum372.const_0;

	private Enum373 enum373_1;

	private int int_1;

	private Enum372 enum372_1;

	public Enum373 Type
	{
		get
		{
			return enum373_1;
		}
		set
		{
			enum373_1 = value;
		}
	}

	public int Width
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public Enum372 Shadow
	{
		get
		{
			return enum372_1;
		}
		set
		{
			enum372_1 = value;
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
				case "shadow":
					enum372_1 = Class2508.smethod_0(reader.Value);
					break;
				case "width":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "type":
					enum373_1 = Class2509.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2336(XmlReader reader)
		: base(reader)
	{
	}

	public Class2336()
	{
	}

	protected override void vmethod_1()
	{
		enum373_1 = Enum373.const_0;
		int_1 = 0;
		enum372_1 = Enum372.const_0;
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
		if (enum373_1 != 0)
		{
			writer.WriteAttributeString("type", Class2509.smethod_1(enum373_1));
		}
		if (int_1 != 0)
		{
			writer.WriteAttributeString("width", XmlConvert.ToString(int_1));
		}
		if (enum372_1 != 0)
		{
			writer.WriteAttributeString("shadow", Class2508.smethod_1(enum372_1));
		}
		writer.WriteEndElement();
	}
}
