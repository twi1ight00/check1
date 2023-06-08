using System;
using Aspose.Cells;
using ns2;
using ns22;

namespace ns12;

internal class Class1374
{
	internal static double[] double_0 = new double[31]
	{
		1.0, 0.1, 0.01, 0.001, 0.0001, 1E-05, 1E-06, 1E-07, 1E-08, 1E-09,
		1E-10, 1E-11, 1E-12, 1E-13, 1E-14, 1E-15, 1E-16, 1E-17, 1E-18, 1E-19,
		1E-20, 1E-21, 1E-22, 1E-23, 1E-24, 1E-25, 1E-26, 1E-27, 1E-28, 1E-29,
		1E-30
	};

	internal static bool smethod_0(double double_1, double double_2)
	{
		double num = Math.Abs(double_1 - double_2);
		if (num < double.Epsilon)
		{
			return true;
		}
		if (num < 0.0001)
		{
			int num2 = (int)Math.Log10(Math.Abs(double_1));
			int num3 = 14 - num2;
			if (num3 >= 0)
			{
				if (num3 >= double_0.Length)
				{
					return num < Math.Pow(10.0, -num3);
				}
				return num < double_0[num3];
			}
		}
		return double_1 == double_2;
	}

	internal static object smethod_1(object object_0, bool bool_0)
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return Math.Abs((double)object_0);
		case TypeCode.DateTime:
			return Math.Abs(CellsHelper.GetDoubleFromDateTime((DateTime)object_0, bool_0));
		default:
			return ErrorType.Value;
		case TypeCode.String:
			return ErrorType.Value;
		case TypeCode.Boolean:
			if ((bool)object_0)
			{
				return 1.0;
			}
			return 0.0;
		}
	}

	public static double smethod_2(double double_1, double double_2)
	{
		if (double_2 < 0.0)
		{
			return 1.0 / smethod_2(double_1, 0.0 - double_2);
		}
		int num = (int)double_2;
		if (double_2 != (double)num)
		{
			return Math.Pow(double_1, double_2);
		}
		return smethod_3(double_1, num);
	}

	public static double smethod_3(double double_1, int int_0)
	{
		if (double_1 == 0.0)
		{
			return 0.0;
		}
		if (int_0 == 0)
		{
			return 1.0;
		}
		double num = 1.0;
		while (int_0 != 0)
		{
			int num2 = int_0 % 2;
			int num3 = int_0 / 2;
			if (num2 != 0)
			{
				num *= double_1;
			}
			double_1 *= double_1;
			int_0 = num3;
		}
		return num;
	}

	public static double smethod_4(double double_1, int int_0)
	{
		if (int_0 > 13)
		{
			return double_1;
		}
		if (int_0 > 0 && int_0 != 1)
		{
			if (Math.Abs(double_1) < 7.922816251426434E+28)
			{
				decimal d = (decimal)double_1;
				d = Math.Round(d, int_0, MidpointRounding.AwayFromZero);
				return (double)d;
			}
			return Math.Round(Math.Round(double_1, 13), int_0, MidpointRounding.AwayFromZero);
		}
		double num = Math.Pow(10.0, int_0);
		if (double_1 > 0.0)
		{
			return Math.Floor(double_1 * num + 0.5) / num;
		}
		return Math.Ceiling(double_1 * num - 0.5) / num;
	}

	internal static object smethod_5(Workbook workbook_0, object object_0, object object_1, bool bool_0)
	{
		if (object_0 == null)
		{
			object_0 = 0.0;
		}
		if (object_1 == null)
		{
			object_1 = 0.0;
		}
		if (!(object_0 is Array) && !(object_1 is Array))
		{
			double num = 0.0;
			double num2 = 0.0;
			object_0 = Class1660.smethod_26(object_0, workbook_0.Settings.Date1904);
			if (object_0 is double num3)
			{
				object_1 = Class1660.smethod_26(object_1, workbook_0.Settings.Date1904);
				if (object_1 is double num4)
				{
					if (bool_0)
					{
						return num3 + num4;
					}
					if (smethod_0(num3, num4))
					{
						return 0.0;
					}
					double num5 = num3 - num4;
					return num5;
				}
				return object_1;
			}
			return object_0;
		}
		return Class1120.smethod_1(workbook_0, object_0, object_1, bool_0);
	}

	internal static object smethod_6(Workbook workbook_0, object object_0, object object_1)
	{
		if (object_0 == null)
		{
			return 0.0;
		}
		if (object_1 == null)
		{
			return 0.0;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_1 is ErrorType)
		{
			return object_1;
		}
		if (!(object_0 is Array) && !(object_1 is Array))
		{
			double num = 0.0;
			double num2 = 0.0;
			object_0 = Class1660.smethod_26(object_0, workbook_0.Settings.Date1904);
			if (object_0 is ErrorType)
			{
				return object_0;
			}
			num = (double)object_0;
			object_1 = Class1660.smethod_26(object_1, workbook_0.Settings.Date1904);
			if (object_1 is ErrorType)
			{
				return object_1;
			}
			num2 = (double)object_1;
			return num * num2;
		}
		return Class1120.smethod_2(workbook_0, object_0, object_1);
	}

	internal static object smethod_7(Workbook workbook_0, object object_0, object object_1)
	{
		object_0 = Class1660.smethod_26(object_0, workbook_0.Settings.Date1904);
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		object_1 = Class1660.smethod_26(object_1, workbook_0.Settings.Date1904);
		if (object_1 is ErrorType)
		{
			return object_1;
		}
		double num = (double)object_0;
		double num2 = (double)object_1;
		if (Math.Abs(num2) < double.Epsilon)
		{
			return ErrorType.Div;
		}
		double num3 = num / num2;
		return num3;
	}

	internal static object smethod_8(Workbook workbook_0, object object_0, object object_1)
	{
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_1 is ErrorType)
		{
			return object_1;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
		{
			double num2 = (double)object_0;
			switch (Type.GetTypeCode(object_1.GetType()))
			{
			case TypeCode.Double:
			{
				double num = (double)object_1;
				if (num2 == (double)object_1)
				{
					return true;
				}
				return false;
			}
			case TypeCode.DateTime:
			{
				double num = CellsHelper.GetDoubleFromDateTime((DateTime)object_1, workbook_0.Settings.Date1904);
				if (num2 == num)
				{
					return true;
				}
				return false;
			}
			case TypeCode.String:
			{
				string text2 = (string)object_1;
				if (Class1677.smethod_20(text2))
				{
					double num = double.Parse(text2);
					if (num2 == num)
					{
						return true;
					}
					return false;
				}
				try
				{
					DateTime dateTime = DateTime.Parse(text2);
					double num = CellsHelper.GetDoubleFromDateTime(dateTime, workbook_0.Settings.Date1904);
					if (num2 == num)
					{
						return true;
					}
					return false;
				}
				catch
				{
					return false;
				}
			}
			}
			goto IL_022d;
		}
		case TypeCode.DateTime:
			switch (Type.GetTypeCode(object_1.GetType()))
			{
			case TypeCode.Double:
				return smethod_8(workbook_0, object_1, object_0);
			case TypeCode.DateTime:
				if ((DateTime)object_0 == (DateTime)object_1)
				{
					return true;
				}
				return false;
			case TypeCode.String:
			{
				string text2 = (string)object_1;
				if (Class1677.smethod_20(text2))
				{
					double num = double.Parse(text2);
					return smethod_8(workbook_0, object_0, num);
				}
				try
				{
					DateTime dateTime = DateTime.Parse(text2);
					if ((DateTime)object_0 == dateTime)
					{
						return true;
					}
					return false;
				}
				catch
				{
					return false;
				}
			}
			}
			goto IL_022d;
		default:
			return false;
		case TypeCode.String:
			switch (Type.GetTypeCode(object_1.GetType()))
			{
			case TypeCode.Double:
			case TypeCode.DateTime:
				return smethod_8(workbook_0, object_1, object_0);
			case TypeCode.String:
			{
				string text = (string)object_0;
				string text2 = (string)object_1;
				return text == text2;
			}
			}
			goto IL_022d;
		case TypeCode.Boolean:
			{
				return object_0.ToString() == object_1.ToString();
			}
			IL_022d:
			return false;
		}
	}

	internal static object smethod_9(Workbook workbook_0, object object_0)
	{
		if (object_0 == null)
		{
			return true;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
		{
			double doubleFromDateTime = (double)object_0;
			if (doubleFromDateTime == 0.0)
			{
				return true;
			}
			return false;
		}
		case TypeCode.DateTime:
		{
			double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbook_0.Settings.Date1904);
			if (doubleFromDateTime == 0.0)
			{
				return true;
			}
			return false;
		}
		default:
			return ErrorType.Value;
		case TypeCode.String:
			return ErrorType.Value;
		case TypeCode.Boolean:
			return !(bool)object_0;
		}
	}

	internal static object smethod_10(Workbook workbook_0, object object_0, object object_1)
	{
		object_0 = Class1660.smethod_26(object_0, workbook_0.Settings.Date1904);
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		object_1 = Class1660.smethod_26(object_1, workbook_0.Settings.Date1904);
		if (object_1 is ErrorType)
		{
			return object_1;
		}
		double num = (double)object_0;
		double num2 = (double)object_1;
		if (Math.Abs(num) < double.Epsilon)
		{
			if ((double)object_1 < 0.0)
			{
				return ErrorType.Div;
			}
			if (Math.Abs(num2) < double.Epsilon)
			{
				return ErrorType.Number;
			}
		}
		double num3 = 0.0;
		if (num < 0.0)
		{
			if (Math.Abs(num2) < double.Epsilon)
			{
				return 1.0;
			}
			if (Math.Abs(num2) < 1.0)
			{
				double num4 = 1.0 / num2;
				if (num4 % 2.0 != 0.0)
				{
					num3 = 0.0 - Math.Pow(0.0 - num, num2);
					if (double.IsNaN(num3))
					{
						return ErrorType.Number;
					}
					return num3;
				}
				return ErrorType.Number;
			}
		}
		num3 = Math.Pow((double)object_0, (double)object_1);
		if (double.IsNaN(num3))
		{
			return ErrorType.Number;
		}
		return num3;
	}

	internal static object smethod_11(object object_0, object object_1, Workbook workbook_0)
	{
		object_0 = Class1660.smethod_26(object_0, workbook_0.Settings.Date1904);
		if (object_0 is double num)
		{
			object_1 = Class1660.smethod_26(object_1, workbook_0.Settings.Date1904);
			if (object_1 is double)
			{
				int num2 = (int)Class1179.ToDouble(object_1);
				if (num2 < -308)
				{
					return ErrorType.Number;
				}
				double num3 = Math.Pow(10.0, num2);
				double num4 = num * num3;
				if (num4 < 2147483647.0 && num4 > -2147483648.0)
				{
					int length = ((int)num4).ToString().Length;
					if (length < 15)
					{
						num4 = Math.Round(num4, 15 - length);
					}
				}
				if (num4 > 0.0)
				{
					return Math.Floor(num4) / num3;
				}
				return Math.Ceiling(num4) / num3;
			}
			return object_1;
		}
		return object_0;
	}

	internal static object smethod_12(object object_0, object object_1, Workbook workbook_0)
	{
		object_0 = Class1660.smethod_26(object_0, workbook_0.Settings.Date1904);
		if (object_0 is double)
		{
			object_1 = Class1660.smethod_26(object_1, workbook_0.Settings.Date1904);
			if (object_1 is double)
			{
				int int_ = (int)Class1179.ToDouble(object_1);
				return smethod_4((double)object_0, int_);
			}
			return object_1;
		}
		return object_0;
	}

	internal static object smethod_13(object object_0, object object_1, Workbook workbook_0)
	{
		object_0 = Class1660.smethod_26(object_0, workbook_0.Settings.Date1904);
		if (object_0 is double num)
		{
			object_1 = Class1660.smethod_26(object_1, workbook_0.Settings.Date1904);
			if (object_1 is double)
			{
				int num2 = (int)Class1179.ToDouble(object_1);
				if (num2 < -308)
				{
					return ErrorType.Number;
				}
				double num3 = Math.Pow(10.0, num2);
				double num4 = num * num3;
				if (num4 < 2147483647.0 && num4 > -2147483648.0)
				{
					int length = ((int)num4).ToString().Length;
					if (length < 15)
					{
						num4 = Math.Round(num4, 15 - length);
					}
				}
				if (num4 > 0.0)
				{
					return Math.Ceiling(num4) / num3;
				}
				return Math.Floor(num4) / num3;
			}
			return object_1;
		}
		return object_0;
	}
}
