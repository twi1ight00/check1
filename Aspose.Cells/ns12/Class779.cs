using System;

namespace ns12;

internal class Class779
{
	internal static object[][] smethod_0(object[][] object_0)
	{
		object[][] array = new object[object_0.Length][];
		for (int i = 0; i < object_0.Length; i++)
		{
			if (object_0[i] != null)
			{
				array[i] = new object[object_0[i].Length];
				for (int j = 0; j < object_0[i].Length; j++)
				{
					array[i][j] = object_0[i][j];
				}
			}
		}
		return array;
	}

	private static void smethod_1(ref Array array_0, ref Array array_1)
	{
		int int_ = ((array_0.Length > array_1.Length) ? ((array_1.Length != 1) ? array_1.Length : array_0.Length) : ((array_0.Length >= array_1.Length) ? array_0.Length : ((array_0.Length != 1) ? array_0.Length : array_1.Length)));
		Array array = (Array)array_0.GetValue(0);
		Array array2 = (Array)array_1.GetValue(0);
		int int_2 = ((array.Length > array2.Length) ? ((array2.Length != 1) ? array2.Length : array.Length) : ((array.Length >= array2.Length) ? array.Length : ((array.Length != 1) ? array.Length : array2.Length)));
		array_0 = smethod_2(array_0, int_, int_2);
		array_1 = smethod_2(array_1, int_, int_2);
	}

	private static Array smethod_2(Array array_0, int int_0, int int_1)
	{
		Array array;
		if (array_0.Length == int_0)
		{
			array = (Array)array_0.GetValue(0);
			if (array.Length == int_1)
			{
				return array_0;
			}
		}
		object[] array2 = new object[int_0];
		bool flag = false;
		array = (Array)array_0.GetValue(0);
		if (array.Length == 1)
		{
			flag = true;
		}
		if (array_0.Length == 1)
		{
			object[] array3 = new object[int_1];
			if (flag)
			{
				for (int i = 0; i < int_1; i++)
				{
					array3[i] = array.GetValue(0);
				}
			}
			else
			{
				array = (Array)array_0.GetValue(0);
				Array.Copy(array, array3, int_1);
			}
			for (int j = 0; j < int_0; j++)
			{
				array2[j] = array3;
			}
		}
		else
		{
			for (int k = 0; k < int_0; k++)
			{
				object[] array3 = new object[int_1];
				array = (Array)array_0.GetValue(k);
				if (flag)
				{
					for (int l = 0; l < int_1; l++)
					{
						array3[l] = array.GetValue(0);
					}
				}
				else
				{
					Array.Copy(array, array3, int_1);
				}
				array2[k] = array3;
			}
		}
		return array2;
	}

	internal static void smethod_3(ref object object_0, ref object object_1)
	{
		if (object_0 is object[][])
		{
			object_0 = smethod_0((object[][])object_0);
		}
		if (object_1 is object[][])
		{
			object_1 = smethod_0((object[][])object_1);
		}
		Array array = null;
		Array array2 = null;
		if (object_0 is Array)
		{
			array = (Array)object_0;
			if (object_1 is Array)
			{
				array2 = (Array)object_1;
				smethod_1(ref array, ref array2);
			}
			else
			{
				array2 = new object[array.Length];
				Array array3 = (Array)array.GetValue(0);
				Array array4 = new object[array3.Length];
				for (int i = 0; i < array4.Length; i++)
				{
					array4.SetValue(object_1, i);
				}
				for (int j = 0; j < array2.Length; j++)
				{
					array2.SetValue(array4, j);
				}
				smethod_1(ref array, ref array2);
			}
		}
		else
		{
			array2 = (Array)object_1;
			array = new object[array2.Length];
			Array array4 = (Array)array2.GetValue(0);
			for (int k = 0; k < array.Length; k++)
			{
				Array array3 = new object[array4.Length];
				for (int l = 0; l < array3.Length; l++)
				{
					array3.SetValue(object_0, l);
				}
				array.SetValue(array3, k);
			}
			smethod_1(ref array, ref array2);
		}
		object_0 = array;
		object_1 = array2;
	}
}
