using System;
using System.Xml;

namespace ns56;

internal class Class1444 : Class1351
{
	public delegate Class1444 Delegate294();

	public delegate void Delegate295(Class1444 elementData);

	public delegate void Delegate296(Class1444 elementData);

	public const bool bool_0 = false;

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = true;

	public const bool bool_5 = true;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const bool bool_8 = true;

	public const bool bool_9 = true;

	public const bool bool_10 = true;

	public const int int_0 = 0;

	public const int int_1 = 0;

	public const uint uint_1 = 600u;

	public const bool bool_11 = true;

	public const bool bool_12 = true;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private string string_0;

	private Guid guid_0;

	private bool bool_13;

	private uint uint_2;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private bool bool_17;

	private bool bool_18;

	private bool bool_19;

	private bool bool_20;

	private bool bool_21;

	private bool bool_22;

	private bool bool_23;

	private int int_2;

	private int int_3;

	private uint uint_3;

	private uint uint_4;

	private uint uint_5;

	private uint uint_6;

	private bool bool_24;

	private bool bool_25;

	private Enum191 enum191_0;

	private Enum220 enum220_0;

	private Class1502 class1502_0;

	public static readonly Enum191 enum191_1 = Class2358.smethod_0("commIndicator");

	public static readonly Enum220 enum220_1 = Class2387.smethod_0("all");

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

	public Guid Guid
	{
		get
		{
			return guid_0;
		}
		set
		{
			guid_0 = value;
		}
	}

	public bool AutoUpdate
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

	public uint MergeInterval
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

	public bool ChangesSavedWin
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

	public bool OnlySync
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

	public bool PersonalView
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

	public bool IncludePrintSettings
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

	public bool IncludeHiddenRowCol
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

	public bool Maximized
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

	public bool Minimized
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

	public bool ShowHorizontalScroll
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

	public bool ShowVerticalScroll
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

	public bool ShowSheetTabs
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

	public int XWindow
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

	public int YWindow
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

	public uint WindowWidth
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

	public uint WindowHeight
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

	public uint TabRatio
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

	public uint ActiveSheetId
	{
		get
		{
			return uint_6;
		}
		set
		{
			uint_6 = value;
		}
	}

	public bool ShowFormulaBar
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

	public bool ShowStatusbar
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

	public Enum191 ShowComments
	{
		get
		{
			return enum191_0;
		}
		set
		{
			enum191_0 = value;
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
				string localName2;
				if ((localName2 = reader.LocalName) != null && localName2 == "extLst")
				{
					class1502_0 = new Class1502(reader);
					continue;
				}
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
				case "guid":
					guid_0 = new Guid(reader.Value);
					break;
				case "autoUpdate":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "mergeInterval":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "changesSavedWin":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "onlySync":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "personalView":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "includePrintSettings":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "includeHiddenRowCol":
					bool_18 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "maximized":
					bool_19 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "minimized":
					bool_20 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showHorizontalScroll":
					bool_21 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showVerticalScroll":
					bool_22 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showSheetTabs":
					bool_23 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "xWindow":
					int_2 = XmlConvert.ToInt32(reader.Value);
					break;
				case "yWindow":
					int_3 = XmlConvert.ToInt32(reader.Value);
					break;
				case "windowWidth":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "windowHeight":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "tabRatio":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "activeSheetId":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "showFormulaBar":
					bool_24 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showStatusbar":
					bool_25 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "showComments":
					enum191_0 = Class2358.smethod_0(reader.Value);
					break;
				case "showObjects":
					enum220_0 = Class2387.smethod_0(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1444(XmlReader reader)
		: base(reader)
	{
	}

	public Class1444()
	{
	}

	protected override void vmethod_1()
	{
		guid_0 = Guid.Empty;
		bool_13 = false;
		uint_2 = uint.MaxValue;
		bool_14 = false;
		bool_15 = false;
		bool_16 = false;
		bool_17 = true;
		bool_18 = true;
		bool_19 = false;
		bool_20 = false;
		bool_21 = true;
		bool_22 = true;
		bool_23 = true;
		int_2 = 0;
		int_3 = 0;
		uint_5 = 600u;
		bool_24 = true;
		bool_25 = true;
		enum191_0 = enum191_1;
		enum220_0 = enum220_1;
	}

	protected override void vmethod_2()
	{
		delegate385_0 = method_3;
		delegate387_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("name", string_0);
		writer.WriteAttributeString("guid", "{" + XmlConvert.ToString(guid_0).ToUpper() + "}");
		if (bool_13)
		{
			writer.WriteAttributeString("autoUpdate", bool_13 ? "1" : "0");
		}
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("mergeInterval", XmlConvert.ToString(uint_2));
		}
		if (bool_14)
		{
			writer.WriteAttributeString("changesSavedWin", bool_14 ? "1" : "0");
		}
		if (bool_15)
		{
			writer.WriteAttributeString("onlySync", bool_15 ? "1" : "0");
		}
		if (bool_16)
		{
			writer.WriteAttributeString("personalView", bool_16 ? "1" : "0");
		}
		if (!bool_17)
		{
			writer.WriteAttributeString("includePrintSettings", bool_17 ? "1" : "0");
		}
		if (!bool_18)
		{
			writer.WriteAttributeString("includeHiddenRowCol", bool_18 ? "1" : "0");
		}
		if (bool_19)
		{
			writer.WriteAttributeString("maximized", bool_19 ? "1" : "0");
		}
		if (bool_20)
		{
			writer.WriteAttributeString("minimized", bool_20 ? "1" : "0");
		}
		if (!bool_21)
		{
			writer.WriteAttributeString("showHorizontalScroll", bool_21 ? "1" : "0");
		}
		if (!bool_22)
		{
			writer.WriteAttributeString("showVerticalScroll", bool_22 ? "1" : "0");
		}
		if (!bool_23)
		{
			writer.WriteAttributeString("showSheetTabs", bool_23 ? "1" : "0");
		}
		if (int_2 != 0)
		{
			writer.WriteAttributeString("xWindow", XmlConvert.ToString(int_2));
		}
		if (int_3 != 0)
		{
			writer.WriteAttributeString("yWindow", XmlConvert.ToString(int_3));
		}
		writer.WriteAttributeString("windowWidth", XmlConvert.ToString(uint_3));
		writer.WriteAttributeString("windowHeight", XmlConvert.ToString(uint_4));
		if (uint_5 != 600)
		{
			writer.WriteAttributeString("tabRatio", XmlConvert.ToString(uint_5));
		}
		writer.WriteAttributeString("activeSheetId", XmlConvert.ToString(uint_6));
		if (!bool_24)
		{
			writer.WriteAttributeString("showFormulaBar", bool_24 ? "1" : "0");
		}
		if (!bool_25)
		{
			writer.WriteAttributeString("showStatusbar", bool_25 ? "1" : "0");
		}
		if (enum191_0 != enum191_1)
		{
			writer.WriteAttributeString("showComments", Class2358.smethod_1(enum191_0));
		}
		if (enum220_0 != enum220_1)
		{
			writer.WriteAttributeString("showObjects", Class2387.smethod_1(enum220_0));
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1502 method_3()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_4(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
