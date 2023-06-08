using System.Xml;

namespace ns56;

internal class Class1491 : Class1351
{
	public delegate Class1491 Delegate350();

	public delegate void Delegate351(Class1491 elementData);

	public delegate void Delegate352(Class1491 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const uint uint_1 = uint.MaxValue;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	private string string_0;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private uint uint_2;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private uint uint_3;

	private string string_6;

	private bool bool_10;

	private bool bool_11;

	private string string_7;

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

	public string Comment
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

	public string CustomMenu
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

	public string Description
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

	public string Help
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

	public string StatusBar
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

	public uint LocalSheetId
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

	public bool Hidden
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

	public bool Function
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

	public bool VbProcedure
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

	public bool Xlm
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

	public uint FunctionGroupId
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

	public string ShortcutKey
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

	public bool PublishToServer
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

	public bool WorkbookParameter
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

	public string Value
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

	protected override void vmethod_0(XmlReader reader)
	{
		_ = reader.LocalName;
		method_2(reader);
		if (!reader.IsEmptyElement)
		{
			reader.Read();
			string_7 = reader.Value;
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
				case "comment":
					string_1 = reader.Value;
					break;
				case "customMenu":
					string_2 = reader.Value;
					break;
				case "description":
					string_3 = reader.Value;
					break;
				case "help":
					string_4 = reader.Value;
					break;
				case "statusBar":
					string_5 = reader.Value;
					break;
				case "localSheetId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "hidden":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "function":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "vbProcedure":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "xlm":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "functionGroupId":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "shortcutKey":
					string_6 = reader.Value;
					break;
				case "publishToServer":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "workbookParameter":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1491(XmlReader reader)
		: base(reader)
	{
	}

	public Class1491()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = uint.MaxValue;
		bool_6 = false;
		bool_7 = false;
		bool_8 = false;
		bool_9 = false;
		uint_3 = uint.MaxValue;
		bool_10 = false;
		bool_11 = false;
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
		if (string_1 != null)
		{
			writer.WriteAttributeString("comment", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("customMenu", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("description", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("help", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("statusBar", string_5);
		}
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("localSheetId", XmlConvert.ToString(uint_2));
		}
		if (bool_6)
		{
			writer.WriteAttributeString("hidden", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("function", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("vbProcedure", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("xlm", bool_9 ? "1" : "0");
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("functionGroupId", XmlConvert.ToString(uint_3));
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("shortcutKey", string_6);
		}
		if (bool_10)
		{
			writer.WriteAttributeString("publishToServer", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("workbookParameter", bool_11 ? "1" : "0");
		}
		writer.WriteString(string_7);
		writer.WriteEndElement();
	}
}
