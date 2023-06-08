using System.Xml;

namespace ns56;

internal class Class1567 : Class1351
{
	public delegate Class1567 Delegate580();

	public delegate void Delegate581(Class1567 elementData);

	public delegate void Delegate582(Class1567 elementData);

	private uint uint_0;

	private uint uint_1;

	private Enum218 enum218_0;

	public uint N
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public uint Np
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

	public Enum218 P
	{
		get
		{
			return enum218_0;
		}
		set
		{
			enum218_0 = value;
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
				case "p":
					enum218_0 = Class2385.smethod_0(reader.Value);
					break;
				case "np":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "n":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1567(XmlReader reader)
		: base(reader)
	{
	}

	public Class1567()
	{
	}

	protected override void vmethod_1()
	{
		enum218_0 = Enum218.const_0;
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
		writer.WriteAttributeString("n", XmlConvert.ToString(uint_0));
		writer.WriteAttributeString("np", XmlConvert.ToString(uint_1));
		writer.WriteAttributeString("p", Class2385.smethod_1(enum218_0));
		writer.WriteEndElement();
	}
}
