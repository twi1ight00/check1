using System;
using System.Collections.Generic;
using Aspose.Cells;
using ns1;
using ns2;
using ns22;

namespace ns12;

internal class Class1339
{
	internal static object smethod_0(double double_0, double double_1, string string_0, bool bool_0)
	{
		if (double_1 < double_0)
		{
			return ErrorType.Number;
		}
		string key;
		if ((key = string_0.ToUpper()) != null)
		{
			if (Class1742.dictionary_96 == null)
			{
				Class1742.dictionary_96 = new Dictionary<string, int>(6)
				{
					{ "D", 0 },
					{ "M", 1 },
					{ "Y", 2 },
					{ "YM", 3 },
					{ "YD", 4 },
					{ "MD", 5 }
				};
			}
			if (Class1742.dictionary_96.TryGetValue(key, out var value))
			{
				switch (value)
				{
				case 0:
				{
					double num6 = Math.Ceiling(double_1 - double_0);
					if (num6 < 0.0)
					{
						return ErrorType.Number;
					}
					return num6;
				}
				case 1:
					try
					{
						DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(double_0, bool_0);
						DateTime dateTimeFromDouble2 = CellsHelper.GetDateTimeFromDouble(double_1, bool_0);
						int num5 = ((dateTimeFromDouble2.Day < dateTimeFromDouble.Day) ? (-1) : 0);
						return (double)((dateTimeFromDouble2.Year - dateTimeFromDouble.Year) * 12 + dateTimeFromDouble2.Month - dateTimeFromDouble.Month) + (double)num5;
					}
					catch
					{
						return ErrorType.Value;
					}
				case 2:
					try
					{
						DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(double_0, bool_0);
						DateTime dateTimeFromDouble2 = CellsHelper.GetDateTimeFromDouble(double_1, bool_0);
						int num4 = 0;
						if (dateTimeFromDouble.Month > dateTimeFromDouble2.Month)
						{
							num4 = -1;
						}
						else if (dateTimeFromDouble.Month == dateTimeFromDouble2.Month && dateTimeFromDouble.Day > dateTimeFromDouble2.Day)
						{
							num4 = -1;
						}
						return (double)(dateTimeFromDouble2.Year - dateTimeFromDouble.Year) + (double)num4;
					}
					catch
					{
						return ErrorType.Value;
					}
				case 3:
					try
					{
						DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(double_0, bool_0);
						DateTime dateTimeFromDouble2 = CellsHelper.GetDateTimeFromDouble(double_1, bool_0);
						int num3 = ((dateTimeFromDouble2.Day < dateTimeFromDouble.Day) ? (-1) : 0);
						return (double)(dateTimeFromDouble2.Month - dateTimeFromDouble.Month) + (double)num3;
					}
					catch
					{
						return ErrorType.Value;
					}
				case 4:
					try
					{
						DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(double_0, bool_0);
						DateTime dateTimeFromDouble2 = CellsHelper.GetDateTimeFromDouble(double_1, bool_0);
						int num2 = 0;
						if (dateTimeFromDouble.Month > dateTimeFromDouble2.Month)
						{
							num2 = -1;
						}
						else if (dateTimeFromDouble.Month == dateTimeFromDouble2.Month && dateTimeFromDouble.Day > dateTimeFromDouble2.Day)
						{
							num2 = -1;
						}
						int value2 = dateTimeFromDouble2.Year - dateTimeFromDouble.Year + num2;
						dateTimeFromDouble = dateTimeFromDouble.AddYears(value2);
						return double_1 - CellsHelper.GetDoubleFromDateTime(dateTimeFromDouble, bool_0);
					}
					catch
					{
						return ErrorType.Value;
					}
				case 5:
					try
					{
						DateTime dateTimeFromDouble = CellsHelper.GetDateTimeFromDouble(double_0, bool_0);
						DateTime dateTimeFromDouble2 = CellsHelper.GetDateTimeFromDouble(double_1, bool_0);
						int num = ((dateTimeFromDouble2.Day < dateTimeFromDouble.Day) ? (-1) : 0);
						int months = (dateTimeFromDouble2.Year - dateTimeFromDouble.Year) * 12 + dateTimeFromDouble2.Month - dateTimeFromDouble.Month + num;
						dateTimeFromDouble = dateTimeFromDouble.AddMonths(months);
						return double_1 - CellsHelper.GetDoubleFromDateTime(dateTimeFromDouble, bool_0);
					}
					catch
					{
						return ErrorType.Value;
					}
				}
			}
		}
		return ErrorType.Number;
	}

	internal static object smethod_1(int int_0, DateTime dateTime_0)
	{
		int dayOfWeek = (int)dateTime_0.DayOfWeek;
		switch (int_0)
		{
		default:
			return (double)(dayOfWeek + 1);
		case 2:
			if (dayOfWeek == 0)
			{
				return 7.0;
			}
			return (double)dayOfWeek;
		case 3:
			dayOfWeek--;
			if (dayOfWeek < 0)
			{
				return 6;
			}
			return (double)dayOfWeek;
		}
	}

	internal static object smethod_2(int int_0, object object_0, WorkbookSettings workbookSettings_0)
	{
		DateTime dateTime = DateTime.Now;
		double num = 0.0;
		bool flag = false;
		if (object_0 != null)
		{
			if (object_0 is ErrorType)
			{
				return object_0;
			}
			if (object_0 is string)
			{
				string text = (string)object_0;
				if (workbookSettings_0.Region == CountryCode.Germany)
				{
					try
					{
						dateTime = DateTime.Parse(text);
						flag = true;
					}
					catch
					{
					}
				}
				if (!flag)
				{
					if (Class1677.smethod_20(text))
					{
						try
						{
							num = double.Parse(text);
							if (num < 0.0)
							{
								return ErrorType.Number;
							}
							if (num != 0.0)
							{
								if (num > 2958465.99)
								{
									return ErrorType.Number;
								}
								dateTime = CellsHelper.GetDateTimeFromDouble(num, workbookSettings_0.Date1904);
								flag = true;
							}
						}
						catch
						{
							try
							{
								dateTime = DateTime.Parse(text);
								flag = true;
							}
							catch
							{
								return ErrorType.Value;
							}
						}
					}
					else
					{
						try
						{
							dateTime = DateTime.Parse(text);
							flag = true;
						}
						catch
						{
							return ErrorType.Value;
						}
					}
				}
			}
			else
			{
				object_0 = Class1660.smethod_26(object_0, workbookSettings_0.Date1904);
				if (object_0 is ErrorType)
				{
					return object_0;
				}
				num = (double)object_0;
				if (num < 0.0)
				{
					return ErrorType.Number;
				}
				if (num != 0.0)
				{
					if (num > 2958465.99)
					{
						return ErrorType.Number;
					}
					dateTime = CellsHelper.GetDateTimeFromDouble(num, workbookSettings_0.Date1904);
					flag = true;
				}
			}
		}
		if (!flag && num == 0.0)
		{
			return int_0 switch
			{
				0 => 0.0, 
				1 => 1.0, 
				2 => 1900.0, 
				3 => 0.0, 
				4 => 0.0, 
				5 => 0.0, 
				_ => ErrorType.Value, 
			};
		}
		return int_0 switch
		{
			0 => (double)dateTime.Day, 
			1 => (double)dateTime.Month, 
			2 => (double)dateTime.Year, 
			3 => (double)dateTime.Second + (double)((dateTime.Millisecond > 500) ? 1 : 0), 
			4 => (double)dateTime.Minute, 
			5 => (double)dateTime.Hour, 
			_ => ErrorType.Value, 
		};
	}

	internal static double smethod_3(DateTime dateTime_0, int int_0)
	{
		DateTime dateTime = new DateTime(dateTime_0.Year, 1, 1);
		int num = (int)(dateTime_0 - dateTime).TotalDays + 1;
		int dayOfWeek = (int)dateTime.DayOfWeek;
		int num2 = 0;
		switch (int_0)
		{
		case 12:
			num2 = 2;
			break;
		case 13:
			num2 = 3;
			break;
		case 14:
			num2 = 4;
			break;
		case 15:
			num2 = 5;
			break;
		case 16:
			num2 = 6;
			break;
		case 2:
		case 11:
		case 21:
			num2 = 1;
			break;
		}
		int num3 = 0;
		num3 = ((num2 == dayOfWeek) ? 7 : ((num2 >= dayOfWeek) ? (num2 - dayOfWeek) : (7 - (dayOfWeek - num2))));
		num -= num3;
		int num4 = num / 7 + 1;
		if (num % 7 != 0)
		{
			num4++;
		}
		return num4;
	}

	internal static bool smethod_4(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1)
	{
		if (double_0 == double_1)
		{
			return true;
		}
		if (double_1 - double_0 > 7.0)
		{
			return false;
		}
		int dayOfWeek = (int)dateTime_0.DayOfWeek;
		int dayOfWeek2 = (int)dateTime_1.DayOfWeek;
		if (dayOfWeek >= dayOfWeek2)
		{
			return false;
		}
		return true;
	}

	internal static DateTime smethod_5(DateTime dateTime_0, int int_0)
	{
		switch (dateTime_0.DayOfWeek)
		{
		default:
		{
			int num = (int)(6 - dateTime_0.DayOfWeek);
			dateTime_0 = ((num <= int_0) ? dateTime_0.AddDays(int_0 + 1) : dateTime_0.AddDays(int_0));
			break;
		}
		case DayOfWeek.Friday:
		case DayOfWeek.Saturday:
			dateTime_0 = dateTime_0.AddDays(int_0 + 2);
			break;
		case DayOfWeek.Sunday:
			dateTime_0 = ((int_0 <= 5) ? dateTime_0.AddDays(1 + int_0) : dateTime_0.AddDays(int_0 + 2));
			break;
		}
		return dateTime_0;
	}

	internal static DateTime smethod_6(DateTime dateTime_0, int int_0)
	{
		switch (dateTime_0.DayOfWeek)
		{
		default:
		{
			int dayOfWeek = (int)dateTime_0.DayOfWeek;
			dateTime_0 = ((dayOfWeek <= int_0) ? dateTime_0.AddDays(-(int_0 + 2)) : dateTime_0.AddDays(-int_0));
			break;
		}
		case DayOfWeek.Saturday:
			dateTime_0 = dateTime_0.AddDays(-(int_0 + 1));
			break;
		case DayOfWeek.Sunday:
			dateTime_0 = dateTime_0.AddDays(-(int_0 + 2));
			break;
		case DayOfWeek.Monday:
			dateTime_0 = dateTime_0.AddDays(-(int_0 + 2));
			break;
		}
		return dateTime_0;
	}

	internal static object smethod_7(DateTime dateTime_0, int int_0, object object_0, DateTime[] dateTime_1)
	{
		if (object_0 is int)
		{
			return (Enum20)object_0 switch
			{
				Enum20.const_0 => smethod_8(dateTime_0, int_0, "0000011", dateTime_1), 
				Enum20.const_1 => smethod_8(dateTime_0, int_0, "1000001", dateTime_1), 
				Enum20.const_2 => smethod_8(dateTime_0, int_0, "1100000", dateTime_1), 
				Enum20.const_3 => smethod_8(dateTime_0, int_0, "0110000", dateTime_1), 
				Enum20.const_4 => smethod_8(dateTime_0, int_0, "0011000", dateTime_1), 
				Enum20.const_5 => smethod_8(dateTime_0, int_0, "0001100", dateTime_1), 
				Enum20.const_6 => smethod_8(dateTime_0, int_0, "0000110", dateTime_1), 
				Enum20.const_7 => smethod_8(dateTime_0, int_0, "0000001", dateTime_1), 
				Enum20.const_8 => smethod_8(dateTime_0, int_0, "1000000", dateTime_1), 
				Enum20.const_9 => smethod_8(dateTime_0, int_0, "0100000", dateTime_1), 
				Enum20.const_10 => smethod_8(dateTime_0, int_0, "0010000", dateTime_1), 
				Enum20.const_11 => smethod_8(dateTime_0, int_0, "0001000", dateTime_1), 
				Enum20.const_12 => smethod_8(dateTime_0, int_0, "0000100", dateTime_1), 
				Enum20.const_13 => smethod_8(dateTime_0, int_0, "0000010", dateTime_1), 
				_ => 0, 
			};
		}
		return smethod_8(dateTime_0, int_0, (string)object_0, dateTime_1);
	}

	internal static object smethod_8(DateTime dateTime_0, int int_0, string string_0, DateTime[] dateTime_1)
	{
		int num = 0;
		bool[] array = new bool[7];
		if (string_0[0] == '1')
		{
			num++;
			array[1] = true;
		}
		if (string_0[1] == '1')
		{
			num++;
			array[2] = true;
		}
		if (string_0[2] == '1')
		{
			num++;
			array[3] = true;
		}
		if (string_0[3] == '1')
		{
			num++;
			array[4] = true;
		}
		if (string_0[4] == '1')
		{
			num++;
			array[5] = true;
		}
		if (string_0[5] == '1')
		{
			num++;
			array[6] = true;
		}
		if (string_0[6] == '1')
		{
			num++;
			array[0] = true;
		}
		DateTime dateTime_2 = dateTime_0;
		DateTime dateTime = dateTime_0.AddDays(int_0);
		double num2 = int_0;
		double num3 = 0.0;
		double num4 = 0.0;
		if (int_0 > 0)
		{
			if (!array[(int)dateTime_2.DayOfWeek])
			{
				num2 += 1.0;
			}
		}
		else if (!array[(int)dateTime_2.DayOfWeek])
		{
			num2 -= 1.0;
		}
		do
		{
			num3 = (double)smethod_11(dateTime_2, dateTime, string_0, dateTime_1, bool_0: false);
			if (num3 != 0.0)
			{
				num4 = num2 - num3;
				dateTime_2 = dateTime;
				if (array[(int)dateTime_2.DayOfWeek])
				{
					num2 -= 1.0;
				}
				dateTime = dateTime.AddDays(num4);
				num2 = num2 - num3 + 1.0;
				continue;
			}
			dateTime = dateTime.AddDays(num4);
			break;
		}
		while (!(num4 <= 0.0));
		return dateTime;
	}

	internal static object smethod_9(DateTime dateTime_0, int int_0, DateTime[] dateTime_1)
	{
		if (int_0 > 0)
		{
			int num = int_0 / 5;
			int int_ = int_0 % 5;
			DateTime dateTime_2 = dateTime_0.AddDays(num * 7);
			dateTime_2 = smethod_5(dateTime_2, int_);
			if (dateTime_1 != null)
			{
				for (int i = 0; i < dateTime_1.Length; i++)
				{
					DayOfWeek dayOfWeek = dateTime_1[i].DayOfWeek;
					if (dayOfWeek != 0 && dayOfWeek != DayOfWeek.Saturday && dateTime_1[i] > dateTime_0 && dateTime_1[i] <= dateTime_2)
					{
						dateTime_2 = dateTime_2.DayOfWeek switch
						{
							DayOfWeek.Friday => dateTime_2.AddDays(3.0), 
							DayOfWeek.Saturday => dateTime_2.AddDays(2.0), 
							DayOfWeek.Sunday => dateTime_2.AddDays(1.0), 
							_ => dateTime_2.AddDays(1.0), 
						};
					}
				}
			}
			return dateTime_2;
		}
		int num2 = -int_0 / 5;
		int int_2 = -int_0 % 5;
		DateTime dateTime_3 = dateTime_0.AddDays(-num2 * 7);
		dateTime_3 = smethod_6(dateTime_3, int_2);
		if (dateTime_1 != null)
		{
			for (int j = 0; j < dateTime_1.Length; j++)
			{
				DayOfWeek dayOfWeek2 = dateTime_1[j].DayOfWeek;
				if (dayOfWeek2 != 0 && dayOfWeek2 != DayOfWeek.Saturday && dateTime_1[j] > dateTime_3 && dateTime_1[j] <= dateTime_0)
				{
					dateTime_3 = dateTime_3.DayOfWeek switch
					{
						DayOfWeek.Saturday => dateTime_3.AddDays(-1.0), 
						DayOfWeek.Sunday => dateTime_3.AddDays(-2.0), 
						DayOfWeek.Monday => dateTime_3.AddDays(-3.0), 
						_ => dateTime_3.AddDays(-1.0), 
					};
				}
			}
		}
		return dateTime_3;
	}

	internal static object smethod_10(DateTime dateTime_0, DateTime dateTime_1, object object_0, DateTime[] dateTime_2, bool bool_0)
	{
		if (object_0 is int)
		{
			return (Enum20)object_0 switch
			{
				Enum20.const_0 => smethod_11(dateTime_0, dateTime_1, "0000011", dateTime_2, bool_0), 
				Enum20.const_1 => smethod_11(dateTime_0, dateTime_1, "1000001", dateTime_2, bool_0), 
				Enum20.const_2 => smethod_11(dateTime_0, dateTime_1, "1100000", dateTime_2, bool_0), 
				Enum20.const_3 => smethod_11(dateTime_0, dateTime_1, "0110000", dateTime_2, bool_0), 
				Enum20.const_4 => smethod_11(dateTime_0, dateTime_1, "0011000", dateTime_2, bool_0), 
				Enum20.const_5 => smethod_11(dateTime_0, dateTime_1, "0001100", dateTime_2, bool_0), 
				Enum20.const_6 => smethod_11(dateTime_0, dateTime_1, "0000110", dateTime_2, bool_0), 
				Enum20.const_7 => smethod_11(dateTime_0, dateTime_1, "0000001", dateTime_2, bool_0), 
				Enum20.const_8 => smethod_11(dateTime_0, dateTime_1, "1000000", dateTime_2, bool_0), 
				Enum20.const_9 => smethod_11(dateTime_0, dateTime_1, "0100000", dateTime_2, bool_0), 
				Enum20.const_10 => smethod_11(dateTime_0, dateTime_1, "0010000", dateTime_2, bool_0), 
				Enum20.const_11 => smethod_11(dateTime_0, dateTime_1, "0001000", dateTime_2, bool_0), 
				Enum20.const_12 => smethod_11(dateTime_0, dateTime_1, "0000100", dateTime_2, bool_0), 
				Enum20.const_13 => smethod_11(dateTime_0, dateTime_1, "0000010", dateTime_2, bool_0), 
				_ => 0, 
			};
		}
		return smethod_11(dateTime_0, dateTime_1, (string)object_0, dateTime_2, bool_0);
	}

	internal static object smethod_11(DateTime dateTime_0, DateTime dateTime_1, string string_0, DateTime[] dateTime_2, bool bool_0)
	{
		double num = (int)CellsHelper.GetDoubleFromDateTime(dateTime_0, bool_0);
		double num2 = (int)CellsHelper.GetDoubleFromDateTime(dateTime_1, bool_0);
		int num3 = (int)(num2 - num + 1.0);
		bool flag = false;
		if (num3 < 0)
		{
			num3 = -num3;
			flag = true;
			DateTime dateTime = dateTime_0;
			dateTime_0 = dateTime_1;
			dateTime_1 = dateTime;
			double num4 = num;
			num = num2;
			num2 = num4;
			num3 = (int)(num2 - num + 1.0);
		}
		int num5 = 0;
		bool[] array = new bool[7];
		for (int i = 0; i <= 6; i++)
		{
			if (string_0[i] == '1')
			{
				num5++;
				array[i] = true;
			}
		}
		num3 = (int)(num3 - (7 - dateTime_0.DayOfWeek));
		double num6 = 0.0;
		switch ((int)dateTime_0.DayOfWeek)
		{
		case 0:
			num6 += (double)(7 - num5);
			break;
		case 1:
			num6 += (double)(6 - num5);
			if (array[6])
			{
				num6 += 1.0;
			}
			break;
		case 2:
			num6 += (double)(5 - num5);
			if (array[6])
			{
				num6 += 1.0;
			}
			if (array[0])
			{
				num6 += 1.0;
			}
			break;
		case 3:
			num6 += (double)(4 - num5);
			if (array[6])
			{
				num6 += 1.0;
			}
			if (array[0])
			{
				num6 += 1.0;
			}
			if (array[1])
			{
				num6 += 1.0;
			}
			break;
		case 4:
			num6 += (double)(3 - num5);
			if (array[6])
			{
				num6 += 1.0;
			}
			if (array[0])
			{
				num6 += 1.0;
			}
			if (array[1])
			{
				num6 += 1.0;
			}
			if (array[2])
			{
				num6 += 1.0;
			}
			break;
		case 5:
			num6 += (double)(2 - num5);
			if (array[6])
			{
				num6 += 1.0;
			}
			if (array[0])
			{
				num6 += 1.0;
			}
			if (array[1])
			{
				num6 += 1.0;
			}
			if (array[2])
			{
				num6 += 1.0;
			}
			if (array[3])
			{
				num6 += 1.0;
			}
			break;
		case 6:
			num6 += (double)(1 - num5);
			if (array[6])
			{
				num6 += 1.0;
			}
			if (array[0])
			{
				num6 += 1.0;
			}
			if (array[1])
			{
				num6 += 1.0;
			}
			if (array[2])
			{
				num6 += 1.0;
			}
			if (array[3])
			{
				num6 += 1.0;
			}
			if (array[4])
			{
				num6 += 1.0;
			}
			break;
		}
		num3 = (int)(num3 - (dateTime_1.DayOfWeek + 1));
		if (!array[6])
		{
			num6 += 1.0;
		}
		for (int j = 1; j <= (int)dateTime_1.DayOfWeek; j++)
		{
			if (!array[j - 1])
			{
				num6 += 1.0;
			}
		}
		num6 += (double)(num3 / 7 * 5);
		if (dateTime_2 != null)
		{
			for (int k = 0; k < dateTime_2.Length; k++)
			{
				DayOfWeek dayOfWeek = dateTime_2[k].DayOfWeek;
				if (dayOfWeek != 0 && dayOfWeek != DayOfWeek.Saturday && dateTime_2[k] > dateTime_0 && dateTime_2[k] <= dateTime_1)
				{
					num6 -= 1.0;
				}
			}
		}
		if (flag)
		{
			return 0.0 - num6;
		}
		return num6;
	}

	internal static object smethod_12(DateTime dateTime_0, DateTime dateTime_1, DateTime[] dateTime_2, bool bool_0)
	{
		double num = (int)CellsHelper.GetDoubleFromDateTime(dateTime_0, bool_0);
		double num2 = (int)CellsHelper.GetDoubleFromDateTime(dateTime_1, bool_0);
		int num3 = (int)(num2 - num + 1.0);
		bool flag = false;
		if (num3 < 0)
		{
			num3 = -num3;
			flag = true;
			DateTime dateTime = dateTime_0;
			dateTime_0 = dateTime_1;
			dateTime_1 = dateTime;
			double num4 = num;
			num = num2;
			num2 = num4;
			num3 = (int)(num2 - num + 1.0);
		}
		if (smethod_4(dateTime_0, dateTime_1, num, num2))
		{
			if (dateTime_0.DayOfWeek == DayOfWeek.Sunday)
			{
				num3--;
			}
			if (dateTime_1.DayOfWeek == DayOfWeek.Saturday)
			{
				num3--;
			}
			if (flag)
			{
				return -num3;
			}
			return num3;
		}
		num3 = (int)(num3 - (7 - dateTime_0.DayOfWeek));
		double num5 = 0.0;
		switch ((int)dateTime_0.DayOfWeek)
		{
		default:
			num5 += (double)(6 - dateTime_0.DayOfWeek);
			break;
		case 0:
		case 1:
			num5 += 5.0;
			break;
		}
		num3 = (int)(num3 - (dateTime_1.DayOfWeek + 1));
		switch ((int)dateTime_1.DayOfWeek)
		{
		case 6:
			num5 += 5.0;
			break;
		default:
			num5 += (double)dateTime_1.DayOfWeek;
			break;
		case 0:
			break;
		}
		num5 += (double)(num3 / 7 * 5);
		if (dateTime_2 != null)
		{
			for (int i = 0; i < dateTime_2.Length; i++)
			{
				DayOfWeek dayOfWeek = dateTime_2[i].DayOfWeek;
				if (dayOfWeek != 0 && dayOfWeek != DayOfWeek.Saturday && dateTime_2[i] > dateTime_0 && dateTime_2[i] <= dateTime_1)
				{
					num5 -= 1.0;
				}
			}
		}
		if (flag)
		{
			return 0.0 - num5;
		}
		return num5;
	}

	internal static object smethod_13(object[] object_0, Workbook workbook_0)
	{
		object[][] array = (object[][])object_0[0];
		object[][] array2 = (object[][])object_0[1];
		object[][] array3 = (object[][])object_0[2];
		object[][] array4 = new object[array.Length][];
		int num = array[0].Length;
		for (int i = 0; i < array.Length; i++)
		{
			array4[i] = new object[num];
			for (int j = 0; j < num; j++)
			{
				array4[i][j] = smethod_14(new object[3]
				{
					array[i][j],
					array2[i][j],
					array3[i][j]
				}, workbook_0);
			}
		}
		return array4;
	}

	internal static object smethod_14(object[] object_0, Workbook workbook_0)
	{
		int[] array = new int[3];
		for (int i = 0; i < 3; i++)
		{
			switch (Type.GetTypeCode(object_0[i].GetType()))
			{
			case TypeCode.Double:
				array[i] = (int)Class1179.ToDouble(object_0[i]);
				break;
			case TypeCode.DateTime:
				switch (i)
				{
				case 0:
					array[0] = ((DateTime)object_0[0]).Year;
					break;
				case 1:
					array[1] = ((DateTime)object_0[1]).Month;
					break;
				case 2:
					array[2] = ((DateTime)object_0[2]).Day;
					break;
				}
				break;
			case TypeCode.String:
			{
				string text = (string)object_0[i];
				if (Class1677.smethod_20(text))
				{
					array[i] = (int)double.Parse(text);
					break;
				}
				return ErrorType.Value;
			}
			case TypeCode.Int32:
				array[i] = (int)object_0[i];
				break;
			case TypeCode.Boolean:
				if ((bool)object_0[i])
				{
					array[i] = 1;
				}
				else
				{
					array[i] = 0;
				}
				break;
			default:
				return ErrorType.Value;
			}
		}
		if ((double)array[0] < 0.0)
		{
			return ErrorType.Number;
		}
		int num = array[0];
		if (num < 1900)
		{
			num += 1900;
		}
		int num2 = array[1];
		int num3 = array[2];
		try
		{
			DateTime dateTime = DateTime.MinValue.AddYears(num - 1).AddMonths(num2 - 1).AddDays(num3 - 1);
			if (dateTime.Year < 1900)
			{
				return ErrorType.Number;
			}
			return CellsHelper.GetDoubleFromDateTime(dateTime, workbook_0.Settings.Date1904);
		}
		catch
		{
			return ErrorType.Number;
		}
	}
}
