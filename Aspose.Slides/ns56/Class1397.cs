using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1397 : Class1351
{
	public delegate Class1397 Delegate153();

	public delegate void Delegate154(Class1397 elementData);

	public delegate void Delegate155(Class1397 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public Class1398.Delegate156 delegate156_0;

	public Class1398.Delegate157 delegate157_0;

	private uint uint_0;

	private bool bool_2;

	private bool bool_3;

	private List<Class1398> list_0;

	public uint Type
	{
		get
		{
			return uint_0;
		}
		set
		{
			uint_0 = value;
		}
	}

	public bool Deleted
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool XmlBased
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Class1398[] CellSmartTagPrList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "cellSmartTagPr")
				{
					Class1398 item = new Class1398(reader);
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
			if (!(reader.Prefix == "xmlns"))
			{
				switch (method_0(reader))
				{
				case "xmlBased":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "deleted":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "type":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1397(XmlReader reader)
		: base(reader)
	{
	}

	public Class1397()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		bool_3 = false;
		list_0 = new List<Class1398>();
	}

	protected override void vmethod_2()
	{
		delegate156_0 = method_3;
		delegate157_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("type", XmlConvert.ToString(uint_0));
		if (bool_2)
		{
			writer.WriteAttributeString("deleted", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("xmlBased", bool_3 ? "1" : "0");
		}
		foreach (Class1398 item in list_0)
		{
			item.vmethod_4("ssml", writer, "cellSmartTagPr");
		}
		writer.WriteEndElement();
	}

	private Class1398 method_3()
	{
		Class1398 @class = new Class1398();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1398 elementData)
	{
		list_0.Add(elementData);
	}
}
