using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1530 : Class1351
{
	public delegate void Delegate471(Class1530 elementData);

	public delegate Class1530 Delegate469();

	public delegate void Delegate470(Class1530 elementData);

	public const uint uint_0 = uint.MaxValue;

	public Class1527.Delegate460 delegate460_0;

	public Class1527.Delegate461 delegate461_0;

	private uint uint_1;

	private List<Class1527> list_0;

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

	public Class1527[] FontList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "font")
				{
					Class1527 item = new Class1527(reader);
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

	public Class1530(XmlReader reader)
		: base(reader)
	{
	}

	public Class1530()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1527>();
	}

	protected override void vmethod_2()
	{
		delegate460_0 = method_3;
		delegate461_0 = method_4;
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
		foreach (Class1527 item in list_0)
		{
			item.vmethod_4("ssml", writer, "font");
		}
		writer.WriteEndElement();
	}

	private Class1527 method_3()
	{
		Class1527 @class = new Class1527();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1527 elementData)
	{
		list_0.Add(elementData);
	}
}
