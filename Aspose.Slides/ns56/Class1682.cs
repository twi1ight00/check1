using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1682 : Class1351
{
	public delegate Class1682 Delegate925();

	public delegate void Delegate926(Class1682 elementData);

	public delegate void Delegate927(Class1682 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_0 = false;

	public Class1728.Delegate1063 delegate1063_0;

	public Class1728.Delegate1064 delegate1064_0;

	public Class1728.Delegate1063 delegate1063_1;

	public Class1728.Delegate1065 delegate1065_0;

	private uint uint_1;

	private int int_0;

	private string string_0;

	private Enum244 enum244_0;

	private bool bool_1;

	private List<Class1728> list_0;

	private Class1728 class1728_0;

	public static readonly Enum244 enum244_1 = Class2411.smethod_0("none");

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

	public int MaxRank
	{
		get
		{
			return int_0;
		}
		set
		{
			int_0 = value;
		}
	}

	public string SetDefinition
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

	public Enum244 SortType
	{
		get
		{
			return enum244_0;
		}
		set
		{
			enum244_0 = value;
		}
	}

	public bool QueryFailed
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	public Class1728[] TplsList => list_0.ToArray();

	public Class1728 SortByTuple => class1728_0;

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
				switch (reader.LocalName)
				{
				case "sortByTuple":
					class1728_0 = new Class1728(reader);
					break;
				case "tpls":
				{
					Class1728 item = new Class1728(reader);
					list_0.Add(item);
					break;
				}
				default:
					reader.Skip();
					flag = true;
					break;
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
				case "queryFailed":
					bool_1 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sortType":
					enum244_0 = Class2411.smethod_0(reader.Value);
					break;
				case "setDefinition":
					string_0 = reader.Value;
					break;
				case "maxRank":
					int_0 = XmlConvert.ToInt32(reader.Value);
					break;
				case "count":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1682(XmlReader reader)
		: base(reader)
	{
	}

	public Class1682()
	{
	}

	protected override void vmethod_1()
	{
		uint_1 = uint.MaxValue;
		enum244_0 = enum244_1;
		bool_1 = false;
		list_0 = new List<Class1728>();
	}

	protected override void vmethod_2()
	{
		delegate1063_0 = method_3;
		delegate1064_0 = method_4;
		delegate1063_1 = method_5;
		delegate1065_0 = method_6;
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
		writer.WriteAttributeString("maxRank", XmlConvert.ToString(int_0));
		writer.WriteAttributeString("setDefinition", string_0);
		if (enum244_0 != enum244_1)
		{
			writer.WriteAttributeString("sortType", Class2411.smethod_1(enum244_0));
		}
		if (bool_1)
		{
			writer.WriteAttributeString("queryFailed", bool_1 ? "1" : "0");
		}
		foreach (Class1728 item in list_0)
		{
			item.vmethod_4("ssml", writer, "tpls");
		}
		if (class1728_0 != null)
		{
			class1728_0.vmethod_4("ssml", writer, "sortByTuple");
		}
		writer.WriteEndElement();
	}

	private Class1728 method_3()
	{
		Class1728 @class = new Class1728();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1728 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1728 method_5()
	{
		if (class1728_0 != null)
		{
			throw new Exception("Only one <sortByTuple> element can be added.");
		}
		class1728_0 = new Class1728();
		return class1728_0;
	}

	private void method_6(Class1728 _sortByTuple)
	{
		class1728_0 = _sortByTuple;
	}
}
