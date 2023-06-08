using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ns28;

internal class Class463 : Class461
{
	internal enum Enum61
	{
		const_0,
		const_1,
		const_2,
		const_3,
		const_4,
		const_5,
		const_6,
		const_7,
		const_8,
		const_9,
		const_10,
		const_11,
		const_12,
		const_13,
		const_14
	}

	internal Class412 class412_0;

	internal Class412 class412_1;

	internal Class412 class412_2;

	internal Class412 class412_3;

	internal Class412 class412_4;

	internal Class412 class412_5;

	internal Class412 class412_6;

	internal Class412 class412_7;

	internal Class412 class412_8;

	internal Class412 class412_9;

	internal Class412 class412_10;

	internal Class412 class412_11;

	internal Class412 class412_12;

	internal Class412 class412_13;

	internal Class412 class412_14;

	internal static Class482 class482_0;

	internal static readonly string string_0;

	internal static readonly string string_1;

	internal static readonly string string_2;

	internal static readonly string string_3;

	internal static readonly string string_4;

	internal static readonly string string_5;

	internal static readonly string string_6;

	internal static readonly string string_7;

	protected override Class482 ElementsFactory => class482_0;

	public DateTime DateTimeCreated
	{
		get
		{
			return DateTime.Parse(class412_8.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
		}
		set
		{
			class412_8.InnerText = smethod_1(value);
		}
	}

	public DateTime DateTimeModified
	{
		get
		{
			return DateTime.Parse(class412_9.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
		}
		set
		{
			class412_9.InnerText = smethod_1(value);
		}
	}

	public DateTime DateTimePrinted
	{
		get
		{
			return DateTime.Parse(class412_10.InnerText, CultureInfo.CurrentCulture, DateTimeStyles.AdjustToUniversal);
		}
		set
		{
			class412_10.InnerText = smethod_1(value);
		}
	}

	public TimeSpan DateTimeTotalTime
	{
		get
		{
			string s = "0";
			string s2 = "0";
			string s3 = "0";
			Regex regex = new Regex("[0-9]+(?=S)");
			Match match = regex.Match(class412_12.InnerText);
			if (match.Success)
			{
				s3 = match.Value;
			}
			regex = new Regex("[0-9]+(?=M)");
			match = regex.Match(class412_12.InnerText);
			if (match.Success)
			{
				s2 = match.Value;
			}
			regex = new Regex("[0-9]+(?=H)");
			match = regex.Match(class412_12.InnerText);
			if (match.Success)
			{
				s = match.Value;
			}
			return TimeSpan.FromHours(double.Parse(s)) + TimeSpan.FromMinutes(double.Parse(s2)) + TimeSpan.FromSeconds(double.Parse(s3));
		}
		set
		{
			class412_10.InnerText = $"PT{value.Hours}H{value.Minutes}M{value.Seconds}S";
		}
	}

	static Class463()
	{
		string_0 = "urn:oasis:names:tc:opendocument:xmlns:office:1.0";
		string_1 = "http://www.w3.org/1999/xlink";
		string_2 = "http://purl.org/dc/elements/1.1/";
		string_3 = "urn:oasis:names:tc:opendocument:xmlns:meta:1.0";
		string_4 = "urn:oasis:names:tc:opendocument:xmlns:presentation:1.0";
		string_5 = "http://openoffice.org/2004/office";
		string_6 = "urn:oasis:names:tc:opendocument:xmlns:smil-compatible:1.0";
		string_7 = "urn:oasis:names:tc:opendocument:xmlns:animation:1.0";
		class482_0 = new Class482(string_0);
		class482_0.Add(string_0, "document-meta", typeof(Class412));
		class482_0.Add(string_0, "meta", typeof(Class412));
		class482_0.Add(string_3, Class412.string_0[0], typeof(Class412));
		class482_0.Add(string_2, Class412.string_0[1], typeof(Class412));
		class482_0.Add(string_2, Class412.string_0[2], typeof(Class412));
		class482_0.Add(string_2, Class412.string_0[3], typeof(Class412));
		class482_0.Add(string_3, Class412.string_0[4], typeof(Class412));
		class482_0.Add(string_3, Class412.string_0[5], typeof(Class412));
		class482_0.Add(string_2, Class412.string_0[6], typeof(Class412));
		class482_0.Add(string_3, Class412.string_0[7], typeof(Class412));
		class482_0.Add(string_3, Class412.string_0[8], typeof(Class412));
		class482_0.Add(string_2, Class412.string_0[9], typeof(Class412));
		class482_0.Add(string_3, Class412.string_0[10], typeof(Class412));
		class482_0.Add(string_3, Class412.string_0[11], typeof(Class412));
		class482_0.Add(string_3, Class412.string_0[12], typeof(Class412));
		class482_0.Add(string_2, Class412.string_0[13], typeof(Class412));
		class482_0.Add(string_3, Class412.string_0[14], typeof(Class412));
	}

	public Class463(Class476 package)
		: base(package)
	{
	}

	internal static string smethod_1(DateTime dt)
	{
		string result = dt.ToString();
		string[] dateTimeFormats = dt.GetDateTimeFormats(CultureInfo.InvariantCulture);
		for (int i = 0; i < dateTimeFormats.Length; i++)
		{
			if (dateTimeFormats[i].IndexOf('Z') != -1)
			{
				result = dateTimeFormats[i].Replace(' ', 'T');
				break;
			}
		}
		return result;
	}

	public void method_2(Enum61 type, object val)
	{
		Class369 @class = (base.DocumentElement as Class369).method_31("meta", string_0);
		switch (type)
		{
		case Enum61.const_0:
			if (class412_0 != null)
			{
				class412_0.InnerText = (string)val;
			}
			else if (class412_0 == null && (string)val != "")
			{
				@class.method_35("generator", string_3).InnerText = (string)val;
			}
			break;
		case Enum61.const_1:
			if (class412_1 != null)
			{
				class412_1.InnerText = (string)val;
			}
			else if (class412_1 == null && (string)val != "")
			{
				@class.method_35("title", string_2).InnerText = (string)val;
			}
			break;
		case Enum61.const_2:
			if (class412_2 != null)
			{
				class412_2.InnerText = (string)val;
			}
			else if (class412_2 == null && (string)val != "")
			{
				@class.method_35("description", string_2).InnerText = (string)val;
			}
			break;
		case Enum61.const_3:
			if (class412_3 != null)
			{
				class412_3.InnerText = (string)val;
			}
			else if (class412_3 == null && (string)val != "")
			{
				@class.method_35("subject", string_2).InnerText = (string)val;
			}
			break;
		case Enum61.const_4:
			if (class412_4 != null)
			{
				class412_4.InnerText = (string)val;
			}
			else if (class412_4 == null && (string)val != "")
			{
				@class.method_35("keyword", string_3).InnerText = (string)val;
			}
			break;
		case Enum61.const_5:
			if (class412_6 != null)
			{
				class412_6.InnerText = (string)val;
			}
			else if (class412_6 == null && (string)val != "")
			{
				@class.method_35("initial-creator", string_3).InnerText = (string)val;
			}
			break;
		case Enum61.const_6:
			if (class412_5 != null)
			{
				class412_5.InnerText = (string)val;
			}
			else if (class412_5 == null && (string)val != "")
			{
				@class.method_35("creator", string_2).InnerText = (string)val;
			}
			break;
		case Enum61.const_8:
			if (class412_8 != null)
			{
				class412_8.InnerText = smethod_1(Convert.ToDateTime(val));
			}
			else if (class412_8 == null)
			{
				@class.method_35("creation-date", string_3).InnerText = smethod_1(Convert.ToDateTime(val));
			}
			break;
		case Enum61.const_9:
			if (class412_9 != null)
			{
				class412_9.InnerText = smethod_1(Convert.ToDateTime(val));
			}
			else if (class412_9 == null)
			{
				@class.method_35("date", string_2).InnerText = smethod_1(Convert.ToDateTime(val));
			}
			break;
		case Enum61.const_10:
			if (class412_10 != null)
			{
				class412_10.InnerText = smethod_1(Convert.ToDateTime(val));
			}
			else if (class412_10 == null)
			{
				@class.method_35("print-date", string_3).InnerText = smethod_1(Convert.ToDateTime(val));
			}
			break;
		case Enum61.const_11:
			if (class412_11 != null)
			{
				class412_11.InnerText = Convert.ToString(val);
			}
			else if (class412_11 == null)
			{
				@class.method_35("editing-cycles", string_3).InnerText = Convert.ToString(val);
			}
			break;
		case Enum61.const_12:
		{
			TimeSpan timeSpan = ((val is TimeSpan) ? ((TimeSpan)val) : default(TimeSpan));
			if (class412_12 != null)
			{
				class412_12.InnerText = $"PT{timeSpan.Hours}H{timeSpan.Minutes}M{timeSpan.Seconds}S";
			}
			else if (class412_12 == null)
			{
				@class.method_35("editing-duration", string_3).InnerText = $"PT{timeSpan.Hours}H{timeSpan.Minutes}M{timeSpan.Seconds}S";
			}
			break;
		}
		case Enum61.const_7:
			break;
		}
	}
}
