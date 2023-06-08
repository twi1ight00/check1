using System;
using System.Collections.Generic;
using ns1;

namespace ns2;

internal class Class428
{
	public static DateTime GetDateTimeFromDouble(double double_0, bool bool_0)
	{
		if (double_0 > 2958465.99)
		{
			return DateTime.MaxValue;
		}
		if (bool_0)
		{
			double_0 += 1462.0;
		}
		if (double_0 < 60.0)
		{
			double_0 += 1.0;
		}
		return DateTime.FromOADate(double_0);
	}

	public static double GetDoubleFromDateTime(DateTime dateTime_0, bool bool_0)
	{
		if (bool_0)
		{
			double totalDays = (dateTime_0 - Class1391.dateTime_1).TotalDays;
			if (totalDays < 0.0)
			{
				return -1.0;
			}
			return totalDays;
		}
		if ((DateTime.MaxValue - dateTime_0).TotalDays < 0.0)
		{
			return -1.0;
		}
		TimeSpan timeSpan = ((!((dateTime_0 - Class1391.dateTime_0).TotalDays > 0.0)) ? (dateTime_0 - Class1391.dateTime_3) : (dateTime_0 - Class1391.dateTime_2));
		if (timeSpan.TotalDays < 0.0)
		{
			return -1.0;
		}
		double num = timeSpan.TotalDays;
		if (dateTime_0.Year == 1900 && dateTime_0.Month == 3 && dateTime_0.Day == 1)
		{
			num += 1.0;
		}
		return num;
	}

	internal static bool smethod_0(string string_0)
	{
		if (string_0 != null && string_0.Length != 0)
		{
			if (string_0[0] != '#')
			{
				return false;
			}
			string key;
			if ((key = string_0) != null)
			{
				if (Class1742.dictionary_0 == null)
				{
					Class1742.dictionary_0 = new Dictionary<string, int>(7)
					{
						{ "#DIV/0!", 0 },
						{ "#N/A", 1 },
						{ "#NAME?", 2 },
						{ "#NULL!", 3 },
						{ "#NUM!", 4 },
						{ "#REF!", 5 },
						{ "#VALUE!", 6 }
					};
				}
				if (Class1742.dictionary_0.TryGetValue(key, out var value))
				{
					switch (value)
					{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
						return true;
					}
				}
			}
			return false;
		}
		return false;
	}
}
