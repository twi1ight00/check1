using System;
using Aspose.Cells;
using ns12;
using ns2;

namespace ns38;

internal class Class1260
{
	internal static object smethod_0(Class1264 class1264_0, WorksheetCollection worksheetCollection_0, Cell cell_0, object object_0, int int_0, int int_1)
	{
		if (object_0 is Array)
		{
			Array array = (Array)object_0;
			object value = array.GetValue(int_0);
			if (value != null && value is Array)
			{
				Array array2 = (Array)value;
				value = array2.GetValue(int_1);
				if (value != null && value is Cell)
				{
					value = class1264_0.method_207((Cell)value);
					array2.SetValue(value, int_1);
				}
				return value;
			}
			return value;
		}
		if (object_0 is Struct87 @struct)
		{
			int row = @struct.cellArea_0.StartRow + int_0;
			int column = @struct.cellArea_0.StartColumn + int_1;
			Cells cells = worksheetCollection_0[@struct.int_1].Cells;
			Cell cell = cells.CheckCell(row, column);
			if (cell == null)
			{
				return null;
			}
			return class1264_0.method_207(cell);
		}
		return object_0;
	}

	internal static object smethod_1(Class1264 class1264_0, WorksheetCollection worksheetCollection_0, Cell cell_0, int int_0, int int_1, object[] object_0, string[] string_0, object[] object_1)
	{
		int num = 0;
		while (true)
		{
			if (num < object_0.Length)
			{
				object object_2 = smethod_0(class1264_0, worksheetCollection_0, cell_0, object_0[num], int_0, int_1);
				object obj = Class1662.smethod_3(object_2, object_1[num], string_0[num], worksheetCollection_0.Workbook.Settings.Date1904);
				if (!(obj is ErrorType))
				{
					if (obj is bool && !(bool)obj)
					{
						break;
					}
					num++;
					continue;
				}
				return obj;
			}
			return true;
		}
		return false;
	}

	internal static int[] smethod_2(object object_0)
	{
		int[] array = new int[2] { 1, 1 };
		if (object_0 is Array)
		{
			Array array2 = (Array)object_0;
			array[0] = array2.Length;
			object value = array2.GetValue(0);
			if (value is Array)
			{
				array[1] = ((Array)value).Length;
			}
			else
			{
				array[1] = 0;
			}
		}
		else if (object_0 is Struct87 @struct)
		{
			array[0] = @struct.cellArea_0.EndRow - @struct.cellArea_0.StartRow + 1;
			array[1] = @struct.cellArea_0.EndColumn - @struct.cellArea_0.StartColumn + 1;
		}
		return array;
	}

	internal static int[] smethod_3(object object_0, object[] object_1)
	{
		int[] array = smethod_2(object_0);
		for (int i = 0; i < object_1.Length; i++)
		{
			int[] array2 = smethod_2(object_1[i]);
			if (array[0] > array2[0])
			{
				array[0] = array2[0];
			}
			if (array[1] > array2[1])
			{
				array[1] = array2[1];
			}
		}
		return array;
	}

	internal static object smethod_4(Class1264 class1264_0, WorksheetCollection worksheetCollection_0, Cell cell_0, object object_0, object[] object_1, string[][] string_0, object[][] object_2, int int_0)
	{
		int[] array = smethod_3(object_0, object_1);
		object[][] array2 = new object[string_0.Length][];
		for (int i = 0; i < string_0.Length; i++)
		{
			array2[i] = new object[string_0[i].Length];
			for (int j = 0; j < string_0[i].Length; j++)
			{
				int num = 0;
				double num2 = 0.0;
				object obj = null;
				object obj2 = null;
				string[] string_ = new string[1] { string_0[i][j] };
				object[] object_3 = new object[1] { object_2[i][j] };
				for (int k = 0; k < array[0]; k++)
				{
					for (int l = 0; l < array[1]; l++)
					{
						obj = smethod_1(class1264_0, worksheetCollection_0, cell_0, k, l, object_1, string_, object_3);
						if (!(obj is bool) || !(bool)obj)
						{
							continue;
						}
						if (int_0 != 2)
						{
							obj2 = smethod_0(class1264_0, worksheetCollection_0, cell_0, object_0, k, l);
							if (obj2 != null && obj2 is ErrorType)
							{
								return obj2;
							}
							obj2 = Class1660.smethod_26(obj2, worksheetCollection_0.Workbook.Settings.Date1904);
							if (!(obj2 is double))
							{
								continue;
							}
						}
						num++;
						if (obj2 != null)
						{
							num2 += (double)obj2;
						}
					}
				}
				switch (int_0)
				{
				default:
					array2[i][j] = num2;
					break;
				case 1:
					if (num == 0)
					{
						array2[i][j] = ErrorType.Div;
					}
					else
					{
						array2[i][j] = num2 / (double)num;
					}
					break;
				case 2:
					array2[i][j] = (double)num;
					break;
				}
			}
		}
		return array2;
	}

	internal static object Calculate(Class1661 class1661_0, Class1264 class1264_0, WorksheetCollection worksheetCollection_0, Cell cell_0, object object_0, object[] object_1, string[] string_0, object[] object_2, int int_0)
	{
		if (object_0 != null && object_0 is Struct87 struct87_)
		{
			object_0 = class1264_0.method_2(struct87_, bool_3: true, bool_4: true, bool_5: true).object_0;
		}
		for (int i = 0; i < object_1.Length; i++)
		{
			object obj = object_1[i];
			if (obj != null && obj is Struct87 struct87_2)
			{
				object_1[i] = class1264_0.method_2(struct87_2, bool_3: true, bool_4: true, bool_5: true).object_0;
			}
		}
		int num = 0;
		double num2 = 0.0;
		object obj2 = null;
		object obj3 = null;
		int[] array = smethod_3(object_0, object_1);
		for (int j = 0; j < array[0]; j++)
		{
			for (int k = 0; k < array[1]; k++)
			{
				obj2 = smethod_1(class1264_0, worksheetCollection_0, cell_0, j, k, object_1, string_0, object_2);
				if (!(obj2 is bool) || !(bool)obj2)
				{
					continue;
				}
				if (int_0 != 2)
				{
					obj3 = smethod_0(class1264_0, worksheetCollection_0, cell_0, object_0, j, k);
					if (obj3 != null && obj3 is ErrorType)
					{
						return obj3;
					}
					if (obj3 == null)
					{
						continue;
					}
					obj3 = Class1660.smethod_26(obj3, worksheetCollection_0.Workbook.Settings.Date1904);
					if (!(obj3 is double))
					{
						continue;
					}
				}
				num++;
				if (obj3 != null)
				{
					num2 += (double)obj3;
				}
			}
		}
		switch (int_0)
		{
		default:
			return num2;
		case 1:
			if (num == 0)
			{
				return ErrorType.Div;
			}
			return num2 / (double)num;
		case 2:
			return (double)num;
		}
	}
}
