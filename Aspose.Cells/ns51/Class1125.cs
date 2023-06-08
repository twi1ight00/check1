using System;
using Aspose.Cells;
using ns12;
using ns2;
using ns22;

namespace ns51;

internal class Class1125
{
	internal static object smethod_0(Class1277 class1277_0, Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 4 || class1661_0.method_7().Count == 3))
		{
			object obj = class1277_0.method_5((Class1661)class1661_0.method_7()[0], cell_0);
			if (obj == null)
			{
				obj = 0.0;
			}
			object obj2 = null;
			bool flag = false;
			_ = (Class1661)class1661_0.method_7()[1];
			int num = -1;
			object obj3 = Class1660.smethod_26(class1277_0.method_5((Class1661)class1661_0.method_7()[2], cell_0), class1277_0.workbook_0.Settings.Date1904);
			if (obj3 is double)
			{
				num = (int)Class1179.ToDouble(obj3) - 1;
				if (num < 0)
				{
					return ErrorType.Value;
				}
				obj2 = class1277_0.method_5((Class1661)class1661_0.method_7()[1], cell_0);
				if (obj2 == null)
				{
					return obj2;
				}
				if (obj2 is ErrorType)
				{
					return obj2;
				}
				Struct87 @struct = default(Struct87);
				if (obj2 is Struct87)
				{
					@struct = (Struct87)obj2;
					obj2 = class1277_0.method_37(class1661_0, class1277_0.workbook_0.Worksheets[@struct.int_1], cell_0, @struct.cellArea_0.StartRow, @struct.cellArea_0.StartRow, @struct.cellArea_0.StartColumn, @struct.cellArea_0.EndColumn);
					flag = true;
					if (num > @struct.cellArea_0.EndRow - @struct.cellArea_0.StartRow)
					{
						return ErrorType.Ref;
					}
				}
				if (!(obj2 is Array))
				{
					return ErrorType.Ref;
				}
				bool bool_ = true;
				if (class1661_0.method_7().Count == 4)
				{
					object obj4 = class1277_0.method_5((Class1661)class1661_0.method_7()[3], cell_0);
					if (obj4 is ErrorType)
					{
						return obj4;
					}
					switch (Type.GetTypeCode(obj4.GetType()))
					{
					case TypeCode.Double:
						if ((double)obj4 == 0.0)
						{
							bool_ = false;
						}
						break;
					case TypeCode.DateTime:
					{
						double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)obj4, class1277_0.workbook_0.Settings.Date1904);
						if (doubleFromDateTime == 0.0)
						{
							bool_ = false;
						}
						break;
					}
					case TypeCode.String:
						return ErrorType.Value;
					case TypeCode.Boolean:
						bool_ = (bool)obj4;
						break;
					}
				}
				int num2 = 0;
				object obj5 = smethod_1(class1277_0, obj, obj2, bool_);
				if (obj5 is double)
				{
					num2 = (int)Class1179.ToDouble(obj5);
					if (flag)
					{
						Cell cell = class1277_0.workbook_0.Worksheets[@struct.int_1].Cells.CheckCell(@struct.cellArea_0.StartRow + num, @struct.cellArea_0.StartColumn + num2);
						if (cell == null)
						{
							return null;
						}
						return class1277_0.method_211(cell);
					}
					Array array = (Array)obj2;
					if (num >= array.Length)
					{
						return ErrorType.Ref;
					}
					Array array2 = (Array)array.GetValue(num);
					return array2.GetValue(num2);
				}
				return obj5;
			}
			return ErrorType.Value;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private static object smethod_1(Class1277 class1277_0, object object_0, object object_1, bool bool_0)
	{
		int num = -1;
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		if (object_0 is object[][])
		{
			object_0 = ((object[][])object_0)[0][0];
		}
		if (object_0 == null)
		{
			object_0 = 0.0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return smethod_2(class1277_0, (double)object_0, (Array)object_1, bool_0);
		case TypeCode.DateTime:
		{
			double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)object_0, class1277_0.workbook_0.Settings.Date1904);
			return smethod_2(class1277_0, doubleFromDateTime, (Array)object_1, bool_0);
		}
		default:
			return ErrorType.Value;
		case TypeCode.String:
		{
			string text = (string)object_0;
			text = text.ToUpper();
			Array array2 = (Array)((Array)object_1).GetValue(0);
			int num3 = 0;
			while (true)
			{
				if (num3 < array2.Length)
				{
					object value2 = array2.GetValue(num3);
					if (value2 != null)
					{
						string text2 = value2.ToString().ToUpper();
						if (text2 == text)
						{
							break;
						}
						if (bool_0 && text.IndexOf(text2) != -1)
						{
							num = num3;
						}
					}
					num3++;
					continue;
				}
				if (bool_0)
				{
					if (num != -1)
					{
						return (double)num;
					}
					return ErrorType.NA;
				}
				return ErrorType.NA;
			}
			return (double)num3;
		}
		case TypeCode.Boolean:
		{
			bool flag = (bool)object_0;
			Array array = (Array)((Array)object_1).GetValue(0);
			int num2 = 0;
			while (true)
			{
				if (num2 < array.Length)
				{
					object value = array.GetValue(num2);
					if (value != null && value is bool && flag == (bool)value)
					{
						break;
					}
					num2++;
					continue;
				}
				return ErrorType.NA;
			}
			return (double)num2;
		}
		}
	}

	private static object smethod_2(Class1277 class1277_0, double double_0, Array array_0, bool bool_0)
	{
		if (bool_0)
		{
			int num = -1;
			Array array = (Array)array_0.GetValue(0);
			int length = array.Length;
			for (int i = 0; i < length; i++)
			{
				object value = array.GetValue(i);
				if (value == null || !(Class1660.smethod_26(value, class1277_0.workbook_0.Settings.Date1904) is double num2))
				{
					continue;
				}
				if (Math.Abs(double_0 - num2) >= double.Epsilon)
				{
					if (num2 < double_0)
					{
						num = i;
					}
					continue;
				}
				if (i == length - 1)
				{
					return (double)i;
				}
				num = i;
				while (true)
				{
					i++;
					if (i != length)
					{
						object value2 = array.GetValue(i);
						if (value2 != null || num < length / 2)
						{
							if (Class1660.smethod_26(value2, class1277_0.workbook_0.Settings.Date1904) is double num3)
							{
								if (!(Math.Abs(double_0 - num3) < double.Epsilon))
								{
									return (double)num;
								}
								num = i;
							}
							else if (num >= length / 2)
							{
								break;
							}
							continue;
						}
						return (double)num;
					}
					return (double)num;
				}
				return (double)num;
			}
			if (num != -1)
			{
				return (double)num;
			}
		}
		else
		{
			Array array2 = (Array)array_0.GetValue(0);
			for (int j = 0; j < array2.Length; j++)
			{
				object value3 = array2.GetValue(j);
				if (value3 != null)
				{
					value3 = Class1660.smethod_26(value3, class1277_0.workbook_0.Settings.Date1904);
					if (value3 is double && !(Math.Abs(double_0 - (double)value3) >= double.Epsilon))
					{
						return (double)j;
					}
				}
			}
		}
		return ErrorType.NA;
	}
}
