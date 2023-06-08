using System;
using Aspose.Cells;

namespace ns12;

internal class Class1670
{
	public static DateTime smethod_0(DateTime dateTime_0, int int_0)
	{
		return ((dateTime_0.Month == 12) ? new DateTime(dateTime_0.Year + 1, 1, 1) : new DateTime(dateTime_0.Year, dateTime_0.Month + 1, 1)).AddMonths(int_0).AddDays(-1.0);
	}

	internal static double smethod_1(double double_0, double double_1, bool bool_0, bool bool_1)
	{
		double num = 0.0;
		if (double_0 == 60.0)
		{
			double_0 += 1.0;
			num += 1.0;
		}
		DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(double_0, bool_1);
		DateTime dateTimeFromDouble2 = CellsHelper.GetDateTimeFromDouble(double_1, bool_1);
		bool flag = false;
		if (dateTimeFromDouble2.Day == 29 && dateTimeFromDouble2.Month == 2 && DateTime.IsLeapYear(dateTimeFromDouble2.Year))
		{
			flag = true;
		}
		int num2 = dateTimeFromDouble2.Year - dateTimeFromDouble.Year;
		dateTimeFromDouble2 = dateTimeFromDouble2.AddYears(dateTimeFromDouble.Year - dateTimeFromDouble2.Year);
		if (dateTimeFromDouble2 < dateTimeFromDouble)
		{
			dateTimeFromDouble2 = dateTimeFromDouble2.AddYears(1);
			num += (double)(360 * (num2 - 1));
			if (flag)
			{
				num += 1.0;
			}
		}
		else
		{
			num += (double)(360 * num2);
			if (flag && !DateTime.IsLeapYear(dateTimeFromDouble2.Year))
			{
				num += 1.0;
			}
		}
		if (dateTimeFromDouble2.Year > dateTimeFromDouble.Year)
		{
			num += (double)((dateTimeFromDouble2.Month - 1) * 30);
			num += (double)dateTimeFromDouble2.Day;
			if (dateTimeFromDouble2.Day == 31)
			{
				if (!bool_0)
				{
					if (dateTimeFromDouble.Day == 30 || dateTimeFromDouble.Day == 31)
					{
						num -= 1.0;
					}
				}
				else
				{
					num -= 1.0;
				}
			}
			num += (double)((13 - dateTimeFromDouble.Month) * 30 - dateTimeFromDouble.Day);
			if (dateTimeFromDouble.Day == 31)
			{
				num += 1.0;
			}
		}
		else
		{
			num += (double)((dateTimeFromDouble2.Month - dateTimeFromDouble.Month) * 30 + dateTimeFromDouble2.Day - dateTimeFromDouble.Day);
			switch (dateTimeFromDouble.Day)
			{
			case 28:
				if (!bool_0 && dateTimeFromDouble.Month == 2 && dateTimeFromDouble.Year != 1900 && !DateTime.IsLeapYear(dateTimeFromDouble.Year))
				{
					num -= 2.0;
				}
				break;
			case 29:
				if (!bool_0 && dateTimeFromDouble.Month == 2 && DateTime.IsLeapYear(dateTimeFromDouble.Year))
				{
					num -= 1.0;
				}
				break;
			case 31:
				num += 1.0;
				break;
			}
			if (dateTimeFromDouble2.Day == 31)
			{
				if (!bool_0)
				{
					if (dateTimeFromDouble.Day == 30 || dateTimeFromDouble.Day == 31)
					{
						num -= 1.0;
					}
				}
				else
				{
					num -= 1.0;
				}
			}
		}
		return num;
	}

	internal static double smethod_2(double double_0, double double_1, bool bool_0)
	{
		DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(double_0, bool_0);
		DateTime dateTimeFromDouble2 = CellsHelper.GetDateTimeFromDouble(double_1, bool_0);
		int year = dateTimeFromDouble.Year;
		int year2 = dateTimeFromDouble2.Year;
		int num = year2 - year + 1;
		dateTimeFromDouble = new DateTime(year, 1, 1);
		dateTimeFromDouble2 = new DateTime(year2 + 1, 1, 1);
		int num2 = (int)(dateTimeFromDouble2 - dateTimeFromDouble).TotalDays;
		return (double)num2 / (double)num;
	}
}
