using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1573 : Class1351
{
	public delegate Class1573 Delegate598();

	public delegate void Delegate599(Class1573 elementData);

	public delegate void Delegate600(Class1573 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1572.Delegate595 delegate595_0;

	public Class1572.Delegate596 delegate596_0;

	private uint uint_1;

	private List<Class1572> list_0;

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

	public Class1572[] MapList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "map")
				{
					Class1572 item = new Class1572(reader);
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

	public Class1573(XmlReader reader)
		: base(reader)
	{
	}

	public Class1573()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1572>();
	}

	protected override void vmethod_2()
	{
		delegate595_0 = method_3;
		delegate596_0 = method_4;
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
		foreach (Class1572 item in list_0)
		{
			item.vmethod_4("ssml", writer, "map");
		}
		writer.WriteEndElement();
	}

	private Class1572 method_3()
	{
		Class1572 @class = new Class1572();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1572 elementData)
	{
		list_0.Add(elementData);
	}
}
