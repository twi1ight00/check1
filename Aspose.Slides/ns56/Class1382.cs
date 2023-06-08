using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1382 : Class1351
{
	public delegate Class1382 Delegate108();

	public delegate void Delegate109(Class1382 elementData);

	public delegate void Delegate110(Class1382 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1381.Delegate105 delegate105_0;

	public Class1381.Delegate106 delegate106_0;

	private uint uint_1;

	private List<Class1381> list_0;

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

	public Class1381[] CacheFieldList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cacheField")
				{
					Class1381 item = new Class1381(reader);
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

	public Class1382(XmlReader reader)
		: base(reader)
	{
	}

	public Class1382()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1381>();
	}

	protected override void vmethod_2()
	{
		delegate105_0 = method_3;
		delegate106_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		foreach (Class1381 item in list_0)
		{
			item.vmethod_4("ssml", writer, "cacheField");
		}
		writer.WriteEndElement();
	}

	private Class1381 method_3()
	{
		Class1381 @class = new Class1381();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1381 elementData)
	{
		list_0.Add(elementData);
	}
}
