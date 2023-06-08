using System.Collections;
using Aspose.Cells;
using ns2;

namespace ns45;

internal class Class1147
{
	internal bool bool_0;

	private ArrayList arrayList_0;

	internal int int_0;

	internal Class1147(bool bool_1, int int_1)
	{
		bool_0 = bool_1;
		arrayList_0 = new ArrayList();
		int_0 = int_1;
	}

	internal void Add(object object_0, int int_1)
	{
		if (object_0 == null)
		{
			Add(0.0, int_1);
		}
		else if (object_0 is double)
		{
			Add((double)object_0, int_1);
		}
		else
		{
			Add((ErrorType)object_0, int_1);
		}
	}

	private void Add(double double_0, int int_1)
	{
		bool flag = false;
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1146 @class = (Class1146)arrayList_0[i];
			if (!(@class.object_0 is ErrorType))
			{
				double num = (double)@class.object_0;
				if (num != double_0)
				{
					if (!(double_0 >= num))
					{
						Class1146 class2 = new Class1146();
						class2.object_0 = double_0;
						class2.arrayList_0.Add(int_1);
						arrayList_0.Insert(i, class2);
						flag = true;
						break;
					}
					continue;
				}
				@class.arrayList_0.Add(int_1);
				flag = true;
				break;
			}
			Class1146 class3 = new Class1146();
			class3.object_0 = double_0;
			class3.arrayList_0.Add(int_1);
			arrayList_0.Insert(i, class3);
			flag = true;
			break;
		}
		if (!flag)
		{
			Class1146 class4 = new Class1146();
			class4.object_0 = double_0;
			class4.arrayList_0.Add(int_1);
			arrayList_0.Add(class4);
		}
		if (arrayList_0.Count > int_0)
		{
			if (bool_0)
			{
				arrayList_0.RemoveAt(0);
			}
			else
			{
				arrayList_0.RemoveAt(arrayList_0.Count - 1);
			}
		}
	}

	private void Add(ErrorType errorType_0, int int_1)
	{
		bool flag = false;
		int num = Class1677.smethod_41(errorType_0);
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1146 @class = (Class1146)arrayList_0[i];
			if (@class.object_0 is ErrorType)
			{
				int num2 = Class1677.smethod_41((ErrorType)@class.object_0);
				if (num == num2)
				{
					@class.arrayList_0.Add(int_1);
					flag = true;
					break;
				}
				if (num < num2)
				{
					Class1146 class2 = new Class1146();
					class2.object_0 = errorType_0;
					class2.arrayList_0.Add(int_1);
					arrayList_0.Insert(i, class2);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			Class1146 class3 = new Class1146();
			class3.object_0 = errorType_0;
			class3.arrayList_0.Add(int_1);
			arrayList_0.Add(class3);
		}
		if (arrayList_0.Count > int_0)
		{
			if (bool_0)
			{
				arrayList_0.RemoveAt(0);
			}
			else
			{
				arrayList_0.RemoveAt(arrayList_0.Count - 1);
			}
		}
	}

	internal Hashtable method_0()
	{
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1146 @class = (Class1146)arrayList_0[i];
			for (int j = 0; j < @class.arrayList_0.Count; j++)
			{
				hashtable.Add(@class.arrayList_0[j], true);
			}
		}
		return hashtable;
	}
}
