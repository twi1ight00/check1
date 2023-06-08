using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace ns14;

internal class Class510
{
	private Class509 class509_0;

	private ArrayList arrayList_0 = new ArrayList();

	private ArrayList arrayList_1 = new ArrayList();

	private ArrayList arrayList_2 = new ArrayList();

	private ArrayList arrayList_3 = new ArrayList();

	private ArrayList arrayList_4 = new ArrayList();

	private ArrayList arrayList_5 = new ArrayList();

	private ArrayList arrayList_6 = new ArrayList();

	private ArrayList arrayList_7 = new ArrayList();

	private ArrayList arrayList_8 = new ArrayList();

	private ArrayList arrayList_9 = new ArrayList();

	private int int_0;

	private int int_1;

	private int int_2;

	private StringBuilder stringBuilder_0;

	private StringBuilder stringBuilder_1;

	internal Class510(Class509 class509_1, StringBuilder stringBuilder_2, StringBuilder stringBuilder_3)
	{
		class509_0 = class509_1;
		stringBuilder_0 = stringBuilder_2;
		stringBuilder_1 = stringBuilder_3;
	}

	internal void method_0()
	{
		if (stringBuilder_0.Length < 1)
		{
			return;
		}
		Class505 @class = new Class505(class509_0, stringBuilder_0.ToString());
		stringBuilder_0.Length = 0;
		int_1 += @class.method_3();
		if (@class.method_2() != null)
		{
			int[] array = @class.method_2();
			foreach (int num in array)
			{
				arrayList_7.Add(num);
			}
		}
		arrayList_4.Add(@class);
		arrayList_5.Add(stringBuilder_1.Length);
	}

	internal void method_1(bool bool_0, int int_3)
	{
		method_0();
		arrayList_3.Add(bool_0);
		arrayList_2.Add(int_1);
		int_0 += int_1;
		int_1 = 0;
		arrayList_6.Add(arrayList_7.Count);
		if (arrayList_4.Count > 0)
		{
			Class505[] array = new Class505[arrayList_4.Count];
			int[] array2 = new int[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (Class505)arrayList_4[i];
				array2[i] = (bool_0 ? (int_3 - (int)arrayList_5[i]) : ((int)arrayList_5[i] - int_3));
			}
			if (bool_0)
			{
				if (array2[0] == int_3 - int_2)
				{
					array2[0] = int.MaxValue;
				}
			}
			else if (array2[array2.Length - 1] == stringBuilder_1.Length - int_3)
			{
				array2[array2.Length - 1] = int.MaxValue;
			}
			arrayList_0.Add(array);
			arrayList_1.Add(array2);
			arrayList_4.Clear();
			arrayList_5.Clear();
		}
		else
		{
			arrayList_0.Add(null);
			arrayList_1.Add(null);
		}
		if (arrayList_9.Count > 0)
		{
			int[] array3 = new int[arrayList_9.Count];
			for (int j = 0; j < array3.Length; j++)
			{
				int num = (int)arrayList_9[j];
				if (num < 0)
				{
					num = -num - 1;
					num = (bool_0 ? (int_3 - num - 1) : (num - int_3));
					num = -num - 1;
				}
				else
				{
					num = (bool_0 ? (int_3 - num - 1) : (num - int_3));
				}
				array3[j] = num;
			}
			arrayList_9.Clear();
			arrayList_8.Add(array3);
		}
		else
		{
			arrayList_8.Add(null);
		}
		int_2 = stringBuilder_1.Length;
	}

	internal void method_2(bool bool_0)
	{
		if (bool_0)
		{
			arrayList_9.Add(stringBuilder_1.Length);
		}
		else
		{
			arrayList_9.Add(-stringBuilder_1.Length - 1);
		}
	}

	[SpecialName]
	internal StringBuilder method_3()
	{
		return stringBuilder_0;
	}

	[SpecialName]
	internal StringBuilder method_4()
	{
		return stringBuilder_1;
	}

	[SpecialName]
	internal int method_5()
	{
		return int_0;
	}

	[SpecialName]
	internal Class505[][] method_6()
	{
		if (arrayList_0.Count > 0)
		{
			Class505[][] array = new Class505[arrayList_0.Count][];
			for (int i = 0; i < array.Length; i++)
			{
				if (arrayList_0[i] != null)
				{
					array[i] = (Class505[])arrayList_0[i];
				}
			}
			return array;
		}
		return null;
	}

	[SpecialName]
	internal int[][] method_7()
	{
		if (arrayList_0.Count > 0)
		{
			int[][] array = new int[arrayList_1.Count][];
			for (int i = 0; i < array.Length; i++)
			{
				if (arrayList_1[i] != null)
				{
					array[i] = (int[])arrayList_1[i];
				}
			}
			return array;
		}
		return null;
	}

	[SpecialName]
	internal int[] method_8()
	{
		if (arrayList_0.Count > 0)
		{
			int[] array = new int[arrayList_2.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (int)arrayList_2[i];
			}
			return array;
		}
		return null;
	}

	[SpecialName]
	internal bool[] method_9()
	{
		if (arrayList_0.Count > 0)
		{
			bool[] array = new bool[arrayList_3.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (bool)arrayList_3[i];
			}
			return array;
		}
		return null;
	}

	[SpecialName]
	internal int[] method_10()
	{
		if (arrayList_7.Count > 0)
		{
			int[] array = new int[arrayList_7.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (int)arrayList_7[i];
			}
			return array;
		}
		return null;
	}

	[SpecialName]
	internal int[] method_11()
	{
		if (arrayList_7.Count > 0)
		{
			int[] array = new int[arrayList_6.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (int)arrayList_6[i];
			}
			return array;
		}
		return null;
	}

	[SpecialName]
	internal int[][] method_12()
	{
		if (arrayList_8.Count > 0)
		{
			int[][] array = new int[arrayList_8.Count][];
			for (int i = 0; i < array.Length; i++)
			{
				if (arrayList_8[i] != null)
				{
					array[i] = (int[])arrayList_8[i];
				}
			}
			return array;
		}
		return null;
	}
}
