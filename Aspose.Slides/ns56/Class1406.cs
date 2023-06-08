using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1406 : Class1351
{
	public delegate Class1406 Delegate180();

	public delegate void Delegate181(Class1406 elementData);

	public delegate void Delegate182(Class1406 elementData);

	public const Enum189 enum189_0 = Enum189.const_0;

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_0 = false;

	public const bool bool_1 = true;

	public const bool bool_2 = false;

	public const bool bool_3 = false;

	public const Enum192 enum192_0 = Enum192.const_0;

	public const Enum249 enum249_0 = Enum249.const_0;

	public const uint uint_1 = uint.MaxValue;

	public const int int_0 = 0;

	public const bool bool_4 = false;

	public Class1421.Delegate225 delegate225_0;

	public Class1421.Delegate227 delegate227_0;

	public Class1446.Delegate300 delegate300_0;

	public Class1446.Delegate302 delegate302_0;

	public Class1551.Delegate532 delegate532_0;

	public Class1551.Delegate534 delegate534_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private Enum189 enum189_1;

	private uint uint_2;

	private int int_1;

	private bool bool_5;

	private bool bool_6;

	private bool bool_7;

	private bool bool_8;

	private Enum192 enum192_1;

	private string string_0;

	private Enum249 enum249_1;

	private uint uint_3;

	private int int_2;

	private bool bool_9;

	private List<string> list_0;

	private Class1421 class1421_0;

	private Class1446 class1446_0;

	private Class1551 class1551_0;

	private Class1502 class1502_0;

	public Enum189 Type
	{
		get
		{
			return enum189_1;
		}
		set
		{
			enum189_1 = value;
		}
	}

	public uint DxfId
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

	public int Priority
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

	public bool StopIfTrue
	{
		get
		{
			return bool_5;
		}
		set
		{
			bool_5 = value;
		}
	}

	public bool AboveAverage
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

	public bool Percent
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

	public bool Bottom
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

	public Enum192 Operator
	{
		get
		{
			return enum192_1;
		}
		set
		{
			enum192_1 = value;
		}
	}

	public string Text
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

	public Enum249 TimePeriod
	{
		get
		{
			return enum249_1;
		}
		set
		{
			enum249_1 = value;
		}
	}

	public uint Rank
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

	public int StdDev
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

	public bool EqualAverage
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

	public string[] FormulaList => list_0.ToArray();

	public Class1421 ColorScale => class1421_0;

	public Class1446 DataBar => class1446_0;

	public Class1551 IconSet => class1551_0;

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
			case "iconSet":
				class1551_0 = new Class1551(reader);
				break;
			case "dataBar":
				class1446_0 = new Class1446(reader);
				break;
			case "colorScale":
				class1421_0 = new Class1421(reader);
				break;
			case "formula":
			{
				string text = reader.ReadString();
				if (!reader.IsEmptyElement)
				{
					while (reader.NodeType != XmlNodeType.EndElement)
					{
						reader.Read();
						text += reader.ReadString();
					}
					list_0.Add(text);
				}
				break;
			}
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
				case "type":
					enum189_1 = Class2356.smethod_0(reader.Value);
					break;
				case "dxfId":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "priority":
					int_1 = XmlConvert.ToInt32(reader.Value);
					break;
				case "stopIfTrue":
					bool_5 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "aboveAverage":
					bool_6 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "percent":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "bottom":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "operator":
					enum192_1 = Class2359.smethod_0(reader.Value);
					break;
				case "text":
					string_0 = reader.Value;
					break;
				case "timePeriod":
					enum249_1 = Class2416.smethod_0(reader.Value);
					break;
				case "rank":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "stdDev":
					int_2 = XmlConvert.ToInt32(reader.Value);
					break;
				case "equalAverage":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1406(XmlReader reader)
		: base(reader)
	{
	}

	public Class1406()
	{
	}

	protected override void vmethod_1()
	{
		enum189_1 = Enum189.const_0;
		uint_2 = uint.MaxValue;
		bool_5 = false;
		bool_6 = true;
		bool_7 = false;
		bool_8 = false;
		enum192_1 = Enum192.const_0;
		enum249_1 = Enum249.const_0;
		uint_3 = uint.MaxValue;
		int_2 = 0;
		bool_9 = false;
		list_0 = new List<string>();
	}

	protected override void vmethod_2()
	{
		delegate225_0 = method_4;
		delegate227_0 = method_5;
		delegate300_0 = method_6;
		delegate302_0 = method_7;
		delegate532_0 = method_8;
		delegate534_0 = method_9;
		delegate385_0 = method_10;
		delegate387_0 = method_11;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (enum189_1 != 0)
		{
			writer.WriteAttributeString("type", Class2356.smethod_1(enum189_1));
		}
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("dxfId", XmlConvert.ToString(uint_2));
		}
		writer.WriteAttributeString("priority", XmlConvert.ToString(int_1));
		if (bool_5)
		{
			writer.WriteAttributeString("stopIfTrue", bool_5 ? "1" : "0");
		}
		if (!bool_6)
		{
			writer.WriteAttributeString("aboveAverage", bool_6 ? "1" : "0");
		}
		if (bool_7)
		{
			writer.WriteAttributeString("percent", bool_7 ? "1" : "0");
		}
		if (bool_8)
		{
			writer.WriteAttributeString("bottom", bool_8 ? "1" : "0");
		}
		if (enum192_1 != 0)
		{
			writer.WriteAttributeString("operator", Class2359.smethod_1(enum192_1));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("text", string_0);
		}
		if (enum249_1 != 0)
		{
			writer.WriteAttributeString("timePeriod", Class2416.smethod_1(enum249_1));
		}
		if (uint_3 != uint.MaxValue)
		{
			writer.WriteAttributeString("rank", XmlConvert.ToString(uint_3));
		}
		if (int_2 != 0)
		{
			writer.WriteAttributeString("stdDev", XmlConvert.ToString(int_2));
		}
		if (bool_9)
		{
			writer.WriteAttributeString("equalAverage", bool_9 ? "1" : "0");
		}
		foreach (string item in list_0)
		{
			method_1("ssml", writer, "formula", item);
		}
		if (class1421_0 != null)
		{
			class1421_0.vmethod_4("ssml", writer, "colorScale");
		}
		if (class1446_0 != null)
		{
			class1446_0.vmethod_4("ssml", writer, "dataBar");
		}
		if (class1551_0 != null)
		{
			class1551_0.vmethod_4("ssml", writer, "iconSet");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	public void method_3(string str)
	{
		list_0.Add(str);
	}

	private Class1421 method_4()
	{
		if (class1421_0 != null)
		{
			throw new Exception("Only one <colorScale> element can be added.");
		}
		class1421_0 = new Class1421();
		return class1421_0;
	}

	private void method_5(Class1421 _colorScale)
	{
		class1421_0 = _colorScale;
	}

	private Class1446 method_6()
	{
		if (class1446_0 != null)
		{
			throw new Exception("Only one <dataBar> element can be added.");
		}
		class1446_0 = new Class1446();
		return class1446_0;
	}

	private void method_7(Class1446 _dataBar)
	{
		class1446_0 = _dataBar;
	}

	private Class1551 method_8()
	{
		if (class1551_0 != null)
		{
			throw new Exception("Only one <iconSet> element can be added.");
		}
		class1551_0 = new Class1551();
		return class1551_0;
	}

	private void method_9(Class1551 _iconSet)
	{
		class1551_0 = _iconSet;
	}

	private Class1502 method_10()
	{
		if (class1502_0 != null)
		{
			throw new Exception("Only one <extLst> element can be added.");
		}
		class1502_0 = new Class1502();
		return class1502_0;
	}

	private void method_11(Class1502 _extLst)
	{
		class1502_0 = _extLst;
	}
}
