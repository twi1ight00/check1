using System.Xml;
using ns57;

namespace ns56;

internal class Class2291 : Class1351
{
	public delegate Class2291 Delegate2620();

	public delegate void Delegate2621(Class2291 elementData);

	public delegate void Delegate2622(Class2291 elementData);

	public const uint uint_0 = 0u;

	private Enum295 enum295_0;

	private uint uint_1;

	public Enum295 Type
	{
		get
		{
			return enum295_0;
		}
		set
		{
			enum295_0 = value;
		}
	}

	public uint Lvl
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
				case "lvl":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "type":
					enum295_0 = Class2590.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class2291(XmlReader reader)
		: base(reader)
	{
	}

	public Class2291()
	{
	}

	protected override void vmethod_1()
	{
		enum295_0 = Enum295.const_0;
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
		writer.WriteAttributeString("type", Class2590.smethod_1(enum295_0));
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("lvl", XmlConvert.ToString(uint_1));
		}
		writer.WriteEndElement();
	}
}
