using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1723 : Class1351
{
	public delegate Class1723 Delegate1048();

	public delegate void Delegate1049(Class1723 elementData);

	public delegate void Delegate1050(Class1723 elementData);

	public const uint uint_0 = 1u;

	public Class1722.Delegate1045 delegate1045_0;

	public Class1722.Delegate1046 delegate1046_0;

	private uint uint_1;

	private List<Class1722> list_0;

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

	public Class1722[] TextFieldList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "textField")
				{
					Class1722 item = new Class1722(reader);
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

	public Class1723(XmlReader reader)
		: base(reader)
	{
	}

	public Class1723()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 1u;
		list_0 = new List<Class1722>();
	}

	protected override void vmethod_2()
	{
		delegate1045_0 = method_3;
		delegate1046_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_1 != 1)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		foreach (Class1722 item in list_0)
		{
			item.vmethod_4("ssml", writer, "textField");
		}
		writer.WriteEndElement();
	}

	private Class1722 method_3()
	{
		Class1722 @class = new Class1722();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1722 elementData)
	{
		list_0.Add(elementData);
	}
}
