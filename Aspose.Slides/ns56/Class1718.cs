using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1718 : Class1351
{
	public delegate Class1718 Delegate1033();

	public delegate void Delegate1034(Class1718 elementData);

	public delegate void Delegate1035(Class1718 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = true;

	public const uint uint_0 = uint.MaxValue;

	public Class1719.Delegate1036 delegate1036_0;

	public Class1719.Delegate1037 delegate1037_0;

	private string string_0;

	private bool bool_2;

	private bool bool_3;

	private uint uint_1;

	private List<Class1719> list_0;

	public string Name
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public bool Pivot
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

	public bool Table
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

	public Class1719[] TableStyleElementList => list_0.ToArray();

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tableStyleElement")
				{
					Class1719 item = new Class1719(reader);
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
				case "count":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "table":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pivot":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "name":
					string_0 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1718(XmlReader reader)
		: base(reader)
	{
	}

	public Class1718()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = true;
		bool_3 = true;
		uint_1 = uint.MaxValue;
		list_0 = new List<Class1719>();
	}

	protected override void vmethod_2()
	{
		delegate1036_0 = method_3;
		delegate1037_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("name", string_0);
		if (!bool_2)
		{
			writer.WriteAttributeString("pivot", bool_2 ? "1" : "0");
		}
		if (!bool_3)
		{
			writer.WriteAttributeString("table", bool_3 ? "1" : "0");
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		foreach (Class1719 item in list_0)
		{
			item.vmethod_4("ssml", writer, "tableStyleElement");
		}
		writer.WriteEndElement();
	}

	private Class1719 method_3()
	{
		Class1719 @class = new Class1719();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1719 elementData)
	{
		list_0.Add(elementData);
	}
}
