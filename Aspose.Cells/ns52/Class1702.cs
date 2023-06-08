using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Aspose.Cells.Drawing;

namespace ns52;

internal class Class1702
{
	private Class1705 class1705_0;

	private Class1703 class1703_0;

	private ArrayList arrayList_0;

	private ushort ushort_0;

	internal int Length => 16 + arrayList_0.Count * 8;

	internal Class1702(Class1703 class1703_1)
	{
		class1703_0 = class1703_1;
		arrayList_0 = new ArrayList();
		class1705_0 = new Class1705();
	}

	internal void Copy(Class1702 class1702_0)
	{
		class1705_0.Copy(class1702_0.class1705_0);
		ushort_0 = class1702_0.ushort_0;
		arrayList_0.Clear();
		for (int i = 0; i < class1702_0.arrayList_0.Count; i++)
		{
			Class1706 class1706_ = (Class1706)class1702_0.arrayList_0[i];
			Class1706 @class = new Class1706();
			@class.Copy(class1706_);
			arrayList_0.Add(@class);
		}
	}

	[SpecialName]
	internal Class1705 method_0()
	{
		return class1705_0;
	}

	[SpecialName]
	internal ArrayList method_1()
	{
		return arrayList_0;
	}

	[SpecialName]
	internal ushort method_2()
	{
		return ushort_0;
	}

	[SpecialName]
	internal void method_3(ushort ushort_1)
	{
		ushort_0 = ushort_1;
	}

	internal Class1701 method_4(ShapeCollection shapeCollection_0, Class1703 class1703_1)
	{
		ushort_0++;
		Class1706 @class = new Class1706();
		@class.int_0 = ushort_0;
		@class.int_1 = 1;
		method_1().Add(@class);
		int num = arrayList_0.Count * 1024 + 1;
		if (num < method_0().int_0)
		{
			int num2 = (int)Math.Ceiling((double)(method_0().int_0 - 1) / 1024.0);
			if (num2 > arrayList_0.Count)
			{
				num = (method_0().int_0 / 1024 + 1) * 1024 + 1;
			}
		}
		method_0().int_0 = num;
		method_0().int_2 = 1;
		method_0().int_1 = 1;
		return new Class1701(shapeCollection_0, class1703_1, ushort_0, method_0().int_0 - 1);
	}

	internal int method_5(int int_0, int int_1)
	{
		int num = arrayList_0.Count - 1;
		while (num >= 0)
		{
			Class1706 @class = (Class1706)arrayList_0[num];
			if (@class.int_0 != int_0)
			{
				num--;
				continue;
			}
			if ((@class.int_1 + int_1) / 1024 != 1)
			{
				break;
			}
			@class = new Class1706();
			@class.int_0 = int_0;
			@class.int_1 = 1;
			arrayList_0.Add(@class);
			int num2 = arrayList_0.Count * 1024 + 1;
			if (num2 < method_0().int_0)
			{
				int num3 = (int)Math.Ceiling((double)(method_0().int_0 - 1) / 1024.0);
				if (num3 > arrayList_0.Count)
				{
					num2 = (method_0().int_0 / 1024 + 1) * 1024 + 1;
				}
			}
			num2--;
			method_0().int_0 = num2;
			return method_0().int_0;
		}
		return -1;
	}

	internal int AddShape(int int_0, int int_1)
	{
		method_0().int_1 += int_1;
		int num = arrayList_0.Count - 1;
		while (num >= 0)
		{
			Class1706 @class = (Class1706)arrayList_0[num];
			if (@class.int_0 != int_0)
			{
				num--;
				continue;
			}
			if (num == arrayList_0.Count - 1 && method_0().int_0 / 1024 <= arrayList_0.Count)
			{
				method_0().int_0 = (arrayList_0.Count + 1) * 1024 + 1;
			}
			@class.int_1 += int_1;
			if (int_1 != 1 || @class.int_1 == 1 || @class.int_1 % 1024 != 1)
			{
				break;
			}
			@class.int_1--;
			@class = new Class1706();
			@class.int_0 = int_0;
			@class.int_1 = 1;
			arrayList_0.Add(@class);
			int num2 = arrayList_0.Count * 1024 + 1;
			if (num2 < method_0().int_0)
			{
				int num3 = (int)Math.Ceiling((double)(method_0().int_0 - 1) / 1024.0);
				if (num3 > arrayList_0.Count)
				{
					num2 = (method_0().int_0 / 1024 + 1) * 1024 + 1;
				}
			}
			method_0().int_0 = num2;
			return method_0().int_0;
		}
		return -1;
	}
}
