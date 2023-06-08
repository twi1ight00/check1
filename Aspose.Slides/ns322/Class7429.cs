using System;
using System.Globalization;

namespace ns322;

internal sealed class Class7429 : Class7399
{
	private DateTime dateTime_0;

	internal static long long_0 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;

	internal static long long_1 = 10000L;

	public static string string_21 = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'zzz";

	public static string string_22 = "ddd, dd MMM yyyy HH':'mm':'ss 'UTC'";

	public static string string_23 = "ddd, dd MMM yyyy";

	public static string string_24 = "HH':'mm':'ss 'GMT'zzz";

	public override object Value
	{
		get
		{
			return dateTime_0;
		}
		set
		{
			if (value is DateTime)
			{
				dateTime_0 = (DateTime)value;
			}
			else if (value is double)
			{
				dateTime_0 = Class7403.smethod_0((double)value);
			}
		}
	}

	public override string _Class => "Date";

	public override double vmethod_3()
	{
		return smethod_0(dateTime_0);
	}

	public static double smethod_0(DateTime date)
	{
		return (date.ToUniversalTime().Ticks - long_0) / long_1;
	}

	public override string ToString()
	{
		return dateTime_0.ToLocalTime().ToString(string_21, CultureInfo.InvariantCulture);
	}

	public override object vmethod_5()
	{
		return dateTime_0;
	}

	public Class7429(DateTime value, Class7399 prototype)
		: base(prototype)
	{
		dateTime_0 = value;
	}

	public Class7429(double value, Class7399 prototype)
		: this(Class7403.smethod_0(value), prototype)
	{
	}
}
