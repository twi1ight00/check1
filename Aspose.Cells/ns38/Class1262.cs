using System;
using Aspose.Cells;
using ns12;
using ns2;
using ns29;

namespace ns38;

internal class Class1262
{
	private Class1264 class1264_0;

	private Workbook workbook_0;

	internal Class1262(Class1264 class1264_1, Workbook workbook_1)
	{
		class1264_0 = class1264_1;
		workbook_0 = workbook_1;
	}

	internal object method_0(Class1661 class1661_0, Cell cell_0)
	{
		object obj = class1264_0.method_4((Class1661)class1661_0.method_7()[0], cell_0);
		if (obj == null)
		{
			obj = 0.0;
		}
		if (obj is ErrorType)
		{
			return obj;
		}
		int num = 1;
		if (class1661_0.method_7().Count == 3)
		{
			object obj2 = Class1660.smethod_26(class1264_0.method_4((Class1661)class1661_0.method_7()[2], cell_0), workbook_0.Settings.Date1904);
			if (!(obj2 is double))
			{
				return obj2;
			}
			num = (int)(double)obj2;
			if (num < 0)
			{
				num = -1;
			}
			else if (num > 0)
			{
				num = 1;
			}
		}
		_ = (Class1661)class1661_0.method_7()[1];
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		Worksheet worksheet = null;
		object obj3 = class1264_0.method_4((Class1661)class1661_0.method_7()[1], cell_0);
		object[][] array = null;
		if (obj3 is Struct87 @struct)
		{
			worksheet = workbook_0.Worksheets[@struct.int_1];
			num2 = @struct.cellArea_0.StartRow;
			num4 = @struct.cellArea_0.StartColumn;
			num3 = @struct.cellArea_0.EndRow;
			int maxRow = worksheet.Cells.MaxRow;
			if (maxRow == -1)
			{
				return ErrorType.NA;
			}
			num5 = @struct.cellArea_0.EndColumn;
			int index = worksheet.Index;
			array = (object[][])class1264_0.method_3(index, num2, num4, num3, num5, bool_3: true, bool_4: true).object_0;
		}
		else
		{
			if (!(obj3 is object[][]))
			{
				return ErrorType.NA;
			}
			array = (object[][])obj3;
			num2 = 0;
			num3 = array.Length - 1;
			num4 = 0;
			num5 = array[0].Length - 1;
		}
		return method_1(obj, array, num2, num3, num4, num5, num);
	}

	private object method_1(object object_0, object[][] object_1, int int_0, int int_1, int int_2, int int_3, int int_4)
	{
		bool bool_ = true;
		int int_5 = 0;
		int int_6 = 0;
		int int_7 = int_1 - int_0;
		if (int_0 == int_1 && !(bool_ = int_3 == int_2))
		{
			int_5 = 0;
			int_6 = 0;
			int_7 = int_3 - int_2;
		}
		object obj = ErrorType.Value;
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			obj = method_3((double)object_0, object_1, int_6, int_7, int_5, bool_, int_4);
			break;
		case TypeCode.DateTime:
			obj = method_3(CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbook_0.Settings.Date1904), object_1, int_6, int_7, int_5, bool_, int_4);
			break;
		default:
			if (object_0 is Array)
			{
				Array array = (Array)object_0;
				object[][] array2 = new object[array.Length][];
				for (int i = 0; i < array.Length; i++)
				{
					Array array3 = (Array)array.GetValue(i);
					if (array3 == null)
					{
						continue;
					}
					array2[i] = new object[array3.Length];
					for (int j = 0; j < array3.Length; j++)
					{
						object_0 = array3.GetValue(j);
						if (object_0 != null)
						{
							switch (Type.GetTypeCode(object_0.GetType()))
							{
							case TypeCode.Double:
								obj = method_3((double)object_0, object_1, int_6, int_7, int_5, bool_, int_4);
								break;
							case TypeCode.DateTime:
								obj = method_3(CellsHelper.GetDoubleFromDateTime((DateTime)object_0, workbook_0.Settings.Date1904), object_1, int_6, int_7, int_5, bool_, int_4);
								break;
							case TypeCode.String:
								obj = method_2((string)object_0, object_1, int_6, int_7, int_5, bool_, int_4);
								break;
							}
							if (!(obj is double))
							{
								return obj;
							}
							array2[i][j] = (double)obj + 1.0;
						}
					}
				}
				return array2;
			}
			obj = method_2(object_0.ToString(), object_1, int_6, int_7, int_5, bool_, int_4);
			break;
		case TypeCode.String:
			obj = method_2((string)object_0, object_1, int_6, int_7, int_5, bool_, int_4);
			break;
		}
		if (obj is double)
		{
			return (double)obj + 1.0;
		}
		return obj;
	}

	private object method_2(string string_0, object[][] object_0, int int_0, int int_1, int int_2, bool bool_0, int int_3)
	{
		int num = -1;
		string text = string_0;
		text = text.ToUpper();
		switch (int_3)
		{
		default:
			return ErrorType.NA;
		case -1:
		{
			int num6 = -1;
			while (true)
			{
				if (int_0 <= int_1)
				{
					num6 = (int_0 + int_1) / 2;
					object obj4 = null;
					if (bool_0)
					{
						if (object_0[num6] != null && object_0[num6][int_2] != null)
						{
							obj4 = object_0[num6][int_2];
							if (obj4 is Cell)
							{
								obj4 = class1264_0.method_207((Cell)obj4);
								object_0[num6][int_2] = obj4;
							}
						}
					}
					else if (object_0[int_2] != null && object_0[int_2][num6] != null)
					{
						obj4 = object_0[int_2][num6];
						if (obj4 is Cell)
						{
							obj4 = class1264_0.method_207((Cell)obj4);
							object_0[int_2][num6] = obj4;
						}
					}
					if (obj4 != null)
					{
						string strB2 = obj4.ToString().ToUpper();
						int num7 = text.CompareTo(strB2);
						if (num7 == 0)
						{
							break;
						}
						if (num7 < 0)
						{
							num = num6;
							int_0 = num6 + 1;
						}
						else
						{
							int_1 = num6 - 1;
						}
						continue;
					}
					object obj5 = method_2(text, object_0, num6 + 1, int_1, int_2, bool_0, int_3);
					if (obj5 is ErrorType)
					{
						obj5 = method_2(text, object_0, int_0, num6 - 1, int_2, bool_0, int_3);
					}
					return obj5;
				}
				if (num != -1)
				{
					return (double)num;
				}
				return ErrorType.NA;
			}
			num = num6;
			int num8 = num6 + 1;
			while (true)
			{
				if (num8 <= int_1)
				{
					object obj4 = null;
					if (bool_0)
					{
						if (object_0[num6] != null && object_0[num6][int_2] != null)
						{
							obj4 = object_0[num6][int_2];
							if (obj4 is Cell)
							{
								obj4 = class1264_0.method_207((Cell)obj4);
								object_0[num6][int_2] = obj4;
							}
						}
					}
					else if (object_0[int_2] != null && object_0[int_2][num6] != null)
					{
						obj4 = object_0[int_2][num6];
						if (obj4 is Cell)
						{
							obj4 = class1264_0.method_207((Cell)obj4);
							object_0[int_2][num6] = obj4;
						}
					}
					if (obj4 != null)
					{
						string strB2 = obj4.ToString().ToUpper();
						if (!(strB2 == text))
						{
							break;
						}
						num = num8;
					}
					num8++;
					continue;
				}
				return (double)num;
			}
			return (double)num;
		}
		case 0:
		{
			int num5 = int_0;
			while (true)
			{
				if (num5 <= int_1)
				{
					object obj3 = null;
					if (bool_0)
					{
						if (object_0[num5] != null && object_0[num5][int_2] != null)
						{
							obj3 = object_0[num5][int_2];
							if (obj3 is Cell)
							{
								obj3 = class1264_0.method_207((Cell)obj3);
								object_0[num5][int_2] = obj3;
							}
						}
					}
					else if (object_0[int_2] != null && object_0[int_2][num5] != null)
					{
						obj3 = object_0[int_2][num5];
						if (obj3 is Cell)
						{
							obj3 = class1264_0.method_207((Cell)obj3);
							object_0[int_2][num5] = obj3;
						}
					}
					if (obj3 != null)
					{
						string string_ = obj3.ToString();
						if (Class1679.smethod_4(string_0, string_, bool_0: true) == 0)
						{
							break;
						}
					}
					num5++;
					continue;
				}
				return ErrorType.NA;
			}
			return (double)num5;
		}
		case 1:
		{
			int num2 = -1;
			while (true)
			{
				if (int_0 <= int_1)
				{
					num2 = (int_0 + int_1) / 2;
					object obj = null;
					if (bool_0)
					{
						if (object_0[num2] != null && object_0[num2][int_2] != null)
						{
							obj = object_0[num2][int_2];
							if (obj is Cell)
							{
								obj = class1264_0.method_207((Cell)obj);
								object_0[num2][int_2] = obj;
							}
						}
					}
					else if (object_0[int_2] != null && object_0[int_2][num2] != null)
					{
						obj = object_0[int_2][num2];
						if (obj is Cell)
						{
							obj = class1264_0.method_207((Cell)obj);
							object_0[int_2][num2] = obj;
						}
					}
					if (obj != null)
					{
						string strB = obj.ToString().ToUpper();
						int num3 = text.CompareTo(strB);
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
					object obj2 = method_2(text, object_0, num2 + 1, int_1, int_2, bool_0, int_3);
					if (obj2 is ErrorType)
					{
						obj2 = method_2(text, object_0, int_0, num2 - 1, int_2, bool_0, int_3);
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
			int num4 = num2 + 1;
			while (true)
			{
				if (num4 <= int_1)
				{
					object obj = null;
					if (bool_0)
					{
						if (object_0[num4] != null && object_0[num4][int_2] != null)
						{
							obj = object_0[num4][int_2];
							if (obj is Cell)
							{
								obj = class1264_0.method_207((Cell)obj);
								object_0[num4][int_2] = obj;
							}
						}
					}
					else if (object_0[int_2] != null && object_0[int_2][num4] != null)
					{
						obj = object_0[int_2][num4];
						if (obj is Cell)
						{
							obj = class1264_0.method_207((Cell)obj);
							object_0[int_2][num4] = obj;
						}
					}
					if (obj != null)
					{
						string strB = obj.ToString().ToUpper();
						if (!(strB == text))
						{
							break;
						}
						num = num4;
					}
					num4++;
					continue;
				}
				return (double)num;
			}
			return (double)num;
		}
		}
	}

	private object method_3(double double_0, object[][] object_0, int int_0, int int_1, int int_2, bool bool_0, int int_3)
	{
		int num = -1;
		int num2 = int_0;
		while (true)
		{
			if (num2 <= int_1)
			{
				object obj = null;
				if (bool_0)
				{
					if (object_0[num2] != null && object_0[num2][int_2] != null)
					{
						obj = object_0[num2][int_2];
						if (obj is Cell)
						{
							obj = class1264_0.method_207((Cell)obj);
							object_0[num2][int_2] = obj;
						}
					}
				}
				else if (object_0[int_2] != null && object_0[int_2][num2] != null)
				{
					obj = object_0[int_2][num2];
					if (obj is Cell)
					{
						obj = class1264_0.method_207((Cell)obj);
						object_0[int_2][num2] = obj;
					}
				}
				if (obj != null && obj is double num3)
				{
					if (!(Math.Abs(double_0 - num3) >= double.Epsilon))
					{
						break;
					}
					switch (int_3)
					{
					case -1:
						if (double_0 <= num3)
						{
							num = num2;
							break;
						}
						if (num == -1)
						{
							return ErrorType.NA;
						}
						return (double)num;
					case 1:
						if (double_0 >= num3)
						{
							num = num2;
							break;
						}
						if (num == -1)
						{
							return ErrorType.NA;
						}
						return (double)num;
					}
				}
				num2++;
				continue;
			}
			if (int_3 != 0)
			{
				if (num != -1)
				{
					return (double)num;
				}
				return ErrorType.NA;
			}
			return ErrorType.NA;
		}
		if (int_3 != 1)
		{
			return (double)num2;
		}
		num = num2;
		num2++;
		while (true)
		{
			if (num2 <= int_1)
			{
				object obj = null;
				if (bool_0)
				{
					if (object_0[num2] != null && object_0[num2][int_2] != null)
					{
						obj = object_0[num2][int_2];
						if (obj is Cell)
						{
							obj = class1264_0.method_207((Cell)obj);
							object_0[num2][int_2] = obj;
						}
					}
				}
				else if (object_0[int_2] != null && object_0[int_2][num2] != null)
				{
					obj = object_0[int_2][num2];
					if (obj is Cell)
					{
						obj = class1264_0.method_207((Cell)obj);
						object_0[int_2][num2] = obj;
					}
				}
				if (obj != null && obj is double num4)
				{
					if (!(Math.Abs(double_0 - num4) < double.Epsilon))
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
}
