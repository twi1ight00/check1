using System;
using System.Globalization;

namespace ns322;

internal class Class7403 : Class7400
{
	private Interface401 interface401_0;

	private bool method_4(string p, IFormatProvider culture, out double result)
	{
		DateTime result2 = new DateTime(0L, DateTimeKind.Utc);
		result = 0.0;
		if (DateTime.TryParse(p, culture, DateTimeStyles.None, out result2))
		{
			result = interface401_0.DateClass.method_5(result2).vmethod_3();
			return true;
		}
		if (DateTime.TryParseExact(p, Class7429.string_21, culture, DateTimeStyles.None, out result2))
		{
			result = interface401_0.DateClass.method_5(result2).vmethod_3();
			return true;
		}
		if (DateTime.TryParseExact(p, Class7429.string_23, culture, DateTimeStyles.None, out var result3))
		{
			result2 = result2.AddTicks(result3.Ticks);
		}
		if (DateTime.TryParseExact(p, Class7429.string_24, culture, DateTimeStyles.None, out result3))
		{
			result2 = result2.AddTicks(result3.Ticks);
		}
		if (result2.Ticks > 0L)
		{
			result = interface401_0.DateClass.method_5(result2).vmethod_3();
			return true;
		}
		return true;
	}

	public static DateTime smethod_0(double number)
	{
		return new DateTime((long)(number * (double)Class7429.long_1 + (double)Class7429.long_0), DateTimeKind.Utc);
	}

	public Class7397 method_5(Class7397[] parameters)
	{
		if (method_4(parameters[0].ToString(), CultureInfo.InvariantCulture, out var result))
		{
			return interface401_0.NumberClass.method_4(result);
		}
		return interface401_0.NaN;
	}

	public Class7397 method_6(Class7397[] parameters)
	{
		if (method_4(parameters[0].ToString(), CultureInfo.CurrentCulture, out var result))
		{
			return interface401_0.NumberClass.method_4(result);
		}
		return interface401_0.NaN;
	}

	public Class7429 method_7(Class7397[] parameters)
	{
		Class7429 @class = null;
		if (parameters.Length == 1)
		{
			if ((parameters[0]._Class == "Number" || parameters[0]._Class == "Object") && double.IsNaN(parameters[0].vmethod_3()))
			{
				return interface401_0.DateClass.method_4(double.NaN);
			}
			if (parameters[0]._Class == "Number")
			{
				return interface401_0.DateClass.method_4(parameters[0].vmethod_3());
			}
			if (method_4(parameters[0].ToString(), CultureInfo.InvariantCulture, out var result))
			{
				return interface401_0.DateClass.method_4(result);
			}
			if (method_4(parameters[0].ToString(), CultureInfo.CurrentCulture, out result))
			{
				return interface401_0.DateClass.method_4(result);
			}
			return interface401_0.DateClass.method_4(0.0);
		}
		if (parameters.Length > 1)
		{
			DateTime value = new DateTime(0L, DateTimeKind.Local);
			if (parameters.Length > 0)
			{
				int num = (int)parameters[0].vmethod_3() - 1;
				if (num < 100)
				{
					num += 1900;
				}
				value = value.AddYears(num);
			}
			if (parameters.Length > 1)
			{
				value = value.AddMonths((int)parameters[1].vmethod_3());
			}
			if (parameters.Length > 2)
			{
				value = value.AddDays((int)parameters[2].vmethod_3() - 1);
			}
			if (parameters.Length > 3)
			{
				value = value.AddHours((int)parameters[3].vmethod_3());
			}
			if (parameters.Length > 4)
			{
				value = value.AddMinutes((int)parameters[4].vmethod_3());
			}
			if (parameters.Length > 5)
			{
				value = value.AddSeconds((int)parameters[5].vmethod_3());
			}
			if (parameters.Length > 6)
			{
				value = value.AddMilliseconds((int)parameters[6].vmethod_3());
			}
			return interface401_0.DateClass.method_5(value);
		}
		return interface401_0.DateClass.method_5(DateTime.UtcNow);
	}

	public Class7397 method_8(Class7397[] parameters)
	{
		int num = 0;
		while (true)
		{
			if (num < parameters.Length)
			{
				if (parameters[num] == Class7437.class7437_0 || (parameters[num]._Class == "Number" && double.IsNaN(parameters[num].vmethod_3())) || (parameters[num]._Class == "Number" && double.IsInfinity(parameters[num].vmethod_3())))
				{
					break;
				}
				num++;
				continue;
			}
			Class7429 @class = method_7(parameters);
			double value = @class.vmethod_3() + TimeZone.CurrentTimeZone.GetUtcOffset(default(DateTime)).TotalMilliseconds;
			return interface401_0.NumberClass.method_4(value);
		}
		return interface401_0.NaN;
	}

	public Class7397 method_9(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.StringClass.method_5(double.NaN.ToString());
		}
		return interface401_0.StringClass.method_5(smethod_0(target.vmethod_3()).ToLocalTime().ToString(Class7429.string_21, CultureInfo.InvariantCulture));
	}

	public Class7397 method_10(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.StringClass.method_5(double.NaN.ToString());
		}
		return interface401_0.StringClass.method_5(smethod_0(target.vmethod_3()).ToLocalTime().ToString(Class7429.string_23, CultureInfo.InvariantCulture));
	}

	public Class7397 method_11(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.StringClass.method_5(double.NaN.ToString());
		}
		return interface401_0.StringClass.method_5(smethod_0(target.vmethod_3()).ToLocalTime().ToString(Class7429.string_24, CultureInfo.InvariantCulture));
	}

	public Class7397 method_12(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.StringClass.method_5(double.NaN.ToString());
		}
		return interface401_0.StringClass.method_5(smethod_0(target.vmethod_3()).ToLocalTime().ToString("F", CultureInfo.CurrentCulture));
	}

	public Class7397 method_13(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.StringClass.method_5(double.NaN.ToString());
		}
		return interface401_0.StringClass.method_5(smethod_0(target.vmethod_3()).ToLocalTime().ToString(Class7429.string_23));
	}

	public Class7397 method_14(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.StringClass.method_5(double.NaN.ToString());
		}
		return interface401_0.StringClass.method_5(smethod_0(target.vmethod_3()).ToLocalTime().ToString(Class7429.string_24));
	}

	public Class7397 method_15(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(target.vmethod_3());
	}

	public Class7397 method_16(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(target.vmethod_3());
	}

	public Class7397 method_17(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToLocalTime().Year);
	}

	public Class7397 method_18(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToUniversalTime().Year);
	}

	public Class7397 method_19(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToLocalTime().Month - 1);
	}

	public Class7397 method_20(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToUniversalTime().Month - 1);
	}

	public Class7397 method_21(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToLocalTime().Day);
	}

	public Class7397 method_22(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToUniversalTime().Day);
	}

	public Class7397 method_23(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4((double)smethod_0(target.vmethod_3()).ToLocalTime().DayOfWeek);
	}

	public Class7397 method_24(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4((double)smethod_0(target.vmethod_3()).ToUniversalTime().DayOfWeek);
	}

	public Class7397 method_25(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToLocalTime().Hour);
	}

	public Class7397 method_26(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToUniversalTime().Hour);
	}

	public Class7397 method_27(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToLocalTime().Minute);
	}

	public Class7397 method_28(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToUniversalTime().Minute);
	}

	public Class7397 method_29(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToLocalTime().Second);
	}

	public Class7397 method_30(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToUniversalTime().Second);
	}

	public Class7397 method_31(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToLocalTime().Millisecond);
	}

	public Class7397 method_32(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.NaN;
		}
		return interface401_0.NumberClass.method_4(smethod_0(target.vmethod_3()).ToUniversalTime().Millisecond);
	}

	public Class7397 method_33(Class7398 target, Class7397[] parameters)
	{
		return interface401_0.NumberClass.method_4(0.0 - TimeZone.CurrentTimeZone.GetUtcOffset(default(DateTime)).TotalMinutes);
	}

	public static Class7397 smethod_1(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no tiem specified");
		}
		target.Value = parameters[0].vmethod_3();
		return target;
	}

	public Class7397 method_34(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no millisecond specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3()).ToLocalTime();
		dateTime = dateTime.AddMilliseconds(-dateTime.Millisecond).AddMilliseconds(parameters[0].vmethod_3());
		target.Value = interface401_0.DateClass.method_5(dateTime).vmethod_3();
		return target;
	}

	public Class7397 method_35(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no millisecond specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3());
		dateTime = dateTime.AddMilliseconds(-dateTime.Millisecond).AddMilliseconds(parameters[0].vmethod_3());
		target.Value = interface401_0.DateClass.method_5(dateTime).vmethod_3();
		return target;
	}

	public Class7397 method_36(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no second specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3()).ToLocalTime();
		dateTime = dateTime.AddSeconds(-dateTime.Second).AddSeconds(parameters[0].vmethod_3());
		target.Value = dateTime;
		if (parameters.Length > 1)
		{
			Class7397[] array = new Class7397[parameters.Length - 1];
			Array.Copy(parameters, 1, array, 0, array.Length);
			target = (Class7429)method_34(target, array);
		}
		return target;
	}

	public Class7397 method_37(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no second specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3());
		dateTime = dateTime.AddSeconds(-dateTime.Second).AddSeconds(parameters[0].vmethod_3());
		target.Value = dateTime;
		if (parameters.Length > 1)
		{
			Class7397[] array = new Class7397[parameters.Length - 1];
			Array.Copy(parameters, 1, array, 0, array.Length);
			target = (Class7429)method_34(target, array);
		}
		return target;
	}

	public Class7397 method_38(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no minute specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3()).ToLocalTime();
		dateTime = dateTime.AddMinutes(-dateTime.Minute).AddMinutes(parameters[0].vmethod_3());
		target.Value = dateTime;
		if (parameters.Length > 1)
		{
			Class7397[] array = new Class7397[parameters.Length - 1];
			Array.Copy(parameters, 1, array, 0, array.Length);
			target = (Class7429)method_36(target, array);
		}
		return target;
	}

	public Class7397 method_39(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no minute specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3());
		dateTime = dateTime.AddMinutes(-dateTime.Minute).AddMinutes(parameters[0].vmethod_3());
		target.Value = dateTime;
		if (parameters.Length > 1)
		{
			Class7397[] array = new Class7397[parameters.Length - 1];
			Array.Copy(parameters, 1, array, 0, array.Length);
			target = (Class7429)method_36(target, array);
		}
		return target;
	}

	public Class7397 method_40(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no hour specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3()).ToLocalTime();
		dateTime = dateTime.AddHours(-dateTime.Hour).AddHours(parameters[0].vmethod_3());
		target.Value = dateTime;
		if (parameters.Length > 1)
		{
			Class7397[] array = new Class7397[parameters.Length - 1];
			Array.Copy(parameters, 1, array, 0, array.Length);
			target = (Class7429)method_38(target, array);
		}
		return target;
	}

	public Class7397 method_41(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no hour specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3());
		dateTime = dateTime.AddHours(-dateTime.Hour).AddHours(parameters[0].vmethod_3());
		target.Value = dateTime;
		if (parameters.Length > 1)
		{
			Class7397[] array = new Class7397[parameters.Length - 1];
			Array.Copy(parameters, 1, array, 0, array.Length);
			target = (Class7429)method_38(target, array);
		}
		return target;
	}

	public static Class7397 smethod_2(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no date specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3()).ToLocalTime();
		dateTime = dateTime.AddDays(-dateTime.Day).AddDays(parameters[0].vmethod_3());
		target.Value = dateTime;
		return target;
	}

	public static Class7397 smethod_3(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no date specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3());
		dateTime = dateTime.AddDays(-dateTime.Day).AddDays(parameters[0].vmethod_3());
		target.Value = dateTime;
		return target;
	}

	public static Class7397 smethod_4(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no month specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3()).ToLocalTime();
		dateTime = dateTime.AddMonths(-dateTime.Month).AddMonths((int)parameters[0].vmethod_3());
		target.Value = dateTime;
		if (parameters.Length > 1)
		{
			Class7397[] array = new Class7397[parameters.Length - 1];
			Array.Copy(parameters, 1, array, 0, array.Length);
			target = (Class7429)smethod_2(target, array);
		}
		return target;
	}

	public static Class7397 smethod_5(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no month specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3());
		dateTime = dateTime.AddMonths(-dateTime.Month).AddMonths((int)parameters[0].vmethod_3());
		target.Value = dateTime;
		if (parameters.Length > 1)
		{
			Class7397[] array = new Class7397[parameters.Length - 1];
			Array.Copy(parameters, 1, array, 0, array.Length);
			target = (Class7429)smethod_2(target, array);
		}
		return target;
	}

	public static Class7397 smethod_6(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no year specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3()).ToLocalTime();
		int num = dateTime.Year - (int)parameters[0].vmethod_3();
		dateTime = dateTime.AddYears(-num);
		target.Value = dateTime;
		if (parameters.Length > 1)
		{
			Class7397[] array = new Class7397[parameters.Length - 1];
			Array.Copy(parameters, 1, array, 0, array.Length);
			target = (Class7429)smethod_4(target, array);
		}
		return target;
	}

	public static Class7397 smethod_7(Class7398 target, Class7397[] parameters)
	{
		if (parameters.Length == 0)
		{
			throw new ArgumentException("There was no year specified");
		}
		DateTime dateTime = smethod_0(target.vmethod_3());
		int num = dateTime.Year - (int)parameters[0].vmethod_3();
		dateTime = dateTime.AddYears(-num);
		target.Value = dateTime;
		if (parameters.Length > 1)
		{
			Class7397[] array = new Class7397[parameters.Length - 1];
			Array.Copy(parameters, 1, array, 0, array.Length);
			target = (Class7429)smethod_4(target, array);
		}
		return target;
	}

	public Class7397 method_42(Class7398 target, Class7397[] parameters)
	{
		if (double.IsNaN(target.vmethod_3()))
		{
			return interface401_0.StringClass.method_5(double.NaN.ToString());
		}
		return interface401_0.StringClass.method_5(smethod_0(target.vmethod_3()).ToString(Class7429.string_22, CultureInfo.InvariantCulture));
	}

	public override Class7397 vmethod_25(Interface396 visitor, Class7398 that, Class7397[] parameters)
	{
		Class7397 result;
		if (string_21 == "UTC")
		{
			result = method_8(parameters);
		}
		else if (string_21 == "parse")
		{
			result = method_5(parameters);
		}
		else if (string_21 == "parseLocale")
		{
			result = method_6(parameters);
		}
		else if (string_21 == "toString")
		{
			result = method_9(that, parameters);
		}
		else if (string_21 == "toDateString")
		{
			result = method_10(that, parameters);
		}
		else if (string_21 == "toTimeString")
		{
			result = method_11(that, parameters);
		}
		else if (string_21 == "toLocaleString")
		{
			result = method_12(that, parameters);
		}
		else if (string_21 == "toLocaleDateString")
		{
			result = method_13(that, parameters);
		}
		else if (string_21 == "toLocaleTimeString")
		{
			result = method_14(that, parameters);
		}
		else if (string_21 == "valueOf")
		{
			result = method_15(that, parameters);
		}
		else if (string_21 == "getTime")
		{
			result = method_16(that, parameters);
		}
		else if (string_21 == "getFullYear")
		{
			result = method_17(that, parameters);
		}
		else if (string_21 == "getUTCFullYear")
		{
			result = method_18(that, parameters);
		}
		else if (string_21 == "getMonth")
		{
			result = method_19(that, parameters);
		}
		else if (string_21 == "getUTCMonth")
		{
			result = method_20(that, parameters);
		}
		else if (string_21 == "getDate")
		{
			result = method_21(that, parameters);
		}
		else if (string_21 == "getUTCDate")
		{
			result = method_22(that, parameters);
		}
		else if (string_21 == "getDay")
		{
			result = method_23(that, parameters);
		}
		else if (string_21 == "getUTCDay")
		{
			result = method_24(that, parameters);
		}
		else if (string_21 == "getHours")
		{
			result = method_25(that, parameters);
		}
		else if (string_21 == "getUTCHours")
		{
			result = method_26(that, parameters);
		}
		else if (string_21 == "getMinutes")
		{
			result = method_27(that, parameters);
		}
		else if (string_21 == "getUTCMinutes")
		{
			result = method_28(that, parameters);
		}
		else if (string_21 == "getSeconds")
		{
			result = method_29(that, parameters);
		}
		else if (string_21 == "getUTCSeconds")
		{
			result = method_30(that, parameters);
		}
		else if (string_21 == "getMilliseconds")
		{
			result = method_31(that, parameters);
		}
		else if (string_21 == "getUTCMilliseconds")
		{
			result = method_32(that, parameters);
		}
		else if (string_21 == "getTimezoneOffset")
		{
			result = method_33(that, parameters);
		}
		else if (string_21 == "setTime")
		{
			result = smethod_1(that, parameters);
		}
		else if (string_21 == "setMilliseconds")
		{
			result = method_34(that, parameters);
		}
		else if (string_21 == "setUTCMilliseconds")
		{
			result = method_35(that, parameters);
		}
		else if (string_21 == "setSeconds")
		{
			result = method_36(that, parameters);
		}
		else if (string_21 == "setUTCSeconds")
		{
			result = method_37(that, parameters);
		}
		else if (string_21 == "setMinutes")
		{
			result = method_38(that, parameters);
		}
		else if (string_21 == "setUTCMinutes")
		{
			result = method_39(that, parameters);
		}
		else if (string_21 == "setHours")
		{
			result = method_40(that, parameters);
		}
		else if (string_21 == "setUTCHours")
		{
			result = method_41(that, parameters);
		}
		else if (string_21 == "setDate")
		{
			result = smethod_2(that, parameters);
		}
		else if (string_21 == "setUTCDate")
		{
			result = smethod_3(that, parameters);
		}
		else if (string_21 == "setMonth")
		{
			result = smethod_4(that, parameters);
		}
		else if (string_21 == "setUTCMonth")
		{
			result = smethod_5(that, parameters);
		}
		else if (string_21 == "setFullYear")
		{
			result = smethod_6(that, parameters);
		}
		else if (string_21 == "setUTCFullYear")
		{
			result = smethod_7(that, parameters);
		}
		else
		{
			if (!(string_21 == "toUTCString"))
			{
				throw new Exception89("unknown date function");
			}
			result = method_42(that, parameters);
		}
		visitor.imethod_36(result);
		return result;
	}

	public override string ToString()
	{
		return $"function {base.Name}";
	}

	public Class7403(Interface401 global, string name, Class7399 prototype)
		: base(prototype)
	{
		string_21 = name;
		interface401_0 = global;
	}
}
