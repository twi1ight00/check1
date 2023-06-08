using System;
using System.Xml;

namespace ns56;

internal class Class1648 : Class1351
{
	public delegate Class1648 Delegate823();

	public delegate void Delegate825(Class1648 elementData);

	public delegate void Delegate824(Class1648 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = true;

	public const byte byte_0 = 0;

	public const uint uint_0 = 1u;

	public const uint uint_1 = 0u;

	public const uint uint_2 = 0u;

	public Class1645.Delegate814 delegate814_0;

	public Class1645.Delegate816 delegate816_0;

	public Class1706.Delegate997 delegate997_0;

	public Class1706.Delegate999 delegate999_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private bool bool_3;

	private bool bool_4;

	private bool bool_5;

	private byte byte_1;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private Class1647 class1647_0;

	private Class1645 class1645_0;

	private Class1706 class1706_0;

	private Class1502 class1502_0;

	public bool PreserveSortFilterLayout
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

	public bool FieldIdWrapped
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

	public bool HeadersInLastRefresh
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

	public byte MinimumVersion
	{
		get
		{
			return byte_1;
		}
		set
		{
			byte_1 = value;
		}
	}

	public uint NextId
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

	public uint UnboundColumnsLeft
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

	public uint UnboundColumnsRight
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

	public Class1647 QueryTableFields => class1647_0;

	public Class1645 QueryTableDeletedFields => class1645_0;

	public Class1706 SortState => class1706_0;

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
				case "sortState":
					class1706_0 = new Class1706(reader);
					break;
				case "queryTableDeletedFields":
					class1645_0 = new Class1645(reader);
					break;
				case "queryTableFields":
					class1647_0 = new Class1647(reader);
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
				case "preserveSortFilterLayout":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "fieldIdWrapped":
					bool_4 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "headersInLastRefresh":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "minimumVersion":
					byte_1 = XmlConvert.ToByte(reader.Value);
					break;
				case "nextId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "unboundColumnsLeft":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "unboundColumnsRight":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1648(XmlReader reader)
		: base(reader)
	{
	}

	public Class1648()
	{
	}

	protected override void vmethod_1()
	{
		bool_3 = true;
		bool_4 = false;
		bool_5 = true;
		byte_1 = 0;
		uint_3 = 1u;
		uint_4 = 0u;
		uint_5 = 0u;
	}

	protected override void vmethod_2()
	{
		delegate814_0 = method_3;
		delegate816_0 = method_4;
		delegate997_0 = method_5;
		delegate999_0 = method_6;
		delegate385_0 = method_7;
		delegate387_0 = method_8;
	}

	protected override void vmethod_3()
	{
		class1647_0 = new Class1647();
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!bool_3)
		{
			writer.WriteAttributeString("preserveSortFilterLayout", bool_3 ? "1" : "0");
		}
		if (bool_4)
		{
			writer.WriteAttributeString("fieldIdWrapped", bool_4 ? "1" : "0");
		}
		if (!bool_5)
		{
			writer.WriteAttributeString("headersInLastRefresh", bool_5 ? "1" : "0");
		}
		if (byte_1 != 0)
		{
			writer.WriteAttributeString("minimumVersion", XmlConvert.ToString(byte_1));
		}
		if (uint_3 != 1)
		{
			writer.WriteAttributeString("nextId", XmlConvert.ToString(uint_3));
		}
		if (uint_4 != 0)
		{
			writer.WriteAttributeString("unboundColumnsLeft", XmlConvert.ToString(uint_4));
		}
		if (uint_5 != 0)
		{
			writer.WriteAttributeString("unboundColumnsRight", XmlConvert.ToString(uint_5));
		}
		class1647_0.vmethod_4("ssml", writer, "queryTableFields");
		if (class1645_0 != null)
		{
			class1645_0.vmethod_4("ssml", writer, "queryTableDeletedFields");
		}
		if (class1706_0 != null)
		{
			class1706_0.vmethod_4("ssml", writer, "sortState");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1645 method_3()
	{
		if (class1645_0 != null)
		{
			throw new Exception("Only one <queryTableDeletedFields> element can be added.");
		}
		class1645_0 = new Class1645();
		return class1645_0;
	}

	private void method_4(Class1645 _queryTableDeletedFields)
	{
		class1645_0 = _queryTableDeletedFields;
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
