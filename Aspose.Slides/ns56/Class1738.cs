using System;
using System.Xml;

namespace ns56;

internal class Class1738 : Class1351
{
	public delegate Class1738 Delegate1093();

	public delegate void Delegate1095(Class1738 elementData);

	public delegate void Delegate1094(Class1738 elementData);

	public const bool bool_0 = false;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const bool bool_8 = false;

	public Class1717.Delegate1030 delegate1030_0;

	public Class1717.Delegate1032 delegate1032_0;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private string string_0;

	private string string_1;

	private bool bool_17;

	private Enum214 enum214_0;

	private string string_2;

	private Class1717 class1717_0;

	public static readonly Enum214 enum214_1 = Class2381.smethod_0("none");

	public bool Xml
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

	public bool SourceData
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

	public bool ParsePre
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

	public bool Consecutive
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

	public bool FirstRow
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

	public bool Xl97
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

	public bool TextDates
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

	public bool Xl2000
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

	public string Url
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

	public string Post
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

	public bool HtmlTables
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

	public Enum214 HtmlFormat
	{
		get
		{
			return enum214_0;
		}
		set
		{
			enum214_0 = value;
		}
	}

	public string EditPage
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

	public Class1717 Tables => class1717_0;

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
				if ((localName2 = reader.LocalName) != null && localName2 == "tables")
				{
					class1717_0 = new Class1717(reader);
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
				case "xml":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "sourceData":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "parsePre":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "consecutive":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "firstRow":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "xl97":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "textDates":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "xl2000":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "url":
					string_0 = reader.Value;
					break;
				case "post":
					string_1 = reader.Value;
					break;
				case "htmlTables":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "htmlFormat":
					enum214_0 = Class2381.smethod_0(reader.Value);
					break;
				case "editPage":
					string_2 = reader.Value;
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1738(XmlReader reader)
		: base(reader)
	{
	}

	public Class1738()
	{
	}

	protected override void vmethod_1()
	{
		bool_9 = false;
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
		bool_14 = false;
		bool_15 = false;
		bool_16 = false;
		bool_17 = false;
		enum214_0 = enum214_1;
	}

	protected override void vmethod_2()
	{
		delegate1030_0 = method_3;
		delegate1032_0 = method_4;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (bool_9)
		{
			writer.WriteAttributeString("xml", bool_9 ? "1" : "0");
		}
		if (bool_10)
		{
			writer.WriteAttributeString("sourceData", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("parsePre", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("consecutive", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("firstRow", bool_13 ? "1" : "0");
		}
		if (bool_14)
		{
			writer.WriteAttributeString("xl97", bool_14 ? "1" : "0");
		}
		if (bool_15)
		{
			writer.WriteAttributeString("textDates", bool_15 ? "1" : "0");
		}
		if (bool_16)
		{
			writer.WriteAttributeString("xl2000", bool_16 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("url", string_0);
		}
		if (string_1 != null)
		{
			writer.WriteAttributeString("post", string_1);
		}
		if (bool_17)
		{
			writer.WriteAttributeString("htmlTables", bool_17 ? "1" : "0");
		}
		if (enum214_0 != enum214_1)
		{
			writer.WriteAttributeString("htmlFormat", Class2381.smethod_1(enum214_0));
		}
		if (string_2 != null)
		{
			writer.WriteAttributeString("editPage", string_2);
		}
		if (class1717_0 != null)
		{
			class1717_0.vmethod_4("ssml", writer, "tables");
		}
		writer.WriteEndElement();
	}

	private Class1717 method_3()
	{
		if (class1717_0 != null)
		{
			throw new Exception("Only one <tables> element can be added.");
		}
		class1717_0 = new Class1717();
		return class1717_0;
	}

	private void method_4(Class1717 _tables)
	{
		class1717_0 = _tables;
	}
}
