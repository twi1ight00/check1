using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1552 : Class1351
{
	public delegate Class1552 Delegate535();

	public delegate void Delegate536(Class1552 elementData);

	public delegate void Delegate537(Class1552 elementData);

	public const uint uint_0 = 0u;

	public const uint uint_1 = 0u;

	public Class1749.Delegate1126 delegate1126_0;

	public Class1749.Delegate1127 delegate1127_0;

	private Enum216 enum216_0;

	private uint uint_2;

	private uint uint_3;

	private List<Class1749> list_0;

	public static readonly Enum216 enum216_1 = Class2383.smethod_0("data");

	public Enum216 T
	{
		get
		{
			return enum216_0;
		}
		set
		{
			enum216_0 = value;
		}
	}

	public uint R
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

	public uint I
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

	public Class1749[] XList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "x")
				{
					Class1749 item = new Class1749(reader);
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
				case "i":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "r":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "t":
					enum216_0 = Class2383.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1552(XmlReader reader)
		: base(reader)
	{
	}

	public Class1552()
	{
	}

	protected override void vmethod_1()
	{
		enum216_0 = enum216_1;
		uint_2 = 0u;
		uint_3 = 0u;
		list_0 = new List<Class1749>();
	}

	protected override void vmethod_2()
	{
		delegate1126_0 = method_3;
		delegate1127_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum216_0 != enum216_1)
		{
			writer.WriteAttributeString("t", Class2383.smethod_1(enum216_0));
		}
		if (uint_2 != 0)
		{
			writer.WriteAttributeString("r", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != 0)
		{
			writer.WriteAttributeString("i", XmlConvert.ToString(uint_3));
		}
		foreach (Class1749 item in list_0)
		{
			item.vmethod_4("ssml", writer, "x");
		}
		writer.WriteEndElement();
	}

	private Class1749 method_3()
	{
		Class1749 @class = new Class1749();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1749 elementData)
	{
		list_0.Add(elementData);
	}
}
