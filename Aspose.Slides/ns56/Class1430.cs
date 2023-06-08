using System;
using System.Xml;

namespace ns56;

internal class Class1430 : Class1351
{
	public delegate Class1430 Delegate252();

	public delegate void Delegate253(Class1430 elementData);

	public delegate void Delegate254(Class1430 elementData);

	public const bool bool_0 = false;

	public const uint uint_0 = 0u;

	public const uint uint_1 = uint.MaxValue;

	public const uint uint_2 = 1u;

	public const byte byte_0 = 0;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public Class1485.Delegate332 delegate332_0;

	public Class1485.Delegate334 delegate334_0;

	public Class1595.Delegate664 delegate664_0;

	public Class1595.Delegate666 delegate666_0;

	public Class1738.Delegate1093 delegate1093_0;

	public Class1738.Delegate1095 delegate1095_0;

	public Class1724.Delegate1051 delegate1051_0;

	public Class1724.Delegate1053 delegate1053_0;

	public Class1613.Delegate718 delegate718_0;

	public Class1613.Delegate720 delegate720_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_3;

	private string string_0;

	private string string_1;

	private bool bool_8;

	private uint uint_4;

	private string string_2;

	private string string_3;

	private uint uint_5;

	private uint uint_6;

	private byte byte_1;

	private byte byte_2;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private Enum193 enum193_0;

	private string string_4;

	private Class1485 class1485_0;

	private Class1595 class1595_0;

	private Class1738 class1738_0;

	private Class1724 class1724_0;

	private Class1613 class1613_0;

	private Class1502 class1502_0;

	public static readonly Enum193 enum193_1 = Class2360.smethod_0("integrated");

	public uint Id
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

	public string SourceFile
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

	public string OdcFile
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

	public bool KeepAlive
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

	public uint Interval
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

	public string Name
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

	public uint Type
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

	public uint ReconnectionMethod
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

	public byte RefreshedVersion
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

	public byte MinRefreshableVersion
	{
		get
		{
			return byte_2;
		}
		set
		{
			byte_2 = value;
		}
	}

	public bool SavePassword
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

	public bool New
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

	public bool Deleted
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

	public bool OnlyUseConnectionFile
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

	public bool Background
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

	public bool RefreshOnLoad
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

	public bool SaveData
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

	public Enum193 Credentials
	{
		get
		{
			return enum193_0;
		}
		set
		{
			enum193_0 = value;
		}
	}

	public string SingleSignOnId
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

	public Class1485 DbPr => class1485_0;

	public Class1595 OlapPr => class1595_0;

	public Class1738 WebPr => class1738_0;

	public Class1724 TextPr => class1724_0;

	public Class1613 Parameters => class1613_0;

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
				case "dbPr":
					class1485_0 = new Class1485(reader);
					break;
				case "olapPr":
					class1595_0 = new Class1595(reader);
					break;
				case "webPr":
					class1738_0 = new Class1738(reader);
					break;
				case "textPr":
					class1724_0 = new Class1724(reader);
					break;
				case "parameters":
					class1613_0 = new Class1613(reader);
					break;
				case "extLst":
					class1502_0 = new Class1502(reader);
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
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "sourceFile":
					string_0 = reader.Value;
					break;
				case "odcFile":
					string_1 = reader.Value;
					break;
				case "keepAlive":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "interval":
					uint_4 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "name":
					string_2 = reader.Value;
					break;
				case "description":
					string_3 = reader.Value;
					break;
				case "type":
					uint_5 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "reconnectionMethod":
					uint_6 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "refreshedVersion":
					byte_1 = XmlConvert.ToByte(reader.Value);
					break;
				case "minRefreshableVersion":
					byte_2 = XmlConvert.ToByte(reader.Value);
					break;
				case "savePassword":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "new":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "deleted":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "onlyUseConnectionFile":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "background":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "refreshOnLoad":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "saveData":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "credentials":
					enum193_0 = Class2360.smethod_0(reader.Value);
					break;
				case "singleSignOnId":
					string_4 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1430(XmlReader reader)
		: base(reader)
	{
	}

	public Class1430()
	{
	}

	protected override void vmethod_1()
	{
		bool_8 = false;
		uint_4 = 0u;
		uint_5 = uint.MaxValue;
		uint_6 = 1u;
		byte_2 = 0;
		bool_9 = false;
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
		bool_14 = false;
		bool_15 = false;
		enum193_0 = enum193_1;
	}

	protected override void vmethod_2()
	{
		delegate332_0 = method_3;
		delegate334_0 = method_4;
		delegate664_0 = method_5;
		delegate666_0 = method_6;
		delegate1093_0 = method_7;
		delegate1095_0 = method_8;
		delegate1051_0 = method_9;
		delegate1053_0 = method_10;
		delegate718_0 = method_11;
		delegate720_0 = method_12;
		delegate385_0 = method_13;
		delegate387_0 = method_14;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		writer.WriteAttributeString("id", XmlConvert.ToString(uint_3));
		if (string_0 != null)
		{
			writer.WriteAttributeString("sourceFile", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("odcFile", string_1);
		}
		if (bool_8)
		{
			writer.WriteAttributeString("keepAlive", bool_8 ? "1" : "0");
		}
		if (uint_4 != 0)
		{
			writer.WriteAttributeString("interval", XmlConvert.ToString(uint_4));
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("name", string_2);
		}
		if (string_3 != null)
		{
			writer.WriteAttributeString("description", string_3);
		}
		if (uint_5 != uint.MaxValue)
		{
			writer.WriteAttributeString("type", XmlConvert.ToString(uint_5));
		}
		if (uint_6 != 1)
		{
			writer.WriteAttributeString("reconnectionMethod", XmlConvert.ToString(uint_6));
		}
		writer.WriteAttributeString("refreshedVersion", XmlConvert.ToString(byte_1));
		if (byte_2 != 0)
		{
			writer.WriteAttributeString("minRefreshableVersion", XmlConvert.ToString(byte_2));
		}
		if (bool_9)
		{
			writer.WriteAttributeString("savePassword", bool_9 ? "1" : "0");
		}
		if (bool_10)
		{
			writer.WriteAttributeString("new", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("deleted", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("onlyUseConnectionFile", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("background", bool_13 ? "1" : "0");
		}
		if (bool_14)
		{
			writer.WriteAttributeString("refreshOnLoad", bool_14 ? "1" : "0");
		}
		if (bool_15)
		{
			writer.WriteAttributeString("saveData", bool_15 ? "1" : "0");
		}
		if (enum193_0 != enum193_1)
		{
			writer.WriteAttributeString("credentials", Class2360.smethod_1(enum193_0));
		}
		if (string_4 != null)
		{
			writer.WriteAttributeString("singleSignOnId", string_4);
		}
		if (class1485_0 != null)
		{
			class1485_0.vmethod_4("ssml", writer, "dbPr");
		}
		if (class1595_0 != null)
		{
			class1595_0.vmethod_4("ssml", writer, "olapPr");
		}
		if (class1738_0 != null)
		{
			class1738_0.vmethod_4("ssml", writer, "webPr");
		}
		if (class1724_0 != null)
		{
			class1724_0.vmethod_4("ssml", writer, "textPr");
		}
		if (class1613_0 != null)
		{
			class1613_0.vmethod_4("ssml", writer, "parameters");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1485 method_3()
	{
		if (class1485_0 != null)
		{
			throw new Exception("Only one <dbPr> element can be added.");
		}
		class1485_0 = new Class1485();
		return class1485_0;
	}

	private void method_4(Class1485 _dbPr)
	{
		class1485_0 = _dbPr;
	}

	private Class1595 method_5()
	{
		if (class1595_0 != null)
		{
			throw new Exception("Only one <olapPr> element can be added.");
		}
		class1595_0 = new Class1595();
		return class1595_0;
	}

	private void method_6(Class1595 _olapPr)
	{
		class1595_0 = _olapPr;
	}

	private Class1738 method_7()
	{
		if (class1738_0 != null)
		{
			throw new Exception("Only one <webPr> element can be added.");
		}
		class1738_0 = new Class1738();
		return class1738_0;
	}

	private void method_8(Class1738 _webPr)
	{
		class1738_0 = _webPr;
	}

	private Class1724 method_9()
	{
		if (class1724_0 != null)
		{
			throw new Exception("Only one <textPr> element can be added.");
		}
		class1724_0 = new Class1724();
		return class1724_0;
	}

	private void method_10(Class1724 _textPr)
	{
		class1724_0 = _textPr;
	}

	private Class1613 method_11()
	{
		if (class1613_0 != null)
		{
			throw new Exception("Only one <parameters> element can be added.");
		}
		class1613_0 = new Class1613();
		return class1613_0;
	}

	private void method_12(Class1613 _parameters)
	{
		class1613_0 = _parameters;
	}

	private Class1502 method_13()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_14(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
