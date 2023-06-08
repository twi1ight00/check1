using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace cn.jpush.api.util;

public class StringUtil
{
	public static bool IsNumber(string strNumber)
	{
		Regex regex = new Regex("[^0-9.-]");
		Regex regex2 = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
		Regex regex3 = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
		string text = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
		string text2 = "^([-]|[0-9])[0-9]*$";
		Regex regex4 = new Regex("(" + text + ")|(" + text2 + ")");
		if (!regex.IsMatch(strNumber) && !regex2.IsMatch(strNumber) && !regex3.IsMatch(strNumber))
		{
			return regex4.IsMatch(strNumber);
		}
		return false;
	}

	public static bool IsNumeric(string value)
	{
		return Regex.IsMatch(value, "^[+-]?\\d*[.]?\\d*$");
	}

	public static bool IsInt(string value)
	{
		return Regex.IsMatch(value, "^[+-]?\\d*$");
	}

	public static bool IsUnsign(string value)
	{
		return Regex.IsMatch(value, "^\\d*[.]?\\d*$");
	}

	public static string arrayToString(string[] values)
	{
		if (values == null)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder(values.Length);
		for (int i = 0; i < values.Length; i++)
		{
			stringBuilder.Append(values[i]).Append(",");
		}
		if (stringBuilder.Length > 0)
		{
			return stringBuilder.ToString().Substring(0, stringBuilder.Length - 1);
		}
		return "";
	}

	public static bool IsDateTime(string datetime)
	{
		bool flag = false;
		try
		{
			DateTime.ParseExact(datetime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool IsTime(string time)
	{
		bool flag = false;
		try
		{
			DateTime.ParseExact(time, "HH:mm:ss", CultureInfo.InvariantCulture);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static bool IsMobile(string mobile)
	{
		return Regex.IsMatch(mobile, "^(1[34578][0-9])(\\\\d{4})(\\\\d{4})$");
	}

	public static bool IsTimeunit(string time_unit)
	{
		bool flag = false;
		if (string.Equals(time_unit, "day", StringComparison.CurrentCultureIgnoreCase))
		{
			return true;
		}
		if (string.Equals(time_unit, "week", StringComparison.CurrentCultureIgnoreCase))
		{
			return true;
		}
		if (string.Equals(time_unit, "month", StringComparison.CurrentCultureIgnoreCase))
		{
			return true;
		}
		return false;
	}

	public static bool IsValidName(string name)
	{
		if (true)
		{
			return name.Length < 256;
		}
		return false;
	}

	public static bool IsValidTag(string tag)
	{
		if (true)
		{
			return tag.Length < 41;
		}
		return false;
	}

	public static bool IsValidAlias(string alias)
	{
		if (true)
		{
			return alias.Length < 41;
		}
		return false;
	}
}
