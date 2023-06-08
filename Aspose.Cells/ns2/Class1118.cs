using System.Collections;
using Aspose.Cells;

namespace ns2;

internal class Class1118 : CollectionBase
{
	public Class1246 this[int int_0]
	{
		get
		{
			if (int_0 >= base.InnerList.Count)
			{
				return null;
			}
			return (Class1246)base.InnerList[int_0];
		}
	}

	internal void method_0(int int_0)
	{
		int num = 0;
		for (int i = 0; i < base.Count; i++)
		{
			Class1246 @class = (Class1246)base.InnerList[i];
			if (@class.ushort_0 == int_0)
			{
				if (i - num > 1)
				{
					base.InnerList.RemoveAt(i);
					base.InnerList.Insert(num, @class);
				}
				num++;
			}
		}
	}

	internal void method_1(ArrayList arrayList_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Class1246 @class = (Class1246)base.InnerList[i];
			arrayList_0.Add(@class.ushort_0);
			arrayList_0.Add(@class.ushort_1);
			arrayList_0.Add(@class.ushort_2);
		}
	}

	internal void Copy(Class1118 class1118_0)
	{
		base.InnerList.Clear();
		for (int i = 0; i < class1118_0.Count; i++)
		{
			Class1246 @class = class1118_0[i];
			Class1246 value = new Class1246(@class.ushort_0, @class.ushort_1, @class.ushort_2);
			base.InnerList.Add(value);
		}
	}

	internal int method_2(ushort ushort_0, ushort ushort_1, ushort ushort_2)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				Class1246 @class = (Class1246)base.InnerList[num];
				if (@class.ushort_0 == ushort_0 && @class.ushort_1 == ushort_1 && @class.ushort_2 == ushort_2)
				{
					break;
				}
				num++;
				continue;
			}
			Class1246 value = new Class1246(ushort_0, ushort_1, ushort_2);
			base.InnerList.Add(value);
			return base.InnerList.Count - 1;
		}
		return num;
	}

	internal int method_3(ushort ushort_0, ushort ushort_1, ushort ushort_2)
	{
		Class1246 value = new Class1246(ushort_0, ushort_1, ushort_2);
		base.InnerList.Add(value);
		return base.Count - 1;
	}

	internal void method_4(ushort ushort_0, int int_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Class1246 @class = (Class1246)base.InnerList[i];
			if (@class.ushort_0 == int_0)
			{
				if (ushort_0 >= @class.ushort_1 && ushort_0 <= @class.ushort_2)
				{
					@class.ushort_1 = ushort.MaxValue;
					@class.ushort_2 = ushort.MaxValue;
				}
				else if (ushort_0 < @class.ushort_1 && ushort_0 < @class.ushort_2 && @class.ushort_1 < 65534 && @class.ushort_2 < 65534)
				{
					@class.ushort_1--;
					@class.ushort_2--;
				}
			}
		}
	}

	internal void method_5(int int_0, int int_1, int int_2)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Class1246 @class = (Class1246)base.InnerList[i];
			if (@class.ushort_0 == int_0)
			{
				if (@class.ushort_1 < int_2 && @class.ushort_1 >= int_1)
				{
					@class.ushort_1++;
				}
				if (@class.ushort_2 < int_2 && @class.ushort_2 >= int_1)
				{
					@class.ushort_2++;
				}
			}
		}
		Class1246 value = new Class1246((ushort)int_0, (ushort)int_1, (ushort)int_1);
		base.InnerList.Add(value);
	}

	internal void method_6(int int_0, int int_1, int int_2)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Class1246 @class = (Class1246)base.InnerList[i];
			if (@class.ushort_0 != int_0)
			{
				continue;
			}
			if (int_1 == @class.ushort_1)
			{
				if (int_1 == @class.ushort_2)
				{
					@class.ushort_1 = (ushort)int_2;
					@class.ushort_2 = (ushort)int_2;
				}
				else if (int_2 >= @class.ushort_2)
				{
					@class.ushort_2--;
				}
				else
				{
					@class.ushort_1 = (ushort)int_2;
				}
			}
			else if (int_1 < @class.ushort_1)
			{
				if (int_2 >= @class.ushort_1)
				{
					@class.ushort_1--;
					if (int_2 >= @class.ushort_2)
					{
						@class.ushort_2--;
					}
				}
			}
			else if (int_1 < @class.ushort_2)
			{
				if (int_2 >= @class.ushort_2)
				{
					@class.ushort_2--;
				}
				else if (int_2 <= @class.ushort_1)
				{
					@class.ushort_1++;
				}
			}
			else if (int_1 == @class.ushort_2)
			{
				if (int_2 <= @class.ushort_1)
				{
					@class.ushort_1++;
				}
				else
				{
					@class.ushort_2 = (ushort)int_2;
				}
			}
			else if (int_2 <= @class.ushort_2)
			{
				@class.ushort_2++;
				if (int_2 <= @class.ushort_1)
				{
					@class.ushort_1++;
				}
			}
		}
	}

	internal int method_7(int int_0, int int_1, int int_2)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				Class1246 @class = (Class1246)base.InnerList[num];
				if (@class.ushort_0 == int_0 && int_1 == @class.ushort_1 && int_2 == @class.ushort_2)
				{
					break;
				}
				num++;
				continue;
			}
			Class1246 value = new Class1246((ushort)int_0, (ushort)int_1, (ushort)int_2);
			base.InnerList.Add(value);
			return base.Count - 1;
		}
		return num;
	}

	internal int method_8(int int_0, int int_1)
	{
		if (int_1 == -1)
		{
			int_1 = 65535;
		}
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				Class1246 @class = (Class1246)base.InnerList[num];
				if (@class.ushort_0 == int_0 && int_1 == @class.ushort_1 && int_1 == @class.ushort_2)
				{
					break;
				}
				num++;
				continue;
			}
			if (int_1 == 65535)
			{
				Class1246 value = new Class1246((ushort)int_0, (ushort)int_1, (ushort)int_1);
				base.InnerList.Add(value);
				return base.Count - 1;
			}
			return -1;
		}
		return num;
	}

	internal int[] method_9(int int_0, int int_1)
	{
		if (int_1 == -1)
		{
			int_1 = 65535;
		}
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i < base.Count; i++)
		{
			Class1246 @class = (Class1246)base.InnerList[i];
			if (@class.ushort_0 == int_0 && int_1 == @class.ushort_1 && int_1 == @class.ushort_2)
			{
				arrayList.Add(i);
			}
		}
		if (arrayList.Count != 0)
		{
			int[] array = new int[arrayList.Count];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = (int)arrayList[j];
			}
			return array;
		}
		if (int_1 == 65535)
		{
			Class1246 value = new Class1246((ushort)int_0, (ushort)int_1, (ushort)int_1);
			return new int[1] { base.InnerList.Add(value) };
		}
		return new int[1] { -1 };
	}

	internal int method_10(int int_0, int int_1, int int_2)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				Class1246 @class = (Class1246)base.InnerList[num];
				if (@class.ushort_0 == int_0 && int_1 == @class.ushort_1 && int_2 == @class.ushort_2)
				{
					break;
				}
				num++;
				continue;
			}
			return -1;
		}
		return num;
	}

	internal int method_11(int int_0, int int_1, int int_2, bool bool_0)
	{
		int num = 0;
		while (true)
		{
			if (num < base.Count)
			{
				Class1246 @class = (Class1246)base.InnerList[num];
				if (@class.ushort_0 == int_0 && int_1 == @class.ushort_1 && int_2 == @class.ushort_2)
				{
					break;
				}
				num++;
				continue;
			}
			if (bool_0)
			{
				return method_3((ushort)int_0, (ushort)int_1, (ushort)int_2);
			}
			return -1;
		}
		return num;
	}

	internal int method_12(int int_0)
	{
		return this[int_0].ushort_0;
	}

	internal int method_13(int int_0)
	{
		return this[int_0].ushort_1;
	}

	internal void method_14(int int_0, Hashtable hashtable_0)
	{
		for (int i = 0; i < base.Count; i++)
		{
			Class1246 @class = (Class1246)base.InnerList[i];
			if (@class.ushort_0 == int_0)
			{
				int ushort_ = @class.ushort_1;
				int ushort_2 = @class.ushort_2;
				if (hashtable_0[ushort_] != null)
				{
					@class.ushort_1 = (ushort)(int)hashtable_0[ushort_];
				}
				if (hashtable_0[ushort_2] != null)
				{
					@class.ushort_2 = (ushort)(int)hashtable_0[ushort_2];
				}
			}
		}
	}

	internal int method_15(WorksheetCollection worksheetCollection_0, int int_0)
	{
		Class1246 @class = this[int_0];
		if (worksheetCollection_0.method_36() != @class.ushort_0)
		{
			return -1;
		}
		if (@class.ushort_1 == @class.ushort_2)
		{
			return @class.ushort_1;
		}
		return -1;
	}
}
