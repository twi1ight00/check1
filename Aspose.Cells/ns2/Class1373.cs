using System.Collections;
using System.Runtime.CompilerServices;
using ns16;

namespace ns2;

internal class Class1373
{
	internal ArrayList arrayList_0;

	internal Class1363 class1363_0;

	internal int MaxRow
	{
		get
		{
			if (arrayList_0.Count == 0)
			{
				return 0;
			}
			return ((Class1117)arrayList_0[arrayList_0.Count - 1]).Index;
		}
	}

	internal int MinRow
	{
		get
		{
			if (arrayList_0.Count == 0)
			{
				return 0;
			}
			return ((Class1117)arrayList_0[0]).Index;
		}
	}

	[SpecialName]
	internal Class1363 method_0()
	{
		if (class1363_0 == null)
		{
			class1363_0 = new Class1363();
		}
		return class1363_0;
	}

	internal Class1373()
	{
		arrayList_0 = new ArrayList();
	}

	internal void Copy(Class1373 class1373_0)
	{
		arrayList_0 = new ArrayList(class1373_0.arrayList_0.Count);
		for (int i = 0; i < class1373_0.arrayList_0.Count; i++)
		{
			Class1117 @class = (Class1117)class1373_0.arrayList_0[i];
			Class1117 class2 = new Class1117(@class.Index);
			arrayList_0.Add(class2);
			class2.Copy(@class);
		}
	}

	[SpecialName]
	internal bool method_1()
	{
		return arrayList_0.Count != 0;
	}

	internal int method_2(int int_0, int int_1)
	{
		if (arrayList_0.Count == 0)
		{
			return -1;
		}
		int num = 0;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				Class1117 @class = (Class1117)arrayList_0[num];
				if (@class.Index <= int_1)
				{
					if (@class.Index >= int_0)
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return -1;
		}
		return num;
	}

	internal Class1117 method_3(int int_0)
	{
		if (arrayList_0.Count == 0)
		{
			return null;
		}
		int num = 0;
		int num2 = arrayList_0.Count - 1;
		int num3 = 0;
		Class1117 @class = (Class1117)arrayList_0[num2];
		if (@class.Index == int_0)
		{
			return @class;
		}
		if (@class.Index < int_0)
		{
			return null;
		}
		while (true)
		{
			if (num <= num2)
			{
				num3 = (num + num2) / 2;
				@class = (Class1117)arrayList_0[num3];
				if (@class.Index == int_0)
				{
					break;
				}
				if (@class.Index < int_0)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3 - 1;
				}
				continue;
			}
			return null;
		}
		return @class;
	}

	internal object method_4(int int_0, int int_1)
	{
		return method_3(int_0)?.method_10(int_1);
	}

	internal Class1117 GetRow(int int_0)
	{
		if (arrayList_0.Count == 0)
		{
			Class1117 @class = new Class1117(int_0);
			arrayList_0.Add(@class);
			return @class;
		}
		int num = 0;
		int num2 = arrayList_0.Count - 1;
		int num3 = 0;
		Class1117 class2 = (Class1117)arrayList_0[num2];
		if (class2.Index == int_0)
		{
			return class2;
		}
		if (class2.Index < int_0)
		{
			Class1117 class3 = new Class1117(int_0);
			arrayList_0.Add(class3);
			return class3;
		}
		while (true)
		{
			if (num <= num2)
			{
				num3 = (num + num2) / 2;
				class2 = (Class1117)arrayList_0[num3];
				if (class2.Index == int_0)
				{
					break;
				}
				if (class2.Index < int_0)
				{
					num = num3 + 1;
				}
				else
				{
					num2 = num3 - 1;
				}
				continue;
			}
			Class1117 class4 = new Class1117(int_0);
			if (class2.Index < int_0)
			{
				arrayList_0.Insert(num3 + 1, class4);
			}
			else
			{
				arrayList_0.Insert(num3, class4);
			}
			return class4;
		}
		return class2;
	}

	internal void method_5(int int_0, int int_1, object object_0)
	{
		Class1117 row = GetRow(int_0);
		row.Add(int_1, object_0);
	}
}
