using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1570 : Class1351
{
	public delegate Class1570 Delegate589();

	public delegate void Delegate590(Class1570 elementData);

	public delegate void Delegate591(Class1570 elementData);

	public const uint uint_0 = 0u;

	public Class1586.Delegate637 delegate637_0;

	public Class1586.Delegate638 delegate638_0;

	private uint uint_1;

	private uint uint_2;

	private Enum219 enum219_0;

	private List<Class1586> list_0;

	public static readonly Enum219 enum219_1 = Class2386.smethod_0("u");

	public uint Ns
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

	public uint C
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

	public Enum219 O
	{
		get
		{
			return enum219_0;
		}
		set
		{
			enum219_0 = value;
		}
	}

	public Class1586[] NList => list_0.ToArray();

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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "n")
				{
					Class1586 item = new Class1586(reader);
					list_0.Add(item);
				}
				else
				{
					reader.Skip();
					flag = true;
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
				case "o":
					enum219_0 = Class2386.smethod_0(reader.Value);
					break;
				case "c":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ns":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1570(XmlReader reader)
		: base(reader)
	{
	}

	public Class1570()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = 0u;
		enum219_0 = enum219_1;
		list_0 = new List<Class1586>();
	}

	protected override void vmethod_2()
	{
		delegate637_0 = method_3;
		delegate638_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("ns", XmlConvert.ToString(uint_1));
		if (uint_2 != 0)
		{
			writer.WriteAttributeString("c", XmlConvert.ToString(uint_2));
		}
		if (enum219_0 != enum219_1)
		{
			writer.WriteAttributeString("o", Class2386.smethod_1(enum219_0));
		}
		foreach (Class1586 item in list_0)
		{
			item.vmethod_4("ssml", writer, "n");
		}
		writer.WriteEndElement();
	}

	private Class1586 method_3()
	{
		Class1586 @class = new Class1586();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1586 elementData)
	{
		list_0.Add(elementData);
	}
}
