using System;
using System.Collections;
using Aspose.Cells;

namespace ns45;

internal class Class1145
{
	internal bool bool_0;

	internal bool bool_1;

	private ArrayList arrayList_0;

	private ArrayList arrayList_1;

	private ArrayList arrayList_2;

	private ArrayList arrayList_3;

	private ArrayList arrayList_4;

	private int int_0;

	private ArrayList arrayList_5;

	internal Class1145(bool bool_2, bool bool_3)
	{
		arrayList_1 = new ArrayList();
		bool_0 = bool_2;
		bool_1 = bool_3;
		if (!bool_2)
		{
			arrayList_0 = new ArrayList();
		}
	}

	internal void Add(object object_0, int int_1)
	{
		int_0++;
		if (object_0 == null)
		{
			if (bool_0)
			{
				if (arrayList_4 == null)
				{
					arrayList_4 = new ArrayList();
				}
				arrayList_4.Add(int_1);
				return;
			}
			object_0 = 0.0;
		}
		switch (Type.GetTypeCode(object_0.GetType()))
		{
		case TypeCode.Double:
			Add((double)object_0, int_1);
			break;
		case TypeCode.DateTime:
		{
			DateTime dateTime = (DateTime)object_0;
			Add(CellsHelper.GetDoubleFromDateTime(dateTime, date1904: false), int_1);
			break;
		}
		case TypeCode.String:
			Add((string)object_0, int_1);
			break;
		case TypeCode.Int32:
			Add((int)object_0, int_1);
			break;
		case TypeCode.Boolean:
			Add((bool)object_0, int_1);
			break;
		}
	}

	private void Add(double double_0, int int_1)
	{
		Struct82 @struct = default(Struct82);
		@struct.double_0 = double_0;
		@struct.int_0 = int_1;
		bool flag = false;
		for (int i = 0; i < arrayList_1.Count; i++)
		{
			if (!(double_0 >= ((Struct82)arrayList_1[i]).double_0))
			{
				arrayList_1.Insert(i, @struct);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			arrayList_1.Add(@struct);
		}
	}

	private void Add(string string_0, int int_1)
	{
		if (arrayList_0 == null)
		{
			arrayList_0 = new ArrayList();
		}
		Struct83 @struct = default(Struct83);
		@struct.string_0 = string_0;
		@struct.int_0 = int_1;
		bool flag = false;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			if (string.Compare(string_0, ((Struct83)arrayList_0[i]).string_0) == -1)
			{
				arrayList_0.Insert(i, @struct);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			arrayList_0.Add(@struct);
		}
	}

	private void Add(bool bool_2, int int_1)
	{
		if (bool_2)
		{
			if (arrayList_2 == null)
			{
				arrayList_2 = new ArrayList();
			}
			arrayList_2.Add(int_1);
		}
		else
		{
			if (arrayList_3 == null)
			{
				arrayList_3 = new ArrayList();
			}
			arrayList_3.Add(int_1);
		}
	}

	internal int[] method_0()
	{
		int[] array = new int[int_0];
		int num = 0;
		if (bool_1)
		{
			if (arrayList_1 != null)
			{
				for (int i = 0; i < arrayList_1.Count; i++)
				{
					Struct82 @struct = (Struct82)arrayList_1[i];
					array[num++] = @struct.int_0;
				}
			}
			if (arrayList_0 != null)
			{
				for (int j = 0; j < arrayList_0.Count; j++)
				{
					Struct83 struct2 = (Struct83)arrayList_0[j];
					array[num++] = struct2.int_0;
				}
			}
			if (arrayList_3 != null)
			{
				for (int k = 0; k < arrayList_3.Count; k++)
				{
					array[num++] = (int)arrayList_3[k];
				}
			}
			if (arrayList_2 != null)
			{
				for (int l = 0; l < arrayList_2.Count; l++)
				{
					array[num++] = (int)arrayList_2[l];
				}
			}
			if (arrayList_5 != null)
			{
				for (int m = 0; m < arrayList_5.Count; m++)
				{
					Struct84 struct3 = (Struct84)arrayList_5[m];
					array[num++] = struct3.int_0;
				}
			}
			if (arrayList_4 != null)
			{
				for (int n = 0; n < arrayList_4.Count; n++)
				{
					array[num++] = (int)arrayList_4[n];
				}
			}
		}
		else
		{
			if (arrayList_4 != null)
			{
				for (int num2 = 0; num2 < arrayList_4.Count; num2++)
				{
					array[num++] = (int)arrayList_4[num2];
				}
			}
			if (arrayList_5 != null)
			{
				for (int num3 = arrayList_5.Count - 1; num3 >= 0; num3--)
				{
					Struct84 struct4 = (Struct84)arrayList_5[num3];
					array[num++] = struct4.int_0;
				}
			}
			if (arrayList_2 != null)
			{
				for (int num4 = 0; num4 < arrayList_2.Count; num4++)
				{
					array[num++] = (int)arrayList_2[num4];
				}
			}
			if (arrayList_3 != null)
			{
				for (int num5 = 0; num5 < arrayList_3.Count; num5++)
				{
					array[num++] = (int)arrayList_3[num5];
				}
			}
			if (arrayList_0 != null)
			{
				for (int num6 = arrayList_0.Count - 1; num6 >= 0; num6--)
				{
					Struct83 struct5 = (Struct83)arrayList_0[num6];
					array[num++] = struct5.int_0;
				}
			}
			if (arrayList_1 != null)
			{
				for (int num7 = arrayList_1.Count - 1; num7 >= 0; num7--)
				{
					Struct82 struct6 = (Struct82)arrayList_1[num7];
					array[num++] = struct6.int_0;
				}
			}
		}
		return array;
	}
}
