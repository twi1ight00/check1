using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1589 : Class1351
{
	public delegate Class1589 Delegate646();

	public delegate void Delegate648(Class1589 elementData);

	public delegate void Delegate647(Class1589 elementData);

	public const uint uint_0 = 0u;

	public Class1588.Delegate643 delegate643_0;

	public Class1588.Delegate644 delegate644_0;

	private uint uint_1;

	private List<Class1588> list_0;

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

	public Class1588[] MetadataTypeList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "metadataType")
				{
					Class1588 item = new Class1588(reader);
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

	public Class1589(XmlReader reader)
		: base(reader)
	{
	}

	public Class1589()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = 0u;
		list_0 = new List<Class1588>();
	}

	protected override void vmethod_2()
	{
		delegate643_0 = method_3;
		delegate644_0 = method_4;
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
		foreach (Class1588 item in list_0)
		{
			item.vmethod_4("ssml", writer, "metadataType");
		}
		writer.WriteEndElement();
	}

	private Class1588 method_3()
	{
		Class1588 @class = new Class1588();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1588 elementData)
	{
		list_0.Add(elementData);
	}
}
