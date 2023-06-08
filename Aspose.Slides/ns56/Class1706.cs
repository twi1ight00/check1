using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1706 : Class1351
{
	public delegate void Delegate999(Class1706 elementData);

	public delegate Class1706 Delegate997();

	public delegate void Delegate998(Class1706 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public Class1705.Delegate994 delegate994_0;

	public Class1705.Delegate995 delegate995_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private bool bool_2;

	private bool bool_3;

	private Enum243 enum243_0;

	private string string_0;

	private List<Class1705> list_0;

	private Class1502 class1502_0;

	public static readonly Enum243 enum243_1 = Class2410.smethod_0("none");

	public bool ColumnSort
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

	public bool CaseSensitive
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

	public Enum243 SortMethod
	{
		get
		{
			return enum243_0;
		}
		set
		{
			enum243_0 = value;
		}
	}

	public string Ref
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

	public Class1705[] SortConditionList => list_0.ToArray();

	public Class1502 ExtLst => class1502_0;

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
				case "extLst":
					class1502_0 = new Class1502(reader);
					break;
				case "sortCondition":
				{
					Class1705 item = new Class1705(reader);
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
				case "ref":
					string_0 = reader.Value;
					break;
				case "sortMethod":
					enum243_0 = Class2410.smethod_0(reader.Value);
					break;
				case "caseSensitive":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "columnSort":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1706(XmlReader reader)
		: base(reader)
	{
	}

	public Class1706()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = false;
		bool_3 = false;
		enum243_0 = enum243_1;
		list_0 = new List<Class1705>();
	}

	protected override void vmethod_2()
	{
		delegate994_0 = method_3;
		delegate995_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_2)
		{
			writer.WriteAttributeString("columnSort", bool_2 ? "1" : "0");
		}
		if (bool_3)
		{
			writer.WriteAttributeString("caseSensitive", bool_3 ? "1" : "0");
		}
		if (enum243_0 != enum243_1)
		{
			writer.WriteAttributeString("sortMethod", Class2410.smethod_1(enum243_0));
		}
		writer.WriteAttributeString("ref", string_0);
		foreach (Class1705 item in list_0)
		{
			item.vmethod_4("ssml", writer, "sortCondition");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1705 method_3()
	{
		Class1705 @class = new Class1705();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1705 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1502 method_5()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_6(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
