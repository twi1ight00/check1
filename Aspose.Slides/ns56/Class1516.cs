using System;
using System.Xml;

namespace ns56;

internal class Class1516 : Class1351
{
	public delegate Class1516 Delegate427();

	public delegate void Delegate429(Class1516 elementData);

	public delegate void Delegate428(Class1516 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public Class1649.Delegate826 delegate826_0;

	public Class1649.Delegate828 delegate828_0;

	public Class1496.Delegate365 delegate365_0;

	public Class1496.Delegate367 delegate367_0;

	public Class1540.Delegate499 delegate499_0;

	public Class1540.Delegate501 delegate501_0;

	private uint uint_2;

	private uint uint_3;

	private Class1649 class1649_0;

	private Class1496 class1496_0;

	private Class1540 class1540_0;

	public uint Par
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public uint Base
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public Class1649 RangePr => class1649_0;

	public Class1496 DiscretePr => class1496_0;

	public Class1540 GroupItems => class1540_0;

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
				switch (reader.LocalName)
				{
				case "groupItems":
					class1540_0 = new Class1540(reader);
					break;
				case "discretePr":
					class1496_0 = new Class1496(reader);
					break;
				case "rangePr":
					class1649_0 = new Class1649(reader);
					break;
				default:
					reader.Skip();
					flag = true;
					break;
				}
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
				case "base":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "par":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1516(XmlReader reader)
		: base(reader)
	{
	}

	public Class1516()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = uint.MaxValue;
		uint_3 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
		delegate826_0 = method_3;
		delegate828_0 = method_4;
		delegate365_0 = method_5;
		delegate367_0 = method_6;
		delegate499_0 = method_7;
		delegate501_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("par", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("base", XmlConvert.ToString(uint_3));
		}
		if (class1649_0 != null)
		{
			class1649_0.vmethod_4("ssml", writer, "rangePr");
		}
		if (class1496_0 != null)
		{
			class1496_0.vmethod_4("ssml", writer, "discretePr");
		}
		if (class1540_0 != null)
		{
			class1540_0.vmethod_4("ssml", writer, "groupItems");
		}
		writer.WriteEndElement();
	}

	private Class1649 method_3()
	{
		if (class1649_0 != null)
		{
			throw new Exception("Only one <rangePr> element can be added.");
		}
		class1649_0 = new Class1649();
		return class1649_0;
	}

	private void method_4(Class1649 _rangePr)
	{
		class1649_0 = _rangePr;
	}

	private Class1496 method_5()
	{
		if (class1496_0 != null)
		{
			throw new Exception("Only one <discretePr> element can be added.");
		}
		class1496_0 = new Class1496();
		return class1496_0;
	}

	private void method_6(Class1496 _discretePr)
	{
		class1496_0 = _discretePr;
	}

	private Class1540 method_7()
	{
		if (class1540_0 != null)
		{
			throw new Exception("Only one <groupItems> element can be added.");
		}
		class1540_0 = new Class1540();
		return class1540_0;
	}

	private void method_8(Class1540 _groupItems)
	{
		class1540_0 = _groupItems;
	}
}
