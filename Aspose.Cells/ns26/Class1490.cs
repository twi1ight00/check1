using System.Collections;
using Aspose.Cells;

namespace ns26;

internal class Class1490
{
	internal Worksheet worksheet_0;

	private Class1489 class1489_0;

	internal ArrayList arrayList_0;

	internal ArrayList arrayList_1;

	internal int int_0;

	internal double double_0;

	internal Class1490(Class1489 class1489_1, Worksheet worksheet_1)
	{
		worksheet_0 = worksheet_1;
		class1489_0 = class1489_1;
		arrayList_1 = new ArrayList();
		int_0 = 0;
		arrayList_0 = new ArrayList();
	}

	internal void method_0(int int_1)
	{
		for (int i = 0; i < arrayList_0.Count; i++)
		{
			Class1488 @class = (Class1488)arrayList_0[i];
			@class.method_0(class1489_0, int_1);
		}
	}

	internal int method_1(int int_1)
	{
		int num = 0;
		Class1488 @class;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				@class = (Class1488)arrayList_0[num];
				if (int_1 >= @class.int_1 && int_1 < @class.int_1 + @class.int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return 15;
		}
		return @class.int_3;
	}

	internal int method_2(int int_1)
	{
		int num = 0;
		Class1488 @class;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				@class = (Class1488)arrayList_0[num];
				if (int_1 >= @class.int_1 && int_1 < @class.int_1 + @class.int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return 15;
		}
		return @class.int_2;
	}

	internal Class1488 method_3(int int_1)
	{
		int num = 0;
		Class1488 @class;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				@class = (Class1488)arrayList_0[num];
				if (int_1 >= @class.int_1 && int_1 < @class.int_1 + @class.int_0)
				{
					break;
				}
				num++;
				continue;
			}
			return null;
		}
		return @class;
	}

	internal Class1488 method_4(int int_1, int int_2)
	{
		int num = 0;
		Class1488 @class;
		while (true)
		{
			if (num < arrayList_0.Count)
			{
				@class = (Class1488)arrayList_0[num];
				if (int_1 >= @class.int_1 && int_1 < @class.int_1 + @class.int_0)
				{
					break;
				}
				num++;
				continue;
			}
			Class1488 class2 = new Class1488();
			class2.int_1 = int_1;
			class2.int_0 = int_2;
			arrayList_0.Add(class2);
			return class2;
		}
		if (@class.int_1 == int_1)
		{
			if (@class.int_0 > int_2)
			{
				int num2 = @class.int_1 + @class.int_0;
				@class.int_0 = int_2;
				Class1488 class3 = new Class1488();
				class3.Copy(@class);
				class3.int_1 = int_1 + int_2;
				class3.int_0 = num2 - class3.int_1;
				arrayList_0.Insert(num + 1, class3);
			}
			return @class;
		}
		int num3 = @class.int_1 + @class.int_0;
		int num4 = int_1 + int_2;
		@class.int_0 = int_1 - @class.int_1 + 1;
		Class1488 class4 = new Class1488();
		class4.Copy(@class);
		class4.int_1 = int_1;
		arrayList_0.Insert(num + 1, class4);
		if (num3 == num4)
		{
			class4.int_0 = num4 - class4.int_1;
			return class4;
		}
		if (num3 > num4)
		{
			int num5 = num3;
			num3 = num4;
			num4 = num5;
		}
		Class1488 class5 = new Class1488();
		class5.Copy(@class);
		class5.int_1 = num3;
		class5.int_0 = num4 - num3;
		arrayList_0.Insert(num + 2, class5);
		return class4;
	}

	internal Class1354 GetRow(int int_1)
	{
		if (int_0 >= arrayList_1.Count)
		{
			return null;
		}
		while (true)
		{
			if (int_0 < arrayList_1.Count)
			{
				Class1354 @class = (Class1354)arrayList_1[int_0];
				if (int_1 < @class.int_0)
				{
					break;
				}
				if (int_1 >= @class.int_0 + @class.int_1)
				{
					int_0++;
					continue;
				}
				return @class;
			}
			return null;
		}
		return null;
	}
}
