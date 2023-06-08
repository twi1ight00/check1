using System;
using Aspose.Cells;
using ns12;
using ns2;
using ns22;
using ns29;

namespace ns51;

internal class Class1126
{
	internal static object Calculate(Class1277 class1277_0, Class1661 class1661_0, Cell cell_0)
	{
		if (class1661_0.method_7() != null && (class1661_0.method_7().Count == 4 || class1661_0.method_7().Count == 3))
		{
			object obj = class1277_0.method_5((Class1661)class1661_0.method_7()[0], cell_0);
			if (obj == null)
			{
				obj = 0.0;
			}
			else if (obj is ErrorType)
			{
				return obj;
			}
			int num = -1;
			object obj2 = Class1660.smethod_26(class1277_0.method_5((Class1661)class1661_0.method_7()[2], cell_0), class1277_0.workbook_0.Settings.Date1904);
			if (obj2 is ErrorType)
			{
				return obj2;
			}
			if (obj2 is double)
			{
				num = (int)Class1179.ToDouble(obj2) - 1;
				if (num < 0)
				{
					return ErrorType.Value;
				}
				bool flag = true;
				if (class1661_0.method_7().Count == 4)
				{
					object obj3 = class1277_0.method_5((Class1661)class1661_0.method_7()[3], cell_0);
					if (obj3 == null)
					{
						Class1661 @class = (Class1661)class1661_0.method_7()[3];
						flag = ((@class.method_9() != null && @class.method_9()[0] == 22) ? true : false);
					}
					else
					{
						if (obj3 is ErrorType)
						{
							return obj3;
						}
						switch (Type.GetTypeCode(obj3.GetType()))
						{
						case TypeCode.Double:
							if ((double)obj3 == 0.0)
							{
								flag = false;
							}
							break;
						case TypeCode.DateTime:
						{
							double doubleFromDateTime = CellsHelper.GetDoubleFromDateTime((DateTime)obj3, class1277_0.workbook_0.Settings.Date1904);
							if (doubleFromDateTime == 0.0)
							{
								flag = false;
							}
							break;
						}
						case TypeCode.String:
							return ErrorType.Value;
						case TypeCode.Boolean:
							flag = (bool)obj3;
							break;
						}
					}
				}
				_ = (Class1661)class1661_0.method_7()[1];
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				Worksheet worksheet = null;
				object obj4 = class1277_0.method_5((Class1661)class1661_0.method_7()[1], cell_0);
				if (obj4 != null && obj4 is ErrorType)
				{
					return obj4;
				}
				if (obj4 is object[][])
				{
					object[][] array = (object[][])obj4;
					int num5 = 0;
					object obj5 = smethod_0(class1277_0, obj, array, flag);
					if (obj5 is double)
					{
						num5 = (int)Class1179.ToDouble(obj5);
						if (num >= array[num5].Length)
						{
							return ErrorType.Ref;
						}
						return array[num5][num];
					}
					return obj5;
				}
				if (obj4 is Struct87 @struct)
				{
					worksheet = class1277_0.workbook_0.Worksheets[@struct.int_1];
					num2 = @struct.cellArea_0.StartRow;
					num4 = @struct.cellArea_0.StartColumn;
					num3 = @struct.cellArea_0.EndRow;
					int num6 = class1277_0.method_1(@struct.int_1);
					if (num6 == -1)
					{
						num2 = num3;
					}
					else if (num3 > num6)
					{
						if (num2 == 0 && num3 == 1048575 && flag)
						{
							double num7 = Math.Pow(2.0, Math.Ceiling(Math.Log(num6, 2.0)));
							num6 = (int)num7 - 1;
						}
						num3 = num6;
						if (num2 > num3)
						{
							num3 = num2;
						}
					}
					Class1375 class2 = class1277_0.method_4(worksheet.Index, num2, num4, num3, num4, bool_3: true, bool_4: true, bool_5: false);
					if (class2.object_0 != null && class2.object_0 is object[][])
					{
						object[][] object_ = (object[][])class2.object_0;
						object obj6 = smethod_0(class1277_0, obj, object_, flag);
						if (obj6 is double)
						{
							Cell cell = worksheet.Cells.CheckCell((int)Class1179.ToDouble(obj6) + num2, num4 + num);
							if (cell == null)
							{
								return null;
							}
							return class1277_0.method_211(cell);
						}
						return obj6;
					}
					return ErrorType.NA;
				}
				return ErrorType.Ref;
			}
			return ErrorType.Value;
		}
		throw new CellsException(ExceptionType.Formula, "Invalid formula in " + cell_0.method_4().method_3().Name + ":" + cell_0.Name);
	}

	private static object smethod_0(Class1277 class1277_0, object object_0, object[][] object_1, bool bool_0)
	{
		if (object_0 == null)
		{
			object_0 = 0.0;
		}
		if (object_0 is ErrorType)
		{
			return object_0;
		}
		object obj = ErrorType.Value;
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			return smethod_3(class1277_0, (double)object_0, object_1, bool_0);
		case TypeCode.DateTime:
			return smethod_3(class1277_0, CellsHelper.GetDoubleFromDateTime((DateTime)object_0, class1277_0.workbook_0.Settings.Date1904), object_1, bool_0);
		default:
			if (bool_0)
			{
				return smethod_2(class1277_0, object_0.ToString(), 0, object_1.Length - 1, object_1);
			}
			return smethod_1(class1277_0, object_0.ToString(), object_1);
		case TypeCode.String:
			if (bool_0)
			{
				return smethod_2(class1277_0, (string)object_0, 0, object_1.Length - 1, object_1);
			}
			return smethod_1(class1277_0, (string)object_0, object_1);
		}
	}

	private static object smethod_1(Class1277 class1277_0, string string_0, object[][] object_0)
	{
		Cell cell = null;
		bool flag = string_0.IndexOfAny(new char[2] { '?', '*' }) != -1;
		int num = 0;
		while (true)
		{
			if (num < object_0.Length)
			{
				if (object_0[num] != null)
				{
					object obj = object_0[num][0];
					if (obj != null && obj is Cell)
					{
						cell = (Cell)obj;
						obj = class1277_0.method_211(cell);
						object_0[num][0] = obj;
					}
					if (obj != null)
					{
						string text = obj.ToString();
						if (flag)
						{
							if (Class1679.smethod_4(string_0, text, bool_0: true) == 0)
							{
								return (double)num;
							}
						}
						else if (string.Compare(string_0, text, ignoreCase: true) == 0)
						{
							break;
						}
					}
				}
				num++;
				continue;
			}
			return ErrorType.NA;
		}
		return (double)num;
	}

	private static object smethod_2(Class1277 class1277_0, string string_0, int int_0, int int_1, object[][] object_0)
	{
		int num = -1;
		Cell cell = null;
		string text = string_0;
		text = text.ToUpper();
		int num2 = -1;
		while (true)
		{
			if (int_0 <= int_1)
			{
				num2 = (int_0 + int_1) / 2;
				object obj = null;
				if (object_0[num2] != null && object_0[num2][0] != null)
				{
					obj = object_0[num2][0];
					if (obj is Cell)
					{
						cell = (Cell)obj;
						obj = class1277_0.method_211(cell);
						object_0[num2][0] = obj;
					}
				}
				if (obj != null)
				{
					int num3 = 0;
					if (obj is double)
					{
						num3 = 1;
					}
					else
					{
						string strB = obj.ToString().ToUpper();
						num3 = text.CompareTo(strB);
					}
					if (num3 == 0)
					{
						break;
					}
					if (num3 > 0)
					{
						num = num2;
						int_0 = num2 + 1;
					}
					else
					{
						int_1 = num2 - 1;
					}
					continue;
				}
				object obj2 = smethod_2(class1277_0, string_0, num2 + 1, int_1, object_0);
				if (obj2 is ErrorType)
				{
					return smethod_2(class1277_0, string_0, int_0, num2 - 1, object_0);
				}
				return obj2;
			}
			if (num != -1)
			{
				return (double)num;
			}
			return ErrorType.NA;
		}
		num = num2;
		num2++;
		while (true)
		{
			if (num2 <= int_1)
			{
				object obj = null;
				if (object_0[num2] != null && object_0[num2][0] != null)
				{
					obj = object_0[num2][0];
					if (obj is Cell)
					{
						cell = (Cell)obj;
						obj = class1277_0.method_211(cell);
						object_0[num2][0] = obj;
					}
				}
				if (obj != null)
				{
					string text2 = obj.ToString().ToUpper();
					if (!(text2 == text))
					{
						break;
					}
					num = num2;
				}
				num2++;
				continue;
			}
			return (double)num;
		}
		return (double)num;
	}

	private static object smethod_3(Class1277 class1277_0, double double_0, object[][] object_0, bool bool_0)
	{
		int num = -1;
		int i = 0;
		while (true)
		{
			if (i < object_0.Length)
			{
				if (object_0[i] != null)
				{
					object obj = object_0[i][0];
					if (obj != null && obj is Cell)
					{
						obj = class1277_0.method_211((Cell)obj);
						object_0[i][0] = obj;
					}
					if (obj != null && obj is double num2)
					{
						if (Math.Abs(double_0 - num2) < double.Epsilon)
						{
							if (!bool_0)
							{
								break;
							}
							num = i;
							for (i++; i < object_0.Length; i++)
							{
								if (object_0[i] == null)
								{
									continue;
								}
								obj = object_0[i][0];
								if (obj != null && obj is Cell)
								{
									obj = class1277_0.method_211((Cell)obj);
									object_0[i][0] = obj;
								}
								if (obj != null && obj is double num3)
								{
									if (!(Math.Abs(double_0 - num3) < double.Epsilon))
									{
										return (double)num;
									}
									num = i;
								}
							}
						}
						else if (bool_0 && double_0 > num2)
						{
							num = i;
						}
					}
				}
				i++;
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
		return (double)i;
	}
}
