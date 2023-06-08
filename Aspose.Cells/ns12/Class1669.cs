using System;
using System.Collections;
using Aspose.Cells;

namespace ns12;

internal class Class1669
{
	public static object smethod_0(int int_0, int int_1, double double_0, bool bool_0)
	{
		bool isError = true;
		object result = Class1668.smethod_20(int_0, int_1, double_0, bool_0, out isError);
		if (isError)
		{
			result = "#NUM!";
		}
		return result;
	}

	public static object smethod_1(double double_0, double double_1, bool bool_0)
	{
		bool isError = true;
		object result = Class1668.smethod_19(double_0, double_1, bool_0, out isError);
		if (isError)
		{
			result = "#NUM!";
		}
		return result;
	}

	internal static double smethod_2(int int_0, double double_0, bool bool_0)
	{
		if (bool_0)
		{
			if (int_0 == 0)
			{
				return Math.Exp(0.0 - double_0);
			}
			double num = 1.0;
			double num2 = 1.0;
			double num3 = 1.0;
			for (int i = 1; i <= int_0; i++)
			{
				num *= (double)i;
				num2 *= double_0;
				num3 += num2 / num;
			}
			return num3 / Math.Exp(double_0);
		}
		double num4 = int_0;
		if (int_0 == 0)
		{
			num4 = 1.0;
		}
		else
		{
			for (int num5 = int_0 - 1; num5 > 1; num5--)
			{
				num4 *= (double)num5;
			}
		}
		return Class1374.smethod_3(double_0, int_0) / (Math.Exp(double_0) * num4);
	}

	internal static object smethod_3(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		bool isError = true;
		if (!(double_0 < double_3) && !(double_0 > double_4) && !(double_4 <= double_3) && !(double_1 <= 0.0) && double_2 > 0.0)
		{
			object result = Class1668.smethod_1(double_0, double_1, double_2, double_3, double_4, out isError);
			if (isError)
			{
				result = "#NUM!";
			}
			return result;
		}
		return "#NUM!";
	}

	internal static object smethod_4(double double_0, double double_1, double double_2, double double_3, double double_4)
	{
		bool isError = true;
		object result = Class1668.smethod_2(double_0, double_1, double_2, double_3, double_4, out isError);
		if (isError)
		{
			result = "#NUM!";
		}
		return result;
	}

	internal static object smethod_5(double double_0, double double_1, double double_2, bool bool_0)
	{
		object obj = Class1668.smethod_17(double_0, double_1, double_2, bool_0);
		if (double.IsNaN((double)obj))
		{
			obj = "#NUM!";
		}
		return obj;
	}

	internal static object smethod_6(double double_0, double double_1, double double_2)
	{
		object obj = Class1668.smethod_18(double_0, double_1, double_2);
		if (double.IsNaN((double)obj))
		{
			obj = "#NUM!";
		}
		return obj;
	}

	internal static object smethod_7(double double_0, double double_1, int int_0)
	{
		bool isError = true;
		object result = Class1668.smethod_4(double_0, (long)double_1, int_0, out isError);
		if (isError)
		{
			result = "#NUM!";
		}
		return result;
	}

	internal static object smethod_8(double double_0, double double_1)
	{
		bool isError = true;
		object result = Class1668.smethod_5(double_0, (long)double_1, out isError);
		if (isError)
		{
			result = "#NUM!";
		}
		return result;
	}

	internal static object smethod_9(double double_0, double double_1)
	{
		if (!(double_0 < 0.0) && !(double_1 < 1.0) && double_1 <= 10000000000.0)
		{
			bool isError = true;
			object result = Class1668.smethod_6(double_0, (long)double_1, out isError);
			if (isError)
			{
				result = "#NUM!";
			}
			return result;
		}
		return "#NUM!";
	}

	internal static object smethod_10(double double_0, double double_1)
	{
		bool isError = true;
		object result = Class1668.smethod_7(double_0, (long)double_1, out isError);
		if (isError)
		{
			result = "#NUM!";
		}
		return result;
	}

	internal static object smethod_11(double double_0, double double_1, double double_2)
	{
		bool isError = true;
		object result = Class1668.smethod_9(double_0, (long)double_1, (long)double_2, out isError);
		if (isError)
		{
			result = "#NUM!";
		}
		return result;
	}

	internal static object smethod_12(double double_0, double double_1, double double_2)
	{
		bool isError = true;
		object result = Class1668.smethod_10(double_0, (long)double_1, (long)double_2, out isError);
		if (isError)
		{
			result = "#NUM!";
		}
		return result;
	}

	private static object smethod_13(object object_0, bool bool_0)
	{
		ArrayList arrayList = new ArrayList();
		Array array = (Array)object_0;
		for (int i = 0; i < array.Length; i++)
		{
			Array array2 = (Array)array.GetValue(i);
			if (array2 == null)
			{
				continue;
			}
			for (int j = 0; j < array2.Length; j++)
			{
				object value = array2.GetValue(j);
				if (value != null)
				{
					if (value is ErrorType)
					{
						return value;
					}
					switch (Type.GetTypeCode(value.GetType()))
					{
					case TypeCode.Double:
						arrayList.Add(value);
						break;
					case TypeCode.DateTime:
						arrayList.Add(CellsHelper.GetDoubleFromDateTime((DateTime)value, bool_0));
						break;
					}
				}
			}
		}
		arrayList.Sort();
		return arrayList;
	}

	internal static object smethod_14(ArrayList arrayList_0, double double_0)
	{
		double num = (double)(arrayList_0.Count - 1) * double_0;
		int num2 = (int)num;
		double num3 = num - (double)num2;
		if (num3 == 0.0)
		{
			return arrayList_0[num2];
		}
		return (1.0 - num3) * (double)arrayList_0[num2] + num3 * (double)arrayList_0[num2 + 1];
	}

	internal static object smethod_15(object object_0, object object_1, WorkbookSettings workbookSettings_0)
	{
		if (object_0 == null)
		{
			return "#NUM!";
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			if (object_1 != null)
			{
				object_1 = Class1660.smethod_26(object_1, workbookSettings_0.Date1904);
				if (object_1 is double num3)
				{
					if (!(num3 < 0.0) && num3 <= 1.0)
					{
						return object_0;
					}
					return "#NUM!";
				}
				return object_1;
			}
			return object_0;
		case TypeCode.DateTime:
			if (object_1 != null)
			{
				object_1 = Class1660.smethod_26(object_1, workbookSettings_0.Date1904);
				if (object_1 is double num2)
				{
					if (!(num2 < 0.0) && num2 <= 1.0)
					{
						return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbookSettings_0.Date1904);
					}
					return "#NUM!";
				}
				return object_1;
			}
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbookSettings_0.Date1904);
		default:
			if (object_0 is Array)
			{
				double num = 0.0;
				if (object_1 != null)
				{
					object_1 = Class1660.smethod_26(object_1, workbookSettings_0.Date1904);
					if (!(object_1 is double))
					{
						return object_1;
					}
					num = (double)object_1;
				}
				if (!(num < 0.0) && num <= 1.0)
				{
					object obj = smethod_13(object_0, workbookSettings_0.Date1904);
					if (obj is ErrorType)
					{
						return obj;
					}
					if (obj is string)
					{
						return obj;
					}
					ArrayList arrayList = (ArrayList)obj;
					if (arrayList.Count == 0)
					{
						return "#NUM!";
					}
					return smethod_14(arrayList, num);
				}
				return "#NUM!";
			}
			return "#NUM!";
		case TypeCode.Boolean:
		case TypeCode.String:
			return "#NUM!";
		}
	}

	internal static object smethod_16(object object_0, object object_1, WorkbookSettings workbookSettings_0)
	{
		if (object_0 == null)
		{
			return "#NUM!";
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return object_0;
		case TypeCode.DateTime:
			return CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbookSettings_0.Date1904);
		default:
			if (object_0 is Array)
			{
				double num = 0.0;
				if (object_1 != null)
				{
					object_1 = Class1660.smethod_26(object_1, workbookSettings_0.Date1904);
					if (!(object_1 is double))
					{
						return object_1;
					}
					num = (double)object_1;
				}
				if (!(num < 0.0) && num <= 4.0)
				{
					object obj = smethod_13(object_0, workbookSettings_0.Date1904);
					if (obj is ErrorType)
					{
						return obj;
					}
					if (obj is string)
					{
						return obj;
					}
					ArrayList arrayList = (ArrayList)obj;
					if (arrayList.Count == 0)
					{
						return "#NUM!";
					}
					return (int)num switch
					{
						0 => arrayList[0], 
						1 => smethod_14(arrayList, 0.25), 
						2 => smethod_14(arrayList, 0.5), 
						3 => smethod_14(arrayList, 0.75), 
						4 => arrayList[arrayList.Count - 1], 
						_ => "#NUM!", 
					};
				}
				return "#NUM!";
			}
			return "#NUM!";
		case TypeCode.Boolean:
		case TypeCode.String:
			return "#NUM!";
		}
	}
}
