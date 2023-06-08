using System;
using System.Xml;

namespace ns56;

internal class Class1724 : Class1351
{
	public delegate Class1724 Delegate1051();

	public delegate void Delegate1053(Class1724 elementData);

	public delegate void Delegate1052(Class1724 elementData);

	public const bool bool_0 = true;

	public const uint uint_0 = 1252u;

	public const uint uint_1 = 1u;

	public const string string_0 = "";

	public const bool bool_1 = true;

	public const string string_1 = ".";

	public const string string_2 = ",";

	public const bool bool_2 = true;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public Class1723.Delegate1048 delegate1048_0;

	public Class1723.Delegate1050 delegate1050_0;

	private bool bool_7;

	private Enum205 enum205_0;

	private uint uint_2;

	private uint uint_3;

	private string string_3;

	private bool bool_8;

	private string string_4;

	private string string_5;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private Enum233 enum233_0;

	private string string_6;

	private Class1723 class1723_0;

	public static readonly Enum205 enum205_1 = Class2372.smethod_0("win");

	public static readonly Enum233 enum233_1 = Class2400.smethod_0("doubleQuote");

	public bool Prompt
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

	public Enum205 FileType
	{
		get
		{
			return enum205_0;
		}
		set
		{
			enum205_0 = value;
		}
	}

	public uint CodePage
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

	public uint FirstRow
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
			return string_3;
		}
		set
		{
			string_3 = value;
		}
	}

	public bool Delimited
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

	public string Decimal
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

	public string Thousands
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

	public bool Tab
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

	public bool Space
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

	public bool Comma
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

	public bool Semicolon
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

	public bool Consecutive
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

	public Enum233 Qualifier
	{
		get
		{
			return enum233_0;
		}
		set
		{
			enum233_0 = value;
		}
	}

	public string Delimiter
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

	public Class1723 TextFields => class1723_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "textFields")
				{
					class1723_0 = new Class1723(reader);
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
				case "prompt":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "fileType":
					enum205_0 = Class2372.smethod_0(reader.Value);
					break;
				case "codePage":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "firstRow":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "sourceFile":
					string_3 = reader.Value;
					break;
				case "delimited":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "decimal":
					string_4 = reader.Value;
					break;
				case "thousands":
					string_5 = reader.Value;
					break;
				case "tab":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "space":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "comma":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "semicolon":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "consecutive":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "qualifier":
					enum233_0 = Class2400.smethod_0(reader.Value);
					break;
				case "delimiter":
					string_6 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1724(XmlReader reader)
		: base(reader)
	{
	}

	public Class1724()
	{
	}

	protected override void vmethod_1()
	{
		bool_7 = true;
		enum205_0 = enum205_1;
		uint_2 = 1252u;
		uint_3 = 1u;
		string_3 = "";
		bool_8 = true;
		string_4 = ".";
		string_5 = ",";
		bool_9 = true;
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
		enum233_0 = enum233_1;
	}

	protected override void vmethod_2()
	{
		delegate1048_0 = method_3;
		delegate1050_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!bool_7)
		{
			writer.WriteAttributeString("prompt", bool_7 ? "1" : "0");
		}
		if (enum205_0 != enum205_1)
		{
			writer.WriteAttributeString("fileType", Class2372.smethod_1(enum205_0));
		}
		if (uint_2 != 1252)
		{
			writer.WriteAttributeString("codePage", XmlConvert.ToString(uint_2));
		}
		if (uint_3 != 1)
		{
			writer.WriteAttributeString("firstRow", XmlConvert.ToString(uint_3));
		}
		if (string_3 != "")
		{
			writer.WriteAttributeString("sourceFile", string_3);
		}
		if (!bool_8)
		{
			writer.WriteAttributeString("delimited", bool_8 ? "1" : "0");
		}
		if (string_4 != ".")
		{
			writer.WriteAttributeString("decimal", string_4);
		}
		if (string_5 != ",")
		{
			writer.WriteAttributeString("thousands", string_5);
		}
		if (!bool_9)
		{
			writer.WriteAttributeString("tab", bool_9 ? "1" : "0");
		}
		if (bool_10)
		{
			writer.WriteAttributeString("space", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("comma", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("semicolon", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("consecutive", bool_13 ? "1" : "0");
		}
		if (enum233_0 != enum233_1)
		{
			writer.WriteAttributeString("qualifier", Class2400.smethod_1(enum233_0));
		}
		if (string_6 != null)
		{
			writer.WriteAttributeString("delimiter", string_6);
		}
		if (class1723_0 != null)
		{
			class1723_0.vmethod_4("ssml", writer, "textFields");
		}
		writer.WriteEndElement();
	}

	private Class1723 method_3()
	{
		if (class1723_0 != null)
		{
			throw new Exception("Only one <textFields> element can be added.");
		}
		class1723_0 = new Class1723();
		return class1723_0;
	}

	private void method_4(Class1723 _textFields)
	{
		class1723_0 = _textFields;
	}
}
