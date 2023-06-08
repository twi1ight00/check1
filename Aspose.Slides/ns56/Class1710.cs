using System;
using System.Xml;

namespace ns56;

internal class Class1710 : Class1351
{
	public delegate Class1710 Delegate1009();

	public delegate void Delegate1010(Class1710 elementData);

	public delegate void Delegate1011(Class1710 elementData);

	public const uint uint_0 = 1u;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const uint uint_1 = 0u;

	public const bool bool_2 = true;

	public const bool bool_3 = false;

	public const uint uint_2 = uint.MaxValue;

	public const uint uint_3 = uint.MaxValue;

	public const uint uint_4 = uint.MaxValue;

	public const uint uint_5 = uint.MaxValue;

	public const uint uint_6 = uint.MaxValue;

	public const uint uint_7 = uint.MaxValue;

	public const uint uint_8 = uint.MaxValue;

	public Class1371.Delegate75 delegate75_0;

	public Class1371.Delegate77 delegate77_0;

	public Class1706.Delegate997 delegate997_0;

	public Class1706.Delegate999 delegate999_0;

	public Class1720.Delegate1039 delegate1039_0;

	public Class1720.Delegate1041 delegate1041_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_9;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private Enum247 enum247_0;

	private uint uint_10;

	private bool bool_4;

	private bool bool_5;

	private uint uint_11;

	private bool bool_6;

	private bool bool_7;

	private uint uint_12;

	private uint uint_13;

	private uint uint_14;

	private uint uint_15;

	private uint uint_16;

	private uint uint_17;

	private string string_4;

	private string string_5;

	private string string_6;

	private uint uint_18;

	private Class1371 class1371_0;

	private Class1706 class1706_0;

	private Class1712 class1712_0;

	private Class1720 class1720_0;

	private Class1502 class1502_0;

	public static readonly Enum247 enum247_1 = Class2414.smethod_0("worksheet");

	public uint Id
	{
		get
		{
			return uint_9;
		}
		set
		{
			uint_9 = value;
		}
	}

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

	public string DisplayName
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

	public string Comment
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

	public string Ref
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

	public Enum247 TableType
	{
		get
		{
			return enum247_0;
		}
		set
		{
			enum247_0 = value;
		}
	}

	public uint HeaderRowCount
	{
		get
		{
			return uint_10;
		}
		set
		{
			uint_10 = value;
		}
	}

	public bool InsertRow
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

	public bool InsertRowShift
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

	public uint TotalsRowCount
	{
		get
		{
			return uint_11;
		}
		set
		{
			uint_11 = value;
		}
	}

	public bool TotalsRowShown
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

	public bool Published
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

	public uint HeaderRowDxfId
	{
		get
		{
			return uint_12;
		}
		set
		{
			uint_12 = value;
		}
	}

	public uint DataDxfId
	{
		get
		{
			return uint_13;
		}
		set
		{
			uint_13 = value;
		}
	}

	public uint TotalsRowDxfId
	{
		get
		{
			return uint_14;
		}
		set
		{
			uint_14 = value;
		}
	}

	public uint HeaderRowBorderDxfId
	{
		get
		{
			return uint_15;
		}
		set
		{
			uint_15 = value;
		}
	}

	public uint TableBorderDxfId
	{
		get
		{
			return uint_16;
		}
		set
		{
			uint_16 = value;
		}
	}

	public uint TotalsRowBorderDxfId
	{
		get
		{
			return uint_17;
		}
		set
		{
			uint_17 = value;
		}
	}

	public string HeaderRowCellStyle
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

	public string DataCellStyle
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

	public string TotalsRowCellStyle
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

	public uint ConnectionId
	{
		get
		{
			return uint_18;
		}
		set
		{
			uint_18 = value;
		}
	}

	public Class1371 AutoFilter => class1371_0;

	public Class1706 SortState => class1706_0;

	public Class1712 TableColumns => class1712_0;

	public Class1720 TableStyleInfo => class1720_0;

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
				case "tableStyleInfo":
					class1720_0 = new Class1720(reader);
					break;
				case "tableColumns":
					class1712_0 = new Class1712(reader);
					break;
				case "sortState":
					class1706_0 = new Class1706(reader);
					break;
				case "autoFilter":
					class1371_0 = new Class1371(reader);
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
				case "id":
					uint_9 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "name":
					string_0 = reader.Value;
					break;
				case "displayName":
					string_1 = reader.Value;
					break;
				case "comment":
					string_2 = reader.Value;
					break;
				case "ref":
					string_3 = reader.Value;
					break;
				case "tableType":
					enum247_0 = Class2414.smethod_0(reader.Value);
					break;
				case "headerRowCount":
					uint_10 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "insertRow":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "insertRowShift":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "totalsRowCount":
					uint_11 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "totalsRowShown":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "published":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "headerRowDxfId":
					uint_12 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "dataDxfId":
					uint_13 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "totalsRowDxfId":
					uint_14 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "headerRowBorderDxfId":
					uint_15 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "tableBorderDxfId":
					uint_16 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "totalsRowBorderDxfId":
					uint_17 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "headerRowCellStyle":
					string_4 = reader.Value;
					break;
				case "dataCellStyle":
					string_5 = reader.Value;
					break;
				case "totalsRowCellStyle":
					string_6 = reader.Value;
					break;
				case "connectionId":
					uint_18 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1710(XmlReader reader)
		: base(reader)
	{
	}

	public Class1710()
	{
	}

	protected override void vmethod_1()
	{
		enum247_0 = enum247_1;
		uint_10 = 1u;
		bool_4 = false;
		bool_5 = false;
		uint_11 = 0u;
		bool_6 = true;
		bool_7 = false;
		uint_12 = uint.MaxValue;
		uint_13 = uint.MaxValue;
		uint_14 = uint.MaxValue;
		uint_15 = uint.MaxValue;
		uint_16 = uint.MaxValue;
		uint_17 = uint.MaxValue;
		uint_18 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
		delegate75_0 = method_3;
		delegate77_0 = method_4;
		delegate997_0 = method_5;
		delegate999_0 = method_6;
		delegate1039_0 = method_7;
		delegate1041_0 = method_8;
		delegate385_0 = method_9;
		delegate387_0 = method_10;
	}

	protected override void vmethod_3()
	{
		class1712_0 = new Class1712();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement("ssml", elementName, "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
		writer.WriteAttributeString("id", XmlConvert.ToString(uint_9));
		if (string_0 != null)
		{
			writer.WriteAttributeString("name", string_0);
		}
		writer.WriteAttributeString("displayName", string_1);
		if (string_2 != null)
		{
			writer.WriteAttributeString("comment", string_2);
		}
		writer.WriteAttributeString("ref", string_3);
		if (enum247_0 != enum247_1)
		{
			writer.WriteAttributeString("tableType", Class2414.smethod_1(enum247_0));
		}
		if (uint_10 != 1)
		{
			writer.WriteAttributeString("headerRowCount", XmlConvert.ToString(uint_10));
		}
		if (bool_4)
		{
			writer.WriteAttributeString("insertRow", bool_4 ? "1" : "0");
		}
		if (bool_5)
		{
			writer.WriteAttributeString("insertRowShift", bool_5 ? "1" : "0");
		}
		if (uint_11 != 0)
		{
			writer.WriteAttributeString("totalsRowCount", XmlConvert.ToString(uint_11));
		}
		if (!bool_6)
		{
			writer.WriteAttributeString("totalsRowShown", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("published", bool_7 ? "1" : "0");
		}
		if (uint_12 != uint.MaxValue)
		{
			writer.WriteAttributeString("headerRowDxfId", XmlConvert.ToString(uint_12));
		}
		if (uint_13 != uint.MaxValue)
		{
			writer.WriteAttributeString("dataDxfId", XmlConvert.ToString(uint_13));
		}
		if (uint_14 != uint.MaxValue)
		{
			writer.WriteAttributeString("totalsRowDxfId", XmlConvert.ToString(uint_14));
		}
		if (uint_15 != uint.MaxValue)
		{
			writer.WriteAttributeString("headerRowBorderDxfId", XmlConvert.ToString(uint_15));
		}
		if (uint_16 != uint.MaxValue)
		{
			writer.WriteAttributeString("tableBorderDxfId", XmlConvert.ToString(uint_16));
		}
		if (uint_17 != uint.MaxValue)
		{
			writer.WriteAttributeString("totalsRowBorderDxfId", XmlConvert.ToString(uint_17));
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("headerRowCellStyle", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("dataCellStyle", string_5);
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("totalsRowCellStyle", string_6);
		}
		if (uint_18 != uint.MaxValue)
		{
			writer.WriteAttributeString("connectionId", XmlConvert.ToString(uint_18));
		}
		if (class1371_0 != null)
		{
			class1371_0.vmethod_4("ssml", writer, "autoFilter");
		}
		if (class1706_0 != null)
		{
			class1706_0.vmethod_4("ssml", writer, "sortState");
		}
		class1712_0.vmethod_4("ssml", writer, "tableColumns");
		if (class1720_0 != null)
		{
			class1720_0.vmethod_4("ssml", writer, "tableStyleInfo");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1371 method_3()
	{
		if (class1371_0 != null)
		{
			throw new Exception("Only one <autoFilter> element can be added.");
		}
		class1371_0 = new Class1371();
		return class1371_0;
	}

	private void method_4(Class1371 _autoFilter)
	{
		class1371_0 = _autoFilter;
	}

	private Class1706 method_5()
	{
		if (class1706_0 != null)
		{
			throw new Exception("Only one <sortState> element can be added.");
		}
		class1706_0 = new Class1706();
		return class1706_0;
	}

	private void method_6(Class1706 _sortState)
	{
		class1706_0 = _sortState;
	}

	private Class1720 method_7()
	{
		if (class1720_0 != null)
		{
			throw new Exception("Only one <tableStyleInfo> element can be added.");
		}
		class1720_0 = new Class1720();
		return class1720_0;
	}

	private void method_8(Class1720 _tableStyleInfo)
	{
		class1720_0 = _tableStyleInfo;
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
