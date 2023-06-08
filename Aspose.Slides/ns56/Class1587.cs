using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1587 : Class1351
{
	public delegate Class1587 Delegate640();

	public delegate void Delegate642(Class1587 elementData);

	public delegate void Delegate641(Class1587 elementData);

	public const uint uint_0 = 0u;

	public Class1754.Delegate1141 delegate1141_0;

	public Class1754.Delegate1142 delegate1142_0;

	private uint uint_1;

	private List<Class1754> list_0;

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

	public Class1754[] SList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "s")
				{
					Class1754 item = new Class1754(reader);
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

	public Class1587(XmlReader reader)
		: base(reader)
	{
	}

	public Class1587()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 0u;
		list_0 = new List<Class1754>();
	}

	protected override void vmethod_2()
	{
		delegate1141_0 = method_3;
		delegate1142_0 = method_4;
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
		foreach (Class1754 item in list_0)
		{
			item.vmethod_4("ssml", writer, "s");
		}
		writer.WriteEndElement();
	}

	private Class1754 method_3()
	{
		Class1754 @class = new Class1754();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1754 elementData)
	{
		list_0.Add(elementData);
	}
}
