using System;
using Aspose.Cells;
using ns12;

namespace ns2;

internal class Class1378
{
	private static double smethod_0(double double_0)
	{
		if (double_0 > 0.0)
		{
			return Math.Floor(double_0 + 0.5);
		}
		return Math.Ceiling(double_0 - 0.5);
	}

	private static double smethod_1(DateTime dateTime_0, DateTime dateTime_1)
	{
		return dateTime_1.Subtract(dateTime_0).Days;
	}

	private static double smethod_2(DateTime dateTime_0, DateTime dateTime_1)
	{
		double num = dateTime_1.Year - dateTime_0.Year;
		double num2 = dateTime_1.Month - dateTime_0.Month;
		double num3 = dateTime_1.Day - dateTime_0.Day;
		return num * 360.0 + num2 * 30.0 + num3;
	}

	private static double smethod_3(DateTime dateTime_0, DateTime dateTime_1)
	{
		DateTime dateTime = dateTime_0;
		DateTime dateTime_2 = dateTime_1;
		if (dateTime_0.Day > 28 && dateTime_0.Month == 2)
		{
			dateTime = new DateTime(dateTime.Year, dateTime.Month, 28);
		}
		if (dateTime_1.Day > 28 && dateTime_1.Month == 2)
		{
			dateTime_2 = new DateTime(dateTime_2.Year, dateTime_2.Month, 28);
		}
		DateTime dateTime_3 = new DateTime(dateTime_2.Year, dateTime.Month, dateTime.Day);
		return (double)((dateTime_2.Year - dateTime.Year) * 365) + smethod_1(dateTime_3, dateTime_2);
	}

	private static double smethod_4(DateTime dateTime_0, DateTime dateTime_1, byte byte_0)
	{
		int num = dateTime_1.Day;
		int day = dateTime_0.Day;
		if (smethod_6(dateTime_1) && (smethod_6(dateTime_0) || byte_0 == 1))
		{
			num = 30;
		}
		if (num == 31 && (dateTime_0.Day >= 30 || byte_0 == 1))
		{
			num = 30;
		}
		if (dateTime_0.Day == 31)
		{
			day = 30;
		}
		if (smethod_6(dateTime_0))
		{
			day = 30;
		}
		return smethod_2(new DateTime(dateTime_0.Year, dateTime_0.Month, day), new DateTime(dateTime_1.Year, dateTime_1.Month, num));
	}

	private static double smethod_5(DateTime dateTime_0, DateTime dateTime_1)
	{
		int num = dateTime_1.Day;
		int num2 = dateTime_0.Day;
		if (num2 == 31)
		{
			num2 = 30;
		}
		if (num == 31)
		{
			num = 30;
		}
		return smethod_2(new DateTime(dateTime_0.Year, dateTime_0.Month, num2), new DateTime(dateTime_1.Year, dateTime_1.Month, num));
	}

	private static bool smethod_6(DateTime dateTime_0)
	{
		if (dateTime_0.Month == 2 && smethod_7(dateTime_0))
		{
			return true;
		}
		return false;
	}

	private static bool smethod_7(DateTime dateTime_0)
	{
		int num = smethod_20(dateTime_0.Year, dateTime_0.Month);
		if (num == dateTime_0.Day)
		{
			return true;
		}
		return false;
	}

	private static double smethod_8(DateTime dateTime_0, int int_0)
	{
		if (int_0 == 1)
		{
			if (smethod_9(dateTime_0.Year))
			{
				return 366.0;
			}
			return 365.0;
		}
		return smethod_10(dateTime_0, dateTime_0, int_0);
	}

	private static bool smethod_9(double double_0)
	{
		if ((double_0 % 4.0 != 0.0 || double_0 % 100.0 == 0.0) && double_0 % 400.0 != 0.0)
		{
			return false;
		}
		return true;
	}

	private static double smethod_10(DateTime dateTime_0, DateTime dateTime_1, int int_0)
	{
		switch (int_0)
		{
		default:
			return 360.0;
		case 0:
			return 360.0;
		case 1:
			if (!smethod_12(dateTime_0, dateTime_1))
			{
				double num = dateTime_1.Year - dateTime_0.Year + 1;
				double num2 = smethod_1(new DateTime(dateTime_0.Year, 1, 1), new DateTime(dateTime_1.Year + 1, 1, 1));
				return num2 / num;
			}
			if (smethod_13(dateTime_0, dateTime_1))
			{
				return 366.0;
			}
			return 365.0;
		case 2:
			return 360.0;
		case 3:
			return 365.0;
		case 4:
			return 360.0;
		}
	}

	private static double smethod_11(DateTime dateTime_0, DateTime dateTime_1, byte byte_0, int int_0)
	{
		double result = 0.0;
		switch (int_0)
		{
		case 0:
			result = smethod_4(dateTime_0, dateTime_1, 0);
			break;
		case 1:
			result = smethod_1(dateTime_0, dateTime_1);
			break;
		case 2:
			result = ((byte_0 != 1) ? smethod_4(dateTime_0, dateTime_1, 0) : smethod_1(dateTime_0, dateTime_1));
			break;
		case 3:
			result = ((byte_0 != 1) ? smethod_3(dateTime_0, dateTime_1) : smethod_1(dateTime_0, dateTime_1));
			break;
		case 4:
			result = smethod_5(dateTime_0, dateTime_1);
			break;
		}
		return result;
	}

	private static bool smethod_12(DateTime dateTime_0, DateTime dateTime_1)
	{
		if (dateTime_0.Year != dateTime_1.Year && (dateTime_1.Year != dateTime_0.Year + 1 || (dateTime_0.Month <= dateTime_1.Month && (dateTime_0.Month != dateTime_1.Month || dateTime_0.Day < dateTime_1.Day))))
		{
			return false;
		}
		return true;
	}

	private static bool smethod_13(DateTime dateTime_0, DateTime dateTime_1)
	{
		if ((dateTime_0.Year == dateTime_1.Year && smethod_9(dateTime_0.Year)) || (dateTime_1.Month == 2 && dateTime_1.Day == 29) || smethod_14(dateTime_0, dateTime_1))
		{
			return true;
		}
		return false;
	}

	private static bool smethod_14(DateTime dateTime_0, DateTime dateTime_1)
	{
		if (dateTime_0.Year == dateTime_1.Year && smethod_9(dateTime_0.Year))
		{
			if (dateTime_0.Month <= 2 && dateTime_1.Month > 2)
			{
				return true;
			}
			return false;
		}
		if (dateTime_0.Year == dateTime_1.Year)
		{
			return false;
		}
		if (dateTime_1.Year == dateTime_0.Year + 1)
		{
			if (smethod_9(dateTime_0.Year))
			{
				if (dateTime_0.Month <= 2)
				{
					return true;
				}
				return false;
			}
			if (smethod_9(dateTime_1.Year))
			{
				if (dateTime_1.Month > 2)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private static DateTime smethod_15(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1, double double_0, bool bool_0)
	{
		bool flag = false;
		if ((int_0 <= 0) ? ((!(dateTime_1 >= dateTime_0)) ? true : false) : ((!(dateTime_0 >= dateTime_1)) ? true : false))
		{
			return dateTime_0;
		}
		DateTime dateTime = dateTime_1;
		while (dateTime > dateTime_0)
		{
			dateTime = smethod_21(dateTime, int_0, int_1, bool_0);
			if (dateTime >= dateTime_1)
			{
				dateTime = dateTime_0;
				break;
			}
		}
		return dateTime;
	}

	private static DateTime smethod_16(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1, double double_0, bool bool_0)
	{
		bool flag = false;
		if ((int_0 <= 0) ? ((!(dateTime_1 >= dateTime_0)) ? true : false) : ((!(dateTime_0 >= dateTime_1)) ? true : false))
		{
			return dateTime_0;
		}
		DateTime dateTime = dateTime_1;
		DateTime result = dateTime_1;
		while (dateTime > dateTime_0)
		{
			result = dateTime;
			dateTime = smethod_21(dateTime, int_0, int_1, bool_0);
			if (dateTime >= dateTime_1)
			{
				dateTime = dateTime_0;
				break;
			}
		}
		return result;
	}

	private static DateTime smethod_17(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1)
	{
		bool bool_ = false;
		int num = smethod_20(dateTime_0.Year, dateTime_0.Month);
		if (num == dateTime_0.Day)
		{
			bool_ = true;
		}
		int int_2 = -12 / int_0;
		return smethod_15(dateTime_0, dateTime_1, int_2, int_1, 0.0, bool_);
	}

	private static double smethod_18(DateTime dateTime_0, DateTime dateTime_1, int int_0)
	{
		DateTime dateTime_2 = smethod_17(dateTime_0, dateTime_1, int_0, 1);
		DateTime dateTime_3 = smethod_19(dateTime_0, dateTime_1, int_0, 1);
		return smethod_1(dateTime_2, dateTime_3);
	}

	private static DateTime smethod_19(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1)
	{
		bool bool_ = false;
		int num = smethod_20(dateTime_0.Year, dateTime_0.Month);
		if (num == dateTime_0.Day)
		{
			bool_ = true;
		}
		int int_2 = -12 / int_0;
		return smethod_16(dateTime_0, dateTime_1, int_2, int_1, 0.0, bool_);
	}

	private static int smethod_20(int int_0, int int_1)
	{
		if (int_1 != 12)
		{
			return new DateTime(int_0, int_1 + 1, 1).AddDays(-1.0).Day;
		}
		return 30;
	}

	private static DateTime smethod_21(DateTime dateTime_0, int int_0, int int_1, bool bool_0)
	{
		smethod_20(dateTime_0.Year, dateTime_0.Month);
		return dateTime_0.AddMonths(int_0);
	}

	internal static object smethod_22(DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, double double_0, double double_1, int int_0, int int_1)
	{
		if (!(double_0 <= 0.0) && double_1 > 0.0)
		{
			if (int_0 != 1 && int_0 != 2 && int_0 != 4)
			{
				return ErrorType.Number;
			}
			if (int_1 >= 0 && int_1 <= 4)
			{
				if (dateTime_0 >= dateTime_2)
				{
					return ErrorType.Number;
				}
				int num = 12 / int_0;
				int int_2 = -num;
				DateTime dateTime = default(DateTime);
				_ = dateTime_1.Day;
				smethod_20(dateTime_1.Year, dateTime_1.Month);
				dateTime = ((!(dateTime_2 > dateTime_1)) ? smethod_21(dateTime_1, int_2, int_1, bool_0: false) : smethod_17(dateTime_1, dateTime_2, num, int_1));
				smethod_19(dateTime_1, dateTime_2, int_0, int_1);
				DateTime dateTime2 = ((dateTime_0 > dateTime) ? dateTime_0 : dateTime);
				double num2 = smethod_11(dateTime2, dateTime_2, 1, int_1);
				object obj = smethod_34(dateTime, dateTime_1, int_0, int_1);
				if (obj is ErrorType)
				{
					return obj;
				}
				double num3 = (double)obj;
				double num4 = num2 / num3;
				if (dateTime > dateTime_0)
				{
					if (int_1 == 0)
					{
						byte byte_ = (byte)((!(dateTime_0 > dateTime)) ? 1 : 0);
						num2 = smethod_4(dateTime_0, dateTime2, byte_) - 1.0;
					}
					else
					{
						num2 = smethod_11(dateTime_0, dateTime2, 1, int_1);
					}
					num4 += num2 / int_1 switch
					{
						0 => (double)smethod_34(dateTime, dateTime_1, int_0, int_1), 
						3 => 365.0 / (double)int_0, 
						_ => (double)smethod_34(dateTime, dateTime_1, int_0, int_1) - 2.0, 
					};
				}
				return double_1 * double_0 / (double)int_0 * num4;
			}
			return ErrorType.Number;
		}
		return ErrorType.Number;
	}

	internal static object smethod_23(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, int int_0)
	{
		if (!(double_0 <= 0.0) && !(double_1 <= 0.0) && !(dateTime_0 >= dateTime_1) && int_0 >= 0 && int_0 <= 4)
		{
			double num = smethod_11(dateTime_0, dateTime_1, 1, int_0);
			double num2 = smethod_10(dateTime_0, dateTime_1, int_0);
			return double_1 * double_0 * num / num2;
		}
		return ErrorType.Number;
	}

	private static DateTime smethod_24(DateTime dateTime_0, int int_0)
	{
		if ((int_0 == 1 || int_0 == 3) && smethod_9(dateTime_0.Year) && dateTime_0.Month == 2 && dateTime_0.Day >= 28)
		{
			return new DateTime(dateTime_0.Year, dateTime_0.Month, 28);
		}
		return dateTime_0;
	}

	private static double smethod_25(double double_0)
	{
		if (double_0 >= 3.0 && double_0 <= 4.0)
		{
			return 1.5;
		}
		if (double_0 >= 5.0 && double_0 <= 6.0)
		{
			return 2.0;
		}
		if (double_0 > 6.0)
		{
			return 2.5;
		}
		return 1.0;
	}

	internal static object smethod_26(double double_0, DateTime dateTime_0, DateTime dateTime_1, double double_1, double double_2, double double_3, int int_0)
	{
		if (!(double_0 < 0.0) && !(double_1 < 0.0) && !(double_1 >= double_0) && !(double_2 < 0.0) && !(dateTime_0 >= dateTime_1) && !(double_3 < 0.0) && int_0 != 2)
		{
			double num = 1.0 / double_3;
			if ((num > 0.0 && num < 3.0) || (num > 4.0 && num < 5.0))
			{
				return ErrorType.Number;
			}
			double num2 = Math.Ceiling(1.0 / double_3);
			if (double_0 != double_1 && double_2 <= num2)
			{
				double num3 = smethod_25(num2);
				double num4 = double_3 * num3;
				double num5 = smethod_8(dateTime_0, int_0);
				DateTime dateTime_2 = smethod_24(dateTime_0, int_0);
				DateTime dateTime_3 = smethod_24(dateTime_1, int_0);
				double num6 = smethod_11(dateTime_2, dateTime_3, 1, int_0);
				double num7 = num6 / num5 * num4 * double_0;
				double num8 = 0.0;
				num8 = ((num7 != 0.0) ? num7 : (double_0 * num4));
				double num9 = 0.0;
				num9 = ((num7 != 0.0) ? (num2 + 1.0) : num2);
				double num10 = double_0 - double_1;
				double num11 = 0.0;
				num11 = ((!(num8 > num10)) ? num8 : num10);
				double num12 = smethod_0(num11);
				double num13 = 0.0;
				num13 = ((double_2 != 0.0) ? smethod_28(1.0, 0.0, num4, double_0 - num12, num9, double_2, double_1) : num12);
				return num13;
			}
			return 0;
		}
		return ErrorType.Number;
	}

	private static bool smethod_27(double double_0, double double_1)
	{
		double num = 0.0001;
		if (Math.Abs(double_0 - double_1) < num)
		{
			return true;
		}
		return false;
	}

	private static double smethod_28(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, double double_6)
	{
		if (double_0 > double_5)
		{
			return smethod_0(double_1);
		}
		double_0 += 1.0;
		double double_7 = double_4 - double_0;
		double num = (smethod_27(double_7, 2.0) ? (double_3 * 0.5) : (double_3 * double_2));
		double_2 = (smethod_27(double_7, 2.0) ? 1.0 : double_2);
		double_1 = ((!(double_3 < double_6)) ? num : ((!(double_3 - double_6 < 0.0)) ? (double_3 - double_6) : 0.0));
		double_3 -= double_1;
		return smethod_28(double_0, double_1, double_2, double_3, double_4, double_5, double_6);
	}

	internal static object smethod_29(double double_0, DateTime dateTime_0, DateTime dateTime_1, double double_1, double double_2, double double_3, int int_0)
	{
		if (!(double_0 < 0.0) && !(double_1 < 0.0) && !(double_1 >= double_0) && !(double_2 < 0.0) && !(dateTime_0 >= dateTime_1) && !(double_3 < 0.0) && int_0 != 2)
		{
			double num = Math.Ceiling(1.0 / double_3);
			double num2 = smethod_8(dateTime_0, int_0);
			DateTime dateTime_2 = smethod_24(dateTime_0, int_0);
			DateTime dateTime_3 = smethod_24(dateTime_1, int_0);
			double num3 = smethod_11(dateTime_2, dateTime_3, 1, int_0);
			double num4 = num3 / num2 * double_3 * double_0;
			double num5 = 0.0;
			num5 = ((num4 != 0.0) ? num4 : (double_0 * double_3));
			double num6 = 0.0;
			num6 = ((num4 != 0.0) ? (num + 1.0) : num);
			double num7 = double_0 - double_1;
			double num8 = 0.0;
			num8 = ((!(num5 > num7)) ? num5 : num7);
			double num9 = 0.0;
			if (double_0 != double_1 && double_2 <= num6)
			{
				if (double_2 == 0.0)
				{
					num9 = num8;
				}
				else
				{
					double double_4 = double_3 * double_0;
					double double_5 = double_0 - double_1 - num8;
					num9 = smethod_30(1.0, double_4, double_5, double_2);
				}
			}
			else
			{
				num9 = 0.0;
			}
			return num9;
		}
		return ErrorType.Number;
	}

	private static double smethod_30(double double_0, double double_1, double double_2, double double_3)
	{
		if (double_0 > double_3)
		{
			return double_1;
		}
		double_1 = ((double_1 > double_2) ? double_2 : double_1);
		double num = double_2 - double_1;
		double_2 = ((num < 0.0) ? 0.0 : num);
		return smethod_30(double_0 + 1.0, double_1, double_2, double_3);
	}

	internal static object smethod_31(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, int int_0, int int_1)
	{
		if ((int_0 == 1 || int_0 == 2 || int_0 == 4) && !(double_0 < 0.0) && !(double_1 < 0.0) && !(dateTime_0 >= dateTime_1) && int_1 >= 0 && int_1 <= 4)
		{
			return smethod_54(dateTime_0, dateTime_1, double_0, double_1, int_0, int_1, bool_0: false);
		}
		return ErrorType.Number;
	}

	internal static object smethod_32(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, int int_0, int int_1)
	{
		if ((int_0 == 1 || int_0 == 2 || int_0 == 4) && !(double_0 < 0.0) && !(double_1 < 0.0) && !(dateTime_0 >= dateTime_1) && int_1 >= 0 && int_1 <= 4)
		{
			return smethod_54(dateTime_0, dateTime_1, double_0, double_1, int_0, int_1, bool_0: true);
		}
		return ErrorType.Number;
	}

	internal static object smethod_33(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1)
	{
		if ((int_0 == 1 || int_0 == 2 || int_0 == 4) && !(dateTime_0 >= dateTime_1) && int_1 >= 0 && int_1 <= 4)
		{
			double num = 0.0;
			switch (int_1)
			{
			case 0:
				num = smethod_4(smethod_17(dateTime_0, dateTime_1, int_0, int_1), dateTime_0, 0);
				break;
			case 1:
				num = smethod_1(smethod_17(dateTime_0, dateTime_1, int_0, int_1), dateTime_0);
				break;
			case 2:
				num = smethod_1(smethod_17(dateTime_0, dateTime_1, int_0, int_1), dateTime_0);
				break;
			case 3:
				num = smethod_1(smethod_17(dateTime_0, dateTime_1, int_0, int_1), dateTime_0);
				break;
			case 4:
				num = smethod_5(smethod_17(dateTime_0, dateTime_1, int_0, int_1), dateTime_0);
				break;
			}
			return num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_34(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1)
	{
		if ((int_0 == 1 || int_0 == 2 || int_0 == 4) && !(dateTime_0 >= dateTime_1) && int_1 >= 0 && int_1 <= 4)
		{
			double num = 0.0;
			switch (int_1)
			{
			case 0:
				num = 360.0 / (double)int_0;
				break;
			case 1:
				num = smethod_18(dateTime_0, dateTime_1, int_0);
				break;
			case 2:
				num = 360.0 / (double)int_0;
				break;
			case 3:
				num = 365.0 / (double)int_0;
				break;
			case 4:
				num = 360.0 / (double)int_0;
				break;
			}
			return num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_35(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1)
	{
		if ((int_0 == 1 || int_0 == 2 || int_0 == 4) && !(dateTime_0 >= dateTime_1) && int_1 >= 0 && int_1 <= 4)
		{
			double num = 0.0;
			switch (int_1)
			{
			case 0:
			{
				DateTime dateTime_2 = smethod_17(dateTime_0, dateTime_1, int_0, int_1);
				DateTime dateTime_3 = smethod_19(dateTime_0, dateTime_1, int_0, int_1);
				double num2 = smethod_4(dateTime_2, dateTime_3, 1);
				double num3 = smethod_4(dateTime_2, dateTime_0, 0);
				num = num2 - num3;
				break;
			}
			case 1:
				num = smethod_1(dateTime_0, smethod_19(dateTime_0, dateTime_1, int_0, int_1));
				break;
			case 2:
				num = smethod_1(dateTime_0, smethod_19(dateTime_0, dateTime_1, int_0, int_1));
				break;
			case 3:
				num = smethod_1(dateTime_0, smethod_19(dateTime_0, dateTime_1, int_0, int_1));
				break;
			case 4:
				num = smethod_5(smethod_19(dateTime_0, dateTime_1, int_0, int_1), dateTime_0);
				break;
			}
			return num;
		}
		return ErrorType.Number;
	}

	private static double smethod_36(DateTime dateTime_0, DateTime dateTime_1, int int_0)
	{
		double num = smethod_11(dateTime_0, dateTime_1, 1, int_0);
		if (num > 0.0)
		{
			return num;
		}
		return 0.0;
	}

	private static double smethod_37(DateTime dateTime_0, DateTime dateTime_1)
	{
		double num = smethod_4(dateTime_0, dateTime_1, 1);
		if (num > 0.0)
		{
			return num;
		}
		return 0.0;
	}

	private static double smethod_38(DateTime dateTime_0, DateTime dateTime_1, int int_0)
	{
		if (int_0 == 0)
		{
			return smethod_37(dateTime_0, dateTime_1);
		}
		return smethod_36(dateTime_0, dateTime_1, int_0);
	}

	private static double smethod_39(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1, bool bool_0)
	{
		_ = (double)((!bool_0) ? 1 : 0);
		bool flag = ((dateTime_0.Day == smethod_20(dateTime_0.Year, dateTime_0.Month)) ? true : false);
		bool flag2 = false;
		flag2 = ((flag || dateTime_0.Month == 2 || dateTime_0.Day <= 28 || dateTime_0.Day >= smethod_20(dateTime_0.Year, dateTime_0.Month)) ? flag : ((dateTime_1.Day == smethod_20(dateTime_1.Year, dateTime_1.Month)) ? true : false));
		DateTime dateTime = smethod_21(dateTime_0, 0, int_1, flag2);
		_ = dateTime_1 < dateTime;
		smethod_21(dateTime, int_0, int_1, flag2);
		bool flag3 = false;
		flag3 = ((int_0 <= 0) ? ((!(dateTime_1 >= dateTime_0)) ? true : false) : ((!(dateTime_0 >= dateTime_1)) ? true : false));
		double num = 0.0;
		if (flag3)
		{
			return num;
		}
		DateTime dateTime2 = dateTime_1;
		while (dateTime2 < dateTime_0)
		{
			dateTime2 = smethod_21(dateTime2, int_0, int_1, flag2);
			num += 1.0;
		}
		return num - 1.0;
	}

	internal static object smethod_40(DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, double double_0, double double_1, int int_0, int int_1, int int_2)
	{
		if ((int_1 == 1 || int_1 == 2 || int_1 == 4) && !(double_0 < 0.0) && !(double_1 < 0.0) && int_0 >= 0 && !(dateTime_1 <= dateTime_0) && !(dateTime_0 <= dateTime_2) && int_2 >= 0 && int_2 <= 4)
		{
			return smethod_42(dateTime_0, dateTime_1, dateTime_2, double_0, double_1, int_0, int_1, int_2, bool_0: true);
		}
		return ErrorType.Number;
	}

	internal static object smethod_41(DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, double double_0, double double_1, int int_0, int int_1, int int_2)
	{
		if ((int_1 == 1 || int_1 == 2 || int_1 == 4) && !(double_1 < 0.0) && !(double_0 < 0.0) && int_0 >= 0 && !(dateTime_1 <= dateTime_0) && !(dateTime_0 <= dateTime_2) && int_2 >= 0 && int_2 <= 4)
		{
			return smethod_42(dateTime_0, dateTime_1, dateTime_2, double_0, double_1, int_0, int_1, int_2, bool_0: false);
		}
		return ErrorType.Number;
	}

	private static object smethod_42(DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, double double_0, double double_1, int int_0, int int_1, int int_2, bool bool_0)
	{
		double num = int_1;
		int int_3 = 12 / int_1;
		double num2 = (double)smethod_57(dateTime_2, dateTime_1, int_1, int_2);
		DateTime dateTime = dateTime_2;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		for (double num8 = 1.0; num8 <= num2; num8 += 1.0)
		{
			DateTime dateTime2 = smethod_21(dateTime, int_3, int_2, bool_0: false);
			double num9 = smethod_38(dateTime, dateTime2, int_2);
			num5 = ((!(num8 < num2)) ? smethod_38(dateTime, dateTime_1, int_2) : num9);
			num6 = ((!(dateTime2 < dateTime_0)) ? ((!(dateTime < dateTime_0)) ? 0.0 : smethod_36(dateTime, dateTime_0, int_2)) : num5);
			DateTime dateTime_3 = ((dateTime_0 > dateTime) ? dateTime_0 : dateTime);
			DateTime dateTime_4 = ((dateTime_1 < dateTime2) ? dateTime_1 : dateTime2);
			double num10 = smethod_36(dateTime_3, dateTime_4, int_2);
			dateTime = dateTime2;
			num3 += num5 / num9;
			num4 += num6 / num9;
			num7 += num10 / num9;
		}
		double num11 = 100.0 * double_0 / num;
		double num12 = num3 * num11 + (double)int_0;
		double num13 = 0.0;
		double num14 = 0.0;
		if (bool_0)
		{
			num13 = num7 * double_1 / num + 1.0;
			num14 = num4 * num11;
			return num12 / num13 - num14;
		}
		num13 = num4 * num11 + double_1;
		num14 = num / num7;
		return (num12 - num13) / num13 * num14;
	}

	internal static object smethod_43(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, int int_0)
	{
		if (!(double_0 <= 0.0) && !(double_1 <= 0.0) && int_0 >= 0 && int_0 <= 4 && !(dateTime_0 >= dateTime_1))
		{
			double num = smethod_10(dateTime_0, dateTime_1, int_0);
			double num2 = smethod_11(dateTime_0, dateTime_1, 1, int_0);
			double num3 = double_1 - double_0 * double_1 * num2 / num;
			return num3;
		}
		return ErrorType.Number;
	}

	internal static object smethod_44(DateTime dateTime_0, DateTime dateTime_1, double double_0)
	{
		if (!(double_0 <= 0.0) && !(dateTime_0 > dateTime_1) && !(dateTime_0.AddYears(1) < dateTime_1))
		{
			double num = 0.0;
			double num2 = smethod_1(dateTime_0, dateTime_1);
			if (num2 > 182.0)
			{
				double num3 = (100.0 - double_0 * 100.0 * num2 / 360.0) / 100.0;
				double num4 = 0.0;
				num4 = ((num2 != 366.0) ? 365.0 : 366.0);
				double d = Math.Pow(num2 / num4, 2.0) - (2.0 * num2 / num4 - 1.0) * (1.0 - 1.0 / num3);
				double num5 = Math.Sqrt(d);
				double num6 = 2.0 * num2 / num4 - 1.0;
				num = 2.0 * (num5 - num2 / num4) / num6;
			}
			else
			{
				num = 365.0 * double_0 / (360.0 - double_0 * num2);
			}
			return num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_45(DateTime dateTime_0, DateTime dateTime_1, double double_0)
	{
		if (!(double_0 <= 0.0) && !(dateTime_0 > dateTime_1) && !(dateTime_0.AddYears(1) < dateTime_1))
		{
			double num = 0.0;
			double num2 = smethod_1(dateTime_0, dateTime_1);
			num = 100.0 * (1.0 - double_0 * num2 / 360.0);
			return num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_46(DateTime dateTime_0, DateTime dateTime_1, double double_0)
	{
		if (!(double_0 <= 0.0) && !(dateTime_0 >= dateTime_1) && !(dateTime_0.AddYears(1) < dateTime_1))
		{
			double num = 0.0;
			double num2 = smethod_1(dateTime_0, dateTime_1);
			num = (100.0 - double_0) / double_0 * 360.0 / num2;
			return num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_47(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, int int_0)
	{
		if (!(double_0 <= 0.0) && !(double_1 <= 0.0) && int_0 >= 0 && int_0 <= 4 && !(dateTime_0 >= dateTime_1))
		{
			double num = smethod_10(dateTime_0, dateTime_1, int_0);
			double num2 = smethod_11(dateTime_0, dateTime_1, 1, int_0);
			double num3 = (double_1 - double_0) / double_0 * num / num2;
			return num3;
		}
		return ErrorType.Number;
	}

	internal static object smethod_48(DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, DateTime dateTime_3, double double_0, double double_1, int int_0, int int_1, int int_2)
	{
		Class417 @class = new Class417(dateTime_0, dateTime_1, dateTime_2, dateTime_3, double_0, int_0, int_1, int_2, double_1, 0.05);
		object obj = @class.Calculate(0.05);
		if (obj is ErrorType)
		{
			return ErrorType.Value;
		}
		return obj;
	}

	internal static object smethod_49(DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, DateTime dateTime_3, double double_0, double double_1, int int_0, int int_1, int int_2)
	{
		if ((int_1 == 1 || int_1 == 2 || int_1 == 4) && !(double_0 < 0.0) && !(double_1 < 0.0) && int_0 >= 0 && !(dateTime_1 <= dateTime_3) && !(dateTime_3 <= dateTime_0) && !(dateTime_0 <= dateTime_2) && int_2 >= 0 && int_2 <= 4)
		{
			smethod_20(dateTime_1.Year, dateTime_1.Month);
			int num = 12 / int_1;
			int int_3 = -num;
			double num2 = (double)smethod_34(dateTime_0, dateTime_1, int_1, int_2);
			double num3 = (double)smethod_57(dateTime_0, dateTime_1, int_1, int_2);
			double num4 = int_1;
			double num5 = smethod_36(dateTime_2, dateTime_3, int_2);
			if (num5 < num2)
			{
				double num6 = smethod_36(dateTime_0, dateTime_3, int_2);
				double num7 = smethod_36(dateTime_2, dateTime_0, int_2);
				double num8 = double_1 / num4 + 1.0;
				double num9 = num6 / num2;
				double x = num8;
				double num10 = Math.Pow(x, num3 - 1.0 + num9);
				double num11 = (double)int_0 / num10;
				double num12 = 100.0 * double_0 / num4 * num5 / num2 / Math.Pow(x, num9);
				double num13 = 0.0;
				for (int i = 2; (double)i <= num3; i++)
				{
					double num14 = 100.0 * double_0 / num4 / Math.Pow(x, (double)(i - 1) + num9);
					num13 += num14;
				}
				double num15 = double_0 / num4;
				double num16 = num7 / num2 * num15 * 100.0;
				return num11 + num12 + num13 - num16;
			}
			double num17 = (double)smethod_57(dateTime_2, dateTime_3, int_1, int_2);
			DateTime dateTime = dateTime_3;
			double num18 = 0.0;
			double num19 = 0.0;
			double num20 = 0.0;
			double num21 = 0.0;
			for (double num22 = num17; num22 >= 1.0; num22 -= 1.0)
			{
				DateTime dateTime2 = smethod_21(dateTime, int_3, int_2, bool_0: false);
				double num23 = 0.0;
				num23 = ((int_2 != 1) ? num2 : smethod_36(dateTime2, dateTime, int_2));
				num20 = ((!(num22 > 1.0)) ? smethod_36(dateTime_2, dateTime, int_2) : num23);
				DateTime dateTime_4 = ((dateTime_2 > dateTime2) ? dateTime_2 : dateTime2);
				DateTime dateTime_5 = ((dateTime_0 < dateTime) ? dateTime_0 : dateTime);
				num21 = smethod_36(dateTime_4, dateTime_5, int_2);
				dateTime = dateTime2;
				num18 += num20 / num23;
				num19 += num21 / num23;
			}
			double num24 = 0.0;
			if (int_2 != 2 && int_2 != 3)
			{
				DateTime dateTime_6 = (DateTime)smethod_55(dateTime_0, dateTime_3, int_1, int_2);
				double num25 = smethod_11(dateTime_6, dateTime_0, 1, int_2);
				num24 = num2 - num25;
			}
			else
			{
				DateTime dateTime_7 = (DateTime)smethod_56(dateTime_0, dateTime_3, int_1, int_2);
				num24 = smethod_36(dateTime_0, dateTime_7, int_2);
			}
			double num26 = smethod_39(dateTime_3, dateTime_0, num, int_2, bool_0: true);
			double num27 = (double)smethod_57(dateTime_3, dateTime_1, int_1, int_2);
			double num28 = double_1 / num4 + 1.0;
			double num29 = num24 / num2;
			double x2 = num28;
			double num30 = Math.Pow(x2, num29 + num26 + num27);
			double num31 = (double)int_0 / num30;
			double num32 = 100.0 * double_0 / num4 * num18 / Math.Pow(x2, num26 + num29);
			double num33 = 0.0;
			for (int j = 1; (double)j <= num27; j++)
			{
				double num34 = 100.0 * double_0 / num4 / Math.Pow(x2, (double)j + num26 + num29);
				num33 += num34;
			}
			double num35 = 100.0 * double_0 / num4 * num19;
			return num31 + num32 + num33 - num35;
		}
		return ErrorType.Number;
	}

	internal static object smethod_50(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, int int_0, int int_1, int int_2)
	{
		if ((int_1 == 1 || int_1 == 2 || int_1 == 4) && !(double_0 < 0.0) && !(double_1 < 0.0) && int_0 > 0 && !(dateTime_0 >= dateTime_1) && int_2 >= 0 && int_2 <= 4)
		{
			double num = (double)smethod_57(dateTime_0, dateTime_1, int_1, int_2);
			DateTime dateTime_2 = (DateTime)smethod_55(dateTime_0, dateTime_1, int_1, int_2);
			double num2 = smethod_11(dateTime_2, dateTime_0, 1, int_2);
			double num3 = (double)smethod_34(dateTime_0, dateTime_1, int_1, int_2);
			double num4 = num3 - num2;
			double num5 = 100.0 * double_0 / (double)int_1;
			double num6 = num5 * num2 / num3;
			double num7 = (double)int_0 / Math.Pow(1.0 + double_1 / (double)int_1, num - 1.0 + num4 / num3);
			double num8 = 0.0;
			double num9 = 0.0;
			for (int i = 1; (double)i <= num; i++)
			{
				num8 += num5 / Math.Pow(1.0 + double_1 / (double)int_1, (double)(i - 1) + num4 / num3);
			}
			num9 = ((num != 1.0) ? (num7 + num8 - num6) : (((double)int_0 + num5) / (1.0 + num4 / num3 * double_1 / (double)int_1) - num6));
			return num9;
		}
		return ErrorType.Number;
	}

	internal static object smethod_51(DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, double double_0, double double_1, int int_0)
	{
		if (!(double_0 < 0.0) && !(double_1 < 0.0) && !(dateTime_0 >= dateTime_1) && int_0 >= 0 && int_0 <= 4)
		{
			double num = smethod_10(dateTime_2, dateTime_0, int_0);
			double num2 = smethod_11(dateTime_2, dateTime_1, 1, int_0);
			double num3 = smethod_11(dateTime_2, dateTime_0, 1, int_0);
			double num4 = num2 - num3;
			double num5 = 100.0 + num2 / num * double_0 * 100.0;
			double num6 = 1.0 + num4 / num * double_1;
			double num7 = num3 / num * double_0 * 100.0;
			return num5 / num6 - num7;
		}
		return ErrorType.Number;
	}

	internal static object smethod_52(DateTime dateTime_0, DateTime dateTime_1, DateTime dateTime_2, double double_0, double double_1, int int_0)
	{
		if (!(double_0 < 0.0) && !(double_1 <= 0.0) && !(dateTime_0 >= dateTime_1) && int_0 >= 0 && int_0 <= 4)
		{
			double num = smethod_10(dateTime_2, dateTime_0, int_0);
			double num2 = smethod_11(dateTime_2, dateTime_1, 1, int_0);
			double num3 = smethod_11(dateTime_2, dateTime_0, 1, int_0);
			double num4 = num2 - num3;
			double num5 = num2 / num * double_0 + 1.0 - double_1 / 100.0 - num3 / num * double_0;
			double num6 = double_1 / 100.0 + num3 / num * double_0;
			double num7 = num / num4;
			return num5 / num6 * num7;
		}
		return ErrorType.Number;
	}

	internal static object smethod_53(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, double double_2, int int_0, int int_1)
	{
		if ((int_0 == 1 || int_0 == 2 || int_0 == 4) && !(double_0 < 0.0) && !(double_1 <= 0.0) && !(double_2 <= 0.0) && !(dateTime_0 >= dateTime_1) && int_1 >= 0 && int_1 <= 4)
		{
			double num = (double)smethod_57(dateTime_0, dateTime_1, int_0, int_1);
			DateTime dateTime_2 = (DateTime)smethod_55(dateTime_0, dateTime_1, int_0, int_1);
			double num2 = smethod_11(dateTime_2, dateTime_0, 1, int_1);
			double num3 = (double)smethod_34(dateTime_0, dateTime_1, int_0, int_1);
			double num4 = num3 - num2 + 1.0;
			double num5 = 0.0;
			if (num <= 1.0)
			{
				double num6 = double_2 / 100.0 + double_0 / (double)int_0 - (double_1 / 100.0 + num2 / num3 * double_0 / (double)int_0);
				double num7 = double_1 / 100.0 + num2 / num3 * double_0 / (double)int_0;
				num5 = num6 / num7 * (double)int_0 * num3 / num4;
				return num5;
			}
			Class418 @class = new Class418(dateTime_0, dateTime_1, double_0, (int)double_2, int_0, int_1, double_1, 0.05);
			object obj = @class.Calculate(0.05);
			if (obj is ErrorType)
			{
				return ErrorType.Value;
			}
			return obj;
		}
		return ErrorType.Number;
	}

	private static double smethod_54(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, int int_0, int int_1, bool bool_0)
	{
		double num = (double)smethod_33(dateTime_0, dateTime_1, int_0, int_1);
		double num2 = (double)smethod_34(dateTime_0, dateTime_1, int_0, int_1);
		double num3 = (double)smethod_57(dateTime_0, dateTime_1, int_0, int_1);
		double num4 = num2 - num;
		double num5 = num4 / num2;
		double num6 = num5 + num3 - 1.0;
		double num7 = double_1 / (double)int_0 + 1.0;
		double num8 = Math.Pow(num7, num6);
		double num9 = num6 * 100.0 / num8;
		double num10 = 100.0 / num8;
		double num11 = 0.0;
		double num12 = 0.0;
		for (int i = 1; (double)i <= num3; i++)
		{
			double num13 = (double)(i - 1) + num5;
			double num14 = Math.Pow(num7, num13);
			double num15 = 100.0 * double_0 / (double)int_0 / num14;
			num11 += num15 * num13;
			num12 += num15;
		}
		double num16 = num9 + num11;
		double num17 = num10 + num12;
		if (bool_0)
		{
			return num16 / num17 / (double)int_0 / num7;
		}
		return num16 / num17 / (double)int_0;
	}

	internal static object smethod_55(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1)
	{
		if ((int_0 == 1 || int_0 == 2 || int_0 == 4) && !(dateTime_0 >= dateTime_1) && int_1 >= 0 && int_1 <= 4)
		{
			return smethod_17(dateTime_0, dateTime_1, int_0, int_1);
		}
		return ErrorType.Number;
	}

	internal static object smethod_56(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1)
	{
		if ((int_0 == 1 || int_0 == 2 || int_0 == 4) && !(dateTime_0 >= dateTime_1) && int_1 >= 0 && int_1 <= 4)
		{
			return smethod_19(dateTime_0, dateTime_1, int_0, int_1);
		}
		return ErrorType.Number;
	}

	internal static object smethod_57(DateTime dateTime_0, DateTime dateTime_1, int int_0, int int_1)
	{
		if ((int_0 == 1 || int_0 == 2 || int_0 == 4) && !(dateTime_0 >= dateTime_1) && int_1 >= 0 && int_1 <= 4)
		{
			DateTime dateTime = smethod_17(dateTime_0, dateTime_1, int_0, int_1);
			double num = (dateTime_1.Year - dateTime.Year) * 12 + (dateTime_1.Month - dateTime.Month);
			return num * (double)int_0 / 12.0;
		}
		return ErrorType.Number;
	}

	internal static double smethod_58(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = 0.0;
		if (double_0 == 0.0)
		{
			return 0.0 - double_3 - double_2 * double_1;
		}
		double num2 = Class1374.smethod_2(1.0 + double_0, double_1);
		num = (0.0 - double_3) * num2;
		return num - double_2 * (1.0 + double_4 * double_0) * (num2 - 1.0) / double_0;
	}

	internal static double smethod_59(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = 0.0;
		if (double_0 == 0.0)
		{
			return 0.0 - double_3 - double_2 * double_1;
		}
		num = 0.0 - double_3;
		double num2 = Math.Pow(1.0 + double_0, double_1);
		if (double.IsInfinity(num2))
		{
			return (0.0 - double_2) * (1.0 + double_0 * double_4) / double_0;
		}
		num -= double_2 * (1.0 + double_4 * double_0) * ((num2 - 1.0) / double_0);
		return num / num2;
	}

	internal static double smethod_60(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		double num = smethod_62(double_0, double_2, double_3, double_4, double_5);
		double num2 = num;
		double num3 = 0.0;
		if (double_5 == 1.0)
		{
			double_1 -= 1.0;
			double_3 += num;
		}
		for (int i = 0; (double)i < double_1; i++)
		{
			num3 = double_3 * double_0;
			num2 = num + num3;
			double_3 += num2;
		}
		return num2;
	}

	internal static double smethod_61(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		double num = smethod_62(double_0, double_2, double_3, double_4, double_5);
		double num2 = 0.0;
		double num3 = 0.0;
		if (double_5 == 1.0)
		{
			double_1 -= 1.0;
			double_3 += num;
		}
		for (int i = 0; (double)i < double_1; i++)
		{
			num3 = double_3 * double_0;
			num2 = num + num3;
			double_3 += num2;
		}
		return 0.0 - num3;
	}

	internal static double smethod_62(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = 0.0;
		if (double_0 == 0.0)
		{
			return (0.0 - (double_3 + double_2)) / double_1;
		}
		double num2 = Math.Pow(1.0 + double_0, double_1);
		if (double.IsInfinity(num2))
		{
			return (0.0 - double_2) * double_0 / (1.0 + double_0 * double_4);
		}
		num = 0.0 - double_3;
		return (num - double_2 * num2) / ((1.0 + double_4 * double_0) * ((num2 - 1.0) / double_0));
	}

	internal static object smethod_63(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		if (double_2 + double_3 + double_1 * double_0 == 0.0)
		{
			return 0.0;
		}
		Class420 @class = new Class420();
		return @class.Calculate(double_0, double_1, double_2, double_3, double_4, double_5);
	}

	internal static double smethod_64(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		double num = 0.0;
		num = (double_1 * (1.0 + double_0 * double_4) / double_0 - double_3) / (double_2 + double_1 * (1.0 + double_0 * double_4) / double_0);
		return Math.Log(num, 1.0 + double_0);
	}

	internal static object smethod_65(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		if (double_3 > double_2 + 1.0)
		{
			return ErrorType.Number;
		}
		if (double_3 > double_2 && double_4 == 12.0)
		{
			return ErrorType.Number;
		}
		if (double_0 == 0.0)
		{
			return 0.0;
		}
		double num = 1.0 - Math.Pow(double_1 / double_0, 1.0 / double_2);
		num = Math.Floor(num * 1000.0 + 0.5) / 1000.0;
		double num2 = double_0 * num * double_4 / 12.0;
		if (double_3 <= 1.0)
		{
			return num2 * double_3;
		}
		for (int i = 2; (double)i < double_3; i++)
		{
			num2 += (double_0 - num2) * num;
		}
		if (double_3 > double_2)
		{
			return (double_0 - num2) * num * (12.0 - double_4) / 12.0;
		}
		return (double_0 - num2) * num;
	}

	internal static object smethod_66(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		if (double_3 >= double_2 + 1.0)
		{
			return ErrorType.Number;
		}
		double num = double_4 / double_2;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = (int)(double_3 + 0.5);
		for (int i = 1; i <= num4; i++)
		{
			num3 = Math.Min((double_0 - num2) * num, double_0 - num2 - double_1);
			num2 += num3;
		}
		return num3 - num3 * (double_3 - (double)num4);
	}

	internal static double smethod_67(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5, bool bool_0)
	{
		if (double_4 > double_2 + 1.0)
		{
			return 0.0;
		}
		double num = double_5 / double_2;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		int num5 = (int)(double_4 + 0.5);
		for (int i = 1; i <= num5; i++)
		{
			num4 = Math.Min((double_0 - num2) * num, double_0 - num2 - double_1);
			if (double_3 < (double)i)
			{
				num3 += num4;
			}
			num2 += num4;
		}
		return num3 - num4 * ((double)num5 - double_4);
	}

	internal static object smethod_68(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, int int_0)
	{
		if (!(double_0 <= 0.0) && !(double_1 <= 0.0) && int_0 >= 0 && int_0 <= 4 && !(dateTime_0 >= dateTime_1))
		{
			double num = smethod_10(dateTime_0, dateTime_1, int_0);
			double num2 = smethod_11(dateTime_0, dateTime_1, 1, int_0);
			double num3 = 1.0 - double_0 / double_1;
			double num4 = num3 * num / num2;
			return num4;
		}
		return ErrorType.Number;
	}

	internal static object smethod_69(double double_0, double double_1)
	{
		if (double_1 < 0.0)
		{
			return ErrorType.Number;
		}
		if (double_1 == 0.0)
		{
			return ErrorType.Div;
		}
		double num = (int)double_0;
		double num2 = double_0 % 1.0;
		double num3 = num + num2 / double_1 * 100.0;
		return num3;
	}

	internal static object smethod_70(double double_0, double double_1)
	{
		if (double_1 < 0.0)
		{
			return ErrorType.Number;
		}
		if (double_1 == 0.0)
		{
			return ErrorType.Div;
		}
		double num = (int)double_0;
		double num2 = double_0 % 1.0;
		double num3 = num + num2 * double_1 / 100.0;
		return num3;
	}

	internal static object smethod_71(double double_0, int int_0)
	{
		if (!(double_0 <= 0.0) && int_0 >= 1)
		{
			double num = Math.Pow(1.0 + double_0 / (double)int_0, int_0) - 1.0;
			return num;
		}
		return ErrorType.Number;
	}

	internal static object smethod_72(double double_0, int int_0)
	{
		if (!(double_0 <= 0.0) && int_0 >= 1)
		{
			double num = Math.Pow(double_0 + 1.0, 1.0 / (double)int_0);
			double num2 = (num - 1.0) * (double)int_0;
			return num2;
		}
		return ErrorType.Number;
	}

	internal static object smethod_73(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, int int_0)
	{
		if (!(double_0 <= 0.0) && !(double_1 <= 0.0) && int_0 >= 0 && int_0 <= 4 && !(dateTime_0 >= dateTime_1))
		{
			double num = smethod_10(dateTime_0, dateTime_1, int_0);
			double num2 = smethod_11(dateTime_0, dateTime_1, 1, int_0);
			double num3 = (double_1 - double_0) / double_0 * num / num2;
			return num3;
		}
		return ErrorType.Number;
	}

	internal static object smethod_74(DateTime dateTime_0, DateTime dateTime_1, double double_0, double double_1, int int_0)
	{
		if (!(double_0 <= 0.0) && !(double_1 <= 0.0) && int_0 >= 0 && int_0 <= 4 && !(dateTime_0 >= dateTime_1))
		{
			double num = smethod_10(dateTime_0, dateTime_1, int_0);
			double num2 = smethod_11(dateTime_0, dateTime_1, 1, int_0);
			double num3 = double_1 * num2 / num;
			double num4 = double_0 / (1.0 - num3);
			return num4;
		}
		return ErrorType.Number;
	}

	internal static double smethod_75(double double_0, double[] double_1)
	{
		foreach (double num in double_1)
		{
			double_0 *= 1.0 + num;
		}
		return double_0;
	}

	internal static double smethod_76(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = smethod_62(double_0, double_1, double_2, 0.0, double_5);
		int i = 1;
		if (double_5 == 1.0)
		{
			double_2 += num4;
			i++;
		}
		for (; i <= (int)double_4; i++)
		{
			num3 = double_2 * double_0;
			num = num4 + num3;
			double_2 += num;
			if (double_3 <= (double)i)
			{
				num2 += num3;
			}
		}
		return 0.0 - num2;
	}

	internal static double smethod_77(double double_0, double double_1, double double_2, double double_3)
	{
		double num = double_3 / double_2;
		return (0.0 - (double_3 - num * double_1)) * double_0;
	}

	internal static double smethod_78(double double_0, double double_1, double double_2, double double_3, double double_4, double double_5)
	{
		double num = 0.0;
		num = smethod_76(double_0, double_1, double_2, double_3, double_4, double_5);
		return (double_4 - double_3 + 1.0) * smethod_62(double_0, double_1, double_2, 0.0, double_5) - num;
	}

	internal static double smethod_79(double double_0, double[] double_1)
	{
		double num = double_0 + 1.0;
		double num2 = 0.0;
		for (int i = 0; i < double_1.Length; i++)
		{
			num2 += double_1[i] / num;
			num *= double_0 + 1.0;
		}
		return num2;
	}

	internal static object smethod_80(double[] double_0, double double_1, double double_2)
	{
		int num = 0;
		for (int i = 0; i < double_0.Length; i++)
		{
			if (double_0[i] < 0.0)
			{
				num++;
			}
		}
		if (num != 0 && num != double_0.Length)
		{
			double[] array = new double[double_0.Length - num];
			double[] array2 = new double[num];
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < double_0.Length; j++)
			{
				if (double_0[j] < 0.0)
				{
					array2[num3++] = double_0[j];
				}
				else
				{
					array[num2++] = double_0[j];
				}
			}
			double num4 = (0.0 - smethod_79(double_2, array)) * Math.Pow(1.0 + double_2, array.Length);
			double num5 = smethod_79(double_1, array2) * (1.0 + double_1);
			return Math.Pow(num4 / num5, 1.0 / (double)(double_0.Length - 1)) - 1.0;
		}
		return ErrorType.Div;
	}
}
