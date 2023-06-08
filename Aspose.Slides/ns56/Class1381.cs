using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1381 : Class1351
{
	public delegate Class1381 Delegate105();

	public delegate void Delegate106(Class1381 elementData);

	public delegate void Delegate107(Class1381 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = true;

	public const uint uint_0 = uint.MaxValue;

	public const int int_0 = 0;

	public const int int_1 = 0;

	public const uint uint_1 = 0u;

	public const bool bool_2 = true;

	public const uint uint_2 = uint.MaxValue;

	public const bool bool_3 = false;

	public Class1684.Delegate931 delegate931_0;

	public Class1684.Delegate933 delegate933_0;

	public Class1516.Delegate427 delegate427_0;

	public Class1516.Delegate429 delegate429_0;

	public Class1749.Delegate1126 delegate1126_0;

	public Class1749.Delegate1127 delegate1127_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private string string_1;

	private string string_2;

	private bool bool_4;

	private bool bool_5;

	private uint uint_3;

	private string string_3;

	private int int_2;

	private int int_3;

	private uint uint_4;

	private bool bool_6;

	private uint uint_5;

	private bool bool_7;

	private Class1684 class1684_0;

	private Class1516 class1516_0;

	private List<Class1749> list_0;

	private Class1502 class1502_0;

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

	public string Caption
	{
		get
		{
			return string_1;
		}
		set
		{
			string_1 = value;
		}
	}

	public string PropertyName
	{
		get
		{
			return string_2;
		}
		set
		{
			string_2 = value;
		}
	}

	public bool ServerField
	{
		get
		{
			return bool_4;
		}
		set
		{
			bool_4 = value;
		}
	}

	public bool UniqueList
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public uint NumFmtId
	{
		get
		{
			return uint_3;
		}
		set
		{
			uint_3 = value;
		}
	}

	public string Formula
	{
		get
		{
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public int SqlType
	{
		get
		{
			return int_2;
		}
		set
		{
			int_2 = value;
		}
	}

	public int Hierarchy
	{
		get
		{
			return int_3;
		}
		set
		{
			int_3 = value;
		}
	}

	public uint Level
	{
		get
		{
			return uint_4;
		}
		set
		{
			uint_4 = value;
		}
	}

	public bool DatabaseField
	{
		get
		{
			return bool_6;
		}
		set
		{
			bool_6 = value;
		}
	}

	public uint MappingCount
	{
		get
		{
			return uint_5;
		}
		set
		{
			uint_5 = value;
		}
	}

	public bool MemberPropertyField
	{
		get
		{
			return bool_7;
		}
		set
		{
			bool_7 = value;
		}
	}

	public Class1684 SharedItems => class1684_0;

	public Class1516 FieldGroup => class1516_0;

	public Class1749[] MpMapList => list_0.ToArray();

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
				case "mpMap":
				{
					Class1749 item = new Class1749(reader);
					list_0.Add(item);
					break;
				}
				case "fieldGroup":
					class1516_0 = new Class1516(reader);
					break;
				case "sharedItems":
					class1684_0 = new Class1684(reader);
					break;
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
				case "name":
					string_0 = reader.Value;
					break;
				case "caption":
					string_1 = reader.Value;
					break;
				case "propertyName":
					string_2 = reader.Value;
					break;
				case "serverField":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "uniqueList":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "numFmtId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "formula":
					string_3 = reader.Value;
					break;
				case "sqlType":
					int_2 = XmlConvert.ToInt32(reader.Value);
					break;
				case "hierarchy":
					int_3 = XmlConvert.ToInt32(reader.Value);
					break;
				case "level":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "databaseField":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "mappingCount":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "memberPropertyField":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1381(XmlReader reader)
		: base(reader)
	{
	}

	public Class1381()
	{
	}

	protected override void vmethod_1()
	{
		bool_4 = false;
		bool_5 = true;
		uint_3 = uint.MaxValue;
		int_2 = 0;
		int_3 = 0;
		uint_4 = 0u;
		bool_6 = true;
		uint_5 = uint.MaxValue;
		bool_7 = false;
		list_0 = new List<Class1749>();
	}

	protected override void vmethod_2()
	{
		delegate931_0 = method_3;
		delegate933_0 = method_4;
		delegate427_0 = method_5;
		delegate429_0 = method_6;
		delegate1126_0 = method_7;
		delegate1127_0 = method_8;
		delegate385_0 = method_9;
		delegate387_0 = method_10;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("name", string_0);
		if (string_1 != null)
		{
			writer.WriteAttributeString("caption", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("propertyName", string_2);
		}
		if (bool_4)
		{
			writer.WriteAttributeString("serverField", bool_4 ? "1" : "0");
		}
		if (!bool_5)
		{
			writer.WriteAttributeString("uniqueList", bool_5 ? "1" : "0");
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("numFmtId", XmlConvert.ToString(uint_3));
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("formula", string_3);
		}
		if (int_2 != 0)
		{
			writer.WriteAttributeString("sqlType", XmlConvert.ToString(int_2));
		}
		if (int_3 != 0)
		{
			writer.WriteAttributeString("hierarchy", XmlConvert.ToString(int_3));
		}
		if (uint_4 != 0)
		{
			writer.WriteAttributeString("level", XmlConvert.ToString(uint_4));
		}
		if (!bool_6)
		{
			writer.WriteAttributeString("databaseField", bool_6 ? "1" : "0");
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("mappingCount", XmlConvert.ToString(uint_5));
		}
		if (bool_7)
		{
			writer.WriteAttributeString("memberPropertyField", bool_7 ? "1" : "0");
		}
		if (class1684_0 != null)
		{
			class1684_0.vmethod_4("ssml", writer, "sharedItems");
		}
		if (class1516_0 != null)
		{
			class1516_0.vmethod_4("ssml", writer, "fieldGroup");
		}
		foreach (Class1749 item in list_0)
		{
			item.vmethod_4("ssml", writer, "mpMap");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1684 method_3()
	{
		if (class1684_0 != null)
		{
			throw new Exception("Only one <sharedItems> element can be added.");
		}
		class1684_0 = new Class1684();
		return class1684_0;
	}

	private void method_4(Class1684 _sharedItems)
	{
		class1684_0 = _sharedItems;
	}

	private Class1516 method_5()
	{
		if (class1516_0 != null)
		{
			throw new Exception("Only one <fieldGroup> element can be added.");
		}
		class1516_0 = new Class1516();
		return class1516_0;
	}

	private void method_6(Class1516 _fieldGroup)
	{
		class1516_0 = _fieldGroup;
	}

	private Class1749 method_7()
	{
		Class1749 @class = new Class1749();
		list_0.Add(@class);
		return @class;
	}

	private void method_8(Class1749 elementData)
	{
		list_0.Add(elementData);
	}

	private Class1502 method_9()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_10(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
