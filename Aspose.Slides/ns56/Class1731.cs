using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1731 : Class1351
{
	public delegate Class1731 Delegate1072();

	public delegate void Delegate1073(Class1731 elementData);

	public delegate void Delegate1074(Class1731 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1685.Delegate934 delegate934_0;

	public Class1685.Delegate935 delegate935_0;

	private uint uint_1;

	private List<Class1685> list_0;

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

	public Class1685[] UserInfoList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "userInfo")
				{
					Class1685 item = new Class1685(reader);
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

	public Class1731(XmlReader reader)
		: base(reader)
	{
	}

	public Class1731()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1685>();
	}

	protected override void vmethod_2()
	{
		delegate934_0 = method_3;
		delegate935_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		foreach (Class1685 item in list_0)
		{
			item.vmethod_4("ssml", writer, "userInfo");
		}
		writer.WriteEndElement();
	}

	private Class1685 method_3()
	{
		Class1685 @class = new Class1685();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1685 elementData)
	{
		list_0.Add(elementData);
	}
}
