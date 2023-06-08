using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1707 : Class1351
{
	public delegate Class1707 Delegate1000();

	public delegate void Delegate1001(Class1707 elementData);

	public delegate void Delegate1002(Class1707 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = uint.MaxValue;

	public Class1676.Delegate907 delegate907_0;

	public Class1676.Delegate908 delegate908_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_2;

	private uint uint_3;

	private List<Class1676> list_0;

	private Class1502 class1502_0;

	public uint Count
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

	public uint UniqueCount
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

	public Class1676[] SiList => list_0.ToArray();

	public Class1502 ExtLst => class1502_0;

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
				case "extLst":
					class1502_0 = new Class1502(reader);
					break;
				case "si":
				{
					Class1676 item = new Class1676(reader);
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
				case "uniqueCount":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "count":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1707(XmlReader reader)
		: base(reader)
	{
	}

	public Class1707()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = uint.MaxValue;
		uint_3 = uint.MaxValue;
		list_0 = new List<Class1676>();
	}

	protected override void vmethod_2()
	{
		delegate907_0 = method_3;
		delegate908_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("uniqueCount", XmlConvert.ToString(uint_3));
		}
		foreach (Class1676 item in list_0)
		{
			item.vmethod_4("ssml", writer, "si");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1676 method_3()
	{
		Class1676 @class = new Class1676();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1676 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1502 method_5()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_6(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
