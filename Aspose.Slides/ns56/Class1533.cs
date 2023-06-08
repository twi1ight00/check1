using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1533 : Class1351
{
	public delegate Class1533 Delegate478();

	public delegate void Delegate479(Class1533 elementData);

	public delegate void Delegate480(Class1533 elementData);

	public const uint uint_0 = 0u;

	public Class1532.Delegate475 delegate475_0;

	public Class1532.Delegate476 delegate476_0;

	private uint uint_1;

	private List<Class1532> list_0;

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

	public Class1532[] FormatList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "format")
				{
					Class1532 item = new Class1532(reader);
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

	public Class1533(XmlReader reader)
		: base(reader)
	{
	}

	public Class1533()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 0u;
		list_0 = new List<Class1532>();
	}

	protected override void vmethod_2()
	{
		delegate475_0 = method_3;
		delegate476_0 = method_4;
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
		foreach (Class1532 item in list_0)
		{
			item.vmethod_4("ssml", writer, "format");
		}
		writer.WriteEndElement();
	}

	private Class1532 method_3()
	{
		Class1532 @class = new Class1532();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1532 elementData)
	{
		list_0.Add(elementData);
	}
}
