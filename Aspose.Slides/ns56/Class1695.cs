using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1695 : Class1351
{
	public delegate void Delegate966(Class1695 elementData);

	public delegate Class1695 Delegate964();

	public delegate void Delegate965(Class1695 elementData);

	public const ushort ushort_0 = ushort.MaxValue;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = true;

	public const bool bool_4 = true;

	public const bool bool_5 = true;

	public const bool bool_6 = true;

	public const bool bool_7 = true;

	public const bool bool_8 = true;

	public const bool bool_9 = true;

	public const bool bool_10 = true;

	public const bool bool_11 = false;

	public const bool bool_12 = true;

	public const bool bool_13 = true;

	public const bool bool_14 = true;

	public const bool bool_15 = false;

	private ushort ushort_1;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private bool bool_22;

	private bool bool_23;

	private bool bool_24;

	private bool bool_25;

	private bool bool_26;

	private bool bool_27;

	private bool bool_28;

	private bool bool_29;

	private bool bool_30;

	private bool bool_31;

	public ushort Password
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

	public bool Sheet
	{
		get
		{
			return bool_16;
		}
		set
		{
			bool_16 = value;
		}
	}

	public bool Objects
	{
		get
		{
			return bool_17;
		}
		set
		{
			bool_17 = value;
		}
	}

	public bool Scenarios
	{
		get
		{
			return bool_18;
		}
		set
		{
			bool_18 = value;
		}
	}

	public bool FormatCells
	{
		get
		{
			return bool_19;
		}
		set
		{
			bool_19 = value;
		}
	}

	public bool FormatColumns
	{
		get
		{
			return bool_20;
		}
		set
		{
			bool_20 = value;
		}
	}

	public bool FormatRows
	{
		get
		{
			return bool_21;
		}
		set
		{
			bool_21 = value;
		}
	}

	public bool InsertColumns
	{
		get
		{
			return bool_22;
		}
		set
		{
			bool_22 = value;
		}
	}

	public bool InsertRows
	{
		get
		{
			return bool_23;
		}
		set
		{
			bool_23 = value;
		}
	}

	public bool InsertHyperlinks
	{
		get
		{
			return bool_24;
		}
		set
		{
			bool_24 = value;
		}
	}

	public bool DeleteColumns
	{
		get
		{
			return bool_25;
		}
		set
		{
			bool_25 = value;
		}
	}

	public bool DeleteRows
	{
		get
		{
			return bool_26;
		}
		set
		{
			bool_26 = value;
		}
	}

	public bool SelectLockedCells
	{
		get
		{
			return bool_27;
		}
		set
		{
			bool_27 = value;
		}
	}

	public bool Sort
	{
		get
		{
			return bool_28;
		}
		set
		{
			bool_28 = value;
		}
	}

	public bool AutoFilter
	{
		get
		{
			return bool_29;
		}
		set
		{
			bool_29 = value;
		}
	}

	public bool PivotTables
	{
		get
		{
			return bool_30;
		}
		set
		{
			bool_30 = value;
		}
	}

	public bool SelectUnlockedCells
	{
		get
		{
			return bool_31;
		}
		set
		{
			bool_31 = value;
		}
	}

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
				_ = reader.LocalName;
				reader.Skip();
				flag = true;
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
				case "password":
					ushort_1 = ushort.Parse(reader.Value, NumberStyles.HexNumber);
					break;
				case "sheet":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "objects":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "scenarios":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "formatCells":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "formatColumns":
					bool_20 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "formatRows":
					bool_21 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "insertColumns":
					bool_22 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "insertRows":
					bool_23 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "insertHyperlinks":
					bool_24 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "deleteColumns":
					bool_25 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "deleteRows":
					bool_26 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "selectLockedCells":
					bool_27 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sort":
					bool_28 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "autoFilter":
					bool_29 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pivotTables":
					bool_30 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "selectUnlockedCells":
					bool_31 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1695(XmlReader reader)
		: base(reader)
	{
	}

	public Class1695()
	{
	}

	protected override void vmethod_1()
	{
		ushort_1 = ushort.MaxValue;
		bool_16 = false;
		bool_17 = false;
		bool_18 = false;
		bool_19 = true;
		bool_20 = true;
		bool_21 = true;
		bool_22 = true;
		bool_23 = true;
		bool_24 = true;
		bool_25 = true;
		bool_26 = true;
		bool_27 = false;
		bool_28 = true;
		bool_29 = true;
		bool_30 = true;
		bool_31 = false;
	}

	protected override void vmethod_2()
	{
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (ushort_1 != ushort.MaxValue)
		{
			writer.WriteAttributeString("password", (ushort_1 & 0xFFFF).ToString("X4"));
		}
		if (bool_16)
		{
			writer.WriteAttributeString("sheet", bool_16 ? "1" : "0");
		}
		if (bool_17)
		{
			writer.WriteAttributeString("objects", bool_17 ? "1" : "0");
		}
		if (bool_18)
		{
			writer.WriteAttributeString("scenarios", bool_18 ? "1" : "0");
		}
		if (!bool_19)
		{
			writer.WriteAttributeString("formatCells", bool_19 ? "1" : "0");
		}
		if (!bool_20)
		{
			writer.WriteAttributeString("formatColumns", bool_20 ? "1" : "0");
		}
		if (!bool_21)
		{
			writer.WriteAttributeString("formatRows", bool_21 ? "1" : "0");
		}
		if (!bool_22)
		{
			writer.WriteAttributeString("insertColumns", bool_22 ? "1" : "0");
		}
		if (!bool_23)
		{
			writer.WriteAttributeString("insertRows", bool_23 ? "1" : "0");
		}
		if (!bool_24)
		{
			writer.WriteAttributeString("insertHyperlinks", bool_24 ? "1" : "0");
		}
		if (!bool_25)
		{
			writer.WriteAttributeString("deleteColumns", bool_25 ? "1" : "0");
		}
		if (!bool_26)
		{
			writer.WriteAttributeString("deleteRows", bool_26 ? "1" : "0");
		}
		if (bool_27)
		{
			writer.WriteAttributeString("selectLockedCells", bool_27 ? "1" : "0");
		}
		if (!bool_28)
		{
			writer.WriteAttributeString("sort", bool_28 ? "1" : "0");
		}
		if (!bool_29)
		{
			writer.WriteAttributeString("autoFilter", bool_29 ? "1" : "0");
		}
		if (!bool_30)
		{
			writer.WriteAttributeString("pivotTables", bool_30 ? "1" : "0");
		}
		if (bool_31)
		{
			writer.WriteAttributeString("selectUnlockedCells", bool_31 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
