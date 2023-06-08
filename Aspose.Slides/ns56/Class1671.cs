using System;
using System.Collections.Generic;
using System.Xml;

namespace ns56;

internal class Class1671 : Class1351
{
	public delegate Class1671 Delegate892();

	public delegate void Delegate893(Class1671 elementData);

	public delegate void Delegate894(Class1671 elementData);

	public const uint uint_0 = uint.MaxValue;

	public const uint uint_1 = 0u;

	public const bool bool_0 = false;

	public const double double_0 = double.NaN;

	public const bool bool_1 = false;

	public const bool bool_2 = false;

	public const byte byte_0 = 0;

	public const bool bool_3 = false;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public Class1394.Delegate144 delegate144_0;

	public Class1394.Delegate145 delegate145_0;

	public Class1502.Delegate385 delegate385_0;

	public Class1502.Delegate387 delegate387_0;

	private uint uint_2;

	private string string_0;

	private uint uint_3;

	private bool bool_7;

	private double double_1;

	private bool bool_8;

	private bool bool_9;

	private byte byte_1;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private List<Class1394> list_0;

	private Class1502 class1502_0;

	public uint R
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

	public string Spans
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

	public uint S
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

	public bool CustomFormat
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

	public double Ht
	{
		get
		{
			return double_1;
		}
		set
		{
			double_1 = value;
		}
	}

	public bool Hidden
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

	public bool CustomHeight
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

	public byte OutlineLevel
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

	public bool Collapsed
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

	public bool ThickTop
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

	public bool ThickBot
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

	public bool Ph
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

	public Class1394[] CList => list_0.ToArray();

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
				case "c":
				{
					Class1394 item = new Class1394(reader);
					list_0.Add(item);
					break;
				}
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
				case "r":
					uint_2 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "spans":
					string_0 = reader.Value;
					break;
				case "s":
					uint_3 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "customFormat":
					bool_7 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ht":
					double_1 = ToDouble(reader.Value);
					break;
				case "hidden":
					bool_8 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "customHeight":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "outlineLevel":
					byte_1 = XmlConvert.ToByte(reader.Value);
					break;
				case "collapsed":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "thickTop":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "thickBot":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "ph":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1671(XmlReader reader)
		: base(reader)
	{
	}

	public Class1671()
	{
	}

	protected override void vmethod_1()
	{
		uint_2 = uint.MaxValue;
		uint_3 = 0u;
		bool_7 = false;
		double_1 = double.NaN;
		bool_8 = false;
		bool_9 = false;
		byte_1 = 0;
		bool_10 = false;
		bool_11 = false;
		bool_12 = false;
		bool_13 = false;
		list_0 = new List<Class1394>();
	}

	protected override void vmethod_2()
	{
		delegate144_0 = method_3;
		delegate145_0 = method_4;
		delegate385_0 = method_5;
		delegate387_0 = method_6;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (uint_2 != uint.MaxValue)
		{
			writer.WriteAttributeString("r", XmlConvert.ToString(uint_2));
		}
		if (string_0 != null)
		{
			writer.WriteAttributeString("spans", string_0);
		}
		if (uint_3 != 0)
		{
			writer.WriteAttributeString("s", XmlConvert.ToString(uint_3));
		}
		if (bool_7)
		{
			writer.WriteAttributeString("customFormat", bool_7 ? "1" : "0");
		}
		if (!double.IsNaN(double_1))
		{
			writer.WriteAttributeString("ht", XmlConvert.ToString(double_1));
		}
		if (bool_8)
		{
			writer.WriteAttributeString("hidden", bool_8 ? "1" : "0");
		}
		if (bool_9)
		{
			writer.WriteAttributeString("customHeight", bool_9 ? "1" : "0");
		}
		if (byte_1 != 0)
		{
			writer.WriteAttributeString("outlineLevel", XmlConvert.ToString(byte_1));
		}
		if (bool_10)
		{
			writer.WriteAttributeString("collapsed", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("thickTop", bool_11 ? "1" : "0");
		}
		if (bool_12)
		{
			writer.WriteAttributeString("thickBot", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("ph", bool_13 ? "1" : "0");
		}
		foreach (Class1394 item in list_0)
		{
			item.vmethod_4("ssml", writer, "c");
		}
		if (class1502_0 != null)
		{
			class1502_0.vmethod_4("ssml", writer, "extLst");
		}
		writer.WriteEndElement();
	}

	private Class1394 method_3()
	{
		Class1394 @class = new Class1394();
		list_0.Add(@class);
		return @class;
	}

	private void method_4(Class1394 elementData)
	{
		list_0.Add(elementData);
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
