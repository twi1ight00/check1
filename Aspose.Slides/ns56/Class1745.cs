using System.Xml;

namespace ns56;

internal class Class1745 : Class1351
{
	public delegate void Delegate1116(Class1745 elementData);

	public delegate Class1745 Delegate1114();

	public delegate void Delegate1115(Class1745 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = true;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = true;

	public const bool bool_5 = false;

	public const bool bool_6 = true;

	public const bool bool_7 = false;

	public const bool bool_8 = false;

	public const bool bool_9 = false;

	public const bool bool_10 = false;

	public const bool bool_11 = false;

	public const bool bool_12 = true;

	public const bool bool_13 = false;

	public const uint uint_0 = uint.MaxValue;

	private bool bool_14;

	private Enum220 enum220_0;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private bool bool_20;

	private Enum253 enum253_0;

	private string string_0;

	private bool bool_21;

	private bool bool_22;

	private bool bool_23;

	private bool bool_24;

	private bool bool_25;

	private bool bool_26;

	private bool bool_27;

	private uint uint_1;

	public static readonly Enum220 enum220_1 = Class2387.smethod_0("all");

	public static readonly Enum253 enum253_1 = Class2420.smethod_0("userSet");

	public bool Date1904
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

	public Enum220 ShowObjects
	{
		get
		{
			return enum220_0;
		}
		set
		{
			enum220_0 = value;
		}
	}

	public bool ShowBorderUnselectedTables
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

	public bool FilterPrivacy
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

	public bool PromptedSolutions
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

	public bool ShowInkAnnotation
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

	public bool BackupFile
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

	public bool SaveExternalLinkValues
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

	public Enum253 UpdateLinks
	{
		get
		{
			return enum253_0;
		}
		set
		{
			enum253_0 = value;
		}
	}

	public string CodeName
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

	public bool HidePivotFieldList
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

	public bool ShowPivotChartFilter
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

	public bool AllowRefreshQuery
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

	public bool PublishItems
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

	public bool CheckCompatibility
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

	public bool AutoCompressPictures
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

	public bool RefreshAllConnections
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

	public uint DefaultThemeVersion
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
				case "date1904":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showObjects":
					enum220_0 = Class2387.smethod_0(reader.Value);
					break;
				case "showBorderUnselectedTables":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "filterPrivacy":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "promptedSolutions":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showInkAnnotation":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "backupFile":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "saveExternalLinkValues":
					bool_20 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "updateLinks":
					enum253_0 = Class2420.smethod_0(reader.Value);
					break;
				case "codeName":
					string_0 = reader.Value;
					break;
				case "hidePivotFieldList":
					bool_21 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showPivotChartFilter":
					bool_22 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "allowRefreshQuery":
					bool_23 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "publishItems":
					bool_24 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "checkCompatibility":
					bool_25 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "autoCompressPictures":
					bool_26 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "refreshAllConnections":
					bool_27 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "defaultThemeVersion":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1745(XmlReader reader)
		: base(reader)
	{
	}

	public Class1745()
	{
	}

	protected override void vmethod_1()
	{
		bool_14 = false;
		enum220_0 = enum220_1;
		bool_15 = true;
		bool_16 = false;
		bool_17 = false;
		bool_18 = true;
		bool_19 = false;
		bool_20 = true;
		enum253_0 = enum253_1;
		bool_21 = false;
		bool_22 = false;
		bool_23 = false;
		bool_24 = false;
		bool_25 = false;
		bool_26 = true;
		bool_27 = false;
		uint_1 = uint.MaxValue;
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
		if (bool_14)
		{
			writer.WriteAttributeString("date1904", bool_14 ? "1" : "0");
		}
		if (enum220_0 != enum220_1)
		{
			writer.WriteAttributeString("showObjects", Class2387.smethod_1(enum220_0));
		}
		if (!bool_15)
		{
			writer.WriteAttributeString("showBorderUnselectedTables", bool_15 ? "1" : "0");
		}
		if (bool_16)
		{
			writer.WriteAttributeString("filterPrivacy", bool_16 ? "1" : "0");
		}
		if (bool_17)
		{
			writer.WriteAttributeString("promptedSolutions", bool_17 ? "1" : "0");
		}
		if (!bool_18)
		{
			writer.WriteAttributeString("showInkAnnotation", bool_18 ? "1" : "0");
		}
		if (bool_19)
		{
			writer.WriteAttributeString("backupFile", bool_19 ? "1" : "0");
		}
		if (!bool_20)
		{
			writer.WriteAttributeString("saveExternalLinkValues", bool_20 ? "1" : "0");
		}
		if (enum253_0 != enum253_1)
		{
			writer.WriteAttributeString("updateLinks", Class2420.smethod_1(enum253_0));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("codeName", string_0);
		}
		if (bool_21)
		{
			writer.WriteAttributeString("hidePivotFieldList", bool_21 ? "1" : "0");
		}
		if (bool_22)
		{
			writer.WriteAttributeString("showPivotChartFilter", bool_22 ? "1" : "0");
		}
		if (bool_23)
		{
			writer.WriteAttributeString("allowRefreshQuery", bool_23 ? "1" : "0");
		}
		if (bool_24)
		{
			writer.WriteAttributeString("publishItems", bool_24 ? "1" : "0");
		}
		if (bool_25)
		{
			writer.WriteAttributeString("checkCompatibility", bool_25 ? "1" : "0");
		}
		if (!bool_26)
		{
			writer.WriteAttributeString("autoCompressPictures", bool_26 ? "1" : "0");
		}
		if (bool_27)
		{
			writer.WriteAttributeString("refreshAllConnections", bool_27 ? "1" : "0");
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("defaultThemeVersion", XmlConvert.ToString(uint_1));
		}
		writer.WriteEndElement();
	}
}
