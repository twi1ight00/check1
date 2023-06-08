using System;
using System.Globalization;
using System.Xml;

namespace ns56;

internal class Class1649 : Class1351
{
	public delegate Class1649 Delegate826();

	public delegate void Delegate828(Class1649 elementData);

	public delegate void Delegate827(Class1649 elementData);

	public const bool bool_0 = true;

	public const bool bool_1 = true;

	public const double double_0 = double.NaN;

	public const double double_1 = double.NaN;

	public const double double_2 = 1.0;

	private bool bool_2;

	private bool bool_3;

	private Enum211 enum211_0;

	private double double_3;

	private double double_4;

	private DateTime dateTime_0;

	private DateTime dateTime_1;

	private double double_5;

	public static readonly Enum211 enum211_1 = Class2378.smethod_0("range");

	public static readonly DateTime dateTime_2 = DateTime.MinValue;

	public static readonly DateTime dateTime_3 = DateTime.MinValue;

	public bool AutoStart
	{
		get
		{
			return bool_2;
		}
		set
		{
			bool_2 = value;
		}
	}

	public bool AutoEnd
	{
		get
		{
			return bool_3;
		}
		set
		{
			bool_3 = value;
		}
	}

	public Enum211 GroupBy
	{
		get
		{
			return enum211_0;
		}
		set
		{
			enum211_0 = value;
		}
	}

	public double StartNum
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

	public double EndNum
	{
		get
		{
			return double_4;
		}
		set
		{
			double_4 = value;
		}
	}

	public DateTime StartDate
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

	public DateTime EndDate
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

	public double GroupInterval
	{
		get
		{
			return double_5;
		}
		set
		{
			double_5 = value;
		}
	}

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
				_ = reader.LocalName;
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
				case "autoStart":
					bool_2 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "autoEnd":
					bool_3 = XmlConvert.ToBoolean(reader.Value);
					break;
				case "groupBy":
					enum211_0 = Class2378.smethod_0(reader.Value);
					break;
				case "startNum":
					double_3 = ToDouble(reader.Value);
					break;
				case "endNum":
					double_4 = ToDouble(reader.Value);
					break;
				case "startDate":
					dateTime_0 = DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
					break;
				case "endDate":
					dateTime_1 = DateTime.Parse(reader.Value, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
					break;
				case "groupInterval":
					double_5 = ToDouble(reader.Value);
					break;
				}
			}
		}
		reader.MoveToElement();
	}

	public Class1649(XmlReader reader)
		: base(reader)
	{
	}

	public Class1649()
	{
	}

	protected override void vmethod_1()
	{
		bool_2 = true;
		bool_3 = true;
		enum211_0 = enum211_1;
		double_3 = double.NaN;
		double_4 = double.NaN;
		dateTime_0 = dateTime_2;
		dateTime_1 = dateTime_3;
		double_5 = 1.0;
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
		if (!bool_2)
		{
			writer.WriteAttributeString("autoStart", bool_2 ? "1" : "0");
		}
		if (!bool_3)
		{
			writer.WriteAttributeString("autoEnd", bool_3 ? "1" : "0");
		}
		if (enum211_0 != enum211_1)
		{
			writer.WriteAttributeString("groupBy", Class2378.smethod_1(enum211_0));
		}
		if (!double.IsNaN(double_3))
		{
			writer.WriteAttributeString("startNum", XmlConvert.ToString(double_3));
		}
		if (!double.IsNaN(double_4))
		{
			writer.WriteAttributeString("endNum", XmlConvert.ToString(double_4));
		}
		if (dateTime_0 != dateTime_2)
		{
			writer.WriteAttributeString("startDate", XmlConvert.ToString(dateTime_0, "yyyy-MM-ddTHH:mm:ss.fff"));
		}
		if (dateTime_1 != dateTime_3)
		{
			writer.WriteAttributeString("endDate", XmlConvert.ToString(dateTime_1, "yyyy-MM-ddTHH:mm:ss.fff"));
		}
		if (double_5 != 1.0)
		{
			writer.WriteAttributeString("groupInterval", XmlConvert.ToString(double_5));
		}
		writer.WriteEndElement();
	}
}
