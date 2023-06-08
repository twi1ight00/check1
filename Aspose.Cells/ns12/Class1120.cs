using System;
using System.Collections;
using Aspose.Cells;

namespace ns12;

internal class Class1120
{
	internal static bool Equals(byte[] byte_0, byte[] byte_1)
	{
		if (byte_0.Length != byte_1.Length)
		{
			return false;
		}
		int num = 0;
		while (true)
		{
			if (num < byte_0.Length)
			{
				if (byte_0[num] != byte_1[num])
				{
					break;
				}
				num++;
				continue;
			}
			return true;
		}
		return false;
	}

	internal static object[] smethod_0(object[] object_0)
	{
		int num = 1;
		int num2 = 1;
		bool flag = true;
		for (int i = 0; i < object_0.Length; i++)
		{
			if (object_0[i] == null)
			{
				continue;
			}
			if (object_0[i] is object[][])
			{
				object[][] array = (object[][])object_0[i];
				if (array.Length > num)
				{
					num = array.Length;
					if (i != 0)
					{
						flag = false;
					}
				}
				if (array[0].Length > num2)
				{
					num2 = array[0].Length;
					if (i != 0)
					{
						flag = false;
					}
				}
			}
			else
			{
				flag = false;
			}
		}
		if (flag)
		{
			return object_0;
		}
		object[] array2 = new object[object_0.Length];
		for (int j = 0; j < object_0.Length; j++)
		{
			if (object_0[j] == null)
			{
				continue;
			}
			object[][] array3 = new object[num][];
			if (object_0[j] is object[][])
			{
				object[][] array4 = (object[][])object_0[j];
				int num3 = array4.Length;
				int num4 = array4[0].Length;
				if (num3 == 1)
				{
					if (num4 == 1)
					{
						for (int k = 0; k < num; k++)
						{
							array3[k] = new object[num2];
							for (int l = 0; l < num2; l++)
							{
								array3[k][l] = array4[0][0];
							}
						}
					}
					else
					{
						for (int m = 0; m < num; m++)
						{
							array3[m] = new object[num2];
							for (int n = 0; n < num4; n++)
							{
								array3[m][n] = array4[0][n];
							}
							if (num4 < num2)
							{
								for (int num5 = num4; num5 < num2; num5++)
								{
									array3[m][num5] = ErrorType.NA;
								}
							}
						}
					}
				}
				else if (num4 == 1)
				{
					for (int num6 = 0; num6 < num; num6++)
					{
						array3[num6] = new object[num2];
						if (num6 < num3)
						{
							if (array4[num6] != null)
							{
								for (int num7 = 0; num7 < num2; num7++)
								{
									array3[num6][num7] = array4[num6][0];
								}
							}
						}
						else
						{
							for (int num8 = 0; num8 < num2; num8++)
							{
								array3[num6][num8] = ErrorType.NA;
							}
						}
					}
				}
				else if (num3 == num && num4 == num2)
				{
					array3 = array4;
				}
				else
				{
					for (int num9 = 0; num9 < num; num9++)
					{
						array3[num9] = new object[num2];
						if (num9 < num3)
						{
							if (array4[num9] != null)
							{
								for (int num10 = 0; num10 < array4[num9].Length; num10++)
								{
									array3[num9][num10] = array4[num9][num10];
								}
							}
							if (num4 < num2)
							{
								for (int num11 = num4; num11 < num2; num11++)
								{
									array3[num9][num11] = ErrorType.NA;
								}
							}
						}
						else
						{
							for (int num12 = 0; num12 < num2; num12++)
							{
								array3[num9][num12] = ErrorType.NA;
							}
						}
					}
				}
			}
			else
			{
				for (int num13 = 0; num13 < num; num13++)
				{
					array3[num13] = new object[num2];
					for (int num14 = 0; num14 < num2; num14++)
					{
						array3[num13][num14] = object_0[j];
					}
				}
			}
			array2[j] = array3;
		}
		return array2;
	}

	internal static object smethod_1(Workbook workbook_0, object object_0, object object_1, bool bool_0)
	{
		Class779.smethod_3(ref object_0, ref object_1);
		object[] array = (object[])object_0;
		object[] array2 = (object[])object_1;
		object[][] array3 = new object[array.Length][];
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			Array array4 = (Array)array[i];
			Array array5 = (Array)array2[i];
			if (i == 0)
			{
				num = array4.Length;
			}
			array3[i] = new object[num];
			for (int j = 0; j < num; j++)
			{
				array3[i][j] = Class1374.smethod_5(workbook_0, (array4 == null) ? ((object)0.0) : array4.GetValue(j), (array5 == null) ? ((object)0.0) : array5.GetValue(j), bool_0);
			}
		}
		return array3;
	}

	internal static object smethod_2(Workbook workbook_0, object object_0, object object_1)
	{
		Class779.smethod_3(ref object_0, ref object_1);
		object[] array = (object[])object_0;
		object[] array2 = (object[])object_1;
		object[][] array3 = new object[array.Length][];
		for (int i = 0; i < array.Length; i++)
		{
			Array array4 = (Array)array[i];
			Array array5 = (Array)array2[i];
			array3[i] = new object[array4.Length];
			for (int j = 0; j < array4.Length; j++)
			{
				array3[i][j] = Class1374.smethod_6(workbook_0, array4.GetValue(j), array5.GetValue(j));
			}
		}
		return array3;
	}

	internal static object smethod_3(Workbook workbook_0, object object_0, object object_1)
	{
		Class779.smethod_3(ref object_0, ref object_1);
		object[] array = (object[])object_0;
		object[] array2 = (object[])object_1;
		for (int i = 0; i < array.Length; i++)
		{
			Array array3 = (Array)array[i];
			Array array4 = (Array)array2[i];
			for (int j = 0; j < array3.Length; j++)
			{
				array3.SetValue(Class1374.smethod_7(workbook_0, array3.GetValue(j), array4.GetValue(j)), j);
			}
			array[i] = array3;
		}
		return array;
	}

	internal static object smethod_4(Workbook workbook_0, object object_0, object object_1)
	{
		Class779.smethod_3(ref object_0, ref object_1);
		object[] array = (object[])object_0;
		object[] array2 = (object[])object_1;
		object[][] array3 = new object[array.Length][];
		for (int i = 0; i < array.Length; i++)
		{
			Array array4 = (Array)array[i];
			Array array5 = (Array)array2[i];
			array3[i] = new object[array4.Length];
			for (int j = 0; j < array4.Length; j++)
			{
				array3[i][j] = Class1374.smethod_10(workbook_0, array4.GetValue(j), array5.GetValue(j));
			}
		}
		return array3;
	}

	internal static object smethod_5(Array array_0, Array array_1)
	{
		object[][] array = new object[array_0.Length][];
		for (int i = 0; i < array_0.Length; i++)
		{
			object value = array_0.GetValue(i);
			if (value == null)
			{
				array[i] = new object[1] { array_1.GetValue(i).ToString() };
			}
			else if (value is Array)
			{
				Array array2 = (Array)value;
				Array array3 = (Array)array_1.GetValue(i);
				array[i] = new object[array3.Length];
				for (int j = 0; j < array2.Length; j++)
				{
					object obj = array2.GetValue(0);
					if (obj == null)
					{
						obj = "";
					}
					object obj2 = array3.GetValue(0);
					if (obj2 == null)
					{
						obj2 = "";
					}
					array[i][j] = obj.ToString() + obj2.ToString();
				}
			}
			else
			{
				object value2 = array_1.GetValue(i);
				if (value2 == null)
				{
					array[i] = new object[1] { value.ToString() };
				}
				else
				{
					array[i] = new object[1] { value.ToString() + value2.ToString() };
				}
			}
		}
		return array;
	}

	internal static object smethod_6(Array array_0, object object_0)
	{
		object[][] array = new object[array_0.Length][];
		for (int i = 0; i < array_0.Length; i++)
		{
			object value = array_0.GetValue(i);
			if (value == null)
			{
				array[i] = new object[1] { object_0.ToString() };
			}
			else
			{
				if (!(value is Array))
				{
					continue;
				}
				Array array2 = (Array)value;
				array[i] = new object[array2.Length];
				for (int j = 0; j < array2.Length; j++)
				{
					object obj = array2.GetValue(0);
					if (obj == null)
					{
						obj = "";
					}
					object obj2 = object_0;
					if (obj2 == null)
					{
						obj2 = "";
					}
					array[i][j] = obj.ToString() + obj2.ToString();
				}
			}
		}
		return array;
	}

	internal static object smethod_7(Workbook workbook_0, object object_0, object object_1)
	{
		if (!(object_0 is object[][]) && !(object_1 is object[][]))
		{
			return Class1374.smethod_8(workbook_0, object_0, object_1);
		}
		if (object_0 is object[][])
		{
			if (object_1 is object[][])
			{
				object[][] array = (object[][])object_1;
				object[][] array2 = Class779.smethod_0((object[][])object_0);
				for (int i = 0; i < array2.Length; i++)
				{
					object[] array3 = array2[i];
					if (array3 != null)
					{
						object[] array4 = array[i];
						for (int j = 0; j < array3.Length; j++)
						{
							array3[j] = Class1374.smethod_8(workbook_0, array3[j], array4[j]);
						}
					}
				}
				return array2;
			}
			object obj = object_0;
			object_0 = object_1;
			object_1 = obj;
		}
		object[][] array5 = (object[][])object_1;
		foreach (object[] array6 in array5)
		{
			if (array6 == null)
			{
				continue;
			}
			for (int l = 0; l < array6.Length; l++)
			{
				object obj2 = array6[l];
				if (obj2 != null)
				{
					array6[l] = Class1374.smethod_8(workbook_0, object_0, obj2);
				}
			}
		}
		return array5;
	}

	internal static object smethod_8(Workbook workbook_0, object object_0)
	{
		Array array = (Array)object_0;
		object[][] array2 = new object[array.Length][];
		object value = array.GetValue(0);
		if (value is Array)
		{
			int length = ((Array)value).Length;
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = new object[length];
				value = array.GetValue(i);
				if (value == null)
				{
					for (int j = 0; j < length; j++)
					{
						array2[i][j] = true;
					}
					continue;
				}
				Array array3 = (Array)value;
				for (int k = 0; k < length; k++)
				{
					array2[i][k] = Class1374.smethod_9(workbook_0, array3.GetValue(k));
				}
			}
		}
		else
		{
			for (int l = 0; l < array.Length; l++)
			{
				array2[l] = new object[1];
				array2[l][0] = Class1374.smethod_9(workbook_0, array.GetValue(l));
			}
		}
		return array2;
	}

	internal static object smethod_9(object object_0)
	{
		Array array = (Array)object_0;
		object[][] array2 = new object[array.Length][];
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array.GetValue(i) == null)
			{
				continue;
			}
			Array array3 = (Array)array.GetValue(i);
			if (i == 0)
			{
				num = array3.Length;
			}
			array2[i] = new object[num];
			for (int j = 0; j < array3.Length; j++)
			{
				if (array3.GetValue(j) == null)
				{
					array2[i][j] = false;
					continue;
				}
				switch (Type.GetTypeCode(array3.GetValue(j).GetType()))
				{
				default:
					array2[i][j] = false;
					break;
				case TypeCode.Double:
				case TypeCode.DateTime:
					array2[i][j] = true;
					break;
				}
			}
		}
		return array2;
	}

	internal static object smethod_10(Workbook workbook_0, object object_0)
	{
		object[][] array = null;
		if (object_0 is double[][])
		{
			double[][] array2 = (double[][])object_0;
			int num = array2[0].Length;
			array = new object[array2.Length][];
			for (int i = 0; i < 0; i++)
			{
				if (array2[i] != null)
				{
					array[i] = new object[num];
					for (int j = 0; j < array2[i].Length; j++)
					{
						array[i][j] = Math.Abs(array2[i][j]);
					}
				}
			}
			return array;
		}
		Array array3 = (Array)object_0;
		array = new object[array3.Length][];
		for (int k = 0; k < array3.Length; k++)
		{
			object value = array3.GetValue(k);
			if (value == null)
			{
				continue;
			}
			Array array4 = (Array)value;
			array[k] = new object[array4.Length];
			for (int l = 0; l < array4.Length; l++)
			{
				object obj = Class1374.smethod_1(array4.GetValue(l), workbook_0.Settings.Date1904);
				if (!(obj is ErrorType))
				{
					array[k][l] = obj;
					continue;
				}
				return obj;
			}
		}
		return array;
	}

	internal static bool smethod_11(Array array_0, Array array_1)
	{
		if (array_0.Length != array_1.Length)
		{
			return false;
		}
		Array array = (Array)array_0.GetValue(0);
		Array array2 = (Array)array_1.GetValue(0);
		if (array.Length != array2.Length)
		{
			return false;
		}
		return true;
	}

	internal static object smethod_12(Workbook workbook_0, Array array_0, Array array_1, ArrayList arrayList_0, ArrayList arrayList_1)
	{
		int length = ((Array)array_0.GetValue(0)).Length;
		for (int i = 0; i < array_0.Length; i++)
		{
			Array array = (Array)array_0.GetValue(i);
			Array array2 = (Array)array_1.GetValue(i);
			for (int j = 0; j < length; j++)
			{
				object value = array.GetValue(j);
				object value2 = array2.GetValue(j);
				if (value == null || value2 == null)
				{
					continue;
				}
				if (!(value is ErrorType))
				{
					if (!(value2 is ErrorType))
					{
						switch (Type.GetTypeCode(value.GetType()))
						{
						case TypeCode.Double:
							switch (Type.GetTypeCode(value2.GetType()))
							{
							case TypeCode.Double:
								arrayList_0.Add(value);
								arrayList_1.Add(value2);
								break;
							case TypeCode.DateTime:
								arrayList_0.Add(value);
								arrayList_1.Add(CellsHelper.GetDoubleFromDateTime((DateTime)value2, workbook_0.Settings.Date1904));
								break;
							}
							break;
						case TypeCode.DateTime:
							switch (Type.GetTypeCode(value2.GetType()))
							{
							case TypeCode.Double:
								arrayList_0.Add(CellsHelper.GetDoubleFromDateTime((DateTime)value, workbook_0.Settings.Date1904));
								arrayList_1.Add(value2);
								break;
							case TypeCode.DateTime:
								arrayList_0.Add(CellsHelper.GetDoubleFromDateTime((DateTime)value, workbook_0.Settings.Date1904));
								arrayList_1.Add(CellsHelper.GetDoubleFromDateTime((DateTime)value2, workbook_0.Settings.Date1904));
								break;
							}
							break;
						}
						continue;
					}
					return value2;
				}
				return value;
			}
		}
		return null;
	}

	internal static int smethod_13(object object_0)
	{
		int num = 0;
		Array array = (Array)object_0;
		Array array2 = (Array)array.GetValue(0);
		int length = array2.Length;
		for (int i = 0; i < array.Length; i++)
		{
			array2 = (Array)array.GetValue(i);
			if (array2 == null)
			{
				num += length;
				continue;
			}
			for (int j = 0; j < array2.Length; j++)
			{
				object value = array2.GetValue(j);
				if (value == null)
				{
					num++;
				}
				else if (value is string && ((string)value).Length == 0)
				{
					num++;
				}
			}
		}
		return num;
	}

	internal static int smethod_14(object object_0)
	{
		int num = 0;
		Array array = (Array)object_0;
		for (int i = 0; i < array.Length; i++)
		{
			object value = array.GetValue(i);
			if (value is Array)
			{
				Array array2 = (Array)value;
				for (int j = 0; j < array2.Length; j++)
				{
					value = array2.GetValue(j);
					if (value is double)
					{
						num++;
					}
				}
			}
			else if (value is double)
			{
				num++;
			}
		}
		return num;
	}

	internal static object smethod_15(object object_0, bool bool_0)
	{
		object[][] array = null;
		if (object_0 is double[][])
		{
			double[][] array2 = (double[][])object_0;
			array = new object[array2.Length][];
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i] != null)
				{
					array[i] = new object[array2[i].Length];
					for (int j = 0; j < array2[i].Length; j++)
					{
						array[i][j] = Class1660.smethod_20(array2[i][j], bool_0);
					}
				}
			}
			return array;
		}
		if (object_0 is object[][])
		{
			object[][] array3 = (object[][])object_0;
			array = new object[array3.Length][];
			for (int k = 0; k < array3.Length; k++)
			{
				if (array3[k] != null)
				{
					array[k] = new object[array3[k].Length];
					for (int l = 0; l < array3[k].Length; l++)
					{
						array[k][l] = Class1660.smethod_20(array3[k][l], bool_0);
					}
				}
			}
			return array;
		}
		return ErrorType.Value;
	}

	internal static int smethod_16(object object_0)
	{
		int num = 0;
		if (object_0 is Array)
		{
			Array array = (Array)object_0;
			for (int i = 0; i < array.Length; i++)
			{
				object value = array.GetValue(i);
				if (value is Array)
				{
					Array array2 = (Array)value;
					for (int j = 0; j < array2.Length; j++)
					{
						value = array2.GetValue(j);
						if (value != null)
						{
							num++;
						}
					}
				}
				else if (value is double)
				{
					num++;
				}
			}
		}
		return num;
	}

	internal static object smethod_17(object[][] object_0, object object_1, Workbook workbook_0, int int_0)
	{
		object[][] array = new object[object_0.Length][];
		int num = object_0[0].Length;
		for (int i = 0; i < object_0.Length; i++)
		{
			array[i] = new object[num];
			for (int j = 0; j < num; j++)
			{
				switch (int_0)
				{
				case -1:
					array[i][j] = Class1374.smethod_11(object_0[i][j], object_1, workbook_0);
					break;
				case 0:
					array[i][j] = Class1374.smethod_12(object_0[i][j], object_1, workbook_0);
					break;
				case 1:
					array[i][j] = Class1374.smethod_13(object_0[i][j], object_1, workbook_0);
					break;
				}
			}
		}
		return array;
	}
}
