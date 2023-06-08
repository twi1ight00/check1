using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1569 : Class1351
{
	public delegate Class1569 Delegate586();

	public delegate void Delegate587(Class1569 elementData);

	public delegate void Delegate588(Class1569 elementData);

	public const uint uint_0 = 0u;

	public Class1566.Delegate577 delegate577_0;

	public Class1566.Delegate578 delegate578_0;

	private uint uint_1;

	private List<Class1566> list_0;

	public uint Count
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

	public Class1566[] MdxList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "mdx")
				{
					Class1566 item = new Class1566(reader);
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
			string text;
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "count")
			{
				uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1569(XmlReader reader)
		: base(reader)
	{
	}

	public Class1569()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 0u;
		list_0 = new List<Class1566>();
	}

	protected override void vmethod_2()
	{
		delegate577_0 = method_3;
		delegate578_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != 0)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		foreach (Class1566 item in list_0)
		{
			item.vmethod_4("ssml", writer, "mdx");
		}
		writer.WriteEndElement();
	}

	private Class1566 method_3()
	{
		Class1566 @class = new Class1566();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1566 elementData)
	{
		list_0.Add(elementData);
	}
}
