using System.Xml;

namespace ns56;

internal class Class1588 : Class1351
{
	public delegate Class1588 Delegate643();

	public delegate void Delegate644(Class1588 elementData);

	public delegate void Delegate645(Class1588 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const bool bool_8 = false;

	public const bool bool_9 = false;

	public const bool bool_10 = false;

	public const bool bool_11 = false;

	public const bool bool_12 = false;

	public const bool bool_13 = false;

	public const bool bool_14 = false;

	public const bool bool_15 = false;

	public const bool bool_16 = false;

	public const bool bool_17 = false;

	public const bool bool_18 = false;

	public const bool bool_19 = false;

	public const bool bool_20 = false;

	public const bool bool_21 = false;

	public const bool bool_22 = false;

	public const bool bool_23 = false;

	public const bool bool_24 = false;

	public const bool bool_25 = false;

	private string string_0;

	private uint uint_0;

	private bool bool_26;

	private bool bool_27;

	private bool bool_28;

	private bool bool_29;

	private bool bool_30;

	private bool bool_31;

	private bool bool_32;

	private bool bool_33;

	private bool bool_34;

	private bool bool_35;

	private bool bool_36;

	private bool bool_37;

	private bool bool_38;

	private bool bool_39;

	private bool bool_40;

	private bool bool_41;

	private bool bool_42;

	private bool bool_43;

	private bool bool_44;

	private bool bool_45;

	private bool bool_46;

	private bool bool_47;

	private bool bool_48;

	private bool bool_49;

	private bool bool_50;

	private bool bool_51;

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

	public uint MinSupportedVersion
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

	public bool GhostRow
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

	public bool GhostCol
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

	public bool Edit
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

	public bool Delete
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

	public bool Copy
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

	public bool PasteAll
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

	public bool PasteFormulas
	{
		get
		{
			return bool_32;
		}
		set
		{
			bool_32 = value;
		}
	}

	public bool PasteValues
	{
		get
		{
			return bool_33;
		}
		set
		{
			bool_33 = value;
		}
	}

	public bool PasteFormats
	{
		get
		{
			return bool_34;
		}
		set
		{
			bool_34 = value;
		}
	}

	public bool PasteComments
	{
		get
		{
			return bool_35;
		}
		set
		{
			bool_35 = value;
		}
	}

	public bool PasteDataValidation
	{
		get
		{
			return bool_36;
		}
		set
		{
			bool_36 = value;
		}
	}

	public bool PasteBorders
	{
		get
		{
			return bool_37;
		}
		set
		{
			bool_37 = value;
		}
	}

	public bool PasteColWidths
	{
		get
		{
			return bool_38;
		}
		set
		{
			bool_38 = value;
		}
	}

	public bool PasteNumberFormats
	{
		get
		{
			return bool_39;
		}
		set
		{
			bool_39 = value;
		}
	}

	public bool Merge
	{
		get
		{
			return bool_40;
		}
		set
		{
			bool_40 = value;
		}
	}

	public bool SplitFirst
	{
		get
		{
			return bool_41;
		}
		set
		{
			bool_41 = value;
		}
	}

	public bool SplitAll
	{
		get
		{
			return bool_42;
		}
		set
		{
			bool_42 = value;
		}
	}

	public bool RowColShift
	{
		get
		{
			return bool_43;
		}
		set
		{
			bool_43 = value;
		}
	}

	public bool ClearAll
	{
		get
		{
			return bool_44;
		}
		set
		{
			bool_44 = value;
		}
	}

	public bool ClearFormats
	{
		get
		{
			return bool_45;
		}
		set
		{
			bool_45 = value;
		}
	}

	public bool ClearContents
	{
		get
		{
			return bool_46;
		}
		set
		{
			bool_46 = value;
		}
	}

	public bool ClearComments
	{
		get
		{
			return bool_47;
		}
		set
		{
			bool_47 = value;
		}
	}

	public bool Assign
	{
		get
		{
			return bool_48;
		}
		set
		{
			bool_48 = value;
		}
	}

	public bool Coerce
	{
		get
		{
			return bool_49;
		}
		set
		{
			bool_49 = value;
		}
	}

	public bool Adjust
	{
		get
		{
			return bool_50;
		}
		set
		{
			bool_50 = value;
		}
	}

	public bool CellMeta
	{
		get
		{
			return bool_51;
		}
		set
		{
			bool_51 = value;
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
				case "name":
					string_0 = reader.Value;
					break;
				case "minSupportedVersion":
					uint_0 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ghostRow":
					bool_26 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ghostCol":
					bool_27 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "edit":
					bool_28 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "delete":
					bool_29 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "copy":
					bool_30 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pasteAll":
					bool_31 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pasteFormulas":
					bool_32 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pasteValues":
					bool_33 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pasteFormats":
					bool_34 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pasteComments":
					bool_35 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pasteDataValidation":
					bool_36 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pasteBorders":
					bool_37 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pasteColWidths":
					bool_38 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "pasteNumberFormats":
					bool_39 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "merge":
					bool_40 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "splitFirst":
					bool_41 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "splitAll":
					bool_42 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "rowColShift":
					bool_43 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "clearAll":
					bool_44 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "clearFormats":
					bool_45 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "clearContents":
					bool_46 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "clearComments":
					bool_47 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "assign":
					bool_48 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "coerce":
					bool_49 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "adjust":
					bool_50 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "cellMeta":
					bool_51 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1588(XmlReader reader)
		: base(reader)
	{
	}

	public Class1588()
	{
	}

	protected override void vmethod_1()
	{
		bool_26 = false;
		bool_27 = false;
		bool_28 = false;
		bool_29 = false;
		bool_30 = false;
		bool_31 = false;
		bool_32 = false;
		bool_33 = false;
		bool_34 = false;
		bool_35 = false;
		bool_36 = false;
		bool_37 = false;
		bool_38 = false;
		bool_39 = false;
		bool_40 = false;
		bool_41 = false;
		bool_42 = false;
		bool_43 = false;
		bool_44 = false;
		bool_45 = false;
		bool_46 = false;
		bool_47 = false;
		bool_48 = false;
		bool_49 = false;
		bool_50 = false;
		bool_51 = false;
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
		writer.WriteAttributeString("name", string_0);
		writer.WriteAttributeString("minSupportedVersion", XmlConvert.ToString(uint_0));
		if (bool_26)
		{
			writer.WriteAttributeString("ghostRow", bool_26 ? "1" : "0");
		}
		if (bool_27)
		{
			writer.WriteAttributeString("ghostCol", bool_27 ? "1" : "0");
		}
		if (bool_28)
		{
			writer.WriteAttributeString("edit", bool_28 ? "1" : "0");
		}
		if (bool_29)
		{
			writer.WriteAttributeString("delete", bool_29 ? "1" : "0");
		}
		if (bool_30)
		{
			writer.WriteAttributeString("copy", bool_30 ? "1" : "0");
		}
		if (bool_31)
		{
			writer.WriteAttributeString("pasteAll", bool_31 ? "1" : "0");
		}
		if (bool_32)
		{
			writer.WriteAttributeString("pasteFormulas", bool_32 ? "1" : "0");
		}
		if (bool_33)
		{
			writer.WriteAttributeString("pasteValues", bool_33 ? "1" : "0");
		}
		if (bool_34)
		{
			writer.WriteAttributeString("pasteFormats", bool_34 ? "1" : "0");
		}
		if (bool_35)
		{
			writer.WriteAttributeString("pasteComments", bool_35 ? "1" : "0");
		}
		if (bool_36)
		{
			writer.WriteAttributeString("pasteDataValidation", bool_36 ? "1" : "0");
		}
		if (bool_37)
		{
			writer.WriteAttributeString("pasteBorders", bool_37 ? "1" : "0");
		}
		if (bool_38)
		{
			writer.WriteAttributeString("pasteColWidths", bool_38 ? "1" : "0");
		}
		if (bool_39)
		{
			writer.WriteAttributeString("pasteNumberFormats", bool_39 ? "1" : "0");
		}
		if (bool_40)
		{
			writer.WriteAttributeString("merge", bool_40 ? "1" : "0");
		}
		if (bool_41)
		{
			writer.WriteAttributeString("splitFirst", bool_41 ? "1" : "0");
		}
		if (bool_42)
		{
			writer.WriteAttributeString("splitAll", bool_42 ? "1" : "0");
		}
		if (bool_43)
		{
			writer.WriteAttributeString("rowColShift", bool_43 ? "1" : "0");
		}
		if (bool_44)
		{
			writer.WriteAttributeString("clearAll", bool_44 ? "1" : "0");
		}
		if (bool_45)
		{
			writer.WriteAttributeString("clearFormats", bool_45 ? "1" : "0");
		}
		if (bool_46)
		{
			writer.WriteAttributeString("clearContents", bool_46 ? "1" : "0");
		}
		if (bool_47)
		{
			writer.WriteAttributeString("clearComments", bool_47 ? "1" : "0");
		}
		if (bool_48)
		{
			writer.WriteAttributeString("assign", bool_48 ? "1" : "0");
		}
		if (bool_49)
		{
			writer.WriteAttributeString("coerce", bool_49 ? "1" : "0");
		}
		if (bool_50)
		{
			writer.WriteAttributeString("adjust", bool_50 ? "1" : "0");
		}
		if (bool_51)
		{
			writer.WriteAttributeString("cellMeta", bool_51 ? "1" : "0");
		}
		writer.WriteEndElement();
	}
}
