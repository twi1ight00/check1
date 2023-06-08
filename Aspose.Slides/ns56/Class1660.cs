using System;
using System.Xml;

namespace ns56;

internal class Class1660 : Class1351
{
	public delegate Class1660 Delegate859();

	public delegate void Delegate860(Class1660 elementData);

	public delegate void Delegate861(Class1660 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const byte byte_0 = 0;

	public const byte byte_1 = 0;

	public const byte byte_2 = 0;

	public const byte byte_3 = 0;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_1;

	private bool bool_7;

	private bool bool_8;

	private uint uint_2;

	private bool bool_9;

	private string string_0;

	private bool bool_10;

	private bool bool_11;

	private byte byte_4;

	private byte byte_5;

	private byte byte_6;

	private byte byte_7;

	private bool bool_12;

	private bool bool_13;

	private string string_1;

	private string string_2;

	private string string_3;

	private string string_4;

	private string string_5;

	private string string_6;

	private string string_7;

	private string string_8;

	private string string_9;

	private string string_10;

	private string string_11;

	private string string_12;

	private Class1502 class1502_0;

	public uint RId
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

	public bool Ua
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

	public bool Ra
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

	public bool CustomView
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

	public bool Function
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

	public bool OldFunction
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

	public byte FunctionGroupId
	{
		get
		{
			return byte_4;
		}
		set
		{
			byte_4 = value;
		}
	}

	public byte OldFunctionGroupId
	{
		get
		{
			return byte_5;
		}
		set
		{
			byte_5 = value;
		}
	}

	public byte ShortcutKey
	{
		get
		{
			return byte_6;
		}
		set
		{
			byte_6 = value;
		}
	}

	public byte OldShortcutKey
	{
		get
		{
			return byte_7;
		}
		set
		{
			byte_7 = value;
		}
	}

	public bool Hidden
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

	public bool OldHidden
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

	public string CustomMenu
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

	public string OldCustomMenu
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

	public string OldDescription
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

	public string Help
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

	public string OldHelp
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

	public string StatusBar
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

	public string OldStatusBar
	{
		get
		{
			return string_8;
		}
		set
		{
			string_8 = value;
		}
	}

	public string Comment
	{
		get
		{
			return string_9;
		}
		set
		{
			string_9 = value;
		}
	}

	public string OldComment
	{
		get
		{
			return string_10;
		}
		set
		{
			string_10 = value;
		}
	}

	public string Formula
	{
		get
		{
			return string_11;
		}
		set
		{
			string_11 = value;
		}
	}

	public string OldFormula
	{
		get
		{
			return string_12;
		}
		set
		{
			string_12 = value;
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
			if (reader.NodeType != XmlNodeType.Element)
			{
				continue;
			}
			switch (reader.LocalName)
			{
			case "extLst":
				class1502_0 = new Class1502(reader);
				break;
			case "oldFormula":
				string_12 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_12 += reader.ReadString();
					}
				}
				break;
			case "formula":
				string_11 = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						string_11 += reader.ReadString();
					}
				}
				break;
			default:
				reader.Skip();
				flag = true;
				break;
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
				case "rId":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "ua":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ra":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "localSheetId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "customView":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "name":
					string_0 = reader.Value;
					break;
				case "function":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "oldFunction":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "functionGroupId":
					byte_4 = XmlConvert.ToByte(reader.Value);
					break;
				case "oldFunctionGroupId":
					byte_5 = XmlConvert.ToByte(reader.Value);
					break;
				case "shortcutKey":
					byte_6 = XmlConvert.ToByte(reader.Value);
					break;
				case "oldShortcutKey":
					byte_7 = XmlConvert.ToByte(reader.Value);
					break;
				case "hidden":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "oldHidden":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "customMenu":
					string_1 = reader.Value;
					break;
				case "oldCustomMenu":
					string_2 = reader.Value;
					break;
				case "description":
					string_3 = reader.Value;
					break;
				case "oldDescription":
					string_4 = reader.Value;
					break;
				case "help":
					string_5 = reader.Value;
					break;
				case "oldHelp":
					string_6 = reader.Value;
					break;
				case "statusBar":
					string_7 = reader.Value;
					break;
				case "oldStatusBar":
					string_8 = reader.Value;
					break;
				case "comment":
					string_9 = reader.Value;
					break;
				case "oldComment":
					string_10 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1660(XmlReader reader)
		: base(reader)
	{
	}

	public Class1660()
	{
	}

	protected override void vmethod_1()
	{
		bool_7 = false;
		bool_8 = false;
		uint_2 = uint.MaxValue;
		bool_9 = false;
		bool_10 = false;
		bool_11 = false;
		byte_4 = 0;
		byte_5 = 0;
		byte_6 = 0;
		byte_7 = 0;
		bool_12 = false;
		bool_13 = false;
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
		writer.WriteAttributeString("rId", XmlConvert.ToString(uint_1));
		if (bool_7)
		{
			writer.WriteAttributeString("ua", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("ra", bool_8 ? "1" : "0");
		}
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("localSheetId", XmlConvert.ToString(uint_2));
		}
		if (bool_9)
		{
			writer.WriteAttributeString("customView", bool_9 ? "1" : "0");
		}
		writer.WriteAttributeString("name", string_0);
		if (bool_10)
		{
			writer.WriteAttributeString("function", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("oldFunction", bool_11 ? "1" : "0");
		}
		if (byte_4 != 0)
		{
			writer.WriteAttributeString("functionGroupId", XmlConvert.ToString(byte_4));
		}
		if (byte_5 != 0)
		{
			writer.WriteAttributeString("oldFunctionGroupId", XmlConvert.ToString(byte_5));
		}
		if (byte_6 != 0)
		{
			writer.WriteAttributeString("shortcutKey", XmlConvert.ToString(byte_6));
		}
		if (byte_7 != 0)
		{
			writer.WriteAttributeString("oldShortcutKey", XmlConvert.ToString(byte_7));
		}
		if (bool_12)
		{
			writer.WriteAttributeString("hidden", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("oldHidden", bool_13 ? "1" : "0");
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("customMenu", string_1);
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("oldCustomMenu", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("description", string_3);
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("oldDescription", string_4);
		}
		if (string_5 != null)
		{
			writer.WriteAttributeString("help", string_5);
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("oldHelp", string_6);
		}
		if (string_7 != null)
		{
			writer.WriteAttributeString("statusBar", string_7);
		}
		if (string_8 != null)
		{
			writer.WriteAttributeString("oldStatusBar", string_8);
		}
		if (string_9 != null)
		{
			writer.WriteAttributeString("comment", string_9);
		}
		if (string_10 != null)
		{
			writer.WriteAttributeString("oldComment", string_10);
		}
		if (string_11 != null)
		{
			method_1("ssml", writer, "formula", string_11);
		}
		if (string_12 != null)
		{
			method_1("ssml", writer, "oldFormula", string_12);
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
