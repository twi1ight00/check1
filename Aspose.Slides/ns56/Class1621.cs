using System;
using System.Xml;

namespace ns56;

internal class Class1621 : Class1351
{
	public delegate Class1621 Delegate742();

	public delegate void Delegate743(Class1621 elementData);

	public delegate void Delegate744(Class1621 elementData);

	public const int int_0 = 0;

	public const bool bool_0 = true;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = true;

	public const bool bool_6 = false;

	public const Enum183 enum183_0 = Enum183.const_0;

	public const uint uint_0 = uint.MaxValue;

	public Class1623.Delegate748 delegate748_0;

	public Class1623.Delegate750 delegate750_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private int int_1;

	private Enum230 enum230_0;

	private bool bool_7;

	private bool bool_8;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private string string_0;

	private bool bool_13;

	private Enum183 enum183_1;

	private uint uint_1;

	private Class1623 class1623_0;

	private Class1502 class1502_0;

	public static readonly Enum230 enum230_1 = Class2397.smethod_0("normal");

	public int Field
	{
		get
		{
			return int_1;
		}
		set
		{
			int_1 = value;
		}
	}

	public Enum230 Type
	{
		get
		{
			return enum230_0;
		}
		set
		{
			enum230_0 = value;
		}
	}

	public bool DataOnly
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

	public bool LabelOnly
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

	public bool GrandRow
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

	public bool GrandCol
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

	public bool CacheIndex
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

	public bool Outline
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

	public string Offset
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

	public bool CollapsedLevelsAreSubtotals
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

	public Enum183 Axis
	{
		get
		{
			return enum183_1;
		}
		set
		{
			enum183_1 = value;
		}
	}

	public uint FieldPosition
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

	public Class1623 References => class1623_0;

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
				case "references":
					class1623_0 = new Class1623(reader);
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
				case "field":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "type":
					enum230_0 = Class2397.smethod_0(reader.Value);
					break;
				case "dataOnly":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "labelOnly":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "grandRow":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "grandCol":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "cacheIndex":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "outline":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "offset":
					string_0 = reader.Value;
					break;
				case "collapsedLevelsAreSubtotals":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "axis":
					enum183_1 = Class2349.smethod_0(reader.Value);
					break;
				case "fieldPosition":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1621(XmlReader reader)
		: base(reader)
	{
	}

	public Class1621()
	{
	}

	protected override void vmethod_1()
	{
		int_1 = 0;
		enum230_0 = enum230_1;
		bool_7 = true;
		bool_8 = false;
		bool_9 = false;
		bool_10 = false;
		bool_11 = false;
		bool_12 = true;
		bool_13 = false;
		enum183_1 = Enum183.const_0;
		uint_1 = uint.MaxValue;
	}

	protected override void vmethod_2()
	{
		delegate748_0 = method_3;
		delegate750_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (int_1 != 0)
		{
			writer.WriteAttributeString("field", XmlConvert.ToString(int_1));
		}
		if (enum230_0 != enum230_1)
		{
			writer.WriteAttributeString("type", Class2397.smethod_1(enum230_0));
		}
		if (!bool_7)
		{
			writer.WriteAttributeString("dataOnly", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("labelOnly", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("grandRow", bool_9 ? "1" : "0");
		}
		if (bool_10)
		{
			writer.WriteAttributeString("grandCol", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("cacheIndex", bool_11 ? "1" : "0");
		}
		if (!bool_12)
		{
			writer.WriteAttributeString("outline", bool_12 ? "1" : "0");
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("offset", string_0);
		}
		if (bool_13)
		{
			writer.WriteAttributeString("collapsedLevelsAreSubtotals", bool_13 ? "1" : "0");
		}
		if (enum183_1 != 0)
		{
			writer.WriteAttributeString("axis", Class2349.smethod_1(enum183_1));
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("fieldPosition", XmlConvert.ToString(uint_1));
		}
		if (class1623_0 != null)
		{
			class1623_0.vmethod_4("ssml", writer, "references");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1623 method_3()
	{
		if (class1623_0 != null)
		{
			throw new Exception("Only one <references> element can be added.");
		}
		class1623_0 = new Class1623();
		return class1623_0;
	}

	private void method_4(Class1623 _references)
	{
		class1623_0 = _references;
	}

	private Class1502 method_5()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_6(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
