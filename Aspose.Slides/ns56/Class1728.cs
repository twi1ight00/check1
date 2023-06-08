using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1728 : Class1351
{
	public delegate Class1728 Delegate1063();

	public delegate void Delegate1065(Class1728 elementData);

	public delegate void Delegate1064(Class1728 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1727.Delegate1060 delegate1060_0;

	public Class1727.Delegate1061 delegate1061_0;

	private uint uint_1;

	private List<Class1727> list_0;

	public uint C
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

	public Class1727[] TplList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tpl")
				{
					Class1727 item = new Class1727(reader);
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
			if (!(reader.Prefix == "xmlns") && (text = method_0(reader)) != null && text == "c")
			{
				uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
			}
		}
		reader.MoveToElement();
	}

	public Class1728(XmlReader reader)
		: base(reader)
	{
	}

	public Class1728()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1727>();
	}

	protected override void vmethod_2()
	{
		delegate1060_0 = method_3;
		delegate1061_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("c", XmlConvert.ToString(uint_1));
		}
		foreach (Class1727 item in list_0)
		{
			item.vmethod_4("ssml", writer, "tpl");
		}
		writer.WriteEndElement();
	}

	private Class1727 method_3()
	{
		Class1727 @class = new Class1727();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1727 elementData)
	{
		list_0.Add(elementData);
	}
}
