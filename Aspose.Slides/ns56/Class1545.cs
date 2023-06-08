using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1545 : Class1351
{
	public delegate Class1545 Delegate514();

	public delegate void Delegate516(Class1545 elementData);

	public delegate void Delegate515(Class1545 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1562.Delegate565 delegate565_0;

	public Class1562.Delegate566 delegate566_0;

	private uint uint_1;

	private List<Class1562> list_0;

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

	public Class1562[] GroupList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "group")
				{
					Class1562 item = new Class1562(reader);
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

	public Class1545(XmlReader reader)
		: base(reader)
	{
	}

	public Class1545()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1562>();
	}

	protected override void vmethod_2()
	{
		delegate565_0 = method_3;
		delegate566_0 = method_4;
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
		foreach (Class1562 item in list_0)
		{
			item.vmethod_4("ssml", writer, "group");
		}
		writer.WriteEndElement();
	}

	private Class1562 method_3()
	{
		Class1562 @class = new Class1562();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1562 elementData)
	{
		list_0.Add(elementData);
	}
}
