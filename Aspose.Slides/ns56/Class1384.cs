using System;
using System.Xml;
using Aspose.Slides;

namespace ns56;

internal class Class1384 : Class1351
{
	public delegate Class1384 Delegate114();

	public delegate void Delegate115(Class1384 elementData);

	public delegate void Delegate116(Class1384 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const uint uint_0 = uint.MaxValue;

	public const int int_0 = 0;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const ushort ushort_0 = 0;

	public const NullableBool nullableBool_0 = NullableBool.NotDefined;

	public const NullableBool nullableBool_1 = NullableBool.NotDefined;

	public const bool bool_7 = false;

	public Class1517.Delegate430 delegate430_0;

	public Class1517.Delegate432 delegate432_0;

	public Class1542.Delegate505 delegate505_0;

	public Class1542.Delegate507 delegate507_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private string string_1;

	private bool bool_8;

	private bool bool_9;

	private uint uint_1;

	private int int_1;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private bool bool_13;

	private uint uint_2;

	private bool bool_14;

	private ushort ushort_1;

	private NullableBool nullableBool_2;

	private NullableBool nullableBool_3;

	private bool bool_15;

	private Class1517 class1517_0;

	private Class1542 class1542_0;

	private Class1502 class1502_0;

	public string UniqueName
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

	public bool Measure
	{
		get
		{
			return bool_8;
		}
		set
		{
			bool_8 = value;
		}
	}

	public bool Set
	{
		get
		{
			return bool_9;
		}
		set
		{
			bool_9 = value;
		}
	}

	public uint ParentSet
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

	public int IconSet
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public bool Attribute
	{
		get
		{
			return bool_10;
		}
		set
		{
			bool_10 = value;
		}
	}

	public bool Time
	{
		get
		{
			return bool_11;
		}
		set
		{
			bool_11 = value;
		}
	}

	public bool KeyAttribute
	{
		get
		{
			return bool_12;
		}
		set
		{
			bool_12 = value;
		}
	}

	public string DefaultMemberUniqueName
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

	public string AllUniqueName
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

	public string AllCaption
	{
		get
		{
			return string_4;
		}
		set
		{
			string_4 = value;
		}
	}

	public string DimensionUniqueName
	{
		get
		{
			return string_5;
		}
		set
		{
			string_5 = value;
		}
	}

	public string DisplayFolder
	{
		get
		{
			return string_6;
		}
		set
		{
			string_6 = value;
		}
	}

	public string MeasureGroup
	{
		get
		{
			return string_7;
		}
		set
		{
			string_7 = value;
		}
	}

	public bool Measures
	{
		get
		{
			return bool_13;
		}
		set
		{
			bool_13 = value;
		}
	}

	public uint Count
	{
		get
		{
			return uint_2;
		}
		set
		{
			uint_2 = value;
		}
	}

	public bool OneField
	{
		get
		{
			return bool_14;
		}
		set
		{
			bool_14 = value;
		}
	}

	public ushort MemberValueDatatype
	{
		get
		{
			return ushort_1;
		}
		set
		{
			ushort_1 = value;
		}
	}

	public NullableBool Unbalanced
	{
		get
		{
			return nullableBool_2;
		}
		set
		{
			nullableBool_2 = value;
		}
	}

	public NullableBool UnbalancedGroup
	{
		get
		{
			return nullableBool_3;
		}
		set
		{
			nullableBool_3 = value;
		}
	}

	public bool Hidden
	{
		get
		{
			return bool_15;
		}
		set
		{
			bool_15 = value;
		}
	}

	public Class1517 FieldsUsage => class1517_0;

	public Class1542 GroupLevels => class1542_0;

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
				case "groupLevels":
					class1542_0 = new Class1542(reader);
					break;
				case "fieldsUsage":
					class1517_0 = new Class1517(reader);
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
				case "uniqueName":
					string_0 = reader.Value;
					break;
				case "caption":
					string_1 = reader.Value;
					break;
				case "measure":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "set":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "parentSet":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "iconSet":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "attribute":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "time":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "keyAttribute":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "defaultMemberUniqueName":
					string_2 = reader.Value;
					break;
				case "allUniqueName":
					string_3 = reader.Value;
					break;
				case "allCaption":
					string_4 = reader.Value;
					break;
				case "dimensionUniqueName":
					string_5 = reader.Value;
					break;
				case "displayFolder":
					string_6 = reader.Value;
					break;
				case "measureGroup":
					string_7 = reader.Value;
					break;
				case "measures":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "count":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "oneField":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "memberValueDatatype":
					ushort_1 = XmlConvert.ToUInt16(reader.Value);
					break;
				case "unbalanced":
					nullableBool_2 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "unbalancedGroup":
					nullableBool_3 = (XmlConvert.ToBoolean(reader.Value) ? NullableBool.True : NullableBool.False);
					break;
				case "hidden":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1384(XmlReader reader)
		: base(reader)
	{
	}

	public Class1384()
	{
	}

	protected override void vmethod_1()
	{
		bool_8 = false;
		bool_9 = false;
		uint_1 = uint.MaxValue;
		int_1 = 0;
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
		bool_14 = false;
		ushort_1 = 0;
		nullableBool_2 = NullableBool.NotDefined;
		nullableBool_3 = NullableBool.NotDefined;
		bool_15 = false;
	}

	protected override void vmethod_2()
	{
		delegate430_0 = method_3;
		delegate432_0 = method_4;
		delegate505_0 = method_5;
		delegate507_0 = method_6;
		delegate385_0 = method_7;
		delegate387_0 = method_8;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("uniqueName", string_0);
		if (string_1 != null)
		{
			writer.WriteAttributeString("caption", string_1);
		}
		if (bool_8)
		{
			writer.WriteAttributeString("measure", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("set", bool_9 ? "1" : "0");
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("parentSet", XmlConvert.ToString(uint_1));
		}
		if (int_1 != 0)
		{
			writer.WriteAttributeString("iconSet", XmlConvert.ToString(int_1));
		}
		if (bool_10)
		{
			writer.WriteAttributeString("attribute", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("time", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("keyAttribute", bool_12 ? "1" : "0");
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("defaultMemberUniqueName", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("allUniqueName", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("allCaption", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("dimensionUniqueName", string_5);
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("displayFolder", string_6);
		}
		if (string_7 != null)
		{
			writer.WriteAttributeString("measureGroup", string_7);
		}
		if (bool_13)
		{
			writer.WriteAttributeString("measures", bool_13 ? "1" : "0");
		}
		writer.WriteAttributeString("count", XmlConvert.ToString(uint_2));
		if (bool_14)
		{
			writer.WriteAttributeString("oneField", bool_14 ? "1" : "0");
		}
		if (ushort_1 != 0)
		{
			writer.WriteAttributeString("memberValueDatatype", XmlConvert.ToString(ushort_1));
		}
		if (nullableBool_2 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("unbalanced", (nullableBool_2 == NullableBool.True) ? "1" : "0");
		}
		if (nullableBool_3 != NullableBool.NotDefined)
		{
			writer.WriteAttributeString("unbalancedGroup", (nullableBool_3 == NullableBool.True) ? "1" : "0");
		}
		if (bool_15)
		{
			writer.WriteAttributeString("hidden", bool_15 ? "1" : "0");
		}
		if (class1517_0 != null)
		{
			class1517_0.vmethod_4("ssml", writer, "fieldsUsage");
		}
		if (class1542_0 != null)
		{
			class1542_0.vmethod_4("ssml", writer, "groupLevels");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1517 method_3()
	{
		if (class1517_0 != null)
		{
			throw new Exception("Only one <fieldsUsage> element can be added.");
		}
		class1517_0 = new Class1517();
		return class1517_0;
	}

	private void method_4(Class1517 _fieldsUsage)
	{
		class1517_0 = _fieldsUsage;
	}

	private Class1542 method_5()
	{
		if (class1542_0 != null)
		{
			throw new Exception("Only one <groupLevels> element can be added.");
		}
		class1542_0 = new Class1542();
		return class1542_0;
	}

	private void method_6(Class1542 _groupLevels)
	{
		class1542_0 = _groupLevels;
	}

	private Class1502 method_7()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_8(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
