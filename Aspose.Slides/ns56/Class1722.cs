using System.Xml;

namespace ns56;

internal class Class1722 : Class1351
{
	public delegate Class1722 Delegate1045();

	public delegate void Delegate1046(Class1722 elementData);

	public delegate void Delegate1047(Class1722 elementData);

	public const uint uint_0 = 0u;

	private Enum203 enum203_0;

	private uint uint_1;

	public static readonly Enum203 enum203_1 = Class2370.smethod_0("general");

	public Enum203 Type
	{
		get
		{
			return enum203_0;
		}
		set
		{
			enum203_0 = value;
		}
	}

	public uint Position
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
				case "position":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "type":
					enum203_0 = Class2370.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1722(XmlReader reader)
		: base(reader)
	{
	}

	public Class1722()
	{
	}

	protected override void vmethod_1()
	{
		enum203_0 = enum203_1;
		uint_1 = 0u;
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
		if (enum203_0 != enum203_1)
		{
			writer.WriteAttributeString("type", Class2370.smethod_1(enum203_0));
		}
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("position", XmlConvert.ToString(uint_1));
		}
		writer.WriteEndElement();
	}
}
