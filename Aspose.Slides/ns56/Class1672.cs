using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1672 : Class1351
{
	public delegate Class1672 Delegate895();

	public delegate void Delegate897(Class1672 elementData);

	public delegate void Delegate896(Class1672 elementData);

	public const uint uint_0 = 0u;

	public Class1515.Delegate424 delegate424_0;

	public Class1515.Delegate425 delegate425_0;

	private uint uint_1;

	private List<Class1515> list_0;

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

	public Class1515[] FieldList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "field")
				{
					Class1515 item = new Class1515(reader);
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

	public Class1672(XmlReader reader)
		: base(reader)
	{
	}

	public Class1672()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 0u;
		list_0 = new List<Class1515>();
	}

	protected override void vmethod_2()
	{
		delegate424_0 = method_3;
		delegate425_0 = method_4;
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
		foreach (Class1515 item in list_0)
		{
			item.vmethod_4("ssml", writer, "field");
		}
		writer.WriteEndElement();
	}

	private Class1515 method_3()
	{
		Class1515 @class = new Class1515();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1515 elementData)
	{
		list_0.Add(elementData);
	}
}
