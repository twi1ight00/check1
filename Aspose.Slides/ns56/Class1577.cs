using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1577 : Class1351
{
	public delegate Class1577 Delegate610();

	public delegate void Delegate611(Class1577 elementData);

	public delegate void Delegate612(Class1577 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1578.Delegate613 delegate613_0;

	public Class1578.Delegate614 delegate614_0;

	private uint uint_1;

	private List<Class1578> list_0;

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

	public Class1578[] MpList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "mp")
				{
					Class1578 item = new Class1578(reader);
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

	public Class1577(XmlReader reader)
		: base(reader)
	{
	}

	public Class1577()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1578>();
	}

	protected override void vmethod_2()
	{
		delegate613_0 = method_3;
		delegate614_0 = method_4;
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
		foreach (Class1578 item in list_0)
		{
			item.vmethod_4("ssml", writer, "mp");
		}
		writer.WriteEndElement();
	}

	private Class1578 method_3()
	{
		Class1578 @class = new Class1578();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1578 elementData)
	{
		list_0.Add(elementData);
	}
}
