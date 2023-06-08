using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1684 : Class1351
{
	public delegate Class1684 Delegate931();

	public delegate void Delegate933(Class1684 elementData);

	public delegate void Delegate932(Class1684 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = true;

	public const bool bool_2 = false;

	public const bool bool_3 = true;

	public const bool bool_4 = false;

	public const bool bool_5 = false;

	public const bool bool_6 = false;

	public const bool bool_7 = false;

	public const double double_0 = double.NaN;

	public const double double_1 = double.NaN;

	public const uint uint_0 = uint.MaxValue;

	public const bool bool_8 = false;

	public Class2605.Delegate2773 delegate2773_0;

	private bool bool_9;

	private bool bool_10;

	private bool bool_11;

	private bool bool_12;

	private bool bool_13;

	private bool bool_14;

	private bool bool_15;

	private bool bool_16;

	private double double_2;

	private double double_3;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private uint uint_1;

	private bool bool_17;

	private List<Class2605> list_0;

	public static readonly DateTime dateTime_2 = DateTime.MinValue;

	public static readonly DateTime dateTime_3 = DateTime.MinValue;

	public bool ContainsSemiMixedTypes
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

	public bool ContainsNonDate
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

	public bool ContainsDate
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

	public bool ContainsString
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

	public bool ContainsBlank
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

	public bool ContainsMixedTypes
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

	public bool ContainsNumber
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

	public bool ContainsInteger
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

	public double MinValue
	{
		get
		{
			return double_2;
		}
		set
		{
			double_2 = value;
		}
	}

	public double MaxValue
	{
		get
		{
			return double_3;
		}
		set
		{
			double_3 = value;
		}
	}

	public DateTime MinDate
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			dateTime_0 = value;
		}
	}

	public DateTime MaxDate
	{
		get
		{
			return dateTime_1;
		}
		set
		{
			dateTime_1 = value;
		}
	}

	public uint Count
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

	public bool LongText
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

	public Class2605[] ValueList => list_0.ToArray();

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
				case "m":
				{
					Class1590 obj6 = new Class1590(reader);
					list_0.Add(new Class2605("m", obj6));
					break;
				}
				case "n":
				{
					Class1592 obj5 = new Class1592(reader);
					list_0.Add(new Class2605("n", obj5));
					break;
				}
				case "b":
				{
					Class1375 obj4 = new Class1375(reader);
					list_0.Add(new Class2605("b", obj4));
					break;
				}
				case "e":
				{
					Class1501 obj3 = new Class1501(reader);
					list_0.Add(new Class2605("e", obj3));
					break;
				}
				case "s":
				{
					Class1708 obj2 = new Class1708(reader);
					list_0.Add(new Class2605("s", obj2));
					break;
				}
				case "d":
				{
					Class1484 obj = new Class1484(reader);
					list_0.Add(new Class2605("d", obj));
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
				case "containsSemiMixedTypes":
					bool_9 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "containsNonDate":
					bool_10 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "containsDate":
					bool_11 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "containsString":
					bool_12 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "containsBlank":
					bool_13 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "containsMixedTypes":
					bool_14 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "containsNumber":
					bool_15 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "containsInteger":
					bool_16 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "minValue":
					double_2 = ToDouble(reader.Value);
					break;
				case "maxValue":
					double_3 = ToDouble(reader.Value);
					break;
				case "minDate":
					dateTime_0 = DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
					break;
				case "maxDate":
					dateTime_1 = DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
					break;
				case "count":
					uint_1 = (uint)XmlConvert.ToInt64(reader.Value);
					break;
				case "longText":
					bool_17 = XmlConvert.ToBoolean(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1684(XmlReader reader)
		: base(reader)
	{
	}

	public Class1684()
	{
	}

	protected override void vmethod_1()
	{
		bool_9 = true;
		bool_10 = true;
		bool_11 = false;
		bool_12 = true;
		bool_13 = false;
		bool_14 = false;
		bool_15 = false;
		bool_16 = false;
		double_2 = double.NaN;
		double_3 = double.NaN;
		dateTime_0 = dateTime_2;
		dateTime_1 = dateTime_3;
		uint_1 = uint.MaxValue;
		bool_17 = false;
		list_0 = new List<Class2605>();
	}

	protected override void vmethod_2()
	{
		delegate2773_0 = method_3;
	}

	protected override void vmethod_3()
	{
	}

	public override void vmethod_4(string prefix, XmlWriter writer, string elementName)
	{
		writer.WriteStartElement(prefix, elementName, null);
		if (!bool_9)
		{
			writer.WriteAttributeString("containsSemiMixedTypes", bool_9 ? "1" : "0");
		}
		if (!bool_10)
		{
			writer.WriteAttributeString("containsNonDate", bool_10 ? "1" : "0");
		}
		if (bool_11)
		{
			writer.WriteAttributeString("containsDate", bool_11 ? "1" : "0");
		}
		if (!bool_12)
		{
			writer.WriteAttributeString("containsString", bool_12 ? "1" : "0");
		}
		if (bool_13)
		{
			writer.WriteAttributeString("containsBlank", bool_13 ? "1" : "0");
		}
		if (bool_14)
		{
			writer.WriteAttributeString("containsMixedTypes", bool_14 ? "1" : "0");
		}
		if (bool_15)
		{
			writer.WriteAttributeString("containsNumber", bool_15 ? "1" : "0");
		}
		if (bool_16)
		{
			writer.WriteAttributeString("containsInteger", bool_16 ? "1" : "0");
		}
		if (!double.IsNaN(double_2))
		{
			writer.WriteAttributeString("minValue", XmlConvert.ToString(double_2));
		}
		if (!double.IsNaN(double_3))
		{
			writer.WriteAttributeString("maxValue", XmlConvert.ToString(double_3));
		}
		if (dateTime_0 != dateTime_2)
		{
			writer.WriteAttributeString("minDate", XmlConvert.ToString(dateTime_0, "yyyy-MM-ddTHH:mm:ss.fff"));
		}
		if (dateTime_1 != dateTime_3)
		{
			writer.WriteAttributeString("maxDate", XmlConvert.ToString(dateTime_1, "yyyy-MM-ddTHH:mm:ss.fff"));
		}
		if (uint_1 != uint.MaxValue)
		{
			writer.WriteAttributeString("count", XmlConvert.ToString(uint_1));
		}
		if (bool_17)
		{
			writer.WriteAttributeString("longText", bool_17 ? "1" : "0");
		}
		foreach (Class2605 item in list_0)
		{
			switch (item.Name)
			{
			case "m":
				((Class1590)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "n":
				((Class1592)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "b":
				((Class1375)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "e":
				((Class1501)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "s":
				((Class1708)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			case "d":
				((Class1484)item.Object).vmethod_4("ssml", writer, item.Name);
				break;
			}
		}
		writer.WriteEndElement();
	}

	private Class2605 method_3(string elementName)
	{
		Class2605 @class = elementName switch
		{
			"m" => new Class2605("m", new Class1590()), 
			"n" => new Class2605("n", new Class1592()), 
			"b" => new Class2605("b", new Class1375()), 
			"e" => new Class2605("e", new Class1501()), 
			"s" => new Class2605("s", new Class1708()), 
			"d" => new Class2605("d", new Class1484()), 
			_ => throw new Exception("Wrong element: " + elementName), 
		};
		list_0.Add(@class);
		return @class;
	}

	public void method_4(Class2605 obj)
	{
		list_0.Add(obj);
	}
}
