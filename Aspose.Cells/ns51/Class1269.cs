using System;
using System.Collections;
using Aspose.Cells;
using ns12;
using ns2;

namespace ns51;

internal class Class1269
{
	internal static object smethod_0(Class1277 class1277_0, WorksheetCollection worksheetCollection_0, Cell cell_0, object object_0, int int_0, int int_1)
	{
		if (object_0 is object[][])
		{
			object[][] array = (object[][])object_0;
			object obj = null;
			if (array[int_0] != null)
			{
				obj = array[int_0][int_1];
			}
			if (obj != null && obj is Cell)
			{
				obj = class1277_0.method_211((Cell)obj);
				array[int_0][int_1] = obj;
			}
			return obj;
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
			return class1277_0.method_211(cell);
		}
		return object_0;
	}

	internal static object smethod_1(Class1277 class1277_0, WorksheetCollection worksheetCollection_0, Cell cell_0, int int_0, int int_1, object[] object_0, string[] string_0, object[] object_1)
	{
		int num = 0;
		while (true)
		{
			if (num < object_0.Length)
			{
				object object_2 = smethod_0(class1277_0, worksheetCollection_0, cell_0, object_0[num], int_0, int_1);
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

	internal static object smethod_2(Class1277 class1277_0, WorksheetCollection worksheetCollection_0, Cell cell_0, int int_0, int int_1, object[] object_0, string[] string_0, object[] object_1, bool[] bool_0)
	{
		int num = 0;
		while (true)
		{
			if (num < object_0.Length)
			{
				if (!bool_0[num])
				{
					object object_2 = smethod_0(class1277_0, worksheetCollection_0, cell_0, object_0[num], int_0, int_1);
					object obj = Class1662.smethod_3(object_2, object_1[num], string_0[num], worksheetCollection_0.Workbook.Settings.Date1904);
					if (obj is ErrorType)
					{
						return obj;
					}
					if (obj is bool && !(bool)obj)
					{
						break;
					}
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	internal static int[] smethod_3(object object_0)
	{
		int[] array = new int[2] { 1, 1 };
		if (object_0 is object[][])
		{
			object[][] array2 = (object[][])object_0;
			array[0] = array2.Length;
			array[1] = array2[0].Length;
		}
		else if (object_0 is Struct87 @struct)
		{
			array[0] = @struct.cellArea_0.EndRow - @struct.cellArea_0.StartRow + 1;
			array[1] = @struct.cellArea_0.EndColumn - @struct.cellArea_0.StartColumn + 1;
		}
		return array;
	}

	internal static int[] smethod_4(object object_0, object[] object_1)
	{
		int[] array = smethod_3(object_0);
		int num = 0;
		while (true)
		{
			if (num < object_1.Length)
			{
				int[] array2 = smethod_3(object_1[num]);
				if (array[0] == array2[0])
				{
					if (array[1] != array2[1])
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return array;
		}
		return null;
	}

	internal static int[] smethod_5(object object_0, object[] object_1)
	{
		int[] array = smethod_3(object_0);
		for (int i = 0; i < object_1.Length; i++)
		{
			int[] array2 = smethod_3(object_1[i]);
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

	internal static Struct87 smethod_6(Struct87 struct87_0, object[] object_0)
	{
		int[] array = smethod_3(struct87_0);
		if (array[0] == 1 && array[1] == 1)
		{
			for (int i = 0; i < object_0.Length; i++)
			{
				int[] array2 = smethod_3(object_0[i]);
				if (i == 0)
				{
					array = array2;
					continue;
				}
				if (array[0] > array2[0])
				{
					array[0] = array2[0];
				}
				if (array[1] > array2[1])
				{
					array[1] = array2[1];
				}
			}
			if (array[0] != 1 || array[1] != 1)
			{
				struct87_0.cellArea_0.EndRow = struct87_0.cellArea_0.EndRow + array[0] - 1;
			}
		}
		return struct87_0;
	}

	internal static object Filter(Class1277 class1277_0, WorksheetCollection worksheetCollection_0, Cell cell_0, Class1375 class1375_0, string string_0, object object_0, int int_0, int int_1)
	{
		string key = string_0 + ((object_0 == null) ? "" : object_0);
		if (class1375_0.hashtable_0 == null)
		{
			class1375_0.hashtable_0 = new Hashtable();
		}
		object obj = class1375_0.hashtable_0[key];
		if (obj == null)
		{
			class1375_0.hashtable_0.Add(key, 0.0);
			return null;
		}
		if (!(obj is double))
		{
			return obj;
		}
		object object_ = class1375_0.object_0;
		int[][] array = new int[int_0][];
		int num = 0;
		int num2 = 0;
		int[] array2 = new int[int_1];
		for (int i = 0; i < int_0; i++)
		{
			num2 = 0;
			for (int j = 0; j < int_1; j++)
			{
				object object_2 = smethod_0(class1277_0, worksheetCollection_0, cell_0, object_, i, j);
				object obj2 = Class1662.smethod_3(object_2, object_0, string_0, worksheetCollection_0.Workbook.Settings.Date1904);
				if (obj2 is bool && (bool)obj2)
				{
					array2[num2++] = j;
				}
			}
			if (num2 != 0)
			{
				int[] array3 = new int[num2 + 1];
				Array.Copy(array2, 0, array3, 1, num2);
				array3[0] = i;
				array[num++] = array3;
			}
		}
		if (num < array.Length)
		{
			int[][] array4 = new int[num][];
			for (int k = 0; k < num; k++)
			{
				array4[k] = array[k];
			}
			array = array4;
		}
		class1375_0.hashtable_0[key] = array;
		return array;
	}

	internal static object Calculate(Class1277 class1277_0, WorksheetCollection worksheetCollection_0, Cell cell_0, object object_0, object[] object_1, string[] string_0, object[] object_2, int int_0, bool bool_0)
	{
		if (object_0 != null && object_0 is Struct87 struct87_)
		{
			Struct87 struct87_2 = smethod_6(struct87_, object_1);
			object_0 = class1277_0.method_3(struct87_2, bool_3: true, bool_4: true, bool_5: true, bool_6: false).object_0;
		}
		Class1375[] array = new Class1375[string_0.Length];
		for (int i = 0; i < object_1.Length; i++)
		{
			object obj = object_1[i];
			if (obj != null && obj is Struct87 struct87_3)
			{
				array[i] = class1277_0.method_3(struct87_3, bool_3: true, bool_4: true, bool_5: true, bool_6: false);
				object_1[i] = array[i].object_0;
			}
		}
		int num = 0;
		double num2 = 0.0;
		object obj2 = null;
		object obj3 = null;
		int[] array2 = null;
		if (bool_0)
		{
			array2 = smethod_4(object_0, object_1);
			if (array2 == null)
			{
				return ErrorType.Value;
			}
		}
		else
		{
			array2 = smethod_5(object_0, object_1);
		}
		int[][] array3 = null;
		bool[] array4 = new bool[string_0.Length];
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j] == null)
			{
				continue;
			}
			object obj4 = Filter(class1277_0, worksheetCollection_0, cell_0, array[j], string_0[j], object_2[j], array2[0], array2[1]);
			if (obj4 != null && obj4 is int[][])
			{
				array4[j] = true;
				if (array3 == null)
				{
					array3 = (int[][])obj4;
					break;
				}
			}
		}
		if (array3 != null)
		{
			for (int k = 0; k < array3.Length; k++)
			{
				for (int l = 1; l < array3[k].Length; l++)
				{
					obj2 = smethod_2(class1277_0, worksheetCollection_0, cell_0, array3[k][0], array3[k][l], object_1, string_0, object_2, array4);
					if (!(obj2 is bool) || !(bool)obj2)
					{
						continue;
					}
					if (int_0 == 2)
					{
						num++;
						continue;
					}
					obj3 = smethod_0(class1277_0, worksheetCollection_0, cell_0, object_0, array3[k][0], array3[k][l]);
					if (obj3 == null || !(obj3 is ErrorType))
					{
						if (obj3 != null)
						{
							obj3 = Class1660.smethod_26(obj3, worksheetCollection_0.Workbook.Settings.Date1904);
							if (obj3 is double)
							{
								num++;
								num2 += (double)obj3;
							}
						}
						continue;
					}
					return obj3;
				}
			}
		}
		else
		{
			for (int m = 0; m < array2[0]; m++)
			{
				for (int n = 0; n < array2[1]; n++)
				{
					obj2 = smethod_1(class1277_0, worksheetCollection_0, cell_0, m, n, object_1, string_0, object_2);
					if (!(obj2 is bool) || !(bool)obj2)
					{
						continue;
					}
					if (int_0 == 2)
					{
						num++;
						continue;
					}
					obj3 = smethod_0(class1277_0, worksheetCollection_0, cell_0, object_0, m, n);
					if (obj3 == null || !(obj3 is ErrorType))
					{
						if (obj3 != null)
						{
							obj3 = Class1660.smethod_26(obj3, worksheetCollection_0.Workbook.Settings.Date1904);
							if (obj3 is double)
							{
								num++;
								num2 += (double)obj3;
							}
						}
						continue;
					}
					return obj3;
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

	internal static object smethod_7(Class1277 class1277_0, WorksheetCollection worksheetCollection_0, Cell cell_0, object object_0, object[] object_1, string[][] string_0, object[][] object_2, int int_0)
	{
		int[] array = smethod_5(object_0, object_1);
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
						obj = smethod_1(class1277_0, worksheetCollection_0, cell_0, k, l, object_1, string_, object_3);
						if (!(obj is bool) || !(bool)obj)
						{
							continue;
						}
						if (int_0 != 2)
						{
							obj2 = smethod_0(class1277_0, worksheetCollection_0, cell_0, object_0, k, l);
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
}
