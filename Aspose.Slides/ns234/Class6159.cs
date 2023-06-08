using System;
using System.Globalization;
using System.Text;
using ns218;

namespace ns234;

internal static class Class6159
{
	private const string string_0 = "ddd, d MMM yyyy HH':'mm':'ss zzzz";

	public static string smethod_0(DateTime value)
	{
		return value.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
	}

	public static string smethod_1(DateTime value)
	{
		return value.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
	}

	public static string smethod_2(DateTime value)
	{
		return value.ToString("yyyyMMddHHmmssZ", CultureInfo.InvariantCulture);
	}

	public static DateTime smethod_3(string value)
	{
		return smethod_17(value, CultureInfo.InvariantCulture);
	}

	public static string smethod_4(DateTime value)
	{
		string text = value.ToString("ddd, d MMM yyyy HH':'mm':'ss zzzz", DateTimeFormatInfo.InvariantInfo);
		return text.Remove(text.LastIndexOf(':'), 1);
	}

	public static DateTime smethod_5(string value)
	{
		return DateTime.ParseExact(value, "ddd, d MMM yyyy HH':'mm':'ss zzzz", DateTimeFormatInfo.InvariantInfo);
	}

	public static string smethod_6(int value)
	{
		return smethod_24(value);
	}

	public static int smethod_7(string val)
	{
		return Class5964.smethod_30(smethod_8(val));
	}

	public static double smethod_8(string val)
	{
		double num = smethod_9(val);
		if (!double.IsNaN(num))
		{
			return num;
		}
		return 0.0;
	}

	public static double smethod_9(string s)
	{
		if (!double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
		{
			return double.NaN;
		}
		return result;
	}

	public static double smethod_10(string s)
	{
		if (!double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out var result))
		{
			return double.NaN;
		}
		return result;
	}

	public static bool smethod_11(string value)
	{
		double result;
		return double.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out result);
	}

	public static int smethod_12(string s)
	{
		if (!double.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return int.MinValue;
		}
		return Class5964.smethod_30(result);
	}

	public static bool smethod_13(string s, out int result)
	{
		result = 0;
		if (s.StartsWith("0x") || s.StartsWith("0X"))
		{
			if (s.Length < 3)
			{
				return false;
			}
			s = s.Substring(2);
		}
		if (double.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result2))
		{
			result = (int)result2;
			return true;
		}
		return false;
	}

	public static int smethod_14(string s)
	{
		int num = int.MinValue;
		while (s.Length > 0)
		{
			num = smethod_12(s);
			if (num != int.MinValue)
			{
				break;
			}
			s = s.Substring(0, s.Length - 1);
		}
		return num;
	}

	public static double smethod_15(string s)
	{
		if (!double.TryParse(s, NumberStyles.Currency, CultureInfo.CurrentCulture, out var result))
		{
			return double.NaN;
		}
		return result;
	}

	public static DateTime smethod_16(string s)
	{
		return smethod_17(s, CultureInfo.CurrentCulture);
	}

	private static DateTime smethod_17(string s, CultureInfo cultureInfo)
	{
		if (!DateTime.TryParse(s, cultureInfo, DateTimeStyles.AdjustToUniversal, out var result))
		{
			return DateTime.MinValue;
		}
		return result;
	}

	public static int smethod_18(string val)
	{
		return int.Parse(val, NumberStyles.Integer, CultureInfo.InvariantCulture);
	}

	public static long smethod_19(string val)
	{
		return long.Parse(val, NumberStyles.Integer, CultureInfo.InvariantCulture);
	}

	public static int smethod_20(string val)
	{
		return int.Parse(val, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
	}

	public static int smethod_21(string s)
	{
		if (!int.TryParse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
		{
			return int.MinValue;
		}
		return result;
	}

	public static bool smethod_22(string val)
	{
		return bool.Parse(val);
	}

	public static string smethod_23(bool val)
	{
		if (!val)
		{
			return "false";
		}
		return "true";
	}

	public static string smethod_24(int val)
	{
		return val.ToString(CultureInfo.InvariantCulture);
	}

	public static string smethod_25(long val)
	{
		return val.ToString(CultureInfo.InvariantCulture);
	}

	public static string smethod_26(int val)
	{
		return val.ToString("D2", CultureInfo.InvariantCulture);
	}

	public static string smethod_27(int val)
	{
		return val.ToString("D3", CultureInfo.InvariantCulture);
	}

	public static string smethod_28(int val)
	{
		return val.ToString("D4", CultureInfo.InvariantCulture);
	}

	public static string smethod_29(int val)
	{
		return val.ToString("D10", CultureInfo.InvariantCulture);
	}

	public static string smethod_30(int val)
	{
		if (val != 0)
		{
			return smethod_24(val);
		}
		return string.Empty;
	}

	public static string smethod_31(int val)
	{
		return val.ToString("X", CultureInfo.InvariantCulture);
	}

	public static string smethod_32(int val)
	{
		return val.ToString("x", CultureInfo.InvariantCulture);
	}

	public static string smethod_33(int val)
	{
		return val.ToString("X2", CultureInfo.InvariantCulture);
	}

	public static string smethod_34(int val)
	{
		return val.ToString("x2", CultureInfo.InvariantCulture);
	}

	public static string smethod_35(int val)
	{
		return val.ToString("X4", CultureInfo.InvariantCulture);
	}

	public static string smethod_36(int val)
	{
		return val.ToString("X6", CultureInfo.InvariantCulture);
	}

	public static string smethod_37(int val)
	{
		return val.ToString("X8", CultureInfo.InvariantCulture);
	}

	public static string smethod_38(double value)
	{
		return value.ToString(CultureInfo.InvariantCulture);
	}

	public static string smethod_39(double val)
	{
		return val.ToString("###########e0", CultureInfo.InvariantCulture);
	}

	public static string smethod_40(double val)
	{
		return val.ToString("0.##", CultureInfo.InvariantCulture);
	}

	public static string smethod_41(double val)
	{
		return val.ToString("0.#########", CultureInfo.InvariantCulture);
	}

	public static string smethod_42(float val)
	{
		return ((double)val).ToString("0.########", CultureInfo.InvariantCulture);
	}

	public static string smethod_43(float val)
	{
		return ((double)val).ToString("0.#########", CultureInfo.InvariantCulture);
	}

	public static string smethod_44(double value, bool isCurrency, bool isUsesGroupSeparator)
	{
		string text = (isCurrency ? "c" : ((!isUsesGroupSeparator) ? "0.#######" : "#,##0.#######"));
		return value.ToString(text, CultureInfo.CurrentCulture);
	}

	public static string smethod_45(double value, string localizedFormat, bool isMultiplyPercent)
	{
		string text = smethod_46(localizedFormat);
		if (text.IndexOf("%") >= 0 && text.IndexOf("'%'") < 0 && !isMultiplyPercent)
		{
			text = text.Replace("%", "'%'");
		}
		return value.ToString(text, CultureInfo.CurrentCulture);
	}

	private static string smethod_46(string format)
	{
		NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
		StringBuilder stringBuilder = new StringBuilder();
		int num = 0;
		while (num < format.Length)
		{
			if (smethod_47(format, num, currentInfo.NumberDecimalSeparator))
			{
				stringBuilder.Append('.');
				num += currentInfo.NumberDecimalSeparator.Length;
			}
			else if (smethod_47(format, num, currentInfo.NumberGroupSeparator))
			{
				stringBuilder.Append(',');
				num += currentInfo.NumberGroupSeparator.Length;
			}
			else if (smethod_47(format, num, currentInfo.PercentSymbol))
			{
				stringBuilder.Append('%');
				num += currentInfo.PercentSymbol.Length;
			}
			else if (smethod_47(format, num, currentInfo.PerMilleSymbol))
			{
				stringBuilder.Append('‰');
				num += currentInfo.PerMilleSymbol.Length;
			}
			else
			{
				stringBuilder.Append(format[num]);
				num++;
			}
		}
		return stringBuilder.ToString();
	}

	private static bool smethod_47(string a, int indexA, string b)
	{
		return Class6165.Equals(a, indexA, b, 0, b.Length);
	}

	public static string smethod_48()
	{
		return DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
	}

	public static string smethod_49()
	{
		string shortTimePattern = DateTimeFormatInfo.CurrentInfo.ShortTimePattern;
		return shortTimePattern.Replace("tt", "am/pm");
	}

	public static char smethod_50()
	{
		string numberDecimalSeparator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
		if (!Class5964.smethod_20(numberDecimalSeparator))
		{
			return '.';
		}
		return numberDecimalSeparator[0];
	}

	public static char smethod_51()
	{
		string numberGroupSeparator = NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
		if (!Class5964.smethod_20(numberGroupSeparator))
		{
			return ',';
		}
		return numberGroupSeparator[0];
	}

	public static string smethod_52()
	{
		return NumberFormatInfo.CurrentInfo.CurrencySymbol;
	}
}
