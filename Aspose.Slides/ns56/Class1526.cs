using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1526 : Class1351
{
	public delegate Class1526 Delegate457();

	public delegate void Delegate458(Class1526 elementData);

	public delegate void Delegate459(Class1526 elementData);

	public const bool bool_0 = false;

	public Class1525.Delegate454 delegate454_0;

	public Class1525.Delegate455 delegate455_0;

	public Class1483.Delegate326 delegate326_0;

	public Class1483.Delegate327 delegate327_0;

	private bool bool_1;

	private Enum186 enum186_0;

	private List<Class1525> list_0;

	private List<Class1483> list_1;

	public static readonly Enum186 enum186_1 = Class2352.smethod_0("none");

	public bool Blank
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Enum186 CalendarType
	{
		get
		{
			return enum186_0;
		}
		set
		{
			enum186_0 = value;
		}
	}

	public Class1525[] FilterList => list_0.ToArray();

	public Class1483[] DateGroupItemList => list_1.ToArray();

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
				case "dateGroupItem":
				{
					Class1483 item2 = new Class1483(reader);
					list_1.Add(item2);
					break;
				}
				case "filter":
				{
					Class1525 item = new Class1525(reader);
					list_0.Add(item);
					break;
				}
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
				case "calendarType":
					enum186_0 = Class2352.smethod_0(reader.Value);
					break;
				case "blank":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1526(XmlReader reader)
		: base(reader)
	{
	}

	public Class1526()
	{
	}

	protected override void vmethod_1()
	{
		bool_1 = false;
		enum186_0 = enum186_1;
		list_0 = new List<Class1525>();
		list_1 = new List<Class1483>();
	}

	protected override void vmethod_2()
	{
		delegate454_0 = method_3;
		delegate455_0 = method_4;
		delegate326_0 = method_5;
		delegate327_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_1)
		{
			writer.WriteAttributeString("blank", bool_1 ? "1" : "0");
		}
		if (enum186_0 != enum186_1)
		{
			writer.WriteAttributeString("calendarType", Class2352.smethod_1(enum186_0));
		}
		foreach (Class1525 item in list_0)
		{
			item.vmethod_4("ssml", writer, "filter");
		}
		foreach (Class1483 item2 in list_1)
		{
			item2.vmethod_4("ssml", writer, "dateGroupItem");
		}
		writer.WriteEndElement();
	}

	private Class1525 method_3()
	{
		Class1525 @class = new Class1525();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1525 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1483 method_5()
	{
		Class1483 @class = new Class1483();
		list_1.Add(@class);
		return @class;
	}

	private void method_6(Class1483 elementData)
	{
		list_1.Add(elementData);
	}
}
